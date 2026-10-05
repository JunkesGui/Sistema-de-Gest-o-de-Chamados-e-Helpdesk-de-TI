using System.ComponentModel.DataAnnotations;

namespace HelpDesk.API.Models.Entities
{
    public class SolucaoDTO
    {
        [Required(ErrorMessage = "A solução é obrigatória para encerrar o chamado.")]
        public string Solucao { get; set; } = string.Empty;
    }
}