import socket

HOST = '192.168.101.101'  
PORT = 9008

s = socket.socket( socket.AF_INET, socket.SOCK_STREAM )
s.connect( ( HOST, PORT ) )


while True:
    yn = input("컨베이어 벨트 작동하시겠습니까?(y/n)")
    s.send(yn.encode())
    if yn == "y":
        break
try:
    while True:
    
        recv_messages = s.recv(20).decode()
        print(recv_messages)
        if "Cp" in recv_messages:
            while True:
                yn = input("컨베이어 벨트를 스탑 하시겠습니까?(y/n)")
                s.send(yn.encode())
                if yn == "y":
                    break
            break
                    
except (ValueError, KeyboardInterrupt):
    print( '[ Server Message ( Exception ) : non numeric' )
    print( '[ Server Message ( Exception ) : close client connection' )
    s.close()
finally:
    s.close()
