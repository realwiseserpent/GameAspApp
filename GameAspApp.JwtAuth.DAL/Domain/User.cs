using System.Collections.Generic;

namespace GameAspApp.JwtAuth.DAL.Domain
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Роли пользователя.
        /// </summary>
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
