using System.ComponentModel.DataAnnotations;
using skm_back_dotnet.Validations;

namespace skm_back_dotnet.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50)]
        [FirstLetterUppercase]
        public string Name { get; set; }

    }
}