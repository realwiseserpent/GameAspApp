using GameAspApp.DAL.Domain;
using System.ComponentModel.DataAnnotations;
using System;

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
        /// Жанр игры.
        /// </summary>
        public SeriesDto Series { get; set; }

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
    }
}
