Public Class Player
    Public Property BoughtItems As New List(Of Int32)()
    Public Property ID As Int32 = -1
    Public Property ChampionID As Int32 = -1
    Public Property Kills As Int32 = 0
    Public Property Deaths As Int32 = 0
    Public Property Assists As Int32 = 0

    Public ReadOnly Property BrawlerID As Int32
        Get
            For Each _validid As Int32 In StatCollection.BW_BRAWLERS
                If BoughtItems.Contains(_validid) Then Return _validid
            Next
            Return -1
        End Get
    End Property
    Public ReadOnly Property BrawlerItemIDs As List(Of Int32)
        Get
            Dim rtn As New List(Of Int32)()
            For Each _validid As Int32 In StatCollection.BW_BRAWLERSUPGRADES
                If BoughtItems.Contains(_validid) Then rtn.Add(_validid)
            Next
            Return rtn
        End Get
    End Property
    Public ReadOnly Property IlligalItemIDs As List(Of Int32)
        Get
            Dim rtn As New List(Of Int32)()
            For Each _validid As Int32 In StatCollection.BW_ILLIGALITEMS
                If BoughtItems.Contains(_validid) Then rtn.Add(_validid)
            Next
            Return rtn
        End Get
    End Property
    Public ReadOnly Property HasIlligalItems As Boolean
        Get
            For Each _validid As Int32 In StatCollection.BW_ILLIGALITEMS
                If BoughtItems.Contains(_validid) Then Return True
            Next
            Return False
        End Get
    End Property

    Public Sub New(ByVal dict As Dictionary(Of String, Object), ByVal _frames As Object())
        ID = dict("participantId")
        ChampionID = dict("championId")
        Kills = dict("stats")("kills")
        Deaths = dict("stats")("deaths")
        Assists = dict("stats")("assists")

        For Each _frame As Dictionary(Of String, Object) In _frames
            If _frame.ContainsKey("events") Then
                Dim _events As Object() = _frame("events")
                For Each _event As Dictionary(Of String, Object) In _events
                    Dim _eventType As String = _event("eventType")

                    'Handle Itempurchases
                    If _eventType = "ITEM_PURCHASED" Then
                        Dim _participantId As Int32 = _event("participantId")

                        If _participantId = ID Then
                            BoughtItems.Add(_event("itemId"))
                        End If
                    End If
                Next
            End If
        Next
    End Sub
End Class
