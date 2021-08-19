Public Class Cls_Direccion_EN
    Private intID As Integer
    Public Property ID() As Integer
        Get
            Return intID
        End Get
        Set(ByVal value As Integer)
            intID = value
        End Set
    End Property

    Private intTipo As Integer
    Public Property Tipo() As Integer
        Get
            Return intTipo
        End Get
        Set(ByVal value As Integer)
            intTipo = value
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

    Private strDireccion As String
    Public Property Direccion() As String
        Get
            Return strDireccion
        End Get
        Set(ByVal value As String)
            strDireccion = value
        End Set
    End Property

    Private strReferencia As String
    Public Property Referencia() As String
        Get
            Return strReferencia
        End Get
        Set(ByVal value As String)
            strReferencia = value
        End Set
    End Property

    Private intDireccionFacturacion As Integer
    Public Property DireccionFacturacion() As Integer
        Get
            Return intDireccionFacturacion
        End Get
        Set(ByVal value As Integer)
            intDireccionFacturacion = value
        End Set
    End Property

    Private intDepartamento As Integer
    Public Property Departamento() As Integer
        Get
            Return intDepartamento
        End Get
        Set(ByVal value As Integer)
            intDepartamento = value
        End Set
    End Property

    Private intProvincia As Integer
    Public Property Provincia() As Integer
        Get
            Return intProvincia
        End Get
        Set(ByVal value As Integer)
            intProvincia = value
        End Set
    End Property

    Private intDistrito As Integer
    Public Property Distrito() As Integer
        Get
            Return intDistrito
        End Get
        Set(ByVal value As Integer)
            intDistrito = value
        End Set
    End Property

    Private intTipoVia As Integer
    Public Property TipoVia() As Integer
        Get
            Return intTipoVia
        End Get
        Set(ByVal value As Integer)
            intTipoVia = value
        End Set
    End Property

    Private strVia As String
    Public Property Via() As String
        Get
            Return strVia
        End Get
        Set(ByVal value As String)
            strVia = value
        End Set
    End Property

    Private strNumero As String
    Public Property Numero() As String
        Get
            Return strNumero
        End Get
        Set(ByVal value As String)
            strNumero = value
        End Set
    End Property

    Private strManzana As String
    Public Property Manzana() As String
        Get
            Return strManzana
        End Get
        Set(ByVal value As String)
            strManzana = value
        End Set
    End Property

    Private strLote As String
    Public Property Lote() As String
        Get
            Return strLote
        End Get
        Set(ByVal value As String)
            strLote = value
        End Set
    End Property

    Private intTipoNivel As Integer
    Public Property TipoNivel() As Integer
        Get
            Return intTipoNivel
        End Get
        Set(ByVal value As Integer)
            intTipoNivel = value
        End Set
    End Property

    Private strNivel As String
    Public Property Nivel() As String
        Get
            Return strNivel
        End Get
        Set(ByVal value As String)
            strNivel = value
        End Set
    End Property

    Private intTipoZona As Integer
    Public Property TipoZona() As Integer
        Get
            Return intTipoZona
        End Get
        Set(ByVal value As Integer)
            intTipoZona = value
        End Set
    End Property

    Private strZona As String
    Public Property Zona() As String
        Get
            Return strZona
        End Get
        Set(ByVal value As String)
            strZona = value
        End Set
    End Property

    Private intTipoClasificacion As Integer
    Public Property TipoClasificacion() As Integer
        Get
            Return intTipoClasificacion
        End Get
        Set(ByVal value As Integer)
            intTipoClasificacion = value
        End Set
    End Property

    Private strClasificacion As String
    Public Property Clasificacion() As String
        Get
            Return strClasificacion
        End Get
        Set(ByVal value As String)
            strClasificacion = value
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

End Class
