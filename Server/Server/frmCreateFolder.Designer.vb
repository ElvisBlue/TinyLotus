<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateFolder
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
        Me.cmdRename = New Server.CrystalClearButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New Server.CrystalClearTextBox()
        Me.CrystalClearThemeContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrystalClearThemeContainer1
        '
        Me.CrystalClearThemeContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.CrystalClearThemeContainer1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdCancel)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.cmdRename)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.Label1)
        Me.CrystalClearThemeContainer1.Controls.Add(Me.txtName)
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
        Me.CrystalClearThemeContainer1.Size = New System.Drawing.Size(322, 150)
        Me.CrystalClearThemeContainer1.SmartBounds = True
        Me.CrystalClearThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
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
        Me.cmdCancel.Location = New System.Drawing.Point(216, 104)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.NoRounding = False
        Me.cmdCancel.Size = New System.Drawing.Size(80, 25)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.Transparent = False
        '
        'cmdRename
        '
        Me.cmdRename.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdRename.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdRename.Image = Nothing
        Me.cmdRename.Location = New System.Drawing.Point(32, 104)
        Me.cmdRename.Name = "cmdRename"
        Me.cmdRename.NoRounding = False
        Me.cmdRename.Size = New System.Drawing.Size(80, 25)
        Me.cmdRename.TabIndex = 6
        Me.cmdRename.Text = "Create"
        Me.cmdRename.Transparent = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Folder name:"
        '
        'txtName
        '
        Me.txtName.Customization = "AAAA//Dw8P+qqqr/"
        Me.txtName.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtName.Image = Nothing
        Me.txtName.Location = New System.Drawing.Point(96, 48)
        Me.txtName.MaxLength = 32767
        Me.txtName.Multiline = False
        Me.txtName.Name = "txtName"
        Me.txtName.NoRounding = False
        Me.txtName.ReadOnly = False
        Me.txtName.Size = New System.Drawing.Size(216, 24)
        Me.txtName.TabIndex = 4
        Me.txtName.Text = "New Folder"
        Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtName.Transparent = False
        Me.txtName.UseSystemPasswordChar = False
        '
        'frmCreateFolder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 150)
        Me.Controls.Add(Me.CrystalClearThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(175, 150)
        Me.Name = "frmCreateFolder"
        Me.Text = "Create new folder"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.CrystalClearThemeContainer1.ResumeLayout(False)
        Me.CrystalClearThemeContainer1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalClearThemeContainer1 As Server.CrystalClearThemeContainer
    Friend WithEvents cmdCancel As Server.CrystalClearButton
    Friend WithEvents cmdRename As Server.CrystalClearButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As Server.CrystalClearTextBox
End Class
