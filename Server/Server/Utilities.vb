Module Utilities
    Public Function TrimPath(ByVal path As String)
        Return path.Substring(path.LastIndexOf("\") + 1)
    End Function

    Public Function RandomDWORD() As UInteger
        Dim Generator As System.Random = New System.Random()
        Return Convert.ToUInt32(Generator.Next(-2147483648, 2147483647) + 2147483648)
    End Function

    Public Sub GlobalLog(txt As String)
        frmmain.Log(txt)
    End Sub
End Module
