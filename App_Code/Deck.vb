Imports Microsoft.VisualBasic

Public Class Deck
    Public cards As Generic.List(Of Card)

    Public Sub New()
        cards = New Generic.List(Of Card)
        For i As Integer = 1 To 14
            cards.Add(New Card(i, SuitType.Club))
            cards.Add(New Card(i, SuitType.Diamond))
            cards.Add(New Card(i, SuitType.Heart))
            cards.Add(New Card(i, SuitType.Spade))
        Next
    End Sub

    Public Sub Shuffle()
        Dim rand As New Random
        Dim new_cards As New Generic.List(Of Card)
        For i As Integer = 1 To 52
            Dim n As Integer = rand.Next Mod cards.Count
            new_cards.Add(cards(n))
            cards.RemoveAt(n)
        Next
        cards = new_cards
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
