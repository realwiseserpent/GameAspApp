using GameAspApp.DAL.Domain;
using System.ComponentModel.DataAnnotations;

namespace GameAspApp.Models.DTO
{
    /// <summary>
    /// DTO для <see cref="Series"/>.
    /// </summary>
    public class SeriesDto : BaseDto
    {
        /// <summary>
        /// Название серии.
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Описание серии.
        /// </summary>
        [StringLength(2500)]
        public string Description { get; set; }
    }
}
