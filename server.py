# echo-server.py
import socket
import sqlite3 as sqlite
import re

HOST = '127.0.0.1'
PORT = 9000  # 0~65535. 0~1023은 예약되어 있음. 5000번부터 사용.
Unit_horizon = []
# DB 생성(오토커밋)
conn = sqlite.connect("test.db", isolation_level=None)
# 커서획득
c = conn.cursor()


def db_commit():
    conn.commit()
    conn.close()  # 연결 닫기


def db_horizon():
    # 데이터 불어오기
    c.execute("SELECT Unit_horizon FROM Unit_factory")
    for row in c:
        row = "Distance" + re.sub('[(),]', '', str(row))
        Unit_horizon.append(row)

    return Unit_horizon


server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)  # 서버소켓 옵션변경

server_socket.bind((HOST, PORT))  # 서버의 호스트 아이디와 포트 반드시 튜플로 바인딩. 서버포트와 아이피주소 설정-바인드
server_socket.listen()  # client 연결될 때 까지 대기
client_socket, addr = server_socket.accept()  # client와 연결 성공을 의미
# server_socket은 연결대기소켓 // client_socket은 연결소켓(실제통신하는 소켓). addr은 연결된 client의 ip와 포트번호
print('[ Server Message : Connected by {} ]'.format(addr))

while True:
    data = client_socket.recv(1024)  # data의 최대크기 1024byte. client에 수신된 정보를 data에 넣음
    if not data:
        break
    c = int(data)
    print('[ Server Message : received from [{0}] -> {1} ]'.format(addr, data.decode()))
    db_horizon()
    Distance = Unit_horizon[c]

    client_socket.sendall(Distance.encode())
    db_commit()

# 항상 닫아줘야함. 안닫아주면 소켓이 계속 물려있음.
client_socket.close()
server_socket.close()

print('[ Stop Server ]')
