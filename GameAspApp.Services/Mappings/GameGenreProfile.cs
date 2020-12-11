using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using AutoMapper;

namespace GameAspApp.Services.Mappings
{
    /// <summary>
    /// Профиль маппинга (жанр игр).
    /// </summary>
    class GameGenreProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GameGenreProfile"/>.
        /// </summary>
        public GameGenreProfile()
        {
            CreateMap<GameGenre, GameGenreDto>();
        }
    }
}
