#!/bin/bash
MY_FIRSTARRAY=(one two three four five)
echo ${MY_FIRSTARRAY[@]}

for item in ${MY_FIRSTARRAY[@]}; do echo -n $item | wc -c;done
