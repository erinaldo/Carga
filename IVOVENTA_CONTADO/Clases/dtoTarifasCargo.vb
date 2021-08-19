Public Class dtoTarifasCargo
    Private _idTarifaCargo As Long
    Private _idTarifaPublica As Long
    Private _idTipoTarifa As Integer
    Private _idProceso As Integer
    Private _base As Double
    Private _peso As Double
    Private _volumen As Double
    Private _sobre As Double
    Private _fleteMinimoPeso As Double
    Private _pesoMinimo As Double
    Private _fleteMinimoVolumen As Double
    Private _volumenMinimo As Double
    Private _fechaActivacion As DateTime
    Private _fechaCaducidad As DateTime
    Private _cargoXReparto As Double
    Private _tipoVisibilidad As Integer
    Private _estadoTarifa As Integer

    '-->Temporal, luego dar una mejor solucion
    Private _importeAticilo_Caja5 As Double
    Private _importeAticilo_Caja10 As Double
    Public Property idTarifaCargo As Long
        Get
            Return _idTarifaCargo
        End Get
        Set(ByVal value As Long)
            _idTarifaCargo = value
        End Set
    End Property
    Public Property idTarifaPublica As Long
        Get
            Return _idTarifaPublica
        End Get
        Set(ByVal value As Long)
            _idTarifaPublica = value
        End Set
    End Property
    Public Property idTipoTarifa As Integer
        Get
            Return _idTipoTarifa
        End Get
        Set(ByVal value As Integer)
            _idTipoTarifa = value
        End Set
    End Property
    Public Property idProceso As Integer
        Get
            Return _idProceso
        End Get
        Set(ByVal value As Integer)
            _idProceso = value
        End Set
    End Property
    Public Property precioBase As Double
        Get
            Return _base
        End Get
        Set(ByVal value As Double)
            _base = value
        End Set
    End Property
    Public Property precioPeso As Double
        Get
            Return _peso
        End Get
        Set(ByVal value As Double)
            _peso = value
        End Set
    End Property
    Public Property precioVolumen As Double
        Get
            Return _volumen
        End Get
        Set(ByVal value As Double)
            _volumen = value
        End Set
    End Property
    Public Property precioSobre As Double
        Get
            Return _sobre
        End Get
        Set(ByVal value As Double)
            _sobre = value
        End Set
    End Property
    Public Property fleteMinimoPeso As Double
        Get
            Return _fleteMinimoPeso
        End Get
        Set(ByVal value As Double)
            _fleteMinimoPeso = value
        End Set
    End Property
    Public Property fleteMinimoVolumen As Double
        Get
            Return _fleteMinimoVolumen
        End Get
        Set(ByVal value As Double)
            _fleteMinimoVolumen = value
        End Set
    End Property
    Public Property pesoMinimo As Double
        Get
            Return _pesoMinimo
        End Get
        Set(ByVal value As Double)
            _pesoMinimo = value
        End Set
    End Property
    Public Property volumnenMinimo As Double
        Get
            Return _volumenMinimo
        End Get
        Set(ByVal value As Double)
            _volumenMinimo = value
        End Set
    End Property
    Public Property fechaActivacion As DateTime
        Get
            Return _fechaActivacion
        End Get
        Set(ByVal value As DateTime)
            _fechaActivacion = value
        End Set
    End Property
    Public Property fechaCaducidad As DateTime
        Get
            Return _fechaCaducidad
        End Get
        Set(ByVal value As DateTime)
            _fechaCaducidad = value
        End Set
    End Property
    Public Property cargoXReparto As Double
        Get
            Return _cargoXReparto
        End Get
        Set(ByVal value As Double)
            _cargoXReparto = value
        End Set
    End Property
    Public Property tipoVisibilidad As Integer
        Get
            Return _tipoVisibilidad
        End Get
        Set(ByVal value As Integer)
            _tipoVisibilidad = value
        End Set
    End Property
    Public Property estadoTarifa As Integer
        Get
            Return _estadoTarifa
        End Get
        Set(ByVal value As Integer)
            _estadoTarifa = value
        End Set
    End Property
    Public Property importeArticulo_Caja5 As Double
        Get
            Return _importeAticilo_Caja5
        End Get
        Set(ByVal value As Double)
            _importeAticilo_Caja5 = value
        End Set
    End Property
    Public Property importeArticulo_Caja10 As Double
        Get
            Return _importeAticilo_Caja10
        End Get
        Set(ByVal value As Double)
            _importeAticilo_Caja10 = value
        End Set
    End Property

End Class
