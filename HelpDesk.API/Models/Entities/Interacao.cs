using System.ComponentModel.DataAnnotations;

namespace HelpDesk.API.Models.Entities
{
    public class Interacao
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Insira o autor da interação.")]
        [MaxLength(50)]
        public string Autor { get; set; }
        
        [Required(ErrorMessage = "Insira uma mensagem para a interação.")]
        [MaxLength(200, ErrorMessage = "A mensagem não pode exceder 200 caracteres.")]
        public string Mensagem { get; set; }
        public DateTime DataRegistro { get; set; }

        public int ChamadoId { get; set; }
        public Chamado? Chamado { get; set; }
    }
}