using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rad.Db;
using System.ComponentModel;

namespace Rad.Controllers;

/// <summary> Документы РАД </summary>
[Route("DocRad")]
[ApiController]
public class DocRadController : Controller
{
    private readonly IDbContextFactory<RadDbContext> _dbContextFactory;

    private readonly MapperConfiguration _autoMapperConfiguration;

    /// <summary> Документы РАД </summary>
    public DocRadController(IDbContextFactory<RadDbContext> dbContextFactory)
    {
        this._dbContextFactory = dbContextFactory;

        this._autoMapperConfiguration = new MapperConfiguration(
            c => {
                c.CreateProjection<DocRad, DocRadListDto>();

                c.CreateProjection<DocRad, DocRadItemDto>();
                c.CreateProjection<DocRadRow, DocRadItemRowDto>();

                c.CreateMap<DocRadItemDto, DocRad>();
                c.CreateMap<DocRadItemRowDto, DocRadRow>();
            });

    }

    /// <summary> Получить список всех документов РАД </summary>
    [HttpGet("List")]
    public async Task<IActionResult> List(UserContext userContext, DxDataSourceLoadOptions loadOptions)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        var source = dbContext.DocRads
                .AsNoTracking()
                .ProjectTo<DocRadListDto>(this._autoMapperConfiguration);
        var data = await DataSourceLoader.LoadAsync(source, loadOptions);

        if (data.data is List<DocRadListDto> rawRad)
        {
            data.data = await this.ListUpdateDto(rawRad);
        }
        return Json(data);
    }

    private async Task<List<DocRadListDto>> ListUpdateDto(List<DocRadListDto> docRadList)
    {
        await Task.Yield();

        foreach (var docRad in docRadList)
        {
            docRad.Actions = new[] {
                    new ObjectAction() { Operation = "edit" } 
            };
        }

        return docRadList;
    }


    public class DocRadListDto 
    {
        /// <summary> ИД </summary>
        public long Id { get; set; }

        /// <summary> Дата документа </summary>
        public string DocNum { get; set; } = "";

        /// <summary> Дата документа </summary>
        public DateTime DocDt { get; set; }

        /// <summary> Статус документа </summary>
        public EnumStatuses Status { get; set; }

        /// <summary> Имя статуса документа </summary>
        public string StatusName { get; set; } = "<Не определено>";

        /// <summary> Коммент </summary>
        public string Descr { get; set; } = "";

        /// <summary> ИД пользователя </summary>
        public long UserSid { get; set; }

        /// <summary> Имя пользователя </summary>
        public string UserName { get; set; } = "";

        /// <summary> Допустимые действия для пользователя для объекта </summary>
        public ObjectAction[] Actions { get; set; } = new ObjectAction[0];
    }


    /// <summary> Получить полный документ </summary>
    [HttpGet("Entity")]
    public async Task<IActionResult> Get(long id, bool withMeta = false)
    {
        using var dbContext = await this._dbContextFactory.CreateDbContextAsync();
        var rad = await dbContext.DocRads
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.DocRows)
                .ProjectTo<DocRadItemDto>(this._autoMapperConfiguration)
                .FirstOrDefaultAsync();

        if (!withMeta)
            return Json(rad);

        return Json(DataWithMetaHelper.ReturnWithMeta(rad, d => d.DocRows));
    }

    public class DocRadItemDto
    {
        /// <summary> ИД </summary>
        public long Id { get; set; }

        /// <summary> Дата документа </summary>
        [Description("Номер документа")]
        public string DocNum { get; set; } = "";

        /// <summary> Дата документа </summary>
        [Description("Дата документа")]
        public DateTime DocDt { get; set; }

        /// <summary> Статус документа </summary>
        [Description("Статус документа")]
        public EnumStatuses Status { get; set; }

        /// <summary> Номер правового акта </summary>
        [Description("Номер правового акта")]
        public string LawNumber { get; set; } = "";

        /// <summary> Дата утверждения правового акта </summary>
        [Description("Дата утверждения правового акта")]
        public DateTime LawDate { get; set; }

        /// <summary> ФИО руководителя </summary>
        [Description("ФИО руководителя")]
        public string BossFio { get; set; } = "";

        /// <summary> Должность руководителя </summary>
        [Description("Должность руководителя")]
        public string BossStat { get; set; } = "";

        /// <summary> ФИО исполнителя </summary>
        [Description("ФИО исполнителя")]
        public string ExecuterFio { get; set; } = "";

        /// <summary> Должность исполнителя </summary>
        [Description("Должность исполнителя")]
        public string ExecuterStat { get; set; } = "";

        /// <summary> Телефон исполнителя </summary>
        [Description("Телефон исполнителя")]
        public string ExecuterPhone { get; set; } = "";

        /// <summary> Коммент </summary>
        [Description("Примечание")]
        public string Descr { get; set; } = "";

        /// <summary> ИД пользователя </summary>
        public long UserSid { get; set; }

        /// <summary> "Поколение" записи </summary>
        public long Generation { get; set; }

        /// <summary> Ссылки на строки </summary>
        public ICollection<DocRadItemRowDto> DocRows { get; set; } = null!;
    }

    public class DocRadItemRowDto
    {
        /// <summary> ИД </summary>
        public long Id { get; set; }

        /// <summary> Код доходов </summary>
        [Description("Код КБК")]
        public string KbkCode { get; set; } = "";

        /// <summary> Дата ввода в действие КБК </summary>
        [Description("Дата ввода в действие КБК")]
        public DateTime? OndateKbk { get; set; }

        /// <summary> Дата закрытия КБК </summary>
        [Description("Дата закрытия КБК")]
        public DateTime? TodateKbk { get; set; }

        /// <summary> Наименование АДБ </summary>
        [Description("Наименование АДБ")]
        public string AdbName { get; set; } = "";

        /// <summary> ИНН АДБ </summary>
        [Description("ИНН АДБ")]
        public string AdbInn { get; set; } = "";

        /// <summary> КПП АДБ </summary>
        [Description("КПП АДБ")]
        public string AdbKpp { get; set; } = "";

        /// <summary> Наименование правового акта </summary>
        [Description("Наименование правового акта")]
        public string LawLegalName { get; set; } = "";

        /// <summary> Номер правового акта </summary>
        [Description("Номер правового акта")]
        public string LawNumber { get; set; } = "";

        /// <summary> Дата правового акта </summary>
        [Description("Дата правового акта")]
        public DateTime? LawDate { get; set; }
    }
}
