Option Strict Off
Option Explicit On
Friend Class frmLoadOrderName
	Inherits System.Windows.Forms.Form
	Private oFPConnection As ADODB.Connection
	
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		Me.Close()
	End Sub
	
	Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
		If txtLoadOrderName.Text = "" Then
			MsgBox("You need to specify a load order name")
		End If
		
		If lstPlateFormats.SelectedIndex < 0 Then
			MsgBox("You need to specify a plate format")
		End If
		
		Call frmPlateSchemeLoadOrder.Initialize(oFPConnection, VB6.GetItemString(lstPlateFormats, lstPlateFormats.SelectedIndex), txtLoadOrderName.Text)
		frmPlateSchemeLoadOrder.Show()
		
		Me.Close()
		
	End Sub
	
	Public Sub Initialize(ByRef oInFPConnection As ADODB.Connection)
		oFPConnection = oInFPConnection
	End Sub
	
	Private Sub frmLoadOrderName_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'adding the different plate formats to the lstFormats
		
		lstPlateFormats.Items.Add("96")
		lstPlateFormats.Items.Add("384")
		
	End Sub

    Private Sub btnOK_Click_1(sender As Object, e As EventArgs) Handles btnOK.Click

    End Sub
End Class