def quarity(cp):
    a=2
    b=1.67
    c=1.33
    d=1
    e=0.67
    f=0.33

    item = {1:'공정능력 매우 불량한 공정',2:'공정능력 불량한 공정',3:'공정능력 저조한 공정',4:'공정능력이 보통인 공정',5:'공정능력이 우수한 공정',6:'공정능력이 매우 우수한 공정',7:'공정능력이 탁월한 공정'}

    if cp >= a:
        return item[7]
    elif cp>=b and cp <a:
        return item[6]
    elif cp <b and cp>=c:
        return item[5]
    elif cp <c and cp>=d:
        return item[4]  
    elif cp <d and cp >=e:
        return item[3]    
    elif cp <e and cp >=f:
        return item[2]
    elif cp < f:
        return item[1]
cp = float(input("i:"))
print(quarity(cp))