using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GameAspApp.Services.Bootstrap;
using GameAspApp.Services.Services;
using GameAspApp.Common.Swagger;

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
            services.AddControllers();
            services.ConfigureServices();
            services.AddAutoMapper(typeof(GameService).GetTypeInfo().Assembly);
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
