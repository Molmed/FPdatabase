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
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lstPlateFormats = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtLoadOrderName = New System.Windows.Forms.TextBox()
        Me.lblPlateFormat = New System.Windows.Forms.Label()
        Me.lblLoadOrderName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstPlateFormats
        '
        Me.lstPlateFormats.BackColor = System.Drawing.SystemColors.Window
        Me.lstPlateFormats.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstPlateFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstPlateFormats.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPlateFormats.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstPlateFormats.Location = New System.Drawing.Point(8, 88)
        Me.lstPlateFormats.Name = "lstPlateFormats"
        Me.lstPlateFormats.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstPlateFormats.Size = New System.Drawing.Size(113, 22)
        Me.lstPlateFormats.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(144, 136)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(73, 25)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(224, 136)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(81, 25)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'txtLoadOrderName
        '
        Me.txtLoadOrderName.AcceptsReturn = True
        Me.txtLoadOrderName.BackColor = System.Drawing.SystemColors.Window
        Me.txtLoadOrderName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLoadOrderName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadOrderName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLoadOrderName.Location = New System.Drawing.Point(8, 32)
        Me.txtLoadOrderName.MaxLength = 0
        Me.txtLoadOrderName.Name = "txtLoadOrderName"
        Me.txtLoadOrderName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLoadOrderName.Size = New System.Drawing.Size(297, 27)
        Me.txtLoadOrderName.TabIndex = 1
        '
        'lblPlateFormat
        '
        Me.lblPlateFormat.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlateFormat.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlateFormat.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlateFormat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlateFormat.Location = New System.Drawing.Point(8, 64)
        Me.lblPlateFormat.Name = "lblPlateFormat"
        Me.lblPlateFormat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlateFormat.Size = New System.Drawing.Size(169, 17)
        Me.lblPlateFormat.TabIndex = 4
        Me.lblPlateFormat.Text = "Plate Format"
        '
        'lblLoadOrderName
        '
        Me.lblLoadOrderName.BackColor = System.Drawing.SystemColors.Control
        Me.lblLoadOrderName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLoadOrderName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadOrderName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoadOrderName.Location = New System.Drawing.Point(8, 8)
        Me.lblLoadOrderName.Name = "lblLoadOrderName"
        Me.lblLoadOrderName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLoadOrderName.Size = New System.Drawing.Size(161, 17)
        Me.lblLoadOrderName.TabIndex = 0
        Me.lblLoadOrderName.Text = "Load order name:"
        '
        'frmLoadOrderName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(312, 169)
        Me.Controls.Add(Me.lstPlateFormats)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtLoadOrderName)
        Me.Controls.Add(Me.lblPlateFormat)
        Me.Controls.Add(Me.lblLoadOrderName)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "frmLoadOrderName"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Load order name"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class