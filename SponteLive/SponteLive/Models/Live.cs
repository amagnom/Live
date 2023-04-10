using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SponteLive.Models.Validation;

namespace SponteLive.Models
{
    public class Live
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; }

        [ForeignKey("Instrutor")]
        [Display(Name = "Instrutor")]
        [Required(ErrorMessage = "O instrutor é obrigatório.")]
        public int? InstrutorId { get; set; }

        public virtual Instrutor? Instrutor { get; set; }

        [Display(Name = "Data e Hora de Início")]
        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [DateMustBeInFuture(ErrorMessage = "A data deve ser no futuro.")]
        public DateTime DataHoraInicio { get; set; }

        [Required(ErrorMessage = "A duração é obrigatória.")]
        public int DuracaoMinutos { get; set; }

        [Required(ErrorMessage = "O valor da inscrição é obrigatório.")]
        [Range(0, Double.PositiveInfinity, ErrorMessage = "O valor da inscrição deve ser maior ou igual a zero.")]
        public decimal ValorInscricao { get; set; }

        public ICollection<Inscricao>? Inscricoes { get; set; }
    }
}
