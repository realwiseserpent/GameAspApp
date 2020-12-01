using System.ComponentModel.DataAnnotations;

namespace GameAspApp.Models.Requests.GameGenre
{
    /// <summary>
    /// Запрос на изменение жанра игры.
    /// </summary>
    public class UpdateGameGenreRequest : CreateGameGenreRequest
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
