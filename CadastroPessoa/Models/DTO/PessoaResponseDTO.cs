using CadastroPessoa.Models.Enuns;

namespace CadastroPessoa.Models.DTO
{
    public class PessoaResponseDTO
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? CpfOuCnpj { get; set; }

        public Status Status { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
