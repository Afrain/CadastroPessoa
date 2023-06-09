using CadastroPessoa.Models.Enuns;

namespace CadastroPessoa.Models.Pessoas
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
