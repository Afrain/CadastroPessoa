using AutoMapper;
using CadastroPessoa.Models;
using CadastroPessoa.Models.DTO;

namespace CadastroPessoa.Profiles
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaRequestDTO, Pessoa>();
            CreateMap<Pessoa, PessoaResponseDTO>()
                .ForMember(pessoaResponseDTO => pessoaResponseDTO.Enderecos,
                            opt => opt.MapFrom(pessoa => pessoa.Enderecos));
        }
    }
}
