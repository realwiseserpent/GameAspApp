using System.Threading.Tasks;
using System.Threading;

namespace GameAspApp.Repositories.Interfaces.CRUD
{
    /// <summary>
    /// Интерфейс для получения сущности по идентификатору.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    /// <typeparam name="TModel">Domain model.</typeparam>
    public interface IGettableById<TDto, TModel>
    {
        /// <summary>
        /// Получение сущности по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Экземпляр сущности.</returns>
        Task<TDto> GetAsync(long id, CancellationToken token = default);
    }
}