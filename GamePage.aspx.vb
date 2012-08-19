
Partial Class GamePage
    Inherits System.Web.UI.Page
    Private player As Player
    Private game As Game

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        player = Session("player")
        game = Application("game")

        If (game Is Nothing) Or (player Is Nothing) Then
            Response.Redirect("./Start.aspx")
        End If

        lbl_players_name.Text = game.GetPlayersList

        If my_hand.Text = "" And game.status = GameStatus.STARTED Then
            For Each c As Card In player.hand
                my_hand.Text &= c.ToString & " "
                up_my_hand.Update()
            Next
        End If
    End Sub
End Class
