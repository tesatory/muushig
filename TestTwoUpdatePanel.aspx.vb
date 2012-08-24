
Partial Class TestTwoUpdatePanel
    Inherits System.Web.UI.Page


    Protected Sub btn1_Click(sender As Object, e As System.EventArgs) Handles btn1.Click
        Session("cnt") = "A"
        lbl1.Text = Session("cnt").ToString
        For i As Integer = 1 To 100
            If Session("cnt") = "B" Then Exit For
            Threading.Thread.Sleep(100)
        Next
    End Sub

    Protected Sub btn2_Click(sender As Object, e As System.EventArgs) Handles btn2.Click
        Session("cnt") = "B"
        lbl2.Text = Session("cnt").ToString
    End Sub
End Class
