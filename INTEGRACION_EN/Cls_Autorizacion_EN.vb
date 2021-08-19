Public Class Cls_Autorizacion_EN
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

    Private intComprobante As Integer
    Public Property Comprobante() As Integer
        Get
            Return intComprobante
        End Get
        Set(ByVal value As Integer)
            intComprobante = value
        End Set
    End Property

    Private dblTotal As Double
    Public Property Total() As Double
        Get
            Return dblTotal
        End Get
        Set(ByVal value As Double)
            dblTotal = value
        End Set
    End Property

    Private intSolicitante As Integer
    Public Property Solicitante() As Integer
        Get
            Return intSolicitante
        End Get
        Set(ByVal value As Integer)
            intSolicitante = value
        End Set
    End Property

    Private intAgencia As Integer
    Public Property Agencia() As Integer
        Get
            Return intAgencia
        End Get
        Set(ByVal value As Integer)
            intAgencia = value
        End Set
    End Property

    Private strObservacion As String
    Public Property Observacion() As String
        Get
            Return strObservacion
        End Get
        Set(ByVal value As String)
            strObservacion = value
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

    Private intID2 As Integer
    Public Property ID2() As Integer
        Get
            Return intID2
        End Get
        Set(ByVal value As Integer)
            intID2 = value
        End Set
    End Property

    Private intOperacion As Integer
    Public Property Operacion() As Integer
        Get
            Return intOperacion
        End Get
        Set(ByVal value As Integer)
            intOperacion = value
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

    Private strDato As String
    Public Property Dato() As String
        Get
            Return strDato
        End Get
        Set(ByVal value As String)
            strDato = value
        End Set
    End Property
    Private intOpcion As Integer
    Public Property Opcion() As Integer
        Get
            Return intOpcion
        End Get
        Set(ByVal value As Integer)
            intOpcion = value
        End Set
    End Property

    Private intTipoOperacion As Integer
    Public Property TipoOperacion() As Integer
        Get
            Return intTipoOperacion
        End Get
        Set(ByVal value As Integer)
            intTipoOperacion = value
        End Set
    End Property

    Private intUsuarioLiquidacion As Integer
    Public Property UsuarioLiquidacion() As Integer
        Get
            Return intUsuarioLiquidacion
        End Get
        Set(ByVal value As Integer)
            intUsuarioLiquidacion = value
        End Set
    End Property

    Private intCuentaCorriente As Integer
    Public Property CuentaCorriente() As Integer
        Get
            Return intCuentaCorriente
        End Get
        Set(ByVal value As Integer)
            intCuentaCorriente = value
        End Set
    End Property

End Class
