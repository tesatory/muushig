
Partial Class CreatePlayer
    Inherits System.Web.UI.Page

    Protected Sub btn_ok_Click(sender As Object, e As System.EventArgs) Handles btn_ok.Click
        Dim new_player As Player
        new_player = New Player(tb_player_name.Text)

    End Sub
End Class
