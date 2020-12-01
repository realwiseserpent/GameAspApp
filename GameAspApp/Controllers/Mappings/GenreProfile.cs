using GameAspApp.Models.DTO;
using GameAspApp.Models.Requests.Genre;
using GameAspApp.Models.Responses.Genre;
using AutoMapper;

namespace GameAspApp.Controllers.Mappings
{
    /// <summary>
    /// Маппинг для запросов и ответов контроллера сущности "Жанр".
    /// </summary>
    public class GenreProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GenreProfile"/>.
        /// </summary>
        public GenreProfile()
        {
            CreateMap<CreateGenreRequest, GenreDto>();
            CreateMap<UpdateGenreRequest, GenreDto>();
            CreateMap<GenreDto, GenreResponse>();
        }
    }
}
