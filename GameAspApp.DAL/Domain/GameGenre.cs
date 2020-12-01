using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAspApp.DAL.Domain
{
    /// <summary>
    /// Промежуточный класс для описания всех жанров игры.
    /// </summary>
    public class GameGenre : BaseEntity
    {
        /// <summary>
        /// Игра.
        /// </summary>
        [Required]
        public Game Game { get; set; }

        /// <summary>
        /// Жанр.
        /// </summary>
        [Required]
        public Genre Genre { get; set; }
    }
}
