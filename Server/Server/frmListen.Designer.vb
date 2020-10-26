<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListen
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
        Me.CrystalClearThemeContainer1 = New Server.CrystalClearThemeContainer()
        Me.cmdCancel = New Server.CrystalClearButton()
        Me.cmdStop = New Server.CrystalClearButton()
        Me.cmdListen = New Server.CrystalClearButton()
        Me.txtPort = New Server.CrystalClearTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword = New Server.CrystalClearTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CrystalClearThemeContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrystalClearThemeContainer1
        '
        Me.CrystalClearThemeContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.CrystalClearThemeContainer1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.CrystalClearThemeContainer1.Controls.Add(Me.txtPassword)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.Label2)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdCancel)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdStop)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdListen)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.txtPort)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.Label1)
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
        Me.CrystalClearThemeContainer1.Size = New System.Drawing.Size(301, 181)
        Me.CrystalClearThemeContainer1.SmartBounds = True
        Me.CrystalClearThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.CrystalClearThemeContainer1.TabIndex = 0
        Me.CrystalClearThemeContainer1.Text = "CrystalClearThemeContainer1"
        Me.CrystalClearThemeContainer1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.CrystalClearThemeContainer1.Transparent = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdCancel.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdCancel.Image = Nothing
        Me.cmdCancel.Location = New System.Drawing.Point(216, 144)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.NoRounding = False
        Me.cmdCancel.Size = New System.Drawing.Size(64, 25)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.Transparent = False
        '
        'cmdStop
        '
        Me.cmdStop.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdStop.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdStop.Image = Nothing
        Me.cmdStop.Location = New System.Drawing.Point(120, 144)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.NoRounding = False
        Me.cmdStop.Size = New System.Drawing.Size(64, 25)
        Me.cmdStop.TabIndex = 3
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.Transparent = False
        '
        'cmdListen
        '
        Me.cmdListen.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdListen.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdListen.Image = Nothing
        Me.cmdListen.Location = New System.Drawing.Point(24, 144)
        Me.cmdListen.Name = "cmdListen"
        Me.cmdListen.NoRounding = False
        Me.cmdListen.Size = New System.Drawing.Size(64, 25)
        Me.cmdListen.TabIndex = 2
        Me.cmdListen.Text = "Listen"
        Me.cmdListen.Transparent = False
        '
        'txtPort
        '
        Me.txtPort.Customization = "AAAA//Dw8P+qqqr/"
        Me.txtPort.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPort.Image = Nothing
        Me.txtPort.Location = New System.Drawing.Point(112, 92)
        Me.txtPort.MaxLength = 32767
        Me.txtPort.Multiline = False
        Me.txtPort.Name = "txtPort"
        Me.txtPort.NoRounding = False
        Me.txtPort.ReadOnly = False
        Me.txtPort.Size = New System.Drawing.Size(72, 31)
        Me.txtPort.TabIndex = 1
        Me.txtPort.Text = "6969"
        Me.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPort.Transparent = False
        Me.txtPort.UseSystemPasswordChar = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Port"
        '
        'txtPassword
        '
        Me.txtPassword.Customization = "AAAA//Dw8P+qqqr/"
        Me.txtPassword.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Image = Nothing
        Me.txtPassword.Location = New System.Drawing.Point(112, 46)
        Me.txtPassword.MaxLength = 32767
        Me.txtPassword.Multiline = False
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.NoRounding = False
        Me.txtPassword.ReadOnly = False
        Me.txtPassword.Size = New System.Drawing.Size(168, 31)
        Me.txtPassword.TabIndex = 6
        Me.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPassword.Transparent = False
        Me.txtPassword.UseSystemPasswordChar = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 18)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Password"
        '
        'frmListen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 181)
        Me.Controls.Add(Me.CrystalClearThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(175, 150)
        Me.Name = "frmListen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Listen"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.CrystalClearThemeContainer1.ResumeLayout(False)
        Me.CrystalClearThemeContainer1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalClearThemeContainer1 As Server.CrystalClearThemeContainer
    Friend WithEvents cmdCancel As Server.CrystalClearButton
    Friend WithEvents cmdStop As Server.CrystalClearButton
    Friend WithEvents cmdListen As Server.CrystalClearButton
    Friend WithEvents txtPort As Server.CrystalClearTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As CrystalClearTextBox
    Friend WithEvents Label2 As Label
End Class
