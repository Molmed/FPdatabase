<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmReadSampleName
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
	Public WithEvents OkButton As System.Windows.Forms.Button
	Public WithEvents txtSampleName As System.Windows.Forms.TextBox
	Public WithEvents _ListView1_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents _ListView1_ColumnHeader_2 As System.Windows.Forms.ColumnHeader
	Public WithEvents ListView1 As System.Windows.Forms.ListView
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmReadSampleName))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.OkButton = New System.Windows.Forms.Button
		Me.txtSampleName = New System.Windows.Forms.TextBox
		Me.ListView1 = New System.Windows.Forms.ListView
		Me._ListView1_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me._ListView1_ColumnHeader_2 = New System.Windows.Forms.ColumnHeader
		Me.ListView1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Samples"
		Me.ClientSize = New System.Drawing.Size(416, 231)
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
		Me.Name = "frmReadSampleName"
		Me.OkButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.OkButton.Text = "OK"
		Me.OkButton.Size = New System.Drawing.Size(81, 33)
		Me.OkButton.Location = New System.Drawing.Point(312, 16)
		Me.OkButton.TabIndex = 2
		Me.OkButton.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OkButton.BackColor = System.Drawing.SystemColors.Control
		Me.OkButton.CausesValidation = True
		Me.OkButton.Enabled = True
		Me.OkButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.OkButton.Cursor = System.Windows.Forms.Cursors.Default
		Me.OkButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OkButton.TabStop = True
		Me.OkButton.Name = "OkButton"
		Me.txtSampleName.AutoSize = False
		Me.txtSampleName.Size = New System.Drawing.Size(113, 19)
		Me.txtSampleName.Location = New System.Drawing.Point(64, 56)
		Me.txtSampleName.TabIndex = 1
		Me.txtSampleName.Text = "Text1"
		Me.txtSampleName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSampleName.AcceptsReturn = True
		Me.txtSampleName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSampleName.BackColor = System.Drawing.SystemColors.Window
		Me.txtSampleName.CausesValidation = True
		Me.txtSampleName.Enabled = True
		Me.txtSampleName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSampleName.HideSelection = True
		Me.txtSampleName.ReadOnly = False
		Me.txtSampleName.Maxlength = 0
		Me.txtSampleName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSampleName.MultiLine = False
		Me.txtSampleName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSampleName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSampleName.TabStop = True
		Me.txtSampleName.Visible = True
		Me.txtSampleName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSampleName.Name = "txtSampleName"
		Me.ListView1.Size = New System.Drawing.Size(265, 169)
		Me.ListView1.Location = New System.Drawing.Point(24, 16)
		Me.ListView1.TabIndex = 0
		Me.ListView1.View = System.Windows.Forms.View.Details
		Me.ListView1.LabelWrap = True
		Me.ListView1.HideSelection = True
		Me.ListView1.FullRowSelect = True
		Me.ListView1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.ListView1.BackColor = System.Drawing.SystemColors.Window
		Me.ListView1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ListView1.LabelEdit = True
		Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.ListView1.Name = "ListView1"
		Me._ListView1_ColumnHeader_1.Tag = "Sample"
		Me._ListView1_ColumnHeader_1.Text = "Sample"
		Me._ListView1_ColumnHeader_1.Width = 170
		Me._ListView1_ColumnHeader_2.Tag = "SampleName"
		Me._ListView1_ColumnHeader_2.Text = "Sample Name"
		Me._ListView1_ColumnHeader_2.Width = 170
		Me.Controls.Add(OkButton)
		Me.Controls.Add(txtSampleName)
		Me.Controls.Add(ListView1)
		Me.ListView1.Columns.Add(_ListView1_ColumnHeader_1)
		Me.ListView1.Columns.Add(_ListView1_ColumnHeader_2)
		Me.ListView1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class