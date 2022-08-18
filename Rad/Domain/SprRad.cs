namespace Rad.Domain;

/// <summary> Справочник РАД </summary>
public class SprRad
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

    /// <summary> Ссылка на КБК </summary>
    public long? SprKbkIncomeId { get; set; }

    /// <summary> Значение КБК (если надо) </summary>
    public SprKbkIncome? SprKbkIncome { get; set; }
}