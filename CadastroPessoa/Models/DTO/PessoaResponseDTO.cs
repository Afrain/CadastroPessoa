using CadastroPessoa.Models.Enuns;
using CadastroPessoa.Models.Pessoas;

namespace CadastroPessoa.Models.DTO
{
    public class PessoaResponseDTO
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? CpfOuCnpj { get; set; }

        public Status Status { get; set; }

        public DateTime DataCadastro { get; set; }

        public List<EnderecoResponseDTO>? Enderecos { get; set; }
    }
}
