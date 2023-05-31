#!/bin/bash

file=$(<$1)

exists=0
sumGuards=0
maxCount=0

echo "A következő munkahelyeken nem történt erőszakos cselekedet:"
while IFS="," read -r name address count nGuards || [[ -n $name ]];
do
	if [[ count -eq 0 ]]; then
		echo $name
		exists=1
	fi

	(( sumGuards = sumGuards + nGuards ))

	if [[ count -gt maxCount ]]; then
		maxCount=$count
	fi
done <<< "$file"
echo ""

if [[ exists -eq 0 ]]; then
	echo "NINCS"
fi

echo "A következő munkahelyeken volt a legtöbb erőszakos cselekedet:"
while IFS="," read -r name address count nGuards
do
	if [[ count -eq maxCount ]]; then
		echo -n "$name "
		echo $address
	fi
done <<< "$file"
echo ""

echo -n "Az összes biztonsági őr száma: "
echo $sumGuards
