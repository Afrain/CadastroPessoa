using AutoMapper;
using CadastroPessoa.Models.Pessoa.DTO;
using CadastroPessoa.Models.Pessoas;

namespace CadastroPessoa.Profiles
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaRequestDTO, Pessoa>();
            CreateMap<Pessoa, PessoaResponseDTO>();
        }
    }
}
