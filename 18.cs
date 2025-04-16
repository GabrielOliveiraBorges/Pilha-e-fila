using System;
using System.Collections.Generic;

class AvaliadorPosFixada
{
    public static double ResolverExpressao(string expressao)
    {
        Stack<double> pilha = new Stack<double>();
        string[] tokens = expressao.Split(' ');

        foreach (string token in tokens)
        {
            if (double.TryParse(token, out double numero))
            {
                pilha.Push(numero);
            }
            else
            {
                if (pilha.Count < 2)
                {
                    throw new InvalidOperationException("Expressão malformada.");
                }

                double b = pilha.Pop();
                double a = pilha.Pop();
                double resultado = 0;

                switch (token)
                {
                    case "+":
                        resultado = a + b;
                        break;
                    case "-":
                        resultado = a - b;
                        break;
                    case "*":
                        resultado = a * b;
                        break;
                    case "/":
                        resultado = a / b;
                        break;
                    default:
                        throw new InvalidOperationException($"Operador desconhecido: {token}");
                }

                pilha.Push(resultado);
            }
        }

        if (pilha.Count != 1)
        {
            throw new InvalidOperationException("Expressão malformada no final.");
        }

        return pilha.Pop();
    }

    static void Main()
    {
        string expressao = "3 4 + 2 *";  
        try
        {
            double resultado = ResolverExpressao(expressao);
            Console.WriteLine($"Resultado da expressão \"{expressao}\" é: {resultado}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
