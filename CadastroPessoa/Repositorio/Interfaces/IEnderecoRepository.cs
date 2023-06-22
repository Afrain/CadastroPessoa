using CadastroPessoa.Models.Pessoas;

namespace CadastroPessoa.Repositorio.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco> BuscarEnderecoID(int id);
        Task<Endereco> Adicionar(Endereco endereco);
        Task<Endereco> Atualizar(Endereco endereco, int id);
        Task<bool> Excluir(int id);
    }
}
