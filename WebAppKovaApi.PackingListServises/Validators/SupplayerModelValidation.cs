using FluentValidation;
using WebAppKovaApi.PackingListServises.Contracts.Models;
using WebAppKovaApi.PackingListServises.Contracts.Validators;

namespace WebAppKovaApi.PackingListServises.Validators
{
    /// <summary>
    /// Валидатор для <see cref="SupplierModel"/>
    /// </summary>
    public class SupplayerModelValidation : AbstractValidator<SupplierModel>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public SupplayerModelValidation()
        {
            Include(new AddSupplayerModelValidator());
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
