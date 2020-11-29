using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameAspApp.Services.Interfaces;
using GameAspApp.Models.DTO;
using System.Collections.Generic;
using GameAspApp.Common.Swagger;
using Microsoft.Extensions.Logging;

namespace GameAspApp.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными о играх.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = SwaggerDocParts.Games)]
    public class GameController : ControllerBase
    {
        /// <summary>
        /// Сообщение логгера в методе Get.
        /// </summary>
        private const string getMessage = "Games/Get was requested.";
        /// <summary>
        /// DI логгера.
        /// </summary>
        private readonly ILogger<GameController> _logger;
        /// <summary>
        /// DI сервиса для игр.
        /// </summary>
        private readonly IGameService _gameService;

        /// <summary>
        /// Конструктор контроллера с DI.
        /// </summary>
        /// <param name="gameService">Внедряемый сервис.</param>
        /// <param name="logger">Внедряемый логгер.</param>
        public GameController(IGameService gameService, ILogger<GameController> logger)
        {
            _gameService = gameService;
            _logger = logger;
        }

        /// <summary>
        /// Реализация GET для контроллера.
        /// </summary>
        /// <returns>Результат запроса.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GameDto>))]
        public IActionResult Get()
        {
            _logger.LogInformation(getMessage);
            var response = _gameService.GetAsync();
            return Ok(response);
        }
    }
}
