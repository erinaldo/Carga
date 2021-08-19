Public Class Cls_ClienteTipoFacturacion_EN
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

    Private intTipoFacturacion As Integer
    Public Property TipoFacturacion() As Integer
        Get
            Return intTipoFacturacion
        End Get
        Set(ByVal value As Integer)
            intTipoFacturacion = value
        End Set
    End Property

    Private intOrdenCompra As Integer
    Public Property OrdenCompra() As Integer
        Get
            Return intOrdenCompra
        End Get
        Set(ByVal value As Integer)
            intOrdenCompra = value
        End Set
    End Property

    Private intLiquidacionDocumento As Integer
    Public Property LiquidacionDocumento() As Integer
        Get
            Return intLiquidacionDocumento
        End Get
        Set(ByVal value As Integer)
            intLiquidacionDocumento = value
        End Set
    End Property

    Private intContacto As Integer
    Public Property Contacto() As Integer
        Get
            Return intContacto
        End Get
        Set(ByVal value As Integer)
            intContacto = value
        End Set
    End Property

    Private intFormaFacturacion As Integer
    Public Property FormaFacturacion() As Integer
        Get
            Return intFormaFacturacion
        End Get
        Set(ByVal value As Integer)
            intFormaFacturacion = value
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

End Class
