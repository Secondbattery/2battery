import socket

host = '192.168.0.121'
port = 7770
client_socket = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
client_socket.connect((host,port))
while True:

    print('1. LED 1번 켜기')
    print('2. LED 1번 끄기')
    print('3. LED 2번 켜기')
    print('4. LED 2번 끄기')
    print('5. 모터 정방향')
    print('6. 모터 역방향')
    print('7. 모터 정지')
    print('\n')

    cl = input('입력하거라 ')

    if int(cl) >7 or int(cl)<1:
        break


    client_socket.send(cl.encode())

data = client_socket.recv(2)
print('\t[client message : received : {} ]'.format(data.decode()))
client_socket.close()
print('\t[stop cli]')
# print(data)
# client_socket.close()
# print('\t[stop cli]')