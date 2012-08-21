
Partial Class KillGame
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Application("game") = Nothing
        Session("player") = Nothing
    End Sub
End Class
