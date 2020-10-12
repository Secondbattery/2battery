import RPi.GPIO as GPIO
import time

# servo_motor angle
def servo_motor(angle):
    if angle >180 or angle < 0:
        return False

        start = 4
        end = 12.5

        ratio = (end - start) /180 #Calcul ratio from angle to percentage

        angle_as_percent = angle * ratio

        return start + angle_as_percent
GPIO.setmode(GPIO,BOARD)
GPIO.setwarnings(False)

#using pin number 12 by signal number
pwm_gpio = 12
frequency = 50
GPIO.setup(pwm_gpio, GPIO.OUT)
pwm = GPIO.PWM(pwm_gpio,frequency)

# 0°
pwm.start(angle_to_percent(0))
time.sleep(2)

#90°
pwm.ChangeDutyCycle(angle_to_percent(90))
time.sleep(1)

#180°
pwm.ChangeDutyCycle(angle_to_percent(180))
time.sleep(1)

#GPIO &Cleanup
pwm.stop()
GPIO.Cleanup()