Option Strict Off
Option Explicit On
Module CollectionHelp
	
	Public Function Exists(ByRef Key As Object, ByRef testCollection As Collection) As Boolean
		Dim msValue As Object
		On Error Resume Next
		'UPGRADE_WARNING: Couldn't resolve default property of object testCollection.Item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object msValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		msValue = testCollection.Item(Key)
		
		If Err.Number = 0 Then
			Exists = True
		Else
			Exists = False
		End If
		
	End Function
End Module