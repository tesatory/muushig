Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class Hand
    Public cards As List(Of Card)

    Public Sub New()
        cards = New List(Of Card)()
    End Sub

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        For Each c As Card In cards
            sb.Append(c.ToString)
            sb.Append(" ")
        Next
        Return sb.ToString
    End Function
End Class
