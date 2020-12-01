using GameAspApp.DAL.Contexts;
using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using GameAspApp.Repositories.Interfaces;
using AutoMapper;

namespace GameAspApp.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сущностями "Жанры игр".
    /// </summary>
    public class GameGenreRepository : BaseRepository<GameGenreDto, GameGenre>, IGameGenreRepository
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GameGenreRepository"/>.
        /// </summary>
        /// <param name="context">Контекст данных.</param>
        /// <param name="mapper">Маппер.</param>
        public GameGenreRepository(GameAspAppContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
