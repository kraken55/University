#!/bin/bash
gcc $1
if [ $? -eq 0 ]
then
	./a.out < be.txt | tee ki-test.txt
fi

diff ki.txt ki-test.txt 
