import numpy as np
import cv2

p_list = []
p=[]
p1, p2, p3, p4 = [],[],[],[]

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
            file = 'C:/Users/hangaramit26/PycharmProjects/2battery' + str(count) + '.png'
            cv2.imwrite(file, img)
            count += 1
            opencv_contour(file)

    cv2.destroyAllWindows()
    cap.release()


font = cv2.FONT_HERSHEY_COMPLEX
def opencv_contour(file):
    img2 = cv2.imread(file, cv2.IMREAD_COLOR)

    # Reading same image in another
    # variable and converting to gray scale.
    img3 = cv2.imread(file, cv2.IMREAD_GRAYSCALE)

    # Converting image to a binary image
    # ( black and white only image).
    _, threshold = cv2.threshold(img3, 170, 255, cv2.THRESH_BINARY)

    # Detecting contours in image.
    contours, _ = cv2.findContours(threshold, cv2.RETR_TREE,
                                   cv2.CHAIN_APPROX_SIMPLE)

    for cnt in contours:

        epsilon = 0.02 * cv2.arcLength(cnt, True)
        approx = cv2.approxPolyDP(cnt, epsilon, True)

        cv2.drawContours(img2, [approx], 0, (0, 0, 255), 1)

        n = approx.ravel()
        i = 0

        for j in n:
            if (i % 2 == 0):
                x = n[i]
                y = n[i + 1]

                # String containing the co-ordinates.
                string = str(x) + ", " + str(y)

                cv2.putText(img2, string, (x, y), font, 0.5, (0, 0, 255))
                string_list = string.split(",")
                string_list = list(map(int, string_list))
                p_list.append(string_list)

            i = i + 1
    print(p_list)

    # Showing the final image.
    cv2.imshow('image2', img2)

    # Exiting the window if 'q' is pressed on the keyboard.
    if cv2.waitKey(0) & 0xFF == ord('q'):
        cv2.destroyAllWindows()

def coodinate_value():
    for i in range(len(p_list)):
        if i % 4 == 0:
            p1.append(p_list[i])
        elif i % 4 == 1:
            p2.append(p_list[i])
        elif i % 4 == 2:
            p4.append(p_list[i])
        elif i % 4 == 3:
            p3.append(p_list[i])


opencv_capture()
coodinate_value()
print("p1")
print(p1)
print("p2")
print(p2)

print("p3")
print(p3)
print("p4")
print(p4)

