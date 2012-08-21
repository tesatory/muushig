
Partial Class TestGetTime2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lbl.Text = "[2] " & Now.TimeOfDay.ToString
        'Threading.Thread.Sleep(2000)
        lbl.Text &= " - " & Now.TimeOfDay.ToString
    End Sub
End Class
