import sqlite3 as sqlite
import socket
import re
import math
import time
import random
import numpy
import RPi.GPIO as GPIO
from Class_Def import *
from module import *
import asyncio

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
 
led1 = 14
led2 = 15
GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)
led_init(led1,led2)

lot=100
Unit_number = 0

conn = sqlite.connect("test.db",isolation_level=None)
c=conn.cursor()
c.execute("CREATE TABLE Unit_factory(Unit_no, Unit_horizon, Unit_pass);")
c.execute("CREATE TABLE Result_factory(Unit_no, AQL_pass, Sigma, Mean, Cp);")


def start(Unit_number):
    global plen
    
    #print(Unit_number)
    Result_horizon = Dot_Distance(p1[Unit_number][0], p1[Unit_number][1], p2[Unit_number][0], p2[Unit_number][1])
    Unit_horizon.append(Result_horizon)
    #print(Result_horizon)
    send_h = 'Distance'+str(Result_horizon)
    conn.send(send_h.encode())
    Result_pass = Unit_Defect(Unit_number, Result_horizon)
    if Result_pass == 1:
        led_on(led1)
    elif Result_pass == 0:
        led_on(led2)
    time.sleep(0.3)
    
    #print(Result_pass)
    Unit_pass.append(Result_pass)
    send_p = 'Unit_pass'+str(Result_pass)
    conn.send(send_p.encode())

    
    c.execute('''INSERT INTO Unit_factory(Unit_no, Unit_horizon, Unit_pass)
        VALUES(%d,%f,%d)''' % (Unit_number, Result_horizon, Result_pass) )
    
    if Unit_number == (plen-1):
        print('last')
        AQL_pass = AQL_Chart(Unit_pass, Sample_Letter(Unit_number))
        #print(AQL_pass)
        send_aql = 'AQL_pass'+str(AQL_pass)
        conn.send(send_aql.encode())
        time.sleep(0.5)

        Deviation = Sigma(Unit_horizon)
        #print(Deviation)
        send_s = 'Sigma'+str(Deviation)
        conn.send(send_s.encode())
        time.sleep(0.5)

        Mean = Avg(Unit_horizon)
        #print(Mean)
        send_m = 'Mean'+str(Mean)
        conn.send(send_m.encode())
        time.sleep(0.5)

        Cp = PCA(Deviation, h_standard)
        #print(Cp)
        send_cp = 'Cp' + str(Cp)
        conn.send(send_cp.encode())

        # Result_factory 
        c.execute('''INSERT INTO Result_factory(Unit_no, AQL_pass, Sigma, Mean, Cp)
            VALUES(%d,%d,%f,%f,%f)''' % (Unit_number, AQL_pass, Deviation, Mean, Cp))
        return






#gostop = False

if __name__ == "__main__":
    
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)

    server_socket.bind((HOST, PORT))
    server_socket.listen(2)
    conn, addr = server_socket.accept()
    print('[ Server Message : Connected by {} ]'.format(addr))

    
    
    
# operate by the Rassberry- pi 
    try:
        motor_init()
        while True:
            recv_message = conn.recv(20).decode()
            if recv_message == "y":
                break
        
        for i in range(plen):
            motor_forward()
            if Sonar() < 30:
                motor_stop()
                start(i)

        while True:
            recv_message = conn.recv(20).decode()    
            if recv_message == 'y':
                break
            
    except KeyboardInterrupt:
        motor_stop()
        
    finally:
        GPIO.cleanup()
        conn.close()

    

    
