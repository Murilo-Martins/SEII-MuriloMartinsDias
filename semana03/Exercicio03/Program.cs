using System;
using System.IO;

namespace CSCourse
{
    class Listar
    {
        public static void Main(string[] args)
        {   
            string[] arquivos = Directory.GetFiles(@"C:\");

            foreach(var arquivo in arquivos){
                Console.WriteLine(arquivo);
            }           
            

            
        }
        
    }
}
