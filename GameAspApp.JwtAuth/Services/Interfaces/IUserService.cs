namespace GameAspApp.JwtAuth.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с пользователями.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Проверка существования пользователя.
        /// </summary>
        bool IsAnExistingUser(string userName);

        /// <summary>
        /// Проверка данных пользователя.
        /// </summary>
        bool IsValidUserCredentials(string userName, string password);

        /// <summary>
        /// Получение роли пользователя.
        /// </summary>
        string GetUserRole(string userName);
    }
}
