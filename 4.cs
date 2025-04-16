using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        
        Queue<string> fila = new Queue<string>();

        
        Console.WriteLine("A fila está vazia? " + (fila.Count == 0));

        
        fila.Enqueue("João");
        fila.Enqueue("Maria");

        
        Console.WriteLine("A fila está vazia? " + (fila.Count == 0));
    }
}
