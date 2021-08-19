Public Class Cls_UnidadAgencia
    Dim _idUnidaAgencia As Integer
    Dim _nombreUnidad As String
    Public Property idUnidadAgencia As String
        Get
            Return _idUnidaAgencia
        End Get
        Set(ByVal value As String)
            _idUnidaAgencia = value
        End Set
    End Property
End Class
