namespace Rad.Domain
{
    /// <summary> Действие, которое можно совершить над объектом </summary>
    public class ObjectAction
    {
        /// <summary> Имя операции </summary>
        public string Operation { get; set; }

        /// <summary> Куда пересылать </summary>
        public string? endpoint { get; set; }

        /// <summary> Каким рисунком отображать </summary>
        public string? glyph { get; set; }

        /// <summary> Какую подсказку писать </summary>
        public string? tooltip { get; set; }
    }
}
