Public Class Cls_TarifaPublica_EN
    Private _idTarifaPublica As Long
    Private _idTipoTarifa As String
    Private _idproceso As String
    Private _Base As Double
    Private _Peso As Double
    Private _Volumen As Double
    Private _Sobre As Double
    Private _FleteMinimo As Double
    Private _TipoVisibilidad As String
    Private _EstadoTarifa As String
    Private _UnidadOrigen As String
    Private _UnidadDestino As String
    Private _Usuario As String
    Private _IP As String
    Private _PesoMinimo As String
    Public Property idTarifaPublica As Long
        Get
            Return _idTarifaPublica
        End Get
        Set(ByVal value As Long)
            _idTarifaPublica = value
        End Set
    End Property

    Public Property PesoMinimo()
        Get
            Return Me._PesoMinimo
        End Get
        Set(ByVal value)
            Me._PesoMinimo = value
        End Set
    End Property

    Public Property IP()
        Get
            Return Me._IP
        End Get
        Set(ByVal value)
            Me._IP = value
        End Set
    End Property

    Public Property Usuario()
        Get
            Return Me._Usuario
        End Get
        Set(ByVal value)
            Me._Usuario = value
        End Set
    End Property
    Public Property UnidadOrigen()
        Get
            Return Me._UnidadOrigen
        End Get
        Set(ByVal value)
            Me._UnidadOrigen = value
        End Set
    End Property
    Public Property UnidadDestino()
        Get
            Return Me._UnidadDestino
        End Get
        Set(ByVal value)
            Me._UnidadDestino = value
        End Set
    End Property
    Public Property idTipoTarifa()
        Get
            Return Me._idTipoTarifa
        End Get
        Set(ByVal value)
            Me._idTipoTarifa = value
        End Set
    End Property

    Public Property idproceso()
        Get
            Return Me._idproceso
        End Get
        Set(ByVal value)
            Me._idproceso = value
        End Set
    End Property

    Public Property Base()
        Get
            Return Me._Base
        End Get
        Set(ByVal value)
            Me._Base = value
        End Set
    End Property

    Public Property Peso()
        Get
            Return Me._Peso
        End Get
        Set(ByVal value)
            Me._Peso = value
        End Set
    End Property

    Public Property Volumen()
        Get
            Return Me._Volumen
        End Get
        Set(ByVal value)
            Me._Volumen = value
        End Set
    End Property

    Public Property Sobre()
        Get
            Return Me._Sobre
        End Get
        Set(ByVal value)
            Me._Sobre = value
        End Set
    End Property
    Public Property FleteMinimo()
        Get
            Return Me._FleteMinimo
        End Get
        Set(ByVal value)
            Me._FleteMinimo = value
        End Set
    End Property

    Public Property TipoVisibilidad()
        Get
            Return Me._TipoVisibilidad
        End Get
        Set(ByVal value)
            Me._TipoVisibilidad = value
        End Set
    End Property

    Public Property EstadoTarifa()
        Get
            Return Me._EstadoTarifa
        End Get
        Set(ByVal value)
            Me._EstadoTarifa = value
        End Set
    End Property

End Class
