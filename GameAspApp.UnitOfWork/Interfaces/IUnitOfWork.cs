using GameAspApp.DAL.Contexts;
using GameAspApp.Repositories.Interfaces;

namespace GameAspApp.UnitOfWork.Interfaces
{
    /// <summary>
    /// Интерфейс Unit of Work.
    /// </summary>
    public interface IUnitOfWork
    {
        public GameAspAppContext DbContext
        { get; }
        public IGameRepository gameRepository
        { get; }
        public IGenreRepository genreRepository
        { get; }
        public IGameGenreRepository gameGenreRepository
        { get; }
        public ISeriesRepository seriesRepository
        { get; }
    }
}