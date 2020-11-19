using GameAspApp.Models.DTO;
using GameAspApp.Database.Domain;
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
        private readonly IMapper _mapper;

        public GameService(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <inheritdoc cref="IGameService"/>
        public IEnumerable<GameDto> GetAsync()
        {
            var games = new List<Game> {
                new Game
                {
                    Id = 1,
                    ReleaseDate = DateTime.Now,
                    Developer = "Me",
                    Publisher = "Me",
                    Genre = "Programming",
                    Name = "GameAspApp",
                    Metascore = 10
                }};
            var response = _mapper.Map<IEnumerable<GameDto>>(games);
            return response;
        }
    }
}
