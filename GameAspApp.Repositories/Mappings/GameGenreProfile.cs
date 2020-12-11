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
            CreateMap<GameGenre, GameGenreDto>().ReverseMap()
                .ForMember(x => x.Entity1Id, y => y.MapFrom(scr => scr.GameId))
                .ForMember(x => x.Entity2Id, y => y.MapFrom(scr => scr.GenreId));
        }
    }
}
