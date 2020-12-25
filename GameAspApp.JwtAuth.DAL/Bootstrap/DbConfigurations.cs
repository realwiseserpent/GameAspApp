using GameAspApp.JwtAuth.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameAspApp.JwtAuth.DAL.Bootstrap
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
        public static void ConfigureAuthDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GameAspAppJwtContext>(
                options => options.UseNpgsql(
                    configuration.GetConnectionString(nameof(GameAspAppJwtContext)),
                    builder => builder.MigrationsAssembly(typeof(GameAspAppJwtContext).Assembly.FullName))
            );
        }
    }
}
