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
        private const string getMessage = "Games/Get was requested.";
        private readonly ILogger<GameController> _logger;
        private readonly IGameService _gameService;
        
        /// <summary>
        /// Конструктор контроллера с DI
        /// </summary>
        /// <param name="gameService">Внедряемый сервис</param>
        public GameController(IGameService gameService, ILogger<GameController> logger)
        {
            _gameService = gameService;
            _logger = logger;
        }

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
