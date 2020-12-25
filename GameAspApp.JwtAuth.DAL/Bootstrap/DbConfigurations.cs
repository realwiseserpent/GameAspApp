using GameAspApp.JwtAuth.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameAspApp.JwtAuth.DAL.Bootstrap
{
    /// <summary>
    /// Db configuration.
    /// </summary>
    public static class DbConfigurations
    {
        /// <summary>
        /// Add DbContext.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="configuration">Config.</param>
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
