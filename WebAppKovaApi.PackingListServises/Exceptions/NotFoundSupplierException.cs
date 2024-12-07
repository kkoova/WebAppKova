namespace WebAppKovaApi.PackingListServises.Exceptions
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
