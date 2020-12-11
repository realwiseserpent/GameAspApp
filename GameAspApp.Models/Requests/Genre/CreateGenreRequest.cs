using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using GameAspApp.Models.DTO;
    
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

        /// <summary>
        /// Описание жанра.
        /// </summary>
        [StringLength(2500)]
        public string Description { get; set; }
    }
}
