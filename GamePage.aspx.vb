
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

        player.last_active_time = Now

        lbl_players_name.Text = game.GetPlayersList

        my_hand.Text = ""
        For Each c As Card In player.hand
            my_hand.Text &= c.ToString & " "
        Next

        If Not game.current_round Is Nothing Then

            If game.current_round.who = player.name Then
                Select Case game.current_round.status
                    Case RoundStatus.inout
                        btn_in.Visible = True
                        btn_out.Visible = True
                        timer.Enabled = False
                    Case RoundStatus.change
                        pnl_change.Visible = True
                        change_list.Items.Clear()
                        For Each c As Card In player.hand
                            change_list.Items.Add(c.ToString)
                        Next
                        timer.Enabled = False
                End Select
            End If
        End If

    End Sub

    Protected Sub btn_in_Click(sender As Object, e As System.EventArgs) Handles btn_in.Click
        game.current_round.inout(True)
        btn_in.Visible = False
        btn_out.Visible = False
        timer.Enabled = True
    End Sub

    Protected Sub btn_out_Click(sender As Object, e As System.EventArgs) Handles btn_out.Click
        game.current_round.inout(False)
        btn_in.Visible = False
        btn_out.Visible = False
        timer.Enabled = True
    End Sub

    Protected Sub btn_change_Click(sender As Object, e As System.EventArgs) Handles btn_change.Click
        pnl_change.Visible = False
        timer.Enabled = True
        Dim change_num As New List(Of Integer)
        For i As Integer = 0 To change_list.Items.Count - 1
            If change_list.Items(i).Selected Then
                change_num.Add(i)
            End If
        Next
        game.current_round.change(change_num)
    End Sub

    Protected Sub btn_quit_Click(sender As Object, e As System.EventArgs) Handles btn_quit.Click
        Session("player") = Nothing

    End Sub
End Class
