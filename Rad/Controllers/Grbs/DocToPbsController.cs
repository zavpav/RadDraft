using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rad.Db;
using Rad.Domain.Docs.Grbs.ToPbs;

namespace Rad.Controllers.Grbs;
    
/// <summary> Распределения по ПБС </summary>
[Route("DocGrbs/ToPbs")]
[ApiController]
public class DocToPbsController : Controller
{
    private readonly IDbContextFactory<GrbsDbContext> _dbContextFactory;
    private readonly MapperConfiguration _autoMapperConfiguration;
    private readonly ILogger _logger;

    public DocToPbsController(IDbContextFactory<GrbsDbContext> dbContextFactory, ILogger logger)
    {
        this._dbContextFactory = dbContextFactory;
        this._logger = logger;
        this._autoMapperConfiguration = new MapperConfiguration(
            c =>
            {
                c.CreateProjection<DocToPbs, DocToPbsListDto>();
                c.CreateProjection<DocToPbs, DocToPbsItemDto>();
                c.CreateProjection<DocToPbsRow, DocToPbsItemRowDto>();
            }
            );
    }


    #region Работа со списком документов

    /// <summary> Получить список всех документов Распределение по ПБС </summary>
    [HttpGet("List")]
    public async Task<IActionResult> List(UserContext userContext, DxDataSourceLoadOptions loadOptions)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        
        this._logger.Here().Warning("Выборка прибита к росписи");

        var source = dbContext.ToPbs
                .Where(x => x.BrSid == StubConstants.BrId)
                .AsNoTracking()
                .ProjectTo<DocToPbsListDto>(this._autoMapperConfiguration);
        var data = await DataSourceLoader.LoadAsync(source, loadOptions);

        if (data.data is List<DocToPbsListDto> rawRad)
            data.data = await this.ListUpdateDto(rawRad);

        return Json(data);
    }

    /// <summary> Обновление "действий" для документов </summary>
    private async Task<List<DocToPbsListDto>> ListUpdateDto(List<DocToPbsListDto> docList)
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

    /// <summary> DTO представления документа Распределение по ПБС для списка </summary>
    public class DocToPbsListDto : DefaultDocDistributionListDto
    {
    }
    #endregion Работа со списком документов

    #region Работа с отдельным документом
    /// <summary> Получить полный документ </summary>
    [HttpGet("Entity")]
    public async Task<JsonResult> Get(long id, bool withMeta = false)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        var doc = await dbContext.ToPbs
                .Include(x => x.Rows)
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ProjectTo<DocToPbsItemDto>(this._autoMapperConfiguration)
                .FirstOrDefaultAsync();

        //var options = new Newtonsoft.Json.JsonSerializerSettings
        //{
        //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        //};

        if (!withMeta)
            return Json(doc);

        return Json(DataWithMetaHelper.ReturnWithMeta(doc));
    }

    /// <summary> DTO редактирования документа Распределение по ПБС </summary>
    public class DocToPbsItemDto : DefaultDocDistributionItemDto
    {
        public ICollection<DocToPbsItemRowDto> Rows { get; set; } = null!;
    }

    /// <summary> DTO строки документа Распределение по ПБС </summary>
    public class DocToPbsItemRowDto : DefaultDocDistributionItemRowDto
    {

    }

    #endregion Работа с отдельным документом

}
