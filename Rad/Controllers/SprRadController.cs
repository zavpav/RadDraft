using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.SignalR;
using Rad.Db;
using Rad.Services.Queue;
using Rad.SignalR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rad.Controllers;

/// <summary> Справочник РАД </summary>
[ApiController]
[Route("SprRad")]
public class SprRadController : Controller
{
    private readonly IDbContextFactory<RadDbContext> _dbContextFactory;
    private readonly MapperConfiguration _autoMapperConfiguration;

    private readonly IBackgroundTaskQueue _taskQueue;
    private readonly IHubContext<NotifyHub, IClientNotifier> _hubContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SprRadController(IDbContextFactory<RadDbContext> dbContextFactory, 
        IBackgroundTaskQueue taskQueue,
        IHubContext<NotifyHub, IClientNotifier> hubContext,
        IHttpContextAccessor httpContextAccessor)
    {
        this._dbContextFactory = dbContextFactory;

        this._taskQueue = taskQueue;
        this._hubContext = hubContext;
        this._httpContextAccessor = httpContextAccessor;

        this._autoMapperConfiguration = new MapperConfiguration(
            c => { 
                c.CreateProjection<SprRad, SprRadListDto>(); 
                c.CreateProjection<SprRad, SprRadItemDto>();
                c.CreateMap<SprRadItemDto, SprRad>();
            });

    }

    /// <summary> Список всех данных РАД </summary>
    [HttpGet("List")]
    public async Task<JsonResult> List(UserContext userContext, DxDataSourceLoadOptions loadOptions)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        var source = dbContext.SprRads.AsNoTracking().ProjectTo<SprRadListDto>(this._autoMapperConfiguration);
        var data = await DataSourceLoader.LoadAsync(source, loadOptions);
        if (data.data is List<SprRadListDto> rawRad)
        {
            data.data = await this.ListUpdateDto(rawRad);
        }
        return Json(data);
    }

    private async Task<List<SprRadListDto>> ListUpdateDto(List<SprRadListDto> sprRadList)
    {
        await Task.Yield();
        foreach (var sprRad in sprRadList)
        {
            var op = Random.Shared.Next(3);
            if (op == 2)
                sprRad.Actions = new[] { 
                    new ObjectAction("edit"),
                    new ObjectAction("delete"),
                    new ObjectAction("print"),
                };
            else if (op == 1)
            {
                sprRad.Actions = new[] {
                    new ObjectAction("edit"),
                };
            }
            else
                sprRad.Actions = new[] {
                    new ObjectAction("edit"),
                    new ObjectAction("delete"),
                };
        }
        return sprRadList;
    }

    /// <summary> Dto для объекта выгружаемого в список Данных РАД </summary>
    public class SprRadListDto 
    {
        /// <summary> ИД </summary>
        public long Id { get; set; }

        /// <summary> Полное наименование </summary>
        public string FullName { get; set; } = "";

        /// <summary> ИНН организации </summary>
        public string Inn { get; set; } = "";

        /// <summary> КПП организации </summary>
        public string Kpp { get; set; } = "";

        /// <summary> КБК </summary>
        public string Kbk { get; set; } = "";

        /// <summary> Дата создания </summary>
        public DateTime OnDate { get; set; }

        /// <summary> Дата закрытия организации (null если ещё активна) </summary>
        public DateTime? ToDate { get; set; }

        /// <summary> Допустимые действия для пользователя для объекта </summary>
        public ObjectAction[] Actions { get; set; } = new ObjectAction[0];
    }


    /// <summary> Получить полный документ </summary>
    [HttpGet("Entity")]
    public async Task<JsonResult> Get(long id, bool withMeta = false)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        var rad = await dbContext.SprRads
                .AsNoTracking()
                .ProjectTo<SprRadItemDto>(this._autoMapperConfiguration)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

        //var options = new Newtonsoft.Json.JsonSerializerSettings
        //{
        //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        //};

        if (!withMeta)
            return Json(rad);

        return Json(DataWithMetaHelper.ReturnWithMeta(rad));
    }

    [HttpPost("Entity")]
    public async Task<IActionResult> Save([FromBody] SprRadItemDto fullRadItem)
    {
        var mapper = this._autoMapperConfiguration.CreateMapper();

        if (fullRadItem.Id != null && fullRadItem.Id != 0)
        {
            using var dbContext = await this._dbContextFactory.CreateDbContextAsync();

            var orig = await dbContext.SprRads.FirstAsync(x => x.Id == fullRadItem.Id);
            mapper.Map(fullRadItem, orig);
            //            dbContext.Entry(newVersion).State = EntityState.Modified;

            await dbContext.SaveChangesAsync();
        }
        else if (fullRadItem.Id == null || fullRadItem.Id == 0)
        {
            using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
            var newVersion = mapper.Map<SprRad>(fullRadItem);
            await dbContext.SprRads.AddAsync(newVersion);
            await dbContext.SaveChangesAsync();
        }

        return Ok();
    }

    private string ConnectionId
    {
        get
        {
            return _httpContextAccessor?.HttpContext?.Request.Headers["x-signalr-connection"] ?? "";
        }
    }


    /// <summary> Dto для объекта выгружаемого в список Данных РАД </summary>
    public class SprRadItemDto
    {
        /// <summary> ИД </summary>
        [Description("ИД")]
        public long? Id { get; set; }

        /// <summary> Полное наименование </summary>
        [Description("Полное наименование")]
        [MaxLength(1000)]
        public string FullName { get; set; } = "";

        /// <summary> ИНН организации </summary>
        [Description("ИНН")]
        public string Inn { get; set; } = "";

        /// <summary> КПП организации </summary>
        [Description("КПП")]
        public string Kpp { get; set; } = "";

        /// <summary> КБК </summary>
        [Description("КБК")]
        public string Kbk { get; set; } = "";

        /// <summary> Дата создания </summary>
        [Description("Дата создания")]
        public DateTime OnDate { get; set; }

        /// <summary> Дата закрытия (null если ещё активна) </summary>
        [Description("Дата закрытия")]
        public DateTime? ToDate { get; set; }

        public string? AnyData { get; set; }
    }
}
