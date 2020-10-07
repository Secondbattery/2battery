import sqlite3

# DB 생성 (오토 커밋)
conn = sqlite3.connect("test.db", isolation_level=None)
# 커서 획득
c = conn.cursor()

#데이터 모두 출력
c.execute("SELECT * FROM table1")
print(c.fetchall())

#DB연결 해제
conn.close()