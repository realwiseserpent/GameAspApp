using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GameAspApp.DAL.Domain
{
    /// <summary>
    /// Класс объекта Игра.
    /// </summary>
    public class Game : BaseEntity
    {
        /// <summary>
        /// Дата релиза игры.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Разработчик игры.
        /// </summary>
        [StringLength(100)]
        public string Developer { get; set; }

        /// <summary>
        /// Издатель игры.
        /// </summary>
        [StringLength(100)]
        public string Publisher { get; set; }

        /// <summary>
        /// Название игры.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Оценка на Metacritic.
        /// </summary>
        public float Metascore { get; set; }

        /// <summary>
        /// Часть серии игр.
        /// </summary>
        public Series Series { get; set; }

        /// <summary>
        /// Идентификатор серии.
        /// </summary>
        public long SeriesId { get; set; }

        /// <summary>
        /// Список жанров, к которым относится игра.
        /// </summary>
        public ICollection<GameGenre> GameGenres { get; set; }

    }
}
