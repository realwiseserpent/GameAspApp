﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAspApp.DAL.Domain
{
    /// <summary>
    /// Класс объекта Серия.
    /// </summary>
    public class Series : BaseEntity
    {
        /// <summary>
        /// Название серии.
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
