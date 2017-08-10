<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPlateScheme
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
	Public WithEvents btnExcel As System.Windows.Forms.Button
	Public WithEvents btnReadFromFile As System.Windows.Forms.Button
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnSaveScheme As System.Windows.Forms.Button
    Public WithEvents flexPlate As System.Windows.Forms.DataGridView
    'Public WithEvents flexPlate As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnReadFromFile = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSaveScheme = New System.Windows.Forms.Button()
        Me.flexPlate = New System.Windows.Forms.DataGridView()
        CType(Me.flexPlate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.SystemColors.Control
        Me.btnExcel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnExcel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnExcel.Location = New System.Drawing.Point(406, 392)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnExcel.Size = New System.Drawing.Size(158, 25)
        Me.btnExcel.TabIndex = 5
        Me.btnExcel.Text = "Copy samples from Excel"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnReadFromFile
        '
        Me.btnReadFromFile.BackColor = System.Drawing.SystemColors.Control
        Me.btnReadFromFile.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnReadFromFile.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReadFromFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnReadFromFile.Location = New System.Drawing.Point(592, 392)
        Me.btnReadFromFile.Name = "btnReadFromFile"
        Me.btnReadFromFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnReadFromFile.Size = New System.Drawing.Size(137, 25)
        Me.btnReadFromFile.TabIndex = 4
        Me.btnReadFromFile.Text = "Read Samples From File"
        Me.btnReadFromFile.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(8, 392)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(81, 25)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSaveScheme
        '
        Me.btnSaveScheme.BackColor = System.Drawing.SystemColors.Control
        Me.btnSaveScheme.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSaveScheme.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveScheme.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSaveScheme.Location = New System.Drawing.Point(744, 392)
        Me.btnSaveScheme.Name = "btnSaveScheme"
        Me.btnSaveScheme.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSaveScheme.Size = New System.Drawing.Size(81, 25)
        Me.btnSaveScheme.TabIndex = 2
        Me.btnSaveScheme.Text = "Save Scheme"
        Me.btnSaveScheme.UseVisualStyleBackColor = False
        '
        'flexPlate
        '
        Me.flexPlate.Location = New System.Drawing.Point(8, 8)
        Me.flexPlate.Name = "flexPlate"
        Me.flexPlate.Size = New System.Drawing.Size(817, 377)
        Me.flexPlate.TabIndex = 0
        '
        'frmPlateScheme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(832, 421)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnReadFromFile)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSaveScheme)
        Me.Controls.Add(Me.flexPlate)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "frmPlateScheme"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Specify the platescheme"
        CType(Me.flexPlate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class