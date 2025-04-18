using System;
using System.Threading;
using Exercicio03.Classes;
class Program
{
    static void Main()
    {
        //Rodando tudo nas classes
        
        ThreadsBasics do1ao6 = new ThreadsBasics();
        do1ao6.Executar();

        ThreadsMedium somente7 = new ThreadsMedium();
        somente7.Executar();
        
        MainClass do8ao10 = new MainClass();
        do8ao10.Executar();

        //Nao consegui fazer funcionar essa
        //Producer do11ao14 = new Producer();
        //do11ao14.Executar();

  
        
    }
    
} 