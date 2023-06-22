using CadastroPessoa.Data;
using CadastroPessoa.Models;
using CadastroPessoa.Models.Enuns;
using CadastroPessoa.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Repositorio
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly CadastroPessoaDBContext _dbContext;

        public PessoaRepository(CadastroPessoaDBContext cadastroPessoaDBContext)
        {
            _dbContext = cadastroPessoaDBContext;
        }

        public async Task<Pessoa> BuscarPorID(int id)
        {
            var pessoa = await _dbContext.Pessoas.FirstOrDefaultAsync(x => x.Id == id);

            // Lanço uma exceção caso a pessoa não seja encontrada
            if (pessoa == null)
            {
                throw new Exception($"Pessoa buscada com ID:{id} não foi encontrada!");
            }

            return pessoa;
        }

        public async Task<List<Pessoa>> BuscarTodasPessoas()
        {
            return await _dbContext.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> Adicionar(Pessoa pessoa)
        {
            _dbContext.Pessoas.Add(pessoa);
            await _dbContext.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa> Atualizar(Pessoa pessoa)
        {
            var usuarioBuscado = await BuscarPorID(pessoa.Id);
            usuarioBuscado.Nome = pessoa.Nome;
            usuarioBuscado.CpfOuCnpj = pessoa.CpfOuCnpj;

            _dbContext.Pessoas.Update(usuarioBuscado);
            await _dbContext.SaveChangesAsync();

            return usuarioBuscado;
        }

        public async Task<bool> Apagar(int id)
        {
            await BuscarPorID(id);
            _dbContext.Remove(id);
            return true;
        }

        public async Task<Pessoa> AlterarStatus(int id)
        {
            var pessoaBuscada = await BuscarPorID(id);

            if (pessoaBuscada.Status == Status.ATIVO)
                pessoaBuscada.Status = Status.INATIVO;
             else
                pessoaBuscada.Status = Status.ATIVO;
            
            _dbContext.Update(pessoaBuscada);
            await _dbContext.SaveChangesAsync();

            return pessoaBuscada;

        }

     
    }
}
