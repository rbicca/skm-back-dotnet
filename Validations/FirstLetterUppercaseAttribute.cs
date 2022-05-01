using System.ComponentModel.DataAnnotations;

namespace skm_back_dotnet.Validations
{
    public class FirstLetterUppercaseAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
                return ValidationResult.Success;

            var firstLetter = value.ToString()[0].ToString();
            if(firstLetter != firstLetter.ToUpper()){
                return new ValidationResult("A primeira letra tem que ser maiúscula.");
            }

            return ValidationResult.Success;
        }
    }
}