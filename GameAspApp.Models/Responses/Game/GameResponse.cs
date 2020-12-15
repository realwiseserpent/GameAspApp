using System;
using System.Collections.Generic;
using GameAspApp.Models.DTO;

namespace GameAspApp.Models.Responses.Game
{
    /// <summary>
    /// Ответ на запросы для игры.
    /// </summary>
    public class GameResponse
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public long Id { get; set; }

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
        public string Publisher { get; set; }

        /// <summary>
        /// Название игры.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Оценка на Metacritic.
        /// </summary>
        public float Metascore { get; set; }

        /// <summary>
        /// Название серии.
        /// </summary>
        public string SeriesName { get; set; }

        /// <summary>
        /// Описание серии.
        /// </summary>
        public string SeriesDesc { get; set; }

        /// <summary>
        /// Список жанров, к которым относится игра.
        /// </summary>
        public ICollection<GenreDto> Genres { get; set; }
    }
}
