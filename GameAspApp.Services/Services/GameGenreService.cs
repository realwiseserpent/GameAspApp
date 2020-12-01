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

        /// <summary>
        /// Инициализирует экземпляр <see cref="GameGenreService"/>.
        /// </summary>
        /// <param name="repository">Репозиторий.</param>
        public GameGenreService(IGameGenreRepository repository)
        {
            _repository = repository;
        }

        ///<inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<GameGenreDto> CreateAsync(GameGenreDto dto)
        {
            return await _repository.CreateAsync(dto);
        }

        /// <inheritdoc cref="IDeletable.DeleteAsync(long[])"/>
        public async Task DeleteAsync(params long[] ids)
        {
            await _repository.DeleteAsync(ids);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<GameGenreDto> GetAsync(long id, CancellationToken token = default)
        {
            return await GetAsync(id, token);
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<GameGenreDto>> GetAsync(CancellationToken token = default)
        {
            return await GetAsync(token);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<GameGenreDto> UpdateAsync(GameGenreDto dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
