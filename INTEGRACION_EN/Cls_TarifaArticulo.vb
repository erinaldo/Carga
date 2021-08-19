Public Class Cls_TarifaArticulo
    Private _idTarifaArticulo As Long
    Private _tarifaPublica As Cls_TarifaPublica_EN
    Private _idArticulo As Integer
    Private _idTipoTarifa As Integer
    Private _idProcesos As Integer
    Private _importe As Double
    Private _fechaActivacion As String
    Private _idUsuario As Integer
    Private _ip As String
    Private _TipoEntrega As Integer


    Public Property idTarifaArticulo As Integer
        Get
            Return _idTarifaArticulo
        End Get
        Set(ByVal value As Integer)
            _idTarifaArticulo = value
        End Set
    End Property
    Public Property tarifaPublica As Cls_TarifaPublica_EN
        Get
            Return _tarifaPublica
        End Get
        Set(ByVal value As Cls_TarifaPublica_EN)
            _tarifaPublica = value
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
    Public Property idTipoTarifa As Integer
        Get
            Return _idTipoTarifa
        End Get
        Set(ByVal value As Integer)
            _idTipoTarifa = value
        End Set
    End Property
    Public Property idProcesos As Integer
        Get
            Return _idProcesos
        End Get
        Set(ByVal value As Integer)
            _idProcesos = value
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
    Public Property TipoEntrega As Integer
        Get
            Return _TipoEntrega
        End Get
        Set(value As Integer)
            _TipoEntrega = value
        End Set
    End Property

    Public Property idUsuario As Integer
        Get
            Return _idUsuario
        End Get
        Set(ByVal value As Integer)
            _idUsuario = value
        End Set
    End Property
    Public Property ip As String
        Get
            Return _ip
        End Get
        Set(ByVal value As String)
            _ip = value
        End Set
    End Property
End Class
