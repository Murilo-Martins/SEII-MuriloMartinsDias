using Microsoft.Maui.Controls;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketMauiApp
{
    public partial class MainPage : ContentPage
    {
        private ClientWebSocket _webSocket;

        public MainPage()
        {
            InitializeComponent();
            _webSocket = new ClientWebSocket();
        }

        // Método para conectar ao WebSocket
        private async void ConnectButton_Clicked(object sender, EventArgs e)
        {
            Uri serverUri = new Uri("ws://localhost:3000");
            await _webSocket.ConnectAsync(serverUri, CancellationToken.None);
            Console.WriteLine("Conectado ao WebSocket.");
        }

        // Método para enviar mensagem
        private async void SendButton_Clicked(object sender, EventArgs e)
        {
            if (_webSocket.State == WebSocketState.Open)
            {
                string message = "Olá, servidor!";
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                await _webSocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
                Console.WriteLine("Mensagem enviada: " + message);
            }
            else
            {
                Console.WriteLine("Não conectado ao WebSocket.");
            }
        }

        // Método para fechar a conexão
        private async void CloseButton_Clicked(object sender, EventArgs e)
        {
            if (_webSocket.State == WebSocketState.Open)
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Fechando a conexão", CancellationToken.None);
                Console.WriteLine("Conexão fechada.");
            }
        }
    }
}
