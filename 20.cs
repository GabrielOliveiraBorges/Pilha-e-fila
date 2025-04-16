using System;
using System.Collections.Generic;

class LRUCache<TKey, TValue>
{
    private readonly int capacidade;
    private readonly Dictionary<TKey, TValue> cache;
    private readonly LinkedList<TKey> ordemUso; 

    public LRUCache(int capacidade)
    {
        this.capacidade = capacidade;
        cache = new Dictionary<TKey, TValue>();
        ordemUso = new LinkedList<TKey>();
    }

    public void Adicionar(TKey chave, TValue valor)
    {
        if (cache.ContainsKey(chave))
        {
            cache[chave] = valor;
            ordemUso.Remove(chave);
            ordemUso.AddLast(chave);
        }
        else
        {
            if (cache.Count >= capacidade)
            {
               
                TKey chaveAntiga = ordemUso.First.Value;
                ordemUso.RemoveFirst();
                cache.Remove(chaveAntiga);
                Console.WriteLine($"Removido do cache: {chaveAntiga}");
            }

            cache[chave] = valor;
            ordemUso.AddLast(chave);
        }

        Console.WriteLine($"Adicionado/Acessado: {chave} -> {valor}");
    }

    public TValue Acessar(TKey chave)
    {
        if (cache.ContainsKey(chave))
        {
          
            ordemUso.Remove(chave);
            ordemUso.AddLast(chave);
            Console.WriteLine($"Acessado: {chave} -> {cache[chave]}");
            return cache[chave];
        }
        else
        {
            Console.WriteLine($"Chave não encontrada no cache: {chave}");
            return default;
        }
    }

    public void MostrarCache()
    {
        Console.WriteLine(" Conteúdo do Cache (mais antigo → mais recente):");
        foreach (TKey chave in ordemUso)
        {
            Console.WriteLine($" - {chave} -> {cache[chave]}");
        }
    }
}

class Program
{
    static void Main()
    {
        LRUCache<string, string> cache = new LRUCache<string, string>(3);

        cache.Adicionar("A", "Valor A");
        cache.Adicionar("B", "Valor B");
        cache.Adicionar("C", "Valor C");

        cache.MostrarCache();

        cache.Acessar("A"); 
        cache.Adicionar("D", "Valor D"); 

        cache.MostrarCache();
    }
}
