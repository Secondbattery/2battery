import asyncio


async def run_client(host='127.0.0.1', port=9000):
  reader, writer = await asyncio.open_connection(host, port)
  bufsize = 1024

  while True:
    horizontal = 90.1
    message = str(horizontal)
    print('SENDING:', message)
    writer.write(message.encode())
    await writer.drain()

    data = await reader.read(bufsize)
    print('RECEIVED:', data.decode())
    if not message :
        writer.close()
        await writer.wait_closed()
    break

asyncio.get_event_loop()\
   .run_until_complete(run_client())