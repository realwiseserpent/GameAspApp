using GameAspApp.Models.DTO;
using System.Collections.Generic;

namespace GameAspApp.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с данными об играх.
    /// </summary>
    public interface IGameService
    {
        IEnumerable<GameDto> GetAsync();
    }
}
