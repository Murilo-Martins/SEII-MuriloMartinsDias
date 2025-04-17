using System;
using System.Threading;

namespace Exercicio03.Classes
{
    public class ThreadsBasics
    {
        static int count = 0;
        static object baton = new object();
        static Random rand = new Random();
        public void Executar()
        {   
            
            if(false)
            {
                //Video 1 ao 3 ------------
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                for (int i = 0; i < 8; i++)//Alterar i<0 para func
                {
                    var thread = new Thread(DifferentMethod);
                    thread.IsBackground = true;
                    thread.Start(i);
                }
                //Video 4 ao 5------------
                    var thread1 = new Thread(IncrementCount);
                    var thread2 = new Thread(IncrementCount);
                    thread1.Start();
                    Thread.Sleep(500);
                    thread2.Start();
                //Video 6 ------------
                for (int i = 0; i < 5; i++)
                {
                    new Thread(UseRestroomStall).Start();
                }
            }
            


            
            
            
        }        
        static void DifferentMethod(object threadID)
        {
            Console.WriteLine("My id: " + threadID);
            Console.WriteLine("Current: " + Thread.CurrentThread.ManagedThreadId);
        }

        static void IncrementCount()
        {
            
            for (int i = 0; i < 10; i++)
            {
                lock(baton)
                {               
                    count++;
                    Console.WriteLine("Thread ID" + Thread.CurrentThread.ManagedThreadId+
                    "Increment count to "+ count);
                }
                Thread.Sleep(1000);
            }
        }

        static void UseRestroomStall()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " tentando ver se o banheiro está livre");
            lock(baton)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " consegui entrar, mandando aquela");
                Thread.Sleep(rand.Next(200));
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Se eu fosse tu não entrava agora");
            }
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Acabou a novela");
            
        }
        

    }
}