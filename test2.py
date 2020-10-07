import asyncio
import time

async def coroutine_1(): #코루틴 정의
    print('코루틴 1 시작')
    print('코루틴 1 중단... 5초간 대기')
    #await로 중단점 설정(블락킹되는 부분에서 사용)
    await asyncio.sleep(5)
    print('코루틴1 재개')

async def coroutine_2():
    print('코루틴 2 시작')
    print('코루틴 2 중단... 4초간 대기')
    await asyncio.sleep(4)
    print('코루틴 2 재개')

if __name__ == '__main__':
    #이벤트 루프 정의
    loop = asyncio.get_event_loop()

    start = time.time()

    #2개의 코륀을 이벤트 루프에서 돌린다
    #코루틴이 여러개일 경우, asyncio.gather을 먼저 이용(순서대로 스케쥴링 된다)
    loop.run_until_complete((asyncio.gather(coroutine_1(), coroutine_2())))
    end = time.time()

    print(f'time taken : {end-start}')