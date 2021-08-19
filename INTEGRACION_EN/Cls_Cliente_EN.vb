Public Class Cls_Cliente_EN

    Private intId As Integer
    Public Property ID() As Integer
        Get
            Return intId
        End Get
        Set(ByVal value As Integer)
            intId = value
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

    Private strGerenteGeneral As String
    Public Property GerenteGeneral() As String
        Get
            Return strGerenteGeneral
        End Get
        Set(ByVal value As String)
            strGerenteGeneral = value
        End Set
    End Property

    Private strRepresentanteLegal As String
    Public Property RepresentanteLegal() As String
        Get
            Return strRepresentanteLegal
        End Get
        Set(ByVal value As String)
            strRepresentanteLegal = value
        End Set
    End Property

    Private strPaginaWeb As String
    Public Property PaginaWeb() As String
        Get
            Return strPaginaWeb
        End Get
        Set(ByVal value As String)
            strPaginaWeb = value
        End Set
    End Property

    Private strFechaNacimiento As String
    Public Property FechaNacimiento() As String
        Get
            Return strFechaNacimiento
        End Get
        Set(ByVal value As String)
            strFechaNacimiento = value
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

    Private strEmail As String
    Public Property Email() As String
        Get
            Return strEmail
        End Get
        Set(ByVal value As String)
            strEmail = value
        End Set
    End Property

    Private intAgenteRetencion As Integer
    Public Property AgenteRetencion() As Integer
        Get
            Return intAgenteRetencion
        End Get
        Set(ByVal value As Integer)
            intAgenteRetencion = value
        End Set
    End Property

    Private intPagoPostFacturacion As Integer
    Public Property PagoPostFacturacion() As Integer
        Get
            Return intPagoPostFacturacion
        End Get
        Set(ByVal value As Integer)
            intPagoPostFacturacion = value
        End Set
    End Property

    Private intRubro As Integer
    Public Property RubroEmpresarial() As Integer
        Get
            Return intRubro
        End Get
        Set(ByVal value As Integer)
            intRubro = value
        End Set
    End Property

    Private intClasificacion As Integer
    Public Property ClasificacionEmpresa() As Integer
        Get
            Return intClasificacion
        End Get
        Set(ByVal value As Integer)
            intClasificacion = value
        End Set
    End Property

    Private intVigente As Integer
    Public Property Vigente() As Integer
        Get
            Return intVigente
        End Get
        Set(ByVal value As Integer)
            intVigente = value
        End Set
    End Property

    Private dblDescuento As Double
    Public Property Descuento() As Double
        Get
            Return dblDescuento
        End Get
        Set(ByVal value As Double)
            dblDescuento = value
        End Set
    End Property

    Private intDigitosSerie As Integer
    Public Property DigitosSerie() As Integer
        Get
            Return intDigitosSerie
        End Get
        Set(ByVal value As Integer)
            intDigitosSerie = value
        End Set
    End Property

    Private strUsuarioWeb As String
    Public Property UsuarioWeb() As String
        Get
            Return strUsuarioWeb
        End Get
        Set(ByVal value As String)
            strUsuarioWeb = value
        End Set
    End Property

    Private strContraseña As String
    Public Property Contraseña() As String
        Get
            Return strContraseña
        End Get
        Set(ByVal value As String)
            strContraseña = value
        End Set
    End Property

    Private intProducto As Integer
    Public Property Producto() As Integer
        Get
            Return intProducto
        End Get
        Set(ByVal value As Integer)
            intProducto = value
        End Set
    End Property

    Private intUsuario As Integer
    Public Property Usuario() As Integer
        Get
            Return intUsuario
        End Get
        Set(ByVal value As Integer)
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

    Private intFuente As Integer
    Public Property Fuente() As Integer
        Get
            Return intFuente
        End Get
        Set(ByVal value As Integer)
            intFuente = value
        End Set
    End Property

    Private intConsignado As Integer
    Public Property Consignado() As Integer
        Get
            Return intConsignado
        End Get
        Set(ByVal value As Integer)
            intConsignado = value
        End Set
    End Property

    Private intBaseArticulo As Integer
    Public Property BaseArticulo() As Integer
        Get
            Return intBaseArticulo
        End Get
        Set(ByVal value As Integer)
            intBaseArticulo = value
        End Set
    End Property
End Class
