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
                case 2: Editar(); break;
                case 3: Apagar(); break;
                case 4: System.Environment.Exit(0); break;
                default: Console.WriteLine("Opção Inexistente"); break;

            }
        }



        static void Criar() { }

        static void Editar() { }

        static void Apagar() { }
    }

       
}
