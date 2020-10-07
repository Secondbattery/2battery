import enum
import select
from test import server


class Action(enum.Enum):
    READ = enum.auto() #enum.auto()를 사용면 자동으로 상수의 값을 할당할 수 있다.
    WRITE = enum.auto()


class Can:
    def __init__(self, action, sock): #초기화
        self.action = action
        self.sock = sock

    def __await__(self):
        yield self.action, self.sock
        #Generator는 Iterator를 생성해주는 함수
        #iterator는 next()함수를 통해 순차적으로 값을 가져오는 object
        #yield 문은 return 문처럼 함수가 값을 반환하고 정지하도록 하는데, 그 함수를 나중에 다시 실행하면 정지했던 위치부터 다시 실행되도록 한다.
        #yield 문이 포함된 함수는 일반 함수와 달리, 호출했을 때 생성기를 반환한다.


class AsyncSocket:
    def __init__(self, sock, *args, **kwargs):
        # *args : 여러 개의 인자를 함수로 받고자 할때 사용
        # **kwargs : (키워드 = 특정 값) 형태로 함수를 호출 (딕셔너리 형태)
        self.sock = sock
        super().__init__(*args, **kwargs)
        # super() : 자식클래스에서 부모클래스의 내용을 사용하고 싶은 경우


    #기존 def 키워드 앞에 async 키워드까지 붙이면 이 함수는 비동기 처리되며,
    #이러한 비동기 함수를 파이썬에서는 코루틴(coroutine)이라고도 부릅니다.
    async def accept(self):
        await Can(Action.READ, self.sock) #await로 비동기 작업을 대기한다
        return self.sock.accept()

    async def recv(self, length):
        await Can(Action.READ, self.sock)
        return self.sock.recv(length)

    async def send(self, data):
        if isinstance(data, str): #data가 str인지 확인하여 encoding
            data = data.encode()

        await Can(Action.WRITE, self.sock)
        self.sock.send(data)

    async def close(self):
        self.sock.close()


class TaskManager:
    current_task = None
    tasks = [] #당장 실행 가능한 대기 큐
    wait_read = {} #파일 읽기 대기큐
    wait_write = {} #파일 쓰기 대기큐

    def add_task(self, task): #당장 실행 가능한 대기 큐에 추가
        self.tasks.append(task)

    def run(self):
        while any((self.tasks, self.wait_read, self.wait_write)):
            while not self.tasks:
                readables, writables, _ = select.select(self.wait_read, self.wait_write, [])
                for sock in readables:
                    task = self.wait_read.pop(sock)
                    self.add_task(task)

                for sock in writables:
                    task = self.wait_write.pop(sock)
                    self.add_task(task)

            self.current_task = self.tasks.pop(0)

            try:
                action, sock = self.current_task.send(None)
            except StopIteration:
                continue

            if action is Action.READ:
                self.wait_read[sock] = self.current_task
            elif action is Action.WRITE:
                self.wait_write[sock] = self.current_task
            else:
                raise RuntimeError(f'wrong action {action}')


task_manager = TaskManager()


async def algorithm(value):
    return value * 2


async def handler(aclient):
    while True:
        req = await aclient.recv(100)  # size of bytes chuck
        if not req:
            await aclient.send('@ close connection\n'.encode())
            print('client accept')
            await aclient.close()
            return

        try:
            value = int(req)
        except ValueError:
            await aclient.send('@ enter integer\n'.encode())
            await aclient.close()
            return

        resp = await algorithm(value)
        await aclient.send(f'> {resp}\n'.encode())


async def server(host, port):
    sock = server.socket()
    # SOL_SOCKET + SO_REUSEADDR: reuse already used address
    sock.setsockopt(server.SOL_SOCKET, server.SO_REUSEADDR, 1)
    sock.bind((host, port,))
    # 5 is max number of queued connections
    # https://docs.python.org/2/library/socket.html#socket.socket.listen
    sock.listen(5)
    asock = AsyncSocket(sock)
    print('[server info : ({}:{})]'.format(host, port))
    while True:
        client, client_address = await asock.accept()
        aclient = AsyncSocket(client)
        await aclient.send('@ connect\n')
        print('Accept Cli{}'.format(client))
        task_manager.add_task(handler(aclient))


if __name__ == '__main__':
    task_manager.add_task(server('127.0.0.1', 9000))
    task_manager.run()