import asyncio
from random import random
import sqlite3 as sqlite


_host = '127.0.0.1'
_port = 9000


#asyncio socket server/client
# async def run_client(host: str, port: int):
#     # 서버와의 연결을 생성합니다.
#     reader: asyncio.StreamReader
#     writer: asyncio.StreamWriter
#     reader, writer = await asyncio.open_connection(host, port)
#
#     # show connection info
#     print("[C] connected")
#
#     # 루프를 돌면서 입력받은 내용을 서버로 보내고,
#     # 응답을 받으면 출력합니다.
#     while True:
#         line = input("[C] enter message: ")
#         if not line:
#             break
#
#         # 입력받은 내용을 서버로 전송
#         payload = line.encode()
#         writer.write(payload)
#         await writer.drain()
#         print(f"[C] sent: {len(payload)} bytes.\n")
#
#         # 서버로부터 받은 응답을 표시
#         data = await reader.read(1024)  # type: bytes
#         print(f"[C] received: {len(data)} bytes")
#         print(f"[C] message: {data.decode()}")
#
#     # 연결을 종료합니다.
#     print("[C] closing connection…")
#     writer.close()
#     await writer.wait_closed()


# def save_Unit_table(column, cli_mes): #Unit_factory테이블의 해당 cloumn에 cli_mes 저장하는 함수
#     conn = sqlite.connect("DB.db") #DB파일에 연결
#     c=conn.cursor() #커서획득
#
#     c.execute("INSERT INTO Unit_factory{0} VALUES{1}".format(column, cli_mes))
#
#     conn.commit()  # 트랜젝션의 내용을 DB에 반영함
#     conn.close() #커서닫기
#
#
# def save_Result_table(column, cli_mes): #Result테이블의 해당 cloumn에 cli_mes 저장하는 함수
#     conn = sqlite.connect("DB.db") #DB파일에 연결
#     c=conn.cursor() #커서획득
#
#     c.execute("INSERT INTO Result{0} VALUES{1}".format(column, cli_mes))
#
#     conn.commit()  # 트랜젝션의 내용을 DB에 반영함
#     conn.close() #커서닫기



