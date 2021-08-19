Public Class Cls_TarifaClienteCargo
    Private _idTarifaClienteCargo As Long
    Private _idTarifaCliente As Long
    Private _tarifaCliente As Cls_TarifaPersona_EN
    Private _idTipoTarifa As Integer
    Private _idProcesos As Integer
    Private _precioBase As Double
    Private _precioPeso As Double
    Private _precioVolumen As Double
    Private _precioSobre As Double
    Private _fechaActivacion As DateTime
    Private _fechaCaducidad As DateTime
    Private _idEstadoTarifario As Integer
    Public Property tarifaCliente As Cls_TarifaPersona_EN
        Get
            Return _tarifaCliente
        End Get
        Set(ByVal value As Cls_TarifaPersona_EN)
            _tarifaCliente = value
        End Set
    End Property
    Public Property idTarifaClienteCargo As Long
        Get
            Return _idTarifaClienteCargo
        End Get
        Set(ByVal value As Long)
            _idTarifaClienteCargo = value
        End Set
    End Property
    Public Property idTarifaCliente As Long
        Get
            Return _idTarifaCliente
        End Get
        Set(ByVal value As Long)
            _idTarifaCliente = value
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
            Return _idProcesos
        End Get
        Set(ByVal value As Integer)
            _idProcesos = value
        End Set
    End Property
    Public Property precioBase As Double
        Get
            Return _precioBase
        End Get
        Set(ByVal value As Double)
            _precioBase = value
        End Set
    End Property
    Public Property precioPeso As Double
        Get
            Return _precioPeso
        End Get
        Set(ByVal value As Double)
            _precioPeso = value
        End Set
    End Property
    Public Property precioVolumen As Double
        Get
            Return _precioVolumen
        End Get
        Set(ByVal value As Double)
            _precioVolumen = value
        End Set
    End Property
    Public Property precioSobre As Double
        Get
            Return _precioSobre
        End Get
        Set(ByVal value As Double)
            _precioSobre = value
        End Set
    End Property
    Public Property fechaActuvacion As DateTime
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
    Public Property estadoTarifa As Integer
        Get
            Return _idEstadoTarifario
        End Get
        Set(ByVal value As Integer)
            _idEstadoTarifario = value
        End Set
    End Property
End Class
