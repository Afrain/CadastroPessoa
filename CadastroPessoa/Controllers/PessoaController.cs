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

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> BuscarTodasPessoas([FromQuery] int skip = 0, [FromQuery] int take = 5)
        {
            var listaPessoas = await _pessoaRepository.BuscarTodasPessoas();
            return Ok(listaPessoas.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> BuscarPessoaId(int id)
        {
            var pessoa = await _pessoaRepository.BuscarPorID(id);
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> Cadastrar([FromBody] PessoaRequestDTO pessoaRequestDTO)
        {
            var pessoa = _pessoaServices.ConverteDTOParaObjeto(pessoaRequestDTO);
            pessoa.DataCadastro = DateTime.Now;
            pessoa.Status = Status.ATIVO;

            var pessoaSalva = await _pessoaRepository.Adicionar(pessoa);
            return CreatedAtAction(nameof(BuscarPessoaId), new { id = pessoaSalva.Id }, pessoaSalva);
        }

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
