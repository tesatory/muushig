Imports Microsoft.VisualBasic

Public Class Player
    Public name As String
    Public hand As New List(Of Card)

    Sub New(_name As String)
        Me.name = _name
    End Sub

End Class
