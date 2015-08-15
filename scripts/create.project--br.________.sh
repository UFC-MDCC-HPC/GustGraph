#!/bin/bash
newline='\n'
tab='\t'
for folder in br.*
do 
	echo -e "<?xml version=\"1.0\" encoding=\"UTF-8\"?>$newline<projectDescription>$newline $tab<name>$folder</name>" > $folder/.project
    echo -e "$tab<comment></comment>$newline $tab<projects>$newline $tab</projects>$newline $tab<buildSpec>$newline $tab $tab<buildCommand>$newline $tab $tab $tab<name>org.emonic.base.EMonic_Builder</name>" >> $folder/.project
	echo -e "$tab $tab $tab<arguments>$newline $tab $tab $tab</arguments>$newline $tab $tab</buildCommand>$newline $tab</buildSpec>$newline $tab<natures>$newline $tab $tab<nature>org.emonic.base.EMonic_Nature</nature>$newline $tab</natures>" >> $folder/.project
	echo -e "</projectDescription>" >> $folder/.project	 
done;

