Imports Microsoft.VisualBasic

Public Enum RoundStatus
    inout
    change
    change_h
    play
    playing
    fault
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
    Public remain As Integer
    Public status As RoundStatus


    Public Sub New(ByVal _plr As List(Of Player), ByVal dlr As String)
        plr = New Dictionary(Of String, Player)
        deck = New Deck
        deck.Shuffle()
        For Each p As Player In _plr
            plr.Add(p.name, p)
            p.hand.AddRange(deck.Deal(5))
        Next
        If plr.Count = 2 Then
            status = RoundStatus.change
        Else
            status = RoundStatus.inout
        End If
        dealer = dlr
        who = dealer
        mext()
        huzur = deck.Deal(1)(0)
        remain = deck.cards.Count
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
        Dim delete As String

        If who = dealer Then
            status = RoundStatus.change
        End If

        If io = False Then
            delete = who

            If plr.Count = 3 Then
                status = RoundStatus.change
                who = dealer
            End If

            mext()
            plr.Remove(delete)
        Else
            mext()
        End If




    End Sub

    Public Sub change(ByVal num As List(Of Integer))

        If status = RoundStatus.change_h Then
            'plr(dealer).hand.RemoveAt(num(0))
            'plr(dealer).hand.Add(huzur)
            who = dealer
            plr(who).hand(num(0)) = huzur
            status = RoundStatus.play
            mext()
            'For i As Integer = 0 To plr.Count - 1
            '    'plr(plr.Keys(i)).total_score -= plr(plr.Keys(i)).round_score
            '    If plr(plr.Keys(i)).round_score = 0 Then
            '        plr(plr.Keys(i)).total_score += 5
            '    End If
            '    plr(plr.Keys(i)).round_score = 0
            'Next
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
            beginplr = who
<<<<<<< HEAD
            small = who
            
=======
>>>>>>> 14faefa0e5119192603a261b523cfff428ca30fe
            If huzur.suit <> SuitType.Spade Then
                gazar = New Card(1, SuitType.Spade)
            End If
            If huzur.suit = SuitType.Spade Then
                gazar = New Card(1, SuitType.Diamond)
            End If
            status = RoundStatus.playing
        End If
        If status = RoundStatus.playing Then
            Up(gazar, who, num) 'plr(who).hand(num)) , num)
            plr(who).hand.RemoveAt(num)
            mext()
            If who = beginplr Then
                If plr(who).hand.Count = 0 Then
                    status = RoundStatus.finish
<<<<<<< HEAD
                    who = small
                    plr(who).round_score += 1
                    For i As Integer = 0 To plr.Count - 1
                        plr(plr.Keys(i)).total_score -= plr(plr.Keys(i)).round_score

                        If plr(plr.Keys(i)).round_score = 0 Then
                            plr(plr.Keys(i)).total_score += 5
                        End If
                        plr(plr.Keys(i)).round_score = 0

                    Next
=======
>>>>>>> 14faefa0e5119192603a261b523cfff428ca30fe
                    Return
                End If
                status = RoundStatus.play
                who = small
                plr(who).round_score += 1

            End If
        End If
    End Sub

    Public Function card_can() As List(Of Integer)
        Dim samba1 As New List(Of Integer)
        Dim samba As New List(Of Integer)
        Select Case status
            Case RoundStatus.play
                For i As Integer = 0 To plr(who).hand.Count - 1
                    If plr(who).hand(i).suit = huzur.suit And plr(who).hand(i).rank = "14" Then
                        samba.Add(i)
                        Return samba
                    End If
                Next
                For i As Integer = 0 To plr(who).hand.Count - 1
                    samba.Add(i)
                Next
                Return samba

            Case RoundStatus.playing
                For i As Integer = 0 To plr(who).hand.Count - 1
                    If plr(who).hand(i).suit = gazar.suit Then
                        If plr(who).hand(i).suit = huzur.suit And plr(who).hand(i).rank > gazar.rank Then
                            samba.Add(i)
                        End If
                        samba1.Add(i)
                    End If
                Next
                If samba.Count <> 0 Then
                    Return samba
                ElseIf samba1.Count <> 0 Then
                    Return samba1
                End If

                For i As Integer = 0 To plr(who).hand.Count - 1
                    If plr(who).hand(i).suit = huzur.suit Then
                        samba.Add(i)
                    End If
                    samba1.Add(i)
                Next

                If samba.Count <> 0 Then
                    Return samba
                Else
                    Return samba1
                End If

            Case Else
                For i As Integer = 0 To plr(who).hand.Count - 1
                    samba.Add(i)
                Next
                Return samba
        End Select
    End Function

    Private Sub Up(ByVal card1 As Card, ByVal str As String, ByVal num As Integer)
        If huzur.suit = card1.suit Then
            If plr(str).hand(num).suit = card1.suit Then
                If plr(str).hand(num).rank > card1.rank Then
                    small = str
                    gazar = plr(str).hand(num) ' 
                End If
            End If
        End If

        If huzur.suit <> card1.suit Then
            If plr(str).hand(num).suit = huzur.suit Then
                small = str
                gazar = plr(str).hand(num) ' plr(who).hand(num)
            End If
            If plr(str).hand(num).suit <> huzur.suit Then
                If card1.rank < plr(str).hand(num).rank Then
                    small = str
                    gazar = plr(str).hand(num) ' plr(who).hand(num)
                End If
            End If
        End If
    End Sub

End Class
