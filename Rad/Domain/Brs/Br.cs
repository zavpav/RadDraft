﻿namespace Rad.Domain.Brs;

public class Br
{
    /// <summary> ИД </summary>
    public long? Id { get; set; }

    /// <summary> Тип бюджетной росписи </summary>
    public EnumBrType BrType { get; set; }

    /// <summary> Организация </summary>
    public long OrgSid { get; set; }

    /// <summary> Год </summary>
    public int Year { get; set; }

    /// <summary> Строки БР </summary>
    public ICollection<BrStructRow> Rows { get; set; } = null!;
}
