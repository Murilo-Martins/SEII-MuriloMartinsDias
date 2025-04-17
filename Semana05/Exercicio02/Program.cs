using Exercicio02.Classes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        ExecutarTask();
        sw.Stop();
        Console.WriteLine($"Operação gastou : {sw.ElapsedMilliseconds}");
    }
    static void RealizarOperacao(int op, string nome, string sobrenome)
    {
        Console.WriteLine($"Iniciando operação {op}...");
        for (int i = 0; i <= 1000000 ; i++)
        {
            var p = new Pessoa(nome, sobrenome, 35);
        }
        Console.WriteLine($"Finalizando operação {op}...");
    }
    static void ExecutarSequencial()
    {
        for (int i = 0; i < 15; i++)
        {   
            RealizarOperacao((i+1),"Fulando", "da silva");
            RealizarOperacao((i+2),"Beltrano", "da silva");
            RealizarOperacao((i+3),"Siclano", "da silva");
            
        }
        
    }
    static void ExecutarThreads()
    {
        var t1= new Thread(() => 
        {
            for (int i = 0; i < 15; i++)
            {
                RealizarOperacao(1,"Fulando", "da silva");
            }
        });
        var t2= new Thread(() => 
        {
            for (int i = 0; i < 15; i++)
            {
                RealizarOperacao(2,"Beltrano", "da silva");
            }
        
        });
        var t3= new Thread(() => 
        {
            for (int i = 0; i < 15; i++)
            {
                RealizarOperacao(3,"Siclano", "da silva");
            }
        });
        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();
    }

    static void ExecutarTask()
    {
        var t1 = Task<int>.Run(() => 
        {
            for (int i = 0; i < 15; i++)
            {
                RealizarOperacao((i+1),"Fulando", "da silva");
               
            }
            return 1;
        });
        var t2 = Task<int>.Run(() => 
        {
            for (int i = 0; i < 15; i++)
            {
                RealizarOperacao((i+15),"Beltrano", "da silva");
                
            }
            return 15;
        
        });
        var t3= Task<int>.Run(() => 
        {
            for (int i = 0; i < 15; i++)
            {
                RealizarOperacao((i+15),"Siclano", "da silva");
                
            }
            return 30;
        });

        Console.WriteLine($"Tarefa {t1.Result}, finalizou");
        Console.WriteLine($"Tarefa {t2.Result}, finalizou");
        Console.WriteLine($"Tarefa {t3.Result}, finalizou");
    }
}