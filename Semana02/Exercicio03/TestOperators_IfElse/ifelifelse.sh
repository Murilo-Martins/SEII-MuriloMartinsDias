#!/bin/bash
# ${1,,} pega o valor passado na primeira posição e coloca tudo em minusculo
if [ ${1,,} = murilo ]; then
    echo "Bom dia e bem vindo"
elif [ ${1,,} = help ]; then
    echo "Digita seu nome uai"
else
    echo "Tu não é meu chefe"
fi