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
    Public players As List(Of Player)
    Private PLAYER_WAIT_TIMEOUT As Integer = 10
    Private MIN_PLAYER_NUM As Integer = 2
    Public current_round As Round

    Public Sub New()
        players = New List(Of Player)
        status = GameStatus.WAITING_PLAYERS
        rand = New Random
    End Sub

    Public Sub AddPlayer(ByVal p As Player)
        If status = GameStatus.WAITING_PLAYERS Then
            players.Add(p)
        End If
    End Sub

    Public Sub RemovePlayer(ByVal p As Player)
        players.Remove(p)
    End Sub

    Public Function IsReadyToStart() As Boolean
        If players.Count >= MIN_PLAYER_NUM Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub ClearInactivePlayers()
        For i As Integer = players.Count - 1 To 0 Step -1
            If players(i).last_active_time.AddSeconds(PLAYER_WAIT_TIMEOUT).CompareTo(Now) < 0 Then
                players.RemoveAt(i)
                If status = GameStatus.STARTED Or status = GameStatus.STARTING Then
                    status = GameStatus.WAITING_PLAYERS
                End If
            End If
        Next
    End Sub

    Public Sub PlayerReady()
        status = GameStatus.STARTING
        Dim ready As Boolean = True
        For Each p As Player In players
            If p.status <> PlayerStatus.IN_GAME Then
                ready = False
            End If
        Next

        If ready Then Start()
    End Sub

    Private Sub Start()
        dealer_ind = rand.Next Mod players.Count
        current_round = New Round(players, players(dealer_ind).name)

        status = GameStatus.STARTED
    End Sub

    Public Sub RoundFinished()
        Dim plr As New List(Of Player)
        For Each p In players
            If p.total_score <= 0 Then GameFinished()
            plr.Add(p)
        Next
        dealer_ind = (dealer_ind + 1) Mod plr.Count
        current_round = New Round(plr, players(dealer_ind).name)
    End Sub

    Public Sub GameFinished()

    End Sub

End Class
