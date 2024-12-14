using WebApiKovaApi.Common.Abstractions;

namespace WebApiKovaApi.Common
{
    public class DataTimeProvider : IDataTimeProvider
    {
        public DateTimeOffset Now => DateTimeOffset.Now;

        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}
