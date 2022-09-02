using Rad.Db;
using Rad.Services.Queue;
using Rad.SignalR;
using Serilog;
using Serilog.Events;
using System.Reflection;
using System.Text.Json.Serialization;

Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.Udp("localhost", 8083, System.Net.Sockets.AddressFamily.InterNetwork, new LogUdpFormatter())
        .CreateLogger();

Log.Logger.Here().Fatal("Start {Start}", DateTime.Now);

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddPooledDbContextFactory<RadDbContext>(opt => opt
        .UseNpgsql($"Host=localhost;Port=5441;Database=postgres;Username=postgres;Password=123456")
        .AddInterceptors(new DbLogInterceptor(Log.Logger))
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging(true)
        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
        );

builder.Services.AddSignalR()
    .AddJsonProtocol(opt => opt.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddHostedService<QueuedHostedService>();
builder.Services.AddSingleton<IBackgroundTaskQueue>(ctx =>
{
    var queueCapacity = 100; // надо определять в переменных окружения
    return new BackgroundTaskQueue(queueCapacity);
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), includeControllerXmlComments: true);
});

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestBody |
           Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPath |
           Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestQuery |
           Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPropertiesAndHeaders |
           Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestHeaders |
           Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestScheme |
           Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestTrailers |
           Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestMethod;
    logging.RequestBodyLogLimit = 4096;
    //logging.ResponseBodyLogLimit = 1;
});

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors(b => {
    b.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    //b.AllowAnyHeader();
    ////b.AllowAnyMethod();
    ////b.AllowCredentials();
    //b.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapHub<NotifyHub>("/notify");

app.MapControllers();

app.Run();
