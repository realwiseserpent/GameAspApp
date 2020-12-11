using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using GameAspApp.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using GameAspApp.Repositories.Interfaces.CRUD;

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

        /// <inheritdoc cref="ICreatable{TDto, TModel}.CreateAsync(TDto)"/>
        public new async Task<GameDto> CreateAsync(GameDto dto)
        {
            Game entity = _mapper.Map<Game>(dto);
            foreach (GameGenre gg in entity.GameGenres)
            {
                gg.Entity1 = entity;
                gg.Entity1Id = entity.Id;
            }
            await _dbSet.AddAsync(entity);
            await _сontext.SaveChangesAsync();
            return await GetAsync(entity.Id);
        }

        /// <inheritdoc/>
        protected override IQueryable<Game> DefaultIncludeProperties(DbSet<Game> dbSet)
        {
            return _dbSet.Include(x => x.Series);
        }
    }
}
