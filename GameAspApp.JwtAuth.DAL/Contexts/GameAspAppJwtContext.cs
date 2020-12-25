using GameAspApp.JwtAuth.DAL.Domain;
using GameAspApp.JwtAuth.DAL.Fluent;
using Microsoft.EntityFrameworkCore;

namespace GameAspApp.JwtAuth.DAL.Contexts
{
    class GameAspAppJwtContext : DbContext
    {
        /// <summary>
        /// Пользователи.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Роли.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Роли пользователей.
        /// </summary>
        public DbSet<UserRoles> UserRoles { get; set; }

        /// <summary>
        /// Инициализация объекта <see cref="GameAspAppJwtContext"/>.
        /// </summary>
        /// <param name="options">Options of context config.</param>
        public GameAspAppJwtContext(DbContextOptions<GameAspAppJwtContext> options) : base(options)
        {
        }

        /// <summary>
        /// Правила создания сущностей.
        /// </summary>
        /// <param name="builder">Билдер моделей.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserRolesConfig());
        }
    }
}
