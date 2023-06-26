using CadastroPessoa.Models.Enuns;
using CadastroPessoa.Repositorio.Interfaces;
using CadastroPessoa.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CadastroPessoa.Models.DTO;
using CadastroPessoa.Models;
using CadastroPessoa.Models.Pessoas;

namespace CadastroPessoa.Controllers
{
    [Route("api/v1/pessoas")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaRepository iPessoaReporitory, IMapper iMapper, IEnderecoRepository enderecoRepository)
        {
            _pessoaRepository = iPessoaReporitory;
            _mapper = iMapper;
        }

        /// <summary>
        /// Retorna todas as pessoas cadastradas
        /// </summary>
        /// <param name="skip">Número da página para retornar</param>
        /// <param name="take">Retornar quantas pessoas por página</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso o retorno de uma lista de pessoa seja feita com sucesso</response>
        /// <remarks>
        /// INFORMAÇÃO
        /// 1. Por padrão só é retornado 20 pessoas por requisição
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PessoaResponseDTO>>> BuscarTodasPessoas([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            var listaPessoas = await _pessoaRepository.BuscarTodasPessoas();
            var listaPessoasDTO = _mapper.Map<List<PessoaResponseDTO>>(listaPessoas);
            return Ok(listaPessoasDTO.Skip(skip).Take(take));
        }

        /// <summary>
        /// Busca uma pessoa no banco de dados pelo ID
        /// </summary>
        /// <param name="id">Código da pessoa</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>
        /// <remarks>
        /// Código é obrigatório
        /// </remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PessoaResponseDTO>> BuscarPessoaId(int id)
        {
            var pessoa = await _pessoaRepository.BuscarPorID(id);
            var pessoaResponseDTO = _mapper.Map<PessoaResponseDTO>(pessoa);
            return Ok(pessoaResponseDTO);
        }

        /// <summary>
        /// Adiciona uma pessoa ao banco de dados
        /// </summary>
        /// <param name="pessoaRequestDTO">Objeto com os campos necessários para criação de uma pessoa</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PessoaResponseDTO>> Cadastrar([FromBody] PessoaRequestDTO pessoaRequestDTO)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaRequestDTO);
            pessoa.DataCadastro = DateTime.Now;
            pessoa.Status = Status.ATIVO;

            var pessoaSalva = await _pessoaRepository.Adicionar(pessoa);

            var pessoaResponseDTO = _mapper.Map<PessoaResponseDTO>(pessoaSalva);

            return CreatedAtAction(nameof(BuscarPessoaId), new { id = pessoaResponseDTO.Id }, pessoaResponseDTO);
        }

        /// <summary>
        /// Atualizar uma pessoa no banco de dados
        /// </summary>
        /// <param name="id">ID da pessoa que será atualizada no banco de dados</param>
        /// <param name="pessoaRequestDTO">Objeto com os campos necessários para a atualização de uma pessoa</param>
        /// <returns>ActionResult</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<PessoaResponseDTO>> Atualizar([FromBody] PessoaRequestDTO pessoaRequestDTO, int id)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaRequestDTO);

            var pessoaBuscada = await _pessoaRepository.BuscarPorID(id);
            pessoaBuscada.Nome = pessoa.Nome;
            pessoaBuscada.CpfOuCnpj = pessoa.CpfOuCnpj;

            var pessoaAtualizada = await _pessoaRepository.Atualizar(pessoaBuscada);

            var pessoaResponseDTO = _mapper.Map<PessoaResponseDTO>(pessoaAtualizada);

            return StatusCode(StatusCodes.Status200OK, pessoaResponseDTO);
        }

        /// <summary>
        /// Excluir uma pessoa no banco de dados
        /// </summary>
        /// <param name="id">ID da pessoa que será excluida no banco de dados</param>
        /// <returns>True caso a exclusão seja feita com sucesso</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Boolean> Excluir(int id)
        {
            var excluiu = _pessoaRepository.Apagar(id);
            return StatusCode(StatusCodes.Status204NoContent, excluiu);
        }

        /// <summary>
        /// Atualizar status da pessoa
        /// </summary>
        /// <param name="id">ID da pessoa que será atualizada o status no banco de dados</param>
        /// <returns>True caso a exclusão seja feita com sucesso</returns>
        [HttpPut("{id}/alterarStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<PessoaResponseDTO>> AlterarStatus(int id)
        {
            var pessoaAtualizada = await _pessoaRepository.AlterarStatus(id);

            var pessoaResponseDTO = _mapper.Map<PessoaResponseDTO>(pessoaAtualizada);

            return StatusCode(StatusCodes.Status204NoContent, pessoaResponseDTO);
        }
    }
}
