Public Class clsArrayBinaryReader
    Public Function BufferReadByte(ByVal Buffer As Byte(), ByVal offset As Integer) As Byte
        Return Buffer(offset)
    End Function

    Public Function BufferReadWORD(ByVal Buffer As Byte(), ByVal offset As Integer) As UShort
        Return BitConverter.ToUInt16(Buffer, offset)
    End Function

    Public Function BufferReadDWORD(ByVal Buffer As Byte(), ByVal offset As Integer) As UInteger
        Return BitConverter.ToUInt32(Buffer, offset)
    End Function

    Public Function BufferReadQWORD(ByVal Buffer As Byte(), ByVal offset As Integer) As UInt64
        Return BitConverter.ToUInt64(Buffer, offset)
    End Function

    Public Function BufferReadBuffer(ByVal Buffer As Byte(), ByVal offset As Integer, ByVal Length As Integer) As Byte()
        Dim Ret(Length - 1) As Byte
        Array.ConstrainedCopy(Buffer, offset, Ret, 0, Length)
        Return Ret
    End Function
End Class
