import numpy as np
import cv2
import numpy

def opencv_capture():
    cap = cv2.VideoCapture(0)
    count = 0

    while (True):
        ret, img = cap.read()  # Read 결과와 frame

        cv2.imshow("Test", img)

        if not ret:
            break

        k = cv2.waitKey(1)

        if k % 256 == 27:
            print("Close")
            break
        elif k % 256 == 32:
            print("Image " + str(count) + "saved")
            file = 'C:/data_science202007/notebook/project_test/image' + str(count) + '.png'
            cv2.imwrite(file, img)
            count += 1

    cap.release()
    cv2.destroyAllWindows()


font = cv2.FONT_HERSHEY_COMPLEX

opencv_capture()