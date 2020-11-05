Module mGlobal
#Region "Builder"
    Private buildObj As clsBuilder = Nothing
    Public Function GetBuilderObj() As clsBuilder
        If buildObj Is Nothing Then
            buildObj = New clsBuilder()
        End If
        Return buildObj
    End Function
#End Region

#Region "Binary Reader"
    Private BinReader As clsArrayBinaryReader = Nothing
    Public Function GetBinReaderObj() As clsArrayBinaryReader
        If BinReader Is Nothing Then
            BinReader = New clsArrayBinaryReader()
        End If
        Return BinReader
    End Function
#End Region

#Region "Binary Writter"
    Private BinaryWritter As clsArrayBinaryWritten = Nothing
    Public Function GetBinWritterObj() As clsArrayBinaryWritten
        If BinaryWritter Is Nothing Then
            BinaryWritter = New clsArrayBinaryWritten()
        End If
        Return BinaryWritter
    End Function
#End Region

#Region "Builder Plugins"
    Private builderPluginMgrObj As clsBuilderPluginMgr = Nothing
    Public Function GetBuilderPluginMgrObj() As clsBuilderPluginMgr
        If builderPluginMgrObj Is Nothing Then
            builderPluginMgrObj = New clsBuilderPluginMgr()
        End If
        Return builderPluginMgrObj
    End Function
#End Region
End Module
