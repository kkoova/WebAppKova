using FluentValidation;
using WebAppKovaApi.PackingListServises.Contracts;
using WebAppKovaApi.PackingListServises.Contracts.Models;
using WebAppKovaApi.PackingListServises.Contracts.Validators;
using WebAppKovaApi.PackingListServises.Exceptions;
using WebAppKovaApi.PackingListServises.Validators;

namespace WebAppKovaApi.PackingListServises
{
    /// <summary>
    /// 
    /// </summary>
    public class SupplierValidationServise : ISupplierValidationServise
    {
        private readonly Dictionary<Type, IValidator> validators = new();

        /// <summary>
        /// ctor
        /// </summary>
        public SupplierValidationServise()
        {
            validators.Add(typeof(SupplierModel), new SupplayerModelValidation());
            validators.Add(typeof(AddSupplierModel), new AddSupplayerModelValidator());
        }
        public void Validate<TModel>(TModel model)
        {
            var modeltype = typeof(TModel);
            if (validators.TryGetValue(modeltype, out var validator))
            {
                var context = new ValidationContext<TModel>(model);
                var validarotResult = validator.Validate(context);

                if (!validarotResult.IsValid)
                {
                    throw new ValidateSupplayerException(validarotResult.Errors.Select(x =>
                        (x.PropertyName, x.ErrorMessage)));
                }
            }
            else
            {
                throw new OperationSupplierException($"Не удалось найти валидатор для типа {modeltype}");
            }
        }
    }
}
