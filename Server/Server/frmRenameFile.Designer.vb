<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRenameFile
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
        Me.CrystalClearThemeContainer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CrystalClearThemeContainer1.MinimumSize = New System.Drawing.Size(233, 185)
        Me.CrystalClearThemeContainer1.Movable = True
        Me.CrystalClearThemeContainer1.Name = "CrystalClearThemeContainer1"
        Me.CrystalClearThemeContainer1.NoRounding = False
        Me.CrystalClearThemeContainer1.Rounding = Server.CrystalClearThemeContainer.RoundingType.None
        Me.CrystalClearThemeContainer1.Sizable = False
        Me.CrystalClearThemeContainer1.Size = New System.Drawing.Size(432, 185)
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
        Me.cmdCancel.Location = New System.Drawing.Point(288, 138)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.NoRounding = False
        Me.cmdCancel.Size = New System.Drawing.Size(107, 31)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.Transparent = False
        '
        'cmdRename
        '
        Me.cmdRename.Customization = "5ubm/9LS0v/m5ub/qqqq/wAAAP//////"
        Me.cmdRename.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmdRename.Image = Nothing
        Me.cmdRename.Location = New System.Drawing.Point(43, 138)
        Me.cmdRename.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdRename.Name = "cmdRename"
        Me.cmdRename.NoRounding = False
        Me.cmdRename.Size = New System.Drawing.Size(107, 31)
        Me.cmdRename.TabIndex = 2
        Me.cmdRename.Text = "Rename"
        Me.cmdRename.Transparent = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 76)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "New name:"
        '
        'txtName
        '
        Me.txtName.Customization = "AAAA//Dw8P+qqqr/"
        Me.txtName.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtName.Image = Nothing
        Me.txtName.Location = New System.Drawing.Point(107, 69)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtName.MaxLength = 32767
        Me.txtName.Multiline = False
        Me.txtName.Name = "txtName"
        Me.txtName.NoRounding = False
        Me.txtName.ReadOnly = False
        Me.txtName.Size = New System.Drawing.Size(309, 28)
        Me.txtName.TabIndex = 0
        Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtName.Transparent = False
        Me.txtName.UseSystemPasswordChar = False
        '
        'frmRenameFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 185)
        Me.Controls.Add(Me.CrystalClearThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MinimumSize = New System.Drawing.Size(233, 185)
        Me.Name = "frmRenameFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rename file"
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
