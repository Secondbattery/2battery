#Async socket server example code

import asyncio

async def handle_asyncclient(reader, writer):
    # 입출력 핸들러는 항상 StreamReader, StreamWriter를 인자로 받는다.
    print('client :', writer.get_extra_info('peername')) #'peername': 소켓이 연결된 원격 주소

    while True:
        data = await reader.read(8) #최대 8바이트까지 읽고, 읽어들인 바이트를 반환한다.
        if data :
            writer.write(b'pong')
            await writer.drain()
            #drain() : 스트림에 다시 기록할 수 있을 때 까지 기다린다.
            #이 동작은 쓰기 버퍼의 수위가 높아지는 동안 버퍼에 과다한 데이터가 들어가는 것을 막는다.
            print('recv: ping -> send: pong')
        elif data == b'done':
            print('recv: done')
            break
        elif len(data) == 0:
            break

    writer.close()
    await writer.wait_closed() #wait_closed() : 스트림이 닫힐 때 까지 기다린다.
    print('connection was closed')


async def server_asyncmain():
    server = await asyncio.start_server(handle_asyncclient, 'localhost', 8000)
    if server is not None:
        print('server started')
        #
        await asyncio.sleep(60)
        server.close()
        await server.wait_closed()
        print('server was closed')


if __name__ == "__main__":

    try:
        loop = asyncio.get_running_loop()
    except RuntimeError:
        loop = None

    if loop and loop.is_running():
        print('Async event loop already running')
        tsk = loop.create_task(server_asyncmain())
    else:
        print('Starting new event loop')
        asyncio.run(server_asyncmain())