Option Strict Off
Option Explicit On
Friend Class FPresultDB
	Inherits System.Windows.Forms.Form
	Public bOK As Boolean
	Private oGtdbConnection As ADODB.Connection
	Private oFPConnection As ADODB.Connection
	Private lPlateId As Integer
	Private oldFormHeight As Short
	Private oPlatesWithData As New Scripting.Dictionary
	
	Public Sub Initialize(ByRef oInFPConnection As ADODB.Connection, ByRef oInGtdbConnection As ADODB.Connection)
		oFPConnection = oInFPConnection
		oGtdbConnection = oInGtdbConnection
	End Sub
	
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		Me.Close()
	End Sub
	
	Private Sub btnGenotypeBrowse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnGenotypeBrowse.Click
		Dim sFileName As String
		
		' CancelError is True.
		On Error GoTo ErrHandler
		' Set filters.
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		CommonDialog1Open.Filter = "All Files (*.*)|*.*|Genotype Files (*.out)|*.out|"
		' Specify default filter.
		CommonDialog1Open.FilterIndex = 2
		
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
		CommonDialog1.CancelError = True
		
		Dim sPath As String
		sPath = getPathVariable(chiRegGenotypeFileOpenPath)
		
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
		txtGeotypeFileName.Text = CommonDialog1Open.FileName
		
		Call SetPathVariable(chiRegGenotypeFileOpenPath, getPath((CommonDialog1Open.FileName)))
		
		' automatically filling in the outfile from marker program
		' finding the filename for the raw datafile
		Dim sFolderName As String
		Dim sDataFileName As String
		Dim sGenotypeFileName As String
		
