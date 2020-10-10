<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmmain
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
        Me.tmThread = New System.Windows.Forms.Timer(Me.components)
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoteCMDToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileExplorerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SurveillanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeyloggerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PluginsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrystalClearThemeContainer1 = New Server.CrystalClearThemeContainer()
        Me.cmdExit = New Server.CrystalClearButton()
        Me.CrystalClearTabControl1 = New Server.CrystalClearTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lvClient = New System.Windows.Forms.ListView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.cmdListen = New Server.CrystalClearButton()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.ctxMenu.SuspendLayout()
        Me.CrystalClearThemeContainer1.SuspendLayout()
        Me.CrystalClearTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmThread
        '
        Me.tmThread.Interval = 1000
        '
        'ctxMenu
        '
        Me.ctxMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.SurveillanceToolStripMenuItem, Me.PluginsToolStripMenuItem})
        Me.ctxMenu.Name = "ContextMenuStrip1"
        Me.ctxMenu.Size = New System.Drawing.Size(138, 70)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoteCMDToolStripMenuItem1, Me.FileExplorerToolStripMenuItem1})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(137, 22)
        Me.ToolStripMenuItem1.Text = "System"
        '
        'RemoteCMDToolStripMenuItem1
        '
        Me.RemoteCMDToolStripMenuItem1.Name = "RemoteCMDToolStripMenuItem1"
        Me.RemoteCMDToolStripMenuItem1.Size = New System.Drawing.Size(145, 22)
        Me.RemoteCMDToolStripMenuItem1.Text = "Remote CMD"
        '
        'FileExplorerToolStripMenuItem1
        '
        Me.FileExplorerToolStripMenuItem1.Name = "FileExplorerToolStripMenuItem1"
        Me.FileExplorerToolStripMenuItem1.Size = New System.Drawing.Size(145, 22)
        Me.FileExplorerToolStripMenuItem1.Text = "File Explorer"
        '
        'SurveillanceToolStripMenuItem
        '
        Me.SurveillanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KeyloggerToolStripMenuItem1})
        Me.SurveillanceToolStripMenuItem.Name = "SurveillanceToolStripMenuItem"
        Me.SurveillanceToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.SurveillanceToolStripMenuItem.Text = "Surveillance"
        '
        'KeyloggerToolStripMenuItem1
        '
        Me.KeyloggerToolStripMenuItem1.Name = "KeyloggerToolStripMenuItem1"
        Me.KeyloggerToolStripMenuItem1.Size = New System.Drawing.Size(127, 22)
        Me.KeyloggerToolStripMenuItem1.Text = "Keylogger"
        '
        'PluginsToolStripMenuItem
        '
        Me.PluginsToolStripMenuItem.Name = "PluginsToolStripMenuItem"
        Me.PluginsToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.PluginsToolStripMenuItem.Text = "Plugins"
        '
        'CrystalClearThemeContainer1
        '
        Me.CrystalClearThemeContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.CrystalClearThemeContainer1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdExit)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.CrystalClearTabControl1)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdListen)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.lbStatus)
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
        Me.CrystalClearThemeContainer1.Size = New System.Drawing.Size(971, 494)
        Me.CrystalClearThemeContainer1.SmartBounds = True
        Me.CrystalClearThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.CrystalClearThemeContainer1.TabIndex = 0
        Me.CrystalClearThemeContainer1.Text = "CrystalClearThemeContainer1"
        Me.CrystalClearThemeContainer1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.CrystalClearThemeContainer1.Transparent = False
        '
        'cmdExit
        '
        Me.cmdExit.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdExit.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdExit.Image = Nothing
        Me.cmdExit.Location = New System.Drawing.Point(936, 2)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.NoRounding = False
        Me.cmdExit.Size = New System.Drawing.Size(32, 20)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "X"
        Me.cmdExit.Transparent = False
        '
        'CrystalClearTabControl1
        '
        Me.CrystalClearTabControl1.Controls.Add(Me.TabPage1)
        Me.CrystalClearTabControl1.Controls.Add(Me.TabPage2)
        Me.CrystalClearTabControl1.Controls.Add(Me.TabPage3)
        Me.CrystalClearTabControl1.Controls.Add(Me.TabPage4)
        Me.CrystalClearTabControl1.Controls.Add(Me.TabPage5)
        Me.CrystalClearTabControl1.Location = New System.Drawing.Point(0, 32)
        Me.CrystalClearTabControl1.Name = "CrystalClearTabControl1"
        Me.CrystalClearTabControl1.SelectedIndex = 0
        Me.CrystalClearTabControl1.Size = New System.Drawing.Size(968, 432)
        Me.CrystalClearTabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.lvClient)
        Me.TabPage1.ImageIndex = 2
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(960, 403)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Connection"
        '
        'lvClient
        '
        Me.lvClient.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.lvClient.HideSelection = False
        Me.lvClient.Location = New System.Drawing.Point(0, 0)
        Me.lvClient.Name = "lvClient"
        Me.lvClient.Size = New System.Drawing.Size(968, 400)
        Me.lvClient.TabIndex = 0
        Me.lvClient.UseCompatibleStateImageBehavior = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.TabPage2.ImageIndex = 1
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(960, 403)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Setting"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(960, 403)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Builder"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.txtLog)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(960, 403)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Log"
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.txtLog.Location = New System.Drawing.Point(6, 2)
        Me.txtLog.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.Size = New System.Drawing.Size(954, 401)
        Me.txtLog.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(960, 403)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "About"
        '
        'cmdListen
        '
        Me.cmdListen.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdListen.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdListen.Image = Nothing
        Me.cmdListen.Location = New System.Drawing.Point(184, 472)
        Me.cmdListen.Name = "cmdListen"
        Me.cmdListen.NoRounding = False
        Me.cmdListen.Size = New System.Drawing.Size(48, 16)
        Me.cmdListen.TabIndex = 6
        Me.cmdListen.Text = "Listen"
        Me.cmdListen.Transparent = False
        '
        'lbStatus
        '
        Me.lbStatus.AutoSize = True
        Me.lbStatus.Location = New System.Drawing.Point(4, 473)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(19, 13)
        Me.lbStatus.TabIndex = 5
        Me.lbStatus.Text = "..."
        '
        'frmmain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 494)
        Me.ControlBox = False
        Me.Controls.Add(Me.CrystalClearThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(175, 150)
        Me.Name = "frmmain"
        Me.Text = "Tiny Lotus 0.1"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ctxMenu.ResumeLayout(False)
        Me.CrystalClearThemeContainer1.ResumeLayout(False)
        Me.CrystalClearThemeContainer1.PerformLayout()
        Me.CrystalClearTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalClearTabControl1 As Server.CrystalClearTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lvClient As System.Windows.Forms.ListView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents cmdExit As Server.CrystalClearButton
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents cmdListen As Server.CrystalClearButton
    Friend WithEvents tmThread As System.Windows.Forms.Timer
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoteCMDToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PluginsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileExplorerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SurveillanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeyloggerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrystalClearThemeContainer1 As Server.CrystalClearThemeContainer
    Public WithEvents txtLog As TextBox
End Class
