using System;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using GameAspApp.JwtAuth.Models;

namespace GameAspApp.JwtAuth.Interfaces
{
    /// <summary>
    /// Интерфейс менеджера токенов.
    /// </summary>
    public interface IJwtAuthManager
    {
        /// <summary>
        /// Свойство доступа к словарю RT.
        /// </summary>
        IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary { get; }

        /// <summary>
        /// Генерация токенов.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="claims">Массив утверждений.</param>
        /// <param name="now">Текущая дата.</param>
        /// <returns><see cref="JwtAuthResult"/></returns>
        JwtAuthResult GenerateTokens(string username, Claim[] claims, DateTime now);

        /// <summary>
        /// Обновить пару токенов.
        /// </summary>
        /// <param name="refreshToken">RT.</param>
        /// <param name="accessToken">AT.</param>
        /// <param name="now">Текущая дата.</param>
        /// <returns></returns>
        JwtAuthResult Refresh(string refreshToken, string accessToken, DateTime now);

        /// <summary>
        /// Удаление RT по времени.
        /// </summary>
        /// <param name="now">Текущая дата.</param>
        void RemoveExpiredRefreshTokens(DateTime now);

        /// <summary>
        /// Удалить RT пользователя.
        /// </summary>
        /// <param name="userName">Имя пользователя.</param>
        void RemoveRefreshTokenByUserName(string userName);

        /// <summary>
        /// Декодирование токена.
        /// </summary>
        /// <param name="token">AT.</param>
        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
    }
}
