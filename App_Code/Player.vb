Imports Microsoft.VisualBasic

Public Enum PlayerStatus
    ACTIVE
    IN_GAME
End Enum


Public Class Player
    Public time As Integer
    Public name As String
    Public hand As New List(Of Card)
    Public last_active_time As DateTime
    Public status As PlayerStatus
    Public total_score As Integer
    Public round_score As Integer
    Public screen_update_needed As Boolean = False

    Sub New(_name As String)
        Me.name = _name
        last_active_time = Now
        total_score = 15
        round_score = 0
        status = PlayerStatus.ACTIVE
        time = 0
    End Sub

End Class
