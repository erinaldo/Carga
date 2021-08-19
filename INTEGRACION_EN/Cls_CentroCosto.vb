Public Class Cls_CentroCosto
    Dim _idCentroCostro As Long
    Dim _centroCosto As String
    Dim _idEstadoRegistro As Integer
    Dim _idUsuarioPersonal As Integer
    Dim _idUsuarioPersonalModificacion As Integer
    Dim _fechaRegistro As DateTime
    Dim _fechaModificacion As DateTime
    Dim _ipRegistro As String
    Dim _ipModificacion As String
    Dim _idRolRegistro As Integer
    Dim _idRolModificacion As Integer
    Public Property idCentroCosto As Long
        Get
            Return _idCentroCostro
        End Get
        Set(ByVal value As Long)
            _idCentroCostro = value
        End Set
    End Property
    Public Property centroCosto As String
        Get
            Return _centroCosto
        End Get
        Set(ByVal value As String)
            _centroCosto = value
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
    Public Property idUsuarioPersonalModificacion As Integer
        Get
            Return _idUsuarioPersonalModificacion
        End Get
        Set(ByVal value As Integer)
            _idUsuarioPersonalModificacion = value
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
