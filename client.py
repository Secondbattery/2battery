from socket import *
from threading import *
import time
from opencv_capture import *

def sends(sock):
    while True:
        sendData = 'TOCUnit_date'+input('입력하세용')
        sock.send(sendData.encode('utf-8'))

def receives(sock):
    while True:
        recvData = sock.recv(1024)

        print(' ')
        print('<<< Server 메세지가 도착하였습니다.')
        print('[Server] : ',recvData.decode('utf-8'))

port = 9000
socket_client = socket(AF_INET, SOCK_STREAM)
socket_client.connect(('192.168.0.126',port))

print('접속완료')

sender = Thread(target=sends, args=(socket_client, ))
receive = Thread(target=receives, args=(socket_client, ))

sender.start()
receive.start()

while True:
    #time.sleep(1)
    pass