document.addEventListener('DOMContentLoaded', function() {
    const btnUp = document.getElementById('btn-up');
    const btnLeft = document.getElementById('btn-left');
    const btnDown = document.getElementById('btn-down');
    const btnRight = document.getElementById('btn-right');

    // Função para enviar o comando para o backend
    const sendCommand = (command) => {
        const url = 'https://blue-river-0f0c3731e.6.azurestaticapps.net/'; // Substitua pela URL do seu backend

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ comando: command })
        })
        .then(response => response.json())
        .then(data => {
            console.log('Resposta do servidor TCP:', data.resposta);
        })
        .catch(error => {
            console.error('Erro ao enviar comando:', error);
        });
    };

    // Adiciona evento de clique para cada botão de controle
    btnUp.addEventListener('click', function() {
        sendCommand('move_up');
    });

    btnLeft.addEventListener('click', function() {
        sendCommand('move_left');
    });

    btnDown.addEventListener('click', function() {
        sendCommand('move_down');
    });

    btnRight.addEventListener('click', function() {
        sendCommand('move_right');
    });
});
