using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.AspNetCore.Builder;
using GameAspApp.Common.Swagger;

namespace GameAspApp.Common.Swagger
{
    /// <summary>
    /// Расширения для конфигурации Swagger.
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Шаблон пути для конечной точки.
        /// </summary>
        const string endpointPath = "./swagger/{0}/swagger.json";
        /// <summary>
        /// Шаблон имени Api.
        /// </summary>
        const string apiName = "{0} API";
        /// <summary>
        /// Шаблон имени Api с версией.
        /// </summary>
        const string apiNameWithVersion = "{0} API {1}";

        /// <summary>
        /// Настройка документов Swagger.
        /// </summary>
        /// <param name="services">Коллекция сервисов для DI.</param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerDocParts.Account,
                    new OpenApiInfo { Title = string.Format(apiName, SwaggerDocParts.Account), Version = "v1" });
                c.SwaggerDoc(SwaggerDocParts.Game,
                    new OpenApiInfo { Title = string.Format(apiName, SwaggerDocParts.Game), Version = "v1" });
                c.SwaggerDoc(SwaggerDocParts.Genre,
                    new OpenApiInfo { Title = string.Format(apiName, SwaggerDocParts.Genre), Version = "v1" });
                c.SwaggerDoc(SwaggerDocParts.Series,
                    new OpenApiInfo { Title = string.Format(apiName, SwaggerDocParts.Series), Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter access JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowGameAspAppJwt",
                    builder =>
                    {
                        // white list
                        builder.WithOrigins("http://localhost:4200");
                        // we have only 3 methods in app, add its.
                        builder.WithMethods("GET", "POST", "OPTIONS");
                        // in request head
                        builder.AllowAnyHeader();
                        // lifetime
                        builder.SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
                    });
            });
        }

        /// <summary>
        /// Метод задает конченые точки для документов swagger.
        /// </summary>
        /// <param name="app">Средство конфигурации приложения.</param>
        public static void ConfigureSwaggerEndpoints(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(string.Format(endpointPath, SwaggerDocParts.Account),
                    string.Format(apiNameWithVersion, SwaggerDocParts.Account, "V1"));
                c.DocumentTitle = string.Format(apiName, SwaggerDocParts.Account);
                c.RoutePrefix = string.Empty;

                c.SwaggerEndpoint(string.Format(endpointPath, SwaggerDocParts.Game),
                    string.Format(apiNameWithVersion, SwaggerDocParts.Game, "V1"));
                c.DocumentTitle = string.Format(apiName, SwaggerDocParts.Game);
                c.RoutePrefix = string.Empty;

                c.SwaggerEndpoint(string.Format(endpointPath, SwaggerDocParts.Genre),
                    string.Format(apiNameWithVersion, SwaggerDocParts.Genre, "V1"));
                c.DocumentTitle = string.Format(apiName, SwaggerDocParts.Genre);
                c.RoutePrefix = string.Empty;

                c.SwaggerEndpoint(string.Format(endpointPath, SwaggerDocParts.Series),
                    string.Format(apiNameWithVersion, SwaggerDocParts.Series, "V1"));
                c.DocumentTitle = string.Format(apiName, SwaggerDocParts.Series);
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
