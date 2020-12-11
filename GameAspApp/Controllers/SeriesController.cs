using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GameAspApp.Common.Swagger;
using GameAspApp.Models.DTO;
using GameAspApp.Models.Requests.Series;
using GameAspApp.Models.Responses.Series;
using GameAspApp.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameAspApp.Controllers
{
    /// <summary>
    /// Контроллер для работы с данными о сериях.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = SwaggerDocParts.Series)]
    public class SeriesController : ControllerBase
    {
        /// <summary>
        /// DI логгера.
        /// </summary>
        private readonly ILogger<SeriesController> _logger;
        /// <summary>
        /// DI сервиса для серий.
        /// </summary>
        private readonly ISeriesService _seriesService;
        /// <summary>
        /// DI маппера.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует экземпляр <see cref="SeriesController"/>
        /// </summary>
        /// <param name="seriesService">Сервис серий.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="mapper">Маппер.</param>
        public SeriesController(ISeriesService seriesService, ILogger<SeriesController> logger, IMapper mapper)
        {
            _seriesService = seriesService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение перечня доступных серий.
        /// </summary>
        /// <returns>Коллекция сущностей "Серия".</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SeriesResponse>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Series/Get was requested.");
            var response = await _seriesService.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<SeriesResponse>>(response));
        }

        /// <summary>
        /// Получение серии по Id.
        /// </summary>
        /// <returns>Cущность "Серия".</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeriesResponse))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Series/GetById was requested.");
            var response = await _seriesService.GetAsync(id, cancellationToken);
            return Ok(_mapper.Map<SeriesResponse>(response));
        }

        /// <summary>
        /// Добавление сущности "Серия".
        /// </summary>
        /// <returns>Cущность "Серия".</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeriesResponse))]
        public async Task<IActionResult> PostAsync(CreateSeriesRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Series/Post was requested.");
            var response = await _seriesService.CreateAsync(_mapper.Map<SeriesDto>(request));
            return Ok(_mapper.Map<SeriesResponse>(response));
        }

        /// <summary>
        /// Изменение сущности "Серия".
        /// </summary>
        /// <returns>Cущность "Серия".</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeriesResponse))]
        public async Task<IActionResult> PutAsync(UpdateSeriesRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Series/Put was requested.");
            var response = await _seriesService.UpdateAsync(_mapper.Map<SeriesDto>(request));
            return Ok(_mapper.Map<SeriesResponse>(response));
        }

        /// <summary>
        /// Удаление сущностей "Серия".
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {
            _logger.LogInformation("Series/Delete was requested.");
            await _seriesService.DeleteAsync(ids);
            return NoContent();
        }
    }
}
