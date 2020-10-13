import asyncio
from random import random
import sqlite3 as sqlite


_host = '127.0.0.1'
_port = 9000


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


            #DB저장하기
            no+=1 #해당 index에 값을 넣어주기 위해 추가

            conn = sqlite.connect("DB.db")  # DB파일에 연결
            c = conn.cursor()  # 커서획득

            #Unit_factory 테이블에 데이터 INSERT
            if cli_mes.startswith('TORUnit_date'):
                insert_cli_mes = cli_mes.replace('TORUnit_date','').split(',')
                index_cli_mes = insert_cli_mes[1]
                send_cli_mes = 'TORUnit_no' + insert_cli_mes[1]

                # C#_client로 입력받은 로트를 Rasp_client에 전송
                payload = send_cli_mes.encode()
                writer.write(payload)
                await writer.drain()
                print("[Server] sent: {}".format(send_cli_mes))


                for no in range(1, int(index_cli_mes)+1): #로트 크기만큼 Unit_date 값 넣어주기
                    c.execute('''INSERT INTO Unit_factory(Unit_date, Unit_no)
                                 VALUES(%s, %s)''' % (insert_cli_mes[0], no))

                c.execute('''INSERT INTO Result(Result_date)
                             VALUES(%s)''' % (insert_cli_mes[0]))


            elif cli_mes.startswith('TOCUnit_no'):
                insert_cli_mes = cli_mes.replace('TOC','').split(',')
                #insert_cli_mes 순서 => [Unit_no, Unit_horizon, Unit_vertical, Unit_hpass, Unit_vpass

                # 입력받은 로트를 C#_client에 전송
                payload = cli_mes.encode()
                writer.write(payload)
                await writer.drain()
                print("[Server] sent: {}".format(cli_mes))

                #DB파일에 저장
                c.execute('''UPDATE Unit_factory SET  
                            Unit_horizon = %s, Unit_vertical = %s, 
                            Unit_hpass = %s, Unit_vpass = %s
                            WHERE Unit_no = %s'''
                            % (insert_cli_mes[1][12:],insert_cli_mes[2][13:],
                               insert_cli_mes[3][10:],insert_cli_mes[4][10:],
                               insert_cli_mes[0][7:]) )




            #Result 테이블에 데이터 삽입
            elif cli_mes.startswith('TORStandard'):
                insert_cli_mes = cli_mes.replace('TOR','').split(',')

                # C#_client로 입력 받은 규격을 Rasp_client에 전송
                payload = cli_mes.encode()
                writer.write(payload)
                await writer.drain()
                print("[Server] sent: {}".format(cli_mes))

                c.execute('''INSERT INTO Result(hStandard, vStandard)
                             VALUES(%s, %s)''' % (insert_cli_mes[0][9:], insert_cli_mes[1][9:]))

            elif cli_mes.startswith('TOCAQL_hpass'):
                insert_cli_mes = cli_mes.replace('TOC','').split(',')
                #insert_cli_mes 순서 => [AQL_hpass, AQL_vpass, hMean, vMean, hSigma, vSigma, hCp, vCp]

                # C#_client로 입력 받은 결과값을 Rasp_client에 전송
                payload = cli_mes.encode()
                writer.write(payload)
                await writer.drain()
                print("[Server] sent: {}".format(cli_mes))

                c.execute('''UPDATE Result SET 
                            AQL_hpass = %s, AQL_vpass = %s, 
                            hMean = %s, vMean = %s,
                            hSigma = %s, vSigma = %s,
                            hCp = %s, vCp = %s'''
                            % (insert_cli_mes[0][9:],insert_cli_mes[1][9:],
                               insert_cli_mes[2][5:],insert_cli_mes[3][5:],
                               insert_cli_mes[4][6:], insert_cli_mes[5][6:],
                               insert_cli_mes[6][3:], insert_cli_mes[7][3:]) )

            conn.commit()  # 트랜젝션의 내용을 DB에 반영함
            conn.close()  # 커서닫기


            await asyncio.sleep(0.2) #대기

            serv_mes = 'Success'
            writer.write(serv_mes.encode())
            await writer.drain()
            print("[Server] sent: {}".format(serv_mes))


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