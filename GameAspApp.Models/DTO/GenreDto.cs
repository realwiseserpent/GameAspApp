using GameAspApp.DAL.Domain;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GameAspApp.Models.DTO
{
    /// <summary>
    /// DTO для <see cref="Genre"/>.
    /// </summary>
    public class GenreDto : BaseDto
    {
        /// <summary>
        /// Название жанра.
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Описание жанра.
        /// </summary>
        [StringLength(2500)]
        public string Description { get; set; }
    }
}
