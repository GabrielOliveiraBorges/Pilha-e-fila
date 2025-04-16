using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<string> historico = new Stack<string>();
        string paginaAtual = "Página Inicial";

        while (true)
        {
            Console.WriteLine($"\nVocê está em: {paginaAtual}");
            Console.WriteLine("1 - Acessar nova página");
            Console.WriteLine("2 - Voltar à página anterior");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome da nova página: ");
                    historico.Push(paginaAtual);
                    paginaAtual = Console.ReadLine(); 
                    break;

                case "2":
                    if (historico.Count > 0)
                    {
                        paginaAtual = historico.Pop(); 
                    }
                    else
                    {
                        Console.WriteLine("Não há páginas anteriores.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Encerrando o programa...");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
