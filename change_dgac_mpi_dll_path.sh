#!/bin/bash
#DGAC.dll
CURRENTPATH='..\\..\\lib\\DGAC.dll'
NEWPATH='..\\..\\lib\\DGAC.dll'
#NEWPATH='..\\opt\\mono-4.2.2\\lib\\mono\\DGAC\\DGAC.dll'
find . -iname *.csproj | xargs sed -i 's/'$CURRENTPATH'/'$NEWPATH'/g'

#MPI.dll
CURRENTPATH='..\\..\\lib\\MPI.dll'
NEWPATH='..\\..\\lib\\MPI.dll'
#NEWPATH='..\\opt\\mono-4.2.2\\lib\\mono\\MPI\\MPI.dll'
find . -iname *.csproj | xargs sed -i 's/'$CURRENTPATH'/'$NEWPATH'/g'

