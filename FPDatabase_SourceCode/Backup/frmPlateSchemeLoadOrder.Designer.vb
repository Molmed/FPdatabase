<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPlateSchemeLoadOrder
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
	Public WithEvents btnSaveLoadOrder As System.Windows.Forms.Button
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents flexPlate As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPlateSchemeLoadOrder))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.btnSaveLoadOrder = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.flexPlate = New AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.flexPlate, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Load order"
		Me.ClientSize = New System.Drawing.Size(839, 417)
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
		Me.Name = "frmPlateSchemeLoadOrder"
		Me.btnSaveLoadOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnSaveLoadOrder.Text = "Save Loadorder"
		Me.btnSaveLoadOrder.Size = New System.Drawing.Size(105, 25)
		Me.btnSaveLoadOrder.Location = New System.Drawing.Point(712, 384)
		Me.btnSaveLoadOrder.TabIndex = 1
		Me.btnSaveLoadOrder.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSaveLoadOrder.BackColor = System.Drawing.SystemColors.Control
		Me.btnSaveLoadOrder.CausesValidation = True
		Me.btnSaveLoadOrder.Enabled = True
		Me.btnSaveLoadOrder.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnSaveLoadOrder.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnSaveLoadOrder.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnSaveLoadOrder.TabStop = True
		Me.btnSaveLoadOrder.Name = "btnSaveLoadOrder"
		Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.Size = New System.Drawing.Size(81, 25)
		Me.btnCancel.Location = New System.Drawing.Point(616, 384)
		Me.btnCancel.TabIndex = 0
		Me.btnCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
		Me.btnCancel.CausesValidation = True
		Me.btnCancel.Enabled = True
		Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnCancel.TabStop = True
		Me.btnCancel.Name = "btnCancel"
		flexPlate.OcxState = CType(resources.GetObject("flexPlate.OcxState"), System.Windows.Forms.AxHost.State)
		Me.flexPlate.Size = New System.Drawing.Size(817, 377)
		Me.flexPlate.Location = New System.Drawing.Point(0, 0)
		Me.flexPlate.TabIndex = 2
		Me.flexPlate.Name = "flexPlate"
		Me.Controls.Add(btnSaveLoadOrder)
		Me.Controls.Add(btnCancel)
		Me.Controls.Add(flexPlate)
		CType(Me.flexPlate, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class