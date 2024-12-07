namespace WebAppKovaApi.PackingListServises.Exceptions
{
    public abstract class SupplierException : Exception
    {
        public SupplierException(string message) 
            : base(message) 
        { }
    }
}
