using System;
using System.IO;

namespace CSCourse
{
    class Existencia
    {
        public static void existe(string[] args)
        {   
            string nomeDoAquivo ="textoCsharpe.txt";
            

            Console.WriteLine("Arquivo existe: ");
            Console.WriteLine(File.Exists(nomeDoAquivo));
            Console.WriteLine("\n");

            
        }
        
    }
}
