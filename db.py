import sqlite3 as sqlite
import re
import math
import time
import random
import numpy




def Append_Dot(dot1, dot2):  # Opencv에서 불러온 꼭지점 좌표 append
    p1.append(dot1)
    p2.append(dot2)

lot = 10
p1 = [(1, 1), (1.1, 1), (0.8, 1), (1.2, 1), (1.3, 1), (1, 1), (2.7, 1), (1, 1), (1, 1), (1, 1)]
p2 = [(10, 1), (10, 1), (10, 1), (10, 1), (10, 1), (14, 1), (12, 1), (10.9, 1), (9.5, 1), (10, 1)]



#DB 생성(오토커밋)
conn = sqlite.connect("test.db",isolation_level=None)
#커서획득
c=conn.cursor()

Unit_horizon=[9.0, 8.9, 9.2, 8.8, 8.7, 13.0, 9.3, 9.9, 8.5, 9.0]
Unit_pass = [1, 1, 1, 1, 1, 0, 1, 0, 0, 1]

#데이터삽입
for Unit_no in range(lot):
        c.execute('''INSERT INTO Unit_factory(Unit_no, Unit_horizon, Unit_pass)
            VALUES(%d,%f,%d)''' % (Unit_no+1, Unit_horizon[Unit_no], Unit_pass[Unit_no]) )

# 데이서 불어오기
c.execute("SELECT Unit_horizon FROM Unit_factory")

#데이터삭제
c.execute('''DELETE FROM Unit_factory''')
conn.commit()
conn.close() #연결 닫기
# ----------------------------------------------------------------------------------------------
