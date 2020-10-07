import asyncio
import time


async def coroutine_1():
    print('코루틴 1 시작')
    print('코루틴 1 중단... 5초간 기다립니다.')
    loop = asyncio.get_event_loop()
    # run_in_executor: 코루틴으로 짜여져 있지 않은 함수(서브루틴)을
    # 코루틴처럼 실행시켜주는 메소드

    # Params of run_in_executor:
    # executor(None: default loop executor), func, *args
    # 또는 concurrent.futures.Executor의 인스턴스 사용가능
    await loop.run_in_executor(None, time.sleep, 5)

    print('코루틴 1 재개')


async def coroutine_2():
    print('코루틴 2 시작')
    print('코루틴 2중단... 5초간 기다립니다.')
    loop = asyncio.get_event_loop()
    await loop.run_in_executor(None, time.sleep, 4)
    print('코루틴 2 재개')

if __name__ == "__main__":
    # 이벤트 루프 정의
    loop = asyncio.get_event_loop()

    # 두 개의 코루틴이 이벤트 루프에서 돌 수 있게 스케쥴링

    start = time.time()
    loop.run_until_complete(asyncio.gather(coroutine_1(), coroutine_2()))
    end = time.time()

    print(f'time taken: {end-start}')