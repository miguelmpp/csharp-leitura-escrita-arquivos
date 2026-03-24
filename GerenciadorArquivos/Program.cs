using System;
using System.IO;

namespace GerenciadorArquivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GerenciadorArquivo gerenciador = new GerenciadorArquivo();
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE LEITURA E ESCRITA DE ARQUIVOS ===");
                Console.WriteLine("1 - Escrever em arquivo");
                Console.WriteLine("2 - Ler arquivo");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        EscreverArquivo(gerenciador);
                        break;

                    case "2":
                        LerArquivo(gerenciador);
                        break;

                    case "3":
                        continuar = false;
                        Console.WriteLine("Encerrando o sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Pausar();
                        break;
                }
            }
        }

        static void EscreverArquivo(GerenciadorArquivo gerenciador)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== ESCRITA DE ARQUIVO ===");

                Console.Write("Informe o caminho do arquivo (ex: dados.txt): ");
                string caminho = Console.ReadLine();

                Console.Write("Digite o conteúdo que deseja salvar: ");
                string conteudo = Console.ReadLine();

                bool sobrescrever = false;

                if (File.Exists(caminho))
                {
                    Console.Write("O arquivo já existe. Deseja sobrescrever? (S/N): ");
                    string resposta = Console.ReadLine();

                    sobrescrever = resposta.Trim().ToUpper() == "S";
                }

                gerenciador.EscreverArquivo(caminho, conteudo, sobrescrever);
            }
            catch (ExtensaoInvalidaException ex)
            {
                Console.WriteLine($"Erro de validação: {ex.Message}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Erro: acesso negado ao arquivo ou diretório.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Erro: o diretório informado não foi encontrado.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Erro de entrada/saída: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }

            Pausar();
        }

        static void LerArquivo(GerenciadorArquivo gerenciador)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== LEITURA DE ARQUIVO ===");

                Console.Write("Informe o caminho do arquivo (ex: dados.txt): ");
                string caminho = Console.ReadLine();

                string conteudo = gerenciador.LerArquivo(caminho);

                Console.WriteLine("\n=== CONTEÚDO DO ARQUIVO ===");
                Console.WriteLine(conteudo);
            }
            catch (ExtensaoInvalidaException ex)
            {
                Console.WriteLine($"Erro de validação: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Erro: acesso negado ao arquivo.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Erro de leitura: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }

            Pausar();
        }

        static void Pausar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}