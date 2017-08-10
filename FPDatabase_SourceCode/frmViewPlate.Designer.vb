<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmViewPlate
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
	Public WithEvents cboPlate As System.Windows.Forms.ComboBox
	Public WithEvents btnClose As System.Windows.Forms.Button
    'Public WithEvents flexPlate As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
    Public WithEvents flexPlate As DataGridView
	Public WithEvents lblSelect As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmViewPlate))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cboPlate = New System.Windows.Forms.ComboBox
		Me.btnClose = New System.Windows.Forms.Button
        'Me.flexPlate = New AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
        Me.flexPlate = New DataGridView
		Me.lblSelect = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.flexPlate, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "View Plate/Plate Scheme"
		Me.ClientSize = New System.Drawing.Size(710, 365)
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
		Me.Name = "frmViewPlate"
		Me.cboPlate.Size = New System.Drawing.Size(193, 21)
		Me.cboPlate.Location = New System.Drawing.Point(96, 336)
		Me.cboPlate.TabIndex = 2
		Me.cboPlate.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboPlate.BackColor = System.Drawing.SystemColors.Window
		Me.cboPlate.CausesValidation = True
		Me.cboPlate.Enabled = True
		Me.cboPlate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboPlate.IntegralHeight = True
		Me.cboPlate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboPlate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboPlate.Sorted = False
		Me.cboPlate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cboPlate.TabStop = True
		Me.cboPlate.Visible = True
		Me.cboPlate.Name = "cboPlate"
		Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnClose.Text = "Close"
		Me.btnClose.Size = New System.Drawing.Size(65, 25)
		Me.btnClose.Location = New System.Drawing.Point(632, 336)
		Me.btnClose.TabIndex = 1
		Me.btnClose.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnClose.BackColor = System.Drawing.SystemColors.Control
		Me.btnClose.CausesValidation = True
		Me.btnClose.Enabled = True
		Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnClose.TabStop = True
		Me.btnClose.Name = "btnClose"
        'flexPlate.OcxState = CType(resources.GetObject("flexPlate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.flexPlate.Size = New System.Drawing.Size(689, 321)
		Me.flexPlate.Location = New System.Drawing.Point(8, 8)
		Me.flexPlate.TabIndex = 0
		Me.flexPlate.Name = "flexPlate"
		Me.lblSelect.Text = "Select <...>"
		Me.lblSelect.Size = New System.Drawing.Size(89, 17)
		Me.lblSelect.Location = New System.Drawing.Point(8, 336)
		Me.lblSelect.TabIndex = 3
		Me.lblSelect.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSelect.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblSelect.BackColor = System.Drawing.SystemColors.Control
		Me.lblSelect.Enabled = True
		Me.lblSelect.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblSelect.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblSelect.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblSelect.UseMnemonic = True
		Me.lblSelect.Visible = True
		Me.lblSelect.AutoSize = False
		Me.lblSelect.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblSelect.Name = "lblSelect"
		Me.Controls.Add(cboPlate)
		Me.Controls.Add(btnClose)
		Me.Controls.Add(flexPlate)
		Me.Controls.Add(lblSelect)
		CType(Me.flexPlate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class