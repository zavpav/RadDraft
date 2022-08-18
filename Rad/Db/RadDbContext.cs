//dotnet ef migrations add Intial -c Context -o Database 
//dotnet ef database update
//docker run -d -p 5441:5432 --name TestGraphQl -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=123456 postgres:14

//https://devexpress.github.io/DevExtreme.AspNet.Data/net/api/DevExtreme.AspNet.Data.DataSourceLoadOptionsBase.html
namespace Rad.Db;

/// <summary> Контекст РАДа </summary>
public class RadDbContext : DbContext
{
    public RadDbContext(DbContextOptions<RadDbContext> options) : base(options)
    {
    }

    /// <summary> Список документов РАД </summary>
    public DbSet<DocRad> DocRads { get; set; } = null!;

    /// <summary> Список строк документов РАД </summary>
    public DbSet<DocRadRow> DocRadRows { get; set; } = null!;

    /// <summary> Справочник РАД </summary>
    public DbSet<SprRad> SprRads { get; set; } = null!;

    /// <summary> КБК доходов </summary>
    public DbSet<SprKbkIncome> SprKbkIncomes { get; set; } = null!;
}