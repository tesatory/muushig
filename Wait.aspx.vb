
Partial Class Wait
    Inherits System.Web.UI.Page

    Private MAX_WAIT_TIME As Integer = 20000   ' in milliseconds
    Private WAIT_STEP As Integer = 200   ' in milliseconds


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim player As Player = Session("player")

        For t As Integer = 1 To MAX_WAIT_TIME Step WAIT_STEP
            If player.screen_update_needed Then Exit For
            Threading.Thread.Sleep(WAIT_STEP)
        Next
    End Sub
End Class
