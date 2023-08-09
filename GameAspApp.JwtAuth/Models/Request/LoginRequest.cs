using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameAspApp.JwtAuth.Models.Request
{
    /// <summary>
    /// Запрос логина.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
