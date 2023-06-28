namespace CadastroPessoa.Middlewares.Exceptions
{
    public class CpfOuCnpjException : Exception
    {
        public CpfOuCnpjException(string mensagem) : base(mensagem) 
        {
        }
        
    }
}
