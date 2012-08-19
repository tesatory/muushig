
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
        my_deck.Deal(5, hands)
        For i As Integer = 0 To 4
            Response.Write("<br/>")
            Response.Write(hands(i).ToString)
        Next



    End Sub
End Class
