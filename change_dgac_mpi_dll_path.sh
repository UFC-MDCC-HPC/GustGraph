#!/bin/bash
#DGAC.dll
CURRENTPATH='opt\\mono-4.2.2\\lib\\mono\\DGAC\\DGAC.dll'
NEWPATH='opt\\mono-4.2.2\\lib\\mono\\DGAC\\DGAC.dll'
#NEWPATH='..\\opt\\mono-4.2.2\\lib\\mono\\DGAC\\DGAC.dll'
find . -iname *.csproj | xargs sed -i 's/'$CURRENTPATH'/'$NEWPATH'/g'

#MPI.dll
CURRENTPATH='opt\\mono-4.2.2\\lib\\mono\\MPI\\MPI.dll'
NEWPATH='opt\\mono-4.2.2\\lib\\mono\\MPI\\MPI.dll'
#NEWPATH='..\\opt\\mono-4.2.2\\lib\\mono\\MPI\\MPI.dll'
find . -iname *.csproj | xargs sed -i 's/'$CURRENTPATH'/'$NEWPATH'/g'

