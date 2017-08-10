<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSelectPlateSchemeName
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
	Public WithEvents btnContinue As System.Windows.Forms.Button
	Public WithEvents lstPlateSchemeFormat As System.Windows.Forms.ComboBox
	Public WithEvents txtPlateSchemeName As System.Windows.Forms.TextBox
	Public WithEvents lblSelectPlateSchemeFormat As System.Windows.Forms.Label
	Public WithEvents lblPlateSchemeName As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSelectPlateSchemeName))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnContinue = New System.Windows.Forms.Button
		Me.lstPlateSchemeFormat = New System.Windows.Forms.ComboBox
		Me.txtPlateSchemeName = New System.Windows.Forms.TextBox
		Me.lblSelectPlateSchemeFormat = New System.Windows.Forms.Label
		Me.lblPlateSchemeName = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Select the plate scheme name"
		Me.ClientSize = New System.Drawing.Size(312, 206)
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
		Me.Name = "frmSelectPlateSchemeName"
		Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.Size = New System.Drawing.Size(73, 25)
		Me.btnCancel.Location = New System.Drawing.Point(144, 176)
		Me.btnCancel.TabIndex = 5
		Me.btnCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
		Me.btnCancel.CausesValidation = True
		Me.btnCancel.Enabled = True
		Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnCancel.TabStop = True
		Me.btnCancel.Name = "btnCancel"
		Me.btnContinue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnContinue.Text = "Continue"
		Me.btnContinue.Size = New System.Drawing.Size(81, 25)
		Me.btnContinue.Location = New System.Drawing.Point(224, 176)
		Me.btnContinue.TabIndex = 4
		Me.btnContinue.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnContinue.BackColor = System.Drawing.SystemColors.Control
		Me.btnContinue.CausesValidation = True
		Me.btnContinue.Enabled = True
		Me.btnContinue.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnContinue.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnContinue.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnContinue.TabStop = True
		Me.btnContinue.Name = "btnContinue"
		Me.lstPlateSchemeFormat.Size = New System.Drawing.Size(161, 21)
		Me.lstPlateSchemeFormat.Location = New System.Drawing.Point(8, 104)
		Me.lstPlateSchemeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.lstPlateSchemeFormat.TabIndex = 3
		Me.lstPlateSchemeFormat.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstPlateSchemeFormat.BackColor = System.Drawing.SystemColors.Window
		Me.lstPlateSchemeFormat.CausesValidation = True
		Me.lstPlateSchemeFormat.Enabled = True
		Me.lstPlateSchemeFormat.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstPlateSchemeFormat.IntegralHeight = True
		Me.lstPlateSchemeFormat.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstPlateSchemeFormat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstPlateSchemeFormat.Sorted = False
		Me.lstPlateSchemeFormat.TabStop = True
		Me.lstPlateSchemeFormat.Visible = True
		Me.lstPlateSchemeFormat.Name = "lstPlateSchemeFormat"
		Me.txtPlateSchemeName.AutoSize = False
		Me.txtPlateSchemeName.Size = New System.Drawing.Size(289, 27)
		Me.txtPlateSchemeName.Location = New System.Drawing.Point(8, 32)
		Me.txtPlateSchemeName.TabIndex = 1
		Me.txtPlateSchemeName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtPlateSchemeName.AcceptsReturn = True
		Me.txtPlateSchemeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPlateSchemeName.BackColor = System.Drawing.SystemColors.Window
		Me.txtPlateSchemeName.CausesValidation = True
		Me.txtPlateSchemeName.Enabled = True
		Me.txtPlateSchemeName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPlateSchemeName.HideSelection = True
		Me.txtPlateSchemeName.ReadOnly = False
		Me.txtPlateSchemeName.Maxlength = 0
		Me.txtPlateSchemeName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPlateSchemeName.MultiLine = False
		Me.txtPlateSchemeName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPlateSchemeName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPlateSchemeName.TabStop = True
		Me.txtPlateSchemeName.Visible = True
		Me.txtPlateSchemeName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPlateSchemeName.Name = "txtPlateSchemeName"
		Me.lblSelectPlateSchemeFormat.Text = "Select the plate scheme format"
		Me.lblSelectPlateSchemeFormat.Size = New System.Drawing.Size(177, 17)
		Me.lblSelectPlateSchemeFormat.Location = New System.Drawing.Point(8, 80)
		Me.lblSelectPlateSchemeFormat.TabIndex = 2
		Me.lblSelectPlateSchemeFormat.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSelectPlateSchemeFormat.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblSelectPlateSchemeFormat.BackColor = System.Drawing.SystemColors.Control
		Me.lblSelectPlateSchemeFormat.Enabled = True
		Me.lblSelectPlateSchemeFormat.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblSelectPlateSchemeFormat.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblSelectPlateSchemeFormat.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblSelectPlateSchemeFormat.UseMnemonic = True
		Me.lblSelectPlateSchemeFormat.Visible = True
		Me.lblSelectPlateSchemeFormat.AutoSize = False
		Me.lblSelectPlateSchemeFormat.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblSelectPlateSchemeFormat.Name = "lblSelectPlateSchemeFormat"
		Me.lblPlateSchemeName.Text = "Define the platescheme name"
		Me.lblPlateSchemeName.Size = New System.Drawing.Size(145, 17)
		Me.lblPlateSchemeName.Location = New System.Drawing.Point(8, 8)
		Me.lblPlateSchemeName.TabIndex = 0
		Me.lblPlateSchemeName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPlateSchemeName.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPlateSchemeName.BackColor = System.Drawing.SystemColors.Control
		Me.lblPlateSchemeName.Enabled = True
		Me.lblPlateSchemeName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPlateSchemeName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlateSchemeName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlateSchemeName.UseMnemonic = True
		Me.lblPlateSchemeName.Visible = True
		Me.lblPlateSchemeName.AutoSize = False
		Me.lblPlateSchemeName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPlateSchemeName.Name = "lblPlateSchemeName"
		Me.Controls.Add(btnCancel)
		Me.Controls.Add(btnContinue)
		Me.Controls.Add(lstPlateSchemeFormat)
		Me.Controls.Add(txtPlateSchemeName)
		Me.Controls.Add(lblSelectPlateSchemeFormat)
		Me.Controls.Add(lblPlateSchemeName)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class