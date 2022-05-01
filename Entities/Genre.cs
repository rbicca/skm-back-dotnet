using System.ComponentModel.DataAnnotations;
using skm_back_dotnet.Validations;

namespace skm_back_dotnet.Entities
{
    public class Genre: IValidatableObject      //Validador geral do modelo, onde combina propriedades
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20)]
        //[FirstLetterUppercase]      //Validador customizado - 1 por propriedade
        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name)){
                var firsLetter = Name[0].ToString();
                if(firsLetter != firsLetter.ToUpper()){
                    yield return new ValidationResult("A primeira letra tem que ser maiúscula", new string[]{nameof(Name)});
                }
            }
        }
    }
}