ErrHandler: 
		Exit Sub
	End Sub
	
	Private Sub btnOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOK.Click
		
		
		Dim Rs As New ADODB.Recordset
		Dim lError As Integer
		Dim lSegmentId As Integer
		Dim lPersonId As Integer
		Dim lAssayId As Integer
		Dim sAssaySNPType As String
		Dim sAssayName As String
		Dim sPlateName As String
		
		If txtDataFileName.Text = "" Then
			MsgBox(" Please enter a raw data filename.")
			Exit Sub
		End If
		
		If txtGeotypeFileName.Text = "" Then
			MsgBox("Please enter a genotype filename.")
			Exit Sub
		End If
		
		If TreeViewPlates.SelectedNode Is Nothing Then
			MsgBox("You need to select a plate to upload the data to.")
			Exit Sub
		Else
			If TreeViewPlates.SelectedNode.Parent Is Nothing Then
				MsgBox("You need to select a plate to upload the data to.")
				Exit Sub
			End If
		End If
		
		On Error GoTo OKButton_Error
		
		sPlateName = TreeViewPlates.SelectedNode.Text
		sAssayName = lstAssays.FocusedItem.Text
		
		
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
		
		'reading the id of the person doing the insert...
		
		Rs.Open("SELECT id FROM person WHERE user_handel = SYSTEM_USER", oFPConnection)
		If Rs.EOF Then
			Err.Raise(-10000,  , "Unable to read the id of person")
		Else
			lPersonId = Rs.Fields(0).Value
			Rs.Close()
		End If
		
		' reading the plate name and reciving the id number
		' from the database
		Rs.Open("SELECT id FROM plate WHERE identifier = '" & sPlateName & "'")
		If Rs.EOF Then
			Err.Raise(-10000,  , "The id for the plate could not be read")
		Else
			lPlateId = Val(Rs.Fields(0).Value)
			Rs.Close()
		End If
		
		' reading the assay id from the result database.
		Rs.Open("SELECT assay_id FROM assay WHERE identifier='" & sAssayName & "'", oGtdbConnection)
		If Rs.EOF Then
			Err.Raise(-10000,  , "The id for the assay could not be read")
		Else
			lAssayId = Val(Rs.Fields(0).Value)
			Rs.Close()
		End If
		
		' reading the SNP type for the assay from the result database.
		Rs.Open("SELECT dbo.fDeNormAlleleVariant_NoFlip(" & CStr(lAssayId) & ")", oGtdbConnection)
		If Rs.EOF Then
			Err.Raise(-10000,  , "The appropriate SNP type could not be read from the result database")
		Else
			sAssaySNPType = Rs.Fields(0).Value
			Rs.Close()
		End If
		
		oFPConnection.BeginTrans()
		
		'Store the names of the selected files so that they are associated with the plate.
		Call oFPConnection.Execute("INSERT INTO filename (plate_id, rawdatafile, genotypefile) " & "VALUES (" & lPlateId & ", '" & txtDataFileName.Text & "', '" & txtGeotypeFileName.Text & "')")
		
		' now we are ready to run the program
		' parsing the raw datafile an upload to database
		lSegmentId = NonFormModule.RawDataFileParser(txtDataFileName.Text, oFPConnection, sAssayName, lPersonId, lPlateId)
		
		' checking if masterplateid is a valid masterplate
		' ie a nonzero number
		If lSegmentId = 0 Then
			Err.Raise(-10000,  , "The parsing of the rawdatafile failed")
		Else
			' if it is a valid number movefuther and set the sample names
			
			lError = NonFormModule.setGenotype(txtGeotypeFileName.Text, lSegmentId, sAssaySNPType, oFPConnection)
			
			' checking if it was aright
			If lError = 0 Then
				Err.Raise(-10000,  , "Unable to parse the genotype file")
			Else
				' updating the marker_id
				lError = NonFormModule.setMarker(sAssayName, lSegmentId, oFPConnection)
				
				If lError = 0 Then
					Err.Raise(CInt("Failed to write the assay to the database"))
				Else
					'Check if all defined wells received a genotype, otherwise warn user.
					Rs.Open("SELECT * FROM plate_map WHERE plate_id = " & CStr(lPlateId) & " AND genotype IS NULL", oFPConnection)
					If Not Rs.EOF Then
						If MsgBox("There were more wells on the plate than genotypes in the file. Continue anyway?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
							Err.Raise(-10000,  , "User aborted.")
						End If
					End If
					oFPConnection.CommitTrans()
					'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
					'UPGRADE_ISSUE: Form property FPresultDB.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
					Me.Cursor = vbNormal
					MsgBox("data succesfully updated to database")
					txtDataFileName.Text = ""
					txtGeotypeFileName.Text = ""
				End If
			End If
		End If
		
		
		Exit Sub
OKButton_Error: 
		'UPGRADE_ISSUE: Unable to determine which constant to upgrade vbNormal to. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"'
		'UPGRADE_ISSUE: Form property FPresultDB.MousePointer does not support custom mousepointers. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"'
		Me.Cursor = vbNormal
		MsgBox(Err.Description)
		oFPConnection.RollbackTrans()
		'UPGRADE_NOTE: Object Rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Rs = Nothing
	End Sub
	
	Private Sub btnPlateSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPlateSearch.Click
		
		Dim iSelectedNodeIndex As Short
		If Not TreeViewPlates.SelectedNode Is Nothing Then
			If TreeViewPlates.SelectedNode.Parent Is Nothing Then
				iSelectedNodeIndex = TreeViewPlates.SelectedNode.Index
			Else
				iSelectedNodeIndex = TreeViewPlates.SelectedNode.Parent.Index
			End If
		End If
		Call searchAndFillLstPlates((txtPlateSearch.Text))
		If iSelectedNodeIndex <> 0 Then
			'UPGRADE_WARNING: Lower bound of collection TreeViewPlates.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
			'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewPlates.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			TreeViewPlates.Nodes.Item(iSelectedNodeIndex).Selected = True
		End If
	End Sub
	
	Private Sub btnRawDataBrowse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnRawDataBrowse.Click
		Dim sFileName As String
		
		' CancelError is True.
		On Error GoTo ErrHandler
		' Set filters.
		'UPGRADE_WARNING: Filter has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		CommonDialog1Open.Filter = "All Files (*.*)|*.*|"
		' Specify default filter.
		CommonDialog1Open.FilterIndex = 1
		
		'UPGRADE_WARNING: The CommonDialog CancelError property is not supported in Visual Basic .NET. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
		CommonDialog1.CancelError = True
		
		Dim sPath As String
		sPath = getPathVariable(chiRegRawDataFileOpenPath)
		
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
		txtDataFileName.Text = CommonDialog1Open.FileName
		
		Call SetPathVariable(chiRegRawDataFileOpenPath, getPath((CommonDialog1Open.FileName)))
		
		' automatically filling in the outfile from marker program
		' finding the filename for the raw datafile
		Dim sFolderName As String
		Dim sDataFileName As String
		Dim sGenotypeFileName As String
		
		If txtDataFileName.Text = "" Then
			Exit Sub
		End If
		
		sDataFileName = Mid(txtDataFileName.Text, InStrRev(txtDataFileName.Text, "\"), Len(txtDataFileName.Text))
		sFolderName = Mid(txtDataFileName.Text, 1, InStrRev(txtDataFileName.Text, "\"))
		
		txtGeotypeFileName.Text = sFolderName & "Output" & sDataFileName & ".out"
		
ErrHandler: 
		Exit Sub
	End Sub
	
	
	Private Sub btnSearchAssay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSearchAssay.Click
		Call searchAndFillLstAssays((txtAssaySearch.Text))
	End Sub
	
	Private Sub FPresultDB_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Call getPlatesWithData()
		Call searchAndFillLstAssays("")
		Call searchAndFillLstPlates("")
		
		oldFormHeight = VB6.PixelsToTwipsY(Me.Height)
	End Sub
	
	
	'UPGRADE_WARNING: Event FPresultDB.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub FPresultDB_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		
		Dim formDiff As Short
		If Not Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then
			
			lblPlateName.Left = VB6.TwipsToPixelsX(100)
			TreeViewPlates.Left = VB6.TwipsToPixelsX(100)
			txtPlateSearch.Left = VB6.TwipsToPixelsX(100)
			lblRawDataFile.Left = VB6.TwipsToPixelsX(100)
			txtDataFileName.Left = VB6.TwipsToPixelsX(100)
			lblGenotypeFile.Left = VB6.TwipsToPixelsX(100)
			txtGeotypeFileName.Left = VB6.TwipsToPixelsX(100)
			lblAssay.Left = VB6.TwipsToPixelsX(100)
			lstAssays.Left = VB6.TwipsToPixelsX(100)
			txtAssaySearch.Left = VB6.TwipsToPixelsX(100)
			
			lblPlateName.Top = VB6.TwipsToPixelsY(100)
			TreeViewPlates.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(lblPlateName.Top) + VB6.PixelsToTwipsY(lblPlateName.Height))
			
			formDiff = VB6.PixelsToTwipsY(Me.Height) - oldFormHeight
			
			If VB6.PixelsToTwipsY(Me.Height) >= 9400 Then
				btnOK.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - VB6.PixelsToTwipsY(btnOK.Height) - 100)
				btnCancel.Top = btnOK.Top
				btnSearchAssay.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(btnOK.Top) - VB6.PixelsToTwipsY(btnSearchAssay.Height) - 200)
				txtAssaySearch.Top = btnSearchAssay.Top
				
				lstAssays.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(lstAssays.Height) + (formDiff / 2))
				lstAssays.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(txtAssaySearch.Top) - VB6.PixelsToTwipsY(lstAssays.Height) - 100)
				
				'UPGRADE_WARNING: Lower bound of collection lstAssays.ColumnHeaders has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lstAssays.Columns.Item(1).Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(lstAssays.Width) - 350)
				
				lblAssay.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(lstAssays.Top) - VB6.PixelsToTwipsY(lblAssay.Height))
				
				txtGeotypeFileName.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(lstAssays.Top) - VB6.PixelsToTwipsY(txtGeotypeFileName.Height) - VB6.PixelsToTwipsY(lblAssay.Height) - 200)
				lblGenotypeFile.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(txtGeotypeFileName.Top) - VB6.PixelsToTwipsY(lblGenotypeFile.Height))
				
				btnGenotypeBrowse.Top = txtGeotypeFileName.Top
				
				txtDataFileName.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(lblGenotypeFile.Top) - VB6.PixelsToTwipsY(txtDataFileName.Height) - 200)
				lblRawDataFile.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(txtDataFileName.Top) - VB6.PixelsToTwipsY(lblRawDataFile.Height))
				
				btnRawDataBrowse.Top = txtDataFileName.Top
				
				
				TreeViewPlates.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(TreeViewPlates.Height) + (formDiff / 2))
				
				framePlateListOptions.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(TreeViewPlates.Top) + VB6.PixelsToTwipsY(TreeViewPlates.Height) + 100)
				
				
				txtPlateSearch.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(framePlateListOptions.Top) + 50)
				
				btnPlateSearch.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(txtPlateSearch.Top) + VB6.PixelsToTwipsY(txtPlateSearch.Height) + 100)
			Else
				Me.Height = VB6.TwipsToPixelsY(9400)
			End If
			If VB6.PixelsToTwipsX(Me.Width) >= 5300 Then
				btnOK.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnOK.Width) - 100)
				btnCancel.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(btnOK.Left) - VB6.PixelsToTwipsX(btnCancel.Width) - 100)
				
				btnSearchAssay.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnSearchAssay.Width) - 100)
				txtAssaySearch.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnSearchAssay.Width) - 300)
				lstAssays.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 200)
				'UPGRADE_WARNING: Lower bound of collection lstAssays.ColumnHeaders has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				lstAssays.Columns.Item(1).Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(lstAssays.Width) - 350)
				
				btnGenotypeBrowse.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnGenotypeBrowse.Width) - 100)
				txtGeotypeFileName.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnGenotypeBrowse.Width) - 300)
				
				btnRawDataBrowse.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnRawDataBrowse.Width) - 100)
				txtDataFileName.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(btnRawDataBrowse.Width) - 300)
				
				framePlateListOptions.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(framePlateListOptions.Width) - 100)
				txtPlateSearch.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(framePlateListOptions.Left) - VB6.PixelsToTwipsX(txtPlateSearch.Left) - 100)
				btnPlateSearch.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(txtPlateSearch.Left) + VB6.PixelsToTwipsX(txtPlateSearch.Width) - VB6.PixelsToTwipsX(btnPlateSearch.Width))
				TreeViewPlates.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 200)
				
			Else
				oldFormHeight = 9400
				Me.Width = VB6.TwipsToPixelsX(5300)
			End If
			
			oldFormHeight = VB6.PixelsToTwipsY(Me.Height)
			
		End If
	End Sub
	Private Sub getPlatesWithData()
		Dim Rs As New ADODB.Recordset
		
		oPlatesWithData = New Scripting.Dictionary
		
		Rs.Open("SELECT DISTINCT identifier FROM plate p, plate_map pm, data d " & "WHERE p.id = pm.plate_id AND d.plate_map_id = pm.id " & "AND p.deleted = 0", oFPConnection)
		
		While Not Rs.EOF
			oPlatesWithData.Add(CStr(Rs.Fields(0).Value), CStr(Rs.Fields(0).Value))
			Rs.MoveNext()
		End While
	End Sub
	
	Private Sub searchAndFillLstAssays(ByRef searchText As String)
		
		lstAssays.Items.Clear()
		
		' this will query the gtdb database and ask for aviable markers
		Dim Rs As New ADODB.Recordset
		
		Rs.Open("SELECT identifier FROM assay WHERE identifier LIKE '%" & searchText & "%' ORDER BY identifier", oGtdbConnection)
		
		Dim ListItemX As System.Windows.Forms.ListViewItem
		Do Until Rs.EOF
			'UPGRADE_ISSUE: MSComctlLib.ListItems method lstAssays.ListItems.Add was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			ListItemX = lstAssays.Items.Add()
			ListItemX.Text = Rs.Fields(0).Value
			Rs.MoveNext()
			'UPGRADE_NOTE: Object ListItemX may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			ListItemX = Nothing
		Loop 
	End Sub
	
	Private Sub searchAndFillLstPlates(ByRef searchText As String)
		
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
				If optShowOnlyEmpty.Checked = True Then
					If Not oPlatesWithData.Exists(CStr(Rs2.Fields(1).Value)) Then
						'UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
						TreeViewPlates.Nodes.Find("person_" & CStr(Rs.Fields(1).Value), True)(0).Nodes.Add("schema_" & CStr(Rs2.Fields(0).Value), CStr(Rs2.Fields(1).Value))
					End If
					Rs2.MoveNext()
				Else
					'UPGRADE_WARNING: Add method behavior has changed Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DBD08912-7C17-401D-9BE9-BA85E7772B99"'
					TreeViewPlates.Nodes.Find("person_" & CStr(Rs.Fields(1).Value), True)(0).Nodes.Add("schema_" & CStr(Rs2.Fields(0).Value), CStr(Rs2.Fields(1).Value))
					Rs2.MoveNext()
				End If
			End While
			Rs2.Close()
			Rs.MoveNext()
		End While
	End Sub
	
	'UPGRADE_WARNING: Event optShowAll.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optShowAll_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optShowAll.CheckedChanged
		If eventSender.Checked Then
			Dim iSelectedNodeIndex As Short
			If Not TreeViewPlates.SelectedNode Is Nothing Then
				If TreeViewPlates.SelectedNode.Parent Is Nothing Then
					iSelectedNodeIndex = TreeViewPlates.SelectedNode.Index
				Else
					iSelectedNodeIndex = TreeViewPlates.SelectedNode.Parent.Index
				End If
			End If
			Call searchAndFillLstPlates("")
			If iSelectedNodeIndex <> 0 Then
				'UPGRADE_WARNING: Lower bound of collection TreeViewPlates.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewPlates.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				TreeViewPlates.Nodes.Item(iSelectedNodeIndex).Selected = True
			End If
		End If
	End Sub
	
	'UPGRADE_WARNING: Event optShowOnlyEmpty.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optShowOnlyEmpty_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optShowOnlyEmpty.CheckedChanged
		If eventSender.Checked Then
			Dim iSelectedNodeIndex As Short
			If Not TreeViewPlates.SelectedNode Is Nothing Then
				If TreeViewPlates.SelectedNode.Parent Is Nothing Then
					iSelectedNodeIndex = TreeViewPlates.SelectedNode.Index
				Else
					iSelectedNodeIndex = TreeViewPlates.SelectedNode.Parent.Index
				End If
			End If
			Call searchAndFillLstPlates("")
			If iSelectedNodeIndex <> 0 Then
				'UPGRADE_WARNING: Lower bound of collection TreeViewPlates.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewPlates.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				TreeViewPlates.Nodes.Item(iSelectedNodeIndex).Selected = True
			End If
		End If
	End Sub
	
	Private Sub txtAssaySearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtAssaySearch.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			Call searchAndFillLstAssays((txtAssaySearch.Text))
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtPlateSearch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPlateSearch.KeyPress
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
			Call searchAndFillLstPlates((txtPlateSearch.Text))
			If iSelectedNodeIndex <> 0 Then
				'UPGRADE_WARNING: Lower bound of collection TreeViewPlates.Nodes has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				'UPGRADE_ISSUE: MSComctlLib.Node property TreeViewPlates.Nodes.Item.Selected was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				TreeViewPlates.Nodes.Item(iSelectedNodeIndex).Selected = True
			End If
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class