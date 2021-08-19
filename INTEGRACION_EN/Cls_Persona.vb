Public Class Cls_Persona
    Dim _idPersona As Long
    Dim _ruc As String
    Dim _razonSocial As String

    Public Property idPersona As Long
        Get
            Return _idPersona
        End Get
        Set(ByVal value As Long)
            _idPersona = value
        End Set
    End Property
    Public Property ruc As String
        Get
            Return _ruc
        End Get
        Set(ByVal value As String)
            _ruc = value
        End Set
    End Property
    Public Property razonSocial As String
        Get
            Return _razonSocial
        End Get
        Set(ByVal value As String)
            _razonSocial = value
        End Set
    End Property
End Class
