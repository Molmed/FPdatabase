<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSelectSampleFile
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
	Public WithEvents TreeViewLoadOrder As System.Windows.Forms.TreeView
	Public WithEvents optOrderByDate As System.Windows.Forms.RadioButton
	Public WithEvents optOrderByName As System.Windows.Forms.RadioButton
	Public WithEvents frameOrderOptions As System.Windows.Forms.GroupBox
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public WithEvents btnSearch As System.Windows.Forms.Button
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents btnBrowse As System.Windows.Forms.Button
	Public WithEvents txtSampleFileName As System.Windows.Forms.TextBox
	Public WithEvents lblloadOrder As System.Windows.Forms.Label
	Public WithEvents lblSampleFileName As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSelectSampleFile))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.TreeViewLoadOrder = New System.Windows.Forms.TreeView
		Me.frameOrderOptions = New System.Windows.Forms.GroupBox
		Me.optOrderByDate = New System.Windows.Forms.RadioButton
		Me.optOrderByName = New System.Windows.Forms.RadioButton
		Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
		Me.btnSearch = New System.Windows.Forms.Button
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnOk = New System.Windows.Forms.Button
		Me.btnBrowse = New System.Windows.Forms.Button
		Me.txtSampleFileName = New System.Windows.Forms.TextBox
		Me.lblloadOrder = New System.Windows.Forms.Label
		Me.lblSampleFileName = New System.Windows.Forms.Label
		Me.frameOrderOptions.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Select sample File"
		Me.ClientSize = New System.Drawing.Size(343, 459)
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
		Me.Name = "frmSelectSampleFile"
		Me.TreeViewLoadOrder.CausesValidation = True
		Me.TreeViewLoadOrder.Size = New System.Drawing.Size(313, 217)
		Me.TreeViewLoadOrder.Location = New System.Drawing.Point(16, 88)
		Me.TreeViewLoadOrder.TabIndex = 11
		Me.TreeViewLoadOrder.HideSelection = False
		Me.TreeViewLoadOrder.Indent = 36
		Me.TreeViewLoadOrder.LabelEdit = False
		Me.TreeViewLoadOrder.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TreeViewLoadOrder.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TreeViewLoadOrder.Name = "TreeViewLoadOrder"
		Me.frameOrderOptions.Text = "Order options"
		Me.frameOrderOptions.Size = New System.Drawing.Size(113, 105)
		Me.frameOrderOptions.Location = New System.Drawing.Point(208, 312)
		Me.frameOrderOptions.TabIndex = 8
		Me.frameOrderOptions.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frameOrderOptions.BackColor = System.Drawing.SystemColors.Control
		Me.frameOrderOptions.Enabled = True
		Me.frameOrderOptions.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frameOrderOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frameOrderOptions.Visible = True
		Me.frameOrderOptions.Padding = New System.Windows.Forms.Padding(0)
		Me.frameOrderOptions.Name = "frameOrderOptions"
		Me.optOrderByDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optOrderByDate.Text = "Order by date"
		Me.optOrderByDate.Size = New System.Drawing.Size(97, 25)
		Me.optOrderByDate.Location = New System.Drawing.Point(8, 56)
		Me.optOrderByDate.TabIndex = 10
		Me.optOrderByDate.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optOrderByDate.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optOrderByDate.BackColor = System.Drawing.SystemColors.Control
		Me.optOrderByDate.CausesValidation = True
		Me.optOrderByDate.Enabled = True
		Me.optOrderByDate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optOrderByDate.Cursor = System.Windows.Forms.Cursors.Default
		Me.optOrderByDate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optOrderByDate.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optOrderByDate.TabStop = True
		Me.optOrderByDate.Checked = False
		Me.optOrderByDate.Visible = True
		Me.optOrderByDate.Name = "optOrderByDate"
		Me.optOrderByName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optOrderByName.Text = "Order by name"
		Me.optOrderByName.Size = New System.Drawing.Size(97, 25)
		Me.optOrderByName.Location = New System.Drawing.Point(8, 24)
		Me.optOrderByName.TabIndex = 9
		Me.optOrderByName.Checked = True
		Me.optOrderByName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optOrderByName.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optOrderByName.BackColor = System.Drawing.SystemColors.Control
		Me.optOrderByName.CausesValidation = True
		Me.optOrderByName.Enabled = True
		Me.optOrderByName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optOrderByName.Cursor = System.Windows.Forms.Cursors.Default
		Me.optOrderByName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optOrderByName.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optOrderByName.TabStop = True
		Me.optOrderByName.Visible = True
		Me.optOrderByName.Name = "optOrderByName"
		Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnSearch.Text = "Search"
		Me.btnSearch.Size = New System.Drawing.Size(73, 25)
		Me.btnSearch.Location = New System.Drawing.Point(128, 352)
		Me.btnSearch.TabIndex = 7
		Me.btnSearch.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSearch.BackColor = System.Drawing.SystemColors.Control
		Me.btnSearch.CausesValidation = True
		Me.btnSearch.Enabled = True
		Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnSearch.TabStop = True
		Me.btnSearch.Name = "btnSearch"
		Me.txtSearch.AutoSize = False
		Me.txtSearch.Size = New System.Drawing.Size(193, 25)
		Me.txtSearch.Location = New System.Drawing.Point(8, 320)
		Me.txtSearch.TabIndex = 6
		Me.txtSearch.Text = "Search"
		Me.txtSearch.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSearch.AcceptsReturn = True
		Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSearch.BackColor = System.Drawing.SystemColors.Window
		Me.txtSearch.CausesValidation = True
		Me.txtSearch.Enabled = True
		Me.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSearch.HideSelection = True
		Me.txtSearch.ReadOnly = False
		Me.txtSearch.Maxlength = 0
		Me.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSearch.MultiLine = False
		Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSearch.TabStop = True
		Me.txtSearch.Visible = True
		Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSearch.Name = "txtSearch"
		Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.Size = New System.Drawing.Size(73, 25)
		Me.btnCancel.Location = New System.Drawing.Point(168, 424)
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
		Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnOk.Text = "OK"
		Me.btnOk.Size = New System.Drawing.Size(73, 25)
		Me.btnOk.Location = New System.Drawing.Point(248, 424)
		Me.btnOk.TabIndex = 4
		Me.btnOk.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnOk.BackColor = System.Drawing.SystemColors.Control
		Me.btnOk.CausesValidation = True
		Me.btnOk.Enabled = True
		Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnOk.TabStop = True
		Me.btnOk.Name = "btnOk"
		Me.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnBrowse.Text = "..."
		Me.btnBrowse.Size = New System.Drawing.Size(33, 25)
		Me.btnBrowse.Location = New System.Drawing.Point(304, 24)
		Me.btnBrowse.TabIndex = 2
		Me.btnBrowse.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnBrowse.BackColor = System.Drawing.SystemColors.Control
		Me.btnBrowse.CausesValidation = True
		Me.btnBrowse.Enabled = True
		Me.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnBrowse.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnBrowse.TabStop = True
		Me.btnBrowse.Name = "btnBrowse"
		Me.txtSampleFileName.AutoSize = False
		Me.txtSampleFileName.Size = New System.Drawing.Size(289, 25)
		Me.txtSampleFileName.Location = New System.Drawing.Point(8, 24)
		Me.txtSampleFileName.TabIndex = 1
		Me.txtSampleFileName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSampleFileName.AcceptsReturn = True
		Me.txtSampleFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtSampleFileName.BackColor = System.Drawing.SystemColors.Window
		Me.txtSampleFileName.CausesValidation = True
		Me.txtSampleFileName.Enabled = True
		Me.txtSampleFileName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtSampleFileName.HideSelection = True
		Me.txtSampleFileName.ReadOnly = False
		Me.txtSampleFileName.Maxlength = 0
		Me.txtSampleFileName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSampleFileName.MultiLine = False
		Me.txtSampleFileName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtSampleFileName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtSampleFileName.TabStop = True
		Me.txtSampleFileName.Visible = True
		Me.txtSampleFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtSampleFileName.Name = "txtSampleFileName"
		Me.lblloadOrder.Text = "Load Order"
		Me.lblloadOrder.Size = New System.Drawing.Size(225, 17)
		Me.lblloadOrder.Location = New System.Drawing.Point(8, 64)
		Me.lblloadOrder.TabIndex = 3
		Me.lblloadOrder.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblloadOrder.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblloadOrder.BackColor = System.Drawing.SystemColors.Control
		Me.lblloadOrder.Enabled = True
		Me.lblloadOrder.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblloadOrder.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblloadOrder.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblloadOrder.UseMnemonic = True
		Me.lblloadOrder.Visible = True
		Me.lblloadOrder.AutoSize = False
		Me.lblloadOrder.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblloadOrder.Name = "lblloadOrder"
		Me.lblSampleFileName.Text = "Sample File:"
		Me.lblSampleFileName.Size = New System.Drawing.Size(193, 17)
		Me.lblSampleFileName.Location = New System.Drawing.Point(8, 8)
		Me.lblSampleFileName.TabIndex = 0
		Me.lblSampleFileName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSampleFileName.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblSampleFileName.BackColor = System.Drawing.SystemColors.Control
		Me.lblSampleFileName.Enabled = True
		Me.lblSampleFileName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblSampleFileName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblSampleFileName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblSampleFileName.UseMnemonic = True
		Me.lblSampleFileName.Visible = True
		Me.lblSampleFileName.AutoSize = False
		Me.lblSampleFileName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblSampleFileName.Name = "lblSampleFileName"
		Me.Controls.Add(TreeViewLoadOrder)
		Me.Controls.Add(frameOrderOptions)
		Me.Controls.Add(btnSearch)
		Me.Controls.Add(txtSearch)
		Me.Controls.Add(btnCancel)
		Me.Controls.Add(btnOk)
		Me.Controls.Add(btnBrowse)
		Me.Controls.Add(txtSampleFileName)
		Me.Controls.Add(lblloadOrder)
		Me.Controls.Add(lblSampleFileName)
		Me.frameOrderOptions.Controls.Add(optOrderByDate)
		Me.frameOrderOptions.Controls.Add(optOrderByName)
		Me.frameOrderOptions.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class