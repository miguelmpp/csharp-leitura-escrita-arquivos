using System;
using System.IO;

namespace GerenciadorArquivos
{
    public class GerenciadorArquivo
    {
        private readonly string[] extensoesPermitidas = { ".txt", ".bat" };

        public void ValidarExtensao(string caminho)
        {
            string extensao = Path.GetExtension(caminho).ToLower();

            foreach (string ext in extensoesPermitidas)
            {
                if (extensao == ext)
                    return;
            }

            throw new ExtensaoInvalidaException(
                "Extensão inválida. Apenas arquivos .txt e .bat são permitidos."
            );
        }

        public void EscreverArquivo(string caminho, string conteudo, bool sobrescrever)
        {
            ValidarExtensao(caminho);

            if (File.Exists(caminho) && !sobrescrever)
            {
                Console.WriteLine("O arquivo já existe e foi preservado.");
                return;
            }

            File.WriteAllText(caminho, conteudo);
            Console.WriteLine("Arquivo gravado com sucesso.");
        }

        public string LerArquivo(string caminho)
        {
            ValidarExtensao(caminho);

            if (!File.Exists(caminho))
                throw new FileNotFoundException("O arquivo informado não foi encontrado.");

            return File.ReadAllText(caminho);
        }
    }
}