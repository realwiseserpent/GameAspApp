using GameAspApp.Models.DTO;
using GameAspApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using GameAspApp.Repositories.Interfaces;

namespace GameAspApp.Services.Services
{
    /// <summary>
    /// Сервис для работы с данными о жанрах.
    /// </summary>
    public class GenreService : IGenreService
    {
        /// <summary>
        /// Репозиторий для работы с сущностями "Жанр".
        /// </summary>
        private readonly IGenreRepository _repository;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GenreService"/>.
        /// </summary>
        /// <param name="repository">Репозиторий.</param>
        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }

        ///<inheritdoc cref="ICreatable{TDto}.CreateAsync(TDto)"/>
        public async Task<GenreDto> CreateAsync(GenreDto dto)
        {
            return await _repository.CreateAsync(dto);
        }

        /// <inheritdoc cref="IDeletable.DeleteAsync(long[])"/>
        public async Task DeleteAsync(params long[] ids)
        {
            await _repository.DeleteAsync(ids);
        }

        /// <inheritdoc cref="IGettableById{TDto}.GetAsync(long, CancellationToken)"/>
        public async Task<GenreDto> GetAsync(long id, CancellationToken token = default)
        {
            return await GetAsync(id, token);
        }

        /// <inheritdoc cref="IGettable{TDto}.GetAsync(CancellationToken)"/>
        public async Task<IEnumerable<GenreDto>> GetAsync(CancellationToken token = default)
        {
            return await GetAsync(token);
        }

        /// <inheritdoc cref="IUpdatable{TDto}.UpdateAsync(TDto)"/>
        public async Task<GenreDto> UpdateAsync(GenreDto dto)
        {
            return await UpdateAsync(dto);
        }
    }
}
