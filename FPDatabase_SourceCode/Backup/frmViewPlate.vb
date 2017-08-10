Option Strict Off
Option Explicit On
Friend Class frmViewPlate
	Inherits System.Windows.Forms.Form
	Dim oFPConnection As ADODB.Connection
	Dim strType As String
	Dim strIdentifier As String
	
	
	Public Sub Initialize(ByRef oInFPConnection As ADODB.Connection, ByRef strInType As Object, Optional ByRef strInIdentifier As Object = "")
		oFPConnection = oInFPConnection
		'UPGRADE_WARNING: Couldn't resolve default property of object strInType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		strType = strInType '"Plate" or "Scheme"
		'UPGRADE_WARNING: Couldn't resolve default property of object strInIdentifier. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		strIdentifier = strInIdentifier 'A possible pre-selected plate or plate scheme to view.
	End Sub
	
	Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
		Me.Close()
	End Sub
	
	Private Sub fillPlateHeaders(ByVal PlateFormat As String)
		'filling the headers in the plate, ie. setting the A, B, C, .. 1, 2, 3, ....
		
		
		Dim lRow As Integer
		Dim lColumn As Integer
		
		If PlateFormat = "96" Then
			' 96 well format code
			'setting the size of the flex grid
			flexPlate.Rows = 9
			flexPlate.set_Cols( , 13)
			
			
			lRow = 0
			For lColumn = 2 To flexPlate.get_Cols()
				flexPlate.set_TextMatrix(lRow, lColumn - 1, lColumn - 1)
			Next lColumn
			
			lColumn = 0
			For lRow = 2 To flexPlate.Rows
				flexPlate.set_TextMatrix(lRow - 1, lColumn, Chr(63 + lRow))
			Next lRow
			
		ElseIf PlateFormat = "384" Then 
			'384 well format code
			
			'setting the size of the flex grid
			flexPlate.Rows = 17
			flexPlate.set_Cols( , 25)
			
			lRow = 0
			For lColumn = 2 To flexPlate.get_Cols()
				flexPlate.set_TextMatrix(lRow, lColumn - 1, lColumn - 1)
			Next lColumn
			
			lColumn = 0
			For lRow = 2 To flexPlate.Rows
				flexPlate.set_TextMatrix(lRow - 1, lColumn, Chr(63 + lRow))
			Next lRow
			
			
		Else
			Err.Raise(-10000,  , "Only the plate formats 96 and 384 is supported")
		End If
		
		
	End Sub
	
	
	
	'UPGRADE_WARNING: Event cboPlate.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cboPlate_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboPlate.SelectedIndexChanged
		Dim strObjectIdentifier As String
		Dim lObjectId As Integer
		Dim Rs As New ADODB.Recordset
		Dim oPlateMap As New Scripting.Dictionary
		
		On Error GoTo cboPlate_Click_Error
		
		Call flexPlate.Clear()
		Call fillPlateHeaders("384")
		
		strObjectIdentifier = cboPlate.Text
		
		If UCase(strType) = "PLATE" Then
			'Get information about the plate.
			Rs.Open("SELECT id FROM plate WHERE identifier='" & strObjectIdentifier & "'", oFPConnection)
			If Not Rs.EOF Then
				lObjectId = CShort(Rs.Fields(0).Value)
				Rs.Close()
			Else
				Err.Raise(-10000,  , "Could not find the id of the plate " & strObjectIdentifier & ".")
			End If
			
			Rs.Open("SELECT m.well_row, m.well_column, s.identifier FROM plate_map m, sample s WHERE m.sample_id=s.id AND m.plate_id=" & CStr(lObjectId), oFPConnection)
		ElseIf UCase(strType) = "SCHEME" Then 
			'Get information about the plate scheme.
			Rs.Open("SELECT id FROM plate_scheme WHERE identifier='" & strObjectIdentifier & "'", oFPConnection)
			If Not Rs.EOF Then
				lObjectId = CShort(Rs.Fields(0).Value)
				Rs.Close()
			Else
				Err.Raise(-10000,  , "Could not find the id of the plate " & strObjectIdentifier & ".")
			End If
			
			Rs.Open("SELECT m.well_row, m.well_column, s.identifier FROM plate_scheme_map m, sample s WHERE m.sample_id=s.id AND m.plate_scheme_id=" & CStr(lObjectId), oFPConnection)
		End If
		
		While Not Rs.EOF
			Call oPlateMap.Add(CStr(Rs.Fields(0).Value) & CStr(Rs.Fields(1).Value), CStr(Rs.Fields(2).Value))
			Rs.MoveNext()
		End While
		
		Call fillPlateGrid(oPlateMap)
		
		Exit Sub
		
		
