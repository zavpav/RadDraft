namespace Rad.Domain.Brs
{
    /// <summary> Строка с суммами БР </summary>
    public class BrSumRow
    {
        /// <summary> ИД структуры </summary>
        public long Id { get; set; }

        /// <summary> ИД росписи </summary>
        public long BrId { get; set; }

        /// <summary> БР </summary>
        public Br Br { get; set; } = null!;

        /// <summary> Строка структуры </summary>
        public long StructRowId { get; set; }

        /// <summary> Строка структуры </summary>
        public BrStructRow StructRow { get; set; } = null!;

        /// <summary> Дата утверждения суммы </summary>
        public DateTime? ApproveDate { get; set; }

        /// <summary> 
        /// Порядковый номер в истории (в структуре). 
        /// Может меняться при добавлении Истории в структуру.
        /// </summary>
        public int? OrderBy { get; set; }

        /// <summary> ИД документа </summary>
        public long DocumentId { get;set; }

        /// <summary> Прочая информация. Например список документов, которые участвовали в формировании этой строки </summary>
        public string? XmlInfo { get; set; }


        /// <summary> Сумма БА 1 </summary>
        public decimal SmBa1 { get; set; }

        /// <summary> Сумма БА 2 </summary>
        public decimal SmBa2 { get; set; }

        /// <summary> Сумма БА 3 </summary>
        public decimal SmBa3 { get; set; }

        /// <summary> Сумма ЛБО 1 </summary>
        public decimal SmLbo1 { get; set; }

        /// <summary> Сумма ЛБО 2 </summary>
        public decimal SmLbo2 { get; set; }

        /// <summary> Сумма ЛБО 3 </summary>
        public decimal SmLbo3 { get; set; }

        /// <summary> Сумма ПОФ </summary>
        public decimal SmPof { get; set; }

        /// <summary> Дата изменения записи </summary>
        public DateTime SysChangeDate { get; set; }

        /// <summary> Поколение записи </summary>
        public long Generation { get; set; }
    }
}
