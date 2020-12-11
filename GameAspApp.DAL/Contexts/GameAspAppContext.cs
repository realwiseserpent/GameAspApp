using GameAspApp.DAL.Domain;
using GameAspApp.DAL.Fluent;
using Microsoft.EntityFrameworkCore;

namespace GameAspApp.DAL.Contexts
{
    /// <summary>
    /// Контекст для работы с данными БД "Игры".
    /// </summary>
    public class GameAspAppContext : DbContext
    {
        /// <summary>
        /// Игры.
        /// </summary>
        public DbSet<Game> Games { get; set; }

        /// <summary>
        /// Жанры игр.
        /// </summary>
        public DbSet<GameGenre> GameGenres { get; set; }

        /// <summary>
        /// Жанры.
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Серии игр.
        /// </summary>
        public DbSet<Series> Series { get; set; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="GameAspAppContext"/>.
        /// </summary>
        /// <param name="options">Опции для конфигурации контекста.</param>
        public GameAspAppContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Правила создания сущностей.
        /// </summary>
        /// <param name="builder">Билдер моделей.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GameGenreConfig());
        }
    }
}
