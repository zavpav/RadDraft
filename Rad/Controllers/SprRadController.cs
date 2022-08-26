using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rad.Db;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
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

        return Json(this.ReturnWithMeta(rad));
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

    public Task<DataWithMeta<T>> ReturnWithMeta<T>(T? entity)
        where T : class
    {
        var res = new DataWithMeta<T>(entity);
        
        foreach (var pi in typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
        {
            var meta = new MetaInformation(pi.Name);

            if (pi.PropertyType == typeof(DateTime) || pi.PropertyType == typeof(DateTime?))
                meta.Type = "date";
            else if (pi.PropertyType == typeof(string))
                meta.Type = "string";
            else if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(long) || pi.PropertyType == typeof(int?) || pi.PropertyType == typeof(long?))
                meta.Type = "int";
            else if (pi.PropertyType == typeof(double) || pi.PropertyType == typeof(double?))
                meta.Type = "double";


            var nullabilityContext = new NullabilityInfoContext();
            var nullabilityInfo = nullabilityContext.Create(pi);
            if (nullabilityInfo.WriteState == NullabilityState.NotNull)
            {
                meta.IsRequire = true;
            }

            foreach (var att in pi.GetCustomAttributes(true))
            {
                if (att is DescriptionAttribute desc)
                    meta.Caption = desc.Description;
                else if (att is RequiredAttribute req)
                    meta.IsRequire = true;
                else if (att is MaxLengthAttribute ml)
                    meta.MaxLen = ml.Length;
            }
            res.Meta.Add(meta);
        }

        return Task.FromResult(res);
    }

    public class MetaInformation
    { 
        public MetaInformation(string name)
        {
            this.Name = name;
            this.Caption = name;
        }

        public string Name { get; }

        public string Caption { get; set; }

        public bool IsRequire { get; set; }

        public string Type { get; set; } = "string";

        public int MaxLen { get; set; }
    }

    public class DataWithMeta<T>
    {
        public DataWithMeta(T? entity)
        {
            this.Entity = entity;
            this.Meta = new List<MetaInformation>();
        }
        public T? Entity;
        public List<MetaInformation> Meta;
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
