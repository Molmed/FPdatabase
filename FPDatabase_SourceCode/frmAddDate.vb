Option Strict Off
Option Explicit On
Friend Class frmAddDate
	Inherits System.Windows.Forms.Form
	Private sDate As String
	Private bOK As Boolean
	Private outDate As String
	
	Public Sub Initialize(ByRef inDate As String)
        sDate = inDate
        DateTimePicker1.Value = DateTime.Now
	End Sub
	
	
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		Me.Hide()
	End Sub
	
	Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
		'checking if the date can be read
		
        bOK = True
        Me.Hide()

	End Sub
	
    Public Function getDate() As DateTime
        getDate = DateTimePicker1.Value
    End Function
	
	Public Function getOk() As Boolean
		getOk = bOK
	End Function
End Class