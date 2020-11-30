using System.ComponentModel.DataAnnotations;

namespace GameAspApp.Models.Requests.Game
{
    /// <summary>
    /// Запрос на изменение игры.
    /// </summary>
    class UpdateGameRequest : CreateGameRequest
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
