using GameAspApp.Models.DTO;

namespace GameAspApp.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с данными о жанрах игр.
    /// </summary>
    public interface IGameGenreService : ICrudService<GameGenreDto>
    {
    }
}
