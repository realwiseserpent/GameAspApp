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
    /// Репозиторий для работы с сущностями "Игра".
    /// </summary>
    public class GameRepository<TContext> : BaseRepository<GameDto, Game, TContext>, IGameRepository<TContext>
        where TContext : DbContext
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GameRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public GameRepository(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <inheritdoc cref="IGameRepository.GetAsync(string, CancellationToken)"/>
        public async Task<GameDto> GetAsync(string name, CancellationToken token = default)
        {
            var entity = await DefaultIncludeProperties(_dbSet)
                              .AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Name.ToUpper() == name.ToUpper());

            var dto = _mapper.Map<GameDto>(entity);

            return dto;
        }

        /// <inheritdoc cref="BaseRepository{TDto, TModel}.DefaultIncludeProperties(DbSet{TModel})"/>
        protected override IQueryable<Game> DefaultIncludeProperties(DbSet<Game> dbSet)
        {
            return _dbSet.Include(x => x.Series).Include(x=>x.GameGenres).ThenInclude(x=>x.Entity2);
        }
    }
}
