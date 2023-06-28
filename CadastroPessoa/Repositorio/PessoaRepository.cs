using CadastroPessoa.Data;
using CadastroPessoa.Middlewares.Exceptions;
using CadastroPessoa.Models;
using CadastroPessoa.Models.Enuns;
using CadastroPessoa.Models.Pessoas;
using CadastroPessoa.Repositorio.Interfaces;
using CadastroPessoa.Util;
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
                throw new NotFoundException($"Pessoa buscada com ID:{id} não foi encontrada!");
            }

            return pessoa;
        }

        public async Task<List<Pessoa>> BuscarTodasPessoas()
        {
            return await _dbContext.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> Adicionar(Pessoa pessoa)
        {
            pessoa.DataCadastro = DateTime.Now;
            pessoa.Status = Status.ATIVO;
            
            ValidaPessoa(pessoa);

            _dbContext.Pessoas.Add(pessoa);
            await _dbContext.SaveChangesAsync();
            
            return pessoa;
        }

        public async Task<Pessoa> Atualizar(Pessoa pessoa)
        {
            var pessoaBuscada = await BuscarPorID(pessoa.Id);
            pessoaBuscada.Nome = pessoa.Nome;
            pessoaBuscada.CpfOuCnpj = pessoa.CpfOuCnpj;

            _dbContext.Pessoas.Update(pessoaBuscada);
            await _dbContext.SaveChangesAsync();

            return pessoaBuscada;
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

        public void  ValidaPessoa(Pessoa pessoa)
        {
            var listaEnderecoAux = pessoa.Enderecos;
            var quantidadeEncontrada = 0;

            //Verifica se requisição tem tipo de endereço repetido
            foreach (Endereco endereco in pessoa.Enderecos)
            {
                for (int i = 0; i < pessoa.Enderecos.Count; i++)
                {
                    if (endereco.EnderecoTipo.Equals(listaEnderecoAux[i].EnderecoTipo))
                    {
                        quantidadeEncontrada++;            
                    }
                }

                if (quantidadeEncontrada > 1)
                {
                    throw new PessoaNegocioException("Existe tipos de endereço repetidos, só é permitido um endereço de cada tipo: 0 - PRINCIPAL, 1 - COMERCIAL, 2 - COBRANCA");
                }

                quantidadeEncontrada = 0;
            }

            //Verifica se CPF ou CNPJ é válido
            if (!Validacoes.ValidaCPF(pessoa.CpfOuCnpj))
            {
                throw new CpfOuCnpjException("Cpf ou CNPJ inválido!");
            }

        }
 
    }
}
