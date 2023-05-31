#!/bin/bash

str1=""
str2=""
if [[ $# -eq 2 ]]; then
	str1=$1
	str2=$2
elif [[ $# -ne 0 ]]; then
	echo "Hiba!"
	exit 1
else
	read -r str1
	read -r str2
fi

if [[ ${#str1} -ge ${#str2} ]]; then
	echo "$str1" | rev
else
	echo "$str2" | rev
fi
