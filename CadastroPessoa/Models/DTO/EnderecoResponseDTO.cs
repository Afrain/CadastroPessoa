using CadastroPessoa.Models.Enuns;

namespace CadastroPessoa.Models.DTO
{
    public class EnderecoResponseDTO
    {
        public int Id { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Complemento { get; set; }
        public string? Cep { get; set; }
        public String? EnderecoTipo { get; set; }
    }
}
