using AutoMapper;
using CadastroPessoa.Models.DTO;
using CadastroPessoa.Models.Pessoas;

namespace CadastroPessoa.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile() 
        {
            CreateMap<Endereco, EnderecoRequestDTO>();
            CreateMap<EnderecoRequestDTO, Endereco>();
            CreateMap<Endereco, EnderecoResponseDTO>();
            CreateMap<EnderecoResponseDTO, Endereco>();
        }
    }
}
