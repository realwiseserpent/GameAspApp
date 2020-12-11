using System;
using GameAspApp.Models.DTO;

namespace GameAspApp.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с данными о сериях.
    /// </summary>
    public interface ISeriesService : ICrudService<SeriesDto>
    {
    }
}
