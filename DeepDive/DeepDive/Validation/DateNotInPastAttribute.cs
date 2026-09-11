using System.ComponentModel.DataAnnotations;

namespace DeepDive.Validation
{
    public class DateNotInPastAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value is DateTime date && date.Date < DateTime.Today)
            {
                return new ValidationResult(
                    "Dato fra må ikke være i fortiden.");
            }

            return ValidationResult.Success;
        }
    }
}
