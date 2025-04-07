#!/bin/bash

showname(){
    echo hello $1
    if [ ${1,,} = Murilo ]; then  
        return 0
    else
        return 1
    fi
}
showname Murilo
if [ $? = 1 ]; then
    echo "Someone unknown called the function!"
fi


