using System;
using System.Threading;

namespace Exercicio03.Classes
{
    
    public class Producer
    {
        static Queue<int> numbers = new Queue<int>();
        static Random rand = new Random();
        const int NumThreads = 3;
        static int[] sums =  new int[NumThreads];

        static void ProduceNumbrs()
        {
            for (int i = 0; i < 25; i++)
            {
                int numToEnqueue = rand.Next(10);
                Console.WriteLine("Producing thread adding " + numToEnqueue);
                numbers.Enqueue(rand.Next(10));
                Thread.Sleep(rand.Next(1000));
            }
        }

        static void SumNumbers(object threadNumber)
        {
            DateTime startTime = DateTime.Now;
            int mySum = 0;
            while((DateTime.Now - startTime).Seconds <11)
            {
                if(numbers.Count !=0)
                {   
                    int numToSum = numbers.Dequeue();
                    mySum+= numbers.Dequeue();
                    Console.WriteLine("Consuming thread adding" + numToSum + " to its total sum "+numToSum);
                }
                    
            }
            sums[(int)threadNumber]= mySum;
        }
        
        public void Executar()
        {
            var producingThread = new Thread(ProduceNumbrs);
            producingThread.Start();
            Thread[] threads = new Thread[NumThreads];
            for (int i = 0; i < NumThreads; i++)
            {
                threads[i] = new Thread(SumNumbers);
                threads[i].Start();
            }
            for (int i = 0; i < NumThreads; i++)
            {
                threads[i].Join();
            }
            
        }
    }
    
}