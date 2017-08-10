Option Strict Off
Option Explicit On
Friend Class frmReadSampleName
	Inherits System.Windows.Forms.Form
	
	Private Sub ListView1_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		txtSampleName.Visible = False
		
		Dim ColSampleName As System.Windows.Forms.ColumnHeader
		
		If ListView1.GetItemAt(x, y) Is Nothing Then Exit Sub
		ColSampleName = ListView1.Columns.Item("SampleName")
		
		'UPGRADE_ISSUE: MSComctlLib.ColumnHeader property ColSampleName.Left was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		If x >= ColSampleName.Left And x <= ColSampleName.Left + VB6.PixelsToTwipsX(ColSampleName.Width) Then
			
			'UPGRADE_ISSUE: MSComctlLib.ListItem property ListView1.SelectedItem.Top was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			txtSampleName.Top = VB6.TwipsToPixelsY(ListView1.FocusedItem.Top + VB6.PixelsToTwipsY(ListView1.Top))
			'UPGRADE_ISSUE: MSComctlLib.ColumnHeader property ColSampleName.Left was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			txtSampleName.Left = VB6.TwipsToPixelsX(ColSampleName.Left + VB6.PixelsToTwipsX(ListView1.Left))
			txtSampleName.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(ColSampleName.Width))
			
			txtSampleName.Text = ListView1.FocusedItem.Tag
			
			txtSampleName.Visible = True
		End If
		
		
		
	End Sub
	
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		Me.Hide()
		
	End Sub
	
	'UPGRADE_WARNING: Event txtSampleName.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtSampleName_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSampleName.TextChanged
		'UPGRADE_WARNING: Lower bound of collection ListView1.SelectedItem has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		If ListView1.FocusedItem.SubItems.Count > 1 Then
			ListView1.FocusedItem.SubItems(1).Text = txtSampleName.Text
		Else
			ListView1.FocusedItem.SubItems.Insert(1, New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, txtSampleName.Text))
		End If
		ListView1.FocusedItem.Tag = txtSampleName.Text
		
	End Sub
End Class