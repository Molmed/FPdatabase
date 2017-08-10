Option Strict Off
Option Explicit On
Friend Class frmPlateAdd
	Inherits System.Windows.Forms.Form
	Public bCancel As Boolean
	Private oFPConnection As ADODB.Connection
	Public Sub Initialize(ByRef oInFPConnection As ADODB.Connection)
		oFPConnection = oInFPConnection
	End Sub
	
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		Me.Close()
	End Sub
	
	Private Sub btnOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOK.Click
		Dim lPlateId As Integer
		Dim sPlateSchemeName As String
		'checking first that a platename has been enterd and that a plate-
		' scheme has been selected
		
		If txtPlateName.Text = "" Then
			MsgBox("You need to enter a plate name")
			Exit Sub
		End If
		
		If TreeViewPlateScheme.SelectedNode Is Nothing Then
			MsgBox("You need to select a plate-scheme")
			Exit Sub
		Else
			If TreeViewPlateScheme.SelectedNode.Parent Is Nothing Then
				MsgBox("You need to select a plate-scheme")
				Exit Sub
			End If
		End If
		sPlateSchemeName = TreeViewPlateScheme.SelectedNode.Text
		
		lPlateId = NonFormModule.createPlate(txtPlateName.Text, sPlateSchemeName, oFPConnection)
		
		If Not lPlateId = 0 Then
			MsgBox("Plate succesfully created")
		End If
	End Sub
	
	Private Sub btnSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSearch.Click
		Dim iSelectedNodeIndex As Short
		If Not TreeViewPlateScheme.SelectedNode Is Nothing Then
			If TreeViewPlateScheme.SelectedNode.Parent Is Nothing Then
				iSelectedNodeIndex = TreeViewPlateScheme.SelectedNode.Index
			Else
				iSelectedNodeIndex = TreeViewPlateScheme.SelectedNode.Parent.Index
			End If
		End If
		Call searchAndFillLstPlateSchemes((txtSearch.Text))
		If iSelectedNodeIndex <> 0 Then
			'UPGRADE_WARNING: Lower bound of collection TreeViewPlateScheme.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewPlateScheme.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			TreeViewPlateScheme.Nodes.Item(iSelectedNodeIndex).Selected = True
		End If
	End Sub
	
	Private Sub btnViewScheme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnViewScheme.Click
		Dim frmSchemeViewer As frmViewPlate
		
		frmSchemeViewer = New frmViewPlate
		Call frmSchemeViewer.Initialize(oFPConnection, "Scheme", TreeViewPlateScheme.SelectedNode.Text)
		frmSchemeViewer.ShowDialog()
		'UPGRADE_NOTE: Object frmSchemeViewer may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		frmSchemeViewer = Nothing
		Exit Sub
		
