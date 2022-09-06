using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rad.Db;
using Rad.Domain.Docs.Grbs.KuDetail;

namespace Rad.Controllers.Grbs;
    
/// <summary> Детализация КУ </summary>
[Route("DocGrbs/KuDetail")]
[ApiController]
public class DocKuDetailController : Controller
{
    private readonly IDbContextFactory<GrbsDbContext> _dbContextFactory;
    private readonly MapperConfiguration _autoMapperConfiguration;
    private readonly ILogger _logger;

    public DocKuDetailController(IDbContextFactory<GrbsDbContext> dbContextFactory, ILogger logger)
    {
        this._dbContextFactory = dbContextFactory;
        this._logger = logger;
        this._autoMapperConfiguration = new MapperConfiguration(
            c =>
            {
                c.CreateProjection<DocKuDetail, DocKuDetailListDto>();
                c.CreateProjection<DocKuDetail, DocKuDetailItemDto>();
                c.CreateProjection<DocKuDetailRow, DocKuDetailItemRowDto>();

            }
            );
    }

    #region Работа со списком документов

    /// <summary> Получить список всех документов Детализация КУ </summary>
    [HttpGet("List")]
    public async Task<IActionResult> List(UserContext userContext, DxDataSourceLoadOptions loadOptions)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();

        this._logger.Here().Warning("Выборка прибита к росписи");

        var source = dbContext.KuDetails
                .Where(x => x.BrSid == StubConstants.BrId)
                .AsNoTracking()
                .ProjectTo<DocKuDetailListDto>(this._autoMapperConfiguration);
        var data = await DataSourceLoader.LoadAsync(source, loadOptions);

        if (data.data is List<DocKuDetailListDto> rawRad)
            data.data = await this.ListUpdateDto(rawRad);

        return Json(data);
    }

    /// <summary> Обновление "действий" для документов </summary>
    private async Task<List<DocKuDetailListDto>> ListUpdateDto(List<DocKuDetailListDto> docList)
    {
        await Task.Yield();

        foreach (var doc in docList)
        {
            doc.Actions = new[] {
                new ObjectAction("edit")
        };
        }

        return docList;
    }

    /// <summary> DTO представления документа Детализация КУ для списка </summary>
    public class DocKuDetailListDto : DefaultDocDistributionListDto
    {
    }
    #endregion Работа со списком документов

    #region Работа с отдельным документом
    /// <summary> Получить полный документ </summary>
    [HttpGet("Entity")]
    public async Task<JsonResult> Get(long id, bool withMeta = false)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        var doc = await dbContext.KuDetails
                .Include(x => x.Rows)
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<DocKuDetailItemDto>(this._autoMapperConfiguration)
                .FirstOrDefaultAsync();

        //var options = new Newtonsoft.Json.JsonSerializerSettings
        //{
        //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        //};

        if (!withMeta)
            return Json(doc);

        return Json(DataWithMetaHelper.ReturnWithMeta(doc));
    }

    /// <summary> DTO редактирования документа Детализация КУ </summary>
    public class DocKuDetailItemDto : DefaultDocDistributionItemDto
    {
        public ICollection<DocKuDetailItemRowDto> Rows { get; set; } = null!;
    }

    /// <summary> DTO строки документа Детализация КУ </summary>
    public class DocKuDetailItemRowDto: DefaultDocDistributionItemRowDto
    {

    }

    #endregion Работа с отдельным документом
}
