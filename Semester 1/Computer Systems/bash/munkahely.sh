#!/bin/bash

# Feladat 1
echo "Feladat 1"

exists=0
while IFS="," read -r name address nIncidents nGuards || [[ -n "$name" ]]
do
	if [[ ${nIncidents} -eq 0 ]]; then
		exists=1
		echo "$name"
	fi
done < "$1"

if [[ ${exists} -eq 0 ]]; then
	echo "NINCS"
fi

echo

# Feladat 2
echo "Feladat 2"

sum=0
while IFS="," read -r name address nIncidents nGuards || [[ -n "$name" ]]
do
	(( sum = sum + nGuards ))
done < "$1"

echo "$sum"
echo

# Feladat 3
echo "Feladat 3"

maxIncidents=0
while IFS="," read -r name address nIncidents nGuards || [[ -n "$name" ]]
do
	if [[ ${maxIncidents} -lt ${nIncidents} ]]; then
		maxIncidents=$nIncidents
	fi
done < "$1"

while IFS="," read -r name address nIncidents nGuards || [[ -n "$name" ]]
do
	if [[ ${nIncidents} -eq ${maxIncidents} ]]; then
		echo "$name $address"
	fi
done < "$1"
