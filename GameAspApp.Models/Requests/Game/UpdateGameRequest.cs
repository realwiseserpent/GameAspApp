using System.ComponentModel.DataAnnotations;

namespace GameAspApp.Models.Requests.Game
{
    /// <summary>
    /// Запрос на изменение игры.
    /// </summary>
    public class UpdateGameRequest : CreateGameRequest
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
