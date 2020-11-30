using GameAspApp.Models.DTO;
using GameAspApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using GameAspApp.Repositories.Interfaces;

namespace GameAspApp.Services.Services
{
    /// <summary>
    /// Сервис для работы с данными о жанрах игр.
    /// </summary>
    public class GameGenreService : IGameGenreService
    {
        /// <summary>
        /// Репозиторий для работы с сущностями "Жанры игр".
        /// </summary>
        private readonly IGameGenreRepository _repository;

        public GameGenreService(IGameGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task<GameGenreDto> CreateAsync(GameGenreDto dto)
        {
            return await _repository.CreateAsync(dto);
        }

        public async Task DeleteAsync(params long[] ids)
        {
            await _repository.DeleteAsync(ids);
        }

        public async Task<GameGenreDto> GetAsync(long id, CancellationToken token = default)
        {
            return await GetAsync(id, token);
        }

        public async Task<IEnumerable<GameGenreDto>> GetAsync(CancellationToken token = default)
        {
            return await GetAsync(token);
        }

        public async Task<GameGenreDto> UpdateAsync(GameGenreDto dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
