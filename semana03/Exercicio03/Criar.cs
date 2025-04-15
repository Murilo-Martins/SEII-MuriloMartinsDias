using System;
using System.IO;

namespace CSCourse
{
    class Criar
    {
        public static void criarArq(string[] args)
        {   
            string nomeDoArquivo = "textoCsharpe.txt";
            string texto = "Esté é um documento de texto!";
            File.WriteAllText(nomeDoArquivo, texto);
            Console.WriteLine("Criado com sucesso!");
            
        }
        
    }
}
