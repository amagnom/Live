using SponteLive.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace SponteLive.Models
{
    public class Inscrito
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [MinimumAge(18)]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O endereço do Instagram é obrigatório.")]
        [InstagramUrl]
        [Display(Name = "Instagram")]
        public string InstagramUrl { get; set; }

    }
}
