using System.ComponentModel.DataAnnotations;
using GameAspApp.Models.DTO;

namespace GameAspApp.Models.Requests.GameGenre
{
    /// <summary>
    /// Запрос на создание жанра игры.
    /// </summary>
    public class CreateGameGenreRequest
    {
        /// <summary>
        /// Игра.
        /// </summary>
        [Required]
        public GameDto Game { get; set; }

        /// <summary>
        /// Жанр.
        /// </summary>
        [Required]
        public GenreDto Genre { get; set; }
    }
}
