Option Strict Off
Option Explicit On
Friend Class frmPlateSchemeLoadOrder
	Inherits System.Windows.Forms.Form
	Private oFPConnection As ADODB.Connection
	Private sPlateFormat As String
	Private sPlateSchemeLoadOrderName As String
	Private oSamplePosition As Scripting.Dictionary
	Private lCounter As Integer
	Private bEmptyCell As Boolean
	
	Public Sub Initialize(ByRef oInFPConnection As ADODB.Connection, ByVal sInPlateFormat As String, ByVal sInPlateSchemeLoadOrderName As String)
		oFPConnection = oInFPConnection
		sPlateFormat = sInPlateFormat
		sPlateSchemeLoadOrderName = sInPlateSchemeLoadOrderName
	End Sub
	
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		Dim iAnswer As Short
		iAnswer = MsgBox("Are you sure you want to quit?", MsgBoxStyle.YesNo)
		If iAnswer = MsgBoxResult.Yes Then
			Me.Close()
		End If
	End Sub
	
	
	Private Sub btnSaveLoadOrder_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSaveLoadOrder.Click
		
		On Error GoTo btnSaveLoadOrder_Error
		
		'looping over all the wells and storing the order in which they are entered
		
		Dim lRow As Integer
		Dim lColumn As Integer
		Dim lLoadOrderId As Integer
		Dim Rs As New ADODB.Recordset
		
		'creating a prepared statement to store the load_order
		Dim LoadOrderMap As New ADODB.Command
		Dim LoadOrderId As New ADODB.Parameter
		Dim LoadOrderCounter As New ADODB.Parameter
		Dim LoadOrderWellRow As New ADODB.Parameter
		Dim LoadOrderWellColumn As New ADODB.Parameter
		
		LoadOrderMap.ActiveConnection = oFPConnection
		LoadOrderMap.CommandText = "INSERT INTO load_order_map(load_order_id, counter, well_row, well_column) VALUES(?,?,?,?)"
		LoadOrderMap.CommandType = ADODB.CommandTypeEnum.adCmdText
		LoadOrderMap.Prepared = True
		
		LoadOrderId = LoadOrderMap.CreateParameter("load_order_id", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 16, 0)
		LoadOrderMap.Parameters.Append(LoadOrderId)
		
		LoadOrderCounter = LoadOrderMap.CreateParameter("counter", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 10, 0)
		LoadOrderMap.Parameters.Append(LoadOrderCounter)
		
		LoadOrderWellRow = LoadOrderMap.CreateParameter("well_row", ADODB.DataTypeEnum.adVarChar, ADODB.ParameterDirectionEnum.adParamInput, 3, "")
		LoadOrderMap.Parameters.Append(LoadOrderWellRow)
		
		LoadOrderWellColumn = LoadOrderMap.CreateParameter("well_column", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 10, 0)
		LoadOrderMap.Parameters.Append(LoadOrderWellColumn)
		
		oFPConnection.BeginTrans()
		
		'creating the load order
		oFPConnection.Execute("INSERT INTO load_order(identifier) VALUES('" & sPlateSchemeLoadOrderName & "')")
		Rs.Open("SELECT SCOPE_IDENTITY()", oFPConnection)
		
		If Rs.EOF Then
			Err.Raise(-100000,  , "Unable to create the load order")
		ElseIf Rs.Fields(0).Value = 0 Then 
			Err.Raise(-100000,  , "Unable to create the load order")
		Else
			lLoadOrderId = Rs.Fields(0).Value
			Rs.Close()
		End If
		
		
		
		For lRow = 1 To flexPlate.Rows - 1
			For lColumn = 1 To flexPlate.get_Cols() - 1
				LoadOrderMap.Parameters("load_order_id").Value = lLoadOrderId
				LoadOrderMap.Parameters("counter").Value = flexPlate.get_TextMatrix(lRow, lColumn)
				LoadOrderMap.Parameters("well_row").Value = Chr(64 + lRow)
				LoadOrderMap.Parameters("well_column").Value = lColumn
				LoadOrderMap.Execute()
			Next lColumn
		Next lRow
		
		oFPConnection.CommitTrans()
		
		MsgBox("Load order succesfully saved")
		
		Exit Sub
btnSaveLoadOrder_Error: 
		MsgBox(Err.Description)
		'UPGRADE_NOTE: Object Rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Rs = Nothing
		oFPConnection.RollbackTrans()
		Exit Sub
		
	End Sub
	
	Private Sub flexPlate_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles flexPlate.ClickEvent
		Dim lRow As Integer
		Dim lColumn As Integer
		
		bEmptyCell = False
		
		
		lRow = flexPlate.Row
		lColumn = flexPlate.Col
		If flexPlate.get_TextMatrix(lRow, lColumn) = "" Then
			flexPlate.set_TextMatrix(lRow, lColumn, lCounter)
			lCounter = lCounter + 1
		End If
		
		'need to loop over all the cells and check if they are all filled in....
		
		For lRow = 1 To flexPlate.Rows - 1
			For lColumn = 1 To flexPlate.get_Cols() - 1
				If flexPlate.get_TextMatrix(lRow, lColumn) = "" Then
					bEmptyCell = True
				End If
			Next lColumn
		Next lRow
		
		If bEmptyCell = False Then
			btnSaveLoadOrder.Enabled = True
		End If
	End Sub
	
	Private Sub frmPlateSchemeLoadOrder_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Call fillPlateHeaders(sPlateFormat)
		lCounter = 1
		btnSaveLoadOrder.Enabled = False
		bEmptyCell = False
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
	
	'UPGRADE_WARNING: Event frmPlateSchemeLoadOrder.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmPlateSchemeLoadOrder_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		
		If Not Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then
			flexPlate.Top = VB6.TwipsToPixelsY(100)
			flexPlate.Left = VB6.TwipsToPixelsX(100)
			If VB6.PixelsToTwipsY(Me.Height) >= 6700 Then
				btnSaveLoadOrder.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - VB6.PixelsToTwipsY(btnSaveLoadOrder.Height) - 100)
				btnCancel.Top = btnSaveLoadOrder.Top
				flexPlate.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(btnSaveLoadOrder.Top) - VB6.PixelsToTwipsY(flexPlate.Top) - 100)
			Else
				Me.Height = VB6.TwipsToPixelsY(6700)
			End If
			If VB6.PixelsToTwipsX(Me.Width) >= 12000 Then
				btnSaveLoadOrder.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnSaveLoadOrder.Width) - 100)
				btnCancel.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(btnSaveLoadOrder.Left) - VB6.PixelsToTwipsX(btnCancel.Width) - 100)
				flexPlate.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(flexPlate.Left) - 100)
			Else
				Me.Width = VB6.TwipsToPixelsX(12000)
			End If
		End If
	End Sub
End Class