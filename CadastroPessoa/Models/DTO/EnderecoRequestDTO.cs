using CadastroPessoa.Models.Enuns;
using System.ComponentModel.DataAnnotations;

namespace CadastroPessoa.Models.DTO
{
    public class EnderecoRequestDTO
    {
        [Required(ErrorMessage = "Logradouro é obrigatório!")]
        public string? Logradouro { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório!")]
        public string? Bairro { get; set; }
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Cep é obrigatório!")]
        public string? Cep { get; set; }

        [Required(ErrorMessage = "Tipo é obrigatório!")]
        public EnderecoTipo EnderecoTipo { get; set; }
    }
}
