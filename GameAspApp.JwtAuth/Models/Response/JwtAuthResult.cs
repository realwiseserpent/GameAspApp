using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameAspApp.JwtAuth.Models
{
    /// <summary>
    /// Ответ на запрос токенов.
    /// </summary>
    public class JwtAuthResult
    {
        /// <summary>
        /// Access token.
        /// </summary>
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Refresh token.
        /// </summary>
        [JsonPropertyName("refreshToken")]
        public RefreshToken RefreshToken { get; set; }
    }
}
