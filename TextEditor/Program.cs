using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer: ");
            Console.WriteLine("1 - Criar um arquivo");
            Console.WriteLine("2 - Abrir e editar um arquivo");
            Console.WriteLine("3 - Deletar um arquivo");
            Console.WriteLine("4 - Fechar programa");
            short userOption = short.Parse(Console.ReadLine());

            switch (userOption)
            {
                case 1: Criar(); break;
                case 2: Abrir(); break;
                case 3: Apagar(); break;
                case 4: System.Environment.Exit(0); break;
                default: Console.WriteLine("Opção Inexistente"); break;

            }
        }
        static void Criar() 
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para SAIR) ");
            Console.WriteLine("-------------------------");

            string userText = "";

            do //Faz sempre o bloco abaixo
            {
                userText += Console.ReadLine();
                userText += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);//Enquanto essa condição não for satisfeita  
            {

            }

            Salvar(userText);
        }

        static void Abrir() {

            var path = "c:\\dev\\EditorTexto\\ArquivosDeTexto\\";

            try
            {
                if (Directory.Exists(path))
                {
                    string[] arquivos = Directory.GetFiles(path);
                    Console.WriteLine("Arquivos no diretório: ");
                    foreach (string arquivo in arquivos)
                    {
                        Console.WriteLine(arquivo);
                    }
                    Console.WriteLine("Cheguei aqui");
                }
                else
                {
                    Console.WriteLine("O diretório não existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        static void Apagar() { }

        static void Salvar(string text)
        {
            Console.Clear();
            var path = "c:\\dev\\EditorTexto\\ArquivosDeTexto\\";
            var extensaoArquivo = ".txt";
            Console.WriteLine("Digite o nome do arquivo: ");
            var nomeDoArquivo = Console.ReadLine();

            using (var leitor = new StreamWriter(path + nomeDoArquivo + extensaoArquivo)) //Fluxo para escrever o arquivo na pasta destino
            {
                leitor.Write(text);
            }

            Console.WriteLine($"Arquivo {nomeDoArquivo} salvo com sucesso !");
        }
    }  
}
