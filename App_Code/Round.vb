Imports Microsoft.VisualBasic

Public Enum RoundStatus
    inout
    change
    change_h
    play
    playing
    finish
End Enum

Public Class Round
    Public plr As Dictionary(Of String, Player)
    Public dealer As String
    Public deck As Deck
    Public who As String
    Public huzur As Card
    Public small As String
    Public beginplr As String
    Public gazar As Card
    Public remain As Integer = 6
    Public status As RoundStatus = RoundStatus.inout


    Public Sub New(ByVal _plr As List(Of Player), ByVal dlr As String)
        plr = New Dictionary(Of String, Player)
        deck = New Deck
        deck.Shuffle()
        For Each p As Player In _plr
            plr.Add(p.name, p)
            p.hand.AddRange(deck.Deal(5))
        Next
        dealer = dlr
        who = dealer
        mext()
        huzur = deck.Deal(1)(0)
    End Sub

    Private Sub mext()
        For i As Integer = 0 To plr.Count - 1
            If plr.Keys(i) = who Then
                who = plr.Keys((i + 1) Mod plr.Count)
                Exit For
            End If
        Next
    End Sub

    Public Sub inout(ByVal io As Boolean)
        If io = False Then
            plr.Remove(who)
        End If
        If plr.Count = 2 Then
            status = RoundStatus.change
            who = dealer
        End If
        If who = dealer Then
            status = RoundStatus.change
        End If
        mext()
    End Sub

    Public Sub change(ByVal num As List(Of Integer))

        If status = RoundStatus.change_h Then
            'plr(dealer).hand.RemoveAt(num(0))
            'plr(dealer).hand.Add(huzur)
            who = dealer
            plr(who).hand(num(0)) = huzur
            status = RoundStatus.play
            mext()
            small = who
            Return
        End If

        remain = remain - num.Count
        Diagnostics.Debug.Assert(remain >= 0)

        For i As Integer = 0 To num.Count - 1
            'plr(who).hand.RemoveAt(num(i))
            plr(who).hand(num(i)) = deck.Deal(1)(0)
        Next
        'plr(who).hand.AddRange(deck.Deal(num.Count))

        If remain = 0 Then
            status = RoundStatus.change_h
            who = dealer
            'mende

            Return
        End If
        If who = dealer Then
            status = RoundStatus.change_h
            Return
        End If
        mext()
    End Sub

    Public Sub Play(ByVal num As Integer)

        If status = RoundStatus.play Then
            beginplr = small
            If huzur.suit <> SuitType.Spade Then
                gazar = New Card(1, SuitType.Spade)
            End If
            If huzur.suit = SuitType.Spade Then
                gazar = New Card(1, SuitType.Diamond)
            End If
            status = RoundStatus.playing
        End If
        If status = RoundStatus.playing Then
            Up(gazar, plr(who).hand(num)) ', num)
            plr(who).hand.RemoveAt(num)
            mext()
            If who = beginplr Then
                If plr(who).hand.Count = 0 Then
                    status = RoundStatus.finish
                End If
                status = RoundStatus.play
            End If
        End If
    End Sub



    Private Sub Up(ByVal card1 As Card, ByVal card2 As Card) ', ByVal num As Integer)
        If huzur.suit = card1.suit Then
            If card2.suit = card1.suit Then
                If card2.rank > card1.rank Then
                    small = who
                    gazar = card2 ' plr(who).hand(num)
                End If
            End If
        End If

        If huzur.suit <> card1.suit Then
            If card2.suit = huzur.suit Then
                small = who
                gazar = card2 ' plr(who).hand(num)
            End If
            If card2.suit <> huzur.suit Then
                If card1.rank < card2.rank Then
                    small = who
                    gazar = card2 ' plr(who).hand(num)
                End If
            End If
        End If
    End Sub

End Class
