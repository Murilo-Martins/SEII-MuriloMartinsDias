using System;
using System.IO;

namespace CSCourse
{
    class VariasLinhas
    {
        public static void WVariasLinhas(string[] args)
        {   
            string[] documentos = {"Documento 1.", "Documento 2."};

            string nomeDoAquivo ="VariasLinhas.txt";
            File.WriteAllLines(nomeDoAquivo, documentos);
            Console.ReadKey(true);            
        }
        
    }
}
