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
            services.AddSwaggerDocument(c =>
            {
                c.Title = SwaggerDocParts.Series;
                c.DocumentName = SwaggerDocParts.Series;
                c.ApiGroupNames = new[] { SwaggerDocParts.Series };
            });
            services.AddSwaggerDocument(c =>
            {
                c.Title = SwaggerDocParts.Genre;
                c.DocumentName = SwaggerDocParts.Genre;
                c.ApiGroupNames = new[] { SwaggerDocParts.Genre };
            });
            //services.AddSwaggerDocument(c =>
            //{
            //    c.Title = SwaggerDocParts.GameGenre;
            //    c.DocumentName = SwaggerDocParts.GameGenre;
            //    c.ApiGroupNames = new[] { SwaggerDocParts.GameGenre };
            //});

        }
    }
}
