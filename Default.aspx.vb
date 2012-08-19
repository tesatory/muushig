
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim my_deck As New Deck
        my_deck.Shuffle()
        Response.Write(my_deck.ToString)

        Dim hands(4) As Hand
        For i As Integer = 0 To 4
            hands(i) = New Hand
        Next

        Response.Write("<br/>")
        Response.Write(my_deck.cards.Count.ToString)

    End Sub
End Class
