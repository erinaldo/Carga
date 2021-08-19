Public Class Cls_ClienteProducto_EN
    Private intId As Integer
    Public Property ID() As Integer
        Get
            Return intId
        End Get
        Set(ByVal value As Integer)
            intId = value
        End Set
    End Property

    Private intNumeroSolicitud As Integer
    Public Property NumeroSolicitud() As Integer
        Get
            Return intNumeroSolicitud
        End Get
        Set(ByVal value As Integer)
            intNumeroSolicitud = value
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

    Private intSubcuenta As Integer
    Public Property Subcuenta() As Integer
        Get
            Return intSubcuenta
        End Get
        Set(ByVal value As Integer)
            intSubcuenta = value
        End Set
    End Property

    Private intOrigen As Integer
    Public Property Origen() As Integer
        Get
            Return intOrigen
        End Get
        Set(ByVal value As Integer)
            intOrigen = value
        End Set
    End Property

    Private intDestino As Integer
    Public Property Destino() As Integer
        Get
            Return intDestino
        End Get
        Set(ByVal value As Integer)
            intDestino = value
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

    Private strObservacion As String
    Public Property Observacion() As String
        Get
            Return strObservacion
        End Get
        Set(ByVal value As String)
            strObservacion = value
        End Set
    End Property

    Private strFecha As String
    Public Property Fecha() As String
        Get
            Return strFecha
        End Get
        Set(ByVal value As String)
            strFecha = value
        End Set
    End Property

    Private intusuario As Integer
    Public Property Usuario() As Integer
        Get
            Return intusuario
        End Get
        Set(ByVal value As Integer)
            intusuario = value
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

    Private intEstado As Integer
    Public Property Estado() As Integer
        Get
            Return intEstado
        End Get
        Set(ByVal value As Integer)
            intEstado = value
        End Set
    End Property

    Private intResponsable As Integer
    Public Property Responsable() As Integer
        Get
            Return intResponsable
        End Get
        Set(ByVal value As Integer)
            intResponsable = value
        End Set
    End Property

    Private intContado As Integer
    Public Property Contado() As Integer
        Get
            Return intContado
        End Get
        Set(ByVal value As Integer)
            intContado = value
        End Set
    End Property

    Private intTipoTarifa As Integer
    Public Property TipoTarifa() As Integer
        Get
            Return intTipoTarifa
        End Get
        Set(ByVal value As Integer)
            intTipoTarifa = value
        End Set
    End Property
    Private intRetorno As Integer
    Public Property Retorno() As Integer
        Get
            Return intRetorno
        End Get
        Set(ByVal value As Integer)
            intRetorno = value
        End Set
    End Property

End Class
