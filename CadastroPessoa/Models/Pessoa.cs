using CadastroPessoa.Middlewares.Exceptions;
using CadastroPessoa.Models.Enuns;
using CadastroPessoa.Models.Pessoas;
using CadastroPessoa.Util;

namespace CadastroPessoa.Models
{
    public class Pessoa : EntidadeGenerica
    {
        public string? Nome { get; set; }
        public string? CpfOuCnpj { get; set; }
        public Status Status { get; set; }
        public virtual List<Endereco> Enderecos { get; set; }

        private Validacoes Validacoes;

        public Pessoa()
        {
        }

        public Pessoa(string? nome, string? cpfOuCnpj, Status status, Validacoes validacoes)
        {
            Nome = nome;
            CpfOuCnpj = cpfOuCnpj;
            Status = status;
            Validacoes = validacoes;
        }
    }
}
