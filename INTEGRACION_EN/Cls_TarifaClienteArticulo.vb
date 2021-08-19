Public Class Cls_TarifaClienteArticulo
    Private _idTarifaClienteArticulo As Long
    Private _tarifaCliente As Cls_TarifaPersona_EN
    Private _idProducto As Integer
    Private _idCentroCosto As Integer
    Private _idArticulo As Integer
    Private _importe As Double
    Private _fechaActivacion As String
    Private _estadoTarifa As Integer
    Private _minimo As Double
    Private _base As Double

    Public Property idTarifaClienteArticulo As Long
        Get
            Return _idTarifaClienteArticulo
        End Get
        Set(ByVal value As Long)
            _idTarifaClienteArticulo = value
        End Set
    End Property
    Public Property tarifaCliente As Cls_TarifaPersona_EN
        Get
            Return _tarifaCliente
        End Get
        Set(ByVal value As Cls_TarifaPersona_EN)
            _tarifaCliente = value
        End Set
    End Property
    Public Property idProducto As Integer
        Get
            Return _idProducto
        End Get
        Set(ByVal value As Integer)
            _idProducto = value
        End Set
    End Property
    Public Property idCentoCosto As Integer
        Get
            Return _idCentroCosto
        End Get
        Set(ByVal value As Integer)
            _idCentroCosto = value
        End Set
    End Property
    Public Property idArticulo As Integer
        Get
            Return _idArticulo
        End Get
        Set(ByVal value As Integer)
            _idArticulo = value
        End Set
    End Property
    Public Property importe As Double
        Get
            Return _importe
        End Get
        Set(ByVal value As Double)
            _importe = value
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
    Public Property estadoTarifa As Integer
        Get
            Return _estadoTarifa
        End Get
        Set(ByVal value As Integer)
            _estadoTarifa = value
        End Set
    End Property

    Public Property minimo() As Double
        Get
            Return _minimo
        End Get
        Set(ByVal value As Double)
            _minimo = value
        End Set
    End Property
End Class
