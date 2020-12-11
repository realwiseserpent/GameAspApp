using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using GameAspApp.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GameAspApp.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями "Серия".
    /// </summary>
    public class SeriesRepository<TContext> : BaseRepository<SeriesDto, Series, TContext>, ISeriesRepository<TContext>
        where TContext : DbContext
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="SeriesRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public SeriesRepository(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <inheritdoc/>
        protected override IQueryable<Series> DefaultIncludeProperties(DbSet<Series> dbSet)
        {
            return _dbSet;
        }
    }
}
