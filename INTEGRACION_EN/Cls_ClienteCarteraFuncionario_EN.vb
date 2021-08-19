Public Class Cls_ClienteCarteraFuncionario_EN

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

    Private strSustento As String
    Public Property Sustento() As String
        Get
            Return strSustento
        End Get
        Set(ByVal value As String)
            strSustento = value
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


    Private intResponsableActual As Integer
    Public Property ResponsableActual() As Integer
        Get
            Return intResponsableActual
        End Get
        Set(ByVal value As Integer)
            intResponsableActual = value
        End Set
    End Property

    Private strResponsableFechaInicio As String
    Public Property ResponsableFechaInicio() As String
        Get
            Return strResponsableFechaInicio
        End Get
        Set(ByVal value As String)
            strResponsableFechaInicio = value
        End Set
    End Property

    Private strResponsableFechaFin As String
    Public Property ResponsableFechaFin() As String
        Get
            Return strResponsableFechaFin
        End Get
        Set(ByVal value As String)
            strResponsableFechaFin = value
        End Set
    End Property

    Private strObservaciones As String
    Public Property Observaciones() As String
        Get
            Return strObservaciones
        End Get
        Set(ByVal value As String)
            strObservaciones = value
        End Set
    End Property

    Private intTipoCuenta As Integer
    Public Property TipoCuenta() As Integer
        Get
            Return intTipoCuenta
        End Get
        Set(ByVal value As Integer)
            intTipoCuenta = value
        End Set
    End Property

End Class
