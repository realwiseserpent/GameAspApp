using GameAspApp.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using GameAspApp.DAL.Contexts;

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
            services.AddScoped<IGameRepository<GameAspAppContext>, GameRepository<GameAspAppContext>>();
            services.AddScoped<IGenreRepository<GameAspAppContext>, GenreRepository<GameAspAppContext>>();
            services.AddScoped<ISeriesRepository<GameAspAppContext>, SeriesRepository<GameAspAppContext>>();
        }
    }
}
