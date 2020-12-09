using GameAspApp.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameAspApp.DAL.Fluent
{
    /// <summary>
    /// Конфигурация миграций для <see cref="GameGenre"/>.
    /// </summary>
    public class GameGenreConfig : IEntityTypeConfiguration<GameGenre>
    {
        /// <summary>
        /// Конфигурирование сущности <see cref="GameGenre"/>.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<GameGenre> builder)
        {
            builder.BaseEntityWithLinksConfig<GameGenre, Game, Genre>(
               e => e.GameGenres, e => e.GameGenres);

            //builder.Property(x => x.)
            //    .IsRequired();

            builder.ToTable("GameGenres");
        }
    }
}

