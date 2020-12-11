using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GameAspApp.DAL.Domain
{
    /// <summary>
    /// Класс объекта Жанр.
    /// </summary>
    public class Genre : BaseEntity
    {
        /// <summary>
        /// Название жанра.
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Описание жанра.
        /// </summary>
        [StringLength(2500)]
        public string Description { get; set; }

        /// <summary>
        /// Список жанров, к которым относится игра.
        /// </summary>
        public ICollection<GameGenre> GameGenres { get; set; }
    }
}
