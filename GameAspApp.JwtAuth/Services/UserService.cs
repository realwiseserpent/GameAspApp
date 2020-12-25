using GameAspApp.JwtAuth.DAL.Contexts;
using GameAspApp.JwtAuth.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace GameAspApp.JwtAuth.Services
{
    /// <summary>
    /// Сервис работы с пользователями.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// DI логгера.
        /// </summary>
        private readonly ILogger<UserService> _logger;
        /// <summary>
        /// DI контекста БД.
        /// </summary>
        private readonly GameAspAppJwtContext _jwtContext;

        /// <summary>
        /// Инициализирует экземпляр <see cref="UserService"/>.
        /// </summary>
        /// <param name="logger">Логгер.</param>
        /// <param name="context">Контекст БД.</param>
        public UserService(ILogger<UserService> logger, GameAspAppJwtContext context)
        {
            _logger = logger;
            _jwtContext = context;
        }

        /// <inheritdoc cref="IUserService.IsValidUserCredentials(string, string)"/>
        public bool IsValidUserCredentials(string userName, string password)
        {
            _logger.LogInformation($"Validating user [{userName}]");
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return _jwtContext.Users.Any(x => x.Login == userName && x.Password == password);
        }

        /// <inheritdoc cref="IUserService.IsAnExistingUser(string)"/>
        public bool IsAnExistingUser(string userName)
        {
            return _jwtContext.Users.Any(x => x.Login == userName);
        }

        /// <inheritdoc cref="IUserService.GetUserRole(string)"/>
        public string GetUserRole(string userName)
        {
            if (!IsAnExistingUser(userName))
            {
                return string.Empty;
            }

            var role = _jwtContext.UserRoles
                .Include(x => x.Entity1)
                .Include(x => x.Entity2)
                .SingleOrDefault(x => x.Entity1.Login == userName).Entity2?.Name;

            if (string.IsNullOrEmpty(role))
                throw new ArgumentNullException("Can't find role.");

            return role;
        }
    }
}
