Imports Microsoft.VisualBasic

Public Enum SuitType
    Club
    Diamond
    Heart
    Spade
End Enum

Public Class Card
    Public rank As Integer
    Public suit As SuitType

    Public Sub New(_rank As Integer, _suit As SuitType)
        Me.rank = _rank
        Me.suit = _suit
    End Sub

    Public Overrides Function ToString() As String
        Dim ret As String = ""
        Select Case rank
            Case Is < 11
                ret = rank.ToString
            Case 11
                ret = "J"
            Case 12
                ret = "Q"
            Case 13
                ret = "K"
            Case 14
                ret = "A"
        End Select

        Select Case suit
            Case SuitType.Club
                ret &= "♣"
            Case SuitType.Diamond
                ret &= "♦"
            Case SuitType.Heart
                ret &= "♥"
            Case SuitType.Spade
                ret &= "♠"
        End Select

        Return ret
    End Function
End Class
