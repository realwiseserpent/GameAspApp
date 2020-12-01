using System.Reflection;
using GameAspApp.Common.Swagger;
using GameAspApp.Services.Bootstrap;
using GameAspApp.Services.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GameAspApp.DAL.Bootstrap;
using GameAspApp.Repositories.Bootstrap;
using GameAspApp.Repositories;
using GameAspApp.Controllers;

namespace GameAspApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Mетод вызывается для средой исполнения. Используется для регистрации сервисов в IoC контейнере.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDb(Configuration);
            services.ConfigureRepositories();
            services.AddControllers();
            services.ConfigureServices();
            services.AddAutoMapper(
                typeof(GameRepository).GetTypeInfo().Assembly,
                typeof(GameController).GetTypeInfo().Assembly,
                typeof(SeriesRepository).GetTypeInfo().Assembly,
                typeof(SeriesController).GetTypeInfo().Assembly,
                typeof(GameGenreRepository).GetTypeInfo().Assembly,
                typeof(GameGenreController).GetTypeInfo().Assembly,
                typeof(GenreRepository).GetTypeInfo().Assembly,
                typeof(GenreController).GetTypeInfo().Assembly
            );
            services.ConfigureSwagger();

        }

        /// <summary>
        /// Mетод вызывается для средой исполнения. Используется для конфигурации окружения для обработки HTTP запроса.
        /// </summary>
        /// <param name="app">Средство конфигурации приложения.</param>
        /// <param name="env">Информация об окружении, в котором работает приложение.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors();
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
