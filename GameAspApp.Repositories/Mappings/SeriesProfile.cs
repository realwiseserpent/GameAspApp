using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using AutoMapper;

namespace GameAspApp.Services.Mappings
{
    /// <summary>
    /// Профиль маппинга (серия).
    /// </summary>
    class SeriesProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="SeriesProfile"/>.
        /// </summary>
        public SeriesProfile()
        {
            CreateMap<Series, SeriesDto>().ReverseMap();
        }
    }
}
