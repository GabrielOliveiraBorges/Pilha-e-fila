using System;
using System.Collections.Generic;

public class Deque<T>
{
    private LinkedList<T> lista;

    public Deque()
    {
        lista = new LinkedList<T>();
    }
    public void InserirFrente(T item)
    {
        lista.AddFirst(item);
        Console.WriteLine($"Elemento {item} inserido à frente.");
    }
    public void InserirFundo(T item)
    {
        lista.AddLast(item);
        Console.WriteLine($"Elemento {item} inserido ao fundo.");
    }
    public T RemoverFrente()
    {
        if (lista.Count == 0)
        {
            throw new InvalidOperationException("Deque vazio. Não há elementos para remover.");
        }

        T item = lista.First.Value;
        lista.RemoveFirst();
        Console.WriteLine($"Elemento {item} removido da frente.");
        return item;
    }

    public T RemoverFundo()
    {
        if (lista.Count == 0)
        {
            throw new InvalidOperationException("Deque vazio. Não há elementos para remover.");
        }

        T item = lista.Last.Value;
        lista.RemoveLast();
        Console.WriteLine($"Elemento {item} removido do fundo.");
        return item;
    }
    public T VerFrente()
    {
        if (lista.Count == 0)
        {
            throw new InvalidOperationException("Deque vazio.");
        }

        return lista.First.Value;
    }

    public T VerFundo()
    {
        if (lista.Count == 0)
        {
            throw new InvalidOperationException("Deque vazio.");
        }

        return lista.Last.Value;
    }

    public bool EstaVazio()
    {
        return lista.Count == 0;
    }
    public int Count
    {
        get { return lista.Count; }
    }

    public void ExibirDeque()
    {
        if (lista.Count == 0)
        {
            Console.WriteLine("Deque vazio.");
            return;
        }

        Console.WriteLine("Elementos no Deque:");
        foreach (var item in lista)
        {
            Console.WriteLine(item);
        }
    }
}

class Program
{
    static void Main()
    {
      
        Deque<int> deque = new Deque<int>();

        deque.InserirFrente(10); 
        deque.InserirFundo(20);  
        deque.InserirFrente(5);  
        deque.InserirFundo(30);  

        deque.ExibirDeque();

       
        deque.RemoverFrente();   
        deque.RemoverFundo();    

       
        deque.ExibirDeque();

        Console.WriteLine($"Elemento da frente: {deque.VerFrente()}");
        Console.WriteLine($"Elemento do fundo: {deque.VerFundo()}");

       
        Console.WriteLine($"Número de elementos no Deque: {deque.Count}");
    }
}
