const net = require('net');
const express = require('express');
const app = express();
const port = process.env.PORT || 3000;

// Configuração do servidor TCP
const tcpHost = '127.0.0.1/'; // Exemplo: '127.0.0.1' ou IP do servidor remoto
const tcpPort = 12345; // Porta do servidor TCP

// Função para enviar comandos via TCP
const sendTcpCommand = (command, callback) => {
  const client = new net.Socket();
  
  // Conecta ao servidor TCP
  client.connect(tcpPort, tcpHost, () => {
    console.log('Conectado ao servidor TCP');
    client.write(command);  // Envia o comando para o servidor TCP
  });

  // Recebe a resposta do servidor TCP
  client.on('data', (data) => {
    console.log('Resposta do servidor TCP: ' + data);
    callback(data.toString()); // Retorna a resposta ao cliente HTTP
    client.destroy(); // Fecha a conexão após receber a resposta
  });

  // Caso haja erro na conexão
  client.on('error', (err) => {
    console.log('Erro TCP: ' + err.message);
    callback('Erro na conexão com o servidor TCP');
  });
};

// Configuração do middleware para permitir requisições POST com JSON
app.use(express.json());

// Endpoint HTTP para receber comandos do cliente (site)
app.post('/enviar-comando', (req, res) => {
  const { comando } = req.body;

  if (!comando) {
    return res.status(400).send('Comando não fornecido');
  }

  // Envia o comando via TCP e responde ao cliente
  sendTcpCommand(comando, (response) => {
    res.send({ resposta: response });
  });
});

// Inicia o servidor HTTP
app.listen(port, () => {
  console.log(`Servidor HTTP rodando na porta ${port}`);
});
