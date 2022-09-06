namespace Rad.Controllers.Grbs
{
    public class DefaultDocDistributionItemDto
    {
        /// <summary> ИД </summary>
        public long Id { get; set; }

        /// <summary> Номер документа </summary>
        public string DocNum { get; set; }

        /// <summary> Дата подписи документа исполнителем </summary>
        public DateTime? ApproveDt { get; set; }

        /// <summary> Дата создания документа </summary>
        public DateTime CreateDt { get; set; }

        /// <summary> Статус документа </summary>
        public string DocStatus { get; set; }

        /// <summary> Коммент </summary>
        public string Descr { get; set; }

        /// <summary> Пользователь, создавший документ </summary>
        public long UserSid { get; set; }

        /// <summary> Распределяемый документом код  </summary>
        public string TopFullSprKey { get; set; }

        /// <summary> Является "первоначальным распределением" </summary>
        public bool IsFirstDistribution { get; set; }
    }
}
