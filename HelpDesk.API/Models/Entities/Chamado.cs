using System.ComponentModel.DataAnnotations;

namespace HelpDesk.API.Models.Entities
{
    public class Chamado{
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage= "Por favor insira um título ao chamado.")]
        [MaxLength(100)]
        public string Titulo {get; set;}

        [Required(ErrorMessage= "Por favor insira uma descriação ao cahamdo.")]
        [MaxLength(200)]
        public string Descricao {get; set;}

        [Required(ErrorMessage= "Por favor insira um nível de prioridade ao cahamdo.")]
        public PrioridadeEnum Prioridade {get; set;}

        [Required(ErrorMessage= "Por favor insira um status ao cahamdo.")]
        public StatusEnum Status {get; set;}

        [Required(ErrorMessage= "Por favor insira o nome do solicitante ao cahamdo.")]
        [MaxLength(50)]
        public string SolicitanteNome {get; set;}

        public DateTime DataAbertura {get; set;}
        public DateTime? DataFechamento {get; set;}

        public string? Solucao {get; set;}

        public int CategoriaId {get; set;}

        public Categoria? Categoria {get; set;}

        public List<Interacao> Interacoes {get; set;} = new List<Interacao>();
    }
}