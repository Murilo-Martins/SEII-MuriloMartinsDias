using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
    static Socket sock;

    static void Main(string[] args)
    {
        sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Solicita o IP do servidor e a porta
        Console.Write("Digite o IP do servidor: ");
        string ip = Console.ReadLine();
        Console.Write("Digite a porta: ");
        int port = int.Parse(Console.ReadLine());

        try
        {
            // Conectando-se ao servidor
            sock.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
            Console.WriteLine("Conectado ao servidor!");

            // Thread para receber mensagens do servidor
            new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        byte[] buffer = new byte[2048];
                        int rec = sock.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                        if (rec <= 0)
                            throw new SocketException();

                        Array.Resize(ref buffer, rec);
                        string msg = Encoding.Default.GetString(buffer);
                        Console.WriteLine($"Mensagem do servidor: {msg}");
                    }
                }
                catch
                {
                    Console.WriteLine("Desconectado do servidor!");
                    Environment.Exit(0);
                }
            }).Start();

            // Loop para enviar mensagens ao servidor
            while (true)
            {
                string textToSend = Console.ReadLine();
                if (!string.IsNullOrEmpty(textToSend))
                {
                    byte[] data = Encoding.Default.GetBytes(textToSend);
                    sock.Send(data, 0, data.Length, SocketFlags.None);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro de conexão: {ex.Message}");
        }
    }
}
