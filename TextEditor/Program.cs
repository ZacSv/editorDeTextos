using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;

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
            Console.WriteLine(" O que deseja fazer: ");
            Console.WriteLine("1 - Criar um arquivo");
            Console.WriteLine("2 - Abrir um arquivo");
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
            DateTime dataCriacaoArquivo = DateTime.Now;
            Console.WriteLine(" Digite seu texto abaixo (ESC para SAIR) ");
            Console.WriteLine("-------------------------");

            string userText = "";

            do //Faz sempre o bloco abaixo
            {
                userText += Console.ReadLine();
                userText += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);//Enquanto essa condição não for satisfeita  
            userText += "Data de criação do arquivo: " + dataCriacaoArquivo;

            Salvar(userText);
            Console.WriteLine("Press any key to return menu");
            Console.ReadKey();
            Menu();
        }

        static void Abrir()
        {

            Console.Clear();
            var path = "c:\\dev\\EditorTexto\\ArquivosDeTexto\\";
            ListarArquivosDoDiretorio(path);
            var extensaoArquivo = ".txt";

            Console.WriteLine("Qual o nome do arquivo que deseja abrir: ");
            var arquivoParaAbrir = Console.ReadLine();
            var caminhoCompletoArquivo = path + arquivoParaAbrir + extensaoArquivo;
            using (var abrirArquivo = new StreamReader(caminhoCompletoArquivo))
            {
                if (File.Exists(caminhoCompletoArquivo))
                {
                    string textoDoArquivo = abrirArquivo.ReadToEnd();
                    Console.WriteLine(textoDoArquivo);
                }
                else
                {
                    Console.WriteLine($"Operação abortada, arquivo {arquivoParaAbrir} inexistente no diretorio {path}");
                }

            }
            Console.WriteLine("Press any key to return menu");
            Console.ReadKey();
            Console.Clear();
            Menu();

        }

        static void Apagar()
        {
            try
            {
                do
                {
                    //Lógica para definir nome e caminho do arquivo
                    var path = "c:\\dev\\EditorTexto\\ArquivosDeTexto\\";
                    var extensaoArquivo = ".txt";
                    Console.Clear();
                    ListarArquivosDoDiretorio(path);
                    Console.WriteLine("Digite o nome do arquivo que deseja apagar: ");
                    var nomeArquivo = Console.ReadLine();
                    var arquivoQueSeraApagado = path + nomeArquivo + extensaoArquivo;
                    if (File.Exists(arquivoQueSeraApagado))
                    {
                        Console.WriteLine("Tem certeza que deseja excluir o arquivo ? (Pressione S para SIM e qualquer outra tecla para NÃO)");
                        string confirmacaoExclusao = Console.ReadLine();

                        //Garante a confirmação de exclusão
                        if (confirmacaoExclusao.ToUpper() == "S")
                        {
                            File.Delete(arquivoQueSeraApagado);
                            File.Delete(arquivoQueSeraApagado);
                            Console.WriteLine("Arquivo excluído com sucesso !");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Operação abortada, {nomeArquivo + extensaoArquivo} inexistente no diretório !\nVerifique o nome do arquivo e tente novamente");
                    }
                    Console.WriteLine("Pressione qualquer tecla para prosseguir e ESC para sair\n");
                }
                while (Console.ReadKey().Key != ConsoleKey.Escape);//Enquanto essa condição não for satisfeita  
                {
                }
            }
            finally
            {
                Menu();
            }
        }

        static void Salvar(string text)
        {
            Console.Clear();
            //Define a extensão e caminho primário do arquivo
            var path = "c:\\dev\\EditorTexto\\ArquivosDeTexto\\";
            var extensaoArquivo = ".txt";
            
            //Solicita do usuário para que digite o nome do arquivo
            Console.WriteLine(" Digite o nome do arquivo: ");
            var nomeDoArquivo = Console.ReadLine().Trim();
            

            //Faz um merge com o nome completo do arquivo
            var caminhoDoArquivo = Path.Combine(path + nomeDoArquivo + extensaoArquivo);

            //Logica para verificar se o nome do arquivo já existe no diretório
            int contador = 1;
            while (File.Exists(caminhoDoArquivo))
            {
                string novoNome = ($"{nomeDoArquivo}_{contador}");
                caminhoDoArquivo = Path.Combine(path, novoNome + extensaoArquivo);
                contador++;
            }
           
            //Se não houver nenhum nome por padrão no arquivo o programa seta o nome "Default"
            if (string.IsNullOrWhiteSpace(nomeDoArquivo))
            {
                string nomePadrao = "Default";
                caminhoDoArquivo = Path.Combine(path + nomePadrao + extensaoArquivo);
            }

            using (var escritor = new StreamWriter(caminhoDoArquivo)) //Fluxo para escrever o arquivo na pasta destino
            {
                escritor.Write(text);
            }

            Console.WriteLine($"Arquivo salvo com sucesso !");
        }

        static void ListarArquivosDoDiretorio(string caminhoComNomeDoArquivo)
        {
            try
            {
                if (Directory.Exists(caminhoComNomeDoArquivo))
                {
                    string[] arquivos = Directory.GetFiles(caminhoComNomeDoArquivo);

                    Console.WriteLine("ARQUIVOS NO DIRETÓRIO");
                    Console.WriteLine("-------------------------------------------");
                    foreach (string arquivo in arquivos)
                    {
                        Console.WriteLine(arquivo.Substring(35));
                    }
                    Console.WriteLine("-------------------------------------------");
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

        static bool VerificaSeNomeDoArquivoExiste(string caminhoArquivo)
        {
            return File.Exists(caminhoArquivo);
        }
    }
    
}
