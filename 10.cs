using System;

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

    public void Limpar()
    {
        for (int i = 0; i <= topo; i++)
        {
            elementos[i] = default(T);
        }
        topo = -1;
    }
}