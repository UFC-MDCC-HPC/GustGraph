#!/bin/bash
for folder in br.ufc.mdcc.hpcshelf.farm.*
do 
        pacote=`echo $folder | cut -d'.' -f6`
        echo $folder " - " $pacote
		sn -k $folder/$pacote.snk
        sn -p $folder/$pacote.snk $folder/$pacote.pub
done;

