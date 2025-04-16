using System;
using System.Collections.Generic;

public class Estacionamento
{
    private Stack<string> pilhaCarros;
    private int capacidadeMaxima;

    public Estacionamento(int capacidade)
    {
        capacidadeMaxima = capacidade;
        pilhaCarros = new Stack<string>();
    }

    public void Entrar(string carro)
    {
        if (pilhaCarros.Count < capacidadeMaxima)
        {
            pilhaCarros.Push(carro);
            Console.WriteLine($"Carro {carro} entrou no estacionamento.");
        }
        else
        {
            Console.WriteLine("Estacionamento cheio! Não é possível adicionar mais carros.");
        }
    }
    public void Sair(string carro)
    {
        if (pilhaCarros.Count == 0)
        {
            Console.WriteLine("Estacionamento vazio! Não há carros para sair.");
            return;
        }

        Stack<string> carrosTemporarios = new Stack<string>();

        while (pilhaCarros.Count > 0)
        {
            string carroAtual = pilhaCarros.Pop();
            if (carroAtual == carro)
            {
                Console.WriteLine($"Carro {carro} saiu do estacionamento.");
                break;
            }
            else
            {
                carrosTemporarios.Push(carroAtual);
            }
        }

        while (carrosTemporarios.Count > 0)
        {
            pilhaCarros.Push(carrosTemporarios.Pop());
        }
    }
    public void ExibirEstacionamento()
    {
        Console.WriteLine("Carros no estacionamento:");
        foreach (var carro in pilhaCarros)
        {
            Console.WriteLine(carro);
        }
    }
}

class Program
{
    static void Main()
    {
 
        Estacionamento estacionamento = new Estacionamento(5);

     
        estacionamento.Entrar("Carro A");
        estacionamento.Entrar("Carro B");
        estacionamento.Entrar("Carro C");
        estacionamento.Entrar("Carro D");
        estacionamento.Entrar("Carro E");

        estacionamento.ExibirEstacionamento();

        estacionamento.Entrar("Carro F"); 

        estacionamento.Sair("Carro C"); 

        estacionamento.ExibirEstacionamento();

       
        estacionamento.Sair("Carro Z");
    }
}
