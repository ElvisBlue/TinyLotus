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
        Dim screenshotPath As String = ScreenshotObj.GetScreenshotPath()
        picScreenshot.Image = Image.FromFile(screenshotPath + selected)
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

    End Sub
End Class