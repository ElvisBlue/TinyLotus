Imports System.IO

Public Class frmKeylogger
    Public KeyloggerObj As clsKeylogger

    Private Sub cmdGetLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateLog.Click
        KeyloggerObj.GetLog()
        Threading.Thread.Sleep(1000)
        GetLogFileToTreeView()
    End Sub

    Private Sub GetLogFileToTreeView()
        Dim keylogPath As String = KeyloggerObj.GetKeylogPath()

        tvLog.Nodes.Clear()

        If (Not Directory.Exists(keylogPath)) Then
            Directory.CreateDirectory(keylogPath)
            Return
        End If

        Dim files() As String = IO.Directory.GetFiles(keylogPath)
        For Each file As String In files
            AddToTreeView(Utilities.TrimPath(file))
        Next
    End Sub

    Private Sub AddToTreeView(ByVal Item As String)
        Dim root = New TreeNode(Item)
        tvLog.Nodes.Add(root)
    End Sub

    Private Sub tvLog_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvLog.AfterSelect
        Dim fileName As String = tvLog.SelectedNode.Text
        Dim keylogPath As String = KeyloggerObj.GetKeylogPath
        txtlog.Text = File.ReadAllText(keylogPath & fileName)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub tvLog_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvLog.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Try
                If tvLog.SelectedNode.Bounds.Contains(e.Location) Then
                    ctxmenu.Show(tvLog, e.Location)
                End If
            Catch
                Return
            End Try
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim fileName As String = tvLog.SelectedNode.Text
        Dim keylogPath As String = KeyloggerObj.GetKeylogPath

        My.Computer.FileSystem.DeleteFile(keylogPath & fileName)
        GetLogFileToTreeView()
    End Sub

    Private Sub cmdOpenLogFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenLogFolder.Click
        Process.Start(KeyloggerObj.GetKeylogPath)
    End Sub

    Private Sub frmKeylogger_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetLogFileToTreeView()
    End Sub
End Class