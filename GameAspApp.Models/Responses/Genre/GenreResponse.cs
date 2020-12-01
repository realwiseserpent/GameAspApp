namespace GameAspApp.Models.Responses.Genre
{
    /// <summary>
    /// Ответ на запросы для жанра.
    /// </summary>
    public class GenreResponse
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название игры.
        /// </summary>
        public string Name { get; set; }
    }
}
