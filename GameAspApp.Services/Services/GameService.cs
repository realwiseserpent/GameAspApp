﻿using GameAspApp.Models.DTO;
using GameAspApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using GameAspApp.Repositories.Interfaces;

namespace GameAspApp.Services.Services
{
    /// <summary>
    /// Сервис для работы с данными об играх.
    /// </summary>
    public class GameService : IGameService
    {
        /// <summary>
        /// Репозиторий для работы с сущностями "Игра".
        /// </summary>
        private readonly IGameRepository _repository;

        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<GameDto> CreateAsync(GameDto dto)
        {
            return await _repository.CreateAsync(dto);
        }

        public async Task DeleteAsync(params long[] ids)
        {
            await _repository.DeleteAsync(ids);
        }

        public async Task<GameDto> GetAsync(long id, CancellationToken token = default)
        {
            return await GetAsync(id, token);
        }

        public async Task<IEnumerable<GameDto>> GetAsync(CancellationToken token = default)
        {
            return await GetAsync(token);
        }

        public async Task<GameDto> UpdateAsync(GameDto dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
