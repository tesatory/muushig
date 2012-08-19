
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

        my_hand.Text = ""
        For Each c As Card In player.hand
            my_hand.Text &= c.ToString & " "
        Next

        If Not game.current_round Is Nothing Then
            If game.current_round.who = player.name Then
                If game.current_round.status = RoundStatus.inout Then
                    btn_in.Visible = True
                    btn_out.Visible = True
                End If
            End If
        End If

    End Sub

    Protected Sub btn_in_Click(sender As Object, e As System.EventArgs) Handles btn_in.Click
        game.current_round.inout(True)
        btn_in.Visible = False
        btn_out.Visible = False
    End Sub

    Protected Sub btn_out_Click(sender As Object, e As System.EventArgs) Handles btn_out.Click
        game.current_round.inout(False)
        btn_in.Visible = False
        btn_out.Visible = False
    End Sub
End Class
