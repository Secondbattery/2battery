import sqlite3

# DB 생성 (오토 커밋)
conn = sqlite3.connect("DB.db", isolation_level=None)
# 커서 획득
c = conn.cursor()

# 데이터 삭제하기
print(conn.execute("DELETE FROM table1").rowcount)

#DB연결 해제
conn.close()