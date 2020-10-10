<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcmd
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
        Me.tmUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.CrystalClearThemeContainer1 = New Server.CrystalClearThemeContainer()
        Me.txtcmd = New System.Windows.Forms.TextBox()
        Me.txtentercmd = New System.Windows.Forms.TextBox()
        Me.cmdExit = New Server.CrystalClearButton()
        Me.CrystalClearThemeContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmUpdate
        '
        Me.tmUpdate.Interval = 500
        '
        'CrystalClearThemeContainer1
        '
        Me.CrystalClearThemeContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.CrystalClearThemeContainer1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.CrystalClearThemeContainer1.Controls.Add(Me.txtcmd)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.txtentercmd)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdExit)
        Me.CrystalClearThemeContainer1.Customization = "5ubm/9LS0v/m5ub/5ubm/6qqqv8="
        Me.CrystalClearThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalClearThemeContainer1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.CrystalClearThemeContainer1.Image = Nothing
        Me.CrystalClearThemeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalClearThemeContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.CrystalClearThemeContainer1.MinimumSize = New System.Drawing.Size(233, 185)
        Me.CrystalClearThemeContainer1.Movable = True
        Me.CrystalClearThemeContainer1.Name = "CrystalClearThemeContainer1"
        Me.CrystalClearThemeContainer1.NoRounding = False
        Me.CrystalClearThemeContainer1.Rounding = Server.CrystalClearThemeContainer.RoundingType.None
        Me.CrystalClearThemeContainer1.Sizable = False
        Me.CrystalClearThemeContainer1.Size = New System.Drawing.Size(919, 498)
        Me.CrystalClearThemeContainer1.SmartBounds = True
        Me.CrystalClearThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.CrystalClearThemeContainer1.TabIndex = 0
        Me.CrystalClearThemeContainer1.Text = "CrystalClearThemeContainer1"
        Me.CrystalClearThemeContainer1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.CrystalClearThemeContainer1.Transparent = False
        '
        'txtcmd
        '
        Me.txtcmd.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.txtcmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcmd.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcmd.ForeColor = System.Drawing.Color.Black
        Me.txtcmd.Location = New System.Drawing.Point(0, 30)
        Me.txtcmd.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcmd.Multiline = True
        Me.txtcmd.Name = "txtcmd"
        Me.txtcmd.ReadOnly = True
        Me.txtcmd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtcmd.Size = New System.Drawing.Size(917, 443)
        Me.txtcmd.TabIndex = 5
        '
        'txtentercmd
        '
        Me.txtentercmd.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.txtentercmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtentercmd.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtentercmd.ForeColor = System.Drawing.Color.Black
        Me.txtentercmd.Location = New System.Drawing.Point(0, 473)
        Me.txtentercmd.Margin = New System.Windows.Forms.Padding(4)
        Me.txtentercmd.Name = "txtentercmd"
        Me.txtentercmd.Size = New System.Drawing.Size(917, 23)
        Me.txtentercmd.TabIndex = 4
        '
        'cmdExit
        '
        Me.cmdExit.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdExit.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdExit.Image = Nothing
        Me.cmdExit.Location = New System.Drawing.Point(871, 2)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.NoRounding = False
        Me.cmdExit.Size = New System.Drawing.Size(43, 25)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "X"
        Me.cmdExit.Transparent = False
        '
        'frmcmd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 498)
        Me.Controls.Add(Me.CrystalClearThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(233, 185)
        Me.Name = "frmcmd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Command"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.CrystalClearThemeContainer1.ResumeLayout(False)
        Me.CrystalClearThemeContainer1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalClearThemeContainer1 As Server.CrystalClearThemeContainer
    Friend WithEvents cmdExit As Server.CrystalClearButton
    Friend WithEvents tmUpdate As System.Windows.Forms.Timer
    Friend WithEvents txtentercmd As System.Windows.Forms.TextBox
    Friend WithEvents txtcmd As System.Windows.Forms.TextBox
End Class
