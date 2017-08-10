Option Strict Off
Option Explicit On
'UPGRADE_NOTE: Constants was upgraded to Constants_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
Module Constants_Renamed
	
	'Registry location.
	Public Const chiRegClassKey As String = HKEY_CURRENT_USER
	Public Const chiRegSectionKey As String = "Software\Chiasma"
	
	'Constant for the store path for registry keys for the paths in the program.
	Public Const chiRegSubSectionPathKey As String = "Software\Chiasma\FPDatabase\Path"
	
	'The constants below holds the key name for the paths that are stored in the registry.
	Public Const chiRegRawDataFileOpenPath As String = "RawDataFileOpenPath"
	
	Public Const chiRegGenotypeFileOpenPath As String = "GenotypeFileOpenPath"
	
	Public Const chiRegSampleFileOpenPath As String = "SampleFileOpenPath"
	
	'Configuration file name
	Public Const chiConfigFileName As String = "FPdatabaseConfig.txt"
End Module