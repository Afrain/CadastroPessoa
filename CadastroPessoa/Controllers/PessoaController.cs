using CadastroPessoa.Models.Enuns;
using CadastroPessoa.Models.Pessoas;
using CadastroPessoa.Models.Pessoa.DTO;
using CadastroPessoa.Repositorio.Interfaces;
using CadastroPessoa.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoa.Controllers
{
    [Route("api/v1/pessoas")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly IPessoaRepository _pessoaRepository;
        private PessoaServices _pessoaServices;

        public PessoaController(IPessoaRepository iPessoaReporitory)
        {
            _pessoaRepository = iPessoaReporitory;
            _pessoaServices = new PessoaServices();
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
        public async Task<ActionResult<List<Pessoa>>> BuscarTodasPessoas([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            var listaPessoas = await _pessoaRepository.BuscarTodasPessoas();
            return Ok(listaPessoas.Skip(skip).Take(take));
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
        public async Task<ActionResult<Pessoa>> BuscarPessoaId(int id)
        {
            var pessoa = await _pessoaRepository.BuscarPorID(id);
            return Ok(pessoa);
        }

        /// <summary>
        /// Adiciona uma pessoa ao banco de dados
        /// </summary>
        /// <param name="pessoaRequestDTO">Objeto com os campos necessários para criação de uma pessoa</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Pessoa>> Cadastrar([FromBody] PessoaRequestDTO pessoaRequestDTO)
        {
            var pessoa = _pessoaServices.ConverteDTOParaObjeto(pessoaRequestDTO);
            pessoa.DataCadastro = DateTime.Now;
            pessoa.Status = Status.ATIVO;

            var pessoaSalva = await _pessoaRepository.Adicionar(pessoa);
            return CreatedAtAction(nameof(BuscarPessoaId), new { id = pessoaSalva.Id }, pessoaSalva);
        }

        /// <summary>
        /// Atualizar uma pessoa no banco de dados
        /// </summary>
        /// <param name="id">ID da pessoa que será atualizada no banco de dados</param>
        /// <param name="pessoaRequestDTO">Objeto com os campos necessários para a atualização de uma pessoa</param>
        /// <returns>ActionResult</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Pessoa>> Atualizar([FromBody] PessoaRequestDTO pessoaRequestDTO, int id)
        {
            var pessoa = _pessoaServices.ConverteDTOParaObjeto(pessoaRequestDTO);

            var pessoaBuscada = await _pessoaRepository.BuscarPorID(id);
            pessoaBuscada.Nome = pessoa.Nome;
            pessoaBuscada.CpfOuCnpj = pessoa.CpfOuCnpj;

            var pessoaAtualizada = await _pessoaRepository.Atualizar(pessoaBuscada);

            return Ok(pessoaAtualizada);
        }

        /// <summary>
        /// Excluir uma pessoa no banco de dados
        /// </summary>
        /// <param name="id">ID da pessoa que será excluida no banco de dados</param>
        /// <returns>ActionResult</returns>
        [HttpDelete("{id}")]
        public ActionResult<Boolean> Excluir(int id)
        {
            var exluiu = _pessoaRepository.Apagar(id);
            return Ok(exluiu);
        }

        [HttpPut("{id}/alterarStatus")]
        public async Task<ActionResult<Pessoa>> AlterarStatus(int id)
        {
            var pessoaAtualizada = await _pessoaRepository.AlterarStatus(id);
            return Ok(pessoaAtualizada);
        }
    }
}
