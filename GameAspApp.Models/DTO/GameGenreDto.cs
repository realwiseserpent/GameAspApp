using System.ComponentModel.DataAnnotations;
using GameAspApp.DAL.Domain;

namespace GameAspApp.Models.DTO
{
    /// <summary>
    /// DTO для <see cref="GameGenre"/>.
    /// </summary>
    public class GameGenreDto : BaseDto
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
