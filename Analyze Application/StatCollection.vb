Imports System.IO
Imports System.Web.Script.Serialization

Public Class StatCollection
    'Static Properties
    Public Shared Property BW_BRAWLERS As Int32() = {3611, 3612, 3613, 3614}
    Public Shared Property BW_BRAWLERSUPGRADES As Int32() = {3615, 3616, 3617, 3621, 3622, 3623, 3624, 3625, 3626}
    Public Shared Property BW_ILLIGALITEMS As Int32() = {3245, 1341, 1340, 1339, 1335, 1336, 1337, 1338, 3924, 3911, 3742, 3745, 3744, 3844, 3841, 3840, 3829, 3150, 3430, 3431, 3434, 3433, 3652}
    Public Shared Property GAME_CHAMPIONS As Int32() = {35, 36, 33, 34, 39, 157, 37, 38, 154, 150, _
                                                        43, 42, 41, 40, 201, 22, 23, 24, 25, 26, _
                                                        27, 28, 29, 3, 161, 2, 1, 7, 30, 6, _
                                                        32, 5, 31, 4, 9, 8, 19, 17, 18, 15, _
                                                        16, 13, 14, 11, 12, 21, 20, 107, 106, 105, _
                                                        104, 103, 99, 102, 101, 412, 98, 222, 96, 223, _
                                                        92, 91, 90, 429, 10, 421, 89, 79, 117, 114, _
                                                        78, 115, 77, 112, 113, 110, 111, 119, 432, 245, _
                                                        82, 83, 80, 81, 86, 84, 85, 67, 126, 69, _
                                                        127, 68, 121, 122, 120, 72, 236, 74, 75, 238, _
                                                        76, 134, 133, 59, 58, 57, 56, 55, 64, 62, _
                                                        63, 268, 267, 60, 131, 61, 266, 143, 48, 45, _
                                                        44, 51, 53, 54, 254, 50}
    Public Shared Property GAME_CHAMPION_MISSFORTUNE As Int32 = 21
    Public Shared Property GAME_CHAMPION_GRAVES As Int32 = 104
    Public Shared Property GAME_CHAMPION_TWISTEDFATE As Int32 = 4
    Public Shared Property GAME_CHAMPION_GANGPLANK As Int32 = 41

    'Helpers
    Public Property js As New JavaScriptSerializer()

    'Stats
    Public Property Stats_Brawlers As New Dictionary(Of Int32, Winrate)()
    Public Property Stats_IlligalItems As New Dictionary(Of Int32, Winrate)()
    Public Property Stats_TotalIlligalItems As New Winrate("USEBLACKMARKET")
    Public Property Stats_GRAVESvsTWISTEDFATE As New Winrate("GRAVESvsTWISTEDFATE")
    Public Property Stats_GRAVESandTWISTEDFATEvsGANGPLANK As New Winrate("GRAVESandTWISTEDFATEvsGANGPLANK")
    Public Property Stats_MISSFORTUNEvsGANGPLANK As New Winrate("MISSFORTUNEvsGANGPLANK")

    ' More Genral Stats
    Public Property Stats_Champions As New Dictionary(Of Int32, Winrate)()
    Public Property Stats_FirstBlood As New Winrate("FIRSTBLOOD")
    Public Property Stats_FirstTower As New Winrate("FIRSTTOWER")
    Public Property Stats_FirstInhibitor As New Winrate("FIRSTINHIBITOR")
    Public Property Stats_FirstBaron As New Winrate("FIRSTBARON")
    Public Property Stats_FirstDragon As New Winrate("FIRSTDRAGON")
    Public Property Stats_FifthDragon As New Winrate("FIFTHDRAGON")

    Public Sub New()
        For Each _itemid As Int32 In BW_BRAWLERS
            Stats_Brawlers.Add(_itemid, New Winrate("item" & _itemid))
            For Each _itemid2 As Int32 In BW_BRAWLERSUPGRADES
                Stats_Brawlers(_itemid).SubStats.Add(_itemid2, New Winrate("item" & _itemid & "_item" & _itemid2))
            Next
            For Each _championid As Int32 In GAME_CHAMPIONS
                Stats_Brawlers(_itemid).SubStats.Add(_championid, New Winrate("item" & _itemid & "_champion" & _championid))
            Next
        Next
        For Each _itemid As Int32 In BW_ILLIGALITEMS
            Stats_IlligalItems.Add(_itemid, New Winrate("item" & _itemid))
            For Each _championid As Int32 In GAME_CHAMPIONS
                Stats_IlligalItems(_itemid).SubStats.Add(_championid, New Winrate("item" & _itemid & "_champion" & _championid))
            Next
        Next
        For Each _championid As Int32 In GAME_CHAMPIONS
            Stats_Champions.Add(_championid, New Winrate("champion" & _championid))
            For Each _itemid As Int32 In BW_BRAWLERS
                Stats_Champions(_championid).SubStats.Add(_itemid, New Winrate("champion" & _championid & "_item" & _itemid))
            Next
            For Each _itemid As Int32 In BW_ILLIGALITEMS
                Stats_Champions(_championid).SubStats.Add(_itemid, New Winrate("champion" & _championid & "_item" & _itemid))
            Next
        Next
    End Sub

    Public Sub ProcessGameInfo(ByVal fi As FileInfo)
        Dim _filecontent As String = File.ReadAllText(fi.FullName)
        Dim gamedict As Dictionary(Of String, Object) = js.DeserializeObject(_filecontent)

        Dim game As New Game(gamedict)

        ' Handle VS Stats (GRAVESvsTWISTEDFATE)
        If game.Teams(game.Teams.Keys(0)).HasChampions({GAME_CHAMPION_GRAVES}) And game.Teams(game.Teams.Keys(1)).HasChampions({GAME_CHAMPION_TWISTEDFATE}) Then
            If game.Teams(game.Teams.Keys(0)).DidWin Then
                Stats_GRAVESvsTWISTEDFATE.WinCounter += 1
            Else
                Stats_GRAVESvsTWISTEDFATE.LoseCounter += 1
            End If
        ElseIf game.Teams(game.Teams.Keys(1)).HasChampions({GAME_CHAMPION_GRAVES}) And game.Teams(game.Teams.Keys(0)).HasChampions({GAME_CHAMPION_TWISTEDFATE}) Then
            If game.Teams(game.Teams.Keys(1)).DidWin Then
                Stats_GRAVESvsTWISTEDFATE.WinCounter += 1
            Else
                Stats_GRAVESvsTWISTEDFATE.LoseCounter += 1
            End If
        End If

        ' Handle VS Stats (GRAVESandTWISTEDFATEvsGANGPLANK)
        If game.Teams(game.Teams.Keys(0)).HasChampions({GAME_CHAMPION_GRAVES, GAME_CHAMPION_TWISTEDFATE}) And game.Teams(game.Teams.Keys(1)).HasChampions({GAME_CHAMPION_GANGPLANK}) Then
            If game.Teams(game.Teams.Keys(0)).DidWin Then
                Stats_GRAVESandTWISTEDFATEvsGANGPLANK.WinCounter += 1
            Else
                Stats_GRAVESandTWISTEDFATEvsGANGPLANK.LoseCounter += 1
            End If
        ElseIf game.Teams(game.Teams.Keys(1)).HasChampions({GAME_CHAMPION_GRAVES, GAME_CHAMPION_TWISTEDFATE}) And game.Teams(game.Teams.Keys(0)).HasChampions({GAME_CHAMPION_GANGPLANK}) Then
            If game.Teams(game.Teams.Keys(1)).DidWin Then
                Stats_GRAVESandTWISTEDFATEvsGANGPLANK.WinCounter += 1
            Else
                Stats_GRAVESandTWISTEDFATEvsGANGPLANK.LoseCounter += 1
            End If
        End If

        ' Handle VS Stats (MISSFORTUNEvsGANGPLANK)
        If game.Teams(game.Teams.Keys(0)).HasChampions({GAME_CHAMPION_MISSFORTUNE}) And game.Teams(game.Teams.Keys(1)).HasChampions({GAME_CHAMPION_GANGPLANK}) Then
            If game.Teams(game.Teams.Keys(0)).DidWin Then
                Stats_MISSFORTUNEvsGANGPLANK.WinCounter += 1
            Else
                Stats_MISSFORTUNEvsGANGPLANK.LoseCounter += 1
            End If
        ElseIf game.Teams(game.Teams.Keys(1)).HasChampions({GAME_CHAMPION_MISSFORTUNE}) And game.Teams(game.Teams.Keys(0)).HasChampions({GAME_CHAMPION_GANGPLANK}) Then
            If game.Teams(game.Teams.Keys(1)).DidWin Then
                Stats_MISSFORTUNEvsGANGPLANK.WinCounter += 1
            Else
                Stats_MISSFORTUNEvsGANGPLANK.LoseCounter += 1
            End If
        End If

        For Each _team As Team In game.Teams.Values
            ' Handle Champion Stats
            Dim _bans As List(Of Int32) = game.Bans
            For Each _championid As Int32 In GAME_CHAMPIONS
                If _bans.Contains(_championid) Then
                    Stats_Champions(_championid).BanCounter += 1
                Else
                    Stats_Champions(_championid).NonBanCounter += 1
                End If
            Next

            ' Handle Team Stats
            If _team.DidWin Then
                If _team.HadFirstBlood Then Stats_FirstBlood.WinCounter += 1
                If _team.HadFirstTower Then Stats_FirstTower.WinCounter += 1
                If _team.HadFirstInhibitor Then Stats_FirstInhibitor.WinCounter += 1
                If _team.HadFirstBaron Then Stats_FirstBaron.WinCounter += 1
                If _team.HadFirstDragon Then Stats_FirstDragon.WinCounter += 1
                If _team.HadFifthDragon Then Stats_FifthDragon.WinCounter += 1
            Else
                If _team.HadFirstBlood Then Stats_FirstBlood.LoseCounter += 1
                If _team.HadFirstTower Then Stats_FirstTower.LoseCounter += 1
                If _team.HadFirstInhibitor Then Stats_FirstInhibitor.LoseCounter += 1
                If _team.HadFirstBaron Then Stats_FirstBaron.LoseCounter += 1
                If _team.HadFirstDragon Then Stats_FirstDragon.LoseCounter += 1
                If _team.HadFifthDragon Then Stats_FifthDragon.LoseCounter += 1
            End If

            For Each _player As Player In _team.Players.Values
                ' Handle Champion Stats
                Stats_Champions(_player.ChampionID).GameCounter += 1
                Stats_Champions(_player.ChampionID).KillCounter += _player.Kills
                Stats_Champions(_player.ChampionID).AssistCounter += _player.Assists
                Stats_Champions(_player.ChampionID).DeathCounter += _player.Deaths
                If _team.DidWin Then
                    Stats_Champions(_player.ChampionID).WinCounter += 1
                Else
                    Stats_Champions(_player.ChampionID).LoseCounter += 1
                End If

                Dim _BrawlerID As Int32 = _player.BrawlerID
                If _BrawlerID > 0 Then
                    ' Handle Brawlers
                    Stats_Brawlers(_BrawlerID).GameCounter += 1
                    Stats_Champions(_player.ChampionID).SubStats(_BrawlerID).GameCounter += 1
                    Stats_Brawlers(_BrawlerID).SubStats(_player.ChampionID).GameCounter += 1
                    If _team.DidWin Then
                        Stats_Brawlers(_BrawlerID).WinCounter += 1
                        Stats_Champions(_player.ChampionID).SubStats(_BrawlerID).WinCounter += 1
                        Stats_Brawlers(_BrawlerID).SubStats(_player.ChampionID).WinCounter += 1
                    Else
                        Stats_Brawlers(_BrawlerID).LoseCounter += 1
                        Stats_Champions(_player.ChampionID).SubStats(_BrawlerID).LoseCounter += 1
                        Stats_Brawlers(_BrawlerID).SubStats(_player.ChampionID).LoseCounter += 1
                    End If

                    ' Handle BrawlerUpgrades
                    Dim _BrawlerItemIDs As List(Of Int32) = _player.BrawlerItemIDs
                    For Each _validID As Int32 In BW_BRAWLERSUPGRADES
                        If _BrawlerItemIDs.Contains(_validID) Then
                            Stats_Brawlers(_BrawlerID).SubStats(_validID).GameCounter += 1
                            If _team.DidWin Then
                                Stats_Brawlers(_BrawlerID).SubStats(_validID).WinCounter += 1
                            Else
                                Stats_Brawlers(_BrawlerID).SubStats(_validID).LoseCounter += 1
                            End If
                        Else
                            Stats_Brawlers(_BrawlerID).SubStats(_validID).NonGameCounter += 1
                        End If
                    Next

                    ' Handle Other Brawlers
                    For Each _stats As KeyValuePair(Of Int32, Winrate) In Stats_Brawlers
                        If Not _stats.Key = _BrawlerID Then
                            _stats.Value.NonGameCounter += 1
                            Stats_Champions(_player.ChampionID).SubStats(_stats.Key).NonGameCounter += 1
                        End If
                    Next

                    ' Handle Other Champions
                    For Each _stats As KeyValuePair(Of Int32, Winrate) In Stats_Champions
                        If Not _stats.Key = _player.ChampionID Then
                            _stats.Value.NonGameCounter += 1
                            Stats_Brawlers(_BrawlerID).SubStats(_stats.Key).NonGameCounter += 1
                        End If
                    Next
                End If

                ' Handle AllIlligalItems
                If _player.HasIlligalItems Then
                    Stats_TotalIlligalItems.GameCounter += 1
                    If _team.DidWin Then
                        Stats_TotalIlligalItems.WinCounter += 1
                    Else
                        Stats_TotalIlligalItems.LoseCounter += 1
                    End If
                Else
                    Stats_TotalIlligalItems.NonGameCounter += 1
                End If

                ' Handle IligalItems
                Dim _IlligalItemIDs As List(Of Int32) = _player.IlligalItemIDs
                For Each _validID As Int32 In BW_ILLIGALITEMS
                    If _IlligalItemIDs.Contains(_validID) Then
                        Stats_IlligalItems(_validID).GameCounter += 1
                        Stats_Champions(_player.ChampionID).SubStats(_validID).GameCounter += 1
                        Stats_IlligalItems(_validID).SubStats(_player.ChampionID).GameCounter += 1
                        If _team.DidWin Then
                            Stats_IlligalItems(_validID).WinCounter += 1
                            Stats_Champions(_player.ChampionID).SubStats(_validID).WinCounter += 1
                            Stats_IlligalItems(_validID).SubStats(_player.ChampionID).WinCounter += 1
                        Else
                            Stats_IlligalItems(_validID).LoseCounter += 1
                            Stats_Champions(_player.ChampionID).SubStats(_validID).LoseCounter += 1
                            Stats_IlligalItems(_validID).SubStats(_player.ChampionID).LoseCounter += 1
                        End If
                    Else
                        Stats_IlligalItems(_validID).NonGameCounter += 1
                        Stats_Champions(_player.ChampionID).SubStats(_validID).NonGameCounter += 1
                        Stats_IlligalItems(_validID).SubStats(_player.ChampionID).NonGameCounter += 1
                    End If
                Next
            Next
        Next

    End Sub

    Public Sub Export(ByVal dir As DirectoryInfo)
        If Not dir.Exists Then dir.Create()

        Dim fiBrawlers As New FileInfo(Path.Combine(dir.FullName, "stats_brawlers.js"))
        If fiBrawlers.Exists Then fiBrawlers.Delete()

        Dim fiIlligalItems As New FileInfo(Path.Combine(dir.FullName, "stats_illigalitems.js"))
        If fiIlligalItems.Exists Then fiIlligalItems.Delete()

        Dim fiChampions As New FileInfo(Path.Combine(dir.FullName, "stats_champions.js"))
        If fiChampions.Exists Then fiChampions.Delete()

        Dim fiOther As New FileInfo(Path.Combine(dir.FullName, "stats_other.js"))
        If fiOther.Exists Then fiOther.Delete()

        Dim arrBrawlers As New List(Of Object)()
        For Each _stats As Winrate In Stats_Brawlers.Values
            arrBrawlers.Add(_stats.ToJSONOnject())
        Next
        File.WriteAllText(fiBrawlers.FullName, "var stats_brawlers = " & js.Serialize(arrBrawlers) & ";")

        Dim arrIlligalItems As New List(Of Object)()
        For Each _stats As Winrate In Stats_IlligalItems.Values
            arrIlligalItems.Add(_stats.ToJSONOnject())
        Next
        File.WriteAllText(fiIlligalItems.FullName, "var stats_illigalitems = " & js.Serialize(arrIlligalItems) & ";")

        Dim arrChampions As New List(Of Object)()
        For Each _stats As Winrate In Stats_Champions.Values
            arrChampions.Add(_stats.ToJSONOnject())
        Next
        File.WriteAllText(fiChampions.FullName, "var stats_champions = " & js.Serialize(arrChampions) & ";")

        Dim arrOther As New List(Of Object)()
        arrOther.Add(Stats_TotalIlligalItems.ToJSONOnject())
        arrOther.Add(Stats_FirstBlood.ToJSONOnject())
        arrOther.Add(Stats_FirstTower.ToJSONOnject())
        arrOther.Add(Stats_FirstInhibitor.ToJSONOnject())
        arrOther.Add(Stats_FirstBaron.ToJSONOnject())
        arrOther.Add(Stats_FirstDragon.ToJSONOnject())
        arrOther.Add(Stats_FifthDragon.ToJSONOnject())
        arrOther.Add(Stats_GRAVESvsTWISTEDFATE.ToJSONOnject())
        arrOther.Add(Stats_GRAVESandTWISTEDFATEvsGANGPLANK.ToJSONOnject())
        arrOther.Add(Stats_MISSFORTUNEvsGANGPLANK.ToJSONOnject())
        File.WriteAllText(fiOther.FullName, "var stats_other = " & js.Serialize(arrOther) & ";")
    End Sub

    Public Overrides Function ToString() As String
        Dim rtn As String = ""
        rtn &= Stats_TotalIlligalItems.ToString() & vbCrLf & vbCrLf
        rtn &= Stats_FirstBlood.ToString() & vbCrLf & vbCrLf
        rtn &= Stats_FirstTower.ToString() & vbCrLf & vbCrLf
        rtn &= Stats_FirstInhibitor.ToString() & vbCrLf & vbCrLf
        rtn &= Stats_FirstBaron.ToString() & vbCrLf & vbCrLf
        rtn &= Stats_FirstDragon.ToString() & vbCrLf & vbCrLf
        rtn &= Stats_FifthDragon.ToString() & vbCrLf & vbCrLf
        rtn &= Stats_GRAVESvsTWISTEDFATE.ToString() & vbCrLf & vbCrLf
        rtn &= Stats_GRAVESandTWISTEDFATEvsGANGPLANK.ToString() & vbCrLf & vbCrLf
        rtn &= Stats_MISSFORTUNEvsGANGPLANK.ToString() & vbCrLf & vbCrLf
        For Each _stats As Winrate In Stats_Brawlers.Values
            rtn &= _stats.ToString() & vbCrLf & vbCrLf
        Next
        For Each _stats As Winrate In Stats_IlligalItems.Values
            rtn &= _stats.ToString() & vbCrLf & vbCrLf
        Next
        For Each _stats As Winrate In Stats_Champions.Values
            rtn &= _stats.ToString() & vbCrLf & vbCrLf
        Next
        Return rtn
    End Function
End Class
