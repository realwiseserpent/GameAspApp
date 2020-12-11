using GameAspApp.Models.DTO;

namespace GameAspApp.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с данными об играх.
    /// </summary>
    public interface IGameService : ICrudService<GameDto>
    {
    }
}
