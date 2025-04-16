using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<string> filaAtendimento = new Queue<string>();
        string opcao;

        do
        {
        
            Console.WriteLine("1 - Adicionar cliente à fila");
            Console.WriteLine("2 - Atender próximo cliente");
            Console.WriteLine("3 - Ver fila de espera");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome do cliente: ");
                    string cliente = Console.ReadLine();
                    filaAtendimento.Enqueue(cliente);
                    Console.WriteLine($"{cliente} foi adicionado(a) à fila.");
                    break;

                case "2":
                    if (filaAtendimento.Count > 0)
                    {
                        string atendido = filaAtendimento.Dequeue();
                        Console.WriteLine($"{atendido} está sendo atendido(a).");
                    }
                    else
                    {
                        Console.WriteLine("A fila está vazia. Nenhum cliente para atender.");
                    }
                    break;

                case "3":
                    if (filaAtendimento.Count > 0)
                    {
                        Console.WriteLine("Clientes na fila:");
                        foreach (var nome in filaAtendimento)
                        {
                            Console.WriteLine("- " + nome);
                        }
                    }
                    else
                    {
                        Console.WriteLine("A fila está vazia.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Encerrando o sistema de atendimento...");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (opcao != "4");
    }
}
