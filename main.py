import math
# import RPi.GPIO as GPIO
import time
import random
import numpy

p1 = []
p2 = []

lot = 10


def Append_Dot(dot1, dot2):  # Opencv에서 불러온 꼭지점 좌표 append
    p1.append(dot1)
    p2.append(dot2)


p1 = [(1, 1), (1.1, 1), (0.8, 1), (1.2, 1), (1.3, 1), (1, 1), (2.7, 1), (1, 1), (1, 1), (1, 1)]
p2 = [(10, 1), (10, 1), (10, 1), (10, 1), (10, 1), (14, 1), (12, 1), (10.9, 1), (9.5, 1), (10, 1)]

# ----------------------------------------------------------------------------------------------

Unit_horizon = []


def Dot_Distance(x1, y1, x2, y2):  # 좌표값으로 가로 치수 측정
    result_horizon = round(math.sqrt(math.pow(abs(x1 - x2), 2) + math.pow(abs(y1 - y2), 2)), 1)
    return result_horizon


for i in range(lot):
    Unit_horizon.append(Dot_Distance(p1[i][0], p1[i][1], p2[i][0], p2[i][1]))

# print(Unit_horizon)

# ----------------------------------------------------------------------------------------------

unit_pass = []
h_standard = 9.0  # 가로규격


def Unit_Defect(Unit_horizon):
    # 측정된 치수와 규격비교하기
    for i in range(lot):
        if (Unit_horizon[i] >= (h_standard * 0.96)) and (Unit_horizon[i] <= (h_standard * 1.04)):  # 규격의 +-4.0%의 오차범위 지정
            result = 1  # 양품
        else:
            result = 0  # 불량품
        unit_pass.append(result)
    return unit_pass


# print(Unit_Defect(Unit_horizon))

# ----------------------------------------------------------------------------------------------

def LED_OnOff(unit_pass):  # 불량이면 LED1 ON, 양품이면 LED2 ON
    GPIO.setmode(GPIO.BCM)
    led1 = 14
    led2 = 15
    GPIO.setup(led1, GPIO.OUT)
    GPIO.setup(led2, GPIO.OUT)

    try:
        for i in unit_pass:
            GPIO.output(led1, False)
            GPIO.output(led2, False)
            time.sleep(1)
            if i == 0:
                GPIO.output(led1, True)
            elif i == 1:
                GPIO.output(led2, True)
            time.sleep(1)
    finally:
        GPIO.cleanup()


# ----------------------------------------------------------------------------------------------

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


# print(Sample_Letter(lot))

# ------------------------------------------------------------------------------------------

def AQL_Chart(unit_pass, letter):  # 기준오차율을 4.0으로 지정하여 AQL검사
    Re = 0  # 초기화
    sample = []
    sample_defect = 0

    if letter == 'A' or letter == 'B':
        sample = random.sample(unit_pass, 3)
        Re = 1
    elif letter == 'C' or letter == 'D' or letter == 'E':
        sample = random.sample(unit_pass, 13)
        Re = 2
    elif letter == 'F':
        sample = random.sample(unit_pass, 20)
        Re = 3
    elif letter == 'G':
        sample = random.sample(unit_pass, 32)
        Re = 4
    elif letter == 'H':
        sample = random.sample(unit_pass, 50)
        Re = 6
    elif letter == 'J':
        sample = random.sample(unit_pass, 80)
        Re = 8
    elif letter == 'K':
        sample = random.sample(unit_pass, 125)
        Re = 11
    elif letter == 'L':
        sample = random.sample(unit_pass, 200)
        Re = 15
    elif letter == 'M' or letter == 'N' or letter == 'P' or letter == 'Q' or letter == 'R':
        sample = random.sample(unit_pass, 315)
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


# print(AQL_Chart(unit_pass, letter))

# ---------------------------------------------------------------------------------------------

def Avg(Unit_horizon):  # 평균함수
    avg = numpy.mean(Unit_horizon)
    return round(avg, 2)


def Sigma(Unit_horizon):  # 표준편차함수
    sigma = numpy.std(Unit_horizon)
    return round(sigma, 2)

# print(Avg(Unit_horizon))
# print(Sigma(Unit_horizon))

# ----------------------------------------------------------------------------------------------

# 최종 결과값
# Unit_horizon=[9.0, 8.9, 9.2, 8.8, 8.7, 13.0, 9.3, 9.9, 8.5, 9.0]

# unit_pass = [1, 1, 1, 1, 1, 0, 1, 0, 0, 1]

# letter = 'B'

# AQL_pass = 1 (AQL_pass는 unit_pass에서 랜덤으로 뽑아서 평가하므로 값이 달라질 수 있습니다.)

# sigma = 1.24

# avg = 9.43

# sigma = 1.
'''def quarity(cp):
    a=2
    b=1.67
    c=1.33
    d=1
    e=0.67
    f=0.33

    item = {1:'공정능력 매우 불량한 공정',2:'공정능력 불량한 공정',3:'공정능력 저조한 공정',4:'공정능력이 보통인 공정',5:'공정능력이 우수한 공정',6:'공정능력이 매우 우수한 공정',7:'공정능력이 탁월한 공정'}

    if cp >= a:
        return item[7]
    elif cp>=b and cp <a:
        return item[6]
    elif cp <b and cp>=c:
        return item[5]
    elif cp <c and cp>=d:
        return item[4]  
    elif cp <d and cp >=e:
        return item[3]    
    elif cp <e and cp >=f:
        return item[2]
    elif cp < f:
        return item[1]
cp = float(input("i:"))
print(quarity(cp))
''''