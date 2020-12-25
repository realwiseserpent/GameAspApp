using System.Text.Json.Serialization;

namespace GameAspApp.JwtAuth.Models.Request
{
    /// <summary>
    /// Запрос refresh token.
    /// </summary>
    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
