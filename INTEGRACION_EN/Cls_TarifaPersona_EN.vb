Public Class Cls_TarifaPersona_EN
    Private _idTarifaCliente As String
    Private _idTarifaClienteCargo As Long
    'Private _tarifaClienteArticulo As Cls_TarifaClienteArticulo
    Private _Origen As String
    Private _Destino As String
    Private _SubCuenta As String
    Private _idPersona As Long
    Private _CodigoCliente As String
    Private _TipoTarifa As String
    Private _pROCESO As String
    Private _Peso As Double
    Private _BASE As Double
    Private _Volumen As Double
    Private _Sobre As Double
    Private _Flete As Double
    Private _iP As String
    Private _Usuario As String
    Private _fechaActivacion As String
    'Public Property tarifaclienteArticulo As Cls_TarifaClienteArticulo
    '    Get
    '        Return _tarifaClienteArticulo
    '    End Get
    '    Set(ByVal value As Cls_TarifaClienteArticulo)
    '        _tarifaClienteArticulo = value
    '    End Set
    'End Property
    Public Property idTarifaClienteCardo As Long
        Get
            Return _idTarifaClienteCargo
        End Get
        Set(ByVal value As Long)
            _idTarifaClienteCargo = value
        End Set
    End Property
    Public Property fechaActivacion As String
        Get
            Return _fechaActivacion
        End Get
        Set(ByVal value As String)
            _fechaActivacion = value
        End Set
    End Property
    Public Property idPersona As String
        Get
            Return _idPersona
        End Get
        Set(ByVal value As String)
            _idPersona = value
        End Set
    End Property

    Public Property idTarifaCliente()
        Get
            Return Me._idTarifaCliente
        End Get
        Set(ByVal value)
            Me._idTarifaCliente = value
        End Set
    End Property

    Public Property CodigoCliente()
        Get
            Return Me._CodigoCliente
        End Get
        Set(ByVal value)
            Me._CodigoCliente = value
        End Set
    End Property

    Public Property TipoTarifa()
        Get
            Return Me._TipoTarifa
        End Get
        Set(ByVal value)
            Me._TipoTarifa = value
        End Set
    End Property
    Public Property PROCESO()
        Get
            Return Me._pROCESO
        End Get
        Set(ByVal value)
            Me._pROCESO = value
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

    Public Property BASE()
        Get
            Return Me._BASE
        End Get
        Set(ByVal value)
            Me._BASE = value
        End Set
    End Property

    Public Property SubCuenta()
        Get
            Return Me._SubCuenta
        End Get
        Set(ByVal value)
            Me._SubCuenta = value
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

    Public Property Flete()
        Get
            Return Me._Flete
        End Get
        Set(ByVal value)
            Me._Flete = value
        End Set
    End Property


    Public Property Origen()
        Get
            Return Me._Origen
        End Get
        Set(ByVal value)
            Me._Origen = value
        End Set
    End Property

    Public Property Destino()
        Get
            Return Me._Destino
        End Get
        Set(ByVal value)
            Me._Destino = value
        End Set
    End Property

    Public Property iP()
        Get
            Return Me._iP
        End Get
        Set(ByVal value)
            Me._iP = value
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

    Private dblPesoMinimo As Double
    Public Property PesoMinimo() As Double
        Get
            Return dblPesoMinimo
        End Get
        Set(ByVal value As Double)
            dblPesoMinimo = value
        End Set
    End Property

    Private dblPesoMinimoFlete As Double
    Public Property PesoMinimoFlete() As Double
        Get
            Return dblPesoMinimoFlete
        End Get
        Set(ByVal value As Double)
            dblPesoMinimoFlete = value
        End Set
    End Property

    Private dblVolumenMinimo As Double
    Public Property VolumenMinimo() As Double
        Get
            Return dblVolumenMinimo
        End Get
        Set(ByVal value As Double)
            dblVolumenMinimo = value
        End Set
    End Property

    Private dblVolumenMinimoFlete As Double
    Public Property VolumenMinimoFlete() As Double
        Get
            Return dblVolumenMinimoFlete
        End Get
        Set(ByVal value As Double)
            dblVolumenMinimoFlete = value
        End Set
    End Property

End Class
