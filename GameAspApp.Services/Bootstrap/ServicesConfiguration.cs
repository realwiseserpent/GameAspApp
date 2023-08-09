using GameAspApp.Services.Interfaces;
using GameAspApp.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using GameAspApp.DAL.Contexts;

namespace GameAspApp.Services.Bootstrap
{
    /// <summary>
    /// Методы расширения для конфигурации сервисов.
    /// </summary>
    public static class ServicesConfiguration
    {
        /// <summary>
        /// Конфигурация сервисов.
        /// </summary>
        /// <param name="services">Коллекция сервисов из Startup.</param>
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IGameService, GameService<GameAspAppContext>>();
            services.AddTransient<IGenreService, GenreService<GameAspAppContext>>();
            //services.AddTransient<IGameGenreService, GameGenreService>();
            services.AddTransient<ISeriesService, SeriesService<GameAspAppContext>>();
        }
    }
}
