Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class Deck
    Public cards As Stack(Of Card)


    Public Sub New()
        cards = New Stack(Of Card)
        For i As Integer = 1 To 14
            cards.Push(New Card(i, SuitType.Club))
            cards.Push(New Card(i, SuitType.Diamond))
            cards.Push(New Card(i, SuitType.Heart))
            cards.Push(New Card(i, SuitType.Spade))
        Next
    End Sub

    Public Sub Shuffle()
        Dim rand As New Random
        Dim shuffled_cards(cards.Count - 1) As Card
        Dim n As Integer
        For i As Integer = 0 To shuffled_cards.Length - 1
            n = rand.Next Mod shuffled_cards.Length
            While (Not shuffled_cards(n) Is Nothing)
                n = (n + 1) Mod shuffled_cards.Length
            End While
            shuffled_cards(n) = cards.Pop
        Next
        cards = New Stack(Of Card)

        For i As Integer = 0 To shuffled_cards.Length - 1
            cards.Push(shuffled_cards(i))
        Next

    End Sub

    Public Sub Deal(num_cards As Integer, hands() As Hand)
        For i As Integer = 1 To num_cards
            For j As Integer = 0 To hands.Length - 1
                hands(j).cards.Add(cards.Pop)
            Next
        Next
    End Sub


    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        For Each c As Card In cards
            sb.Append(c.ToString)
            sb.Append(" ")
        Next
        Return sb.ToString
    End Function
End Class
