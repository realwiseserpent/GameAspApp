using GameAspApp.Models.DTO;
using GameAspApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using GameAspApp.Repositories.Interfaces;

namespace GameAspApp.Services.Services
{
    /// <summary>
    /// Сервис для работы с данными о сериях.
    /// </summary>
    public class SeriesService : ISeriesService
    {
        /// <summary>
        /// Репозиторий для работы с сущностями "Серия".
        /// </summary>
        private readonly ISeriesRepository _repository;

        /// <summary>
        /// Инициализирует экземпляр <see cref="SeriesService"/>.
        /// </summary>
        /// <param name="repository">Репозиторий.</param>
        public SeriesService(ISeriesRepository repository)
        {
            _repository = repository;
        }

        ///<inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<SeriesDto> CreateAsync(SeriesDto dto)
        {
            return await _repository.CreateAsync(dto);
        }

        /// <inheritdoc cref="IDeletable.DeleteAsync(long[])"/>
        public async Task DeleteAsync(params long[] ids)
        {
            await _repository.DeleteAsync(ids);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<SeriesDto> GetAsync(long id, CancellationToken token = default)
        {
            return await GetAsync(id, token);
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<SeriesDto>> GetAsync(CancellationToken token = default)
        {
            return await GetAsync(token);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<SeriesDto> UpdateAsync(SeriesDto dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
