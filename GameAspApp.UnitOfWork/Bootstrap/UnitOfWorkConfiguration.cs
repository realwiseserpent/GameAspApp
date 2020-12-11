using Microsoft.Extensions.DependencyInjection;
using GameAspApp.UnitOfWork.Interfaces;
using GameAspApp.DAL.Contexts;

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
            services.AddScoped<IUnitOfWork<GameAspAppContext>, UnitOfWork<GameAspAppContext>>();
        }
    }
}
