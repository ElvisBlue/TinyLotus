<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFileExplorer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TmFileExplorer = New System.Windows.Forms.Timer(Me.components)
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DownloadFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CreateFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExecuteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrystalClearThemeContainer1 = New Server.CrystalClearThemeContainer()
        Me.CrystalClearTabControl1 = New Server.CrystalClearTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.cmdGo = New Server.CrystalClearButton()
        Me.cbDriveList = New System.Windows.Forms.ComboBox()
        Me.lvFileExplorer = New System.Windows.Forms.ListView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CrystalClearTabControl2 = New Server.CrystalClearTabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lvDownload = New System.Windows.Forms.ListView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lvUpload = New System.Windows.Forms.ListView()
        Me.cmdExit = New Server.CrystalClearButton()
        Me.ctxMenu.SuspendLayout()
        Me.CrystalClearThemeContainer1.SuspendLayout()
        Me.CrystalClearTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.CrystalClearTabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TmFileExplorer
        '
        Me.TmFileExplorer.Enabled = True
        Me.TmFileExplorer.Interval = 500
        '
        'ctxMenu
        '
        Me.ctxMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.ToolStripSeparator1, Me.DownloadFileToolStripMenuItem, Me.UploadFileToolStripMenuItem, Me.ToolStripSeparator2, Me.RenameToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator4, Me.CreateFolderToolStripMenuItem, Me.ToolStripSeparator3, Me.ExecuteToolStripMenuItem})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(150, 182)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(146, 6)
        '
        'DownloadFileToolStripMenuItem
        '
        Me.DownloadFileToolStripMenuItem.Name = "DownloadFileToolStripMenuItem"
        Me.DownloadFileToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.DownloadFileToolStripMenuItem.Text = "Download File"
        '
        'UploadFileToolStripMenuItem
        '
        Me.UploadFileToolStripMenuItem.Name = "UploadFileToolStripMenuItem"
        Me.UploadFileToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.UploadFileToolStripMenuItem.Text = "Upload File"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(146, 6)
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(146, 6)
        '
        'CreateFolderToolStripMenuItem
        '
        Me.CreateFolderToolStripMenuItem.Name = "CreateFolderToolStripMenuItem"
        Me.CreateFolderToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.CreateFolderToolStripMenuItem.Text = "Create Folder"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(146, 6)
        '
        'ExecuteToolStripMenuItem
        '
        Me.ExecuteToolStripMenuItem.Name = "ExecuteToolStripMenuItem"
        Me.ExecuteToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ExecuteToolStripMenuItem.Text = "Execute"
        '
        'CrystalClearThemeContainer1
        '
        Me.CrystalClearThemeContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.CrystalClearThemeContainer1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.CrystalClearThemeContainer1.Controls.Add(Me.CrystalClearTabControl1)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdExit)
        Me.CrystalClearThemeContainer1.Customization = "5ubm/9LS0v/m5ub/5ubm/6qqqv8="
        Me.CrystalClearThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalClearThemeContainer1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.CrystalClearThemeContainer1.Image = Nothing
        Me.CrystalClearThemeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalClearThemeContainer1.MinimumSize = New System.Drawing.Size(175, 150)
        Me.CrystalClearThemeContainer1.Movable = True
        Me.CrystalClearThemeContainer1.Name = "CrystalClearThemeContainer1"
        Me.CrystalClearThemeContainer1.NoRounding = False
        Me.CrystalClearThemeContainer1.Rounding = Server.CrystalClearThemeContainer.RoundingType.None
        Me.CrystalClearThemeContainer1.Sizable = False
        Me.CrystalClearThemeContainer1.Size = New System.Drawing.Size(751, 426)
        Me.CrystalClearThemeContainer1.SmartBounds = True
        Me.CrystalClearThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.CrystalClearThemeContainer1.TabIndex = 0
        Me.CrystalClearThemeContainer1.Text = "CrystalClearThemeContainer1"
        Me.CrystalClearThemeContainer1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.CrystalClearThemeContainer1.Transparent = False
        '
        'CrystalClearTabControl1
        '
        Me.CrystalClearTabControl1.Controls.Add(Me.TabPage1)
        Me.CrystalClearTabControl1.Controls.Add(Me.TabPage2)
        Me.CrystalClearTabControl1.Location = New System.Drawing.Point(0, 32)
        Me.CrystalClearTabControl1.Name = "CrystalClearTabControl1"
        Me.CrystalClearTabControl1.SelectedIndex = 0
        Me.CrystalClearTabControl1.Size = New System.Drawing.Size(744, 392)
        Me.CrystalClearTabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.txtPath)
        Me.TabPage1.Controls.Add(Me.cmdGo)
        Me.TabPage1.Controls.Add(Me.cbDriveList)
        Me.TabPage1.Controls.Add(Me.lvFileExplorer)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(736, 363)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "File Explorer"
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPath.Location = New System.Drawing.Point(72, 10)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(608, 20)
        Me.txtPath.TabIndex = 5
        '
        'cmdGo
        '
        Me.cmdGo.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdGo.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdGo.Image = Nothing
        Me.cmdGo.Location = New System.Drawing.Point(688, 8)
        Me.cmdGo.Name = "cmdGo"
        Me.cmdGo.NoRounding = False
        Me.cmdGo.Size = New System.Drawing.Size(40, 25)
        Me.cmdGo.TabIndex = 4
        Me.cmdGo.Text = "Go"
        Me.cmdGo.Transparent = False
        '
        'cbDriveList
        '
        Me.cbDriveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDriveList.FormattingEnabled = True
        Me.cbDriveList.Location = New System.Drawing.Point(8, 8)
        Me.cbDriveList.Name = "cbDriveList"
        Me.cbDriveList.Size = New System.Drawing.Size(56, 21)
        Me.cbDriveList.TabIndex = 2
        '
        'lvFileExplorer
        '
        Me.lvFileExplorer.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.lvFileExplorer.HideSelection = False
        Me.lvFileExplorer.Location = New System.Drawing.Point(8, 40)
        Me.lvFileExplorer.Name = "lvFileExplorer"
        Me.lvFileExplorer.Size = New System.Drawing.Size(720, 320)
        Me.lvFileExplorer.TabIndex = 1
        Me.lvFileExplorer.UseCompatibleStateImageBehavior = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.CrystalClearTabControl2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(736, 363)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "File Transfer"
        '
        'CrystalClearTabControl2
        '
        Me.CrystalClearTabControl2.Controls.Add(Me.TabPage3)
        Me.CrystalClearTabControl2.Controls.Add(Me.TabPage4)
        Me.CrystalClearTabControl2.Location = New System.Drawing.Point(0, 0)
        Me.CrystalClearTabControl2.Name = "CrystalClearTabControl2"
        Me.CrystalClearTabControl2.SelectedIndex = 0
        Me.CrystalClearTabControl2.Size = New System.Drawing.Size(736, 360)
        Me.CrystalClearTabControl2.TabIndex = 4
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.lvDownload)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(728, 331)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Download"
        '
        'lvDownload
        '
        Me.lvDownload.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.lvDownload.HideSelection = False
        Me.lvDownload.Location = New System.Drawing.Point(0, 0)
        Me.lvDownload.Name = "lvDownload"
        Me.lvDownload.Size = New System.Drawing.Size(728, 328)
        Me.lvDownload.TabIndex = 3
        Me.lvDownload.UseCompatibleStateImageBehavior = False
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.lvUpload)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(728, 331)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Upload"
        '
        'lvUpload
        '
        Me.lvUpload.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.lvUpload.HideSelection = False
        Me.lvUpload.Location = New System.Drawing.Point(0, 0)
        Me.lvUpload.Name = "lvUpload"
        Me.lvUpload.Size = New System.Drawing.Size(728, 328)
        Me.lvUpload.TabIndex = 4
        Me.lvUpload.UseCompatibleStateImageBehavior = False
        '
        'cmdExit
        '
        Me.cmdExit.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdExit.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdExit.Image = Nothing
        Me.cmdExit.Location = New System.Drawing.Point(716, 3)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.NoRounding = False
        Me.cmdExit.Size = New System.Drawing.Size(32, 20)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "X"
        Me.cmdExit.Transparent = False
        '
        'frmFileExplorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 426)
        Me.Controls.Add(Me.CrystalClearThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(175, 150)
        Me.Name = "frmFileExplorer"
        Me.Text = "File Manager"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ctxMenu.ResumeLayout(False)
        Me.CrystalClearThemeContainer1.ResumeLayout(False)
        Me.CrystalClearTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.CrystalClearTabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalClearThemeContainer1 As Server.CrystalClearThemeContainer
    Friend WithEvents CrystalClearTabControl1 As Server.CrystalClearTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cmdExit As Server.CrystalClearButton
    Friend WithEvents lvFileExplorer As System.Windows.Forms.ListView
    Friend WithEvents cmdGo As Server.CrystalClearButton
    Friend WithEvents cbDriveList As System.Windows.Forms.ComboBox
    Friend WithEvents TmFileExplorer As System.Windows.Forms.Timer
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DownloadFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RenameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CreateFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExecuteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrystalClearTabControl2 As Server.CrystalClearTabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lvDownload As System.Windows.Forms.ListView
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents lvUpload As ListView
End Class
