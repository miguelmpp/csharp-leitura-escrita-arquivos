using System;

namespace GerenciadorArquivos
{
    public class ExtensaoInvalidaException : Exception
    {
        public ExtensaoInvalidaException(string mensagem) : base(mensagem)
        {
        }
    }
}