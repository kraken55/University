#!/bin/bash

if [[ $# -ne 1 ]]; then
	echo "Paramter error: usage: fact <num>"
	exit 1
elif ! [[ $1 =~ ^[0-9]+$ ]]; then
	echo "Invalid input: parameter must be a nonnegative number"
	exit 2
fi

fact=1
for (( i = 1; i <= $1; i++ )); do
	(( fact = fact * i ))
done

echo "Factorial of $1: $fact"

exit 0
