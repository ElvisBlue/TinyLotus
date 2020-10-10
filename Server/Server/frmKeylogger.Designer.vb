<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeylogger
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
        Me.cmdExit = New Server.CrystalClearButton()
        Me.cmdOpenLogFolder = New Server.CrystalClearButton()
        Me.cmdUpdateLog = New Server.CrystalClearButton()
        Me.txtlog = New System.Windows.Forms.TextBox()
        Me.tvLog = New System.Windows.Forms.TreeView()
        Me.ctxmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrystalClearThemeContainer1.SuspendLayout()
        Me.ctxmenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrystalClearThemeContainer1
        '
        Me.CrystalClearThemeContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.CrystalClearThemeContainer1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdExit)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdOpenLogFolder)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdUpdateLog)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.txtlog)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.tvLog)
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
        Me.CrystalClearThemeContainer1.Size = New System.Drawing.Size(669, 451)
        Me.CrystalClearThemeContainer1.SmartBounds = True
        Me.CrystalClearThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
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
        Me.cmdExit.Location = New System.Drawing.Point(634, 3)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.NoRounding = False
        Me.cmdExit.Size = New System.Drawing.Size(32, 20)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "X"
        Me.cmdExit.Transparent = False
        '
        'cmdOpenLogFolder
        '
        Me.cmdOpenLogFolder.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdOpenLogFolder.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdOpenLogFolder.Image = Nothing
        Me.cmdOpenLogFolder.Location = New System.Drawing.Point(8, 416)
        Me.cmdOpenLogFolder.Name = "cmdOpenLogFolder"
        Me.cmdOpenLogFolder.NoRounding = False
        Me.cmdOpenLogFolder.Size = New System.Drawing.Size(176, 24)
        Me.cmdOpenLogFolder.TabIndex = 3
        Me.cmdOpenLogFolder.Text = "Open Log Folder"
        Me.cmdOpenLogFolder.Transparent = False
        '
        'cmdUpdateLog
        '
        Me.cmdUpdateLog.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdUpdateLog.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdUpdateLog.Image = Nothing
        Me.cmdUpdateLog.Location = New System.Drawing.Point(8, 384)
        Me.cmdUpdateLog.Name = "cmdUpdateLog"
        Me.cmdUpdateLog.NoRounding = False
        Me.cmdUpdateLog.Size = New System.Drawing.Size(176, 24)
        Me.cmdUpdateLog.TabIndex = 2
        Me.cmdUpdateLog.Text = "Update Log"
        Me.cmdUpdateLog.Transparent = False
        '
        'txtlog
        '
        Me.txtlog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtlog.Location = New System.Drawing.Point(192, 32)
        Me.txtlog.Multiline = True
        Me.txtlog.Name = "txtlog"
        Me.txtlog.ReadOnly = True
        Me.txtlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtlog.Size = New System.Drawing.Size(472, 408)
        Me.txtlog.TabIndex = 1
        '
        'tvLog
        '
        Me.tvLog.Location = New System.Drawing.Point(8, 32)
        Me.tvLog.Name = "tvLog"
        Me.tvLog.Size = New System.Drawing.Size(176, 344)
        Me.tvLog.TabIndex = 0
        '
        'ctxmenu
        '
        Me.ctxmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ctxmenu.Name = "ContextMenuStrip1"
        Me.ctxmenu.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'frmKeylogger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 451)
        Me.Controls.Add(Me.CrystalClearThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(175, 150)
        Me.Name = "frmKeylogger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Keylogger"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.CrystalClearThemeContainer1.ResumeLayout(False)
        Me.CrystalClearThemeContainer1.PerformLayout()
        Me.ctxmenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalClearThemeContainer1 As Server.CrystalClearThemeContainer
    Friend WithEvents cmdUpdateLog As Server.CrystalClearButton
    Friend WithEvents txtlog As System.Windows.Forms.TextBox
    Friend WithEvents tvLog As System.Windows.Forms.TreeView
    Friend WithEvents cmdOpenLogFolder As Server.CrystalClearButton
    Friend WithEvents cmdExit As Server.CrystalClearButton
    Friend WithEvents ctxmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
