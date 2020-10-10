Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.NetworkInformation
Imports ZLibNet

Public Class clsConnection
    Private Const TINY_LOTUS_HEADER As UInteger = &HCAFEBABEUI

    'Public
    Public Sub New(ByVal mConn As TcpClient)
        Conn = mConn
    End Sub

    Public Function SendRawPacket(ByVal packetData As Byte()) As Boolean
        Dim binWritter As clsArrayBinaryWritten = New clsArrayBinaryWritten()
        Dim dataSending As Byte() = Nothing
        binWritter.BufferAddDword(dataSending, TINY_LOTUS_HEADER)

        'Now Compress send data
        Dim compressedPacket As Byte()

        compressedPacket = ZLibCompressor.Compress(packetData)


        binWritter.BufferAddDword(dataSending, compressedPacket.Length)
        binWritter.BufferAddDword(dataSending, packetData.Length)
        binWritter.BufferMerge(dataSending, compressedPacket)

        Try
            Dim stream As NetworkStream = Conn.GetStream()
            stream.Write(dataSending, 0, dataSending.Length)
        Catch Ex As Exception
            Return False
        End Try


        Return True
    End Function

    Public Function RecvRawPacket(ByRef Buffer As Byte()) As Boolean
        Dim stream As NetworkStream = Conn.GetStream()
        Dim header(11) As Byte
        Dim BinReader As clsArrayBinaryReader = New clsArrayBinaryReader()

        Try
            While Conn.Available < 12
                Threading.Thread.Sleep(1)
            End While
            stream.Read(header, 0, 12)
            If BinReader.BufferReadDWORD(header, 0) = TINY_LOTUS_HEADER Then
                Dim packetSize As Integer = BinReader.BufferReadDWORD(header, 4)

                'OK perform decompress buffer
                Dim compressedBuffer As Byte()
                ReDim compressedBuffer(packetSize - 1)

                While Conn.Available < packetSize
                    Threading.Thread.Sleep(1)
                End While
                Dim bytesread As Integer = stream.Read(compressedBuffer, 0, packetSize)

                If bytesread < packetSize Then
                    MsgBox("What do I do?")
                End If

                Buffer = ZLibCompressor.DeCompress(compressedBuffer)
                Return True
            Else
                Utilities.GlobalLog("Wrong header from " & Conn.Client.RemoteEndPoint.AddressFamily.ToString())
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub CloseConnection()
        Conn.GetStream().Close()
        Conn.Close()
    End Sub

    Public Function GetState(ByVal tcpClient As TcpClient) As TcpState
        Try
            Dim foo = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections().SingleOrDefault(Function(x) x.LocalEndPoint.Equals(tcpClient.Client.LocalEndPoint) And
                                                                                                                        x.RemoteEndPoint.Equals(tcpClient.Client.RemoteEndPoint))
            Return If(foo IsNot Nothing, foo.State, TcpState.Unknown)
        Catch
            Return TcpState.Unknown
        End Try
    End Function

    Public Function IsConnected() As Boolean
        Return If(GetState(Conn) = TcpState.Established, True, False)
        'Return Conn.Client.Connected
    End Function

    Public Function GetIPAddr() As String
        Dim IP As IPEndPoint = Conn.Client.RemoteEndPoint
        Return IP.Address.ToString
    End Function

    'Private
    Private Conn As TcpClient
End Class

'Am I need ConnPool
Public Class clsConnectionPool
    'Public
    Public Sub New(ByVal mConn As TcpClient)
        Conn = New clsConnection(mConn)
        IsBusying = False
    End Sub

    Public Function QueryConnObj() As clsConnection
        'Wait for Obj
        While IsBusying = True
            Threading.Thread.Sleep(10)
        End While

        'Lock Obj
        IsBusying = True
        Return Conn
    End Function

    Public Function ReturnConnObj() As Boolean
        'Unlock Obj
        IsBusying = False
        Return True
    End Function

    Public Function ForceQueryConnObj() As clsConnection
        'Please use for read-only
        Return Conn
    End Function

    'Private
    Private Conn As clsConnection
    Private IsBusying As Boolean

End Class