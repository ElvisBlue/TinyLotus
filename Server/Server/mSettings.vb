﻿Imports System.Net

Module mSettings
    Public ServerSetting As Settings
    Public Structure Settings
        Public Port As Integer
        Public isListening As Integer
        Public password As String
        Public blockIPList As List(Of IPAddress)
    End Structure

    Public Function WriteSettings()
        Return False
    End Function

    Public Function ReadSettings()
        Return False
    End Function
End Module
