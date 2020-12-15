using GameAspApp.DAL.Contexts;
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
    /// Репозиторий для работы с сущностями "Серия".
    /// </summary>
    public class SeriesRepository : BaseRepository<SeriesDto, Series>, ISeriesRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="SeriesRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public SeriesRepository(GameAspAppContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <inheritdoc cref="ISeriesRepository.GetAsync(string, CancellationToken)"/>
        public async Task<SeriesDto> GetAsync(string name, CancellationToken token = default)
        {
            var entity = await DefaultIncludeProperties(_dbSet)
                              .AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Name.ToUpper() == name.ToUpper());

            var dto = _mapper.Map<SeriesDto>(entity);

            return dto;
        }

        /// <inheritdoc cref="BaseRepository{TDto, TModel}.CreateAsync(TDto)"/>
        public new async Task<SeriesDto> CreateAsync(SeriesDto dto)
        {
            var series = await GetAsync(dto.Name);
            if (series != null)
                return series;
            return await base.CreateAsync(dto);
        }

        /// <inheritdoc cref="BaseRepository{TDto, TModel}.DefaultIncludeProperties(DbSet{TModel})"/>
        protected override IQueryable<Series> DefaultIncludeProperties(DbSet<Series> dbSet)
        {
            return _dbSet;
        }
    }
}
