using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GameAspApp.Common.Swagger;
using GameAspApp.Models.DTO;
using GameAspApp.Models.Requests.GameGenre;
using GameAspApp.Models.Responses.GameGenre;
using GameAspApp.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameAspApp.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными о жанрах игр.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = SwaggerDocParts.GameGenre)]
    public class GameGenreController : ControllerBase
    {
        /// <summary>
        /// DI логгера.
        /// </summary>
        private readonly ILogger<GameGenreController> _logger;
        /// <summary>
        /// DI сервиса для жанров игр.
        /// </summary>
        private readonly IGameGenreService _gameGenreService;
        /// <summary>
        /// DI маппера.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GameGenreController"/>
        /// </summary>
        /// <param name="gameGenreService">Сервис жанров игр.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="mapper">Маппер.</param>
        public GameGenreController(IGameGenreService gameGenreService, ILogger<GameGenreController> logger, IMapper mapper)
        {
            _gameGenreService = gameGenreService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение перечня доступных жанров игр.
        /// </summary>
        /// <returns>Коллекция сущностей "Жанр игр".</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GameGenreResponse>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("GameGenre/Get was requested.");
            var response = await _gameGenreService.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<GameGenreResponse>>(response));
        }

        /// <summary>
        /// Получение жанра игр по Id.
        /// </summary>
        /// <returns>Cущность "Жанр игр".</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameGenreResponse))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GameGenre/GetById was requested.");
            var response = await _gameGenreService.GetAsync(id, cancellationToken);
            return Ok(_mapper.Map<GameGenreResponse>(response));
        }

        /// <summary>
        /// Добавление сущности "Жанр игр".
        /// </summary>
        /// <returns>Cущность "Жанр игр".</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameGenreResponse))]
        public async Task<IActionResult> PostAsync(CreateGameGenreRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GameGenre/Post was requested.");
            var response = await _gameGenreService.CreateAsync(_mapper.Map<GameGenreDto>(request));
            return Ok(_mapper.Map<GameGenreResponse>(response));
        }

        /// <summary>
        /// Изменение сущности "Жанр игр".
        /// </summary>
        /// <returns>Cущность "Жанр игр".</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameGenreResponse))]
        public async Task<IActionResult> PutAsync(UpdateGameGenreRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GameGenre/Put was requested.");
            var response = await _gameGenreService.UpdateAsync(_mapper.Map<GameGenreDto>(request));
            return Ok(_mapper.Map<GameGenreResponse>(response));
        }

        /// <summary>
        /// Удаление сущностей "Жанр игр".
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {
            _logger.LogInformation("GameGenre/Delete was requested.");
            await _gameGenreService.DeleteAsync(ids);
            return NoContent();
        }
    }
}
