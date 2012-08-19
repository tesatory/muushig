
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim my_deck As New Deck
        my_deck.Shuffle()
        Response.Write(my_deck.ToString)
    End Sub
End Class
