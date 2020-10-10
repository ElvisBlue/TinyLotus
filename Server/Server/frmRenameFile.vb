Public Class frmRenameFile
    Public path As String = ""
    Public oldName As String = ""
    Public fileExplorerObj As clsFileExplorer = Nothing

    Private Sub cmdRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRename.Click
        If txtName.Text = "" Then
            MsgBox("Name can not be blank", vbCritical, "Error")
            Exit Sub
        End If
        fileExplorerObj.SendRenameFile(path + oldName, path + txtName.Text)
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class