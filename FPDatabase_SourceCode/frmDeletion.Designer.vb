<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDeletion
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
	Public WithEvents btnDelete As System.Windows.Forms.Button
	Public WithEvents btnOK As System.Windows.Forms.Button
	Public WithEvents optOrderByDate As System.Windows.Forms.RadioButton
	Public WithEvents optOrderByName As System.Windows.Forms.RadioButton
	Public WithEvents frameOrderOptions As System.Windows.Forms.GroupBox
	Public WithEvents btnSearch As System.Windows.Forms.Button
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents TreeViewItems As System.Windows.Forms.TreeView
	Public WithEvents cboItemType As System.Windows.Forms.ComboBox
	Public WithEvents lblAvailableItems As System.Windows.Forms.Label
	Public WithEvents lblItemType As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDeletion))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.btnDelete = New System.Windows.Forms.Button
		Me.btnOK = New System.Windows.Forms.Button
		Me.frameOrderOptions = New System.Windows.Forms.GroupBox
		Me.optOrderByDate = New System.Windows.Forms.RadioButton
		Me.optOrderByName = New System.Windows.Forms.RadioButton
		Me.btnSearch = New System.Windows.Forms.Button
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.TreeViewItems = New System.Windows.Forms.TreeView
		Me.cboItemType = New System.Windows.Forms.ComboBox
		Me.lblAvailableItems = New System.Windows.Forms.Label
		Me.lblItemType = New System.Windows.Forms.Label
		Me.frameOrderOptions.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Delete"
		Me.ClientSize = New System.Drawing.Size(396, 525)
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
		Me.Name = "frmDeletion"
		Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnDelete.Text = "Delete"
		Me.btnDelete.Size = New System.Drawing.Size(73, 25)
		Me.btnDelete.Location = New System.Drawing.Point(8, 360)
		Me.btnDelete.TabIndex = 10
		Me.btnDelete.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
		Me.btnDelete.CausesValidation = True
		Me.btnDelete.Enabled = True
		Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnDelete.TabStop = True
		Me.btnDelete.Name = "btnDelete"
		Me.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnOK.Text = "Close"
		Me.btnOK.Size = New System.Drawing.Size(81, 25)
		Me.btnOK.Location = New System.Drawing.Point(304, 496)
		Me.btnOK.TabIndex = 9
		Me.btnOK.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnOK.BackColor = System.Drawing.SystemColors.Control
		Me.btnOK.CausesValidation = True
		Me.btnOK.Enabled = True
		Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnOK.TabStop = True
		Me.btnOK.Name = "btnOK"
		Me.frameOrderOptions.Text = "Order options"
		Me.frameOrderOptions.Size = New System.Drawing.Size(121, 73)
		Me.frameOrderOptions.Location = New System.Drawing.Point(264, 416)
		Me.frameOrderOptions.TabIndex = 6
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
		Me.optOrderByDate.Size = New System.Drawing.Size(97, 17)
		Me.optOrderByDate.Location = New System.Drawing.Point(16, 40)
		Me.optOrderByDate.TabIndex = 8
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
		Me.optOrderByName.Size = New System.Drawing.Size(97, 17)
		Me.optOrderByName.Location = New System.Drawing.Point(16, 16)
		Me.optOrderByName.TabIndex = 7
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
		Me.btnSearch.Location = New System.Drawing.Point(184, 464)
		Me.btnSearch.TabIndex = 5
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
		Me.txtSearch.Location = New System.Drawing.Point(8, 432)
		Me.txtSearch.TabIndex = 4
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
		Me.TreeViewItems.CausesValidation = True
		Me.TreeViewItems.Size = New System.Drawing.Size(377, 265)
		Me.TreeViewItems.Location = New System.Drawing.Point(8, 88)
		Me.TreeViewItems.TabIndex = 2
		Me.TreeViewItems.LabelEdit = False
		Me.TreeViewItems.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TreeViewItems.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TreeViewItems.Name = "TreeViewItems"
		Me.cboItemType.Size = New System.Drawing.Size(273, 21)
		Me.cboItemType.Location = New System.Drawing.Point(8, 32)
		Me.cboItemType.Items.AddRange(New Object(){"Plate", "Plate Scheme"})
		Me.cboItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboItemType.TabIndex = 1
		Me.cboItemType.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboItemType.BackColor = System.Drawing.SystemColors.Window
		Me.cboItemType.CausesValidation = True
		Me.cboItemType.Enabled = True
		Me.cboItemType.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboItemType.IntegralHeight = True
		Me.cboItemType.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboItemType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboItemType.Sorted = False
		Me.cboItemType.TabStop = True
		Me.cboItemType.Visible = True
		Me.cboItemType.Name = "cboItemType"
		Me.lblAvailableItems.Text = "Available items:"
		Me.lblAvailableItems.Size = New System.Drawing.Size(145, 17)
		Me.lblAvailableItems.Location = New System.Drawing.Point(8, 72)
		Me.lblAvailableItems.TabIndex = 3
		Me.lblAvailableItems.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAvailableItems.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblAvailableItems.BackColor = System.Drawing.SystemColors.Control
		Me.lblAvailableItems.Enabled = True
		Me.lblAvailableItems.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblAvailableItems.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblAvailableItems.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblAvailableItems.UseMnemonic = True
		Me.lblAvailableItems.Visible = True
		Me.lblAvailableItems.AutoSize = False
		Me.lblAvailableItems.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblAvailableItems.Name = "lblAvailableItems"
		Me.lblItemType.Text = "Type of item to delete:"
		Me.lblItemType.Size = New System.Drawing.Size(265, 17)
		Me.lblItemType.Location = New System.Drawing.Point(8, 8)
		Me.lblItemType.TabIndex = 0
		Me.lblItemType.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblItemType.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblItemType.BackColor = System.Drawing.SystemColors.Control
		Me.lblItemType.Enabled = True
		Me.lblItemType.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblItemType.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblItemType.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblItemType.UseMnemonic = True
		Me.lblItemType.Visible = True
		Me.lblItemType.AutoSize = False
		Me.lblItemType.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblItemType.Name = "lblItemType"
		Me.Controls.Add(btnDelete)
		Me.Controls.Add(btnOK)
		Me.Controls.Add(frameOrderOptions)
		Me.Controls.Add(btnSearch)
		Me.Controls.Add(txtSearch)
		Me.Controls.Add(TreeViewItems)
		Me.Controls.Add(cboItemType)
		Me.Controls.Add(lblAvailableItems)
		Me.Controls.Add(lblItemType)
		Me.frameOrderOptions.Controls.Add(optOrderByDate)
		Me.frameOrderOptions.Controls.Add(optOrderByName)
		Me.frameOrderOptions.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class