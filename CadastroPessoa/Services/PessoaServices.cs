using CadastroPessoa.Models.DTO;
using CadastroPessoa.Models;

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
