﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAspApp.DAL.Domain
{
    /// <summary>
    /// Класс объекта Жанр.
    /// </summary>
    public class Genre : BaseEntity
    {
        /// <summary>
        /// Название жанра.
        /// </summary>
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
