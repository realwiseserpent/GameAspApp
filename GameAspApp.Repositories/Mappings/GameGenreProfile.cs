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
                .ForMember(x => x.Entity2Id, y => y.MapFrom(scr => scr.GenreId))
                .ForMember(x => x.Entity1, y => y.MapFrom(scr => scr.Game))
                .ForMember(x => x.Entity2, y => y.MapFrom(scr => scr.Genre));
            CreateMap<GameGenre, GameGenreDto>()
                .ForMember(x => x.GameId, y => y.MapFrom(scr => scr.Entity1Id))
                .ForMember(x => x.GenreId, y => y.MapFrom(scr => scr.Entity2Id))
                .ForMember(x => x.Game, y => y.MapFrom(scr => scr.Entity1))
                .ForMember(x => x.Genre, y => y.MapFrom(scr => scr.Entity2));
        }
    }
}
