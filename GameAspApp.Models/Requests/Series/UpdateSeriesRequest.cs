﻿using System.ComponentModel.DataAnnotations;

namespace GameAspApp.Models.Requests.Series
{
    /// <summary>
    /// Запрос на изменение серии.
    /// </summary>
    public class UpdateSeriesRequest : CreateSeriesRequest
    {
        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
