using GameAspApp.Models.DTO;
using GameAspApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace GameAspApp.Services.Services
{
    /// <summary>
    /// Сервис для работы с данными о жанрах игр.
    /// </summary>
    public class GameGenreService : IGameGenreService
    {
        /// <summary>
        /// Unit of Work для работы с репозиториями.
        /// </summary>
        private readonly IUnitOfWork _uow;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GameGenreService"/>.
        /// </summary>
        /// <param name="uow">Unit of Work.</param>
        public GameGenreService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        ///<inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<GameGenreDto> CreateAsync(GameGenreDto dto)
        {
            using var scope = await _uow.gameGenreRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var gameGenre = await _uow.gameGenreRepository.CreateAsync(dto);
                scope.Commit();
                return gameGenre;
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
            using var scope = await _uow.gameGenreRepository.Context.Database.BeginTransactionAsync();
            try
            {
                await _uow.gameGenreRepository.DeleteAsync(ids);
                scope.Commit();
            }
            catch (Exception ex)
            {
                scope.Rollback();
                throw ex;
            }
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<GameGenreDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _uow.gameGenreRepository.GetAsync(id, token);
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<GameGenreDto>> GetAsync(CancellationToken token = default)
        {
            return await _uow.gameGenreRepository.GetAsync(token);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<GameGenreDto> UpdateAsync(GameGenreDto dto)
        {
            using var scope = await _uow.gameGenreRepository.Context.Database.BeginTransactionAsync();
            try
            {
                var gameGenre = await _uow.gameGenreRepository.UpdateAsync(dto);
                scope.Commit();
                return gameGenre;
            }
            catch (Exception ex)
            {
                scope.Rollback();
                throw ex;
            }
        }
    }
}
