import re
import math
import time
import random
import numpy
import RPi.GPIO as GPIO


GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)

h_standard = 90.0 

def led_init(led1,led2):
    GPIO.setup(led1,GPIO.OUT)
    GPIO.setup(led2,GPIO.OUT)

def led_on(led_pin):
    GPIO.output(led_pin,True)
    time.sleep(0.1)
    led_off(led_pin)
def led_off(led_pin):
    GPIO.output(led_pin,False)


def Dot_Distance(x1, y1, x2, y2): 
    result_horizon  = round(math.sqrt(math.pow(abs(x1 - x2), 2) + math.pow(abs(y1 - y2), 2)), 1)
    return result_horizon

def Unit_Defect(Unit_number, Result_horizon): 
    if (Result_horizon >= (h_standard * 0.96)) and (Result_horizon <= (h_standard * 1.04)):  
        result = 1 
    else:
        result = 0  
    return result

def Sample_Letter(lot): 
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

def AQL_Chart(Unit_pass, letter):
    Re = 0  # 
    sample = []  # 
    sample_defect = 0  # 
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
    for i in sample:  #
        if i == 0:
            sample_defect += 1
        elif i == 1:
            continue
    if sample_defect >= Re:
        AQL_pass = 0
    elif sample_defect < Re:
        AQL_pass = 1
    return AQL_pass

def Avg(Unit_horizon):  
    avg = numpy.mean(Unit_horizon)
    return round(avg, 2)

def Sigma(Unit_horizon):  
    sigma = numpy.std(Unit_horizon)
    return round(sigma, 2)

def PCA(sigma, h_standard):
    USL = h_standard * 1.04 
    LSL = h_standard * 0.96
    Cp = (USL - LSL) / (6 * sigma)
    return round(Cp, 2)
