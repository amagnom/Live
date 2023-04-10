using System.ComponentModel.DataAnnotations;

namespace SponteLive.Models.Validation
{
    public class DateMustBeInFutureAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date && date.Date < DateTime.Today)
            {
                return new ValidationResult("A data deve ser igual ou superior a hoje.");
            }

        
             return ValidationResult.Success;
        }
    }

}