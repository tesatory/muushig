Imports Microsoft.VisualBasic

Public Enum PlayerStatus
    ACTIVE
    IN_GAME
End Enum

Public Class Player
    Public name As String
    Public hand As New List(Of Card)
    Public last_active_time As DateTime
    Public status As PlayerStatus

    Sub New(_name As String)
        Me.name = _name
        last_active_time = Now
        status = PlayerStatus.ACTIVE
    End Sub

End Class
