Public Class Cls_Contacto_EN
    Private intID As Integer
    Public Property ID() As Integer
        Get
            Return intID
        End Get
        Set(ByVal value As Integer)
            intID = value
        End Set
    End Property

    Private intSubcuenta As Integer
    Public Property Subcuenta() As Integer
        Get
            Return intSubcuenta
        End Get
        Set(ByVal value As Integer)
            intSubcuenta = value
        End Set
    End Property

    Private intCargo As Integer
    Public Property Cargo() As Integer
        Get
            Return intCargo
        End Get
        Set(ByVal value As Integer)
            intCargo = value
        End Set
    End Property

    Private intTipoDocumento As Integer
    Public Property TipoDocumento() As Integer
        Get
            Return intTipoDocumento
        End Get
        Set(ByVal value As Integer)
            intTipoDocumento = value
        End Set
    End Property

    Private strNumeroDocumento As String
    Public Property NumeroDocumento() As String
        Get
            Return strNumeroDocumento
        End Get
        Set(ByVal value As String)
            strNumeroDocumento = value
        End Set
    End Property

    Private strRazonSocial As String
    Public Property RazonSocial() As String
        Get
            Return strRazonSocial
        End Get
        Set(ByVal value As String)
            strRazonSocial = value
        End Set
    End Property

    Private strNombres As String
    Public Property Nombres() As String
        Get
            Return strNombres
        End Get
        Set(ByVal value As String)
            strNombres = value
        End Set
    End Property

    Private strApellidoPaterno As String
    Public Property ApellidoPaterno() As String
        Get
            Return strApellidoPaterno
        End Get
        Set(ByVal value As String)
            strApellidoPaterno = value
        End Set
    End Property

    Private strApellidoMaterno As String
    Public Property ApellidoMaterno() As String
        Get
            Return strApellidoMaterno
        End Get
        Set(ByVal value As String)
            strApellidoMaterno = value
        End Set
    End Property

    Private strEmail As String
    Public Property Email() As String
        Get
            Return strEmail
        End Get
        Set(ByVal value As String)
            strEmail = value
        End Set
    End Property

    Private strSexo As String
    Public Property Sexo() As String
        Get
            Return strSexo
        End Get
        Set(ByVal value As String)
            strSexo = value
        End Set
    End Property

    Private intUsuario As Integer
    Public Property Usuario() As String
        Get
            Return intUsuario
        End Get
        Set(ByVal value As String)
            intUsuario = value
        End Set
    End Property

    Private strIP As String
    Public Property IP() As String
        Get
            Return strIP
        End Get
        Set(ByVal value As String)
            strIP = value
        End Set
    End Property

    Private intCliente As Integer
    Public Property Cliente() As Integer
        Get
            Return intCliente
        End Get
        Set(ByVal value As Integer)
            intCliente = value
        End Set
    End Property

    Private strNombre As String
    Public Property Nombre() As String
        Get
            Return strNombre
        End Get
        Set(ByVal value As String)
            strNombre = value
        End Set
    End Property

    Private intTipoPersona As Integer
    Public Property TipoPersona() As Integer
        Get
            Return intTipoPersona
        End Get
        Set(ByVal value As Integer)
            intTipoPersona = value
        End Set
    End Property

    Private intEstado As Integer
    Public Property Estado() As Integer
        Get
            Return intEstado
        End Get
        Set(ByVal value As Integer)
            intEstado = value
        End Set
    End Property

    Private strFechaIngreso As String
    Public Property FechaIngreso() As String
        Get
            Return strFechaIngreso
        End Get
        Set(ByVal value As String)
            strFechaIngreso = value
        End Set
    End Property

End Class

