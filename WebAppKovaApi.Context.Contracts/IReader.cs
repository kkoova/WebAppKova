namespace WebAppKovaApi.Context.Contracts
{
    /// <summary>
    /// Интерфейс получение записей из запроса
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Предоставляет функциональные возможности для выполнение запросов
        /// </summary>
        IQueryable<IEntity> Read<IEntity>() where IEntity : class;
    }
}
