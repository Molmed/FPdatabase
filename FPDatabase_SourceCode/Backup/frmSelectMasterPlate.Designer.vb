<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSelectMasterPlate
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
	Public WithEvents TreeViewPlates As System.Windows.Forms.TreeView
	Public WithEvents btnSearch As System.Windows.Forms.Button
	Public WithEvents txtSearch As System.Windows.Forms.TextBox
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOK As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSelectMasterPlate))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.TreeViewPlates = New System.Windows.Forms.TreeView
		Me.btnSearch = New System.Windows.Forms.Button
		Me.txtSearch = New System.Windows.Forms.TextBox
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnOK = New System.Windows.Forms.Button
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Select the plate you want to use"
		Me.ClientSize = New System.Drawing.Size(379, 317)
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
		Me.Name = "frmSelectMasterPlate"
		Me.TreeViewPlates.CausesValidation = True
		Me.TreeViewPlates.Size = New System.Drawing.Size(361, 241)
		Me.TreeViewPlates.Location = New System.Drawing.Point(8, 8)
		Me.TreeViewPlates.TabIndex = 4
		Me.TreeViewPlates.HideSelection = False
		Me.TreeViewPlates.Indent = 36
		Me.TreeViewPlates.LabelEdit = False
		Me.TreeViewPlates.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TreeViewPlates.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TreeViewPlates.Name = "TreeViewPlates"
		Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnSearch.Text = "Search"
		Me.btnSearch.Size = New System.Drawing.Size(73, 25)
		Me.btnSearch.Location = New System.Drawing.Point(296, 256)
		Me.btnSearch.TabIndex = 3
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
		Me.txtSearch.Size = New System.Drawing.Size(281, 25)
		Me.txtSearch.Location = New System.Drawing.Point(8, 256)
		Me.txtSearch.TabIndex = 2
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
		Me.btnCancel.Location = New System.Drawing.Point(216, 288)
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
		Me.btnOK.Location = New System.Drawing.Point(296, 288)
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
		Me.Controls.Add(TreeViewPlates)
		Me.Controls.Add(btnSearch)
		Me.Controls.Add(txtSearch)
		Me.Controls.Add(btnCancel)
		Me.Controls.Add(btnOK)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class