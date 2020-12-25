using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using GameAspApp.JwtAuth.Interfaces;

namespace GameAspApp.JwtAuth
{
    /// <summary>
    /// Автономная служба удаления истекших RT.
    /// </summary>
    public class JwtRefreshTokenCache : IHostedService, IDisposable
    {
        /// <summary>
        /// DI таймера.
        /// </summary>
        private Timer _timer;
        /// <summary>
        /// DI менеджера токенов.
        /// </summary>
        private readonly IJwtAuthManager _jwtAuthManager;

        /// <summary>
        /// Инициализирует экземпляр <see cref="JwtRefreshTokenCache"/>.
        /// </summary>
        /// <param name="jwtAuthManager"><see cref="IJwtAuthManager"/></param>
        public JwtRefreshTokenCache(IJwtAuthManager jwtAuthManager)
        {
            _jwtAuthManager = jwtAuthManager;
        }

        /// <summary>
        /// Запуск удаления истекших RT.
        /// </summary>
        /// <param name="stoppingToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken stoppingToken)
        {
            // remove expired refresh tokens from cache every minute
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        /// <summary>
        /// Удаление истекших RT.
        /// </summary>
        private void DoWork(object state)
        {
            _jwtAuthManager.RemoveExpiredRefreshTokens(DateTime.Now);
        }

        /// <summary>
        /// Остановка удаления истекших RT.
        /// </summary>
        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Очистка ресурсов таймера.
        /// </summary>
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
