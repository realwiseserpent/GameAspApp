namespace GameAspApp.Models.Responses.Series
{
    /// <summary>
    /// Ответ на запросы для серии.
    /// </summary>
    class SeriesResponse
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название серии.
        /// </summary>
        public string Name { get; set; }
    }
}
