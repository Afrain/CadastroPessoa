using CadastroPessoa.Models.Pessoas;
using CadastroPessoa.Models.Pessoa.DTO;

namespace CadastroPessoa.Services
{
    public class PessoaServices
    {
        public Pessoa ConverteDTOParaObjeto(PessoaRequestDTO pessoaRequestDTO)
        {
            return new Pessoa
            {
                Nome = pessoaRequestDTO.Nome,
                CpfOuCnpj = pessoaRequestDTO.CpfOuCnpj
            };
        }
    }
}
