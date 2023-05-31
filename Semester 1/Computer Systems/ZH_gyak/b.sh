#!/bin/bash

if [[ $# -ne 1 ]]; then
	echo "Paraméter hiányzik"
	exit 1
fi

n=$1
if ! [[ ${n} =~ ^[0-9]+$ ]]; then
	echo "A paraméter nem szám!"
	exit 2
fi

touch b.ki
for (( i=0; i<n; i++ )); do
	randnum=$(( (RANDOM % 11) + 10 ))
	echo "$randnum" | cat >> b.ki
done
