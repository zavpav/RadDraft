using Rad.Db;

namespace Rad.Controllers;

/// <summary> Документы РАД </summary>
[Route("DocRad")]
[ApiController]
public class DocRadController : Controller
{
    private readonly IDbContextFactory<RadDbContext> _dbContextFactory;

    /// <summary> Документы РАД </summary>
    public DocRadController(IDbContextFactory<RadDbContext> dbContextFactory)
    {
        this._dbContextFactory = dbContextFactory;
    }

    /// <summary> Получить список всех документов РАД </summary>
    [HttpGet("List")]
    public async Task<IActionResult> List(UserContext userContext, DxDataSourceLoadOptions loadOptions)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        var source = dbContext.DocRads
                .AsNoTracking()
                .Select(x =>
                new {
                    x.Id,
                    x.DocNum,
                    x.DocDt,
                    x.Descr,
                    StatusName = "Статус " + x.Status,
                    UserName = "Пользователь"
                });
        var data = await DataSourceLoader.LoadAsync(source, loadOptions);
        return Json(data);
    }

    /// <summary> Получить полный документ </summary>
    [HttpGet("Entity")]
    public async Task<IActionResult> Get(long id)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        var rad = await dbContext.DocRads
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.DocRows)
                .FirstOrDefaultAsync();
        return Json(rad);
    }

}
