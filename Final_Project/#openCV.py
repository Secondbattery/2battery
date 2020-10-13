import numpy as np
import cv2

p_list = []
p=[]
p1, p2, p3, p4 = [],[],[],[]
# openCV 함수 
def opencv_capture():
    cap = cv2.VideoCapture(0) # 실시간 이미지 받아오기
    count = 0  #찍한 횟수

    while (True):
        ret, img = cap.read()  # Read 결과와 frame

        cv2.imshow("Test", img)  # Test 화면에 img 표시

        if not ret:
            break

        k = cv2.waitKey(1)  # 입력대기

        if k % 256 == 27:  # esc 버튼을 누르면 닫기
            print("Close")
            break
        elif k % 256 == 32: # space 바를 누르면 사진 저장
            print("Image " + str(count) + "saved")  #
            file = 'C:/Users/hangaramit26/PycharmProjects/2battery' + str(count) + '.png'
            cv2.imwrite(file, img)
            count += 1
            opencv_contour(file)

    cv2.destroyAllWindows() # 이미지 윈도우 삭제
    cap.release()


font = cv2.FONT_HERSHEY_COMPLEX
def opencv_contour(file):
    img2 = cv2.imread(file, cv2.IMREAD_COLOR)

    img3 = cv2.imread(file, cv2.IMREAD_GRAYSCALE) # 같은 이미지를 gray scale로 저장

    _, threshold = cv2.threshold(img3, 170, 255, cv2.THRESH_BINARY)  #gray scale로 된 이미지를 오직 검정, 화이트 이미지로 변환

    # Detecting contours in image.
    contours, _ = cv2.findContours(threshold, cv2.RETR_TREE,        # 이미지를 윤곽선 검출
                                   cv2.CHAIN_APPROX_SIMPLE)

    for cnt in contours:

        epsilon = 0.02 * cv2.arcLength(cnt, True)  # 근사치
        approx = cv2.approxPolyDP(cnt, epsilon, True)

        cv2.drawContours(img2, [approx], 0, (0, 0, 255), 1)

        n = approx.ravel()
        i = 0

        for j in n:  # 좌표값 추출
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
    if cv2.waitKey(0) & 0xFF == ord('q'):  # q 누르면 화면 닫기
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
