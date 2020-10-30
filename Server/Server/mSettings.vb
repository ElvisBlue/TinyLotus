Imports System.Net
Imports System.IO


Module mSettings
    Public ServerSetting As Settings
    Private SettingFileName As String = Application.StartupPath & "\" & "Settings.dat"
    Public Structure Settings
        Public Port As Integer
        Public isListening As Integer
        Public password As String
        Public blockIPList As List(Of IPAddress)
    End Structure

    Public Function WriteSettings()
        Dim settingText As String = ""
        Try
            settingText &= mSettings.ServerSetting.Port.ToString() & vbCrLf &
                        mSettings.ServerSetting.isListening.ToString() & vbCrLf &
                        mSettings.ServerSetting.password & vbCrLf

            For Each ip As IPAddress In mSettings.ServerSetting.blockIPList
                settingText &= ip.ToString() & "|"
            Next

            settingText = settingText.Substring(0, settingText.Length - 1)
            File.WriteAllText(SettingFileName, settingText)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function ReadSettings()
        Try
            Dim txtSettings As String = File.ReadAllText(SettingFileName)
            Dim basicSetting = txtSettings.Split(vbCrLf)
            mSettings.ServerSetting.Port = Int(basicSetting(0))
            mSettings.ServerSetting.isListening = Int(basicSetting(1))
            mSettings.ServerSetting.password = basicSetting(2).Replace(vbLf, "")

            mSettings.ServerSetting.blockIPList = New List(Of IPAddress)

            Dim blockIPArray = basicSetting(3).Replace(vbLf, "").Split("|")
            For Each ip As String In blockIPArray
                Dim ipToAdd As IPAddress = Nothing
                If IPAddress.TryParse(ip, ipToAdd) Then
                    mSettings.ServerSetting.blockIPList.Add(ipToAdd)
                End If
            Next
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
End Module
