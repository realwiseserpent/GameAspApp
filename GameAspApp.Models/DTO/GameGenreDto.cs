using GameAspApp.DAL.Domain;

namespace GameAspApp.Models.DTO
{
    /// <summary>
    /// DTO для <see cref="GameGenre"/>.
    /// </summary>
    class GameGenreDto : BaseDto
    {
        /// <summary>
        /// Игра.
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Жанр.
        /// </summary>
        public Genre Genre { get; set; }
    }
}
