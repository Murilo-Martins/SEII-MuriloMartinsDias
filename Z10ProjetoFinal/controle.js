// controle.js

// Conectando ao WebSocket (ajuste o IP/porta conforme necessário)
const socket = new WebSocket('ws://192.168.0.100:3000'); // <-- Troque para o IP do seu servidor/app MAUI!

socket.onopen = function () {
    console.log('Conectado ao servidor WebSocket');
};

socket.onerror = function (error) {
    console.error('Erro WebSocket:', error);
};

function enviar(comando) {
    if (socket.readyState === WebSocket.OPEN) {
        socket.send(comando);
        console.log('Comando enviado:', comando);
    } else {
        console.error('WebSocket não está conectado.');
    }
}
