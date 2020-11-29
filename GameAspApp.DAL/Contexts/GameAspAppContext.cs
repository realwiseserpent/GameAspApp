﻿using GameAspApp.DAL.Domain;
using Microsoft.EntityFrameworkCore;

namespace GameAspApp.DAL.Contexts
{
    /// <summary>
    /// Контекст для работы с данными БД "Магазины одежды".
    /// </summary>
    public class GameAspAppContext : DbContext
    {
        /// <summary>
        /// Магазины.
        /// </summary>
        public DbSet<Game> Games { get; set; }

        /// <summary>
        /// Поставщики.
        /// </summary>
        public DbSet<GameGenre> GameGenres { get; set; }

        /// <summary>
        /// Одежда.
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Наличие в магазинах.
        /// </summary>
        public DbSet<Series> Series { get; set; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="GameAspAppContext"/>.
        /// </summary>
        public GameAspAppContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}