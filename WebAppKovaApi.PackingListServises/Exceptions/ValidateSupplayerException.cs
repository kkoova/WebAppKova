namespace WebAppKovaApi.PackingListServises.Exceptions
{
    public class ValidateSupplayerException : SupplierException
    {
        public IEnumerable<(string, string)> Errors { get;set; }

        /// <summary>
        /// ctor
        /// </summary>
        public ValidateSupplayerException(IEnumerable<(string, string)> errors) 
            : base("Ошибка валидации")
        {
            Errors = errors;
        }
    }
}
