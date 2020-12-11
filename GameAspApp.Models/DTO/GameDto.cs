using GameAspApp.DAL.Domain;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace GameAspApp.Models.DTO
{
    /// <summary>
    /// DTO для <see cref="Game"/>.
    /// </summary>
    public class GameDto : BaseDto
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
        /// Идентификатор серии.
        /// </summary>
        public long SeriesId { get; set; }

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
        /// Жанр игры.
        /// </summary>
        public SeriesDto Series { get; set; }

        /// <summary>
        /// Список жанров, к которым относится игра.
        /// </summary>
        public ICollection<GameGenreDto> GameGenres { get; set; }
    }
}