btnViewScheme_Click_Error: 
		'UPGRADE_NOTE: Object frmSchemeViewer may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		frmSchemeViewer = Nothing
		MsgBox(Err.Description)
	End Sub
	
	
	Private Sub frmPlateAdd_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		bCancel = False
		Call searchAndFillLstPlateSchemes("")
	End Sub
	
	Private Sub searchAndFillLstPlateSchemes(ByRef searchText As String)
		
		
		
		TreeViewPlateScheme.Nodes.Clear()
		
		Dim sqlCommand As String
		sqlCommand = "SELECT id, identifier, created " & "FROM plate_scheme " & "WHERE person_id = ?  AND identifier LIKE ? " & "AND deleted = 0"
		
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
			TreeViewPlateScheme.Nodes.Add("person_" & CStr(Rs.Fields(1).Value), CStr(Rs.Fields(0).Value))
			Rs.MoveNext()
		End While
		
		Rs.MoveFirst()
		While Not Rs.EOF
			cmdGetPlateScheme.Parameters("person_id").Value = CInt(Rs.Fields(1).Value)
			cmdGetPlateScheme.Parameters("search_string").Value = "%" & searchText & "%"
			Rs2 = cmdGetPlateScheme.Execute
			While Not Rs2.EOF
				'UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
				TreeViewPlateScheme.Nodes.Find("person_" & CStr(Rs.Fields(1).Value), True)(0).Nodes.Add("schema_" & CStr(Rs2.Fields(0).Value), CStr(Rs2.Fields(1).Value))
				Rs2.MoveNext()
			End While
			Rs2.Close()
			Rs.MoveNext()
		End While
	End Sub
	
	'UPGRADE_WARNING: Event frmPlateAdd.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmPlateAdd_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		
		If Not Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then
			lblPlateName.Top = VB6.TwipsToPixelsY(100)
			txtPlateName.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(lblPlateName.Top) + VB6.PixelsToTwipsY(lblPlateName.Height))
			lblPlateName.Left = VB6.TwipsToPixelsX(100)
			txtPlateName.Left = VB6.TwipsToPixelsX(100)
			
			lblSelectPlateScheme.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(txtPlateName.Top) + VB6.PixelsToTwipsY(txtPlateName.Height) + 200)
			lblSelectPlateScheme.Left = VB6.TwipsToPixelsX(100)
			
			TreeViewPlateScheme.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(lblSelectPlateScheme.Top) + VB6.PixelsToTwipsY(lblSelectPlateScheme.Height))
			TreeViewPlateScheme.Left = VB6.TwipsToPixelsX(100)
			
			
			txtSearch.Left = VB6.TwipsToPixelsX(100)
			btnViewScheme.Left = VB6.TwipsToPixelsX(100)
			
			
			If VB6.PixelsToTwipsY(Me.Height) >= 8000 Then
				btnOK.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - VB6.PixelsToTwipsY(btnOK.Height) - 100)
				btnCancel.Top = btnOK.Top
				
				frameOrderOptions.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(btnOK.Top) - VB6.PixelsToTwipsY(frameOrderOptions.Height) - 100)
				
				txtSearch.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(frameOrderOptions.Top) + 100)
				
				btnSearch.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(txtSearch.Top) + VB6.PixelsToTwipsY(txtSearch.Height) + 100)
				btnViewScheme.Top = btnSearch.Top
				
				txtPlateName.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(lblPlateName.Top) + VB6.PixelsToTwipsY(lblPlateName.Height))
				
				lblSelectPlateScheme.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(txtPlateName.Top) + VB6.PixelsToTwipsY(txtPlateName.Height) + 200)
				
				TreeViewPlateScheme.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(frameOrderOptions.Top) - VB6.PixelsToTwipsY(TreeViewPlateScheme.Top) - 100)
				
			Else
				Me.Height = VB6.TwipsToPixelsY(8000)
				Call frmPlateAdd_Resize(Me, New System.EventArgs())
			End If
			If VB6.PixelsToTwipsX(Me.Width) >= 5200 Then
				txtPlateName.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 200)
				TreeViewPlateScheme.Width = txtPlateName.Width
				txtSearch.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(txtPlateName.Width) - VB6.PixelsToTwipsX(frameOrderOptions.Width) - 200)
				
				btnSearch.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(txtSearch.Left) + VB6.PixelsToTwipsX(txtSearch.Width) - VB6.PixelsToTwipsX(btnSearch.Width))
				
				btnOK.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnOK.Width) - 100)
				btnCancel.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(btnOK.Left) - VB6.PixelsToTwipsX(btnCancel.Width) - 100)
				
				frameOrderOptions.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(txtPlateName.Width) - VB6.PixelsToTwipsX(frameOrderOptions.Width) + 100)
				
			Else
				Call frmPlateAdd_Resize(Me, New System.EventArgs())
				Me.Width = VB6.TwipsToPixelsX(5200)
			End If
			
		End If
	End Sub
	
	
	'UPGRADE_WARNING: Event optOrderByDate.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optOrderByDate_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optOrderByDate.CheckedChanged
		If eventSender.Checked Then
			Dim iSelectedNodeIndex As Short
			If Not TreeViewPlateScheme.SelectedNode Is Nothing Then
				If TreeViewPlateScheme.SelectedNode.Parent Is Nothing Then
					iSelectedNodeIndex = TreeViewPlateScheme.SelectedNode.Index
				Else
					iSelectedNodeIndex = TreeViewPlateScheme.SelectedNode.Parent.Index
				End If
			End If
			Call searchAndFillLstPlateSchemes("")
			If iSelectedNodeIndex <> 0 Then
				'UPGRADE_WARNING: Lower bound of collection TreeViewPlateScheme.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewPlateScheme.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				TreeViewPlateScheme.Nodes.Item(iSelectedNodeIndex).Selected = True
			End If
		End If
	End Sub
	
	'UPGRADE_WARNING: Event optOrderByName.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optOrderByName_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optOrderByName.CheckedChanged
		If eventSender.Checked Then
			Dim iSelectedNodeIndex As Short
			If Not TreeViewPlateScheme.SelectedNode Is Nothing Then
				If TreeViewPlateScheme.SelectedNode.Parent Is Nothing Then
					iSelectedNodeIndex = TreeViewPlateScheme.SelectedNode.Index
				Else
					iSelectedNodeIndex = TreeViewPlateScheme.SelectedNode.Parent.Index
				End If
			End If
			Call searchAndFillLstPlateSchemes("")
			If iSelectedNodeIndex <> 0 Then
				'UPGRADE_WARNING: Lower bound of collection TreeViewPlateScheme.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewPlateScheme.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				TreeViewPlateScheme.Nodes.Item(iSelectedNodeIndex).Selected = True
			End If
		End If
	End Sub
	
	Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim iSelectedNodeIndex As Short
		If KeyAscii = 13 Then
			If Not TreeViewPlateScheme.SelectedNode Is Nothing Then
				If TreeViewPlateScheme.SelectedNode.Parent Is Nothing Then
					iSelectedNodeIndex = TreeViewPlateScheme.SelectedNode.Index
				Else
					iSelectedNodeIndex = TreeViewPlateScheme.SelectedNode.Parent.Index
				End If
			End If
			Call searchAndFillLstPlateSchemes((txtSearch.Text))
			If iSelectedNodeIndex <> 0 Then
				'UPGRADE_WARNING: Lower bound of collection TreeViewPlateScheme.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewPlateScheme.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				TreeViewPlateScheme.Nodes.Item(iSelectedNodeIndex).Selected = True
			End If
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class