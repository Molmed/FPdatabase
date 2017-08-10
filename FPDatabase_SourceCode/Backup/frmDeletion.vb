Option Strict Off
Option Explicit On
Friend Class frmDeletion
	Inherits System.Windows.Forms.Form
	
	Private oFPConnection As ADODB.Connection
	
	Public Sub Initialize(ByRef oInFPConnection As ADODB.Connection)
		oFPConnection = oInFPConnection
	End Sub
	
	Private Sub searchAndFillLstItems(ByRef itemType As String, ByRef searchText As String)
		
		TreeViewItems.Nodes.Clear()
		
		Dim sqlCommand As String
		If itemType = "Plate" Then
			sqlCommand = "SELECT id, identifier " & "FROM plate " & "WHERE person_id = ?  AND identifier LIKE ? " & "AND deleted = 0"
			
			sqlCommand = sqlCommand & " ORDER BY identifier"
			
		ElseIf itemType = "Plate Scheme" Then 
			sqlCommand = "SELECT id, identifier, created " & "FROM plate_scheme " & "WHERE person_id = ?  AND identifier LIKE ? " & "AND deleted = 0"
			
			If optOrderByDate.Checked = True Then
				sqlCommand = sqlCommand & " ORDER BY created"
			Else
				sqlCommand = sqlCommand & " ORDER BY identifier"
			End If
		End If
		
		
		Dim cmdGetItem As New ADODB.Command
		Dim prmPerson As ADODB.Parameter
		Dim prmSearchString As ADODB.Parameter
		
		cmdGetItem.ActiveConnection = oFPConnection
		cmdGetItem.CommandText = sqlCommand
		cmdGetItem.CommandType = ADODB.CommandTypeEnum.adCmdText
		cmdGetItem.Prepared = True
		
		prmPerson = cmdGetItem.CreateParameter("person_id", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 15, 0)
		cmdGetItem.Parameters.Append(prmPerson)
		prmSearchString = cmdGetItem.CreateParameter("search_string", ADODB.DataTypeEnum.adVarChar, ADODB.ParameterDirectionEnum.adParamInput, 1000, "")
		cmdGetItem.Parameters.Append(prmSearchString)
		
		Dim Rs As New ADODB.Recordset
		Dim Rs2 As New ADODB.Recordset
		
		Rs.Open("SELECT name, id FROM person ORDER BY name", oFPConnection)
		
		While Not Rs.EOF
			TreeViewItems.Nodes.Add("person_" & CStr(Rs.Fields(1).Value), CStr(Rs.Fields(0).Value))
			Rs.MoveNext()
		End While
		
		Rs.MoveFirst()
		While Not Rs.EOF
			cmdGetItem.Parameters("person_id").Value = CInt(Rs.Fields(1).Value)
			cmdGetItem.Parameters("search_string").Value = "%" & searchText & "%"
			Rs2 = cmdGetItem.Execute
			While Not Rs2.EOF
				'UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
				TreeViewItems.Nodes.Find("person_" & CStr(Rs.Fields(1).Value), True)(0).Nodes.Add("item_" & CStr(Rs2.Fields(0).Value), CStr(Rs2.Fields(1).Value))
				Rs2.MoveNext()
			End While
			Rs2.Close()
			Rs.MoveNext()
		End While
	End Sub
	
	Private Sub btnDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnDelete.Click
		Dim strDeleteCmd As String
		Dim strKeyParts() As String
		
		On Error GoTo btnDelete_Click_Error
		
		strKeyParts = Split(TreeViewItems.SelectedNode.Name, "_")
		If UBound(strKeyParts) <> 1 Then
			MsgBox("Error, could not delete.")
			Exit Sub
		End If
		If strKeyParts(0) = "person" Then
			MsgBox("Please select a valid item.")
			Exit Sub
		End If
		If MsgBox("Do you want to delete the " & LCase(cboItemType.Text) & " " & TreeViewItems.SelectedNode.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
			Exit Sub
		End If
		If cboItemType.Text = "Plate" Then
			strDeleteCmd = "UPDATE plate SET deleted=1 WHERE id=" & strKeyParts(1)
		ElseIf cboItemType.Text = "Plate Scheme" Then 
			strDeleteCmd = "UPDATE plate_scheme SET deleted=1 WHERE id=" & strKeyParts(1)
		End If
		oFPConnection.Execute(strDeleteCmd)
		'UPGRADE_WARNING: MSComctlLib.Nodes method TreeViewItems.Nodes.Remove has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		TreeViewItems.Nodes.RemoveAt((TreeViewItems.SelectedNode.Index))
		Exit Sub
		
btnDelete_Click_Error: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub btnOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOK.Click
		Me.Close()
	End Sub
	
	Private Sub btnSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSearch.Click
		Dim iSelectedNodeIndex As Short
		If Not TreeViewItems.SelectedNode Is Nothing Then
			If TreeViewItems.SelectedNode.Parent Is Nothing Then
				iSelectedNodeIndex = TreeViewItems.SelectedNode.Index
			Else
				iSelectedNodeIndex = TreeViewItems.SelectedNode.Parent.Index
			End If
		End If
		Call searchAndFillLstItems((cboItemType.Text), (txtSearch.Text))
		If iSelectedNodeIndex <> 0 Then
			'UPGRADE_WARNING: Lower bound of collection TreeViewItems.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewItems.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			TreeViewItems.Nodes.Item(iSelectedNodeIndex).Selected = True
		End If
	End Sub
	
	'UPGRADE_WARNING: Event frmDeletion.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmDeletion_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		If VB6.PixelsToTwipsY(Me.Height) > 7000 Then
			btnOK.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - VB6.PixelsToTwipsY(btnOK.Height) - 600)
			frameOrderOptions.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(btnOK.Top) - VB6.PixelsToTwipsY(frameOrderOptions.Height) - 200)
			btnSearch.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(btnOK.Top) - VB6.PixelsToTwipsY(btnSearch.Height) - 200)
			txtSearch.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(btnSearch.Top) - VB6.PixelsToTwipsY(txtSearch.Height) - 200)
			btnDelete.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(txtSearch.Top) - VB6.PixelsToTwipsY(btnDelete.Height) - 800)
			TreeViewItems.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - VB6.PixelsToTwipsY(TreeViewItems.Top) - 3500)
		End If
		If VB6.PixelsToTwipsX(Me.Width) > 5000 Then
			btnOK.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - VB6.PixelsToTwipsX(btnOK.Width) - 200)
			frameOrderOptions.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - VB6.PixelsToTwipsX(frameOrderOptions.Width) - 200)
			btnSearch.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(frameOrderOptions.Left) - VB6.PixelsToTwipsX(btnSearch.Width) - 100)
			txtSearch.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - VB6.PixelsToTwipsX(frameOrderOptions.Width) - 400)
			TreeViewItems.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 500)
			cboItemType.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 1000)
		End If
	End Sub
	
	'UPGRADE_WARNING: Event optOrderByDate.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optOrderByDate_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optOrderByDate.CheckedChanged
		If eventSender.Checked Then
			Dim iSelectedNodeIndex As Short
			If Not TreeViewItems.SelectedNode Is Nothing Then
				If TreeViewItems.SelectedNode.Parent Is Nothing Then
					iSelectedNodeIndex = TreeViewItems.SelectedNode.Index
				Else
					iSelectedNodeIndex = TreeViewItems.SelectedNode.Parent.Index
				End If
			End If
			Call searchAndFillLstItems((cboItemType.Text), "")
			If iSelectedNodeIndex <> 0 Then
				'UPGRADE_WARNING: Lower bound of collection TreeViewItems.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewItems.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				TreeViewItems.Nodes.Item(iSelectedNodeIndex).Selected = True
			End If
		End If
	End Sub
	
	'UPGRADE_WARNING: Event optOrderByName.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optOrderByName_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optOrderByName.CheckedChanged
		If eventSender.Checked Then
			Dim iSelectedNodeIndex As Short
			If Not TreeViewItems.SelectedNode Is Nothing Then
				If TreeViewItems.SelectedNode.Parent Is Nothing Then
					iSelectedNodeIndex = TreeViewItems.SelectedNode.Index
				Else
					iSelectedNodeIndex = TreeViewItems.SelectedNode.Parent.Index
				End If
			End If
			Call searchAndFillLstItems((cboItemType.Text), "")
			If iSelectedNodeIndex <> 0 Then
				'UPGRADE_WARNING: Lower bound of collection TreeViewItems.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewItems.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				TreeViewItems.Nodes.Item(iSelectedNodeIndex).Selected = True
			End If
		End If
	End Sub
	
	'UPGRADE_WARNING: Event cboItemType.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub cboItemType_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboItemType.SelectedIndexChanged
		If cboItemType.Text = "Plate" Then
			frameOrderOptions.Enabled = False
			optOrderByName.Enabled = False
			optOrderByDate.Enabled = False
		ElseIf cboItemType.Text = "Plate Scheme" Then 
			frameOrderOptions.Enabled = True
			optOrderByName.Enabled = True
			optOrderByDate.Enabled = True
		End If
		Call searchAndFillLstItems((cboItemType.Text), "")
	End Sub
	
	Private Sub frmDeletion_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		cboItemType.SelectedIndex = 0
		Call searchAndFillLstItems((cboItemType.Text), "")
	End Sub
	
	Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim iSelectedNodeIndex As Short
		If KeyAscii = 13 Then
			If Not TreeViewItems.SelectedNode Is Nothing Then
				If TreeViewItems.SelectedNode.Parent Is Nothing Then
					iSelectedNodeIndex = TreeViewItems.SelectedNode.Index
				Else
					iSelectedNodeIndex = TreeViewItems.SelectedNode.Parent.Index
				End If
			End If
			Call searchAndFillLstItems((cboItemType.Text), (txtSearch.Text))
			If iSelectedNodeIndex <> 0 Then
				'UPGRADE_WARNING: Lower bound of collection TreeViewItems.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewItems.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				TreeViewItems.Nodes.Item(iSelectedNodeIndex).Selected = True
			End If
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class