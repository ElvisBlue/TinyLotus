Public Interface IBuilderPlugin
    Sub OnInit(ByVal hostObj As Object)
    Function OnBuild(ByVal server As String, ByVal port As UInt16, ByVal password As String) As Byte()
    Function GetPluginAuthor() As String
    Function GetPluginName() As String
    Function GetPluginID() As UInt32
    Function GetPluginDesc() As String
End Interface

Public Interface IBuilderHost
    Function BuildDLL(ByVal server As String, ByVal port As UInt16, ByVal password As String) As Byte()
    Function BuildShellCode(ByVal server As String, ByVal port As UInt16, ByVal password As String) As Byte()
End Interface
