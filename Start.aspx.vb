
Partial Class Start
    Inherits System.Web.UI.Page
    Private player As Player
    Private game As Game

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Application("game") Is Nothing Then
            Application("game") = New Game
        End If

        If (Session("player") Is Nothing) Then
            Response.Redirect("./CreatePlayer.aspx")
        End If
        player = Session("player")
        player.last_active_time = Now
        player.status = PlayerStatus.ACTIVE

        game = Application("game")
        game.ClearInactivePlayers()

        If game.players.Contains(player) = False Then
            game.AddPlayer(player)
        End If

        lbl_players_name.Text = ""
        For Each p As Player In game.players
            lbl_players_name.Text &= p.name & "<br/>"
        Next

        If game.IsReadyToStart Then
            btn_start.Enabled = True
        Else
            btn_start.Enabled = False
        End If
    End Sub

    Protected Sub btn_start_Click(sender As Object, e As System.EventArgs) Handles btn_start.Click
        player.status = PlayerStatus.IN_GAME
        game.PlayerReady()
        Response.Redirect("./GamePage.aspx")
    End Sub

    Protected Sub btn_logout_Click(sender As Object, e As System.EventArgs) Handles btn_logout.Click
        game.players.Remove(player)
        Session.Remove("player")
        Response.Redirect("./CreatePlayer.aspx")
    End Sub
End Class
