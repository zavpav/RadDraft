using Rad.Db;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Rad.Controllers;

/// <summary> Справочник РАД </summary>
[ApiController]
[Route("SprRad")]
public class SprRadController : Controller
{
    private readonly IDbContextFactory<RadDbContext> _dbContextFactory;

    public SprRadController(IDbContextFactory<RadDbContext> dbContextFactory)
    {
        this._dbContextFactory = dbContextFactory;
    }

    /// <summary> Список всех данных РАД </summary>
    [HttpGet("List")]
    public async Task<IActionResult> List(UserContext userContext, DxDataSourceLoadOptions loadOptions)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        var source = dbContext.SprRads.AsNoTracking();
        var data = await DataSourceLoader.LoadAsync(source, loadOptions);
        return Json(data);
    }

    /// <summary> Получить полный документ </summary>
    [HttpGet("Entity")]
    public async Task<IActionResult> Get(long id)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        var rad = await dbContext.SprRads
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

        //var options = new Newtonsoft.Json.JsonSerializerSettings
        //{
        //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        //};
        return Json(rad);
    }
}
