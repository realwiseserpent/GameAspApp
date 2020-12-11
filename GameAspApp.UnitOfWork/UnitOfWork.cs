using System;
using GameAspApp.Repositories.Interfaces;
using GameAspApp.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameAspApp.UnitOfWork
{
    /// <summary>
    /// Класс для работы с репозиториями.
    /// </summary>
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : DbContext
    {
        /// <summary>
        /// Репозиторий для работы с сущностями "Игра".
        /// </summary>
        private readonly IGameRepository<TContext> _gameRepository;
        /// <summary>
        /// Репозиторий для работы с сущностями "Жанр".
        /// </summary>
        private readonly IGenreRepository<TContext> _genreRepository;
        /// <summary>
        /// Репозиторий для работы с сущностями "Жанры игр".
        /// </summary>
        private readonly IGameGenreRepository<TContext> _gameGenreRepository;
        /// <summary>
        /// Репозиторий для работы с сущностями "Серия".
        /// </summary>
        private readonly ISeriesRepository<TContext> _seriesRepository;
        /// <summary>
        /// Контекст для работы с данными БД.
        /// </summary>
        protected readonly TContext _сontext;

        public IGameRepository<TContext> gameRepository { get { return _gameRepository; } }
        public IGenreRepository<TContext> genreRepository { get { return _genreRepository; } }
        public IGameGenreRepository<TContext> gameGenreRepository { get { return _gameGenreRepository; } }
        public ISeriesRepository<TContext> seriesRepository { get { return _seriesRepository; } }
        public TContext DbContext { get { return _сontext; } }

        private bool disposed = false;

        /// <summary>
        /// Инициализирует экземпляр <see cref="UnitOfWork"/>.
        /// </summary>
        /// <param name="сontext">Контекст для работы с данными БД.</param>
        /// <param name="gameRepository">Репозиторий для работы с сущностями "Игра".</param>
        /// <param name="genreRepository">Репозиторий для работы с сущностями "Жанр".</param>
        /// <param name="seriesRepository">Репозиторий для работы с сущностями "Серия".</param>
        public UnitOfWork(TContext сontext,
            IGameRepository<TContext> gameRepository, 
            IGenreRepository<TContext> genreRepository,
            ISeriesRepository<TContext> seriesRepository)
        {
            _сontext = сontext;
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
            _seriesRepository = seriesRepository;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
