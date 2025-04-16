using System;
using System.Collections.Generic;

public class MinhaFila<T>
{
    private List<T> elementos = new List<T>();

    
    public void Enqueue(T item)
    {
        elementos.Add(item);
    }

    
    public T Dequeue()
    {
        if (elementos.Count == 0)
            throw new InvalidOperationException("A fila está vazia.");

        T primeiro = elementos[0];
        elementos.RemoveAt(0);
        return primeiro;
    }

    
    public T Peek()
    {
        if (elementos.Count == 0)
            throw new InvalidOperationException("A fila está vazia.");

        return elementos[0];
    }

    
    public int Count
    {
        get { return elementos.Count; }
    }
}

class Program
{
    
    static void Main()
    {
        
        MinhaFila<int> fila = new MinhaFila<int>();

      
        fila.Enqueue(10);
        fila.Enqueue(20);
        fila.Enqueue(30);

      
        Console.WriteLine("Início da fila: " + fila.Peek()); 

       
        Console.WriteLine("Removido da fila: " + fila.Dequeue()); 

        
        Console.WriteLine("Novo início da fila: " + fila.Peek()); 

       
        Console.WriteLine("Tamanho da fila: " + fila.Count); 
    }
}
