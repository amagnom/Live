using SponteLive.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace SponteLive.Models
{
    public class Instrutor
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [MinimumAge(18)]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O endereço do Instagram é obrigatório.")]
        [InstagramUrl]
        [Display(Name = "Instagram")]
        public string InstagramUrl { get; set; }

        public ICollection<Live>? Lives { get; set; }
    }
}
