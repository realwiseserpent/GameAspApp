using GameAspApp.Models.DTO;
using GameAspApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using GameAspApp.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameAspApp.Services.Services
{
    /// <summary>
    /// Сервис для работы с данными о сериях.
    /// </summary>
    public class SeriesService<TContext> : ISeriesService where TContext : DbContext
    {
        /// <summary>
        /// Unit of Work для работы с репозиториями.
        /// </summary>
        private readonly IUnitOfWork<TContext> _uow;

        /// <summary>
        /// Инициализирует экземпляр <see cref="SeriesService"/>.
        /// </summary>
        /// <param name="uow">Unit of Work.</param>
        public SeriesService(IUnitOfWork<TContext> uow)
        {
            _uow = uow;
        }

        ///<inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<SeriesDto> CreateAsync(SeriesDto dto)
        {
            using var scope = await _uow.DbContext.Database.BeginTransactionAsync();
            try
            {
                var series = await _uow.seriesRepository.CreateAsync(dto);
                scope.Commit();
                return series;
            }
            catch (Exception ex)
            {
                scope.Rollback();
                throw ex;
            }
        }

        /// <inheritdoc cref="IDeletable.DeleteAsync(long[])"/>
        public async Task DeleteAsync(params long[] ids)
        {
            using var scope = await _uow.DbContext.Database.BeginTransactionAsync();
            try
            {
                await _uow.seriesRepository.DeleteAsync(ids);
                scope.Commit();
            }
            catch (Exception ex)
            {
                scope.Rollback();
                throw ex;
            }
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<SeriesDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _uow.seriesRepository.GetAsync(id, token);
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<SeriesDto>> GetAsync(CancellationToken token = default)
        {
            return await _uow.seriesRepository.GetAsync(token);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<SeriesDto> UpdateAsync(SeriesDto dto)
        {
            using var scope = await _uow.DbContext.Database.BeginTransactionAsync();
            try
            {
                var series = await _uow.seriesRepository.UpdateAsync(dto);
                scope.Commit();
                return series;
            }
            catch (Exception ex)
            {
                scope.Rollback();
                throw ex;
            }
        }
    }
}
