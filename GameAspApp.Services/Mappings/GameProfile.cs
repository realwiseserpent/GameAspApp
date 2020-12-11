using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using AutoMapper;

namespace GameAspApp.Services.Mappings
{
    /// <summary>
    /// Профиль маппинга (Игра).
    /// </summary>
    class GameProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GameProfile"/>.
        /// </summary>
        public GameProfile()
        {
            CreateMap<Game, GameDto>();
        }
    }
}
