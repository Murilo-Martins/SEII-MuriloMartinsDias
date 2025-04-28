// servidor.js

const WebSocket = require('ws');

// Cria um servidor WebSocket na porta 3000
const wss = new WebSocket.Server({ port: 3000 });

console.log('Servidor WebSocket rodando na porta 3000...');

wss.on('connection', (ws) => {
    console.log('Novo cliente conectado!');

    ws.on('message', (message) => {
        console.log('Mensagem recebida:', message.toString());
    });

    ws.on('close', () => {
        console.log('Cliente desconectado.');
    });
});
