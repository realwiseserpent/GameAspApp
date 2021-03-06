using System.Reflection;
using GameAspApp.Common.Swagger;
using GameAspApp.Services.Bootstrap;
using GameAspApp.UnitOfWork.Bootstrap;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GameAspApp.DAL.Bootstrap;
using GameAspApp.JwtAuth.DAL.Bootstrap;
using GameAspApp.JwtAuth.Bootstrap;
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
        /// M���� ���������� ��� ������ ����������. ������������ ��� ����������� �������� � IoC ����������.
        /// </summary>
        /// <param name="services">��������� ��������.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDb(Configuration);
            services.ConfigureAuthDb(Configuration);
            services.ConfigureJwt(Configuration);

            services.ConfigureUnitOfWork();
            services.ConfigureRepositories();
            services.AddControllers();

            services.ConfigureServices();
            services.AddAutoMapper(
                typeof(GameRepository).GetTypeInfo().Assembly,
                typeof(GameController).GetTypeInfo().Assembly,
                typeof(SeriesRepository).GetTypeInfo().Assembly,
                typeof(SeriesController).GetTypeInfo().Assembly,
                typeof(GenreRepository).GetTypeInfo().Assembly,
                typeof(GenreController).GetTypeInfo().Assembly
            );
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
            app.UseSwagger();
            app.ConfigureSwaggerEndpoints();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors();
        }
    }
}
