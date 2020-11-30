using GameAspApp.Models.DTO;

namespace GameAspApp.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с данными о жанрах.
    /// </summary>
    public interface IGenreService : ICrudService<GenreDto>
    {
    }
}
