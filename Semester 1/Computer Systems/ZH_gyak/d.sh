#!/bin/bash

if ! [[ -f "e.in" ]]; then
	echo "A fájl nem létezik"
	exit 1
fi

lineCount=$(cat "e.in" | wc --lines)
if [[ ${lineCount} -lt 2 ]]; then
	echo "A fájl 2 sornál kevesebbet tartalmaz"
	exit 1
fi
