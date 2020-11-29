using GameAspApp.DAL.Domain;
using System.ComponentModel.DataAnnotations;

namespace GameAspApp.Models.DTO
{
    /// <summary>
    /// DTO для <see cref="Series"/>.
    /// </summary>
    class SeriesDto : BaseDto
    {
        /// <summary>
        /// Название серии.
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
