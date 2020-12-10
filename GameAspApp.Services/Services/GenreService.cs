using GameAspApp.Models.DTO;
using GameAspApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace GameAspApp.Services.Services
{
    /// <summary>
    /// Сервис для работы с данными о жанрах.
    /// </summary>
    public class GenreService : IGenreService
    {
        /// <summary>
        /// Unit of Work для работы с репозиториями.
        /// </summary>
        private readonly IUnitOfWork _uow;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GenreService"/>.
        /// </summary>
        /// <param name="uow">Unit of Work.</param>
        public GenreService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        ///<inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<GenreDto> CreateAsync(GenreDto dto)
        {
            using var scope = await _uow.genreRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var genre = await _uow.genreRepository.CreateAsync(dto);
                scope.Commit();
                return genre;
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
            using var scope = await _uow.genreRepository.Context.Database.BeginTransactionAsync();
            try
            {
                await _uow.genreRepository.DeleteAsync(ids);
                scope.Commit();
            }
            catch (Exception ex)
            {
                scope.Rollback();
                throw ex;
            }
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<GenreDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _uow.genreRepository.GetAsync(id, token);
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<GenreDto>> GetAsync(CancellationToken token = default)
        {
            return await _uow.genreRepository.GetAsync(token);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<GenreDto> UpdateAsync(GenreDto dto)
        {
            using var scope = await _uow.genreRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var genre = await _uow.genreRepository.UpdateAsync(dto);
                scope.Commit();
                return genre;
            }
            catch (Exception ex)
            {
                scope.Rollback();
                throw ex;
            }
        }
    }
}
