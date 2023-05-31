num = 341
numstring = str()

while num != 0:
    numstring += str(num % 2)
    num = num // 2

print(int(numstring[::-1]))

