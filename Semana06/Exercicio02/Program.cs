using System.Threading.Tasks;
using System.Timers;
using Exercicio02.Classes;
class Program
{       static void Main(string[] args)
    {
        // Inicia o servidor em Thread/Task
        Task.Run(() => SyncSocketServer.StartListener());

        // Aguarda garantindo que o servidor esteja escutando
        Task.Delay(500).Wait();
        SyncSocketClient.StartClient();

        Console.ReadLine();
        AsyncSocketClient.StartClient();
        
    }
}