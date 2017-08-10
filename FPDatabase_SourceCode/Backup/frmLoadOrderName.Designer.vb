<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmLoadOrderName
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
	Public WithEvents lstPlateFormats As System.Windows.Forms.ComboBox
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOK As System.Windows.Forms.Button
	Public WithEvents txtLoadOrderName As System.Windows.Forms.TextBox
	Public WithEvents lblPlateFormat As System.Windows.Forms.Label
	Public WithEvents lblLoadOrderName As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLoadOrderName))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.lstPlateFormats = New System.Windows.Forms.ComboBox
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnOK = New System.Windows.Forms.Button
		Me.txtLoadOrderName = New System.Windows.Forms.TextBox
		Me.lblPlateFormat = New System.Windows.Forms.Label
		Me.lblLoadOrderName = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Load order name"
		Me.ClientSize = New System.Drawing.Size(312, 169)
		Me.Location = New System.Drawing.Point(4, 30)
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
		Me.Name = "frmLoadOrderName"
		Me.lstPlateFormats.Size = New System.Drawing.Size(113, 21)
		Me.lstPlateFormats.Location = New System.Drawing.Point(8, 88)
		Me.lstPlateFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.lstPlateFormats.TabIndex = 5
		Me.lstPlateFormats.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstPlateFormats.BackColor = System.Drawing.SystemColors.Window
		Me.lstPlateFormats.CausesValidation = True
		Me.lstPlateFormats.Enabled = True
		Me.lstPlateFormats.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstPlateFormats.IntegralHeight = True
		Me.lstPlateFormats.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstPlateFormats.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstPlateFormats.Sorted = False
		Me.lstPlateFormats.TabStop = True
		Me.lstPlateFormats.Visible = True
		Me.lstPlateFormats.Name = "lstPlateFormats"
		Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.Size = New System.Drawing.Size(73, 25)
		Me.btnCancel.Location = New System.Drawing.Point(144, 136)
		Me.btnCancel.TabIndex = 3
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
		Me.btnOK.Size = New System.Drawing.Size(81, 25)
		Me.btnOK.Location = New System.Drawing.Point(224, 136)
		Me.btnOK.TabIndex = 2
		Me.btnOK.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnOK.BackColor = System.Drawing.SystemColors.Control
		Me.btnOK.CausesValidation = True
		Me.btnOK.Enabled = True
		Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnOK.TabStop = True
		Me.btnOK.Name = "btnOK"
		Me.txtLoadOrderName.AutoSize = False
		Me.txtLoadOrderName.Size = New System.Drawing.Size(297, 27)
		Me.txtLoadOrderName.Location = New System.Drawing.Point(8, 32)
		Me.txtLoadOrderName.TabIndex = 1
		Me.txtLoadOrderName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtLoadOrderName.AcceptsReturn = True
		Me.txtLoadOrderName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtLoadOrderName.BackColor = System.Drawing.SystemColors.Window
		Me.txtLoadOrderName.CausesValidation = True
		Me.txtLoadOrderName.Enabled = True
		Me.txtLoadOrderName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtLoadOrderName.HideSelection = True
		Me.txtLoadOrderName.ReadOnly = False
		Me.txtLoadOrderName.Maxlength = 0
		Me.txtLoadOrderName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtLoadOrderName.MultiLine = False
		Me.txtLoadOrderName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtLoadOrderName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtLoadOrderName.TabStop = True
		Me.txtLoadOrderName.Visible = True
		Me.txtLoadOrderName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtLoadOrderName.Name = "txtLoadOrderName"
		Me.lblPlateFormat.Text = "Plate Format"
		Me.lblPlateFormat.Size = New System.Drawing.Size(169, 17)
		Me.lblPlateFormat.Location = New System.Drawing.Point(8, 64)
		Me.lblPlateFormat.TabIndex = 4
		Me.lblPlateFormat.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPlateFormat.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPlateFormat.BackColor = System.Drawing.SystemColors.Control
		Me.lblPlateFormat.Enabled = True
		Me.lblPlateFormat.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPlateFormat.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlateFormat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlateFormat.UseMnemonic = True
		Me.lblPlateFormat.Visible = True
		Me.lblPlateFormat.AutoSize = False
		Me.lblPlateFormat.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPlateFormat.Name = "lblPlateFormat"
		Me.lblLoadOrderName.Text = "Load order name:"
		Me.lblLoadOrderName.Size = New System.Drawing.Size(161, 17)
		Me.lblLoadOrderName.Location = New System.Drawing.Point(8, 8)
		Me.lblLoadOrderName.TabIndex = 0
		Me.lblLoadOrderName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLoadOrderName.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblLoadOrderName.BackColor = System.Drawing.SystemColors.Control
		Me.lblLoadOrderName.Enabled = True
		Me.lblLoadOrderName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblLoadOrderName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblLoadOrderName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblLoadOrderName.UseMnemonic = True
		Me.lblLoadOrderName.Visible = True
		Me.lblLoadOrderName.AutoSize = False
		Me.lblLoadOrderName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblLoadOrderName.Name = "lblLoadOrderName"
		Me.Controls.Add(lstPlateFormats)
		Me.Controls.Add(btnCancel)
		Me.Controls.Add(btnOK)
		Me.Controls.Add(txtLoadOrderName)
		Me.Controls.Add(lblPlateFormat)
		Me.Controls.Add(lblLoadOrderName)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class