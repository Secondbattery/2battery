import RPi.GPIO as GPIO
import time
import sys
import asyncio

GPIO.setmode( GPIO.BCM )
GPIO.setwarnings(False)

MOTOR_P = 4
MOTOR_N = 25
MOTOR_EN = 12

trig = 0
echo = 1
    
GPIO.setup(trig, GPIO.OUT)
GPIO.setup(echo, GPIO.IN)

async def coroutine_1():
    await asyncio.sleep(5)

async def coroutine_2():
    await asyncio.sleep(4)

async def awaits():
    loop = asyncio.get_event_loop()
    loop.run_until_complete(asyncio.gather(coroutine_1(), coroutine_2()))
    loop.close()

def motor_init():
    GPIO.setup( MOTOR_P, GPIO.OUT )
    GPIO.setup( MOTOR_N, GPIO.OUT )
    GPIO.setup( MOTOR_EN, GPIO.OUT )

def motor_forward():
    print( 'forward' )
    GPIO.output( MOTOR_P, True )
    GPIO.output( MOTOR_N, False )
    GPIO.output( MOTOR_EN, True )
    time.sleep( 1 )
    
def motor_backward():
    print( 'backward' )
    GPIO.output( MOTOR_P, False )
    GPIO.output( MOTOR_N, True )
    GPIO.output( MOTOR_EN, True )
    time.sleep( 1 )
    
def motor_stop():
    GPIO.output( MOTOR_EN, False )
    time.sleep( 1 )

def Sonar():
    while True:
        GPIO.output(trig, False)
        time.sleep(0.5)                 
        GPIO.output(trig, True)
        time.sleep(0.00001)
        GPIO.output(trig, False)
        
        while GPIO.input(echo) == False :
            pulse_start = time.time()
            
        while GPIO.input(echo) == True :
            pulse_end = time.time()
            
        pulse_duration = pulse_end - pulse_start
        distance = pulse_duration * 17000
        distance = round(distance, 2)
        return distance


