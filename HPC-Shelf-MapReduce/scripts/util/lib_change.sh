#!/bin/bash

OLD1='usr\\lib\\mono\\DGAC\\DGAC.dll'
NEW1='..\\..\\opt\\mono\\lib\\mono\\DGAC\\DGAC.dll'
find . -iname *.csproj | xargs sed -i 's/'$OLD1'/'$NEW1'/g'

OLD1='usr\\lib\\mono\\MPI\\MPI.dll'
NEW1='..\\..\\opt\\mono\\lib\\mono\\MPI\\MPI.dll'
find . -iname *.csproj | xargs sed -i 's/'$OLD1'/'$NEW1'/g'

