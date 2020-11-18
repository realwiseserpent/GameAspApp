using Microsoft.Extensions.DependencyInjection;

namespace GameAspApp.Common.Swagger
{
    /// <summary>
    /// Расширения для конфигурации Swagger.
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Настройка документов Swagger.
        /// </summary>
        /// <param name="services">Коллекция сервисов для DI.</param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerDocument(c =>
            {
                c.Title = SwaggerDocParts.Games;
                c.DocumentName = SwaggerDocParts.Games;
                c.ApiGroupNames = new[] { SwaggerDocParts.Games };
            });
        }
    }
}
