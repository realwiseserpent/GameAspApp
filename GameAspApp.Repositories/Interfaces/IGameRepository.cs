using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using GameAspApp.Repositories.Interfaces.CRUD;
using System.Threading.Tasks;
using System.Threading;

namespace GameAspApp.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностями "Игра".
    /// </summary>
    public interface IGameRepository : ICrudRepository<GameDto, Game>
    {
        /// <summary>
        /// Получение сущности по названию.
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="token"></param>
        /// <returns>Экземпляр сущности.</returns>
        Task<GameDto> GetAsync(string name, CancellationToken token = default);
    }
}