cboPlate_Click_Error: 
		If Not Rs Is Nothing Then
			Rs.Close()
		End If
		MsgBox(Err.Description)
	End Sub
	
	Private Sub frmViewPlate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Always use 384 format and let 96-plates take up only the top-left corner.
		Call fillPlateHeaders("384")
		If UCase(strType) = "PLATE" Then
			lblSelect.Text = "Select plate"
			Me.Text = "View Plate"
			Call fillPlateList()
		ElseIf UCase(strType) = "SCHEME" Then 
			lblSelect.Text = "Select scheme"
			Me.Text = "View Plate Scheme"
			Call fillSchemeList()
		End If
		
		'Check if there is a pre-selection, and try to show it.
		If strIdentifier <> "" Then
			cboPlate.Text = strIdentifier
			Call cboPlate_SelectedIndexChanged(cboPlate, New System.EventArgs())
		End If
	End Sub
	
	Private Sub fillPlateList()
		Dim Rs As New ADODB.Recordset
		
		On Error GoTo fillPlateList_Error
		
		Rs.Open("SELECT id, identifier FROM plate WHERE deleted = 0", oFPConnection)
		If Not Rs Is Nothing Then
			While Not Rs.EOF
				cboPlate.Items.Add((Rs.Fields(1).Value))
				Rs.MoveNext()
			End While
			Rs.Close()
		End If
		Exit Sub
		
fillPlateList_Error: 
		If Not Rs Is Nothing Then
			Rs.Close()
		End If
		MsgBox(Err.Description)
	End Sub
	
	Private Sub fillSchemeList()
		Dim Rs As New ADODB.Recordset
		
		On Error GoTo fillSchemeList_Error
		
		Rs.Open("SELECT id, identifier FROM plate_scheme WHERE deleted = 0", oFPConnection)
		If Not Rs Is Nothing Then
			While Not Rs.EOF
				cboPlate.Items.Add((Rs.Fields(1).Value))
				Rs.MoveNext()
			End While
			Rs.Close()
		End If
		Exit Sub
		
fillSchemeList_Error: 
		If Not Rs Is Nothing Then
			Rs.Close()
		End If
		MsgBox(Err.Description)
	End Sub
	
	Private Sub fillPlateGrid(ByRef oInPlate As Scripting.Dictionary)
		'Input is a dictionary with wells as keys (e.g. "B9") and the
		'information to be shown in the flex grid as string values.
		Dim i As Short
		Dim j As Short
		Dim strWell As String
		
		For i = 1 To flexPlate.Rows - 1
			For j = 1 To flexPlate.get_Cols() - 1
				strWell = Chr(64 + i) & CStr(j)
				If oInPlate.Exists(strWell) Then
					'UPGRADE_WARNING: Couldn't resolve default property of object oInPlate(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					flexPlate.set_TextMatrix(i, j, oInPlate(strWell))
				End If
			Next j
		Next i
	End Sub
	
	Private Sub showTitle(ByRef strInIdentifier As String)
		Me.Text = strInIdentifier
	End Sub
	
	'UPGRADE_WARNING: Event frmViewPlate.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmViewPlate_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		If Not Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then
			flexPlate.Top = VB6.TwipsToPixelsY(100)
			flexPlate.Left = VB6.TwipsToPixelsX(100)
			If VB6.PixelsToTwipsY(Me.Height) >= 2000 Then
				btnClose.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - VB6.PixelsToTwipsY(btnClose.Height) - 100)
				cboPlate.Top = btnClose.Top
				lblSelect.Top = btnClose.Top
				flexPlate.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(btnClose.Top) - VB6.PixelsToTwipsY(flexPlate.Top) - 100)
			Else
				Me.Height = VB6.TwipsToPixelsY(2000)
			End If
			If VB6.PixelsToTwipsX(Me.Width) >= 6000 Then
				btnClose.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnClose.Width) - 100)
				flexPlate.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 200)
			Else
				Me.Width = VB6.TwipsToPixelsX(6000)
			End If
		End If
	End Sub
End Class