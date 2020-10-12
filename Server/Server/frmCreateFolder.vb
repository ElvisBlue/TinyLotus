Public Class frmCreateFolder
    Public fileExplorerObj As clsFileExplorer = Nothing
    Public path As String

    Private Sub frmCreateFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtName.Text = "New Folder"
    End Sub

    Private Sub cmdRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRename.Click
        If Name = "" Then
            MsgBox("Name can not be blank", vbCritical, "Error")
            Exit Sub
        End If

        If fileExplorerObj Is Nothing Then
            Exit Sub
        End If

        fileExplorerObj.SendCreateDirectory(path + txtName.Text)
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class