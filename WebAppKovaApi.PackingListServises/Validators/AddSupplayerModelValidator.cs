using FluentValidation;
using WebAppKovaApi.PackingListServises.Contracts.Models;

namespace WebAppKovaApi.PackingListServises.Contracts.Validators
{
    /// <summary>
    /// 
    /// </summary>
    public class AddSupplayerModelValidator : AbstractValidator<AddSupplierModel>
    {
        private const int MaxDataBaseString = 255;
        private const int MinDataBaseString = 3;
        /// <summary>
        /// ctr
        /// </summary>
        public AddSupplayerModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(MinDataBaseString, MaxDataBaseString);
            RuleFor(x => x.Description).MaximumLength(MaxDataBaseString);
        }
    }
}
