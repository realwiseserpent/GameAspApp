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
            CreateMap<GameGenreDto, GenreDto>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.GenreId))
                .ForMember(x => x.Name, y => y.MapFrom(src => src.Genre.Name))
                .ForMember(x => x.Description, y => y.MapFrom(src => src.Genre.Description));
            CreateMap<GenreDto, GameGenreDto>()
                .ForMember(x => x.Genre, y => y.MapFrom(src => src))
                .ForMember(x => x.GenreId, y => y.MapFrom(src => src.Id));
        }
    }
}
