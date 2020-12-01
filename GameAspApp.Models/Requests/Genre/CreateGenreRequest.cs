using System.ComponentModel.DataAnnotations;

namespace GameAspApp.Models.Requests.Genre
{
    /// <summary>
    /// Запрос на создание жанра.
    /// </summary>
    public class CreateGenreRequest
    {
        /// <summary>
        /// Название жанра.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
