<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmAddDate
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOK As System.Windows.Forms.Button
	Public WithEvents lstYear As System.Windows.Forms.ComboBox
	Public WithEvents lstMonth As System.Windows.Forms.ComboBox
	Public WithEvents lstDay As System.Windows.Forms.ComboBox
	Public WithEvents lblYear As System.Windows.Forms.Label
	Public WithEvents lblMonth As System.Windows.Forms.Label
	Public WithEvents lblDay As System.Windows.Forms.Label
	Public WithEvents lblDate As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAddDate))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnOK = New System.Windows.Forms.Button
		Me.lstYear = New System.Windows.Forms.ComboBox
		Me.lstMonth = New System.Windows.Forms.ComboBox
		Me.lstDay = New System.Windows.Forms.ComboBox
		Me.lblYear = New System.Windows.Forms.Label
		Me.lblMonth = New System.Windows.Forms.Label
		Me.lblDay = New System.Windows.Forms.Label
		Me.lblDate = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Specify date"
		Me.ClientSize = New System.Drawing.Size(262, 213)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmAddDate"
		Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.Size = New System.Drawing.Size(65, 25)
		Me.btnCancel.Location = New System.Drawing.Point(104, 168)
		Me.btnCancel.TabIndex = 9
		Me.btnCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
		Me.btnCancel.CausesValidation = True
		Me.btnCancel.Enabled = True
		Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnCancel.TabStop = True
		Me.btnCancel.Name = "btnCancel"
		Me.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnOK.Text = "OK"
		Me.btnOK.Size = New System.Drawing.Size(73, 25)
		Me.btnOK.Location = New System.Drawing.Point(176, 168)
		Me.btnOK.TabIndex = 8
		Me.btnOK.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnOK.BackColor = System.Drawing.SystemColors.Control
		Me.btnOK.CausesValidation = True
		Me.btnOK.Enabled = True
		Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnOK.TabStop = True
		Me.btnOK.Name = "btnOK"
		Me.lstYear.Size = New System.Drawing.Size(65, 21)
		Me.lstYear.Location = New System.Drawing.Point(72, 112)
		Me.lstYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.lstYear.TabIndex = 7
		Me.lstYear.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstYear.BackColor = System.Drawing.SystemColors.Window
		Me.lstYear.CausesValidation = True
		Me.lstYear.Enabled = True
		Me.lstYear.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstYear.IntegralHeight = True
		Me.lstYear.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstYear.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstYear.Sorted = False
		Me.lstYear.TabStop = True
		Me.lstYear.Visible = True
		Me.lstYear.Name = "lstYear"
		Me.lstMonth.Size = New System.Drawing.Size(89, 21)
		Me.lstMonth.Location = New System.Drawing.Point(72, 88)
		Me.lstMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.lstMonth.TabIndex = 5
		Me.lstMonth.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstMonth.BackColor = System.Drawing.SystemColors.Window
		Me.lstMonth.CausesValidation = True
		Me.lstMonth.Enabled = True
		Me.lstMonth.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstMonth.IntegralHeight = True
		Me.lstMonth.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstMonth.Sorted = False
		Me.lstMonth.TabStop = True
		Me.lstMonth.Visible = True
		Me.lstMonth.Name = "lstMonth"
		Me.lstDay.Size = New System.Drawing.Size(33, 21)
		Me.lstDay.Location = New System.Drawing.Point(72, 64)
		Me.lstDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.lstDay.TabIndex = 2
		Me.lstDay.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstDay.BackColor = System.Drawing.SystemColors.Window
		Me.lstDay.CausesValidation = True
		Me.lstDay.Enabled = True
		Me.lstDay.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstDay.IntegralHeight = True
		Me.lstDay.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstDay.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstDay.Sorted = False
		Me.lstDay.TabStop = True
		Me.lstDay.Visible = True
		Me.lstDay.Name = "lstDay"
		Me.lblYear.Text = "Year"
		Me.lblYear.Size = New System.Drawing.Size(41, 17)
		Me.lblYear.Location = New System.Drawing.Point(16, 112)
		Me.lblYear.TabIndex = 6
		Me.lblYear.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblYear.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblYear.BackColor = System.Drawing.SystemColors.Control
		Me.lblYear.Enabled = True
		Me.lblYear.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblYear.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblYear.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblYear.UseMnemonic = True
		Me.lblYear.Visible = True
		Me.lblYear.AutoSize = False
		Me.lblYear.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblYear.Name = "lblYear"
		Me.lblMonth.Text = "Month"
		Me.lblMonth.Size = New System.Drawing.Size(49, 17)
		Me.lblMonth.Location = New System.Drawing.Point(16, 88)
		Me.lblMonth.TabIndex = 4
		Me.lblMonth.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMonth.BackColor = System.Drawing.SystemColors.Control
		Me.lblMonth.Enabled = True
		Me.lblMonth.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMonth.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMonth.UseMnemonic = True
		Me.lblMonth.Visible = True
		Me.lblMonth.AutoSize = False
		Me.lblMonth.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMonth.Name = "lblMonth"
		Me.lblDay.Text = "Day"
		Me.lblDay.Size = New System.Drawing.Size(41, 17)
		Me.lblDay.Location = New System.Drawing.Point(16, 64)
		Me.lblDay.TabIndex = 3
		Me.lblDay.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDay.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDay.BackColor = System.Drawing.SystemColors.Control
		Me.lblDay.Enabled = True
		Me.lblDay.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDay.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDay.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDay.UseMnemonic = True
		Me.lblDay.Visible = True
		Me.lblDay.AutoSize = False
		Me.lblDay.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDay.Name = "lblDay"
		Me.lblDate.Text = "foo"
		Me.lblDate.Size = New System.Drawing.Size(185, 17)
		Me.lblDate.Location = New System.Drawing.Point(16, 32)
		Me.lblDate.TabIndex = 1
		Me.lblDate.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDate.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDate.BackColor = System.Drawing.SystemColors.Control
		Me.lblDate.Enabled = True
		Me.lblDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDate.UseMnemonic = True
		Me.lblDate.Visible = True
		Me.lblDate.AutoSize = False
		Me.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDate.Name = "lblDate"
		Me.Label1.Text = "Explain the date below...."
		Me.Label1.Size = New System.Drawing.Size(273, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 8)
		Me.Label1.TabIndex = 0
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(btnCancel)
		Me.Controls.Add(btnOK)
		Me.Controls.Add(lstYear)
		Me.Controls.Add(lstMonth)
		Me.Controls.Add(lstDay)
		Me.Controls.Add(lblYear)
		Me.Controls.Add(lblMonth)
		Me.Controls.Add(lblDay)
		Me.Controls.Add(lblDate)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class