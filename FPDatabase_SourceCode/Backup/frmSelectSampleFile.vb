Option Strict Off
Option Explicit On
Friend Class frmSelectSampleFile
	Inherits System.Windows.Forms.Form
	Private oOwner As frmPlateScheme
	Private oFPConnection As ADODB.Connection
	
	Private Sub btnBrowse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnBrowse.Click
		' CancelError is True.
		On Error GoTo ErrHandler
		' Set filters.
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		CommonDialog1Open.Filter = "All Files (*.*)|*.*|Text Files (*.txt) |*.txt|"
		' Specify default filter.
		CommonDialog1Open.FilterIndex = 2
		
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
		CommonDialog1.CancelError = True
		
		'UPGRADE_WARNING: FileOpenConstants constant FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		'UPGRADE_WARNING: MSComDlg.CommonDialog property CommonDialog1.Flags was upgraded to CommonDialog1Open.CheckFileExists which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		CommonDialog1Open.CheckFileExists = True
		CommonDialog1Open.CheckPathExists = True
		'UPGRADE_WARNING: MSComDlg.CommonDialog property CommonDialog1.Flags was upgraded to CommonDialog1Open.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		'UPGRADE_WARNING: FileOpenConstants constant FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		CommonDialog1Open.ShowReadOnly = False
		
		Dim sPath As String
		sPath = getPathVariable(chiRegSampleFileOpenPath)
		
		If sPath <> "" Then
			CommonDialog1Open.InitialDirectory = sPath
		End If
		
		'UPGRADE_WARNING: FileOpenConstants constant FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		'UPGRADE_WARNING: MSComDlg.CommonDialog property CommonDialog1.Flags was upgraded to CommonDialog1Open.CheckFileExists which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		CommonDialog1Open.CheckFileExists = True
		CommonDialog1Open.CheckPathExists = True
		'UPGRADE_WARNING: MSComDlg.CommonDialog property CommonDialog1.Flags was upgraded to CommonDialog1Open.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		'UPGRADE_WARNING: FileOpenConstants constant FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
		CommonDialog1Open.ShowReadOnly = False
		
		' Display the Open dialog box.
		CommonDialog1Open.ShowDialog()
		' Call the open file procedure.
		txtSampleFileName.Text = CommonDialog1Open.FileName
		
		Call SetPathVariable(chiRegSampleFileOpenPath, getPath((CommonDialog1Open.FileName)))
		
		Exit Sub
