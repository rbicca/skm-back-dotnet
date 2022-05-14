using System.ComponentModel.DataAnnotations;
using skm_back_dotnet.Validations;

namespace skm_back_dotnet.DTOs
{
    public class GenreCreationDTO
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50)]
        [FirstLetterUppercase]
        public string Name { get; set; }

    }
}