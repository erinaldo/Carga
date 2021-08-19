Public Class Cls_TarifaServicio_EN

    Private intOpcion As Integer
    Public Property Opcion() As Integer
        Get
            Return intOpcion
        End Get
        Set(ByVal value As Integer)
            intOpcion = value
        End Set
    End Property


    Private intIDTarifa As Integer
    Public Property IDTarifa() As Integer
        Get
            Return intIDTarifa
        End Get
        Set(ByVal value As Integer)
            intIDTarifa = value
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

    Private inTipoTarifa As Integer
    Public Property TipoTarifa() As Integer
        Get
            Return inTipoTarifa
        End Get
        Set(ByVal value As Integer)
            inTipoTarifa = value
        End Set
    End Property

    Private intTipoVisibilidad As Integer
    Public Property TipoVisibilidad() As Integer
        Get
            Return intTipoVisibilidad
        End Get
        Set(ByVal value As Integer)
            intTipoVisibilidad = value
        End Set
    End Property

    Private intServicio As Integer
    Public Property Servicio() As Integer
        Get
            Return intServicio
        End Get
        Set(ByVal value As Integer)
            intServicio = value
        End Set
    End Property

    Private intUnidad As Integer
    Public Property Unidad() As Integer
        Get
            Return intUnidad
        End Get
        Set(ByVal value As Integer)
            intUnidad = value
        End Set
    End Property
    Private dblInicio As Double
    Public Property Inicio() As Double
        Get
            Return dblInicio
        End Get
        Set(ByVal value As Double)
            dblInicio = value
        End Set
    End Property

    Private dblFin As Double
    Public Property Fin() As Double
        Get
            Return dblFin
        End Get
        Set(ByVal value As Double)
            dblFin = value
        End Set
    End Property

    Private dblMonto As Double
    Public Property Monto() As Double
        Get
            Return dblMonto
        End Get
        Set(ByVal value As Double)
            dblMonto = value
        End Set
    End Property

    Private strFechaActivacion As String
    Public Property FechaActivacion() As String
        Get
            Return strFechaActivacion
        End Get
        Set(ByVal value As String)
            strFechaActivacion = value
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