ErrHandler: 
		Exit Sub
	End Sub
	
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		Me.Close()
	End Sub
	
	Private Sub btnOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOK.Click
		Dim oFile As New Scripting.FileSystemObject
		If Not oFile.FileExists(txtSampleFileName.Text) Then
			MsgBox("You need to choose an existing file")
		End If
		
		If TreeViewLoadOrder.SelectedNode Is Nothing Then
			MsgBox("You need to choose a load order")
			Exit Sub
		Else
			If TreeViewLoadOrder.SelectedNode.Parent Is Nothing Then
				MsgBox("You need to choose a load order")
				Exit Sub
			End If
		End If
		
		Call oOwner.ReadSampleFile(txtSampleFileName.Text, TreeViewLoadOrder.SelectedNode.Text)
		
		Me.Close()
	End Sub
	
	Public Sub Initialize(ByRef oInOwner As frmPlateScheme, ByRef oInFPConnection As ADODB.Connection)
		oOwner = oInOwner
		oFPConnection = oInFPConnection
	End Sub
	
	Private Sub btnSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSearch.Click
		Dim iSelectedNodeIndex As Short
		If Not TreeViewLoadOrder.SelectedNode Is Nothing Then
			If TreeViewLoadOrder.SelectedNode.Parent Is Nothing Then
				iSelectedNodeIndex = TreeViewLoadOrder.SelectedNode.Index
			Else
				iSelectedNodeIndex = TreeViewLoadOrder.SelectedNode.Parent.Index
			End If
		End If
		Call searchAndFillLstLoadOrder((txtSearch.Text))
		If iSelectedNodeIndex <> 0 Then
			'UPGRADE_WARNING: Lower bound of collection TreeViewLoadOrder.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewLoadOrder.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			TreeViewLoadOrder.Nodes.Item(iSelectedNodeIndex).Selected = True
		End If
	End Sub
	
	Private Sub frmSelectSampleFile_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Call searchAndFillLstLoadOrder("")
	End Sub
	
	Private Sub searchAndFillLstLoadOrder(ByRef searchText As String)
		
		TreeViewLoadOrder.Nodes.Clear()
		
		Dim sqlCommand As String
		sqlCommand = "SELECT id, identifier, created " & "FROM load_order " & "WHERE person_id = ?  AND identifier LIKE ?"
		
		If optOrderByDate.Checked = True Then
			sqlCommand = sqlCommand & " ORDER BY created"
		Else
			sqlCommand = sqlCommand & " ORDER BY identifier"
		End If
		
		Dim cmdGetPlateScheme As New ADODB.Command
		Dim prmPerson As ADODB.Parameter
		Dim prmSearchString As ADODB.Parameter
		
		cmdGetPlateScheme.ActiveConnection = oFPConnection
		cmdGetPlateScheme.CommandText = sqlCommand
		cmdGetPlateScheme.CommandType = ADODB.CommandTypeEnum.adCmdText
		cmdGetPlateScheme.Prepared = True
		
		prmPerson = cmdGetPlateScheme.CreateParameter("person_id", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 15, 0)
		cmdGetPlateScheme.Parameters.Append(prmPerson)
		prmSearchString = cmdGetPlateScheme.CreateParameter("search_string", ADODB.DataTypeEnum.adVarChar, ADODB.ParameterDirectionEnum.adParamInput, 1000, "")
		cmdGetPlateScheme.Parameters.Append(prmSearchString)
		
		Dim Rs As New ADODB.Recordset
		Dim Rs2 As New ADODB.Recordset
		
		Rs.Open("SELECT name, id FROM person ORDER BY name", oFPConnection)
		
		While Not Rs.EOF
			TreeViewLoadOrder.Nodes.Add("person_" & CStr(Rs.Fields(1).Value), CStr(Rs.Fields(0).Value))
			Rs.MoveNext()
		End While
		
		Rs.MoveFirst()
		While Not Rs.EOF
			cmdGetPlateScheme.Parameters("person_id").Value = CInt(Rs.Fields(1).Value)
			cmdGetPlateScheme.Parameters("search_string").Value = "%" & searchText & "%"
			Rs2 = cmdGetPlateScheme.Execute
			While Not Rs2.EOF
				'UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
				TreeViewLoadOrder.Nodes.Find("person_" & CStr(Rs.Fields(1).Value), True)(0).Nodes.Add("schema_" & CStr(Rs2.Fields(0).Value), CStr(Rs2.Fields(1).Value))
				Rs2.MoveNext()
			End While
			Rs2.Close()
			Rs.MoveNext()
		End While
	End Sub
	
	'UPGRADE_WARNING: Event frmSelectSampleFile.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmSelectSampleFile_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		If Not Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then
			lblSampleFileName.Top = VB6.TwipsToPixelsY(100)
			lblSampleFileName.Left = VB6.TwipsToPixelsX(100)
			txtSampleFileName.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(lblSampleFileName.Top) + VB6.PixelsToTwipsY(lblSampleFileName.Height))
			txtSampleFileName.Left = VB6.TwipsToPixelsX(100)
			btnBrowse.Top = txtSampleFileName.Top
			TreeViewLoadOrder.Left = VB6.TwipsToPixelsX(100)
			lblloadOrder.Left = VB6.TwipsToPixelsX(100)
			txtSearch.Left = VB6.TwipsToPixelsX(100)
			
			If VB6.PixelsToTwipsY(Me.Height) >= 7000 Then
				lblloadOrder.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(txtSampleFileName.Top) + VB6.PixelsToTwipsY(txtSampleFileName.Height) + 200)
				TreeViewLoadOrder.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(lblloadOrder.Top) + VB6.PixelsToTwipsY(lblloadOrder.Height))
				
				btnOK.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - VB6.PixelsToTwipsY(btnOK.Height) - 100)
				btnCancel.Top = btnOK.Top
				
				frameOrderOptions.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(btnOK.Top) - VB6.PixelsToTwipsY(frameOrderOptions.Height) - 100)
				txtSearch.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(frameOrderOptions.Top) + 100)
				btnSearch.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(txtSearch.Top) + VB6.PixelsToTwipsY(txtSearch.Height) + 100)
				
				TreeViewLoadOrder.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(frameOrderOptions.Top) - VB6.PixelsToTwipsY(TreeViewLoadOrder.Top) - 100)
			Else
				Me.Height = VB6.TwipsToPixelsY(7000)
			End If
			
			If VB6.PixelsToTwipsX(Me.Width) >= 5000 Then
				txtSampleFileName.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnBrowse.Width) - 300)
				btnBrowse.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnBrowse.Width) - 100)
				
				TreeViewLoadOrder.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 200)
				
				btnOK.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnOK.Width) - 100)
				btnCancel.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(btnOK.Left) - VB6.PixelsToTwipsX(btnCancel.Width) - 100)
				
				frameOrderOptions.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(frameOrderOptions.Width) - 100)
				
				txtSearch.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(frameOrderOptions.Left) - VB6.PixelsToTwipsX(txtSearch.Left) - 100)
				btnSearch.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(txtSearch.Left) + VB6.PixelsToTwipsX(txtSearch.Width) - VB6.PixelsToTwipsX(btnSearch.Width))
			Else
				Me.Width = VB6.TwipsToPixelsX(5000)
			End If
		End If
	End Sub
	
	'UPGRADE_WARNING: Event optOrderByDate.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optOrderByDate_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optOrderByDate.CheckedChanged
		If eventSender.Checked Then
			Dim iSelectedNodeIndex As Short
			If Not TreeViewLoadOrder.SelectedNode Is Nothing Then
				If TreeViewLoadOrder.SelectedNode.Parent Is Nothing Then
					iSelectedNodeIndex = TreeViewLoadOrder.SelectedNode.Index
				Else
					iSelectedNodeIndex = TreeViewLoadOrder.SelectedNode.Parent.Index
				End If
			End If
			Call searchAndFillLstLoadOrder("")
			If iSelectedNodeIndex <> 0 Then
				'UPGRADE_WARNING: Lower bound of collection TreeViewLoadOrder.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewLoadOrder.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				TreeViewLoadOrder.Nodes.Item(iSelectedNodeIndex).Selected = True
			End If
		End If
	End Sub
	
	'UPGRADE_WARNING: Event optOrderByName.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optOrderByName_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optOrderByName.CheckedChanged
		If eventSender.Checked Then
			Dim iSelectedNodeIndex As Short
			If Not TreeViewLoadOrder.SelectedNode Is Nothing Then
				If TreeViewLoadOrder.SelectedNode.Parent Is Nothing Then
					iSelectedNodeIndex = TreeViewLoadOrder.SelectedNode.Index
				Else
					iSelectedNodeIndex = TreeViewLoadOrder.SelectedNode.Parent.Index
				End If
			End If
			Call searchAndFillLstLoadOrder("")
			If iSelectedNodeIndex <> 0 Then
				'UPGRADE_WARNING: Lower bound of collection TreeViewLoadOrder.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewLoadOrder.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				TreeViewLoadOrder.Nodes.Item(iSelectedNodeIndex).Selected = True
			End If
		End If
	End Sub
	
	Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim iSelectedNodeIndex As Short
		If KeyAscii = 13 Then
			If Not TreeViewLoadOrder.SelectedNode Is Nothing Then
				If TreeViewLoadOrder.SelectedNode.Parent Is Nothing Then
					iSelectedNodeIndex = TreeViewLoadOrder.SelectedNode.Index
				Else
					iSelectedNodeIndex = TreeViewLoadOrder.SelectedNode.Parent.Index
				End If
			End If
			Call searchAndFillLstLoadOrder((txtSearch.Text))
			If iSelectedNodeIndex <> 0 Then
				'UPGRADE_WARNING: Lower bound of collection TreeViewLoadOrder.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewLoadOrder.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				TreeViewLoadOrder.Nodes.Item(iSelectedNodeIndex).Selected = True
			End If
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class