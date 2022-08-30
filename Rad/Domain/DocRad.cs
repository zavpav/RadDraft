namespace Rad.Domain;

/// <summary> Строка документа РАД </summary>
public class DocRad
{
    /// <summary> ИД </summary>
    public long Id { get; set; }

    /// <summary> Дата документа </summary>
    public string DocNum { get; set; } = "";

    /// <summary> Дата документа </summary>
    public DateTime DocDt { get; set; }

    /// <summary> Статус документа </summary>
    public EnumStatuses Status { get; set; }

    /// <summary> Номер правового акта </summary>
    public string LawNumber { get; set; } = "";

    /// <summary> Дата утверждения правового акта </summary>
    public DateTime LawDate { get; set; }

    /// <summary> ФИО руководителя </summary>
    public string BossFio { get; set; } = "";

    /// <summary> Должность руководителя </summary>
    public string BossStat { get; set; } = "";

    /// <summary> ФИО исполнителя </summary>
    public string ExecuterFio { get; set; } = "";

    /// <summary> Должность исполнителя </summary>
    public string ExecuterStat { get; set; } = "";

    /// <summary> Телефон исполнителя </summary>
    public string ExecuterPhone { get; set; } = "";

    /// <summary> Коммент </summary>
    public string Descr { get; set; } = "";

    /// <summary> ИД пользователя </summary>
    public long UserSid { get; set; }

    /// <summary> "Поколение" записи </summary>
    public long Generation { get; set; }

    /// <summary> Ссылки на строки </summary>
    public ICollection<DocRadRow>? DocRows { get; set; } = null;
}
