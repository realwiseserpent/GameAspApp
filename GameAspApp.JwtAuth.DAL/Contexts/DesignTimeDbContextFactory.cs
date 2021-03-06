﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace GameAspApp.JwtAuth.DAL.Contexts
{
    /// <summary>
    /// Фабрика для создания нового контекста в процессе миграций.
    /// </summary>
    internal sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GameAspAppJwtContext>
    {
        /// <summary>
        /// Создание контекста для миграций.
        /// </summary>
        /// <param name="args">Строковые аргументы миграций.</param>
        /// <returns>Контекст.</returns>
        public GameAspAppJwtContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json", false, true)
                               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                                        true, true)
                               .AddEnvironmentVariables()
                               .Build();

            var connectionString = configuration.GetConnectionString(nameof(GameAspAppJwtContext));

            var builder = new DbContextOptionsBuilder<GameAspAppJwtContext>()
                   .UseNpgsql(connectionString, __options =>
                   {
                       __options.MigrationsAssembly(typeof(GameAspAppJwtContext).Assembly.FullName);
                   });

            var context = new GameAspAppJwtContext(builder.Options);

            return context;
        }
    }
}

