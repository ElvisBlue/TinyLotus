Imports System.IO
Imports System.Threading

Public Class frmScreenshot
    Public ScreenshotObj As clsScreenshot
    Private Delegate Sub SafeUpdateImageLv()

    Private triedCnt
    Private Sub cmdTakeScreen_Click(sender As Object, e As EventArgs) Handles cmdTakeScreen.Click
        ScreenshotObj.SendTakeScreenshot()
        UpdateImgLv()
    End Sub

    Private Sub UpdateImgLv()
        tmSync.Enabled = True
    End Sub

    Private Sub frmScreenshot_Load(sender As Object, e As EventArgs) Handles Me.Load
        lvImage.Items.Clear()
        UpdateImgLv()
    End Sub

    Private Sub lvImage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvImage.SelectedIndexChanged
        Dim selected As String = lvImage.SelectedItem
        If selected <> Nothing Then
            Dim screenshotPath As String = ScreenshotObj.GetScreenshotPath()
            picScreenshot.Image = Image.FromFile(screenshotPath + selected)
        End If
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        picScreenshot.Image = Nothing
        Me.Close()
    End Sub

    Private Sub tmSync_Tick(sender As Object, e As EventArgs) Handles tmSync.Tick
        Dim currentItem As Integer = lvImage.Items.Count
        Dim screenshotPath As String = ScreenshotObj.GetScreenshotPath()

        If (Not Directory.Exists(screenshotPath)) Then
            Directory.CreateDirectory(screenshotPath)
            tmSync.Enabled = False
            Return
        End If

        Dim files() As String = IO.Directory.GetFiles(screenshotPath)
        If files.Count <> currentItem Then
            lvImage.Items.Clear()
            For Each file As String In files
                lvImage.Items.Add(Utilities.TrimPath(file))
            Next
            tmSync.Enabled = False
            Return
        End If

<<<<<<< HEAD
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If lvImage.SelectedItem <> Nothing Then
            Dim imagePath As String = ScreenshotObj.GetScreenshotPath() + lvImage.SelectedItem
            Process.Start(imagePath)
        End If
    End Sub

    Private Sub lvImage_MouseDown(sender As Object, e As MouseEventArgs) Handles lvImage.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim index As Integer = lvImage.IndexFromPoint(e.Location)
            If index <> -1 Then
                ctxMenu.Show(lvImage, e.Location)
            End If
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If picScreenshot.Image IsNot Nothing Then
            picScreenshot.Image.Dispose()
            picScreenshot.Image = Nothing
        End If
        If lvImage.SelectedItem <> Nothing Then
            Dim imagePath As String = ScreenshotObj.GetScreenshotPath() + lvImage.SelectedItem
            Try
                My.Computer.FileSystem.DeleteFile(imagePath)
            Catch
                MsgBox("Error while trying to delete image", MsgBoxStyle.Critical, "Error")
            End Try
            UpdateImgLv()
        End If
    End Sub

    Private Sub OpenFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFolderToolStripMenuItem.Click
        If lvImage.SelectedItem <> Nothing Then
            Process.Start(ScreenshotObj.GetScreenshotPath())
        End If
=======
>>>>>>> 72ca2dcff8bcde993befda3e9ef5d72328f953b3
    End Sub
End Class