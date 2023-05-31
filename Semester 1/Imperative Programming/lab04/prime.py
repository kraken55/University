from cmath import sqrt


import math

def isPrime(n: int):
    for i in range(2, round(math.sqrt(n)) + 1):
        if n % i == 0:
            return False
    return True

curr = 2
num = int(input())

while (num != 1):
    while (num % curr == 0):
        print(str(curr) + " ", end="")
        num = num // curr
    
    curr += 1
    while (not isPrime(curr)):
        curr += 1