namespace CadastroPessoa.Models.DTO
{
    public class EnderecoRequestDTO
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public int PessoaID { get; set; }
    }
}
