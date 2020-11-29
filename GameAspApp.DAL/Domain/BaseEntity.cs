using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAspApp.DAL.Domain
{
    /// <summary>
    /// Базовый класс для доменных моделей.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}
