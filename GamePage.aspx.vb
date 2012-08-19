
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
            my_hand.Text &= c.ToString & " | "
        Next

        If Not game.current_round Is Nothing Then

            If game.current_round.who = player.name Then
                Select Case game.current_round.status
                    Case RoundStatus.inout
                        btn_in.Visible = True
                        btn_out.Visible = True
                        timer.Enabled = False
                    Case RoundStatus.change
                        If pnl_change.Visible = False Then
                            pnl_change.Visible = True
                            'lbl_remain.Text = game.current_round.remain
                            change_list.Items.Clear()
                            For i As Integer = 0 To player.hand.Count - 1
                                change_list.Items.Add(New ListItem(player.hand(i).ToString, i))
                            Next
                            timer.Enabled = False
                        End If

                End Select
            End If
        End If

    End Sub

    Protected Sub btn_in_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_in.Click
        game.current_round.inout(True)
        btn_in.Visible = False
        btn_out.Visible = False
        timer.Enabled = True
    End Sub

    Protected Sub btn_out_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_out.Click
        game.current_round.inout(False)
        btn_in.Visible = False
        btn_out.Visible = False
        timer.Enabled = True
    End Sub

<<<<<<< HEAD
    Protected Sub btn_change_Click(sender As Object, e As System.EventArgs) Handles btn_change.Click
=======
    Protected Sub btn_change_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_change.Click
        pnl_change.Visible = False
        timer.Enabled = True
>>>>>>> 55b02d22f6866484249f0e8add59ec73aaf9238b
        Dim change_num As New List(Of Integer)
        For i As Integer = 0 To change_list.Items.Count - 1
            If change_list.Items(i).Selected Then
                change_num.Add(i)
            End If
        Next
        game.current_round.change(change_num)
        pnl_change.Visible = False
        timer.Enabled = True
        change_list.Items.Clear()
    End Sub

    Protected Sub btn_quit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quit.Click
        Session("player") = Nothing

    End Sub
End Class
