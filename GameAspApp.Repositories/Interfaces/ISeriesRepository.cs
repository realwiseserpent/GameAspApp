﻿using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using GameAspApp.Repositories.Interfaces.CRUD;
using Microsoft.EntityFrameworkCore;

namespace GameAspApp.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностями "Серия".
    /// </summary>
    public interface ISeriesRepository<TContext> : 
        ICrudRepository<SeriesDto, Series, TContext>
    {
    }
}
