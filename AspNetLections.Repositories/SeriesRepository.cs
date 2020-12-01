using GameAspApp.DAL.Contexts;
using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using GameAspApp.Repositories.Interfaces;
using AutoMapper;

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
    }
}
