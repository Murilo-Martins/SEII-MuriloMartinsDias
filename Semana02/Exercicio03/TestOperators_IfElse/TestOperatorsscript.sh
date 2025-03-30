#!/bin/bash

echo "Primeiro valor a ser comparado: "
read $1
echo "Segundo valor a ser comparado: "
read $2

if [ $1 -eq $2 ]; then
    echo "O primeiro valor é maior que o segundo."
elif [ $1 -gt $2 ]; then
    echo "Os valores são iguais."
    
else
    echo "O segundo valor é maior que o primeiro."
fi
