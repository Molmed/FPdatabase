<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FPresultDB
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
	Public WithEvents optShowAll As System.Windows.Forms.RadioButton
	Public WithEvents optShowOnlyEmpty As System.Windows.Forms.RadioButton
	Public WithEvents framePlateListOptions As System.Windows.Forms.GroupBox
	Public WithEvents TreeViewPlates As System.Windows.Forms.TreeView
	Public WithEvents btnPlateSearch As System.Windows.Forms.Button
	Public WithEvents txtPlateSearch As System.Windows.Forms.TextBox
	Public WithEvents btnSearchAssay As System.Windows.Forms.Button
	Public WithEvents txtAssaySearch As System.Windows.Forms.TextBox
	Public WithEvents _lstAssays_ColumnHeader_1 As System.Windows.Forms.ColumnHeader
	Public WithEvents lstAssays As System.Windows.Forms.ListView
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnGenotypeBrowse As System.Windows.Forms.Button
	Public WithEvents txtGeotypeFileName As System.Windows.Forms.TextBox
	Public WithEvents btnOK As System.Windows.Forms.Button
	Public WithEvents btnRawDataBrowse As System.Windows.Forms.Button
	Public WithEvents txtDataFileName As System.Windows.Forms.TextBox
	Public WithEvents lblPlateName As System.Windows.Forms.Label
	Public WithEvents lblAssay As System.Windows.Forms.Label
	Public WithEvents lblGenotypeFile As System.Windows.Forms.Label
	Public WithEvents lblRawDataFile As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FPresultDB))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.framePlateListOptions = New System.Windows.Forms.GroupBox
		Me.optShowAll = New System.Windows.Forms.RadioButton
		Me.optShowOnlyEmpty = New System.Windows.Forms.RadioButton
		Me.TreeViewPlates = New System.Windows.Forms.TreeView
		Me.btnPlateSearch = New System.Windows.Forms.Button
		Me.txtPlateSearch = New System.Windows.Forms.TextBox
		Me.btnSearchAssay = New System.Windows.Forms.Button
		Me.txtAssaySearch = New System.Windows.Forms.TextBox
		Me.lstAssays = New System.Windows.Forms.ListView
		Me._lstAssays_ColumnHeader_1 = New System.Windows.Forms.ColumnHeader
		Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnGenotypeBrowse = New System.Windows.Forms.Button
		Me.txtGeotypeFileName = New System.Windows.Forms.TextBox
		Me.btnOK = New System.Windows.Forms.Button
		Me.btnRawDataBrowse = New System.Windows.Forms.Button
		Me.txtDataFileName = New System.Windows.Forms.TextBox
		Me.lblPlateName = New System.Windows.Forms.Label
		Me.lblAssay = New System.Windows.Forms.Label
		Me.lblGenotypeFile = New System.Windows.Forms.Label
		Me.lblRawDataFile = New System.Windows.Forms.Label
		Me.framePlateListOptions.SuspendLayout()
		Me.lstAssays.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "FP Result Entry"
		Me.ClientSize = New System.Drawing.Size(349, 610)
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
		Me.Name = "FPresultDB"
		Me.framePlateListOptions.Text = "Platelist Options"
		Me.framePlateListOptions.Size = New System.Drawing.Size(113, 65)
		Me.framePlateListOptions.Location = New System.Drawing.Point(232, 208)
		Me.framePlateListOptions.TabIndex = 16
		Me.framePlateListOptions.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.framePlateListOptions.BackColor = System.Drawing.SystemColors.Control
		Me.framePlateListOptions.Enabled = True
		Me.framePlateListOptions.ForeColor = System.Drawing.SystemColors.ControlText
		Me.framePlateListOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.framePlateListOptions.Visible = True
		Me.framePlateListOptions.Padding = New System.Windows.Forms.Padding(0)
		Me.framePlateListOptions.Name = "framePlateListOptions"
		Me.optShowAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optShowAll.Text = "Show All"
		Me.optShowAll.Size = New System.Drawing.Size(97, 17)
		Me.optShowAll.Location = New System.Drawing.Point(8, 40)
		Me.optShowAll.TabIndex = 18
		Me.optShowAll.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optShowAll.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optShowAll.BackColor = System.Drawing.SystemColors.Control
		Me.optShowAll.CausesValidation = True
		Me.optShowAll.Enabled = True
		Me.optShowAll.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optShowAll.Cursor = System.Windows.Forms.Cursors.Default
		Me.optShowAll.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optShowAll.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optShowAll.TabStop = True
		Me.optShowAll.Checked = False
		Me.optShowAll.Visible = True
		Me.optShowAll.Name = "optShowAll"
		Me.optShowOnlyEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optShowOnlyEmpty.Text = "Only Empty"
		Me.optShowOnlyEmpty.Size = New System.Drawing.Size(97, 17)
		Me.optShowOnlyEmpty.Location = New System.Drawing.Point(8, 16)
		Me.optShowOnlyEmpty.TabIndex = 17
		Me.optShowOnlyEmpty.Checked = True
		Me.optShowOnlyEmpty.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optShowOnlyEmpty.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optShowOnlyEmpty.BackColor = System.Drawing.SystemColors.Control
		Me.optShowOnlyEmpty.CausesValidation = True
		Me.optShowOnlyEmpty.Enabled = True
		Me.optShowOnlyEmpty.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optShowOnlyEmpty.Cursor = System.Windows.Forms.Cursors.Default
		Me.optShowOnlyEmpty.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optShowOnlyEmpty.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optShowOnlyEmpty.TabStop = True
		Me.optShowOnlyEmpty.Visible = True
		Me.optShowOnlyEmpty.Name = "optShowOnlyEmpty"
		Me.TreeViewPlates.CausesValidation = True
		Me.TreeViewPlates.Size = New System.Drawing.Size(329, 169)
		Me.TreeViewPlates.Location = New System.Drawing.Point(8, 32)
		Me.TreeViewPlates.TabIndex = 15
		Me.TreeViewPlates.HideSelection = False
		Me.TreeViewPlates.LabelEdit = False
		Me.TreeViewPlates.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TreeViewPlates.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TreeViewPlates.Name = "TreeViewPlates"
		Me.btnPlateSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnPlateSearch.Text = "Search"
		Me.btnPlateSearch.Size = New System.Drawing.Size(65, 25)
		Me.btnPlateSearch.Location = New System.Drawing.Point(160, 248)
		Me.btnPlateSearch.TabIndex = 14
		Me.btnPlateSearch.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnPlateSearch.BackColor = System.Drawing.SystemColors.Control
		Me.btnPlateSearch.CausesValidation = True
		Me.btnPlateSearch.Enabled = True
		Me.btnPlateSearch.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnPlateSearch.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnPlateSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnPlateSearch.TabStop = True
		Me.btnPlateSearch.Name = "btnPlateSearch"
		Me.txtPlateSearch.AutoSize = False
		Me.txtPlateSearch.Size = New System.Drawing.Size(217, 25)
		Me.txtPlateSearch.Location = New System.Drawing.Point(8, 216)
		Me.txtPlateSearch.TabIndex = 13
		Me.txtPlateSearch.Text = "Search"
		Me.txtPlateSearch.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtPlateSearch.AcceptsReturn = True
		Me.txtPlateSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPlateSearch.BackColor = System.Drawing.SystemColors.Window
		Me.txtPlateSearch.CausesValidation = True
		Me.txtPlateSearch.Enabled = True
		Me.txtPlateSearch.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPlateSearch.HideSelection = True
		Me.txtPlateSearch.ReadOnly = False
		Me.txtPlateSearch.Maxlength = 0
		Me.txtPlateSearch.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPlateSearch.MultiLine = False
		Me.txtPlateSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPlateSearch.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPlateSearch.TabStop = True
		Me.txtPlateSearch.Visible = True
		Me.txtPlateSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPlateSearch.Name = "txtPlateSearch"
		Me.btnSearchAssay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnSearchAssay.Text = "Search"
		Me.btnSearchAssay.Size = New System.Drawing.Size(73, 25)
		Me.btnSearchAssay.Location = New System.Drawing.Point(272, 544)
		Me.btnSearchAssay.TabIndex = 12
		Me.btnSearchAssay.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSearchAssay.BackColor = System.Drawing.SystemColors.Control
		Me.btnSearchAssay.CausesValidation = True
		Me.btnSearchAssay.Enabled = True
		Me.btnSearchAssay.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnSearchAssay.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnSearchAssay.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnSearchAssay.TabStop = True
		Me.btnSearchAssay.Name = "btnSearchAssay"
		Me.txtAssaySearch.AutoSize = False
		Me.txtAssaySearch.Size = New System.Drawing.Size(249, 25)
		Me.txtAssaySearch.Location = New System.Drawing.Point(8, 544)
		Me.txtAssaySearch.TabIndex = 11
		Me.txtAssaySearch.Text = "Search"
		Me.txtAssaySearch.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtAssaySearch.AcceptsReturn = True
		Me.txtAssaySearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAssaySearch.BackColor = System.Drawing.SystemColors.Window
		Me.txtAssaySearch.CausesValidation = True
		Me.txtAssaySearch.Enabled = True
		Me.txtAssaySearch.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAssaySearch.HideSelection = True
		Me.txtAssaySearch.ReadOnly = False
		Me.txtAssaySearch.Maxlength = 0
		Me.txtAssaySearch.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAssaySearch.MultiLine = False
		Me.txtAssaySearch.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAssaySearch.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAssaySearch.TabStop = True
		Me.txtAssaySearch.Visible = True
		Me.txtAssaySearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAssaySearch.Name = "txtAssaySearch"
		Me.lstAssays.Size = New System.Drawing.Size(329, 137)
		Me.lstAssays.Location = New System.Drawing.Point(8, 400)
		Me.lstAssays.TabIndex = 10
		Me.lstAssays.View = System.Windows.Forms.View.Details
		Me.lstAssays.LabelWrap = True
		Me.lstAssays.HideSelection = False
		Me.lstAssays.FullRowSelect = True
		Me.lstAssays.GridLines = True
		Me.lstAssays.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstAssays.BackColor = System.Drawing.SystemColors.Window
		Me.lstAssays.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstAssays.LabelEdit = True
		Me.lstAssays.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstAssays.Name = "lstAssays"
		Me._lstAssays_ColumnHeader_1.Text = "Assay Name"
		Me._lstAssays_ColumnHeader_1.Width = 170
		Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.Size = New System.Drawing.Size(73, 25)
		Me.btnCancel.Location = New System.Drawing.Point(192, 576)
		Me.btnCancel.TabIndex = 8
		Me.btnCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
		Me.btnCancel.CausesValidation = True
		Me.btnCancel.Enabled = True
		Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnCancel.TabStop = True
		Me.btnCancel.Name = "btnCancel"
		Me.btnGenotypeBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnGenotypeBrowse.Text = "..."
		Me.btnGenotypeBrowse.Size = New System.Drawing.Size(25, 25)
		Me.btnGenotypeBrowse.Location = New System.Drawing.Point(320, 352)
		Me.btnGenotypeBrowse.TabIndex = 4
		Me.btnGenotypeBrowse.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnGenotypeBrowse.BackColor = System.Drawing.SystemColors.Control
		Me.btnGenotypeBrowse.CausesValidation = True
		Me.btnGenotypeBrowse.Enabled = True
		Me.btnGenotypeBrowse.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnGenotypeBrowse.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnGenotypeBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnGenotypeBrowse.TabStop = True
		Me.btnGenotypeBrowse.Name = "btnGenotypeBrowse"
		Me.txtGeotypeFileName.AutoSize = False
		Me.txtGeotypeFileName.Size = New System.Drawing.Size(297, 25)
		Me.txtGeotypeFileName.Location = New System.Drawing.Point(8, 352)
		Me.txtGeotypeFileName.TabIndex = 3
		Me.txtGeotypeFileName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtGeotypeFileName.AcceptsReturn = True
		Me.txtGeotypeFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtGeotypeFileName.BackColor = System.Drawing.SystemColors.Window
		Me.txtGeotypeFileName.CausesValidation = True
		Me.txtGeotypeFileName.Enabled = True
		Me.txtGeotypeFileName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtGeotypeFileName.HideSelection = True
		Me.txtGeotypeFileName.ReadOnly = False
		Me.txtGeotypeFileName.Maxlength = 0
		Me.txtGeotypeFileName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtGeotypeFileName.MultiLine = False
		Me.txtGeotypeFileName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtGeotypeFileName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtGeotypeFileName.TabStop = True
		Me.txtGeotypeFileName.Visible = True
		Me.txtGeotypeFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtGeotypeFileName.Name = "txtGeotypeFileName"
		Me.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnOK.Text = "OK"
		Me.btnOK.Size = New System.Drawing.Size(73, 25)
		Me.btnOK.Location = New System.Drawing.Point(272, 576)
		Me.btnOK.TabIndex = 2
		Me.btnOK.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnOK.BackColor = System.Drawing.SystemColors.Control
		Me.btnOK.CausesValidation = True
		Me.btnOK.Enabled = True
		Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnOK.TabStop = True
		Me.btnOK.Name = "btnOK"
		Me.btnRawDataBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnRawDataBrowse.Text = "..."
		Me.btnRawDataBrowse.Size = New System.Drawing.Size(25, 25)
		Me.btnRawDataBrowse.Location = New System.Drawing.Point(320, 304)
		Me.btnRawDataBrowse.TabIndex = 1
		Me.btnRawDataBrowse.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnRawDataBrowse.BackColor = System.Drawing.SystemColors.Control
		Me.btnRawDataBrowse.CausesValidation = True
		Me.btnRawDataBrowse.Enabled = True
		Me.btnRawDataBrowse.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnRawDataBrowse.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnRawDataBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnRawDataBrowse.TabStop = True
		Me.btnRawDataBrowse.Name = "btnRawDataBrowse"
		Me.txtDataFileName.AutoSize = False
		Me.txtDataFileName.Size = New System.Drawing.Size(297, 25)
		Me.txtDataFileName.Location = New System.Drawing.Point(8, 304)
		Me.txtDataFileName.TabIndex = 0
		Me.txtDataFileName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtDataFileName.AcceptsReturn = True
		Me.txtDataFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDataFileName.BackColor = System.Drawing.SystemColors.Window
		Me.txtDataFileName.CausesValidation = True
		Me.txtDataFileName.Enabled = True
		Me.txtDataFileName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDataFileName.HideSelection = True
		Me.txtDataFileName.ReadOnly = False
		Me.txtDataFileName.Maxlength = 0
		Me.txtDataFileName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDataFileName.MultiLine = False
		Me.txtDataFileName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDataFileName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDataFileName.TabStop = True
		Me.txtDataFileName.Visible = True
		Me.txtDataFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDataFileName.Name = "txtDataFileName"
		Me.lblPlateName.Text = "Select a plate to add to"
		Me.lblPlateName.Size = New System.Drawing.Size(257, 17)
		Me.lblPlateName.Location = New System.Drawing.Point(8, 8)
		Me.lblPlateName.TabIndex = 9
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
		Me.lblAssay.Text = "Select Assay:"
		Me.lblAssay.Size = New System.Drawing.Size(233, 17)
		Me.lblAssay.Location = New System.Drawing.Point(8, 384)
		Me.lblAssay.TabIndex = 7
		Me.lblAssay.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAssay.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblAssay.BackColor = System.Drawing.SystemColors.Control
		Me.lblAssay.Enabled = True
		Me.lblAssay.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblAssay.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblAssay.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblAssay.UseMnemonic = True
		Me.lblAssay.Visible = True
		Me.lblAssay.AutoSize = False
		Me.lblAssay.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblAssay.Name = "lblAssay"
		Me.lblGenotypeFile.Text = "Genotype File"
		Me.lblGenotypeFile.Size = New System.Drawing.Size(249, 17)
		Me.lblGenotypeFile.Location = New System.Drawing.Point(8, 336)
		Me.lblGenotypeFile.TabIndex = 6
		Me.lblGenotypeFile.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblGenotypeFile.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblGenotypeFile.BackColor = System.Drawing.SystemColors.Control
		Me.lblGenotypeFile.Enabled = True
		Me.lblGenotypeFile.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblGenotypeFile.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblGenotypeFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblGenotypeFile.UseMnemonic = True
		Me.lblGenotypeFile.Visible = True
		Me.lblGenotypeFile.AutoSize = False
		Me.lblGenotypeFile.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblGenotypeFile.Name = "lblGenotypeFile"
		Me.lblRawDataFile.Text = "Raw data file"
		Me.lblRawDataFile.Size = New System.Drawing.Size(225, 17)
		Me.lblRawDataFile.Location = New System.Drawing.Point(8, 288)
		Me.lblRawDataFile.TabIndex = 5
		Me.lblRawDataFile.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRawDataFile.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblRawDataFile.BackColor = System.Drawing.SystemColors.Control
		Me.lblRawDataFile.Enabled = True
		Me.lblRawDataFile.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblRawDataFile.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblRawDataFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblRawDataFile.UseMnemonic = True
		Me.lblRawDataFile.Visible = True
		Me.lblRawDataFile.AutoSize = False
		Me.lblRawDataFile.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblRawDataFile.Name = "lblRawDataFile"
		Me.Controls.Add(framePlateListOptions)
		Me.Controls.Add(TreeViewPlates)
		Me.Controls.Add(btnPlateSearch)
		Me.Controls.Add(txtPlateSearch)
		Me.Controls.Add(btnSearchAssay)
		Me.Controls.Add(txtAssaySearch)
		Me.Controls.Add(lstAssays)
		Me.Controls.Add(btnCancel)
		Me.Controls.Add(btnGenotypeBrowse)
		Me.Controls.Add(txtGeotypeFileName)
		Me.Controls.Add(btnOK)
		Me.Controls.Add(btnRawDataBrowse)
		Me.Controls.Add(txtDataFileName)
		Me.Controls.Add(lblPlateName)
		Me.Controls.Add(lblAssay)
		Me.Controls.Add(lblGenotypeFile)
		Me.Controls.Add(lblRawDataFile)
		Me.framePlateListOptions.Controls.Add(optShowAll)
		Me.framePlateListOptions.Controls.Add(optShowOnlyEmpty)
		Me.lstAssays.Columns.Add(_lstAssays_ColumnHeader_1)
		Me.framePlateListOptions.ResumeLayout(False)
		Me.lstAssays.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class