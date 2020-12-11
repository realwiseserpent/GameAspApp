using GameAspApp.DAL.Domain;
using GameAspApp.Models.DTO;
using GameAspApp.Repositories.Interfaces.CRUD;
using Microsoft.EntityFrameworkCore;

namespace GameAspApp.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностями "Жанр".
    /// </summary>
    public interface IGenreRepository<TContext> : 
        ICrudRepository<GenreDto, Genre, TContext>
    {
    }
}
