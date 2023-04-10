using System.ComponentModel.DataAnnotations;

namespace SponteLive.Models.Validation
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                var age = DateTime.Today.Year - dateOfBirth.Year;

                if (dateOfBirth > DateTime.Today.AddYears(-age))
                    age--;

                if (age < _minimumAge)
                {
                    return new ValidationResult($"Você deve ter pelo menos {_minimumAge} anos.");
                }
            }

            return ValidationResult.Success;
        }
    }

}
