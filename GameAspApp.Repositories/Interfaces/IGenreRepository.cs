﻿using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using GameAspApp.Repositories.Interfaces.CRUD;
using System.Threading.Tasks;
using System.Threading;

namespace GameAspApp.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностями "Жанр".
    /// </summary>
    public interface IGenreRepository : ICrudRepository<GenreDto, Genre>
    {
        /// <summary>
        /// Получение сущности по названию.
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="token"></param>
        /// <returns>Экземпляр сущности.</returns>
        Task<GenreDto> GetAsync(string name, CancellationToken token = default);
    }
}
