using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using AutoMapper;

namespace GameAspApp.Services.Mappings
{
    /// <summary>
    /// Профиль маппинга (жанр).
    /// </summary>
    class GenreProfile : Profile
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="GenreProfile"/>.
        /// </summary>
        public GenreProfile()
        {
            CreateMap<Genre, GenreDto>();
        }
    }
}
