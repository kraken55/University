#!/bin/bash

count=0
while read -r num || [[ -n "$num" ]]; do
	if [[ $(( num % 3 )) -eq 0 ]]; then
		count=$((count + 1))
	fi
done < "b.ki"

echo "$count"
