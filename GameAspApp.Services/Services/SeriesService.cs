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

        public SeriesService(ISeriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<SeriesDto> CreateAsync(SeriesDto dto)
        {
            return await _repository.CreateAsync(dto);
        }

        public async Task DeleteAsync(params long[] ids)
        {
            await _repository.DeleteAsync(ids);
        }

        public async Task<SeriesDto> GetAsync(long id, CancellationToken token = default)
        {
            return await GetAsync(id, token);
        }

        public async Task<IEnumerable<SeriesDto>> GetAsync(CancellationToken token = default)
        {
            return await GetAsync(token);
        }

        public async Task<SeriesDto> UpdateAsync(SeriesDto dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
