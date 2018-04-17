Option Strict Off
Option Explicit On

Imports FPDatabase.My.Resources

Enum Environment
    Operational
    Validation
    Development
End Enum
Friend Class frmStart
    Inherits System.Windows.Forms.Form
    Private oFPConnection As ADODB.Connection
    Private oGtdbConnection As ADODB.Connection
    Private bPracticeMode As Boolean

    Public Sub Initialize(ByRef oInFPConnection As ADODB.Connection, ByRef oInGtdbConnection As ADODB.Connection, ByVal bInPracticeMode As Object)
        oFPConnection = oInFPConnection
        oGtdbConnection = oInGtdbConnection
        'UPGRADE_WARNING: Couldn't resolve default property of object bInPracticeMode. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        bPracticeMode = bInPracticeMode
        Dim env = ExtractEnvironment(oFPConnection.ConnectionString)
        ShowEnvironment(env)
    End Sub

    Private Function ExtractEnvironment(connectionString As String) As Environment
        Dim parts = connectionString.Split(";")
        Dim initialCatalogPart As String
        For Each part As String In parts
            If part.Contains("Initial Catalog") Then
                initialCatalogPart = part
            End If
        Next
        If initialCatalogPart.Contains("devel") Then
            Return Environment.Development
        ElseIf initialCatalogPart.Contains("practice") Then
            Return Environment.Validation
        ElseIf initialCatalogPart.EndsWith("FP") Then
            Return Environment.Operational
        Else
            Throw New Exception("The connection string could not be parsed for determining type of environment. Quitting")
        End If
    End Function

    Private Sub ShowEnvironment(env As Environment)
        Select Case env
            Case Environment.Development
                ShowDevelBackground()
            Case Environment.Validation
                ShowValidationBackground()
            Case Environment.Operational
                ShrinkBackground()
        End Select
    End Sub

    Private Sub ShrinkBackground()
        Height = Height - EnvironemtIndicatorPanel.Height
    End Sub

    Private Sub ShowDevelBackground()
        EnvironemtIndicatorPanel.BackgroundImage = Backgrounds.DevelBackground
        BackgroundImage = Backgrounds.DevelBackground
    End Sub

    Private Sub ShowValidationBackground()
        EnvironemtIndicatorPanel.BackgroundImage = Backgrounds.ValidationBackground
        BackgroundImage = Backgrounds.ValidationBackground
    End Sub

    Private Sub btnCreatePlateScheme_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCreatePlateScheme.Click
		Call frmSelectPlateSchemeName.Initialize(oFPConnection, oGtdbConnection)
		frmSelectPlateSchemeName.Show()
	End Sub
	
	Private Sub btnDeletion_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnDeletion.Click
		Call frmDeletion.Initialize(oFPConnection)
		frmDeletion.Show()
	End Sub
	
    Private Sub btnPlateSchemeLoadOrder_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Call frmLoadOrderName.Initialize(oFPConnection)
        frmLoadOrderName.Show()
    End Sub
	
	Private Sub btnViewPlate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnViewPlate.Click
		Call frmViewPlate.Initialize(oFPConnection, "Plate")
		frmViewPlate.Show()
	End Sub
	
	Private Sub CreatePlateButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CreatePlateButton.Click
		Call frmPlateAdd.Initialize(oFPConnection)
		frmPlateAdd.Show()
	End Sub
	
	
	Private Sub frmStart_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		If bPracticeMode Then
			Call DisplayPracticeFlag()
		End If
	End Sub
	
	Private Sub frmStart_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		Call UnloadAllForms()
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub QuitButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles QuitButton.Click
		oFPConnection.Close()
		oGtdbConnection.Close()
		'UPGRADE_NOTE: Object oFPConnection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oFPConnection = Nothing
		'UPGRADE_NOTE: Object oGtdbConnection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oGtdbConnection = Nothing
		Me.Close()
	End Sub
	
	Private Sub UploadButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles UploadButton.Click
		Call FPresultDB.Initialize(oFPConnection, oGtdbConnection)
		FPresultDB.Show()
	End Sub
	
	Private Sub ViewButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ViewButton.Click
		
		Dim SelectMasterPlate As New frmSelectMasterPlate
		Call SelectMasterPlate.Init(oFPConnection)
		Call VB6.ShowForm(SelectMasterPlate, VB6.FormShowConstants.Modal, Me)
		
		Dim sMasterPlateName As String
		sMasterPlateName = SelectMasterPlate.getPlateName
		
		If sMasterPlateName = "" Then
			Exit Sub
		End If
		Call viewFPData(oFPConnection, sMasterPlateName)
		
	End Sub
	
	Private Sub DisplayPracticeFlag()
		Me.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(200, 0, 0))
		Me.Text = "PRACTICE"
	End Sub
End Class