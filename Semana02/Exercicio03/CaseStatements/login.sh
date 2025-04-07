#!/bin/bash

case ${1,,} in 
	murilo | administrator)			
        echo "Oi, tu que manda";;
	help)
		echo "Só coloca seu nome";;
	*)
		echo "E ai, ce sabe que não pode logar assim, coloca um usuario de verdade"
esac
