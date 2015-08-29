Imports System.Threading
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Net

Public Class Form1

    Private Sub backgroundthread_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundthread.ProgressChanged, backgroundbrawlers.ProgressChanged
        pbProgress.Value = e.ProgressPercentage

        If TypeOf e.UserState Is String Then
            lblProgress.Text = CType(e.UserState, String)
        ElseIf TypeOf e.UserState Is StatCollection Then
            Dim _stats As StatCollection = e.UserState
            tbLog.Text = _stats.ToString()
        End If
    End Sub

    Private Sub backgroundthread_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles backgroundthread.DoWork
        backgroundthread.ReportProgress(0, "Reading File")

        Dim fi As New FileInfo(tbFile.Text)
        Dim di As New DirectoryInfo(Path.Combine(fi.Directory.FullName, Path.GetFileNameWithoutExtension(fi.FullName) & IIf(cbTimeline.Checked, "_full", "")))
        If Not di.Exists Then di.Create()

        If fi.Exists Then
            Dim _filecontent As String = File.ReadAllText(fi.FullName)
            Dim js As New JavaScriptSerializer()

            Dim gameids As Object() = js.DeserializeObject(_filecontent)
            Dim server As String = Path.GetFileNameWithoutExtension(fi.FullName).ToLower()

            For i As Int32 = 0 To gameids.Length - 1
                If backgroundthread.CancellationPending Then Exit Sub
                backgroundthread.ReportProgress(CInt(100 * ((i + 1) / gameids.Length)), "Processing " & (i + 1) & " / " & gameids.Length)

                'Download Game
                Dim gameid As String = gameids(i) & ""
                Dim gamefi As New FileInfo(Path.Combine(di.FullName, gameid & ".json"))
                If Not gamefi.Exists Then
                    Dim url As String = "https://" & server & ".api.pvp.net/api/lol/" & server & "/v2.2/match/" & gameid & "?api_key=" & tbAPIKEY.Text & IIf(cbTimeline.Checked, "&includeTimeline=true", "")

                    Dim _error As Boolean = True
                    While _error
                        Dim rtn As String = GetData(url, _error)
                        If Not String.IsNullOrEmpty(rtn) Then File.WriteAllText(gamefi.FullName, rtn)

                        If _error Then Thread.Sleep(2500)
                    End While
                End If
            Next
        End If
    End Sub

    Private Sub backgroundbrawlers_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles backgroundbrawlers.DoWork
        backgroundbrawlers.ReportProgress(0, "Reading Directory")

        Dim _stats As New StatCollection()

        Dim di As New DirectoryInfo(tbDir.Text)
        If di.Exists Then
            Dim _files As FileInfo() = di.GetFiles("*.json", SearchOption.AllDirectories)
            Dim js As New JavaScriptSerializer()

            For i As Int32 = 0 To _files.Length - 1
                If backgroundbrawlers.CancellationPending Then Exit For
                backgroundbrawlers.ReportProgress(CInt(100 * ((i + 1) / _files.Length)), "Processing " & (i + 1) & " / " & _files.Length)

                Dim fi As FileInfo = _files(i)
                _stats.ProcessGameInfo(fi)

                ' If i > 1000 Then Exit For
            Next
        End If

        _stats.Export(New DirectoryInfo(tbExportDir.Text))
        backgroundbrawlers.ReportProgress(100, _stats)
    End Sub

    Private Sub backgroundthread_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundthread.RunWorkerCompleted, backgroundbrawlers.RunWorkerCompleted
        pbProgress.Value = 100

        lblProgress.Text = "... Ended"
        btnStartImport.Enabled = True
        lbBrawlers.Enabled = True

        btnStopImport.Enabled = False
    End Sub

    Private Sub btnStopImport_Click(sender As Object, e As EventArgs) Handles btnStopImport.Click
        backgroundthread.CancelAsync()
        backgroundbrawlers.CancelAsync()
    End Sub

    Private Sub PreStart_Background()
        pbProgress.Value = 0
        lblProgress.Text = "Starting ..."

        btnStartImport.Enabled = False
        lbBrawlers.Enabled = False

        btnStopImport.Enabled = True
    End Sub

    Private Sub btnStartImport_Click(sender As Object, e As EventArgs) Handles btnStartImport.Click
        PreStart_Background()

        backgroundthread.RunWorkerAsync()
    End Sub

    Private Sub lbBrawlers_Click(sender As Object, e As EventArgs) Handles lbBrawlers.Click
        PreStart_Background()

        backgroundbrawlers.RunWorkerAsync()
    End Sub

    Public Function GetData(url As String, ByRef _error As Boolean) As String
        _error = False

        'Create Request
        Dim request As WebRequest = WebRequest.Create(url)
        request.ContentType = "application/x-www-form-urlencoded"
        request.Method = "GET"

        'Write Body
        Dim requestStream As Stream = Nothing

        'Get Response
        Dim response As WebResponse = Nothing
        Dim responseReader As StreamReader = Nothing
        Try
            response = request.GetResponse()
            requestStream = response.GetResponseStream()
            responseReader = New StreamReader(requestStream)
            Dim responseString As String = responseReader.ReadToEnd()

            Return responseString
        Catch ex As WebException
            _error = True
            If CType(ex.Response, HttpWebResponse).StatusCode = 429 Then

                Dim forbreakpoint As String = ""
            Else
                Dim forbreakpoint As String = ""
            End If
        End Try

        'Close Readers / Writers
        If Not responseReader Is Nothing Then responseReader.Close()
        If Not requestStream Is Nothing Then requestStream.Close()
        If Not response Is Nothing Then response.Close()

        'Handle Result
        Return Nothing
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fiChampions As New FileInfo(tbChampionsFile.Text)
        Dim fiItems As New FileInfo(tbItemsFile.Text)

        Dim exportDir As New DirectoryInfo(tbExportDir2.Text)
        If Not exportDir.Exists Then exportDir.Create()

        Dim exChampions As New FileInfo(Path.Combine(exportDir.FullName, "data_champions.js"))
        If exChampions.Exists Then exChampions.Delete()
        Dim exItems As New FileInfo(Path.Combine(exportDir.FullName, "data_illigalitems.js"))
        If exItems.Exists Then exItems.Delete()

        Dim js As New JavaScriptSerializer()
        js.MaxJsonLength = 9999999 ' Because the championsfile is large -.-

        'Load Items
        Dim dItems As New Dictionary(Of String, Object)()
        Dim orgItems As Dictionary(Of String, Object) = js.DeserializeObject(File.ReadAllText(fiItems.FullName))("data")
        Dim allitemids As New List(Of Int32)()
        allitemids.AddRange(StatCollection.BW_BRAWLERS)
        allitemids.AddRange(StatCollection.BW_BRAWLERSUPGRADES)
        allitemids.AddRange(StatCollection.BW_ILLIGALITEMS)

        For Each itemid As Int32 In allitemids
            Dim d As Dictionary(Of String, Object) = orgItems("" & itemid)
            Dim addd As New Dictionary(Of String, Object)()
            addd.Add("id", d("id"))
            addd.Add("name", d("name"))
            addd.Add("description", d("description"))
            addd.Add("gold", d("gold")("total"))

            'http://ddragon.leagueoflegends.com/cdn/5.2.1/img/champion/Aatrox.png
            Dim imgd As Dictionary(Of String, Object) = d("image")
            addd.Add("image", "http://ddragon.leagueoflegends.com/cdn/5.16.1/img/" & imgd("group") & "/" & imgd("full"))

            dItems.Add("item" & addd("id"), addd)
        Next
        File.WriteAllText(exItems.FullName, "var data_illigalitems = " & js.Serialize(dItems) & ";")

        'Load Champions
        Dim dChampions As New Dictionary(Of String, Object)()
        Dim orgChampions As Dictionary(Of String, Object) = js.DeserializeObject(File.ReadAllText(fiChampions.FullName))("data")

        For Each d As Dictionary(Of String, Object) In orgChampions.Values
            Dim addd As New Dictionary(Of String, Object)()
            addd.Add("id", d("id"))
            addd.Add("name", d("name"))
            addd.Add("title", d("title"))
            addd.Add("lore", d("lore"))

            'http://ddragon.leagueoflegends.com/cdn/5.2.1/img/champion/Aatrox.png
            Dim imgd As Dictionary(Of String, Object) = d("image")
            addd.Add("image", "http://ddragon.leagueoflegends.com/cdn/5.16.1/img/" & imgd("group") & "/" & imgd("full"))

            dChampions.Add("champion" & addd("id"), addd)
        Next

        File.WriteAllText(exChampions.FullName, "var data_champions = " & js.Serialize(dChampions) & ";")

        tbLog.Text &= "Export DONE!"
    End Sub
End Class
