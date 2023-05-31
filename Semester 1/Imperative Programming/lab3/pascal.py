import math

n = int(input())

for i in range(n+1):
    #print(" " * (math.ceil(n / 2) - i), end="")
    for j in range(i+1):
        if j == 0:
            print("1 ", end="")
        else:
            print(str(int(math.factorial(i) / (math.factorial(j)*math.factorial(i - j)))) + " ", end="")
    print()
