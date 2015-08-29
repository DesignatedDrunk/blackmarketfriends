Public Class Game
    Public Property Teams As New Dictionary(Of Int32, Team)()
    Public ReadOnly Property Bans As List(Of Int32)
        Get
            Dim rtn As New List(Of Int32)()
            For Each t As Team In Teams.Values
                rtn.AddRange(t.Bans)
            Next
            Return rtn
        End Get
    End Property

    Public Sub New(ByVal dict As Dictionary(Of String, Object))
        ' Create Teams
        Dim _teams As Object() = dict("teams")
        For Each _team As Dictionary(Of String, Object) In _teams
            Dim t As New Team(_team("teamId"))
            If CType(_team("winner"), Boolean) Then t.DidWin = True
            If CType(_team("firstBlood"), Boolean) Then t.HadFirstBlood = True
            If CType(_team("firstTower"), Boolean) Then t.HadFirstTower = True
            If CType(_team("firstInhibitor"), Boolean) Then t.HadFirstInhibitor = True
            If CType(_team("firstBaron"), Boolean) Then t.HadFirstBaron = True
            If CType(_team("firstDragon"), Boolean) Then t.HadFirstDragon = True
            If CType(_team("dragonKills"), Int32) >= 5 Then t.HadFifthDragon = True

            ' Crashed on game without bans?
            If _team.ContainsKey("bans") Then
                Dim _bans As Object() = _team("bans")
                For Each _ban As Dictionary(Of String, Object) In _bans
                    Dim championID As Int32 = _ban("championId")
                    If championID > 0 Then t.Bans.Add(championID)
                Next
            End If
            Teams.Add(t.ID, t)
        Next

        ' Fill Teams
        Dim _frames As Object() = dict("timeline")("frames")
        Dim _participants As Object() = dict("participants")
        For Each _participant As Dictionary(Of String, Object) In _participants
            Teams(_participant("teamId")).Players.Add(_participant("participantId"), New Player(_participant, _frames))
        Next

    End Sub
End Class
