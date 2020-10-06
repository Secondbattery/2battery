import RPi.GPIO as GPIO
import time
import sys

GPIO.setmode( GPIO.BCM )
GPIO.setwarnings(False)

MOTOR_P = 4
MOTOR_N = 25
MOTOR_EN = 12

led1 = 14
led2 = 15

trig = 3
echo = 2
GPIO.setup(trig, GPIO.OUT)
GPIO.setup(echo, GPIO.IN)
def led_init( led1, led2 ):
    GPIO.setup( led1, GPIO.OUT )
    GPIO.setup( led2, GPIO.OUT )

def led_on( led_pin ):
    GPIO.output( led_pin, True )

def led_off( led_pin ):
    GPIO.output( led_pin, False )

def led_blink( led_pin, delay ):
    led_on( led_pin )
    time.sleep( delay )
    led_off( led_pin )
    time.sleep( delay )

def led_all_blink():
    led_on( led1 )
    led_on( led2 )
    time.sleep( 0.5 )
    led_off( led1 )
    led_off( led2 )
    time.sleep( 0.5 )

def led_shift( led1, led2, delay ):
    led_on( led1 )
    led_off( led2 )
    time.sleep( delay )
    led_on( led2 )
    led_off( led1 )
    time.sleep( delay )

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

    while 1:
        GPIO.output(trig, False)
        time.sleep(0.5)                 
        GPIO.output(trig, True)
        time.sleep(0.00001)
        GPIO.output(trig, False)                  
        while GPIO.input(echo) == 0 :
            pulse_start = time.time()                  
        while GPIO.input(echo) == 1 :
            pulse_end = time.time()               
            pulse_duration = pulse_end - pulse_start
            distance = pulse_duration * 17000
            distance = round(distance, 2)
        print ("Distance : ", distance, "cm")