using CadastroPessoa.Models.Pessoas;

namespace CadastroPessoa.Repositorio.Interfaces
{
    public interface IPessoaRepository
    {
        Task<List<Pessoa>> BuscarTodasPessoas();

        Task<Pessoa> BuscarPorID(int id);

        Task<Pessoa> Adicionar(Pessoa pessoa);

        Task<Pessoa> Atualizar(Pessoa pessoa);

        Task<bool> Apagar(int id);

        Task<Pessoa> AlterarStatus(int id);
    }
}
