using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GameAspApp.Common.Swagger;
using GameAspApp.Models.DTO;
using GameAspApp.Models.Requests.Game;
using GameAspApp.Models.Responses.Game;
using GameAspApp.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameAspApp.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными об играх.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = SwaggerDocParts.Games)]
    public class GameController : ControllerBase
    {
        /// <summary>
        /// DI логгера.
        /// </summary>
        private readonly ILogger<GameController> _logger;
        /// <summary>
        /// DI сервиса для игр.
        /// </summary>
        private readonly IGameService _gameService;
        /// <summary>
        /// DI маппера.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GameController"/>
        /// </summary>
        /// <param name="gameService">Сервис игр.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="mapper">Маппер.</param>
        public GameController(IGameService gameService, ILogger<GameController> logger, IMapper mapper)
        {
            _gameService = gameService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение перечня доступных игр.
        /// </summary>
        /// <returns>Коллекция сущностей "Игра".</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GameResponse>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Game/Get was requested.");
            var response = await _gameService.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<GameResponse>>(response));
        }

        /// <summary>
        /// Получение игры по Id.
        /// </summary>
        /// <returns>Cущность "Игра".</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameResponse))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Game/GetById was requested.");
            var response = await _gameService.GetAsync(id, cancellationToken);
            return Ok(_mapper.Map<GameResponse>(response));
        }

        /// <summary>
        /// Добавление сущности "Игра".
        /// </summary>
        /// <returns>Cущность "Игра".</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameResponse))]
        public async Task<IActionResult> PostAsync(CreateGameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Game/Post was requested.");
            var response = await _gameService.CreateAsync(_mapper.Map<GameDto>(request));
            return Ok(_mapper.Map<GameResponse>(response));
        }

        /// <summary>
        /// Изменение сущности "Игра".
        /// </summary>
        /// <returns>Cущность "Игра".</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameResponse))]
        public async Task<IActionResult> PutAsync(UpdateGameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Game/Put was requested.");
            var response = await _gameService.UpdateAsync(_mapper.Map<GameDto>(request));
            return Ok(_mapper.Map<GameResponse>(response));
        }

        /// <summary>
        /// Удаление сущностей "Игра".
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {
            _logger.LogInformation("Game/Delete was requested.");
            await _gameService.DeleteAsync(ids);
            return NoContent();
        }
    }
}
