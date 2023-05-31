import csv

with open("szenzor.csv", "w") as szenzorok:
    writer = csv.writer(szenzorok, delimiter=";")
    for id in range(1, 51):
        writer.writerow(id,)
        

def lemeruloben(sznev: str) -> bool:
    file = csv.reader("szenzor.csv")
    for line in file:
        print(line)