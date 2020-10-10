Public Class clsBoneObj
    'Public
    Public Function GetObjID() As Integer
        Return ObjID
    End Function

    Public Overridable Sub OnInit()

    End Sub

    Public Overridable Sub OnExit()

    End Sub

    Public Overridable Sub OnPacketArrived(ByVal packet As Byte())

    End Sub

    'Protected
    Protected Function SendPacket(ByVal packetData As Byte()) As Boolean
        Dim SendData() As Byte = {}
        Dim BinWritter As clsArrayBinaryWritten = New clsArrayBinaryWritten()
        BinWritter.BufferAddDword(SendData, ObjID)
        BinWritter.BufferAddDword(SendData, packetData.Length)
        BinWritter.BufferMerge(SendData, packetData)
        Return Conn.SendRawPacket(SendData)
    End Function

    Protected Function RecvPacket(ByRef packetData As Byte()) As Boolean
        'I may not need this function
        'Use this function if you want to send and receive packet instantly
        'It may skip some packet to get the correct packet
        Dim RawPacket() As Byte = {}

        If Conn.RecvRawPacket(RawPacket) = True Then
            Dim BinReader As clsArrayBinaryReader = New clsArrayBinaryReader()
            Dim ID As Integer = BinReader.BufferReadDWORD(RawPacket, 0)

            'Should fix this
            If ID <> ObjID Then
                'OK ignore current packet because it's not the packet for this obj
                Return False
            End If
            Dim packetSize As Integer = BinReader.BufferReadDWORD(RawPacket, 4)

            packetData = BinReader.BufferReadBuffer(RawPacket, 8, packetSize)
            Return True
        End If
        Return False
    End Function

    'Protected
    Protected ObjID As Integer
    Protected Conn As clsConnection
End Class
