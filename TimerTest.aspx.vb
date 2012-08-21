
Partial Class TimerTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lbl.Text = Now.ToString
        lbl2.Text = Now.ToString
        Threading.Thread.Sleep(5000)
    End Sub

    Protected Sub btn_off_Click(sender As Object, e As System.EventArgs) Handles btn_off.Click
        tmr.Enabled = False
    End Sub

    Protected Sub btn_on_Click(sender As Object, e As System.EventArgs) Handles btn_on.Click
        tmr.Enabled = True
    End Sub
End Class
