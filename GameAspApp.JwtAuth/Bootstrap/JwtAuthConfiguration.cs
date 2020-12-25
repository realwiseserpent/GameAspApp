using GameAspApp.JwtAuth.Interfaces;
using GameAspApp.JwtAuth.Services.Interfaces;
using GameAspApp.JwtAuth.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GameAspApp.JwtAuth.Models;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace GameAspApp.JwtAuth.Bootstrap
{
    /// <summary>
    /// Расширения для конфигурации аутентификации через JWT токены.
    /// </summary>
    public static class JwtAuthConfiguration
    {
        /// <summary>
        /// Конфигурирование аутентификации через JWT токены.
        /// </summary>
        /// <param name="services">Коллекция сервисов из Startup.</param>
        /// <param name="configuration">Конфигурация.</param>
        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtTokenConfig = configuration.GetSection(nameof(JwtTokenConfig)).Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);
            //добавление аутентификации
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                // the authentication requires HTTPS for the metadata address or authority
                x.RequireHttpsMetadata = true;
                // saves the JWT access token in the current HttpContext,
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

            //регистрация сервисов
            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            services.AddHostedService <JwtRefreshTokenCache>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
