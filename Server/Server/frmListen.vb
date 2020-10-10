Imports System.Net
Imports System.Net.Sockets

Public Class frmListen

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmListen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPort.Text = mSettings.ServerSetting.Port
    End Sub

    Private Sub cmdListen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListen.Click
        mSettings.ServerSetting.Port = Val(txtPort.Text)
        If mSettings.ServerSetting.isListening = True Then
            frmmain.serverTCP.Stop()
            frmmain.serverTCP.Server.Dispose()
        End If

        frmmain.serverTCP = New TcpListener(IPAddress.Parse("0.0.0.0"), mSettings.ServerSetting.Port)
        frmmain.serverTCP.Start()
        frmmain.serverTCP.BeginAcceptTcpClient(New AsyncCallback(AddressOf frmmain.AcceptClientCallBack), frmmain.serverTCP)

        mSettings.ServerSetting.isListening = True
        Me.Close()
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        frmmain.serverTCP.Stop()
        frmmain.serverTCP.Server.Dispose()

        ShutdownAllClient()
        mSettings.ServerSetting.isListening = False
        Me.Close()
    End Sub

    Private Sub ShutdownAllClient()
        Dim clientMgr As clsClientMgr = frmmain.clientMgr

        For Each client As clsClientObj In clientMgr.GetClientList()
            client.ForceDisconnect()
        Next
    End Sub
End Class