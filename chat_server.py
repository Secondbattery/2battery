from socket import *
from threading import *
import time

def sends(sock):
    while True:
        sendData = input('[Server] : ')
        sock.send(sendData.encode('utf-8'))

def receives(sock):
    while True:
        recvData = sock.recv(1024)

        print(' ')
        print('<<< Client 메세지가 도착하였습니다.')
        print('[Client] : ', recvData.decode('utf-8'))

port = 9000
server_pro = socket(AF_INET, SOCK_STREAM)
server_pro.bind(('', port))
server_pro.listen(1)

print('%d번 포트가 대기 중입니다...'%port)

connectionsock, addr = server_pro.accept()

print(str(addr), '에서 접속되었습니다.')

senders = Thread(target=sends, args=(connectionsock, ))
receiver = Thread(target=receives, args=(connectionsock, ))

senders.start()
receiver.start()

while True:
    #time.sleep(1)
    pass
