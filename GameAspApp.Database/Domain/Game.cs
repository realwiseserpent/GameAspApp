using System;

namespace GameAspApp.Database.Domain
{
    /// <summary>
    /// Класс игры
    /// </summary>
    public class Game
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
        /// Жанр игры.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Название игры.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Оценка на Metacritic.
        /// </summary>
        public float Metascore { get; set; }
    }
}
