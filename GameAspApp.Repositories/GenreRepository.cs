using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using GameAspApp.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GameAspApp.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями "Жанр".
    /// </summary>
    public class GenreRepository<TContext> : BaseRepository<GenreDto, Genre, TContext>, IGenreRepository<TContext>
        where TContext : DbContext
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GenreRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public GenreRepository(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <inheritdoc/>
        protected override IQueryable<Genre> DefaultIncludeProperties(DbSet<Genre> dbSet)
        {
            return _dbSet;
        }
    }
}
