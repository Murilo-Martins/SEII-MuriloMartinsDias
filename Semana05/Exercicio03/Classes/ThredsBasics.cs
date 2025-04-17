namespace Exercicio03.Classes
{
    public class ThredsBasics
    {
        
        public void Executar()
        {   
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 8; i++)
            {
                var thread = new Thread(DifferentMethod);
                thread.IsBackground = true;
                thread.Start(i);
            }
            
            
        }        
        static void DifferentMethod(object threadID)
        {
            Console.WriteLine("My id: " + threadID);
            Console.WriteLine("Current: " + Thread.CurrentThread.ManagedThreadId);
        }
        

    }
}