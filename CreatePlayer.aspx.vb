
Partial Class CreatePlayer
    Inherits System.Web.UI.Page

    Protected Sub btn_ok_Click(sender As Object, e As System.EventArgs) Handles btn_ok.Click
        Dim game As Game = Application("game")

        If (game Is Nothing) Then
            Response.Redirect("./Start.aspx")
        End If

        Dim new_player As Player
        new_player = New Player(tb_player_name.Text)

        Session("player") = new_player
        game.AddPlayer(new_player)

        Response.Redirect("./Start.aspx")
    End Sub
End Class
