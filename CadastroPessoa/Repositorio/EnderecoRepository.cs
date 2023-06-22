using CadastroPessoa.Data;
using CadastroPessoa.Models.Pessoas;
using CadastroPessoa.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Repositorio
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly CadastroPessoaDBContext _dbContext;

        public EnderecoRepository(CadastroPessoaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Endereco> BuscarEnderecoID(int id)
        {
            var enderecoBuscado = await _dbContext.Enderecos.FirstOrDefaultAsync(endereco => endereco.Id == id);
            if (enderecoBuscado == null) 
                throw new Exception($"Pessoa buscada com ID:{id} não foi encontrada!");
            return enderecoBuscado;
        }

        public async Task<Endereco> Adicionar(Endereco endereco)
        {
            endereco.DataCadastro = DateTime.Now;
            _dbContext.Enderecos.Add(endereco);
            await _dbContext.SaveChangesAsync();
            return endereco;
        }

        public async Task<Endereco> Atualizar(Endereco endereco, int id)
        {
            var enderecoBuscado = await BuscarEnderecoID(id);
            enderecoBuscado.Logradouro = endereco.Logradouro;
            enderecoBuscado.Bairro = endereco.Bairro;
            enderecoBuscado.Complemento = endereco.Complemento;
            enderecoBuscado.Cep = endereco.Cep;
            enderecoBuscado.Pessoa = endereco.Pessoa;
            return enderecoBuscado;
        }

        public Task<bool> Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
