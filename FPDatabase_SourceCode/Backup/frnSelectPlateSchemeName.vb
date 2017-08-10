Option Strict Off
Option Explicit On
Friend Class frmSelectPlateSchemeName
	Inherits System.Windows.Forms.Form
	Private oFPConnection As ADODB.Connection
	Private oGtdbConnection As ADODB.Connection
	
	Public Sub Initialize(ByRef oInFPConnection As ADODB.Connection, ByRef oInGtdbConnection As ADODB.Connection)
		oFPConnection = oInFPConnection
		oGtdbConnection = oInGtdbConnection
	End Sub
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		Me.Close()
	End Sub
	
	Private Sub btnContinue_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnContinue.Click
		'checking if a plate scheme name and a format has been chosen.
		
		If txtPlateSchemeName.Text = "" Then
			MsgBox("You need to specify a platescheme name")
			Exit Sub
		End If
		
		If lstPlateSchemeFormat.SelectedIndex < 0 Then
			MsgBox("You need to select a platescheme format")
			Exit Sub
		End If
		
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
		Call frmPlateScheme.Initialize(oGtdbConnection, oFPConnection, VB6.GetItemString(lstPlateSchemeFormat, lstPlateSchemeFormat.SelectedIndex), txtPlateSchemeName.Text)
		frmPlateScheme.Show()
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.Close()
	End Sub
	
	Private Sub frmSelectPlateSchemeName_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Call fillLstPlateSchemeFormat()
	End Sub
	
	Private Sub fillLstPlateSchemeFormat()
		lstPlateSchemeFormat.Items.Add("96")
		lstPlateSchemeFormat.Items.Add("384")
	End Sub
End Class