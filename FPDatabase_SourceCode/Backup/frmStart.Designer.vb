<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmStart
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
	Public WithEvents btnDeletion As System.Windows.Forms.Button
	Public WithEvents btnViewPlate As System.Windows.Forms.Button
	Public WithEvents btnPlateSchemeLoadOrder As System.Windows.Forms.Button
	Public WithEvents btnCreatePlateScheme As System.Windows.Forms.Button
	Public WithEvents CreatePlateButton As System.Windows.Forms.Button
	Public WithEvents QuitButton As System.Windows.Forms.Button
	Public WithEvents UploadButton As System.Windows.Forms.Button
	Public WithEvents ViewButton As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStart))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.btnDeletion = New System.Windows.Forms.Button
		Me.btnViewPlate = New System.Windows.Forms.Button
		Me.btnPlateSchemeLoadOrder = New System.Windows.Forms.Button
		Me.btnCreatePlateScheme = New System.Windows.Forms.Button
		Me.CreatePlateButton = New System.Windows.Forms.Button
		Me.QuitButton = New System.Windows.Forms.Button
		Me.UploadButton = New System.Windows.Forms.Button
		Me.ViewButton = New System.Windows.Forms.Button
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "FP data handler"
		Me.ClientSize = New System.Drawing.Size(157, 399)
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
		Me.Name = "frmStart"
		Me.btnDeletion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnDeletion.Text = "Delete"
		Me.btnDeletion.Size = New System.Drawing.Size(121, 33)
		Me.btnDeletion.Location = New System.Drawing.Point(16, 280)
		Me.btnDeletion.TabIndex = 7
		Me.btnDeletion.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnDeletion.BackColor = System.Drawing.SystemColors.Control
		Me.btnDeletion.CausesValidation = True
		Me.btnDeletion.Enabled = True
		Me.btnDeletion.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnDeletion.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnDeletion.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnDeletion.TabStop = True
		Me.btnDeletion.Name = "btnDeletion"
		Me.btnViewPlate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnViewPlate.Text = "View Plate"
		Me.btnViewPlate.Size = New System.Drawing.Size(121, 33)
		Me.btnViewPlate.Location = New System.Drawing.Point(16, 240)
		Me.btnViewPlate.TabIndex = 6
		Me.btnViewPlate.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnViewPlate.BackColor = System.Drawing.SystemColors.Control
		Me.btnViewPlate.CausesValidation = True
		Me.btnViewPlate.Enabled = True
		Me.btnViewPlate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnViewPlate.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnViewPlate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnViewPlate.TabStop = True
		Me.btnViewPlate.Name = "btnViewPlate"
		Me.btnPlateSchemeLoadOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnPlateSchemeLoadOrder.Text = "Create Platescheme Loadorder"
		Me.btnPlateSchemeLoadOrder.Size = New System.Drawing.Size(121, 33)
		Me.btnPlateSchemeLoadOrder.Location = New System.Drawing.Point(16, 200)
		Me.btnPlateSchemeLoadOrder.TabIndex = 5
		Me.btnPlateSchemeLoadOrder.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnPlateSchemeLoadOrder.BackColor = System.Drawing.SystemColors.Control
		Me.btnPlateSchemeLoadOrder.CausesValidation = True
		Me.btnPlateSchemeLoadOrder.Enabled = True
		Me.btnPlateSchemeLoadOrder.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnPlateSchemeLoadOrder.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnPlateSchemeLoadOrder.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnPlateSchemeLoadOrder.TabStop = True
		Me.btnPlateSchemeLoadOrder.Name = "btnPlateSchemeLoadOrder"
		Me.btnCreatePlateScheme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnCreatePlateScheme.Text = "Create Plate Scheme"
		Me.btnCreatePlateScheme.Size = New System.Drawing.Size(121, 33)
		Me.btnCreatePlateScheme.Location = New System.Drawing.Point(16, 160)
		Me.btnCreatePlateScheme.TabIndex = 4
		Me.btnCreatePlateScheme.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCreatePlateScheme.BackColor = System.Drawing.SystemColors.Control
		Me.btnCreatePlateScheme.CausesValidation = True
		Me.btnCreatePlateScheme.Enabled = True
		Me.btnCreatePlateScheme.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnCreatePlateScheme.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnCreatePlateScheme.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnCreatePlateScheme.TabStop = True
		Me.btnCreatePlateScheme.Name = "btnCreatePlateScheme"
		Me.CreatePlateButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CreatePlateButton.Text = "Create Plate"
		Me.CreatePlateButton.Size = New System.Drawing.Size(121, 33)
		Me.CreatePlateButton.Location = New System.Drawing.Point(16, 120)
		Me.CreatePlateButton.TabIndex = 3
		Me.CreatePlateButton.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CreatePlateButton.BackColor = System.Drawing.SystemColors.Control
		Me.CreatePlateButton.CausesValidation = True
		Me.CreatePlateButton.Enabled = True
		Me.CreatePlateButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CreatePlateButton.Cursor = System.Windows.Forms.Cursors.Default
		Me.CreatePlateButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CreatePlateButton.TabStop = True
		Me.CreatePlateButton.Name = "CreatePlateButton"
		Me.QuitButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.QuitButton.Text = "Quit"
		Me.QuitButton.Size = New System.Drawing.Size(121, 33)
		Me.QuitButton.Location = New System.Drawing.Point(16, 344)
		Me.QuitButton.TabIndex = 2
		Me.QuitButton.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.QuitButton.BackColor = System.Drawing.SystemColors.Control
		Me.QuitButton.CausesValidation = True
		Me.QuitButton.Enabled = True
		Me.QuitButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.QuitButton.Cursor = System.Windows.Forms.Cursors.Default
		Me.QuitButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.QuitButton.TabStop = True
		Me.QuitButton.Name = "QuitButton"
		Me.UploadButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.UploadButton.Text = "Upload Data"
		Me.UploadButton.Size = New System.Drawing.Size(121, 33)
		Me.UploadButton.Location = New System.Drawing.Point(16, 56)
		Me.UploadButton.TabIndex = 1
		Me.UploadButton.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.UploadButton.BackColor = System.Drawing.SystemColors.Control
		Me.UploadButton.CausesValidation = True
		Me.UploadButton.Enabled = True
		Me.UploadButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.UploadButton.Cursor = System.Windows.Forms.Cursors.Default
		Me.UploadButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.UploadButton.TabStop = True
		Me.UploadButton.Name = "UploadButton"
		Me.ViewButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.ViewButton.Text = "View Data"
		Me.ViewButton.Size = New System.Drawing.Size(121, 33)
		Me.ViewButton.Location = New System.Drawing.Point(16, 16)
		Me.ViewButton.TabIndex = 0
		Me.ViewButton.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ViewButton.BackColor = System.Drawing.SystemColors.Control
		Me.ViewButton.CausesValidation = True
		Me.ViewButton.Enabled = True
		Me.ViewButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ViewButton.Cursor = System.Windows.Forms.Cursors.Default
		Me.ViewButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ViewButton.TabStop = True
		Me.ViewButton.Name = "ViewButton"
		Me.Controls.Add(btnDeletion)
		Me.Controls.Add(btnViewPlate)
		Me.Controls.Add(btnPlateSchemeLoadOrder)
		Me.Controls.Add(btnCreatePlateScheme)
		Me.Controls.Add(CreatePlateButton)
		Me.Controls.Add(QuitButton)
		Me.Controls.Add(UploadButton)
		Me.Controls.Add(ViewButton)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class