using System.ComponentModel;

namespace Rad.Domain;

/// <summary> Статусы документов </summary>
public enum EnumStatuses
{
    /// <summary> Не понятно. Не определен </summary>
    [Description("Не определен")]
    NotDefine = 0,
    /// <summary> Черновик </summary>
    [Description("Черновик")]
    Draft = 1,
    /// <summary> Утвержден </summary>
    [Description("Утвержден")]
    Approved,
    /// <summary> Новый </summary>
    [Description("Новый")]
    New,
    /// <summary> Выгружен </summary>
    [Description("Выгружен")]
    Exported,
    /// <summary> Принят в ФК </summary>
    [Description("Принят в ФК")]
    InFk,
    /// <summary> Не принят в ФК </summary>
    [Description("Не принят в ФК")]
    NotInFk,
    /// <summary> Аннулирован </summary>
    [Description("Аннулирован")]
    Annul,
    /// <summary> Отменен </summary>
    [Description("Отменен")]
    Canceled,
    /// <summary> Загружен </summary>
    [Description("Загружен")]
    Loaded,
    /// <summary> Не проведен (N в  корректировках Ф) </summary>
    [Description("Не проведен")]
    NegativeSumm,
    /// <summary> Не проведен (P в  корректировках Ф) </summary>
    [Description("Не проведен")]
    PositiveSumm,
    /// <summary> Подписана </summary>
    Signed,
    /// <summary> Принят </summary>
    [Description("Принят")]
    Adopted,
    /// <summary> Отклонен </summary>
    [Description("Отклонен")]
    Discard,
    /// <summary> Сформирована корректировка </summary>
    [Description("Сформирована корректировка")]
    FormedCorrect,
    /// <summary> Сформировано РР </summary>
    [Description("Сформировано РР")]
    RrCreated,
    /// <summary> Обработан </summary>
    [Description("Обработан")]
    Processed,
    /// <summary> Отправлен </summary>
    [Description("Отправлен")]
    Sended,
    /// <summary> На рассмотрении </summary>
    [Description("На рассмотрении")]
    Review,
    /// <summary> Подготовлен </summary>
    [Description("Подготовлен")]
    Prepared,

    /// <summary> На доработке </summary>
    [Description("На доработке")]
    Fixing,
    /// <summary> Доработан </summary>
    [Description("Доработан")]
    Fix,

    // СД костыли
    /// <summary> Внутренний </summary>
    [Description("Внутренний")]
    Internal,

    // АСУД (УОПДиТАО)
    Review2,
    Adopted2,
    Discard2,

    // АСУД (УКСНЭР)
    ReviewUksner,
    AdoptedUksner,
    DiscardUksner,
}
