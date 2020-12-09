﻿using System.Threading;
using System.Threading.Tasks;

namespace GameAspApp.Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс для изменения сущности.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TModel">Domain model.</typeparam>
    public interface IUpdatable<TDto, TModel>
    {
        /// <summary>
        /// Изменение сущности.
        /// </summary>
        /// <param name="dto">DTO.</param>
        /// <param name="token">Экземпляр <see cref="CancellationToken"/>.</param>
        /// <returns>Обновленная сущность.</returns>
        Task<TDto> UpdateAsync(TDto dto, CancellationToken token = default);
    }
}