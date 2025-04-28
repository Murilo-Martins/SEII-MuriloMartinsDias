using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Microsoft.Maui.Controls;

namespace Cliente
{
    public partial class MainPage : ContentPage
    {
        static Socket sock;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StartTcpClient();
        }

        // Método para conectar ao servidor TCP
        private void StartTcpClient()
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Solicita o IP do servidor e a porta
            string ip = "127.0.0.1"; // Defina o IP ou pegue de algum lugar (ex. configurado no site)
            int port = 12345; // Defina a porta que o servidor vai escutar

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

                            // Atualize o conteúdo da interface com a mensagem recebida
                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                // Aqui você pode atualizar a interface com a nova mensagem
                                messageLabel.Text = msg; // Exemplo de label para mostrar a mensagem
                            });
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Desconectado do servidor!");
                        sock.Close();
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
}
