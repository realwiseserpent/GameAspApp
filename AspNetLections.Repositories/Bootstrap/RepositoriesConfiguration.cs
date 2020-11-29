using GameAspApp.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GameAspApp.Repositories.Bootstrap
{
    /// <summary>
    /// Расширения для конфигурации репозиториев.
    /// </summary>
    public static class RepositoriesConfiguration
    {
        /// <summary>
        /// Конфигурирование репозиториев.
        /// </summary>
        /// <param name="services">Коллекция сервисов из Startup.</param>
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IGameGenreRepository, GameGenreRepository>();
            services.AddScoped<ISeriesRepository, SeriesRepository>();
        }
    }
}
