using System;
using System.Text.Json.Serialization;

namespace GameAspApp.JwtAuth.Models
{
    /// <summary>
    /// RT model.
    /// </summary>
    public class RefreshToken
    {
        /// <summary>
        /// User name.
        /// </summary>
        [JsonPropertyName("username")]
        public string UserName { get; set; }    // can be used for usage tracking
        // can optionally include other metadata, such as user agent, ip address, device name, and so on

        /// <summary>
        /// RT value.
        /// </summary>
        [JsonPropertyName("tokenString")]
        public string TokenString { get; set; }

        /// <summary>
        /// Expipe date.
        /// </summary>
        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }
    }
}
