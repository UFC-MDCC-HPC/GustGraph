#!/bin/bash
for folder in br.ufc.mdcc.hpcshelf.mapreduce.*.*
do 
        pacote=`echo $folder | cut -d'.' -f7`
        echo $folder " - " $pacote
		sn -k $folder/$pacote.snk
        sn -p $folder/$pacote.snk $folder/$pacote.pub
        #ls $folder
done;

