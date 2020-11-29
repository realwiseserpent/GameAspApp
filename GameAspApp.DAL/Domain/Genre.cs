using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAspApp.DAL.Domain
{
    /// <summary>
    /// Класс объекта Жанр.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// Название жанра.
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
