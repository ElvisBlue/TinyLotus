Public Class clsSwitch
    'Public
    Inherits clsBoneObj

    'Private
    Dim isAccepted As Boolean = False
    Dim InfoObj As clsInfo

    Public Sub New(ByVal mConn As clsConnection, ByVal m_Info As clsInfo)
        Conn = mConn
        InfoObj = m_Info
    End Sub

    Public Overrides Sub OnInit()
        'Init Switch Obj ID
        ObjID = 5
    End Sub

    Public Overrides Sub OnExit()

    End Sub

    Public Overrides Sub OnPacketArrived(ByVal packet() As Byte)
        Dim ID As Byte = packet(0)
        Dim BinReader As clsArrayBinaryReader = New clsArrayBinaryReader()
        Select Case ID
            Case 0 'Case password
                Dim clientPassword As String = System.Text.Encoding.ASCII.GetString(BinReader.BufferReadBuffer(packet, 1, packet.Length - 1)).Replace(vbNullChar, "")
                If clientPassword = mSettings.ServerSetting.password Then
                    isAccepted = True
                    SendAcceptClient()
                    InfoObj.SendGetWindowBasicInfo()
                    InfoObj.SendGetWindowVersion()
                    InfoObj.SendGetWindowTitle()
                    InfoObj.SendGetBotTag()
                    InfoObj.SendGetBotUID()
                Else
                    Utilities.GlobalLog("Wrong password from " + InfoObj.GetClientInfo().IP)
                    SendClose()
                End If
        End Select
    End Sub

    Public Function IsClientAccept()
        Return isAccepted
    End Function

    Public Function SendClose()
        Dim packet() As Byte = Nothing
        Dim BinWritter As clsArrayBinaryWritten = New clsArrayBinaryWritten()
        BinWritter.BufferAddByte(packet, 0)
        Return SendPacket(packet)
    End Function

    Public Function SendTerminate()
        Dim packet() As Byte = Nothing
        Dim BinWritter As clsArrayBinaryWritten = New clsArrayBinaryWritten()
        BinWritter.BufferAddByte(packet, 1)
        Return SendPacket(packet)
    End Function

    Public Function SendRequiredPassword()
        Dim packet() As Byte = Nothing
        Dim BinWritter As clsArrayBinaryWritten = New clsArrayBinaryWritten()
        BinWritter.BufferAddByte(packet, 3)
        Return SendPacket(packet)
    End Function

    Private Function SendAcceptClient()
        Dim packet() As Byte = Nothing
        Dim BinWritter As clsArrayBinaryWritten = New clsArrayBinaryWritten()
        BinWritter.BufferAddByte(packet, 2)
        Return SendPacket(packet)
    End Function

End Class
