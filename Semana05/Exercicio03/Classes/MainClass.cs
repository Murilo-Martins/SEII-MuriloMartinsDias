using System;
using System.Threading;
using System.Diagnostics;

namespace Exercicio03.Classes
{
    public class MainClass
    {
        static byte[] values = new byte[50000000];
        static long[] portionResults;
        static long portionSize;
        
        static void GenerateInts()
        {
            var rand = new Random(987);
            for (int i = 0; i < values.Length; i++)
            {
                values[i]=(byte)rand.Next(10);
            }
        }
        static void SumYourPortion(object portionNumber)
        {
            long sum = 0;
            int portionNumberAsInt = (int)portionNumber;
            long temp = portionNumberAsInt* portionSize;
            int baseIndex = (int)temp;

            for (int i = baseIndex; i < baseIndex + portionSize; i++)
            {
                sum += values[i];
            }
            portionResults[portionNumberAsInt] = sum;
            
        }
        public void Executar()
        {
            portionResults = new long[Environment.ProcessorCount];
            portionSize = values.Length / Environment.ProcessorCount;
            GenerateInts();
            Console.WriteLine("Somando..");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            long total = 0;
            for (int i = 0; i < values.Length; i++)
                total += values[i];
            watch.Stop();
            Console.WriteLine("Total value is: "+ total);
            Console.WriteLine("Time to sum: "+ watch.Elapsed);
            Console.WriteLine();


            watch.Reset();
            watch.Start();
            Thread[] threads = new Thread[Environment.ProcessorCount];
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads[i] = new Thread(SumYourPortion);
                threads[i].Start(i);
            }
            for (int i = 0; i < Environment.ProcessorCount; i++)
                threads[i].Join();
            long sum2 = 0;
            for (int i = 0; i < Environment.ProcessorCount; i++)
                sum2 += portionResults[i];
            Console.WriteLine("Total value is: "+ sum2);
            Console.WriteLine("Time to sum: "+ watch.Elapsed);
            
            
        }
    }
}