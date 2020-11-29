using System.Reflection;
using GameAspApp.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameAspApp.DAL.Bootstrap
{
    /// <summary>
    /// Конфигурации БД.
    /// </summary>
    public static class DbConfigurations
    {
        /// <summary>
        /// Подключение DbContext.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="configuration">Конфигурация.</param>
        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GameAspAppContext>(
                options => options.UseNpgsql(
                    configuration.GetConnectionString(nameof(GameAspAppContext)),
                    builder => builder.MigrationsAssembly(typeof(GameAspAppContext).Assembly.FullName))
            );
        }
    }
}
