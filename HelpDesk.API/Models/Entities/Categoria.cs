using System.ComponentModel.DataAnnotations;

namespace HelpDesk.API.Models.Entities
{
    public class Categoria{
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage= "Por favor insira um nome para a catetgoria.")]
        [MaxLength(50)]
        public string Nome {get; set;}

        public List<Chamado> Chamados {get; set;} = new List<Chamado>();
    }
}