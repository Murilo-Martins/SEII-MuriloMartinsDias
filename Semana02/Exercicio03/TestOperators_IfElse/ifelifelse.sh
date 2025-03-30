#!/bin/bash

if [ ${1,,} = Murilo ]; then
    echo "Bom dia e bem vindo"
elif [ ${1,,} = help ]; then
    echo "Digita seu nome uai"
else
    echo "Tu não é meu chefe"
fi