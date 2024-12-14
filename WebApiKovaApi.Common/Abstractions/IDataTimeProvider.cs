namespace WebApiKovaApi.Common.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataTimeProvider
    {
        DateTimeOffset Now { get; }

        DateTimeOffset UtcNow { get; }
    }
}
