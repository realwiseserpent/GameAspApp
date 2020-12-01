using GameAspApp.Models.DTO;
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

        /// <summary>
        /// Инициализирует экземпляр <see cref="GameService"/>.
        /// </summary>
        /// <param name="repository">Репозиторий.</param>
        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }

        ///<inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<GameDto> CreateAsync(GameDto dto)
        {
            return await _repository.CreateAsync(dto);
        }

        /// <inheritdoc cref="IDeletable.DeleteAsync(long[])"/>
        public async Task DeleteAsync(params long[] ids)
        {
            await _repository.DeleteAsync(ids);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<GameDto> GetAsync(long id, CancellationToken token = default)
        {
            return await _repository.GetAsync(id, token);
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<GameDto>> GetAsync(CancellationToken token = default)
        {
            return await _repository.GetAsync(token);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<GameDto> UpdateAsync(GameDto dto)
        {
            return await _repository.UpdateAsync(dto);
        }
    }
}
