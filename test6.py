import asyncio

async def handle_conn(reader, writer):
  # 입출력 핸들러는 항상 StreamReader, StreamWriter를 인자로 받는다.
  addr = writer.get_extra_info('peername')
  while True:
    data = await reader.read(8)
    msg = data.decode()
    print("RECEIVED {} FROM {}".format(msg, addr))
    print("SENDING {}".format(msg))
    writer.write(data)
    await writer.drain()
    if msg == '100.5':
      print("CLOSING")
      writer.close()
      await writer.wait_closed()
      break

async def run_server(host='127.0.0.1', port=9000):
  server = await asyncio.start_server(handle_conn, host, port)
  addr = server.sockets[0].getsockname()
  print("SERVING ON {}".format(addr))

  async with server:
    await server.serve_forever()

asyncio.get_event_loop().run_until_complete(run_server())