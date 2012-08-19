Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Enum GameStatus
    WAITING_PLAYERS
    STARTING
    STARTED
End Enum

Public Class Game
    Public status As GameStatus

    Public Sub New()
        players = New Dictionary(Of String, Player)
        status = GameStatus.WAITING_PLAYERS
    End Sub

    Public Sub AddPlayer(p As Player)
        If status = GameStatus.WAITING_PLAYERS Then
            players.Add(p.name, p)
        End If
    End Sub

    Public Function GetPlayersList() As String
        Dim sb As New StringBuilder
        For Each p As Player In players.Values
            sb.Append(p.name)
            If p.status = PlayerStatus.IN_GAME Then
                sb.Append(" [Тоглоомонд орсон]")
            End If
            sb.Append("<br/>")
        Next
        Return sb.ToString
    End Function

    Public Function IsReadyToStart() As Boolean
        If players.Count = PLAYER_NUM Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub ClearInactivePlayers()
        If status = GameStatus.WAITING_PLAYERS Then
            For i As Integer = players.Count - 1 To 0 Step -1
                If players.Values(i).last_active_time.AddSeconds(PLAYER_WAIT_TIMEOUT).CompareTo(Now) < 0 Then
                    players.Remove(players.Keys(i))
                End If
            Next
        End If
    End Sub

    Public Function IsPlayerExist(name As String) As Boolean
        If players.ContainsKey(name) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub PlayerReady()
        status = GameStatus.STARTED
        For Each p As Player In players.Values
            If p.status = PlayerStatus.ACTIVE Then
                status = GameStatus.STARTING
            End If
        Next

        If status = GameStatus.STARTED Then Start()
    End Sub

    Private Sub Start()

    End Sub

    Private players As Dictionary(Of String, Player)
    Private PLAYER_WAIT_TIMEOUT As Integer = 5
    Private PLAYER_NUM As Integer = 2


End Class
