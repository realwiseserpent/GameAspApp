using System.Text.Json.Serialization;

namespace GameAspApp.JwtAuth.Models
{
    /// <summary>
    /// AT config from appconfig.
    /// </summary>
    public class JwtTokenConfig
    {
        /// <summary>
        /// Secret.
        /// </summary>
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Issuer.
        /// </summary>
        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// Audience.
        /// </summary>
        [JsonPropertyName("audience")]
        public string Audience { get; set; }

        /// <summary>
        /// AT time.
        /// </summary>
        [JsonPropertyName("accessTokenExpiration")]
        public int AccessTokenExpiration { get; set; }

        /// <summary>
        /// RT time.
        /// </summary>
        [JsonPropertyName("refreshTokenExpiration")]
        public int RefreshTokenExpiration { get; set; }
    }
}
