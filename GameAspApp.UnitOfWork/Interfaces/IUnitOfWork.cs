using GameAspApp.Repositories.Interfaces;

namespace GameAspApp.UnitOfWork.Interfaces
{
    /// <summary>
    /// Интерфейс Unit of Work.
    /// </summary>
    public interface IUnitOfWork<TContext>
    {
        public TContext DbContext
        { get; }
        public IGameRepository<TContext> gameRepository
        { get; }
        public IGenreRepository<TContext> genreRepository
        { get; }
        public IGameGenreRepository<TContext> gameGenreRepository
        { get; }
        public ISeriesRepository<TContext> seriesRepository
        { get; }
    }
}