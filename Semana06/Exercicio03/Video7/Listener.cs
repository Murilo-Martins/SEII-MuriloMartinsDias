using System;
using System.Net;
using System.Net.Sockets;

namespace Multi_Con_S
{
    class Listener
    {
        private Socket s;

        public bool Listening { get; private set; }

        public int Port { get; private set; }

        public Listener(int port)
        {
            this.Port = port;
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            if (Listening)
                return;

            s.Bind(new IPEndPoint(IPAddress.Any, Port));
            s.Listen(10); // número de conexões pendentes permitidas

            s.BeginAccept(callback, null);
            Listening = true;

            Console.WriteLine($"Servidor ouvindo na porta {Port}...");
        }

        public void Stop()
        {
            if (!Listening)
                return;

            s.Close();
            s.Dispose();
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Listening = false;
        }

        void callback(IAsyncResult ar)
        {
            try
            {
                Socket client = s.EndAccept(ar);

                // Dispara o evento para quem estiver ouvindo
                SocketAccepted?.Invoke(client);

                // Continua ouvindo
                s.BeginAccept(callback, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no callback: {ex.Message}");
            }
        }

        public delegate void SocketAcceptedHandler(Socket e);
        public event SocketAcceptedHandler SocketAccepted;
    }
}
