﻿using System.ComponentModel.DataAnnotations;

namespace GameAspApp.Models.Requests.Series
{
    /// <summary>
    /// Запрос на создание серии.
    /// </summary>
    public class CreateSeriesRequest
    {
        /// <summary>
        /// Название серии.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Описание серии.
        /// </summary>
        [StringLength(2500)]
        public string Description { get; set; }
    }
}
