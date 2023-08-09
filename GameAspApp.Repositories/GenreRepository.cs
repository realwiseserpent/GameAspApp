using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using GameAspApp.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

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

        /// <inheritdoc cref="IGenreRepository.GetAsync(string, CancellationToken)"/>
        public async Task<GenreDto> GetAsync(string name, CancellationToken token = default)
        {
            var entity = await DefaultIncludeProperties(_dbSet)
                              .AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Name.ToUpper() == name.ToUpper());

            var dto = _mapper.Map<GenreDto>(entity);

            return dto;
        }

        /// <inheritdoc cref="BaseRepository{TDto, TModel}.CreateAsync(TDto)"/>
        public new async Task<GenreDto> CreateAsync(GenreDto dto)
        {
            var genre = await GetAsync(dto.Name);
            if (genre != null)
                return genre;
            return await base.CreateAsync(dto);
        }

        /// <inheritdoc cref="BaseRepository{TDto, TModel}.DefaultIncludeProperties(DbSet{TModel})"/>
        protected override IQueryable<Genre> DefaultIncludeProperties(DbSet<Genre> dbSet)
        {
            return _dbSet;
        }
    }
}
