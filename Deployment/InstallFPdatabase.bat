rmdir  "C:\Chiasma\FPdatabase"

mkdir "C:\Chiasma\FPdatabase"

robocopy .\ C:\Chiasma\FPdatabase\ FPdatabase.exe
robocopy .\ C:\Chiasma\FPdatabase\ FPdatabaseConfig.txt
robocopy .\ C:\chiasma\FPdatabase\ FPdatabase.exe.config
robocopy .\ %UserProfile%\Desktop\ FPdatabase.lnk
robocopy .\ C:\Chiasma\FPdatabase\ Interop.Scripting.dll
robocopy .\ C:\Chiasma\FPdatabase\ Microsoft.Office.Interop.Excel.dll



