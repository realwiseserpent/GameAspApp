using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using GameAspApp.Repositories.Interfaces.CRUD;

namespace GameAspApp.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностями "Жанры игр".
    /// </summary>
    interface IGameGenreRepository : ICrudRepository<GameGenreDto, GameGenre>
    {
    }
}
