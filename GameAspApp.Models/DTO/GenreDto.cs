using GameAspApp.DAL.Domain;
using System.ComponentModel.DataAnnotations;

namespace GameAspApp.Models.DTO
{
    /// <summary>
    /// DTO для <see cref="Genre"/>.
    /// </summary>
    class GenreDto : BaseDto
    {
        /// <summary>
        /// Название жанра.
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
