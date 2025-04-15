namespace CSCourse
{
    class LerLinhas
    {
        public static void Vlinhas(string[] args)
        {   
            string nomeDoAquivo ="VariasLinhas.txt";
            
            string[] documentos = File.ReadAllLines(nomeDoAquivo);
            Console.WriteLine(documentos[0]);
            Console.ReadKey(true);            
        }
        
    }
}