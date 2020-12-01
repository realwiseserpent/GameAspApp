using GameAspApp.Models.DTO;
using GameAspApp.Models.Requests.Series;
using GameAspApp.Models.Responses.Series;
using AutoMapper;

namespace GameAspApp.Controllers.Mappings
{
    /// <summary>
    /// Маппинг для запросов и ответов контроллера сущности "Серия".
    /// </summary>
    public class SeriesProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="SeriesProfile"/>.
        /// </summary>
        public SeriesProfile()
        {
            CreateMap<CreateSeriesRequest, SeriesDto>();
            CreateMap<UpdateSeriesRequest, SeriesDto>();
            CreateMap<SeriesDto, SeriesResponse>();
        }
    }
}
