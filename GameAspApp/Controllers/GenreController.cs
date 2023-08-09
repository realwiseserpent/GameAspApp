using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GameAspApp.Common.Swagger;
using GameAspApp.Models.DTO;
using GameAspApp.Models.Requests.Genre;
using GameAspApp.Models.Responses.Genre;
using GameAspApp.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using GameAspApp.JwtAuth;

namespace GameAspApp.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными о жанрах.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [ApiExplorerSettings(GroupName = SwaggerDocParts.Genre)]
    public class GenreController : ControllerBase
    {
        /// <summary>
        /// DI логгера.
        /// </summary>
        private readonly ILogger<GenreController> _logger;
        /// <summary>
        /// DI сервиса для жанров.
        /// </summary>
        private readonly IGenreService _genreService;
        /// <summary>
        /// DI маппера.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="GenreController"/>
        /// </summary>
        /// <param name="genreService">Сервис жанров.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="mapper">Маппер.</param>
        public GenreController(IGenreService genreService, ILogger<GenreController> logger, IMapper mapper)
        {
            _genreService = genreService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение перечня доступных жанров.
        /// </summary>
        /// <returns>Коллекция сущностей "Жанр".</returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GenreResponse>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Genre/Get was requested.");
            var response = await _genreService.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<GenreResponse>>(response));
        }

        /// <summary>
        /// Получение жанра по Id.
        /// </summary>
        /// <returns>Cущность "Жанр".</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.Default)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenreResponse))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Genre/GetById was requested.");
            var response = await _genreService.GetAsync(id, cancellationToken);
            return Ok(_mapper.Map<GenreResponse>(response));
        }

        /// <summary>
        /// Добавление сущности "Жанр".
        /// </summary>
        /// <returns>Cущность "Жанр".</returns>
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenreResponse))]
        public async Task<IActionResult> PostAsync(CreateGenreRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Genre/Post was requested.");
            var response = await _genreService.CreateAsync(_mapper.Map<GenreDto>(request));
            return Ok(_mapper.Map<GenreResponse>(response));
        }

        /// <summary>
        /// Изменение сущности "Жанр".
        /// </summary>
        /// <returns>Cущность "Жанр".</returns>
        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenreResponse))]
        public async Task<IActionResult> PutAsync(UpdateGenreRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Genre/Put was requested.");
            var response = await _genreService.UpdateAsync(_mapper.Map<GenreDto>(request));
            return Ok(_mapper.Map<GenreResponse>(response));
        }

        /// <summary>
        /// Удаление сущностей "Жанр".
        /// </summary>
        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {
            _logger.LogInformation("Genre/Delete was requested.");
            await _genreService.DeleteAsync(ids);
            return NoContent();
        }
    }
}
