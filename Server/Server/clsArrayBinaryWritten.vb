Public Class clsArrayBinaryWritten
    'Public stuff here
    Public Function BufferAddByte(ByRef buffer As Byte(), ByVal value As UInteger) As Boolean
        If IsNothing(buffer) Then
            ReDim buffer(0)
            buffer(0) = value
            Return True
        End If
        ReDim Preserve buffer(UBound(buffer) + 1)
        buffer(UBound(buffer)) = value And &HFF
        Return True
    End Function

    Public Function BufferAddWord(ByRef buffer As Byte(), ByVal value As UInteger) As Boolean
        BufferAddByte(buffer, value And &HFF)
        BufferAddByte(buffer, (value >> 8) And &HFF)
        Return True
    End Function

    Public Function BufferAddDword(ByRef buffer As Byte(), ByVal value As UInteger) As Boolean
        BufferAddWord(buffer, value And &HFFFF)
        BufferAddWord(buffer, (value >> 16) And &HFFFF)
        Return True
    End Function

    Public Function BufferMerge(ByRef buffer1 As Byte(), ByRef buffer2 As Byte()) As Boolean
        Dim buffer1_OldLength As Integer = buffer1.Length
        ReDim Preserve buffer1(UBound(buffer1) + UBound(buffer2) + 1)
        buffer2.CopyTo(buffer1, buffer1_OldLength)
        Return True
    End Function
End Class
