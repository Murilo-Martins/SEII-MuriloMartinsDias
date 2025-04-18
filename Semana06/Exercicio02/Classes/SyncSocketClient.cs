using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Exercicio02.Classes
{
    public class SyncSocketClient
    {
        public static void StartClient()
        {
            byte[] bytes = new byte[1024];
            try
            {
                var hostName = Dns.GetHostName();
                IPHostEntry ipHost = Dns.GetHostEntry(hostName);
                Console.WriteLine($"Host: {hostName}");

                IPAddress ip = ipHost.AddressList[0]; // Escolhe o primeiro IP disponível
                IPEndPoint remoteEp = new IPEndPoint(ip, 45323);

                Socket sender = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEp);
                    Console.WriteLine($"Socket conectado a {sender.RemoteEndPoint}");

                    byte[] msg = Encoding.ASCII.GetBytes("This is just a test");
                    int bytesSent = sender.Send(msg);

                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine($"Mensagem ecoada: {Encoding.ASCII.GetString(bytes, 0, bytesRec)}");

                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"Erro de argumento: {e.Message}");
                    throw;
                }
                catch (SocketException e)
                {
                    Console.WriteLine($"Erro de socket: {e.Message}");
                    throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro inesperado: {e.Message}");
                    throw;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao tentar obter IP: {e.Message}");
                throw;
            }
        }
    }
}
