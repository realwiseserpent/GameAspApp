using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using GameAspApp.Common.Swagger;

namespace GameAspApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = SwaggerDocParts.Games)]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Game> Get()
        {
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
