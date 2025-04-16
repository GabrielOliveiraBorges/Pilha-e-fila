using System;
using System.Collections.Generic;

class Documento : IComparable<Documento>
{
    public string Nome { get; set; }
    public int Prioridade { get; set; }

    public Documento(string nome, int prioridade)
    {
        Nome = nome;
        Prioridade = prioridade;
    }

    public int CompareTo(Documento outro)
    {
        return Prioridade.CompareTo(outro.Prioridade); 
    }

    public override string ToString()
    {
        return $"Documento: {Nome}, Prioridade: {Prioridade}";
    }
}

class GerenciadorImpressao
{
    private List<Documento> fila;

    public GerenciadorImpressao()
    {
        fila = new List<Documento>();
    }

    public void AdicionarDocumento(string nome, int prioridade)
    {
        Documento doc = new Documento(nome, prioridade);
        fila.Add(doc);
        fila.Sort(); 
        Console.WriteLine($"Adicionado: {doc}");
    }

    public void ImprimirProximo()
    {
        if (fila.Count > 0)
        {
            Documento doc = fila[0];
            fila.RemoveAt(0);
            Console.WriteLine($"Imprimindo: {doc}");
        }
        else
        {
            Console.WriteLine("Fila de impressão vazia.");
        }
    }

    public void ListarFila()
    {
        Console.WriteLine("\nFila de Impressão:");
        foreach (Documento doc in fila)
        {
            Console.WriteLine(" - " + doc);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GerenciadorImpressao impressora = new GerenciadorImpressao();

        impressora.AdicionarDocumento("Relatório Financeiro", 2);
        impressora.AdicionarDocumento("Currículo", 1);
        impressora.AdicionarDocumento("Proposta Comercial", 3);

        impressora.ListarFila();

        Console.WriteLine(" Impressão ");
        impressora.ImprimirProximo();
        impressora.ImprimirProximo();
        impressora.ImprimirProximo();
        impressora.ImprimirProximo();
    }
}
