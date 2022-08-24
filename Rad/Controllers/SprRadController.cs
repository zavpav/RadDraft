using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    private readonly MapperConfiguration _autoMapperConfiguration;

    public SprRadController(IDbContextFactory<RadDbContext> dbContextFactory)
    {
        this._dbContextFactory = dbContextFactory;
        this._autoMapperConfiguration = new MapperConfiguration(
            c => c.CreateProjection<SprRad, SprRadListDto>());

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
                    new ObjectAction() { Operation = "edit" },
                    new ObjectAction() { Operation = "delete" },
                    new ObjectAction() { Operation = "print" },
                };
            else if (op == 1)
            {
                sprRad.Actions = new[] {
                    new ObjectAction() { Operation = "edit" },
                };
            }
            else
                sprRad.Actions = new[] {
                    new ObjectAction() { Operation = "edit" },
                    new ObjectAction() { Operation = "delete" },
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
    public async Task<JsonResult> Get(long id)
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
