Public Class dtoCodigo
    Private intId As Integer
    Public Property Id() As Integer
        Get
            Return intId
        End Get
        Set(ByVal value As Integer)
            intId = value
        End Set
    End Property

    Private alista As List(Of String)
    Public Property Lista() As List(Of String)
        Get
            Return alista
        End Get
        Set(ByVal value As List(Of String))
            alista = value
        End Set
    End Property

    Public Sub New()
        alista = New List(Of String)
    End Sub

End Class
