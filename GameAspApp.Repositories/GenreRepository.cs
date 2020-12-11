using GameAspApp.DAL.Contexts;
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
    public class GenreRepository : BaseRepository<GenreDto, Genre>, IGenreRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GenreRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public GenreRepository(GameAspAppContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <inheritdoc/>
        protected override IQueryable<Genre> DefaultIncludeProperties(DbSet<Genre> dbSet)
        {
            return _dbSet;
        }
    }
}
