using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Text;

namespace TcpMessageReceiver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TcpController : ControllerBase
    {
        private readonly string tcpHost = "ENDERECO_DO_SERVIDOR_TCP"; // Substitua com o IP ou endereço do servidor TCP
        private readonly int tcpPort = 12345; // Substitua pela porta correta

        // Endpoint para enviar comando via TCP
        [HttpPost("enviar-comando")]
        public IActionResult EnviarComando([FromBody] ComandoDto comando)
        {
            if (comando == null || string.IsNullOrEmpty(comando.Comando))
            {
                return BadRequest("Comando não fornecido.");
            }

            try
            {
                // Envia o comando via TCP e obtém a resposta
                var resposta = EnviarComandoTcp(comando.Comando);
                return Ok(new { resposta });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao se comunicar com o servidor TCP: {ex.Message}");
            }
        }

        // Função que se conecta ao servidor TCP e envia o comando
        private string EnviarComandoTcp(string comando)
        {
            using (var client = new TcpClient(tcpHost, tcpPort))
            {
                var stream = client.GetStream();
                byte[] dados = Encoding.ASCII.GetBytes(comando);
                stream.Write(dados, 0, dados.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                return Encoding.ASCII.GetString(buffer, 0, bytesRead);
            }
        }
    }

    // DTO para o comando
    public class ComandoDto
    {
        public string Comando { get; set; }
    }
}
