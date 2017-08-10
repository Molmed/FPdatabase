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
	Public WithEvents lstSamples As System.Windows.Forms.ComboBox
	Public WithEvents flexPlate As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPlateScheme))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.btnExcel = New System.Windows.Forms.Button
		Me.btnReadFromFile = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnSaveScheme = New System.Windows.Forms.Button
		Me.lstSamples = New System.Windows.Forms.ComboBox
		Me.flexPlate = New AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.flexPlate, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Specify the platescheme"
		Me.ClientSize = New System.Drawing.Size(832, 421)
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
		Me.Name = "frmPlateScheme"
		Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnExcel.Text = "Copy samples from Excel"
		Me.btnExcel.Size = New System.Drawing.Size(129, 25)
		Me.btnExcel.Location = New System.Drawing.Point(432, 392)
		Me.btnExcel.TabIndex = 5
		Me.btnExcel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnExcel.BackColor = System.Drawing.SystemColors.Control
		Me.btnExcel.CausesValidation = True
		Me.btnExcel.Enabled = True
		Me.btnExcel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnExcel.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnExcel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnExcel.TabStop = True
		Me.btnExcel.Name = "btnExcel"
		Me.btnReadFromFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnReadFromFile.Text = "Read Samples From File"
		Me.btnReadFromFile.Size = New System.Drawing.Size(137, 25)
		Me.btnReadFromFile.Location = New System.Drawing.Point(592, 392)
		Me.btnReadFromFile.TabIndex = 4
		Me.btnReadFromFile.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnReadFromFile.BackColor = System.Drawing.SystemColors.Control
		Me.btnReadFromFile.CausesValidation = True
		Me.btnReadFromFile.Enabled = True
		Me.btnReadFromFile.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnReadFromFile.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnReadFromFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnReadFromFile.TabStop = True
		Me.btnReadFromFile.Name = "btnReadFromFile"
		Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.Size = New System.Drawing.Size(81, 25)
		Me.btnCancel.Location = New System.Drawing.Point(8, 392)
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
		Me.btnSaveScheme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnSaveScheme.Text = "Save Scheme"
		Me.btnSaveScheme.Size = New System.Drawing.Size(81, 25)
		Me.btnSaveScheme.Location = New System.Drawing.Point(744, 392)
		Me.btnSaveScheme.TabIndex = 2
		Me.btnSaveScheme.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSaveScheme.BackColor = System.Drawing.SystemColors.Control
		Me.btnSaveScheme.CausesValidation = True
		Me.btnSaveScheme.Enabled = True
		Me.btnSaveScheme.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnSaveScheme.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnSaveScheme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnSaveScheme.TabStop = True
		Me.btnSaveScheme.Name = "btnSaveScheme"
		Me.lstSamples.Size = New System.Drawing.Size(89, 21)
		Me.lstSamples.Location = New System.Drawing.Point(96, 120)
		Me.lstSamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.lstSamples.TabIndex = 1
		Me.lstSamples.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstSamples.BackColor = System.Drawing.SystemColors.Window
		Me.lstSamples.CausesValidation = True
		Me.lstSamples.Enabled = True
		Me.lstSamples.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstSamples.IntegralHeight = True
		Me.lstSamples.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstSamples.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstSamples.Sorted = False
		Me.lstSamples.TabStop = True
		Me.lstSamples.Visible = True
		Me.lstSamples.Name = "lstSamples"
		flexPlate.OcxState = CType(resources.GetObject("flexPlate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.flexPlate.Size = New System.Drawing.Size(817, 377)
		Me.flexPlate.Location = New System.Drawing.Point(8, 8)
		Me.flexPlate.TabIndex = 0
		Me.flexPlate.Name = "flexPlate"
		Me.Controls.Add(btnExcel)
		Me.Controls.Add(btnReadFromFile)
		Me.Controls.Add(btnCancel)
		Me.Controls.Add(btnSaveScheme)
		Me.Controls.Add(lstSamples)
		Me.Controls.Add(flexPlate)
		CType(Me.flexPlate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class