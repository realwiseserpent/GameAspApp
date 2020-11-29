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
        public Game Game { get; set; }

        /// <summary>
        /// Жанр.
        /// </summary>
        public Genre Genre { get; set; }
    }
}
