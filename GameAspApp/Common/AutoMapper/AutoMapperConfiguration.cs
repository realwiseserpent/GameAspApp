using System.Reflection;
using GameAspApp.DAL.Contexts;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using GameAspApp.Repositories;
using GameAspApp.Controllers;

namespace GameAspApp.Common.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(GameRepository<GameAspAppContext>).GetTypeInfo().Assembly,
                typeof(GameController).GetTypeInfo().Assembly,
                typeof(SeriesRepository<GameAspAppContext>).GetTypeInfo().Assembly,
                typeof(SeriesController).GetTypeInfo().Assembly,
                typeof(GenreRepository<GameAspAppContext>).GetTypeInfo().Assembly,
                typeof(GenreController).GetTypeInfo().Assembly
           );
        }
    }
}
