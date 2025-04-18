using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Exercicio02.Classes
{
    public class ObjectState
    {
        public Socket wSocket = null;
        public const int bufferSize = 1024;
        public byte[] buffer = new byte[bufferSize];
        public StringBuilder sb = new StringBuilder();
    }

    public class AsyncSocketListener
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public static void StartListener()
        {
            IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName())
                .AddressList[0]; // use AddressFamily.InterNetwork para garantir IPv4 se necessário

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 45323);

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    allDone.Reset();
                    Console.WriteLine("Waiting for incoming connection...");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        private static void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();

            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            ObjectState state = new ObjectState();
            state.wSocket = handler;
            handler.BeginReceive(state.buffer, 0, ObjectState.bufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        private static void ReadCallback(IAsyncResult ar)
        {
            ObjectState state = (ObjectState)ar.AsyncState;
            Socket handler = state.wSocket;

            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                string content = state.sb.ToString();

                if (content.IndexOf("<EOF>", StringComparison.Ordinal) > -1)
                {
                    Console.WriteLine($"Read {content.Length} bytes\nData: {content}");

                    Send(handler, content);
                }
                else
                {
                    handler.BeginReceive(state.buffer, 0, ObjectState.bufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
            }
        }

        private static void Send(Socket handler, string data)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            Socket handler = (Socket)ar.AsyncState;
            int bytesSent = handler.EndSend(ar);
            Console.WriteLine($"Sent {bytesSent} bytes to client.");

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
}
