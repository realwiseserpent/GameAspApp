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
            CreateMap <long, GameGenreDto>()
                .ForMember(x => x.GenreId, y => y.MapFrom(src => src));
            CreateMap<CreateGameRequest, GameDto>()
                .ForMember(x => x.SeriesId, y => y.MapFrom(src => src.Series.Id))
                .ForMember(x => x.GameGenres, y => y.MapFrom(src => src.Genres));
            CreateMap<UpdateGameRequest, GameDto>();
            CreateMap<GameDto, GameResponse>()
                .ForMember(x => x.SeriesName, y => y.MapFrom(src => src.Series.Name))
                .ForMember(x => x.SeriesDesc, y => y.MapFrom(src => src.Series.Description));

        }
    }
}
