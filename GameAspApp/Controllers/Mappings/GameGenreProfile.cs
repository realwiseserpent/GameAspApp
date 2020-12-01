using GameAspApp.Models.DTO;
using GameAspApp.Models.Requests.GameGenre;
using GameAspApp.Models.Responses.GameGenre;
using AutoMapper;

namespace GameAspApp.Controllers.Mappings
{
    /// <summary>
    /// Маппинг для запросов и ответов контроллера сущности "Жанр игр".
    /// </summary>
    public class GameGenreProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GameGenreProfile"/>.
        /// </summary>
        public GameGenreProfile()
        {
            CreateMap<CreateGameGenreRequest, GameGenreDto>();
            CreateMap<UpdateGameGenreRequest, GameGenreDto>();
            CreateMap<GameGenreDto, GameGenreResponse>();
        }
    }
}
