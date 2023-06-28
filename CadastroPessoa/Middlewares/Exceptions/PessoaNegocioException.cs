namespace CadastroPessoa.Middlewares.Exceptions
{
    public class PessoaNegocioException : Exception
    {
        public PessoaNegocioException(string? message) : base(message)
        {
        }
    }
}
