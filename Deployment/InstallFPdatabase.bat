rmdir  "C:\Chiasma\FPdatabase"

mkdir "C:\Chiasma\FPdatabase"

robocopy .\ C:\Chiasma\FPdatabase\ FPdatabase.exe
robocopy .\ C:\Chiasma\FPdatabase\ FPdatabaseConfig.txt
robocopy .\ %UserProfile%\Desktop\ FPdatabase.lnk
