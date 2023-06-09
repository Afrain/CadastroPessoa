namespace CadastroPessoa.Models.Pessoas
{
    public class Endereco
    {
        public int Id { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Complemento { get; set;}
        public string? Cep { get; set; }
        public int PessoaID { get; set; }
        public virtual Pessoa? Pessoa { get; set; }

        public Endereco()
        {
        }

        public Endereco(int id, string? logradouro, string? bairro, string? complemento, string? cep, int pessoaID, Pessoa? pessoa)
        {
            Id = id;
            Logradouro = logradouro;
            Bairro = bairro;
            Complemento = complemento;
            Cep = cep;
            PessoaID = pessoaID;
            Pessoa = pessoa;
        }
    }
}
