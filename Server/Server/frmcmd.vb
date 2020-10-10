Imports System.Threading

Public Class frmcmd
    Public CmdObj As clsCommand

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        CmdObj.ExitCmd()
        Me.Close()
    End Sub

    Private Sub frmcmd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CmdObj.StartCmd()
        Dim cnt As Integer = 0
        While CmdObj.IsCmdStarted() = False
            Threading.Thread.Sleep(1000)
            cnt += 1
            If cnt = 5 Then
                MsgBox("Can not start remote command", vbCritical, "Error")
                Me.Close()
                Exit While
            End If
        End While
        tmUpdate.Enabled = True
        CmdObj.SendGetText()
        Threading.Thread.Sleep(500)
        txtcmd.Text = CmdObj.GetCmdText
    End Sub

    Private Sub tmUpdate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmUpdate.Tick
        If CmdObj.IsCmdStarted = True Then
            CmdObj.SendGetText()
            Dim tmp As String = Replace(CmdObj.GetCmdText(), vbLf, vbCrLf)
            If tmp = Nothing Then Exit Sub
            If txtcmd.Text <> tmp Then
                txtcmd.Text = ""
                txtcmd.AppendText(tmp)
            End If
        End If
    End Sub

    Private Sub txtentercmd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtentercmd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Trim(txtentercmd.Text) = "cls" Then
                CmdObj.ClearCmd()
            End If
            CmdObj.SendCommand(txtentercmd.Text)
            txtentercmd.Text = ""
        End If
    End Sub
End Class