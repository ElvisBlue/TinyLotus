Imports System.Reflection
Imports PluginInterface

'Based on: http://www.divelements.co.uk/net/articles/plugins/plugins.asp
'Based on: https://www.codeproject.com/Articles/1052356/Creating-a-simple-plugin-system-with-NET

Public Class clsBuilderHost
    Implements IBuilderHost

    Public Function BuildDLL(ByVal server As String, ByVal port As UInt16, ByVal password As String) As Byte() Implements IBuilderHost.BuildDLL
        Dim builderObj As clsBuilder = mGlobal.GetBuilderObj()
        Return builderObj.BuildDLL(server, port, password)
    End Function

    Public Function BuildShellCode(ByVal server As String, ByVal port As UInt16, ByVal password As String) As Byte() Implements IBuilderHost.BuildShellCode
        Dim builderObj As clsBuilder = mGlobal.GetBuilderObj()
        Return builderObj.BuildShellcode(server, port, password)
    End Function
End Class

Public Class clsBuilderPlugin
    Private pluginObj As IBuilderPlugin
    Private objDLL As [Assembly]
    Private hostObj As Object

    Public Sub New(ByVal mHostObj As Object)
        hostObj = mHostObj
    End Sub
    Public Function Load(ByVal pluginPath As String) As Boolean
        Try
            objDLL = [Assembly].LoadFrom(pluginPath)
            pluginObj = GetDLLInterface(objDLL)
            If pluginObj Is Nothing Then
                Return False
            End If
            pluginObj.OnInit(hostObj)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function GetPluginInstance() As IBuilderPlugin
        Return pluginObj
    End Function

    Private Function GetDLLInterface(ByVal objDLL As [Assembly]) As IBuilderPlugin
        For Each objType As Type In objDLL.GetTypes
            If objType.IsPublic = True Then
                If Not ((objType.Attributes And TypeAttributes.Abstract) = TypeAttributes.Abstract) Then
                    Dim objInterface As Type = objType.GetInterface("IBuilderPlugin", True)
                    If Not (objInterface Is Nothing) Then
                        Return DirectCast(objDLL.CreateInstance(objType.FullName, True), IBuilderPlugin)
                    End If
                End If
            End If
        Next
        Return Nothing
    End Function
End Class

Public Class clsBuilderPluginMgr
    Private builderPluginList As List(Of clsBuilderPlugin)
    Private hostObj As IBuilderHost

    Public Sub New()
        hostObj = New clsBuilderHost()
        builderPluginList = New List(Of clsBuilderPlugin)
    End Sub
    Public Function GetBuilderPluginByID(ByVal ID As UInt32) As clsBuilderPlugin
        For Each plugin As clsBuilderPlugin In builderPluginList
            Dim pluginInterface As IBuilderPlugin = plugin.GetPluginInstance()
            If pluginInterface.GetPluginID() = ID Then
                Return plugin
            End If
        Next
        Return Nothing
    End Function

    Public Function GetBuilderPluginByName(ByVal pluginName As String) As clsBuilderPlugin
        For Each plugin As clsBuilderPlugin In builderPluginList
            Dim pluginInterface As IBuilderPlugin = plugin.GetPluginInstance()
            If pluginInterface.GetPluginName() = pluginName Then
                Return plugin
            End If
        Next
        Return Nothing
    End Function

    Public Function GetBuilderPluginList() As List(Of clsBuilderPlugin)
        Return builderPluginList
    End Function

    Public Function LoadPlugin(ByVal pluginPath As String) As Boolean
        Dim builderPlugin As clsBuilderPlugin = New clsBuilderPlugin(hostObj)
        If builderPlugin.Load(pluginPath) Then
            Return RegisterBuilderPlugin(builderPlugin)
        End If
        Return False
    End Function

    Private Function RegisterBuilderPlugin(ByVal builderPlugin As clsBuilderPlugin) As Boolean
        If builderPlugin IsNot Nothing Then
            Dim pluginObj As IBuilderPlugin = builderPlugin.GetPluginInstance()
            For Each plugin In builderPluginList
                Dim currentPluginInterface As IBuilderPlugin = plugin.GetPluginInstance()
                If currentPluginInterface.GetPluginID() = pluginObj.GetPluginID() Then
                    Utilities.GlobalLog("Failed to load builder plugin " & currentPluginInterface.GetPluginName() & ": A plugin has same plugin id has been loaded")
                    Return False
                End If
            Next
            builderPluginList.Add(builderPlugin)
            Utilities.GlobalLog("Builder plugin '" & pluginObj.GetPluginName() & "' has been loaded")
            Return True
        Else
            Return False
        End If
    End Function
End Class
