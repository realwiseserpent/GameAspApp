using GameAspApp.Database.Domain;
using System.ComponentModel.DataAnnotations;
using System;

namespace GameAspApp.Models.DTO
{
    /// <summary>
    /// DTO для <see cref="Game"/>.
    /// </summary>
    public class GameDto
    {
        /// <summary>
        /// Дата релиза игры.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Разработчик игры.
        /// </summary>
        public string Developer { get; set; }

        /// <summary>
        /// Издатель игры.
        /// </summary>
        [Required]
        public string Publisher { get; set; }

        /// <summary>
        /// Жанр игры.
        /// </summary>
        [Required]
        public string Genre { get; set; }

        /// <summary>
        /// Название игры.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Оценка на Metacritic.
        /// </summary>
        public float Metascore { get; set; }
    }
}
