Public Class clsCommand
    'Public
    Inherits clsBoneObj

    Public Sub New(ByVal mConn As clsConnection)
        Conn = mConn
    End Sub

    Public Overrides Sub OnInit()
        ObjID = 1
    End Sub

    Public Overrides Sub OnExit()

    End Sub

    Public Overrides Sub OnPacketArrived(ByVal packet As Byte())
        Dim ID As Integer = packet(0)
        Dim BinReader As clsArrayBinaryReader = New clsArrayBinaryReader()

        Select Case ID
            Case 0
                If packet(1) = 1 Then
                    IsStarted = True
                    CmdText = ""
                End If
            Case 1
                'Enter command ok
            Case 2
                IsStarted = False
                CmdText = ""
            Case 3
                If packet.Length > 2 Then
                    Dim CmdData As Byte() = BinReader.BufferReadBuffer(packet, 1, packet.Length - 1)
                    CmdText += System.Text.ASCIIEncoding.ASCII.GetString(CmdData)
                End If
        End Select

    End Sub

    Public Function StartCmd() As Boolean
        Dim sendData(0) As Byte
        sendData(0) = 0
        SendPacket(sendData)
        Return Nothing
    End Function

    Public Function SendCommand(ByVal Command As String) As Boolean
        Dim sendData() As Byte = Nothing
        Dim BinWriter As clsArrayBinaryWritten = New clsArrayBinaryWritten()

        BinWriter.BufferAddByte(sendData, 1)
        BinWriter.BufferMerge(sendData, System.Text.Encoding.ASCII.GetBytes(Command))
        BinWriter.BufferAddWord(sendData, 10) 'Enter and null char

        SendPacket(sendData)
        Return Nothing
    End Function

    Public Function ClearCmd()
        CmdText = ""
        Return Nothing
    End Function

    Public Function SendGetText()
        Dim sendData(0) As Byte
        sendData(0) = 3
        SendPacket(sendData)
        Return Nothing
    End Function

    Public Function ExitCmd() As Boolean
        Dim sendData(0) As Byte
        sendData(0) = 2
        SendPacket(sendData)
        Return Nothing
    End Function

    Public Function GetCmdText() As String
        Return CmdText
    End Function

    Public Function IsCmdStarted() As Boolean
        Return IsStarted
    End Function

    'Private
    Dim CmdText As String
    Dim IsStarted As Boolean
End Class
