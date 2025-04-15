using System;
using System.IO;

namespace CSCourse
{
    class DeletarDiretorio
    {
        public static void deletar(string[] args)
        {   
            string diretorio ="Newpasta";
            Directory.Delete(diretorio);
            
                 
            

            
        }
        
    }
}
