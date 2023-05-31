#!/bin/bash

# Feladat 1
echo "Feladat 1"

while IFS=',' read -r name position jobs || [[ -n "$name" ]]
do
	if [[ ${position} == "pultos" ]]; then
		echo "$name"
	fi
done < "$1"

# Feladat 2
echo "Feladat 2"
while IFS=',' read -r name position jobs || [[ -n "$name" ]]
do
	count=1
	for (( i=0; i<${#jobs}; i++ )); do
		if [[ ${jobs:$i:1} == ',' ]]; then
			(( count = count + 1 ))
		fi
	done

	if [[ $count -ge 3 ]]; then
		echo "$name"
	fi
done < "$1"

# Feladat 3
echo "Feladat 3"

targetPos=""
read targetPos

count=0
while IFS=',' read -r name position jobs || [[ -n "$name" ]]
do
	if [[ ${position} == "$targetPos" ]]; then
		(( count = count + 1 ))
	fi
done < "$1"
echo "$count"