async def handler(reader: asyncio.StreamReader, writer: asyncio.StreamWriter):
    no = 0
    while True:
        # 클라이언트가 보낸 내용을 받기
        data: bytes = await reader.read(1024)
        # 받은 내용을 출력하고,
        # 가공한 내용을 다시 내보내기
        if data != None:
            peername = writer.get_extra_info('peername')
            print(f"[S] received: {len(data)} bytes from {peername}")

            cli_mes = data.decode() #client에서 보내준 data를 decode

            if cli_mes.startswith('TOC'): # Rasp에서 C#으로 보내줄 data 서버에 출력
                print("[Rasp_Client] message: {}".format(cli_mes[3:]))

            elif cli_mes.startswith('TOR'): # C#에서 Rasp로 보내줄 data 서버에 출력
                print("[C#_Client] message: {}".format(cli_mes[3:]))



            #DB연결 시작
            no+=1

            conn = sqlite.connect("DB.db")  # DB파일에 연결
            c = conn.cursor()  # 커서획득

            #테이블에 데이터 INSERT
            if cli_mes.startswith('TORUnit_date'):
                insert_cli_mes = cli_mes.replace('TORUnit_date','').split(',')
                index_cli_mes = insert_cli_mes[1]

                for no in range(1, int(index_cli_mes)+1):
                    c.execute('''INSERT INTO Unit_factory(Unit_date, Unit_no)
                                 VALUES(%s,%d)''' % (insert_cli_mes[0], no))

                c.execute('''INSERT INTO Result(Result_date)
                             VALUES(%s)''' % (insert_cli_mes[0]))

            elif cli_mes.startswith('TOCUnit_horizon'):
                insert_cli_mes = cli_mes.replace('TOC','').split(',')
                #insert_cli_mes 순서 => [Unit_horizon, Unit_vertical, Unit_hpass, Unit_vpass]

                if no>=1 and no<=index_cli_mes:
                    c.execute('''UPDATE Unit_factory SET 
                                Unit_horizon = %s, Unit_vertical = %s, 
                                Unit_hpass = %s, Unit_vpass = %s
                                WHERE Unit_no = %d'''
                                % (insert_cli_mes[0][12:],insert_cli_mes[1][13:],
                                   insert_cli_mes[2][10:],insert_cli_mes[3][10:], no) )


            # elif cli_mes.startswith('TORhStandard'):
            #     insert_cli_mes = cli_mes.replace('TORhStandard','')
            #     c.execute('''INSERT INTO Result(hStandard)
            #                  VALUES(%s)''' % (insert_cli_mes))
            #
            # elif cli_mes.startswith('TORvStandard'):
            #     insert_cli_mes = cli_mes.replace('TORvStandard','')
            #     c.execute('''INSERT INTO Result(vStandard)
            #                  VALUES(%s)''' % (insert_cli_mes))
            #
            # elif cli_mes.startswith('TOCAQL_hpass'):
            #     insert_cli_mes = cli_mes.replace('TOCAQL_hpass','')
            #     c.execute('''INSERT INTO Result(AQL_hpass)
            #                  VALUES(%s)''' % (insert_cli_mes))
            #
            # elif cli_mes.startswith('TOCAQL_vpass'):
            #     insert_cli_mes = cli_mes.replace('TOCAQL_vpass','')
            #     c.execute('''INSERT INTO Result(AQL_vpass)
            #                  VALUES(%s)''' % (insert_cli_mes))
            #
            # elif cli_mes.startswith('TOChMean'):
            #     insert_cli_mes = cli_mes.replace('TOChMean','')
            #     c.execute('''INSERT INTO Result(hMean)
            #                  VALUES(%s)''' % (insert_cli_mes))
            #
            # elif cli_mes.startswith('TOCvMean'):
            #     insert_cli_mes = cli_mes.replace('TOCvMean', '')
            #     c.execute('''INSERT INTO Result(vMean)
            #                  VALUES(%s)''' % (insert_cli_mes))
            #
            # elif cli_mes.startswith('TOChSigma'):
            #     insert_cli_mes = cli_mes.replace('TOChSigma', '')
            #     c.execute('''INSERT INTO Result(hSigma)
            #                  VALUES(%s)''' % (insert_cli_mes))
            #
            # elif cli_mes.startswith('TOCvSigma'):
            #     insert_cli_mes = cli_mes.replace('TOCvSigma', '')
            #     c.execute('''INSERT INTO Result(vSigma)
            #                  VALUES(%s)''' % (insert_cli_mes))
            #
            # elif cli_mes.startswith('TOChCp'):
            #     insert_cli_mes = cli_mes.replace('TOChCp', '')
            #     c.execute('''INSERT INTO Result(hCp)
            #                  VALUES(%s)''' % (insert_cli_mes))
            #
            # elif cli_mes.startswith('TOCvCp'):
            #     insert_cli_mes = cli_mes.replace('TOCvCp', '')
            #     c.execute('''INSERT INTO Result(vCp)
            #                  VALUES(%s)''' % (insert_cli_mes))

            conn.commit()  # 트랜젝션의 내용을 DB에 반영함
            conn.close()  # 커서닫기


            await asyncio.sleep(0.2) #대기

            serv_mes = input('[Server] : ')
            writer.write(serv_mes.encode())
            await writer.drain()


async def run_server():
    # 서버를 생성하고 실행
    server = await asyncio.start_server(handler, host=_host, port=_port)
    async with server:
        # serve_forever()를 호출해야 클라이언트와 연결을 수락합니다.
        await server.serve_forever()


async def main():
    # await asyncio.wait([run_server(), run_client(_host, _port)])
    await asyncio.wait([run_server()])


if __name__ == "__main__":
    asyncio.run(main())