namespace Rad.Domain;

/// <summary> Строка документа РАД </summary>
public class DocRadRow
{
    /// <summary> ИД </summary>
    public long Id { get; set; }

    /// <summary> Ссылка на РАД </summary>
    public long RadId { get; set; }

    /// <summary> Код доходов </summary>
    public string KbkCode { get; set; } = "";

    /// <summary> Дата ввода в действие КБК </summary>
    public DateTime? OndateKbk { get; set; }

    /// <summary> Дата закрытия КБК </summary>
    public DateTime? TodateKbk { get; set; }

    /// <summary> Наименование АДБ </summary>
    public string AdbName { get; set; } = "";

    /// <summary> ИНН АДБ </summary>
    public string AdbInn { get; set; } = "";

    /// <summary> КПП АДБ </summary>
    public string AdbKpp { get; set; } = "";

    /// <summary> Наименование правового акта </summary>
    public string LawLegalName { get; set; } = "";

    /// <summary> Номер правового акта </summary>
    public string LawNumber { get; set; } = "";

    /// <summary> Дата правового акта </summary>
    public DateTime? LawDate { get; set; }
}
