using System;
using System.IO;

namespace CSCourse
{
    class Anexar
    {
        public static void anexarArq(string[] args)
        {   
            string nomeDoAquivo ="textoCsharpe.txt";
            string conteudo = File.ReadAllText(nomeDoAquivo);

            Console.WriteLine("Conteudo do arquivo: ");
            Console.WriteLine(conteudo);
            Console.WriteLine("\n");

            File.AppendAllText(nomeDoAquivo, "Outro arquivo aqui.");
            var conteudo2 = File.ReadAllText(nomeDoAquivo);
            Console.WriteLine("Conteudo do arquivo: ");
            Console.WriteLine(conteudo2);
            Console.ReadKey(true);            
        }
        
    }
}
