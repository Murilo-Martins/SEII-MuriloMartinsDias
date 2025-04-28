// Conectando ao servidor WebSocket (no C#)
const socket = new WebSocket('ws://localhost:8080');  // Ajuste o IP/porta conforme necessário

// Quando a conexão for estabelecida
socket.onopen = function() {
    console.log('Conectado ao servidor WebSocket');
    // Enviar uma mensagem para o servidor assim que a conexão for estabelecida
    socket.send('Olá, servidor!');
};

// Quando o servidor enviar uma mensagem
socket.onmessage = function(event) {
    console.log('Mensagem recebida do servidor:', event.data);
};

// Caso ocorra um erro na conexão
socket.onerror = function(error) {
    console.error('Erro WebSocket:', error);
};

// Caso a conexão seja fechada
socket.onclose = function() {
    console.log('Conexão WebSocket fechada');
};

// Enviar comando para o servidor a partir de um input ou ação do usuário
function enviarComando(comando) {
    if (socket.readyState === WebSocket.OPEN) {
        socket.send(comando);
        console.log('Comando enviado:', comando);
    } else {
        console.error('WebSocket não está conectado.');
    }
}

// Exemplo de chamada de envio de comando
enviarComando('Comando do cliente');
