Public Class Cls_ContactoCentroCosto
    Dim _idContactoCentrocosto As Long
    Dim _centroCosto As Cls_CentroCosto
    Dim _codigSap As String
    Dim _persona As Cls_Persona
    Dim _ciudadCobertura As Cls_UnidadAgencia
    Dim _idEstadoRegistro As Integer
    Dim _idUsuarioRegistro As Integer
    Dim _idUsuarioModificacion As Integer
    Dim _fechaRegistro As DateTime
    Dim _fechaModificacion As DateTime
    Dim _ipRegistro As String
    Dim _ipModificacion As String
    Dim _idRolRegistro As Integer
    Dim _idRolModificacion As Integer
    Public Property idContactoCentroCosto As Long
        Get
            Return _idContactoCentrocosto
        End Get
        Set(ByVal value As Long)
            _idContactoCentrocosto = value
        End Set
    End Property
    Public Property centroCosto As Cls_CentroCosto
        Get
            Return _centroCosto
        End Get
        Set(ByVal value As Cls_CentroCosto)
            _centroCosto = value
        End Set
    End Property
    Public Property codigoSap As String
        Get
            Return _codigSap
        End Get
        Set(ByVal value As String)
            _codigSap = value
        End Set
    End Property
    Public Property persona As Cls_Persona
        Get
            Return _persona
        End Get
        Set(ByVal value As Cls_Persona)
            _persona = value
        End Set
    End Property
    Public Property unidadAgenica As Cls_UnidadAgencia
        Get
            Return _ciudadCobertura
        End Get
        Set(ByVal value As Cls_UnidadAgencia)
            _ciudadCobertura = value
        End Set
    End Property
    Public Property idEstadoRegistro As Integer
        Get
            Return _idEstadoRegistro
        End Get
        Set(ByVal value As Integer)
            _idEstadoRegistro = value
        End Set
    End Property
    Public Property idUsuarioRegistro As Integer
        Get
            Return _idUsuarioRegistro
        End Get
        Set(ByVal value As Integer)
            _idUsuarioRegistro = value
        End Set
    End Property
    Public Property idUsuarioPersonalModificacion As Integer
        Get
            Return _idUsuarioModificacion
        End Get
        Set(ByVal value As Integer)
            _idUsuarioModificacion = value
        End Set
    End Property
    Public Property fechaRegistro As DateTime
        Get
            Return _fechaRegistro
        End Get
        Set(ByVal value As DateTime)
            _fechaRegistro = value
        End Set
    End Property
    Public Property fechaModificacion As DateTime
        Get
            Return _fechaModificacion
        End Get
        Set(ByVal value As DateTime)
            _fechaModificacion = value
        End Set
    End Property
    Public Property ipRegistro As String
        Get
            Return _ipRegistro
        End Get
        Set(ByVal value As String)
            _ipRegistro = value
        End Set
    End Property
    Public Property ipModificacion As String
        Get
            Return _ipModificacion
        End Get
        Set(ByVal value As String)
            _ipModificacion = value
        End Set
    End Property
    Public Property idRolRegistro As Integer
        Get
            Return _idRolRegistro
        End Get
        Set(ByVal value As Integer)
            _idRolRegistro = value
        End Set
    End Property
    Public Property idRolModificador As Integer
        Get
            Return _idRolModificacion
        End Get
        Set(ByVal value As Integer)
            _idRolModificacion = value
        End Set
    End Property
End Class
