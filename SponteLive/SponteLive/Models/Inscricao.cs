using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SponteLive.Models
{
    public class Inscricao
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A Live é obrigatória.")]
        public int? LiveId { get; set; }

        [ForeignKey("LiveId")]
        public virtual Live? Live { get; set; }

        [Required(ErrorMessage = "O Inscrito é obrigatório.")]
        public int? InscritoId { get; set; }

        [ForeignKey("InscritoId")]
        public virtual Inscrito? Inscrito { get; set; }

        [Required(ErrorMessage = "O Valor da Inscrição é obrigatório.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A Data de Vencimento é obrigatória.")]
        public DateTime DataVencimento { get; set; }

        [Required(ErrorMessage = "O Status de Pagamento é obrigatório.")]
        public bool StatusPagamento { get; set; }

    }
}
