using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Digite uma sequência de parênteses: ");
        string entrada = Console.ReadLine();

        if (EstaBalanceada(entrada))
        {
            Console.WriteLine("A sequência está balanceada!");
        }
        else
        {
            Console.WriteLine("A sequência NÃO está balanceada.");
        }
    }

    static bool EstaBalanceada(string sequencia)
    {
        Stack<char> pilha = new Stack<char>();

        foreach (char c in sequencia)
        {
            if (c == '(')
            {
                pilha.Push(c);
            }
            else if (c == ')')
            {
                if (pilha.Count == 0)
                {
                    return false; 
                }
                pilha.Pop();
            }
        }

        return pilha.Count == 0; 
    }
}
