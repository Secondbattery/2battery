import RPi.GPIO as GPIO
import time
from module_def import *

GPIO.setmode( GPIO.BCM )
GPIO.setwarnings( False )

trig = 0 # transmit
echo = 1 # receive

GPIO.setup( trig, GPIO.OUT )
GPIO.setup( echo, GPIO.IN )

if __name__ == "__main__":
    try:
        motor_init()
        led_init(led1,led2)
        while True:
            yn = input("컨베이어 벨트 작동하시겠습니까?(y/n)")
            if yn == "y":
                motor_forward()
                led_off(led1)
            else:
                motor_stop()
                led_on(led1)


    except KeyboardInterrupt:
        motor_stop()
    finally:
        GPIO.cleanup()


try:
    while True:
        GPIO.output( trig, False )
        time.sleep( 0.5 )

        GPIO.output( trig, True )
        time.sleep( 0.00001 )

        GPIO.output( trig, False )

        while GPIO.input( echo ) == False:
            pluse_start = time.time()
        
        while GPIO.input( echo ) == True:
            pluse_end = time.time()

        pluse_duration = pluse_end - pluse_start
        distance = pluse_duration * 17000
        distance = round( distance )

        print(distance)
        if distance >= 30:
            led_all_blink()
            motor_forward()

        elif distance < 30:
            led_on( led1 )
            led_on( led2 )
            motor_stop()
except KeyboardInterrupt:
    pass

finally:
    GPIO.cleanup()