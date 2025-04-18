using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Exercicio02.Classes
{
    public class ObjectStates
    {
        public const int bufferSize = 256;
        public Socket wSocket = null;
        public byte[] buffer = new byte[bufferSize];
        public StringBuilder sb = new StringBuilder();
    }

    public class AsyncSocketClient
    {
        private const int Port = 4343;

        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        private static string response = string.Empty;

        public static void StartClient()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ip = ipHost.AddressList[0];
                IPEndPoint remoteEndPoint = new IPEndPoint(ip, Port);

                Socket client = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                client.BeginConnect(remoteEndPoint, new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                Send(client, "Hello from client<EOF>");
                sendDone.WaitOne();

                Receive(client);
                receiveDone.WaitOne();

                Console.WriteLine($"Response received: {response}");

                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
                Console.WriteLine($"Socket connected to {client.RemoteEndPoint}");
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                ObjectStates state = new ObjectStates();
                state.wSocket = client;
                client.BeginReceive(state.buffer, 0, ObjectStates.bufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                ObjectStates state = (ObjectStates)ar.AsyncState;
                Socket client = state.wSocket;

                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    response = state.sb.ToString();

                    if (response.IndexOf("<EOF>") > -1)
                    {
                        receiveDone.Set();
                    }
                    else
                    {
                        client.BeginReceive(state.buffer, 0, ObjectStates.bufferSize, 0,
                            new AsyncCallback(ReceiveCallback), state);
                    }
                }
                else
                {
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, string data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                int bytesSent = client.EndSend(ar);
                Console.WriteLine($"Sent {bytesSent} bytes to server.");
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
