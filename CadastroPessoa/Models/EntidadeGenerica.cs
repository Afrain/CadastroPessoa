using System.ComponentModel.DataAnnotations;

namespace CadastroPessoa.Models
{
    public abstract class EntidadeGenerica : Entidade
    {
        [Required(ErrorMessage = "Data de cadastro é obrigatório!")]
        public DateTime DataCadastro { get; set; }
    }
}
