using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpMessageReceiver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly string tcpHost = "127.0.0.1"; // Substitua com o IP do seu servidor TCP
        private readonly int tcpPort = 12345; // Substitua pela porta do servidor TCP

        [HttpPost("enviar-comando")]
        public async Task<IActionResult> EnviarComando([FromBody] MessageRequest request)
        {
            if (string.IsNullOrEmpty(request.Comando))
            {
                return BadRequest("Comando não fornecido");
            }

            // Envia o comando via TCP
            var response = await SendTcpCommand(request.Comando);

            // Retorna a resposta para o cliente
            return Ok(new { resposta = response });
        }

        private async Task<string> SendTcpCommand(string command)
        {
            try
            {
                using (var client = new TcpClient())
                {
                    // Conecta ao servidor TCP
                    await client.ConnectAsync(tcpHost, tcpPort);

                    using (var stream = client.GetStream())
                    {
                        // Converte o comando em bytes e envia para o servidor TCP
                        byte[] data = Encoding.ASCII.GetBytes(command);
                        await stream.WriteAsync(data, 0, data.Length);

                        // Aguarda a resposta do servidor TCP
                        byte[] buffer = new byte[2048];
                        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                        return response;
                    }
                }
            }
            catch (SocketException ex)
            {
                return $"Erro ao conectar com o servidor TCP: {ex.Message}";
            }
        }
    }

    // Classe para mapear o JSON recebido no corpo da requisição
    public class MessageRequest
    {
        public string Comando { get; set; }
    }
}
