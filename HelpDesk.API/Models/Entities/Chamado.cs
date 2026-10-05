namespace DeskFlow.API.Models.Entities
{
    public class Chamado{
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage= "Por favor insira um título ao chamado.")]
        [MaxLenght(100)]
        public string title {get; set;}

        [Required(ErrorMessage= "Por favor insira uma descriação ao cahamdo.")]
        [MaxLenght(200)]
        public string description {get; set;}

        [Required(ErrorMessage= "Por favor insira um nível de prioridade ao cahamdo.")]
        public string status {get; set;}

        [Required(ErrorMessage= "Por favor insira o nome do solicitante ao cahamdo.")]
        [MaxLenght(50)]
        public string requester {get; set;}

        public DateTime startDate {get; set;}
        public DateTime? endDate {get; set;}

        public string? evaluation {get; set;}

        [Required(ErrorMessage= "Por favor insira a categoria do cahamdo.")]
        public string categoria {get; set;}
    }
}