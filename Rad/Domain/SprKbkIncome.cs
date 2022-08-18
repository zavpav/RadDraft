namespace Rad.Domain;

/// <summary> КБК доходов </summary>
public class SprKbkIncome
{
    /// <summary> ИД </summary>
    public long Id { get; set; }

    /// <summary> Код КБК </summary>
    public string Code { get; set; } = "";

    /// <summary> "Название" КБК </summary>
    public string Name { get; set; } = "";

    /// <summary> Дата начала действия (null если была изначальная) </summary>
    public DateTime? OnDate { get; set; }

    /// <summary> Дата окончания действия (null если ещё активна) </summary>
    public DateTime? ToDate { get; set; }
}
