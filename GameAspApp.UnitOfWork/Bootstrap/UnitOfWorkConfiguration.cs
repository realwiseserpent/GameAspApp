using Microsoft.Extensions.DependencyInjection;

namespace GameAspApp.UnitOfWork.Bootstrap
{
    /// <summary>
    /// Методы расширения для конфигурации сервисов.
    /// </summary>
    public static class UnitOfWorkConfiguration
    {
        /// <summary>
        /// Конфигурация Unit of Work.
        /// </summary>
        /// <param name="services">Коллекция сервисов из Startup.</param>
        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
