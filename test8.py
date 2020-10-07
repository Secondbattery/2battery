import asyncio
from random import random


async def run_server():
    # 서버를 생성하고 실행
    server = await asyncio.start_server(handler, host="127.0.0.1", port=9000)
    async with server:
        # serve_forever()를 호출해야 클라이언트와 연결을 수락합니다.
        await server.serve_forever()

async def handler(reader: asyncio.StreamReader, writer: asyncio.StreamWriter):
    while True:
        # 클라이언트가 보낸 내용을 받기
        data: bytes = await reader.read(1024)
        # 받은 내용을 출력하고,
        # 가공한 내용을 다시 내보내기
        peername = writer.get_extra_info('peername')
        print(f"[S] received: {len(data)} bytes from {peername}")
        mes = data.decode()
        print(f"[S] message: {mes}")
        res = mes.upper()[::-1]
        await asyncio.sleep(random() * 2)
        writer.write(res.encode())
        await writer.drain()

