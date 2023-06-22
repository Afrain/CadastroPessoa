using AutoMapper;
using CadastroPessoa.Models.DTO;
using CadastroPessoa.Models.Pessoas;
using CadastroPessoa.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoa.Controllers
{
    [Route("api/v1/enderecos")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private IMapper _mapper;

        public EnderecoController(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Endereco>> Salvar([FromBody] EnderecoRequestDTO enderecoRequestDTO) 
        {
            var endereco = _mapper.Map<Endereco>(enderecoRequestDTO);
            var enderecoSalvo = await _enderecoRepository.Adicionar(endereco);
            return Ok(enderecoSalvo);
        }
    }
}
