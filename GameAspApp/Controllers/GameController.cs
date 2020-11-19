using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using GameAspApp.Common.Swagger;
using Microsoft.Extensions.Logging;

namespace GameAspApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = SwaggerDocParts.Games)]
    public class GameController : ControllerBase
    {
        private const string getMessage = "Games/Get was requested.";
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Index")]
        public IEnumerable<Game> Get()
        {
            _logger.LogInformation(getMessage);
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Game
            {
                ReleaseDate = DateTime.Now.AddDays(index),
                Name = index.ToString(),
                Developer = index.ToString(),
                Publisher = index.ToString(),
                Metascore = rng.Next(1, 10),
            })
            .ToArray();
        }
    }
}
