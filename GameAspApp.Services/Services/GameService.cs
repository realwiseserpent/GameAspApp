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
    /// Сервис для работы с данными об играх.
    /// </summary>
    public class GameService<TContext> : IGameService where TContext : DbContext
    {
        /// <summary>
        /// Unit of Work для работы с репозиториями.
        /// </summary>
        private readonly IUnitOfWork<TContext> _uow;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GameService"/>.
        /// </summary>
        /// <param name="uow">Unit of Work.</param>
        public GameService(IUnitOfWork<TContext> uow)
        {
            _uow = uow;
        }

        ///<inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<GameDto> CreateAsync(GameDto dto)
        {
            using var scope = await _uow.DbContext.Database.BeginTransactionAsync();
            try
            {
                SeriesDto series = await _uow.seriesRepository.GetAsync(dto.Series.Name);
                ICollection <GameGenreDto> gameGenre = dto.GameGenres;
                if (null != series)
                {
                    dto.Series = null;
                    dto.SeriesId = series.Id;
                }
                foreach (GameGenreDto gg in gameGenre)
                {
                    GenreDto genre = await _uow.genreRepository.GetAsync(gg.Genre.Name);
                    if (null != genre)
                    {
                        gg.Genre = null;
                        gg.GenreId = genre.Id;
                    }
                    gg.Game = dto;
                }
                var game = await _uow.gameRepository.CreateAsync(dto);
                scope.Commit();
                return game;
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
                await _uow.gameRepository.DeleteAsync(ids);
                scope.Commit();
            }
            catch (Exception ex)
            {
                scope.Rollback();
                throw ex;
            }
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<GameDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _uow.gameRepository.GetAsync(id, token);
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<GameDto>> GetAsync(CancellationToken token = default)
        {
            return await _uow.gameRepository.GetAsync(token);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<GameDto> UpdateAsync(GameDto dto)
        {
            using var scope = await _uow.DbContext.Database.BeginTransactionAsync();
            try
            {
                var game = await _uow.gameRepository.UpdateAsync(dto);
                scope.Commit();
                return game;
            }
            catch (Exception ex)
            {
                scope.Rollback();
                throw ex;
            }
        }
    }
}
