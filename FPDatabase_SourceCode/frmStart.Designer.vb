<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStart
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
	Public WithEvents btnDeletion As System.Windows.Forms.Button
	Public WithEvents btnViewPlate As System.Windows.Forms.Button
    Public WithEvents btnCreatePlateScheme As System.Windows.Forms.Button
	Public WithEvents CreatePlateButton As System.Windows.Forms.Button
	Public WithEvents QuitButton As System.Windows.Forms.Button
	Public WithEvents UploadButton As System.Windows.Forms.Button
	Public WithEvents ViewButton As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnDeletion = New System.Windows.Forms.Button()
        Me.btnViewPlate = New System.Windows.Forms.Button()
        Me.btnCreatePlateScheme = New System.Windows.Forms.Button()
        Me.CreatePlateButton = New System.Windows.Forms.Button()
        Me.QuitButton = New System.Windows.Forms.Button()
        Me.UploadButton = New System.Windows.Forms.Button()
        Me.ViewButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnDeletion
        '
        Me.btnDeletion.BackColor = System.Drawing.SystemColors.Control
        Me.btnDeletion.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnDeletion.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeletion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDeletion.Location = New System.Drawing.Point(16, 239)
        Me.btnDeletion.Name = "btnDeletion"
        Me.btnDeletion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDeletion.Size = New System.Drawing.Size(121, 33)
        Me.btnDeletion.TabIndex = 7
        Me.btnDeletion.Text = "Delete"
        Me.btnDeletion.UseVisualStyleBackColor = False
        '
        'btnViewPlate
        '
        Me.btnViewPlate.BackColor = System.Drawing.SystemColors.Control
        Me.btnViewPlate.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnViewPlate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewPlate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnViewPlate.Location = New System.Drawing.Point(16, 199)
        Me.btnViewPlate.Name = "btnViewPlate"
        Me.btnViewPlate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnViewPlate.Size = New System.Drawing.Size(121, 33)
        Me.btnViewPlate.TabIndex = 6
        Me.btnViewPlate.Text = "View Plate"
        Me.btnViewPlate.UseVisualStyleBackColor = False
        '
        'btnCreatePlateScheme
        '
        Me.btnCreatePlateScheme.BackColor = System.Drawing.SystemColors.Control
        Me.btnCreatePlateScheme.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCreatePlateScheme.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreatePlateScheme.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCreatePlateScheme.Location = New System.Drawing.Point(16, 160)
        Me.btnCreatePlateScheme.Name = "btnCreatePlateScheme"
        Me.btnCreatePlateScheme.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCreatePlateScheme.Size = New System.Drawing.Size(121, 33)
        Me.btnCreatePlateScheme.TabIndex = 4
        Me.btnCreatePlateScheme.Text = "Create Plate Scheme"
        Me.btnCreatePlateScheme.UseVisualStyleBackColor = False
        '
        'CreatePlateButton
        '
        Me.CreatePlateButton.BackColor = System.Drawing.SystemColors.Control
        Me.CreatePlateButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.CreatePlateButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreatePlateButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CreatePlateButton.Location = New System.Drawing.Point(16, 120)
        Me.CreatePlateButton.Name = "CreatePlateButton"
        Me.CreatePlateButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CreatePlateButton.Size = New System.Drawing.Size(121, 33)
        Me.CreatePlateButton.TabIndex = 3
        Me.CreatePlateButton.Text = "Create Plate"
        Me.CreatePlateButton.UseVisualStyleBackColor = False
        '
        'QuitButton
        '
        Me.QuitButton.BackColor = System.Drawing.SystemColors.Control
        Me.QuitButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.QuitButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuitButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.QuitButton.Location = New System.Drawing.Point(16, 303)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.QuitButton.Size = New System.Drawing.Size(121, 33)
        Me.QuitButton.TabIndex = 2
        Me.QuitButton.Text = "Quit"
        Me.QuitButton.UseVisualStyleBackColor = False
        '
        'UploadButton
        '
        Me.UploadButton.BackColor = System.Drawing.SystemColors.Control
        Me.UploadButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.UploadButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UploadButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UploadButton.Location = New System.Drawing.Point(16, 56)
        Me.UploadButton.Name = "UploadButton"
        Me.UploadButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UploadButton.Size = New System.Drawing.Size(121, 33)
        Me.UploadButton.TabIndex = 1
        Me.UploadButton.Text = "Upload Data"
        Me.UploadButton.UseVisualStyleBackColor = False
        '
        'ViewButton
        '
        Me.ViewButton.BackColor = System.Drawing.SystemColors.Control
        Me.ViewButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.ViewButton.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ViewButton.Location = New System.Drawing.Point(16, 16)
        Me.ViewButton.Name = "ViewButton"
        Me.ViewButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ViewButton.Size = New System.Drawing.Size(121, 33)
        Me.ViewButton.TabIndex = 0
        Me.ViewButton.Text = "View Data"
        Me.ViewButton.UseVisualStyleBackColor = False
        '
        'frmStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(157, 359)
        Me.Controls.Add(Me.btnDeletion)
        Me.Controls.Add(Me.btnViewPlate)
        Me.Controls.Add(Me.btnCreatePlateScheme)
        Me.Controls.Add(Me.CreatePlateButton)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.UploadButton)
        Me.Controls.Add(Me.ViewButton)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmStart"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "FP data handler"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class