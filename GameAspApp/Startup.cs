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
using GameAspApp.Common.AutoMapper;

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
        /// Måòîä âûçûâàåòñÿ äëÿ ñðåäîé èñïîëíåíèÿ. Èñïîëüçóåòñÿ äëÿ ðåãèñòðàöèè ñåðâèñîâ â IoC êîíòåéíåðå.
        /// </summary>
        /// <param name="services">Êîëëåêöèÿ ñåðâèñîâ.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDb(Configuration);
            services.ConfigureAuthDb(Configuration);
            services.ConfigureJwt(Configuration);

            services.ConfigureUnitOfWork();
            services.ConfigureRepositories();
            services.AddControllers();

            services.ConfigureServices();
            services.ConfigureAutoMapper();
            services.ConfigureSwagger();
        }

        /// <summary>
        /// Måòîä âûçûâàåòñÿ äëÿ ñðåäîé èñïîëíåíèÿ. Èñïîëüçóåòñÿ äëÿ êîíôèãóðàöèè îêðóæåíèÿ äëÿ îáðàáîòêè HTTP çàïðîñà.
        /// </summary>
        /// <param name="app">Ñðåäñòâî êîíôèãóðàöèè ïðèëîæåíèÿ.</param>
        /// <param name="env">Èíôîðìàöèÿ îá îêðóæåíèè, â êîòîðîì ðàáîòàåò ïðèëîæåíèå.</param>
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
