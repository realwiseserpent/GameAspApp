using System;
using GameAspApp.DAL.Contexts;
using GameAspApp.Repositories.Interfaces;

namespace GameAspApp.UnitOfWork
{
    /// <summary>
    /// Класс для работы с репозиториями.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// Репозиторий для работы с сущностями "Игра".
        /// </summary>
        private readonly IGameRepository _gameRepository;
        /// <summary>
        /// Репозиторий для работы с сущностями "Жанр".
        /// </summary>
        private readonly IGenreRepository _genreRepository;
        /// <summary>
        /// Репозиторий для работы с сущностями "Жанры игр".
        /// </summary>
        private readonly IGameGenreRepository _gameGenreRepository;
        /// <summary>
        /// Репозиторий для работы с сущностями "Серия".
        /// </summary>
        private readonly ISeriesRepository _seriesRepository;
        /// <summary>
        /// Контекст для работы с данными БД.
        /// </summary>
        protected readonly GameAspAppContext _сontext;

        public IGameRepository gameRepository { get { return _gameRepository; } }
        public IGenreRepository genreRepository { get { return _genreRepository; } }
        public IGameGenreRepository gameGenreRepository { get { return _gameGenreRepository; } }
        public ISeriesRepository seriesRepository { get { return _seriesRepository; } }
        public GameAspAppContext DbContext { get { return _сontext; } }

        private bool disposed = false;

        /// <summary>
        /// Инициализирует экземпляр <see cref="UnitOfWork"/>.
        /// </summary>
        /// <param name="сontext">Контекст для работы с данными БД.</param>
        /// <param name="gameRepository">Репозиторий для работы с сущностями "Игра".</param>
        /// <param name="genreRepository">Репозиторий для работы с сущностями "Жанр".</param>
        /// <param name="seriesRepository">Репозиторий для работы с сущностями "Серия".</param>
        public UnitOfWork(GameAspAppContext сontext,
            IGameRepository gameRepository, 
            IGenreRepository genreRepository,
            ISeriesRepository seriesRepository)
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
