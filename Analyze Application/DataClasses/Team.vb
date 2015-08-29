Public Class Team
    Public Property Players As New Dictionary(Of Int32, Player)()
    Public Property Bans As New List(Of Int32)()
    Public Property ID As Int32 = -1
    Public Property DidWin As Boolean = False

    Public Property HadFirstBlood As Boolean = False
    Public Property HadFirstTower As Boolean = False
    Public Property HadFirstInhibitor As Boolean = False
    Public Property HadFirstBaron As Boolean = False
    Public Property HadFirstDragon As Boolean = False
    Public Property HadFifthDragon As Boolean = False

    Public Sub New(ByVal _id As Int32)
        ID = _id
    End Sub

    Public Function HasChampions(ByVal _ids As Int32()) As Boolean
        For Each _id As Int32 In _ids
            Dim didfnd As Boolean = False
            For Each _player As Player In Players.Values
                If _player.ChampionID = _id Then
                    didfnd = True
                    Exit For
                End If
            Next
            If Not didfnd Then Return False
        Next
        Return True
    End Function
End Class
