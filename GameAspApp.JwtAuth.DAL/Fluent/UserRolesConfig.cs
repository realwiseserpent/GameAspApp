using GameAspApp.JwtAuth.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameAspApp.JwtAuth.DAL.Fluent
{
    /// <summary>
    /// Конфигурация миграций для <see cref="UserRoles"/>.
    /// </summary>
    public class UserRolesConfig : IEntityTypeConfiguration<UserRoles>
    {
        /// <summary>
        /// Конфигурирование сущности <see cref="UserRoles"/>.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            builder.BaseEntityWithLinksConfig<UserRoles, User, Role>(
               e => e.UserRoles, e => e.UserRoles);

            builder.ToTable(nameof(UserRoles));
        }
    }
}

