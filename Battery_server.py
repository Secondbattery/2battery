import sqlite3 as sqlite
from test import server
import math
import time
import random
import numpy
import RPi.GPIO as GPIO

p1 = [(5,1)]*100
p2 = [(96,1), (92,1), (100,1), (95,1), (95,1), (97,1), (96,1), (96,1), (95,1), (94,1),
      (97,1), (93,1), (99.1,1), (94,1), (95,1), (97,1), (96,1), (96,1), (98,1), (94,1),
      (96,1), (95,1), (96,1), (94,1), (95,1), (95,1), (96,1), (96,1), (95,1), (96,1)]*3\
     +[(96,1), (97,1), (94,1), (93,1), (95,1), (94,1), (95,1), (96,1), (97,1), (93,1)]

plen = p2.__len__()
HOST = '192.168.101.101'
PORT = 9008
Unit_horizon = []
Unit_pass = [] 
h_standard = 90.0  
led1 = 14
led2 = 15
GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)

lot=100
Unit_number = 0

def led_init(led1,led2):
    GPIO.setup(led1,GPIO.OUT)
    GPIO.setup(led2,GPIO.OUT)
def led_on(led_pin):
    GPIO.output(led_pin,True)
    time.sleep(0.1)
    led_off(led_pin)
def led_off(led_pin):
    GPIO.output(led_pin,False)

conn = sqlite.connect("test.db",isolation_level=None)
c=conn.cursor()

led_init(led1,led2)

def Dot_Distance(x1, y1, x2, y2): 
    result_horizon  = round(math.sqrt(math.pow(abs(x1 - x2), 2) + math.pow(abs(y1 - y2), 2)), 1)
    return result_horizon

def Unit_Defect(Result_horizon): #Unit_number가 왜있었지???
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

def start(Unit_number):
    global plen
    
    #print(Unit_number)
    Result_horizon = Dot_Distance(p1[Unit_number][0], p1[Unit_number][1], p2[Unit_number][0], p2[Unit_number][1])
    Unit_horizon.append(Result_horizon)
    #print(Result_horizon)
    send_h = 'Distance'+str(Result_horizon)
    client_socket.send(send_h.encode())
    Result_pass = Unit_Defect(Result_horizon)
    if Result_pass == 1:
        led_on(led1)
    elif Result_pass == 0:
        led_on(led2)
    time.sleep(0.3)
    
    #print(Result_pass)
    Unit_pass.append(Result_pass)
    send_p = 'Unit_pass'+str(Result_pass)
    client_socket.send(send_p.encode())

    
    c.execute('''INSERT INTO Unit_factory(Unit_no, Unit_horizon, Unit_pass)
        VALUES(%d,%f,%d)''' % (Unit_number, Result_horizon, Result_pass) )
    if Unit_number == (plen-1):
        print('last')
        AQL_pass = AQL_Chart(Unit_pass, Sample_Letter(Unit_number))
        #print(AQL_pass)
        send_aql = 'AQL_pass'+str(AQL_pass)
        client_socket.send(send_aql.encode())
        time.sleep(0.5)

        Deviation = Sigma(Unit_horizon)
        #print(Deviation)
        send_s = 'Sigma'+str(Deviation)
        client_socket.send(send_s.encode())
        time.sleep(0.5)

        Mean = Avg(Unit_horizon)
        #print(Mean)
        send_m = 'Mean'+str(Mean)
        client_socket.send(send_m.encode())
        time.sleep(0.5)

        Cp = PCA(Deviation, h_standard)
        #print(Cp)
        send_cp = 'Cp' + str(Cp)
        client_socket.send(send_cp.encode())

        # Result_factory 
        c.execute('''INSERT INTO Result_factory(Unit_no, AQL_pass, Sigma, Mean, Cp)
            VALUES(%d,%d,%f,%f,%f)''' % (Unit_number, AQL_pass, Deviation, Mean, Cp))
        # client_socket.close()
        # server_socket.close()       
        return






#gostop = False

if __name__ == "__main__":
    
    
    abc = plen
    server_socket = server.socket(server.AF_INET, server.SOCK_STREAM)
    server_socket.setsockopt(server.SOL_SOCKET, server.SO_REUSEADDR, 1)

    server_socket.bind((HOST, PORT))
    server_socket.listen(2)
    client_socket, addr = server_socket.accept()
    print('[ Server Message : Connected by {} ]'.format(addr))
   
    
    for i in range(abc):
        start(i)
    #
    while True:
        
             
        a = input("press y : ")      
        #if a=='y':
        
        
        if a == 'y':
            client_socket.close()
            server_socket.close()   
            break

        #else:
        #    break
        

    client_socket.close()
    server_socket.close()       