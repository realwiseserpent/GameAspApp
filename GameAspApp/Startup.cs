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
        /// M���� ���������� ��� ������ ����������. ������������ ��� ����������� �������� � IoC ����������.
        /// </summary>
        /// <param name="services">��������� ��������.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureServices();
            services.AddAutoMapper(typeof(GameService).GetTypeInfo().Assembly);
            services.ConfigureSwagger();

        }

        /// <summary>
        /// M���� ���������� ��� ������ ����������. ������������ ��� ������������ ��������� ��� ��������� HTTP �������.
        /// </summary>
        /// <param name="app">�������� ������������ ����������.</param>
        /// <param name="env">���������� �� ���������, � ������� �������� ����������.</param>
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
