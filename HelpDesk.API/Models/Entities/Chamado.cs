using System.ComponentModel.DataAnnotations;

namespace HelpDesk.API.Models.Entities
{
    public class Chamado{
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage= "Por favor insira um título ao chamado.")]
        [MaxLength(100)]
        public string title {get; set;}

        [Required(ErrorMessage= "Por favor insira uma descriação ao cahamdo.")]
        [MaxLength(200)]
        public string description {get; set;}

        [Required(ErrorMessage= "Por favor insira um nível de prioridade ao cahamdo.")]
        public string status {get; set;}

        [Required(ErrorMessage= "Por favor insira o nome do solicitante ao cahamdo.")]
        [MaxLength(50)]
        public string requester {get; set;}

        public DateTime startDate {get; set;}
        public DateTime? endDate {get; set;}

        public string? evaluation {get; set;}

        [Required(ErrorMessage= "Por favor insira a categoria do cahamdo.")]
        public string categoria {get; set;}
    }
}