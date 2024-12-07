namespace WebAppKovaApi.PackingListServises.Contracts
{
    /// <summary>
    /// Валидация моделей сервиса
    /// </summary>
    public class ISupplierValidationServise
    {
        /// <summary>
        /// Валидирует модаль <see cref="TModel"/>
        /// </summary>
        void Validate<TModel>(TModel model);
    }
}
