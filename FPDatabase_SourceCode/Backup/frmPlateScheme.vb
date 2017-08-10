Option Strict Off
Option Explicit On
Friend Class frmPlateScheme
	Inherits System.Windows.Forms.Form
	Private oGtdbConnection As ADODB.Connection
	Private oFPConnection As ADODB.Connection
	Private sPlateFormat As String
	Private sPlateSchemeName As String
	Private oSampleList As Scripting.Dictionary
	
	Public Sub Initialize(ByRef oInGtdbConnection As ADODB.Connection, ByRef oInFPConnection As ADODB.Connection, ByVal sInPlateFormat As String, ByVal sInPlateSchemeName As String)
		oGtdbConnection = oInGtdbConnection
		oFPConnection = oInFPConnection
		sPlateFormat = sInPlateFormat
		sPlateSchemeName = sInPlateSchemeName
	End Sub
	
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		Dim iAnswer As Short
		iAnswer = MsgBox("Are you sure you want to quit?", MsgBoxStyle.YesNo)
		If iAnswer = MsgBoxResult.Yes Then
			Me.Close()
		End If
	End Sub
	
	Private Sub btnExcel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnExcel.Click
		Dim colSamples As Collection
		Dim oSampleX As Object
		Dim intNumberOfWells As Short
		Dim strWell As String
		Dim i As Short
		Dim j As Short
		
		On Error GoTo btnExcel_Error
		
		colSamples = ReadSampleName
		
		If Not colSamples Is Nothing Then
			intNumberOfWells = CShort(sPlateFormat)
			For i = 1 To flexPlate.Rows - 1
				For j = 1 To flexPlate.get_Cols() - 1
					strWell = Chr(64 + i) & CStr(j)
					'UPGRADE_WARNING: Couldn't resolve default property of object colSamples(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					flexPlate.set_TextMatrix(i, j, colSamples.Item(strWell))
				Next j
			Next i
		End If
		Exit Sub
		
btnExcel_Error: 
		MsgBox("Error while copying samples from Excel sheet. The selected cell range may not fit into the plate.")
		Call flexPlate.Clear()
		Call fillPlateHeaders(sPlateFormat)
	End Sub
	
	Private Sub btnReadFromFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnReadFromFile.Click
		Call frmSelectSampleFile.Initialize(Me, oFPConnection)
		frmSelectSampleFile.Show()
	End Sub
	
	Private Sub btnSaveScheme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSaveScheme.Click
		'creating the plate first and then adding all the samples to the plate map...
		
		Dim Rs As New ADODB.Recordset
		
		On Error GoTo btnSaveScheme_Error
		
		'creating a prepared statements to add the plate_scheme_map to the database
		
		Dim oPlateSchemeMap As New ADODB.Command
		Dim oSampleId As New ADODB.Parameter
		Dim oWellRow As New ADODB.Parameter
		Dim oWellColumn As New ADODB.Parameter
		Dim oPlateSchemeId As New ADODB.Parameter
		
		
		oPlateSchemeMap.ActiveConnection = oFPConnection
		oPlateSchemeMap.CommandText = "INSERT INTO plate_scheme_map(sample_id, well_row, well_column, plate_scheme_id) VALUES(?,?,?,?)"
		oPlateSchemeMap.CommandType = ADODB.CommandTypeEnum.adCmdText
		oPlateSchemeMap.Prepared = True
		
		oSampleId = oPlateSchemeMap.CreateParameter("sample_id", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 15, 0)
		oPlateSchemeMap.Parameters.Append(oSampleId)
		
		oWellRow = oPlateSchemeMap.CreateParameter("well_row", ADODB.DataTypeEnum.adVarChar, ADODB.ParameterDirectionEnum.adParamInput, 1, "")
		oPlateSchemeMap.Parameters.Append(oWellRow)
		
		oWellColumn = oPlateSchemeMap.CreateParameter("well_column", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 2, 0)
		oPlateSchemeMap.Parameters.Append(oWellColumn)
		
		oPlateSchemeId = oPlateSchemeMap.CreateParameter("plate_scheme_id", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 15, 0)
		oPlateSchemeMap.Parameters.Append(oPlateSchemeId)
		
		
		Dim oSample As New ADODB.Command
		Dim oSampleIdentifier As New ADODB.Parameter
		
		oSample.ActiveConnection = oFPConnection
		oSample.CommandText = "SELECT id FROM sample WHERE identifier = ?"
		oSample.CommandType = ADODB.CommandTypeEnum.adCmdText
		oSample.Prepared = True
		
		oSampleIdentifier = oSample.CreateParameter("identifier", ADODB.DataTypeEnum.adVarChar, ADODB.ParameterDirectionEnum.adParamInput, 255, "")
		oSample.Parameters.Append(oSampleIdentifier)
		
		
		Dim oSampleInsert As New ADODB.Command
		Dim oSampleInsertIdentifier As New ADODB.Parameter
		oSampleInsert.ActiveConnection = oFPConnection
		oSampleInsert.CommandText = "INSERT INTO sample(identifier) VALUES(?) SELECT SCOPE_IDENTITY()"
		oSampleInsert.CommandType = ADODB.CommandTypeEnum.adCmdText
		oSampleInsert.Prepared = True
		
		oSampleInsertIdentifier = oSampleInsert.CreateParameter("identifier", ADODB.DataTypeEnum.adVarChar, ADODB.ParameterDirectionEnum.adParamInput, 255, "")
		oSampleInsert.Parameters.Append(oSampleInsertIdentifier)
		
		
		oFPConnection.BeginTrans()
		
		
		Dim lPlateSchemeId As Integer
		oFPConnection.Execute("INSERT INTO plate_scheme(identifier) VALUES('" & sPlateSchemeName & "')")
		Rs.Open("SELECT SCOPE_IDENTITY()", oFPConnection)
		
		lPlateSchemeId = Rs.Fields(0).Value
		Rs.Close()
		
		
		'looping over all the wells in the plate schema
		
		Dim lRow As Integer
		Dim lColumn As Integer
		Dim lSampleId As Integer
		
		For lRow = 1 To flexPlate.Rows - 1
			For lColumn = 1 To flexPlate.get_Cols() - 1
				If CStr(Trim(flexPlate.get_TextMatrix(lRow, lColumn))) <> "" Then
					oSample.Parameters("identifier").Value = flexPlate.get_TextMatrix(lRow, lColumn)
					'checking if the sample exists
					Rs = oSample.Execute
					If Rs.EOF Then
						'need to create the sample
						oSampleInsert.Parameters("identifier").Value = flexPlate.get_TextMatrix(lRow, lColumn)
						oSampleInsert.Execute()
						oSample.Parameters("identifier").Value = flexPlate.get_TextMatrix(lRow, lColumn)
						Rs = oSample.Execute
						lSampleId = Rs.Fields(0).Value
						Rs.Close()
					Else
						lSampleId = Rs.Fields(0).Value
						Rs.Close()
					End If
					
					oPlateSchemeMap.Parameters("sample_id").Value = lSampleId
					oPlateSchemeMap.Parameters("well_row").Value = Chr(lRow + 64)
					oPlateSchemeMap.Parameters("well_column").Value = lColumn
					oPlateSchemeMap.Parameters("plate_scheme_id").Value = lPlateSchemeId
					oPlateSchemeMap.Execute()
				End If
			Next lColumn
		Next lRow
		
		oFPConnection.CommitTrans()
		
		MsgBox("Plate-scheme succesfully saved")
		
		Exit Sub
		
btnSaveScheme_Error: 
		MsgBox(Err.Description)
		oFPConnection.RollbackTrans()
		Exit Sub
		
	End Sub
	
	Private Sub flexPlate_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles flexPlate.ClickEvent
		Dim lRow As Integer
		Dim lColumn As Integer
		
		With flexPlate
			lstSamples.SetBounds(VB6.TwipsToPixelsX(.CellLeft + VB6.PixelsToTwipsX(.Left)), VB6.TwipsToPixelsY(.CellTop + VB6.PixelsToTwipsY(.Top)), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
			System.Windows.Forms.Application.DoEvents()
			lRow = .Row
			lColumn = .Col
			If oSampleList.Exists(CStr(.get_TextMatrix(lRow, lColumn))) Then
				'UPGRADE_WARNING: Couldn't resolve default property of object oSampleList.Item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				lstSamples.SelectedIndex = oSampleList.Item(CStr(.get_TextMatrix(lRow, lColumn)))
			End If
		End With
		
		lstSamples.Visible = True
		
	End Sub
	
	
	Private Sub flexPlate_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles flexPlate.Scroll
		lstSamples.Visible = False
	End Sub
	
	Private Sub frmPlateScheme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
		lstSamples.Visible = False
	End Sub
	
	Private Sub frmPlateScheme_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		oSampleList = New Scripting.Dictionary
		Call fillLstSamples()
		Call fillPlateHeaders(sPlateFormat)
		
		Me.Text = sPlateSchemeName
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
	
	Private Sub fillLstSamples()
		' sub till fill the list with the aviable sample in the GTDB database
		
		lstSamples.Items.Clear()
		
		Dim lLargestWidth As Integer
		lLargestWidth = 0
		
		Dim Rs As New ADODB.Recordset
		Dim lCounter As Integer
		lCounter = 0
		
		Rs.Open("SELECT identifier FROM sample ORDER BY identifier", oGtdbConnection)
		
		Do Until Rs.EOF
			lstSamples.Items.Add(Rs.Fields(0).Value)
			oSampleList.Add(CStr(Rs.Fields(0).Value), lCounter)
			'UPGRADE_ISSUE: Form method frmPlateScheme.TextWidth was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			If TextWidth(CStr(Rs.Fields(0).Value)) > lLargestWidth Then
				'UPGRADE_ISSUE: Form method frmPlateScheme.TextWidth was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				lLargestWidth = TextWidth(CStr(Rs.Fields(0).Value))
			End If
			Rs.MoveNext()
			lCounter = lCounter + 1
		Loop 
		
		lstSamples.Width = VB6.TwipsToPixelsX(lLargestWidth + 400)
		lstSamples.Visible = False
	End Sub
	
	
	Private Sub frmPlateScheme_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
		lstSamples.Visible = False
	End Sub
	
	'UPGRADE_WARNING: Event frmPlateScheme.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmPlateScheme_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		
		If Not Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then
			
			lstSamples.Visible = False
			
			If VB6.PixelsToTwipsY(Me.Height) >= 2000 Then
				flexPlate.Top = VB6.TwipsToPixelsY(100)
				
				btnSaveScheme.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - VB6.PixelsToTwipsY(btnSaveScheme.Height) - 100)
				btnCancel.Top = btnSaveScheme.Top
				btnReadFromFile.Top = btnSaveScheme.Top
				btnExcel.Top = btnSaveScheme.Top
				
				flexPlate.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(btnSaveScheme.Top) - VB6.PixelsToTwipsY(flexPlate.Top) - 100)
				
			Else
				Me.Height = VB6.TwipsToPixelsY(2000)
			End If
			
			If VB6.PixelsToTwipsX(Me.Width) >= 3000 Then
				flexPlate.Left = VB6.TwipsToPixelsX(100)
				flexPlate.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 200)
				btnSaveScheme.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnSaveScheme.Width) - 100)
				btnCancel.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(btnSaveScheme.Left) - VB6.PixelsToTwipsX(btnCancel.Width) - 100)
				btnReadFromFile.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(btnCancel.Left) - VB6.PixelsToTwipsX(btnReadFromFile.Width) - 300)
				btnExcel.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(btnReadFromFile.Left) - VB6.PixelsToTwipsX(btnExcel.Width) - 100)
			Else
				Me.Width = VB6.TwipsToPixelsX(3000)
			End If
			
		End If
	End Sub
	
	'UPGRADE_WARNING: Event lstSamples.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub lstSamples_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstSamples.SelectedIndexChanged
		Dim lRow As Integer
		Dim lCoulumn As Integer
		
		
		
		lRow = flexPlate.Row
		lCoulumn = flexPlate.Col
		
		
		flexPlate.set_TextMatrix(lRow, lCoulumn, VB6.GetItemString(lstSamples, lstSamples.SelectedIndex))
		
		
		lstSamples.Visible = False
		
		'checking if all the cells are filled in.. in that case enable the save scheme button..
		Dim bNotFilledIn As Boolean
		bNotFilledIn = False
		
		For lRow = 1 To flexPlate.Rows - 1
			For lCoulumn = 1 To flexPlate.get_Cols() - 1
				If flexPlate.get_TextMatrix(lRow, lCoulumn) = "" Then
					bNotFilledIn = True
				End If
			Next lCoulumn
		Next lRow
		
		If bNotFilledIn = False Then
			btnSaveScheme.Enabled = True
		End If
		
		
	End Sub
	
	
	Public Sub ReadSampleFile(ByVal sFileName As String, ByVal sLoadOrderName As String)
		
		On Error GoTo ReadSampleFile_Error
		
		'trying to find the loadorder id first
		
		Dim Rs As New ADODB.Recordset
		Dim lLoadOrderId As Integer
		Rs.Open("SELECT id FROM load_order WHERE identifier ='" & sLoadOrderName & "'", oFPConnection)
		If Rs.EOF Then
			Err.Raise(-10000,  , "Could not read the id number of loadorder: " & sLoadOrderName)
		Else
			lLoadOrderId = Rs.Fields(0).Value
			Rs.Close()
		End If
		
		Dim oLoadOrder As New Scripting.Dictionary
		Dim oPlateCoordinate As New PlateCoordinate
		
		'reading the loadorder from the database
		Rs.Open("SELECT counter, well_row, well_column FROM load_order_map WHERE load_order_id = " & lLoadOrderId & " ORDER BY counter", oFPConnection)
		
		Do Until Rs.EOF
			oPlateCoordinate = New PlateCoordinate
			Call oPlateCoordinate.Initialize(Rs.Fields(1).Value, Rs.Fields(2).Value)
			oLoadOrder.Add(CInt(Rs.Fields(0).Value), oPlateCoordinate)
			'UPGRADE_NOTE: Object oPlateCoordinate may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			oPlateCoordinate = Nothing
			Rs.MoveNext()
		Loop 
		Rs.Close()
		
		
		Dim oFile As New Scripting.FileSystemObject
		Dim oStream As Scripting.TextStream
		
		oStream = oFile.OpenTextFile(sFileName)
		
		'reading line by line and checking where the sample should be put..
		Dim lRow As Integer
		Dim lColumn As Integer
		Dim sTextLine As String
		Dim lCounter As Integer
		lCounter = 1
		
		Do Until oStream.AtEndOfStream
			sTextLine = Trim(oStream.ReadLine)
			If oLoadOrder.Exists(lCounter) Then
				oPlateCoordinate = oLoadOrder.Item(lCounter)
				lRow = oPlateCoordinate.getRowNr
				lColumn = oPlateCoordinate.getColumnNr
				
				'checking if the sample exists in the database
				If Not oSampleList.Exists(sTextLine) Then
					Err.Raise(-10000,  , "The sample: " & sTextLine & " does not exists in the resultdatabase")
				Else
					flexPlate.set_TextMatrix(lRow, lColumn, sTextLine)
				End If
			Else
				Err.Raise(-10000,  , "The number of sample is higher than the load order size")
			End If
			
			lCounter = lCounter + 1
		Loop 
		
		oStream.Close()
		'UPGRADE_NOTE: Object oStream may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oStream = Nothing
		'UPGRADE_NOTE: Object oFile may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oFile = Nothing
		'UPGRADE_NOTE: Object Rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Rs = Nothing
		
		Exit Sub
ReadSampleFile_Error: 
		MsgBox(Err.Description)
	End Sub
End Class