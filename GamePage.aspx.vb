
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

        UpdateGameStatus()
        UpdateRoundStatus()
    End Sub

    Private Sub UpdateGameStatus()
        lbl_players_name.Text = game.GetPlayersList

        my_hand.Text = ""
        For Each c As Card In player.hand
            my_hand.Text &= c.ToHtmlImg & "  "
        Next

        my_round_point.Text = ""
        For i As Integer = 1 To player.round_score
            my_round_point.Text &= Card.BackToHtmlImg & "  "
        Next

        my_score.Text = player.total_score
    End Sub

    Private Sub UpdateRoundStatus()
        If game.current_round Is Nothing Then
            Return
        End If

        If Not game.current_round.huzur Is Nothing Then
            lbl_huzur.Text = game.current_round.huzur.ToHtmlImg
        Else
            lbl_huzur.Text = Card.BackToHtmlImg
        End If


        If Not game.current_round.gazar Is Nothing Then
            lbl_gazar.Text = game.current_round.gazar.ToHtmlImg
        Else
            lbl_gazar.Text = ""
            For i As Integer = 1 To game.current_round.remain
                lbl_gazar.Text &= Card.BackToHtmlImg & "  "
            Next
        End If


        If game.current_round.who = player.name Then
            Select Case game.current_round.status
                Case RoundStatus.inout
                    btn_in.Visible = True
                    btn_out.Visible = True
                    timer.Enabled = False
                Case RoundStatus.change
                    If pnl_change.Visible = False Then
                        pnl_change.Visible = True
                        lbl_remain.Text = game.current_round.remain & " мод үлдсэн байна"
                        change_list.Items.Clear()
                        For i As Integer = 0 To player.hand.Count - 1
                            change_list.Items.Add(New ListItem(player.hand(i).ToString, i))
                        Next
                        timer.Enabled = False
                    End If
                Case RoundStatus.change_h
                    If pnl_change.Visible = False Then
                        pnl_change.Visible = True
                        lbl_remain.Text = "Газрын модоо авна уу"
                        change_list.Items.Clear()
                        For i As Integer = 0 To player.hand.Count - 1
                            change_list.Items.Add(New ListItem(player.hand(i).ToString, i))
                        Next
                        timer.Enabled = False
                    End If
                Case RoundStatus.play, RoundStatus.playing
                    If pnl_play.Visible = False Then
                        pnl_play.Visible = True
                        play_list.Items.Clear()
                        Dim possible_cards As List(Of Integer) = game.current_round.card_can
                        For i As Integer = 0 To player.hand.Count - 1
                            Dim item As New ListItem(player.hand(i).ToString, i)
                            If possible_cards.Contains(i) = False Then item.Enabled = False
                            play_list.Items.Add(item)
                        Next
                        For Each item As ListItem In play_list.Items
                            If item.Enabled Then
                                item.Selected = True
                                Exit For
                            End If
                        Next

                        timer.Enabled = False
                    End If

                Case RoundStatus.finish
                    game.RoundFinished()
            End Select
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

    Protected Sub btn_change_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_change.Click
        Dim change_num As New List(Of Integer)
        For i As Integer = 0 To change_list.Items.Count - 1
            If change_list.Items(i).Selected Then
                change_num.Add(i)
            End If
        Next
        If game.current_round.status = RoundStatus.change Then
            If change_num.Count > game.current_round.remain Then
                Return
            End If
        End If

        If game.current_round.status = RoundStatus.change_h Then
            If change_num.Count <> 1 Then
                Return
            End If
        End If

        game.current_round.change(change_num)
        pnl_change.Visible = False
        timer.Enabled = True
        change_list.Items.Clear()

    End Sub

    Protected Sub btn_play_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_play.Click
        Dim play_num As Integer
        For i As Integer = 0 To play_list.Items.Count - 1
            If play_list.Items(i).Selected Then
                play_num = i
            End If
        Next

        game.current_round.Play(play_num)
        pnl_play.Visible = False
        timer.Enabled = True
        play_list.Items.Clear()
    End Sub

    Protected Sub btn_quit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quit.Click
        Session("player") = Nothing

    End Sub

End Class
