using CadastroPessoa.Models.Enuns;
using CadastroPessoa.Models.Pessoas;

namespace CadastroPessoa.Models
{
    public class Pessoa : EntidadeGenerica
    {
        public string? Nome { get; set; }
        public string? CpfOuCnpj { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(string? nome, string? cpfOuCnpj, Status status)
        {
            Nome = nome;
            CpfOuCnpj = cpfOuCnpj;
            Status = status;
        }
    }
}
