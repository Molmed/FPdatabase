Option Strict Off
Option Explicit On
Module WindowsAPI
	'**************************************
	'Windows API/Global Declarations for :cR
	'     egistry
	'**************************************
	
	
#If Win32 Then
	'Registry Constants
	Public Const HKEY_CLASSES_ROOT As Integer = &H80000000
	Public Const HKEY_CURRENT_USER As Integer = &H80000001
	Public Const HKEY_LOCAL_MACHINE As Integer = &H80000002
	Public Const HKEY_USERS As Integer = &H80000003
	'Registry Specific Access Rights
	Public Const KEY_QUERY_VALUE As Integer = &H1
	Public Const KEY_SET_VALUE As Integer = &H2
	Public Const KEY_CREATE_SUB_KEY As Integer = &H4
	Public Const KEY_ENUMERATE_SUB_KEYS As Integer = &H8
	Public Const KEY_NOTIFY As Integer = &H10
	Public Const KEY_CREATE_LINK As Integer = &H20
	Public Const KEY_ALL_ACCESS As Integer = &H3F
	'Open/Create Options
	Public Const REG_OPTION_NON_VOLATILE As Short = 0
	Public Const REG_OPTION_VOLATILE As Integer = &H1
	'Key creation/open disposition
	Public Const REG_CREATED_NEW_KEY As Integer = &H1
	Public Const REG_OPENED_EXISTING_KEY As Integer = &H2
	'masks for the predefined standard acces
	'     s types
	Public Const STANDARD_RIGHTS_ALL As Integer = &H1F0000
	Public Const SPECIFIC_RIGHTS_ALL As Integer = &HFFFF
	'Define severity codes
	Public Const ERROR_SUCCESS As Short = 0
	Public Const ERROR_ACCESS_DENIED As Short = 5
	Public Const ERROR_NO_MORE_ITEMS As Short = 259
	'Predefined Value Types
	Public Const REG_NONE As Short = (0) 'No value Type
	Public Const REG_SZ As Short = (1) 'Unicode nul terminated String
	Public Const REG_EXPAND_SZ As Short = (2) 'Unicode nul terminated String w/enviornment var
	Public Const REG_BINARY As Short = (3) 'Free form binary
	Public Const REG_DWORD As Short = (4) '32-bit number
	Public Const REG_DWORD_LITTLE_ENDIAN As Short = (4) '32-bit number (same as REG_DWORD)
	Public Const REG_DWORD_BIG_ENDIAN As Short = (5) '32-bit number
	Public Const REG_LINK As Short = (6) 'Symbolic Link (unicode)
	Public Const REG_MULTI_SZ As Short = (7) 'Multiple Unicode strings
	Public Const REG_RESOURCE_LIST As Short = (8) 'Resource list In the resource map
	Public Const REG_FULL_RESOURCE_DESCRIPTOR As Short = (9) 'Resource list In the hardware description
	Public Const REG_RESOURCE_REQUIREMENTS_LIST As Short = (10)
	'Structures Needed For Registry Prototyp
	'     es
	
	
	Structure SECURITY_ATTRIBUTES
		Dim nLength As Integer
		Dim lpSecurityDescriptor As Integer
		Dim bInheritHandle As Boolean
	End Structure
	
	
	Structure FILETIME
		Dim dwLowDateTime As Integer
		Dim dwHighDateTime As Integer
	End Structure
	'Registry Function Prototypes
	
	
	Declare Function RegOpenKeyEx Lib "advapi32"  Alias "RegOpenKeyExA"(ByVal hKey As Integer, ByVal lpSubKey As String, ByVal ulOptions As Integer, ByVal samDesired As Integer, ByRef phkResult As Integer) As Integer
	
	
	Declare Function RegSetValueEx Lib "advapi32"  Alias "RegSetValueExA"(ByVal hKey As Integer, ByVal lpValueName As String, ByVal Reserved As Integer, ByVal dwType As Integer, ByVal szData As String, ByVal cbData As Integer) As Integer
	
	
	Declare Function RegCloseKey Lib "advapi32" (ByVal hKey As Integer) As Integer
	
	
	Declare Function RegQueryValueEx Lib "advapi32"  Alias "RegQueryValueExA"(ByVal hKey As Integer, ByVal lpValueName As String, ByVal lpReserved As Integer, ByRef lpType As Integer, ByVal szData As String, ByRef lpcbData As Integer) As Integer
	
	
	'UPGRADE_WARNING: Structure SECURITY_ATTRIBUTES may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function RegCreateKeyEx Lib "advapi32"  Alias "RegCreateKeyExA"(ByVal hKey As Integer, ByVal lpSubKey As String, ByVal Reserved As Integer, ByVal lpClass As String, ByVal dwOptions As Integer, ByVal samDesired As Integer, ByRef lpSecurityAttributes As SECURITY_ATTRIBUTES, ByRef phkResult As Integer, ByRef lpdwDisposition As Integer) As Integer
	
	
	'UPGRADE_WARNING: Structure FILETIME may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function RegEnumKeyEx Lib "advapi32.dll"  Alias "RegEnumKeyExA"(ByVal hKey As Integer, ByVal dwIndex As Integer, ByVal lpName As String, ByRef lpcbName As Integer, ByVal lpReserved As Integer, ByVal lpClass As String, ByRef lpcbClass As Integer, ByRef lpftLastWriteTime As FILETIME) As Integer
	
	
	Declare Function RegEnumKey Lib "advapi32.dll"  Alias "RegEnumKeyA"(ByVal hKey As Integer, ByVal dwIndex As Integer, ByVal lpName As String, ByVal cbName As Integer) As Integer
	
	
	Declare Function RegEnumValue Lib "advapi32.dll"  Alias "RegEnumValueA"(ByVal hKey As Integer, ByVal dwIndex As Integer, ByVal lpValueName As String, ByRef lpcbValueName As Integer, ByVal lpReserved As Integer, ByRef lpType As Integer, ByVal lpData As String, ByRef lpcbData As Integer) As Integer
	
#End If
End Module