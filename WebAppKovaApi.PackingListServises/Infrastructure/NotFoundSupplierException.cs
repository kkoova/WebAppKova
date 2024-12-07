using WebAppKovaApi.PackingListServises.Exception;

namespace WebAppKovaApi.PackingListServises.Infrastructure
{
    public class NotFoundSupplierException : SupplierException
    {
        public NotFoundSupplierException(string message) 
            : base(message)
        {

        }

        public NotFoundSupplierException(Guid entityId)
            : base($"Не удалось найти сущность с идентификатором '{entityId}'")
        {

        }
    }
}
