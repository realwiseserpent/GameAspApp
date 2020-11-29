using GameAspApp.Models.DTO;
using GameAspApp.DAL.Mocks;
using GameAspApp.DAL.Contexts;
using GameAspApp.DAL.Domain;
using GameAspApp.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System;

namespace GameAspApp.Services.Services
{
    /// <summary>
    /// Сервис для работы с данными об играх.
    /// </summary>
    public class GameService : IGameService
    {
        /// <summary>
        /// DI маппера.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        private readonly GameAspAppContext _context;

        /// <summary>
        /// Конструктор сервиса с DI.
        /// </summary>
        /// <param name="mapper">Внедряемый маппер.</param>
        public GameService(GameAspAppContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <inheritdoc cref="IGameService"/>
        public IEnumerable<GameDto> GetAsync()
        {
            var series = new Series
            {
                Id = 1,
                Name = "123"
            };

            var game = new Game
            {
                Id = 1,
                Name = "123",
                Developer = "test",
                Publisher = "test",
                Metascore = 55,
                ReleaseDate = DateTime.Now,
                Series = series
            };

            var genre = new Genre { Id = 1, Name = "1235" };

            var gameGenre = new GameGenre{
                Id=1,
                Genre = genre,
                Game = game
            };

            _context.Series.Add(series);
            _context.Games.Add(game);
            _context.Genres.Add(genre);
            _context.GameGenres.Add(gameGenre);

            _context.SaveChanges();
            //var games = GameMock.GetGames();
            var response = _mapper.Map<IEnumerable<GameDto>>(_context.Games);
            return response;
        }
    }
}
