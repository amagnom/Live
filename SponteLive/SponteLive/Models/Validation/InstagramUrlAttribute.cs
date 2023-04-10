using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SponteLive.Models.Validation
{
    public class InstagramUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var regex = new Regex(@"^(?:https?:\/\/)?(?:www\.)?instagram.com\/[a-zA-Z0-9_\.]*\/?$");
                var match = regex.Match(value.ToString() ?? string.Empty);
                if (!match.Success)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
