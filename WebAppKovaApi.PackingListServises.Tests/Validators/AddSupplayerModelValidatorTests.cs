using FluentValidation.TestHelper;
using WebAppKovaApi.PackingListServises.Contracts.Models;
using WebAppKovaApi.PackingListServises.Contracts.Validators;
using Xunit;

namespace WebAppKovaApi.PackingListServises.Tests.Validators
{
    /// <summary>
    /// Теыты для <see cref="AddSupplayerModelValidator"/>
    /// </summary>
    public class AddSupplayerModelValidatorTests
    {
        private readonly AddSupplayerModelValidator validator = new();

        /// <summary>
        /// Провкляект наличие ошибок
        /// </summary>
        [Fact]
        public void ShoyldHaveError()
        {
            // Arrange
            var model = new AddSupplierModel
            {
                Name = string.Empty,
                Description = new string('%', 500),
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(person => person.Name);
            result.ShouldHaveValidationErrorFor(person => person.Description);
        }

        /// <summary>
        /// Провкляект наличие ошибок для короткого Name
        /// </summary>
        [Fact]
        public void ShoyldHaveErrorForShortName()
        {
            // Arrange
            var model = new AddSupplierModel
            {
                Name = "H",
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(person => person.Name);
        }

        /// <summary>
        /// Провкляект наличие ошибок для длинного Name
        /// </summary>
        [Fact]
        public void ShoyldHaveErrorForLongName()
        {
            // Arrange
            var model = new AddSupplierModel
            {
                Name = new string('%', 500),
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(person => person.Name);
        }

        /// <summary>
        /// Провкляект отсутсвие ошибок 
        /// </summary>
        [Fact]
        public void ShoyldNotHaveError()
        {
            // Arrange
            var model = new AddSupplierModel
            {
                Name = "Test",
                Description = "Test",
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(person => person.Name);
            result.ShouldNotHaveValidationErrorFor(person => person.Description);
        }
    }
}
