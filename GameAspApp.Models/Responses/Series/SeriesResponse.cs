namespace GameAspApp.Models.Responses.Series
{
    /// <summary>
    /// Ответ на запросы для серии.
    /// </summary>
    public class SeriesResponse
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название серии.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание серии.
        /// </summary>
        public string Description { get; set; }
    }
}
