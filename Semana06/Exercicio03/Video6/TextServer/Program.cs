using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
    private static Socket listener;
    private static Socket acceptedClient;

    static void Main(string[] args)
    {
        try
        {
            // Cria o socket listener
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, 3)); // Porta 3
            listener.Listen(10);

            Console.WriteLine("Servidor iniciado e aguardando conexões...");

            // Thread para aceitar conexões
            new Thread(() =>
            {
                try
                {
                    acceptedClient = listener.Accept();
                    Console.WriteLine("Cliente conectado!");

                    // Thread para receber dados do cliente
                    new Thread(() =>
                    {
                        try
                        {
                            byte[] sizeBuf = new byte[4];
                            acceptedClient.Receive(sizeBuf, 0, sizeBuf.Length, 0);
                            int size = BitConverter.ToInt32(sizeBuf, 0);

                            using (MemoryStream ms = new MemoryStream())
                            {
                                byte[] buffer;
                                if (size < acceptedClient.ReceiveBufferSize)
                                {
                                    buffer = new byte[size];
                                }
                                else
                                {
                                    buffer = new byte[acceptedClient.ReceiveBufferSize];
                                }

                                int rec = acceptedClient.Receive(buffer, 0, buffer.Length, 0);
                                size -= rec;
                                ms.Write(buffer, 0, buffer.Length);

                                // Continua recebendo se necessário
                                while (size > 0)
                                {
                                    rec = acceptedClient.Receive(buffer, 0, Math.Min(buffer.Length, size), 0);
                                    size -= rec;
                                    ms.Write(buffer, 0, rec);
                                }

                                byte[] data = ms.ToArray();

                                // Exibe a mensagem no console
                                string message = Encoding.Default.GetString(data);
                                Console.WriteLine("Mensagem recebida: ");
                                Console.WriteLine(message);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao receber dados: {ex.Message}");
                        }
                    }).Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro na conexão: {ex.Message}");
                }
            }).Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao iniciar servidor: {ex.Message}");
        }

        // Aguarda o servidor até ser fechado
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}
