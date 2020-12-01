using GameAspApp.Models.DTO;
using GameAspApp.Models.Requests.Game;
using GameAspApp.Models.Responses.Game;
using AutoMapper;

namespace GameAspApp.Controllers.Mappings
{
    /// <summary>
    /// Маппинг для запросов и ответов контроллера сущности "Игра".
    /// </summary>
    public class GameProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GameProfile"/>.
        /// </summary>
        public GameProfile()
        {
            CreateMap<CreateGameRequest, GameDto>();
            CreateMap<UpdateGameRequest, GameDto>();
            CreateMap<GameDto, GameResponse>();
        }
    }
}
