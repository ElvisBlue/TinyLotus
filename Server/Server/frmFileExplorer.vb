Imports System.IO

Public Class frmFileExplorer
    Public fileExplorerObj As clsFileExplorer = Nothing
    Private bListViewInit As Boolean = False

    Public Sub lv_Init()
        With lvFileExplorer
            .Clear()
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
            .Sorting = SortOrder.Ascending
            .MultiSelect = False
            .HideSelection = False

            'Add column header
            .Columns.Add("Name", 300)
            .Columns.Add("Size", 100)
            .Columns.Add("Type", 50)
            .Columns.Add("Creation Time", 150)
            .Columns.Add("Write Time", 150)
        End With

        With lvDownload
            .Clear()
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
            .Sorting = SortOrder.Ascending
            .MultiSelect = False
            .HideSelection = False

            'Add column header
            .Columns.Add("File Name", 200)
            .Columns.Add("Status", 400)
        End With

        With lvUpload
            .Clear()
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
            .Sorting = SortOrder.Ascending
            .MultiSelect = False
            .HideSelection = False

            'Add column header
            .Columns.Add("File Name", 200)
            .Columns.Add("Status", 400)
        End With
    End Sub

    Private Sub frmFileExplorer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lv_Init()


        Dim downloadPath As String = fileExplorerObj.GetDownloadPath()

        If (Not Directory.Exists(downloadPath)) Then
            Directory.CreateDirectory(downloadPath)
        End If

        fileExplorerObj.SendGetDiskMask()

        Dim cnt As Integer = 0
        While fileExplorerObj.GetDiskMask = 0
            Threading.Thread.Sleep(1000)
            cnt += 1
            If cnt = 5 Then
                MsgBox("Can not load drive list", vbCritical, "Error")
                Me.Close()
                Exit While
            End If
        End While
        Dim diskMask As Integer = fileExplorerObj.GetDiskMask()

        cbDriveList.Items.Clear()
        Dim diskAscii As Byte = &H41
        While diskMask <> 0
            If (diskMask And 1) = 1 Then
                cbDriveList.Items.Add(Chr(diskAscii) + ":\")
            End If
            diskMask >>= 1
            diskAscii += 1
        End While
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        fileExplorerObj = Nothing
        Me.Close()
    End Sub

    Private Sub cbDriveList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDriveList.SelectedIndexChanged
        txtPath.Text = cbDriveList.SelectedItem.ToString()
        fileExplorerObj.SendBrowseFolder(txtPath.Text)
    End Sub

    Private Function ConverterToSizeString(ByVal size As UInt64)
        Dim DoubleBytes As Double
        Select Case size
            Case Is >= 1099511627776
                DoubleBytes = CDbl(size / 1099511627776) 'TB
                Return FormatNumber(DoubleBytes, 2) & " TB"
            Case 1073741824 To 1099511627775
                DoubleBytes = CDbl(size / 1073741824) 'GB
                Return FormatNumber(DoubleBytes, 2) & " GB"
            Case 1048576 To 1073741823
                DoubleBytes = CDbl(size / 1048576) 'MB
                Return FormatNumber(DoubleBytes, 2) & " MB"
            Case 1024 To 1048575
                DoubleBytes = CDbl(size / 1024) 'KB
                Return FormatNumber(DoubleBytes, 2) & " KB"
            Case 0 To 1023
                DoubleBytes = size ' bytes
                Return FormatNumber(DoubleBytes, 2) & " bytes"
            Case Else
                Return "???"
        End Select
    End Function

    Private Sub AddItemToFileList(ByVal Item As clsFileExplorer.LITE_WIN32_FIND_DATA)
        Dim data(4) As String
        data(0) = Item.cFileName
        If Item.isFolder = 1 Then
            data(1) = ""
            data(2) = "Folder"
        Else
            Dim fileSize As UInt64 = Item.nFileSizeLow + (Item.nFileSizeHigh << 32)
            data(1) = ConverterToSizeString(fileSize)
            data(2) = ""
        End If
        data(3) = DateTime.FromFileTime(Item.ftCreationTime).ToString()
        data(4) = DateTime.FromFileTime(Item.ftLastWriteTime).ToString()
        Dim itm As ListViewItem = New ListViewItem(data)
        lvFileExplorer.Items.Add(itm)
    End Sub

    Private currentSession As UInteger = 0
    Private Sub TmFileExplorer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmFileExplorer.Tick
        If fileExplorerObj Is Nothing Then Exit Sub
        Dim ItemList As List(Of clsFileExplorer.LITE_WIN32_FIND_DATA) = fileExplorerObj.GetCurrentFolderItem()
        If currentSession <> fileExplorerObj.GetFolderBrowserSession() Or lvFileExplorer.Items.Count <> fileExplorerObj.GetCurrentFolderItem.Count Then
            currentSession = fileExplorerObj.GetFolderBrowserSession()
            lvFileExplorer.Items.Clear()
            'Disable Listview sort a while for speed up
            Dim oldSortIComparer As IComparer = lvFileExplorer.ListViewItemSorter
            lvFileExplorer.ListViewItemSorter = Nothing
            For Each item As clsFileExplorer.LITE_WIN32_FIND_DATA In ItemList
                AddItemToFileList(item)
            Next
            'Now bring the sort back
            lvFileExplorer.ListViewItemSorter = oldSortIComparer
            lvFileExplorer.Sort()
        End If

        Dim test As List(Of clsFileExplorer.DownloadItem) = fileExplorerObj.GetDownloadList()

        If lvDownload.Items.Count = fileExplorerObj.GetDownloadList().Count Then
            UpdateDownloadLv()
        Else
            RefreshDownloadLv()
        End If

        If lvUpload.Items.Count = fileExplorerObj.GetUploadList().Count Then
            UpdateUploadLv()
        Else
            RefreshUploadLv()
        End If
    End Sub

    Private Sub CrystalClearButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGo.Click
        fileExplorerObj.SendBrowseFolder(txtPath.Text)
    End Sub

    ' The column currently used for sorting.
    Private m_SortingColumn As ColumnHeader
    Private Sub lvFileExplorer_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvFileExplorer.ColumnClick
        'http://www.vb-helper.com/howto_net_listview_sort_clicked_column.html

        Dim new_sorting_column As ColumnHeader = _
        lvFileExplorer.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortingColumn.Text = _
                m_SortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        lvFileExplorer.ListViewItemSorter = New  _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        lvFileExplorer.Sort()
    End Sub

    Private Sub lvFileExplorer_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvFileExplorer.DoubleClick
        If lvFileExplorer.SelectedItems.Count > 0 Then
            If lvFileExplorer.FocusedItem.SubItems(2).Text = "Folder" Then
                If lvFileExplorer.FocusedItem.SubItems(0).Text = ".." Then
                    txtPath.Text = DescPath(txtPath.Text)
                Else
                    txtPath.Text += lvFileExplorer.FocusedItem.SubItems(0).Text + "\"
                End If
                fileExplorerObj.SendBrowseFolder(txtPath.Text)
            End If
        End If
    End Sub

    Private Function DescPath(ByVal path As String) As String
        Dim tmp As String() = path.Split("\")
        Dim result As String = ""
        For i = 0 To tmp.Length - 3
            result += tmp(i) + "\"
        Next
        Return result
    End Function

    Private Sub txtPath_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPath.KeyDown
        If e.KeyCode = Keys.Enter Then
            fileExplorerObj.SendBrowseFolder(txtPath.Text)
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        txtPath.Text = fileExplorerObj.GetCurrentBrowserPath()
        fileExplorerObj.SendBrowseFolder(txtPath.Text)
    End Sub

    Private Sub lvFileExplorer_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvFileExplorer.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ctxMenu.Show(lvFileExplorer, e.Location)
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If lvFileExplorer.SelectedItems.Count > 0 Then
            If lvFileExplorer.FocusedItem.SubItems(2).Text = "Folder" Then
                MsgBox("Folder deletion is not support at this time", vbCritical, "Ops")
                Exit Sub
            End If

            Dim deletePath As String = txtPath.Text & lvFileExplorer.FocusedItem.SubItems(0).Text
            fileExplorerObj.SendDeleteFile(deletePath)
            'Refresh item
            fileExplorerObj.SendBrowseFolder(txtPath.Text)
            Threading.Thread.Sleep(500)
        End If
    End Sub

    Private Sub RenameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameToolStripMenuItem.Click
        If lvFileExplorer.SelectedItems.Count > 0 Then
            frmRenameFile.txtName.Text = lvFileExplorer.FocusedItem.SubItems(0).Text
            frmRenameFile.oldName = lvFileExplorer.FocusedItem.SubItems(0).Text
            frmRenameFile.path = fileExplorerObj.GetCurrentBrowserPath()
            frmRenameFile.fileExplorerObj = fileExplorerObj
            frmRenameFile.ShowDialog()
            fileExplorerObj.SendBrowseFolder(fileExplorerObj.GetCurrentBrowserPath())
        End If
    End Sub

    Private Sub ExecuteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecuteToolStripMenuItem.Click
        If lvFileExplorer.SelectedItems.Count > 0 Then
            fileExplorerObj.SendExecuteFile(fileExplorerObj.GetCurrentBrowserPath() + lvFileExplorer.FocusedItem.SubItems(0).Text)
        End If
    End Sub

    Private Sub CreateFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateFolderToolStripMenuItem.Click
        If lvFileExplorer.SelectedItems.Count > 0 Then
            frmCreateFolder.path = fileExplorerObj.GetCurrentBrowserPath()
            frmCreateFolder.fileExplorerObj = fileExplorerObj
            frmCreateFolder.ShowDialog()
            fileExplorerObj.SendBrowseFolder(fileExplorerObj.GetCurrentBrowserPath())
        End If
    End Sub

    Private Sub lvDownload_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDownload.SelectedIndexChanged

    End Sub

    Private Sub DownloadFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadFileToolStripMenuItem.Click
        If lvFileExplorer.SelectedItems.Count > 0 Then
            If lvFileExplorer.FocusedItem.SubItems(2).Text = "Folder" Then
                MsgBox("Download folder is not support", vbCritical, "Error")
            End If
            Dim downloadFileName As String = lvFileExplorer.FocusedItem.SubItems(0).Text
            fileExplorerObj.SendDownload(fileExplorerObj.GetCurrentBrowserPath() + downloadFileName)
        End If
    End Sub

    Private Sub RefreshDownloadLv()
        lvDownload.Items.Clear()
        Dim listOfDownload As List(Of clsFileExplorer.DownloadItem) = fileExplorerObj.GetDownloadList()

        For Each Item As clsFileExplorer.DownloadItem In listOfDownload
            Dim progress As Integer
            If Item.Attr.status = clsFileExplorer.DOWNLOAD_INIT Then
                progress = 0
            ElseIf Item.Attr.status = clsFileExplorer.DOWNLOAD_PROGRESS Then
                progress = 100 - (Item.Attr.sizeLeft * 100 / Item.Attr.totalSize)
            ElseIf Item.Attr.status = clsFileExplorer.DOWNLOAD_FINISH Then
                progress = 100
            ElseIf Item.Attr.status = clsFileExplorer.DOWNLOAD_ERROR Then
                Utilities.GlobalLog("Error while downloading " + Utilities.TrimPath(Item.Attr.path))
                listOfDownload.Remove(Item)
            End If
            AddItemToDownloadLv(Utilities.TrimPath(Item.Attr.path), progress)
        Next
    End Sub

    Private Sub UpdateDownloadLv()
        Dim i As Integer
        Dim downloadList As List(Of clsFileExplorer.DownloadItem) = fileExplorerObj.GetDownloadList()

        For i = 0 To downloadList.Count - 1
            lvDownload.Items(i).SubItems(0).Text = TrimPath(downloadList(i).Attr.path)
            If downloadList(i).Attr.status = clsFileExplorer.DOWNLOAD_INIT Then
                lvDownload.Items(i).SubItems(1).Text = "Waiting..."
            Else
                lvDownload.Items(i).SubItems(1).Text = Math.Floor(100 - (downloadList(i).Attr.sizeLeft * 100 / downloadList(i).Attr.totalSize)).ToString + "%"
            End If
        Next
    End Sub

    Private Sub RefreshUploadLv()
        lvUpload.Items.Clear()
        Dim listOfUpload As List(Of clsFileExplorer.UploadItem) = fileExplorerObj.GetUploadList()

        For Each Item As clsFileExplorer.UploadItem In listOfUpload
            Dim progress As Integer
            If Item.Attr.status = clsFileExplorer.UPLOAD_INIT Then
                progress = 0
            ElseIf Item.Attr.status = clsFileExplorer.UPLOAD_PROGRESS Then
                progress = (Item.Attr.sizeUploaded * 100 / Item.Attr.totalSize)
            ElseIf Item.Attr.status = clsFileExplorer.UPLOAD_FINISH Then
                progress = 100
            ElseIf Item.Attr.status = clsFileExplorer.UPLOAD_ERROR Then
                Utilities.GlobalLog("Error while uploading " + Utilities.TrimPath(Item.Attr.path))
                listOfUpload.Remove(Item)
            End If
            AddItemToUploadLv(Utilities.TrimPath(Item.Attr.path), progress)
        Next
    End Sub

    Private Sub UpdateUploadLv()
        Dim i As Integer
        Dim uploadList As List(Of clsFileExplorer.UploadItem) = fileExplorerObj.GetUploadList()

        For i = 0 To uploadList.Count - 1
            lvUpload.Items(i).SubItems(0).Text = TrimPath(uploadList(i).Attr.path)
            lvUpload.Items(i).SubItems(1).Text = Math.Floor((uploadList(i).Attr.sizeUploaded * 100 / uploadList(i).Attr.totalSize)).ToString + "%"
        Next
    End Sub

    Private Sub AddItemToDownloadLv(ByVal name As String, ByVal progress As Integer)
        Dim data(2) As String
        data(0) = name
        data(1) = Math.Floor(progress).ToString + "%"
        Dim itm As ListViewItem = New ListViewItem(data)
        lvDownload.Items.Add(itm)
    End Sub

    Private Sub AddItemToUploadLv(ByVal name As String, ByVal progress As Integer)
        Dim data(2) As String
        data(0) = name
        data(1) = Math.Floor(progress).ToString + "%"
        Dim itm As ListViewItem = New ListViewItem(data)
        lvUpload.Items.Add(itm)
    End Sub

    Private Sub UploadFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadFileToolStripMenuItem.Click
        Dim uploadedPath As String = txtPath.Text
        Dim openFileDlg As OpenFileDialog = New OpenFileDialog()
        With openFileDlg
            .Title = "Open file to upload"
            .Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
            .RestoreDirectory = True
        End With
        If openFileDlg.ShowDialog() = DialogResult.OK Then
            'MsgBox(Utilities.TrimPath(openFileDlg.FileName))
            uploadedPath += Utilities.TrimPath(openFileDlg.FileName)
            fileExplorerObj.SendUpload(openFileDlg.FileName, uploadedPath)
        End If
    End Sub
End Class