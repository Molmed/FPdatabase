Option Strict Off
Option Explicit On
Friend Class frmAddDate
	Inherits System.Windows.Forms.Form
	Private sDate As String
	Private bOK As Boolean
	Private outDate As String
	
	Public Sub Initialize(ByRef inDate As String)
		sDate = inDate
	End Sub
	
	
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		Me.Hide()
	End Sub
	
	Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
		'checking if the date can be read
		
		Dim oDate As Date
		
		
		outDate = VB6.GetItemString(lstDay, lstDay.SelectedIndex) & " " & VB6.GetItemString(lstMonth, lstMonth.SelectedIndex) & " " & VB6.GetItemString(lstYear, lstYear.SelectedIndex)
		If Not IsDate(outDate) = True Then
			' checking if the day has been entered correctly
			' if not
			MsgBox("Date could not read")
			Exit Sub
		Else
			bOK = True
			Me.Hide()
		End If
		
	End Sub
	
	Private Sub frmAddDate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'filling the dropdown lists
		Dim i As Short
		
		For i = 1 To 31
			lstDay.Items.Add(CStr(i))
		Next i
		
		lstMonth.Items.Add("Jan")
		lstMonth.Items.Add("Feb")
		lstMonth.Items.Add("Mar")
		lstMonth.Items.Add("Apr")
		lstMonth.Items.Add("May")
		lstMonth.Items.Add("Jun")
		lstMonth.Items.Add("Jul")
		lstMonth.Items.Add("Aug")
		lstMonth.Items.Add("Sep")
		lstMonth.Items.Add("Oct")
		lstMonth.Items.Add("Nov")
		lstMonth.Items.Add("Dec")
		
		For i = 1999 To 2010
			lstYear.Items.Add(CStr(i))
		Next i
		
		'setting the label that shows the date string
		lblDate.Text = sDate
		
	End Sub
	
	Public Function getDate() As String
		getDate = outDate
	End Function
	
	Public Function getOk() As Boolean
		getOk = bOK
	End Function
End Class