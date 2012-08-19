
Partial Class Start
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Application("game") Is Nothing Then
            Application("game") = New Game
        End If

        If (Session("player") Is Nothing) Then
            Response.Redirect("./CreatePlayer.aspx")
        End If
        Dim player As Player = Session("player")
        player.last_active_time = Now
        player.status = PlayerStatus.ACTIVE

        Dim game As Game = Application("game")
        game.ClearInactivePlayers()

        If game.IsPlayerExist(player.name) = False Then
            game.AddPlayer(player)
        End If

        lbl_players_name.Text = game.GetPlayersList

        If game.IsReadyToStart Then
            btn_start.Enabled = True
        Else
            btn_start.Enabled = False
        End If
    End Sub

    Protected Sub btn_start_Click(sender As Object, e As System.EventArgs) Handles btn_start.Click
        Dim player As Player = Session("player")
        player.status = PlayerStatus.IN_GAME
        Response.Redirect("./GamePage.aspx")
    End Sub
End Class
