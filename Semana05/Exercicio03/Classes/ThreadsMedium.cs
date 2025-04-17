namespace Exercicio03.Classes
{
    public class ThreadsMedium
    {
        static object baton = new object();
        public void Executar()
        {
            monitor();
        }
        static void monitor()
        {
            bool lockTaken =false;
            Monitor.Enter(baton, ref lockTaken);
            try
            {
                Console.WriteLine("Va ao banheiro");
            }
            finally
            {
                if(lockTaken)
                    Monitor.Exit(baton);
            }
        }
    }
}