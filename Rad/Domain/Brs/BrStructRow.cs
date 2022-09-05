namespace Rad.Domain.Brs;

/// <summary> Строка структуры БР </summary>
public class BrStructRow
{
    /// <summary> ИД структуры </summary>
    public long Id { get; set; }

    /// <summary> ИД росписи </summary>
    public long BrId { get; set; }

    /// <summary> ИД Родительской записи </summary>
    public long? ParentRowId { get; set; }

    /// <summary> Родительская строка </summary>
    public BrStructRow? ParentRow { get; set; }

    /// <summary> Дочерние записи </summary>
    public ICollection<BrStructRow>? ChildRows { get; set; }

    /// <summary> Полный код </summary>
    public string FullSprKey { get; set; } = string.Empty;
    
    /// <summary> ИД записи справочника </summary>
    public long SprId { get; set; }

    /// <summary> Дата начала действия элемента структуры </summary>
    public DateTime? OnDate { get; set; }

    /// <summary> Дата окончания действия элемента структуры </summary>
    public DateTime? ToDate { get; set; }

    /// <summary> Фактическое серверное время последнего изменения структуры </summary>
    public DateTime SysChangeDate { get; set; }
    
    /// <summary> Разная информация </summary>
    /// <remarks>
    /// Разные флаги?
    /// ПНО, Спецрасходы (АСУБС), Осужденные/ПДД (АСУД) и т.д.
    /// </remarks>
    public string? XmlInfo { get; set; }

    /// <summary> История изменения БР </summary>
    public ICollection<BrSumRow>? Sums { get; set; }
}
