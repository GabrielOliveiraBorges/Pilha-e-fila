using System;

public class FilaCircular<T>
{
    private T[] elementos;
    private int frente;
    private int tras;
    private int capacidade;
    private int tamanho;

    // Construtor que define a capacidade da fila
    public FilaCircular(int capacidade)
    {
        this.capacidade = capacidade;
        elementos = new T[capacidade];
        frente = 0;
        tras = 0;
        tamanho = 0;
    }

    // Adiciona um item ao final da fila
    public void Enqueue(T item)
    {
        if (tamanho == capacidade)
        {
            throw new InvalidOperationException("Fila cheia");
        }

        elementos[tras] = item;
        tras = (tras + 1) % capacidade; // Move para o próximo índice circular
        tamanho++;
    }

    // Remove e retorna o item da frente da fila
    public T Dequeue()
    {
        if (tamanho == 0)
        {
            throw new InvalidOperationException("Fila vazia");
        }

        T item = elementos[frente];
        frente = (frente + 1) % capacidade; // Move para o próximo índice circular
        tamanho--;
        return item;
    }

    // Retorna o item da frente sem remover
    public T Peek()
    {
        if (tamanho == 0)
        {
            throw new InvalidOperationException("Fila vazia");
        }

        return elementos[frente];
    }

    // Retorna o número de elementos na fila
    public int Count
    {
        get { return tamanho; }
    }

    // Verifica se a fila está vazia
    public bool EstaVazia()
    {
        return tamanho == 0;
    }

    // Verifica se a fila está cheia
    public bool EstaCheia()
    {
        return tamanho == capacidade;
    }
}

class Program
{
    static void Main()
    {
       
        FilaCircular<int> fila = new FilaCircular<int>(5);

        
        fila.Enqueue(10);
        fila.Enqueue(20);
        fila.Enqueue(30);
        fila.Enqueue(40);
        fila.Enqueue(50);

       
        try
        {
            fila.Enqueue(60); 
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);  
        }

        Console.WriteLine("Dequeue: " + fila.Dequeue()); 
        Console.WriteLine("Dequeue: " + fila.Dequeue()); 

        
        fila.Enqueue(60); 
        fila.Enqueue(70);

      
        Console.WriteLine("Frente da fila: " + fila.Peek()); 
        Console.WriteLine("Quantidade de elementos na fila: " + fila.Count); 

        
        while (!fila.EstaVazia())
        {
            Console.WriteLine(fila.Dequeue());
        }
    }
}
