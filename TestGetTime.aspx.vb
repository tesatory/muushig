
Partial Class TestGetTime
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lbl.Text = "[1] " & Now.TimeOfDay.ToString
        Threading.Thread.Sleep(5000)
        lbl.Text &= " - " & Now.TimeOfDay.ToString
    End Sub
End Class
