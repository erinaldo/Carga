Public Class Cls_ClienteFueraZona_EN
    Private intID As Integer
    Public Property ID() As Integer
        Get
            Return intID
        End Get
        Set(ByVal value As Integer)
            intID = value
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

    Private dblTotal As Double
    Public Property Total() As Double
        Get
            Return dblTotal
        End Get
        Set(ByVal value As Double)
            dblTotal = value
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

    Private intEstado As Integer
    Public Property Estado() As Integer
        Get
            Return intEstado
        End Get
        Set(ByVal value As Integer)
            intEstado = value
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
            Return strIp
        End Get
        Set(ByVal value As String)
            strIp = value
        End Set
    End Property

End Class
