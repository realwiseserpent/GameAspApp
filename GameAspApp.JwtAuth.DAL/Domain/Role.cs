using System.Collections.Generic;

namespace GameAspApp.JwtAuth.DAL.Domain
{
    /// <summary>
    /// Роль.
    /// </summary>
    public class Role : BaseEntity
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип роли.
        /// </summary>
        public string RoleType { get; set; }

        /// <summary>
        /// Роли пользователей.
        /// </summary>
        public ICollection<UserRoles> UserRoles { get; set; }
    }

}
