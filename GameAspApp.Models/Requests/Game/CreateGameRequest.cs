using System.ComponentModel.DataAnnotations;
using GameAspApp.Models.DTO;
using System;

namespace GameAspApp.Models.Requests.Game
{
    /// <summary>
    /// Запрос на создание игры.
    /// </summary>
    public class CreateGameRequest
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
        /// Серия игры.
        /// </summary>
        public SeriesDto Series { get; set; }
    }
}
