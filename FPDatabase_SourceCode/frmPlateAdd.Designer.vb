<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPlateAdd
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
	Public WithEvents optOrderByDate As System.Windows.Forms.RadioButton
	Public WithEvents optOrderByName As System.Windows.Forms.RadioButton
	Public WithEvents frameOrderOptions As System.Windows.Forms.GroupBox
	Public WithEvents TreeViewPlateScheme As System.Windows.Forms.TreeView
	Public WithEvents btnSearch As System.Windows.Forms.Button
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents btnViewScheme As System.Windows.Forms.Button
	Public WithEvents txtPlateName As System.Windows.Forms.TextBox
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOK As System.Windows.Forms.Button
	Public WithEvents lblSelectPlateScheme As System.Windows.Forms.Label
	Public WithEvents lblPlateName As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPlateAdd))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.frameOrderOptions = New System.Windows.Forms.GroupBox
		Me.optOrderByDate = New System.Windows.Forms.RadioButton
		Me.optOrderByName = New System.Windows.Forms.RadioButton
		Me.TreeViewPlateScheme = New System.Windows.Forms.TreeView
		Me.btnSearch = New System.Windows.Forms.Button
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.btnViewScheme = New System.Windows.Forms.Button
		Me.txtPlateName = New System.Windows.Forms.TextBox
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnOK = New System.Windows.Forms.Button
		Me.lblSelectPlateScheme = New System.Windows.Forms.Label
		Me.lblPlateName = New System.Windows.Forms.Label
		Me.frameOrderOptions.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Add a plate"
		Me.ClientSize = New System.Drawing.Size(407, 508)
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
		Me.Name = "frmPlateAdd"
		Me.frameOrderOptions.Text = "Order options"
		Me.frameOrderOptions.Size = New System.Drawing.Size(121, 73)
		Me.frameOrderOptions.Location = New System.Drawing.Point(272, 392)
		Me.frameOrderOptions.TabIndex = 9
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
		Me.optOrderByDate.Location = New System.Drawing.Point(8, 40)
		Me.optOrderByDate.TabIndex = 11
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
		Me.optOrderByName.Location = New System.Drawing.Point(8, 16)
		Me.optOrderByName.TabIndex = 10
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
		Me.TreeViewPlateScheme.CausesValidation = True
		Me.TreeViewPlateScheme.Size = New System.Drawing.Size(385, 289)
		Me.TreeViewPlateScheme.Location = New System.Drawing.Point(8, 96)
		Me.TreeViewPlateScheme.TabIndex = 8
		Me.TreeViewPlateScheme.HideSelection = False
		Me.TreeViewPlateScheme.Indent = 36
		Me.TreeViewPlateScheme.LabelEdit = False
		Me.TreeViewPlateScheme.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TreeViewPlateScheme.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TreeViewPlateScheme.Name = "TreeViewPlateScheme"
		Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnSearch.Text = "Search"
		Me.btnSearch.Size = New System.Drawing.Size(73, 25)
		Me.btnSearch.Location = New System.Drawing.Point(184, 424)
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
		Me.txtSearch.Size = New System.Drawing.Size(249, 25)
		Me.txtSearch.Location = New System.Drawing.Point(8, 392)
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
		Me.btnViewScheme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnViewScheme.Text = "View Scheme"
		Me.btnViewScheme.Size = New System.Drawing.Size(89, 25)
		Me.btnViewScheme.Location = New System.Drawing.Point(8, 424)
		Me.btnViewScheme.TabIndex = 5
		Me.btnViewScheme.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnViewScheme.BackColor = System.Drawing.SystemColors.Control
		Me.btnViewScheme.CausesValidation = True
		Me.btnViewScheme.Enabled = True
		Me.btnViewScheme.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnViewScheme.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnViewScheme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnViewScheme.TabStop = True
		Me.btnViewScheme.Name = "btnViewScheme"
		Me.txtPlateName.AutoSize = False
		Me.txtPlateName.Size = New System.Drawing.Size(385, 25)
		Me.txtPlateName.Location = New System.Drawing.Point(8, 24)
		Me.txtPlateName.TabIndex = 3
		Me.txtPlateName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtPlateName.AcceptsReturn = True
		Me.txtPlateName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPlateName.BackColor = System.Drawing.SystemColors.Window
		Me.txtPlateName.CausesValidation = True
		Me.txtPlateName.Enabled = True
		Me.txtPlateName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPlateName.HideSelection = True
		Me.txtPlateName.ReadOnly = False
		Me.txtPlateName.Maxlength = 0
		Me.txtPlateName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPlateName.MultiLine = False
		Me.txtPlateName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPlateName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPlateName.TabStop = True
		Me.txtPlateName.Visible = True
		Me.txtPlateName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPlateName.Name = "txtPlateName"
		Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.Size = New System.Drawing.Size(73, 25)
		Me.btnCancel.Location = New System.Drawing.Point(240, 472)
		Me.btnCancel.TabIndex = 1
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
		Me.btnOK.Size = New System.Drawing.Size(73, 25)
		Me.btnOK.Location = New System.Drawing.Point(320, 472)
		Me.btnOK.TabIndex = 0
		Me.btnOK.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnOK.BackColor = System.Drawing.SystemColors.Control
		Me.btnOK.CausesValidation = True
		Me.btnOK.Enabled = True
		Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnOK.TabStop = True
		Me.btnOK.Name = "btnOK"
		Me.lblSelectPlateScheme.Text = "Selet the plate scheme"
		Me.lblSelectPlateScheme.Size = New System.Drawing.Size(185, 17)
		Me.lblSelectPlateScheme.Location = New System.Drawing.Point(8, 72)
		Me.lblSelectPlateScheme.TabIndex = 4
		Me.lblSelectPlateScheme.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSelectPlateScheme.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblSelectPlateScheme.BackColor = System.Drawing.SystemColors.Control
		Me.lblSelectPlateScheme.Enabled = True
		Me.lblSelectPlateScheme.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblSelectPlateScheme.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblSelectPlateScheme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblSelectPlateScheme.UseMnemonic = True
		Me.lblSelectPlateScheme.Visible = True
		Me.lblSelectPlateScheme.AutoSize = False
		Me.lblSelectPlateScheme.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblSelectPlateScheme.Name = "lblSelectPlateScheme"
		Me.lblPlateName.Text = "Plate Name:"
		Me.lblPlateName.Size = New System.Drawing.Size(72, 21)
		Me.lblPlateName.Location = New System.Drawing.Point(8, 8)
		Me.lblPlateName.TabIndex = 2
		Me.lblPlateName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPlateName.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPlateName.BackColor = System.Drawing.SystemColors.Control
		Me.lblPlateName.Enabled = True
		Me.lblPlateName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPlateName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPlateName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPlateName.UseMnemonic = True
		Me.lblPlateName.Visible = True
		Me.lblPlateName.AutoSize = False
		Me.lblPlateName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPlateName.Name = "lblPlateName"
		Me.Controls.Add(frameOrderOptions)
		Me.Controls.Add(TreeViewPlateScheme)
		Me.Controls.Add(btnSearch)
		Me.Controls.Add(txtSearch)
		Me.Controls.Add(btnViewScheme)
		Me.Controls.Add(txtPlateName)
		Me.Controls.Add(btnCancel)
		Me.Controls.Add(btnOK)
		Me.Controls.Add(lblSelectPlateScheme)
		Me.Controls.Add(lblPlateName)
		Me.frameOrderOptions.Controls.Add(optOrderByDate)
		Me.frameOrderOptions.Controls.Add(optOrderByName)
		Me.frameOrderOptions.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class