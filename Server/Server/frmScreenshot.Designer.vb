<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScreenshot
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
        Me.CrystalClearThemeContainer1 = New Server.CrystalClearThemeContainer()
        Me.lvImage = New Server.CrystalClearListbox()
        Me.cmdExit = New Server.CrystalClearButton()
        Me.cmdTakeScreen = New Server.CrystalClearButton()
        Me.picScreenshot = New System.Windows.Forms.PictureBox()
        Me.tmSync = New System.Windows.Forms.Timer(Me.components)
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrystalClearThemeContainer1.SuspendLayout()
        CType(Me.picScreenshot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrystalClearThemeContainer1
        '
        Me.CrystalClearThemeContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.CrystalClearThemeContainer1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.CrystalClearThemeContainer1.Controls.Add(Me.lvImage)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdExit)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdTakeScreen)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.picScreenshot)
        Me.CrystalClearThemeContainer1.Customization = "5ubm/9LS0v/m5ub/5ubm/6qqqv8="
        Me.CrystalClearThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalClearThemeContainer1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.CrystalClearThemeContainer1.Image = Nothing
        Me.CrystalClearThemeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalClearThemeContainer1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CrystalClearThemeContainer1.MinimumSize = New System.Drawing.Size(175, 150)
        Me.CrystalClearThemeContainer1.Movable = True
        Me.CrystalClearThemeContainer1.Name = "CrystalClearThemeContainer1"
        Me.CrystalClearThemeContainer1.NoRounding = False
        Me.CrystalClearThemeContainer1.Rounding = Server.CrystalClearThemeContainer.RoundingType.None
        Me.CrystalClearThemeContainer1.Sizable = False
        Me.CrystalClearThemeContainer1.Size = New System.Drawing.Size(1296, 753)
        Me.CrystalClearThemeContainer1.SmartBounds = True
        Me.CrystalClearThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.CrystalClearThemeContainer1.TabIndex = 0
        Me.CrystalClearThemeContainer1.Text = "CrystalClearThemeContainer1"
        Me.CrystalClearThemeContainer1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.CrystalClearThemeContainer1.Transparent = False
        '
        'lvImage
        '
        Me.lvImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.lvImage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvImage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lvImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lvImage.ForeColor = System.Drawing.Color.Black
        Me.lvImage.FormattingEnabled = True
        Me.lvImage.IntegralHeight = False
        Me.lvImage.ItemHeight = 21
        Me.lvImage.ItemImage = Nothing
        Me.lvImage.Location = New System.Drawing.Point(0, 33)
        Me.lvImage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lvImage.Name = "lvImage"
        Me.lvImage.Size = New System.Drawing.Size(308, 674)
        Me.lvImage.TabIndex = 4
        '
        'cmdExit
        '
        Me.cmdExit.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdExit.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdExit.Image = Nothing
        Me.cmdExit.Location = New System.Drawing.Point(1249, 2)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.NoRounding = False
        Me.cmdExit.Size = New System.Drawing.Size(43, 25)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "X"
        Me.cmdExit.Transparent = False
        '
        'cmdTakeScreen
        '
        Me.cmdTakeScreen.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdTakeScreen.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdTakeScreen.Image = Nothing
        Me.cmdTakeScreen.Location = New System.Drawing.Point(537, 713)
        Me.cmdTakeScreen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdTakeScreen.Name = "cmdTakeScreen"
        Me.cmdTakeScreen.NoRounding = False
        Me.cmdTakeScreen.Size = New System.Drawing.Size(189, 27)
        Me.cmdTakeScreen.TabIndex = 1
        Me.cmdTakeScreen.Text = "Take Screenshot"
        Me.cmdTakeScreen.Transparent = False
        '
        'picScreenshot
        '
        Me.picScreenshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picScreenshot.Location = New System.Drawing.Point(313, 33)
        Me.picScreenshot.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.picScreenshot.Name = "picScreenshot"
        Me.picScreenshot.Size = New System.Drawing.Size(979, 674)
        Me.picScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picScreenshot.TabIndex = 0
        Me.picScreenshot.TabStop = False
        '
        'tmSync
        '
        Me.tmSync.Interval = 1000
<<<<<<< HEAD
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.OpenFolderToolStripMenuItem})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(181, 92)
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'OpenFolderToolStripMenuItem
        '
        Me.OpenFolderToolStripMenuItem.Name = "OpenFolderToolStripMenuItem"
        Me.OpenFolderToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.OpenFolderToolStripMenuItem.Text = "Open Folder"
=======
>>>>>>> 72ca2dcff8bcde993befda3e9ef5d72328f953b3
        '
        'frmScreenshot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1296, 753)
        Me.Controls.Add(Me.CrystalClearThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
<<<<<<< HEAD
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(131, 122)
=======
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MinimumSize = New System.Drawing.Size(175, 150)
>>>>>>> 72ca2dcff8bcde993befda3e9ef5d72328f953b3
        Me.Name = "frmScreenshot"
        Me.Text = "Screenshot"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.CrystalClearThemeContainer1.ResumeLayout(False)
        CType(Me.picScreenshot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CrystalClearThemeContainer1 As CrystalClearThemeContainer
    Friend WithEvents cmdTakeScreen As CrystalClearButton
    Friend WithEvents picScreenshot As PictureBox
    Friend WithEvents cmdExit As CrystalClearButton
    Friend WithEvents lvImage As CrystalClearListbox
    Friend WithEvents tmSync As Timer
    Friend WithEvents ctxMenu As ContextMenuStrip
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFolderToolStripMenuItem As ToolStripMenuItem
End Class
