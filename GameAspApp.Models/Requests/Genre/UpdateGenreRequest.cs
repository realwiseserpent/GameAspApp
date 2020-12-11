using System.ComponentModel.DataAnnotations;

namespace GameAspApp.Models.Requests.Genre
{
    /// <summary>
    /// Запрос на изменение жанра.
    /// </summary>
    public class UpdateGenreRequest : CreateGenreRequest
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
