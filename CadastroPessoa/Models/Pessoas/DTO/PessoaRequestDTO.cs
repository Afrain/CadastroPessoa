using System.ComponentModel.DataAnnotations;

namespace CadastroPessoa.Models.Pessoa.DTO
{
    public class PessoaRequestDTO
    {
        /// <summary>
        /// Nome da pessoa
        /// </summary>
        [Required(ErrorMessage = "Nome da pessoa é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo permitido é 100 caracteres!")]
        public string? Nome { get; set; }

        // CPF ou CNPJ da pessoa
        [Required(ErrorMessage = "CpfOuCnpj da pessoa é obrigatório!")]
        [MaxLength(14, ErrorMessage = "O tamanho máximo permitido é 14 caracteres!")]
        [MinLength(11, ErrorMessage = "O tamanho minimo permitido é 11 caracteres!")]
        public string? CpfOuCnpj { get; set; }

    }
}
