'''O socket tem bastante influencia ao tratar de servidores
com grande quantidade de requisicoes e chamadas'''

# --- Importando os modulos necessarios ---
import socket       #modulo para sockets
import threading    #modulo para threads
import time         #modulo para tempo e data

PORT = 5050         #porta de acesso
FORMATO = 'utf-8'   #formato para codificacao
SERVER = "192.168.0.109"    #IP do servidor 
ADDR = (SERVER, PORT)       #Address do servidor

client = socket.socket(socket.AF_INET, socket.SOCK_STREAM) #declarando o client
client.connect(ADDR)    #atribuindo as características do client (server, PORT)


def handle_mensagens(): #gerenciamento de mensagens
    while(True):
        msg = client.recv(1024).decode()    #decodificacao e tamanho da mensagem
        mensagem_splitada = msg.split("=")  #separa o conteudo da mensagem
        print(mensagem_splitada[1] + ": " + mensagem_splitada[2])

def enviar(mensagem):
    client.send(mensagem.encode(FORMATO))   #envia o formato de decodificacao

def enviar_mensagem():  #envia a mensagem
    mensagem = input()  #mensagem lida pelo terminal
    enviar("msg=" + mensagem)   #metodo de envio da mensagem

def enviar_nome():      #envia o nome da pessoa (client)
    nome = input('Digite seu nome: ')   #leitura via terminal
    enviar("nome=" + nome)  #envio do nome

def iniciar_envio():    #realiza o inicio do envio da mensagem
    enviar_nome()       #envia o nome do cliente
    enviar_mensagem()   #envia a mensagem


# existirao duas threads. uma para cuidar do gerenciamento de mensagens e outra para iniciar o envio
def iniciar():
    thread1 = threading.Thread(target=handle_mensagens)
    thread2 = threading.Thread(target=iniciar_envio)
    thread1.start()
    thread2.start()

iniciar()