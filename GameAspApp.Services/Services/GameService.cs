using GameAspApp.Models.DTO;
using GameAspApp.Database.Mocks;
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
        /// Конструктор сервиса с DI.
        /// </summary>
        /// <param name="mapper">Внедряемый маппер.</param>
        public GameService(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        /// <inheritdoc cref="IGameService"/>
        public IEnumerable<GameDto> GetAsync()
        {
            var games = GameMock.GetGames();
            var response = _mapper.Map<IEnumerable<GameDto>>(games);
            return response;
        }
    }
}
