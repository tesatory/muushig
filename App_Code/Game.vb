Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Enum GameStatus
    WAITING_PLAYERS
    STARTING
    STARTED
End Enum

Public Class Game

    Public status As GameStatus
    Public dealer_ind As Integer
    Private rand As Random

    Public Sub New()
        players = New Dictionary(Of String, Player)
        status = GameStatus.WAITING_PLAYERS
        rand = New Random
    End Sub

    Public Sub AddPlayer(ByVal p As Player)
        If status = GameStatus.WAITING_PLAYERS Then
            players.Add(p.name, p)
        End If
    End Sub

    Public Sub RemovePlayer(ByVal p As Player)
        players.Remove(p.name)
    End Sub

    Public Function GetPlayersList() As String
        Dim sb As New StringBuilder
        For Each p As Player In players.Values
            sb.Append(p.name)
            If p.status = PlayerStatus.IN_GAME Then
                sb.Append(" [холбогдсон]")
            End If
            If Not current_round Is Nothing Then
                If current_round.dealer = p.name Then
                    sb.Append(" [Ажил хийсэн]")
                End If
                If current_round.plr.ContainsKey(p.name) = False Then
                    sb.Append(" [өнжсөн]")
                End If
                If current_round.who = p.name Then
                    sb.Append(" [Ээлж]")
                End If
                sb.Append(" Оноо ")
                sb.Append(p.total_score)
            End If
            sb.Append("<br/>")
        Next
        Return sb.ToString
    End Function

    Public Function IsReadyToStart() As Boolean
        If players.Count >= MIN_PLAYER_NUM Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub ClearInactivePlayers()
        For i As Integer = players.Count - 1 To 0 Step -1
            If players.Values(i).last_active_time.AddSeconds(PLAYER_WAIT_TIMEOUT).CompareTo(Now) < 0 Then
                players.Remove(players.Keys(i))
                If status = GameStatus.STARTED Or status = GameStatus.STARTING Then
                    status = GameStatus.WAITING_PLAYERS
                End If
            End If
        Next
    End Sub

    Public Function IsPlayerExist(ByVal name As String) As Boolean
        If players.ContainsKey(name) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub PlayerReady()
        status = GameStatus.STARTING
        Dim ready As Boolean = True
        For Each p As Player In players.Values
            If p.status <> PlayerStatus.IN_GAME Then
                ready = False
            End If
        Next

        If ready Then Start()
    End Sub

    Private Sub Start()
        Dim plr As New List(Of Player)
        For Each p In players.Values
            plr.Add(p)
        Next
        dealer_ind = rand.Next Mod plr.Count
        current_round = New Round(plr, players.Keys(dealer_ind))

        status = GameStatus.STARTED
    End Sub

    Public Sub RoundFinished()
        Dim plr As New List(Of Player)
        For Each p In players.Values
            If p.total_score <= 0 Then GameFinished()
            plr.Add(p)
        Next
        dealer_ind = (dealer_ind + 1) Mod plr.Count
        current_round = New Round(plr, players.Keys(dealer_ind))
    End Sub

    Public Sub GameFinished()

    End Sub

    Private players As Dictionary(Of String, Player)
    Private PLAYER_WAIT_TIMEOUT As Integer = 10
    Private MIN_PLAYER_NUM As Integer = 2
    Public current_round As Round
End Class
