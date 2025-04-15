using System;
using System.IO;

namespace CSCourse
{
    class Ler
    {
        public static void lerArq(string[] args)
        {   
            string arquivo = "textoCsharpe.txt";
            string texto = File.ReadAllText(arquivo);
            Console.WriteLine(texto);
            
        }
        
    }
}
