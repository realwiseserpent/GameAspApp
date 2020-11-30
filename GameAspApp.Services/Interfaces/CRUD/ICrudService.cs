namespace GameAspApp.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса с базовыми CRUD-операциями.
    /// </summary>
    /// <typeparam name="TDto">DTO.</typeparam>
    public interface ICrudService<TDto> :
            ICreatable<TDto>,
            IGettableById<TDto>,
            IGettable<TDto>,
            IUpdatable<TDto>,
            IDeletable
    {
    }
}