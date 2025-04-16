using System;
using System.Collections.Generic;

class SistemaUndoRedo
{
    private Stack<string> pilhaUndo = new Stack<string>();
    private Stack<string> pilhaRedo = new Stack<string>();
    private string estadoAtual = "";

    public void ExecutarAcao(string novaAcao)
    {
        pilhaUndo.Push(estadoAtual);
        estadoAtual = novaAcao;
        pilhaRedo.Clear(); 
        Console.WriteLine($"Ação executada: {estadoAtual}");
    }

    public void Desfazer()
    {
        if (pilhaUndo.Count > 0)
        {
            pilhaRedo.Push(estadoAtual);
            estadoAtual = pilhaUndo.Pop();
            Console.WriteLine($"Desfeito. Estado atual: {estadoAtual}");
        }
        else
        {
            Console.WriteLine("Nada para desfazer.");
        }
    }

    public void Refazer()
    {
        if (pilhaRedo.Count > 0)
        {
            pilhaUndo.Push(estadoAtual);
            estadoAtual = pilhaRedo.Pop();
            Console.WriteLine($"Refeito. Estado atual: {estadoAtual}");
        }
        else
        {
            Console.WriteLine("Nada para refazer.");
        }
    }

    public void MostrarEstado()
    {
        Console.WriteLine($"Estado atual: {estadoAtual}");
    }
}

class Program
{
    static void Main()
    {
        SistemaUndoRedo sistema = new SistemaUndoRedo();

        sistema.ExecutarAcao("Escreveu: Galo");
        sistema.ExecutarAcao("Escreveu: Doido");
        sistema.ExecutarAcao("Apagou: Doido");

        sistema.Desfazer(); 
        sistema.Desfazer(); 

        sistema.Refazer();  

        sistema.MostrarEstado(); 
    }
}
