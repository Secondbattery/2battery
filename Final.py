import sqlite3 as sqlite
import socket
import re
import math
import time
import random
import numpy

p1 = [(5,1)]*100
p2 = [(96,1), (92,1), (100,1), (95,1), (95,1), (97,1), (96,1), (96,1), (95,1), (94,1),
      (97,1), (93,1), (99.1,1), (94,1), (95,1), (97,1), (96,1), (96,1), (98,1), (94,1),
      (96,1), (95,1), (96,1), (94,1), (95,1), (95,1), (96,1), (96,1), (95,1), (96,1)]*3\
     +[(96,1), (97,1), (94,1), (93,1), (95,1), (94,1), (95,1), (96,1), (97,1), (93,1)]

HOST = '127.0.0.1'
PORT = 9000  # 0~65535. 0~1023은 예약되어 있음. 5000번부터 사용.
Unit_horizon = [] #측정된 가로치수 넣어주는 리스트
Unit_pass = [] #측정된 치수들의 불량여부
h_standard = 90.0  # 가로규격
lot=100
Unit_number = -1

#DB 생성(오토커밋)
conn = sqlite.connect("test.db",isolation_level=None)
#커서획득
c=conn.cursor()

def Dot_Distance(x1, y1, x2, y2):  # 좌표값으로 가로 치수 측정
    result_horizon  = round(math.sqrt(math.pow(abs(x1 - x2), 2) + math.pow(abs(y1 - y2), 2)), 1)
    return result_horizon

def Unit_Defect(Unit_number, Result_horizon): # 측정된 치수들 규격과 비교하기
    if (Result_horizon >= (h_standard * 0.96)) and (Result_horizon <= (h_standard * 1.04)):  # 규격의 +-4.0%의 오차범위 지정
        result = 1  # 양품
    else:
        result = 0  # 불량품
    return result

def Sample_Letter(lot):  # G2 검사 수준으로 샘플링 글자 추출
    if lot >= 1 and lot <= 8:
        letter = 'A'
    elif lot >= 9 and lot <= 15:
        letter = 'B'
    elif lot >= 16 and lot <= 25:
        letter = 'C'
    elif lot >= 26 and lot <= 50:
        letter = 'D'
    elif lot >= 51 and lot <= 90:
        letter = 'E'
    elif lot >= 91 and lot <= 150:
        letter = 'F'
    elif lot >= 151 and lot <= 280:
        letter = 'G'
    elif lot >= 281 and lot <= 500:
        letter = 'H'
    elif lot >= 501 and lot <= 1200:
        letter = 'J'
    elif lot >= 1201 and lot <= 3200:
        letter = 'K'
    elif lot >= 3201 and lot <= 10000:
        letter = 'L'
    elif lot >= 10001 and lot <= 35000:
        letter = 'M'
    elif lot >= 35001 and lot <= 150000:
        letter = 'N'
    elif lot >= 150001 and lot <= 500000:
        letter = 'P'
    elif lot >= 500001:
        letter = 'Q'
    return letter

def AQL_Chart(Unit_pass, letter):  # 기준오차율을 4.0으로 지정하여 AQL검사
    Re = 0  # Re값 초기화
    sample = []  # Unit_pass에서 샘플링갯수만큼 랜덤으로 넣어주는 리스트
    sample_defect = 0  # sample에서 불량품 개수의 초기값
    if letter == 'A' or letter == 'B':
        sample = random.sample(Unit_pass, 3)
        Re = 1
    elif letter == 'C' or letter == 'D' or letter == 'E':
        sample = random.sample(Unit_pass, 13)
        Re = 2
    elif letter == 'F':
        sample = random.sample(Unit_pass, 20)
        Re = 3
    elif letter == 'G':
        sample = random.sample(Unit_pass, 32)
        Re = 4
    elif letter == 'H':
        sample = random.sample(Unit_pass, 50)
        Re = 6
    elif letter == 'J':
        sample = random.sample(Unit_pass, 80)
        Re = 8
    elif letter == 'K':
        sample = random.sample(Unit_pass, 125)
        Re = 11
    elif letter == 'L':
        sample = random.sample(Unit_pass, 200)
        Re = 15
    elif letter == 'M' or letter == 'N' or letter == 'P' or letter == 'Q' or letter == 'R':
        sample = random.sample(Unit_pass, 315)
        Re = 22
    for i in sample:  # 추출된 샘플 안에서 불량품개수 count
        if i == 0:
            sample_defect += 1
        elif i == 1:
            continue
    if sample_defect >= Re:
        AQL_pass = 0
    elif sample_defect < Re:
        AQL_pass = 1
    return AQL_pass

def Avg(Unit_horizon):  # 평균함수
    avg = numpy.mean(Unit_horizon)
    return round(avg, 2)

def Sigma(Unit_horizon):  # 표준편차함수
    sigma = numpy.std(Unit_horizon)
    return round(sigma, 2)

def PCA(sigma, h_standard):
    USL = h_standard * 1.04  # 규격상한
    LSL = h_standard * 0.96
    Cp = (USL - LSL) / (6 * sigma)
    return round(Cp, 2)

def start(Unit_number):
    print(Unit_number)
    Result_horizon = Dot_Distance(p1[Unit_number][0], p1[Unit_number][1], p2[Unit_number][0], p2[Unit_number][1])
    Unit_horizon.append(Result_horizon)
    print(Result_horizon)
    Result_pass = Unit_Defect(Unit_number, Result_horizon)
    #LED켜기
    print(Result_pass)
    Unit_pass.append(Result_pass)


    # Unit_factory 테이블 데이터 삽입
    c.execute('''INSERT INTO Unit_factory(Unit_no, Unit_horizon, Unit_pass)
        VALUES(%d,%f,%d)''' % (Unit_number, Result_horizon, Result_pass) )

    if Unit_number == 5:
        print('최종결과값이여유~')
        AQL_pass = AQL_Chart(Unit_pass, Sample_Letter(Unit_number))
        print(AQL_pass)
        time.sleep(0.5)

        Deviation = Sigma(Unit_horizon)
        print(Deviation)
        time.sleep(0.5)

        Mean = Avg(Unit_horizon)
        print(Mean)
        time.sleep(0.5)

        Cp = PCA(Deviation, h_standard)
        print(Cp)

        # Result_factory 테이블 데이터 삽입
        c.execute('''INSERT INTO Result_factory(Unit_no, AQL_pass, Sigma, Mean, Cp)
                    VALUES(%d,%d,%f,%f,%f)''' % (Unit_number, AQL_pass, Deviation, Mean, Cp))
        return



while True:
    a = input("물건이 들어왔나유?")
    if a=='y':
        Unit_number+=1
        start(Unit_number)
    else:
        break