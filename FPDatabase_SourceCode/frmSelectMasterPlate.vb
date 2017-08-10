Option Strict Off
Option Explicit On
Friend Class frmSelectMasterPlate
	Inherits System.Windows.Forms.Form
	Public iAnswer As Short
	Private oFPConnection As ADODB.Connection
	Private sMasterPlateName As String
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		sMasterPlateName = ""
		Me.Hide()
	End Sub
	Private Sub btnOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOK.Click
		If Not TreeViewPlates.SelectedNode Is Nothing Then
			sMasterPlateName = TreeViewPlates.SelectedNode.Text
		End If
		Me.Hide()
	End Sub
	Private Sub btnSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSearch.Click
		Dim iSelectedNodeIndex As Short
		If Not TreeViewPlates.SelectedNode Is Nothing Then
			If TreeViewPlates.SelectedNode.Parent Is Nothing Then
				iSelectedNodeIndex = TreeViewPlates.SelectedNode.Index
			Else
				iSelectedNodeIndex = TreeViewPlates.SelectedNode.Parent.Index
			End If
		End If
		Call searchAndFill(txtSearch.Text)
        If iSelectedNodeIndex >= 0 Then
            'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewPlates.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            TreeViewPlates.SelectedNode() = TreeViewPlates.Nodes.Item(iSelectedNodeIndex)
        End If
	End Sub
	Private Sub frmSelectMasterPlate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Call searchAndFill("")
	End Sub
	'UPGRADE_WARNING: Event frmSelectMasterPlate.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmSelectMasterPlate_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize

        If oFPConnection Is Nothing Then
            Exit Sub
        End If
		If Not Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then
			
			TreeViewPlates.Top = VB6.TwipsToPixelsY(100)
			TreeViewPlates.Left = VB6.TwipsToPixelsX(100)
			txtSearch.Left = VB6.TwipsToPixelsX(100)
			
			If VB6.PixelsToTwipsY(Me.Height) >= 4000 Then
				btnOK.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - VB6.PixelsToTwipsY(btnOK.Height) - 100)
				btnCancel.Top = btnOK.Top
				btnSearch.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(btnOK.Top) - VB6.PixelsToTwipsY(btnSearch.Height) - 100)
				txtSearch.Top = btnSearch.Top
				
				TreeViewPlates.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(btnSearch.Top) - VB6.PixelsToTwipsY(TreeViewPlates.Top) - 100)
			Else
				Me.Height = VB6.TwipsToPixelsY(4000)
			End If
			If VB6.PixelsToTwipsX(Me.Width) >= 4800 Then
				btnOK.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnOK.Width) - 100)
				btnCancel.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(btnOK.Left) - VB6.PixelsToTwipsX(btnCancel.Width) - 100)
				btnSearch.Left = btnOK.Left
				txtSearch.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnSearch.Width) - 300)
				TreeViewPlates.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 200)
				
			Else
				Me.Width = VB6.TwipsToPixelsX(4800)
			End If
		End If
	End Sub
	
	
	Private Sub searchAndFill(ByRef searchText As String)
		
		TreeViewPlates.Nodes.Clear()
		
		Dim sqlCommand As String
		sqlCommand = "SELECT id, identifier " & "FROM plate " & "WHERE person_id = ?  AND identifier LIKE ? " & "AND deleted = 0 " & "ORDER BY identifier"
		
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
			TreeViewPlates.Nodes.Add("person_" & CStr(Rs.Fields(1).Value), CStr(Rs.Fields(0).Value))
			Rs.MoveNext()
		End While
		
		Rs.MoveFirst()
		While Not Rs.EOF
			cmdGetPlateScheme.Parameters("person_id").Value = CInt(Rs.Fields(1).Value)
			cmdGetPlateScheme.Parameters("search_string").Value = "%" & searchText & "%"
			Rs2 = cmdGetPlateScheme.Execute
			While Not Rs2.EOF
				'UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
				TreeViewPlates.Nodes.Find("person_" & CStr(Rs.Fields(1).Value), True)(0).Nodes.Add("schema_" & CStr(Rs2.Fields(0).Value), CStr(Rs2.Fields(1).Value))
				Rs2.MoveNext()
			End While
			Rs2.Close()
			Rs.MoveNext()
		End While
		
	End Sub
	
	Public Sub Init(ByRef oInFPConnection As ADODB.Connection)
		oFPConnection = oInFPConnection
	End Sub
	
	Public Function getPlateName() As String
		getPlateName = sMasterPlateName
	End Function
	
	Private Sub txtSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim iSelectedNodeIndex As Short
		If KeyAscii = 13 Then
			If Not TreeViewPlates.SelectedNode Is Nothing Then
				If TreeViewPlates.SelectedNode.Parent Is Nothing Then
					iSelectedNodeIndex = TreeViewPlates.SelectedNode.Index
				Else
					iSelectedNodeIndex = TreeViewPlates.SelectedNode.Parent.Index
				End If
			End If
			Call searchAndFill(txtSearch.Text)
            If iSelectedNodeIndex >= 0 Then
                'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewPlates.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                TreeViewPlates.SelectedNode() = TreeViewPlates.Nodes.Item(iSelectedNodeIndex)
            End If
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class