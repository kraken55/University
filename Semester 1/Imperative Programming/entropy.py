import math

file = open("bun.txt", 'r')
txt = file.readlines()

chars = dict()
totalChars = 0
for line in txt:
    for char in line:
        chars[char] = chars.get(char, 0) + 1
        totalChars += 1
entropy = 0
for v in chars.values():
    entropy += (v / totalChars) * math.log2(v / totalChars)

entropy = -entropy

print(entropy)