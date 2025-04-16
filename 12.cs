using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Digite um número decimal para converter em binário: ");
        int numeroDecimal = int.Parse(Console.ReadLine());

       
        MinhaPilha<int> pilha = new MinhaPilha<int>();

       
        while (numeroDecimal > 0)
        {
            int resto = numeroDecimal % 2;  
            pilha.Push(resto); 
            numeroDecimal /= 2; 
        }

       
        Console.Write("Número binário: ");
        while (!pilha.EstaVazia())
        {
            Console.Write(pilha.Pop());  
        }

        Console.WriteLine();  
    }
}

public class MinhaPilha<T>
{
    private T[] elementos;
    private int topo;
    private const int capacidadeInicial = 10;

    public MinhaPilha()
    {
        elementos = new T[capacidadeInicial];
        topo = -1;
    }

    public void Push(T item)
    {
        if (topo == elementos.Length - 1)
        {
            RedimensionarArray();
        }

        topo++;
        elementos[topo] = item;
    }

    public T Pop()
    {
        if (EstaVazia())
        {
            throw new InvalidOperationException("A pilha está vazia");
        }

        T item = elementos[topo];
        elementos[topo] = default(T);
        topo--;
        return item;
    }

    public T Peek()
    {
        if (EstaVazia())
        {
            throw new InvalidOperationException("A pilha está vazia");
        }

        return elementos[topo];
    }

    public int Count
    {
        get { return topo + 1; }
    }

    public bool EstaVazia()
    {
        return topo == -1;
    }

    private void RedimensionarArray()
    {
        int novaCapacidade = elementos.Length * 2;
        T[] novoArray = new T[novaCapacidade];

        Array.Copy(elementos, novoArray, elementos.Length);

        elementos = novoArray;
    }
}
