using System.ComponentModel.DataAnnotations;
using GameAspApp.DAL.Domain;

namespace GameAspApp.Models.DTO
{
    /// <summary>
    /// DTO для <see cref="GameGenre"/>.
    /// </summary>
    public class GameGenreDto
    {
        /// <summary>
        /// Id игры.
        /// </summary>
        [Required]
        public long GameId { get; set; }

        /// <summary>
        /// Id жанра.
        /// </summary>
        [Required]
        public long GenreId { get; set; }

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
