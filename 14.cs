using System;
using System.Collections.Generic;

public class FilaDePrioridade<T>
{
    private List<Elemento<T>> elementos;

    public FilaDePrioridade()
    {
        elementos = new List<Elemento<T>>();
    }

    public void Enqueue(T item, int prioridade)
    {
        Elemento<T> novoElemento = new Elemento<T>(item, prioridade);

        elementos.Add(novoElemento);
        elementos.Sort((x, y) => y.Prioridade.CompareTo(x.Prioridade));
    }

    public T Dequeue()
    {
        if (elementos.Count == 0)
        {
            throw new InvalidOperationException("Fila vazia");
        }

        T item = elementos[0].Item;
        elementos.RemoveAt(0); 
        return item;
    }

    public T Peek()
    {
        if (elementos.Count == 0)
        {
            throw new InvalidOperationException("Fila vazia");
        }

        return elementos[0].Item;
    }

    public int Count
    {
        get { return elementos.Count; }
    }

    public bool EstaVazia()
    {
        return elementos.Count == 0;
    }

    private class Elemento<U>
    {
        public U Item { get; set; }
        public int Prioridade { get; set; }

        public Elemento(U item, int prioridade)
        {
            Item = item;
            Prioridade = prioridade;
        }
    }
}

class Program
{
    static void Main()
    {
        
        FilaDePrioridade<string> fila = new FilaDePrioridade<string>();

        
        fila.Enqueue("Tarefa 1", 3); 
        fila.Enqueue("Tarefa 2", 1); 
        fila.Enqueue("Tarefa 3", 4); 
        fila.Enqueue("Tarefa 4", 2); 

        Console.WriteLine("Quantidade de elementos na fila: " + fila.Count);

      
        Console.WriteLine("Atendendo: " + fila.Dequeue()); 
        Console.WriteLine("Atendendo: " + fila.Dequeue()); 
        Console.WriteLine("Atendendo: " + fila.Dequeue()); 
        Console.WriteLine("Atendendo: " + fila.Dequeue()); 

       
        Console.WriteLine("Fila está vazia: " + fila.EstaVazia());
    }
}
