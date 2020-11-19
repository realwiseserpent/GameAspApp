using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameAspApp.Services.Interfaces;
using GameAspApp.Models.DTO;
using System.Collections.Generic;
using GameAspApp.Common.Swagger;

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
        private readonly IGameService _gameService;

        /// <summary>
        /// Конструктор контроллера с DI
        /// </summary>
        /// <param name="gameService">Внедряемый сервис</param>
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Получение перечня игр.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GameDto>))]
        public IActionResult Get()
        {
            var response = _gameService.GetAsync();
            return Ok(response);
        }
    }
}
