using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sock.Bind(new IPEndPoint(IPAddress.Any, 1994));
        sock.Listen(0);

        Console.WriteLine("Aguardando conexão...");
        Socket acc = sock.Accept();
        Console.WriteLine("Conexão aceita!");

        // Thread para receber mensagens do cliente
        new Thread(() =>
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[255];
                    int rec = acc.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                    if (rec <= 0)
                        throw new SocketException();

                    Array.Resize(ref buffer, rec);
                    string msg = Encoding.Default.GetString(buffer);
                    Console.WriteLine($"Recebido: {msg}");
                }
            }
            catch
            {
                Console.WriteLine("Desconectado!");
                Environment.Exit(0);
            }
        }).Start();

        // Consegui fazer o botão não, aqui o gpt foi um santo
        while (true)
        {
            string textToSend = Console.ReadLine();
            if (!string.IsNullOrEmpty(textToSend))
            {
                byte[] data = Encoding.Default.GetBytes(textToSend);
                acc.Send(data, 0, data.Length, SocketFlags.None);
            }
        }
    }
}
