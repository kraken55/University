import math


a = int(input())

s = 3 * a / 2

print(round(math.sqrt(s * (s - a) ** 3), 2))