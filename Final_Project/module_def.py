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
#------ LED 연결 함수-----------
def led_init( led1, led2 ):
    GPIO.setup( led1, GPIO.OUT )
    GPIO.setup( led2, GPIO.OUT )
# led_on led 켜기
def led_on( led_pin ):
    GPIO.output( led_pin, True )
# led_on led 끄기
def led_off( led_pin ):
    GPIO.output( led_pin, False )
# led 켜고 끄기 
def led_blink( led_pin, delay ):
    led_on( led_pin )
    time.sleep( delay )
    led_off( led_pin )
    time.sleep( delay )
# led1,led2 켜기 , led1,led2 끄기
def led_all_blink():
    led_on( led1 )
    led_on( led2 )
    time.sleep( 0.5 )
    led_off( led1 )
    led_off( led2 )
    time.sleep( 0.5 )
#led1 켜고 led 2 끄기, led2 켜고 , led1 끄기
def led_shift( led1, led2, delay ):
    led_on( led1 )
    led_off( led2 )
    time.sleep( delay )
    led_on( led2 ) 
    led_off( led1 )
    time.sleep( delay )

# ------------------------------

#------ 모터함수 ----------------

def motor_init():
    GPIO.setup( MOTOR_P, GPIO.OUT )
    GPIO.setup( MOTOR_N, GPIO.OUT )
    GPIO.setup( MOTOR_EN, GPIO.OUT )
# 기본 모터 앞으로 전진 
def motor_forward():
    print( 'forward' )
    GPIO.output( MOTOR_P, True )
    GPIO.output( MOTOR_N, False )
    GPIO.output( MOTOR_EN, True )
    time.sleep( 1 )
# 기본 모터 뒤로 전진 
def motor_backward():
    print( 'backward' )
    GPIO.output( MOTOR_P, False )
    GPIO.output( MOTOR_N, True )
    GPIO.output( MOTOR_EN, True )
    time.sleep( 1 )
# 모터 멈춤
def motor_stop():
    GPIO.output( MOTOR_EN, False )
    time.sleep( 1 )
#--------------------------------

#----------초음파 센서------------
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
#---------------------------------
#------------서보모터 각도제어-----
def servo_motor (angle) :
    if angle > 180 or angle < 0 :
        return False

    start = 4
    end = 12.5
    ratio = (end - start)/180 #Calcul ratio from angle to percent

    angle_as_percent = angle * ratio

    return start + angle_as_percent


GPIO.setmode(GPIO.BOARD) #Use Board numerotation mode
GPIO.setwarnings(False) #Disable warnings

#Use pin 12 for PWM signal 사용 예시
pwm_gpio = 12
frequence = 50
GPIO.setup(pwm_gpio, GPIO.OUT)
pwm = GPIO.PWM(pwm_gpio, frequence)

#Init at 0° 
pwm.start(servo_motor(0))
time.sleep(1)

#Go at 90°
pwm.ChangeDutyCycle(servo_motor(90))
time.sleep(1)

#Finish at 180°
pwm.ChangeDutyCycle(servo_motor(180))
time.sleep(1)

#Close GPIO & cleanup
pwm.stop()
GPIO.cleanup()