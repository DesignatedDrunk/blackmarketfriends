Imports System.Web.Script.Serialization

Public Class Winrate
    Public Property ID As String
    Public Property SubStats As New Dictionary(Of String, Winrate)()

    'WinRate
    Public Property WinCounter As ULong = 0
    Public Property LoseCounter As ULong = 0
    Public ReadOnly Property WinRate As Double
        Get
            If WinCounter <= 0 Then Return 0
            If LoseCounter <= 0 Then Return 100
            Return (WinCounter / (WinCounter + LoseCounter)) * 100.0
        End Get
    End Property

    'PickRate
    Public Property GameCounter As ULong = 0
    Public Property NonGameCounter As ULong = 0
    Public ReadOnly Property PickRate As Double
        Get
            If GameCounter <= 0 Then Return 0
            If NonGameCounter <= 0 Then Return 100
            Return (GameCounter / (GameCounter + NonGameCounter)) * 100.0
        End Get
    End Property

    'BanRate
    Public Property BanCounter As ULong = 0
    Public Property NonBanCounter As ULong = 0
    Public ReadOnly Property BanRate As Double
        Get
            If BanCounter <= 0 Then Return 0
            If NonBanCounter <= 0 Then Return 100
            Return (BanCounter / (BanCounter + NonBanCounter)) * 100.0
        End Get
    End Property

    'KDA
    Public Property KillCounter As ULong = 0
    Public Property DeathCounter As ULong = 0
    Public Property AssistCounter As ULong = 0
    Public ReadOnly Property KDA As Double
        Get
            If KillCounter <= 0 And AssistCounter <= 0 Then Return 0
            Return (KillCounter + AssistCounter) / IIf(DeathCounter <= 0, 1, DeathCounter)
        End Get
    End Property

    'Pick / BanRate
    Public ReadOnly Property PickBanRate As Double
        Get
            Return PickRate + BanRate
        End Get
    End Property

    Public Sub New(ByVal _id As String)
        ID = _id
    End Sub

    Public Function ToJSONOnject() As Dictionary(Of String, Object)
        Dim d As New Dictionary(Of String, Object)()
        d.Add("id", ID)

        d.Add("winrate", WinRate)
        d.Add("winrate_positive", WinCounter)
        d.Add("winrate_total", WinCounter + LoseCounter)

        d.Add("pickrate", PickRate)
        d.Add("pickrate_positive", GameCounter)
        d.Add("pickrate_total", GameCounter + NonGameCounter)

        d.Add("banrate", BanRate)
        d.Add("banrate_positive", BanCounter)
        d.Add("banrate_total", BanCounter + NonBanCounter)

        d.Add("kda", KDA)
        d.Add("kda_kills", KillCounter)
        d.Add("kda_assists", AssistCounter)
        d.Add("kda_deaths", DeathCounter)

        Dim lst As New List(Of Object)()
        For Each wr As Winrate In SubStats.Values
            lst.Add(wr.ToJSONOnject())
        Next
        d.Add("substats", lst.ToArray())

        Return d
    End Function

    Public Overrides Function ToString() As String
        Dim rtn As String = "[" & ID & "] "
        rtn &= vbCrLf & "Winrate " & WinRate & " (" & GameCounter & " / " & NonGameCounter & ")"
        rtn &= vbCrLf & "Pickrate " & PickRate
        rtn &= vbCrLf & "Banrate " & BanRate
        rtn &= vbCrLf & "Pickbanrate " & PickBanRate

        For Each _stats As Winrate In SubStats.Values
            rtn &= vbCrLf & "(( " & _stats.ToString() & " ))"
        Next

        Return rtn
    End Function
End Class
