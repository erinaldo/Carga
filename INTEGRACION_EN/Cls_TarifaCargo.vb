Public Class Cls_TarifaCargo
    Dim _idTarifaCargo As Long
    Dim _tarifaPublica As Cls_TarifaPublica_EN
    Dim _idTipoTarifa As Integer
    Dim _idProcesos As Integer
    Dim _Base As Double
    Dim _Peso As Double
    Dim _Volumen As Double
    Dim _Sobre As Double
    Dim _FleteMinimoPeso As Double
    Dim _PesoMinimo As Double
    Dim _FleteMinimoVol As Double
    Dim _VolMinimo As Double
    Dim _CargoReparto As Double
    Dim _fechaActivacion As String
    Dim _fechaCaducidad As String
    Dim _tipoVisibilidad As Integer
    Dim _estadoTarifa As Integer
    Dim _idUsuario As Integer
    Dim _ip As String

    Public Property idTarifaCargo As Long
        Get
            Return _idTarifaCargo
        End Get
        Set(ByVal value As Long)
            _idTarifaCargo = value
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
    Public Property Base As Double
        Get
            Return _Base
        End Get
        Set(ByVal value As Double)
            _Base = value
        End Set
    End Property
    Public Property Peso As Double
        Get
            Return _Peso
        End Get
        Set(ByVal value As Double)
            _Peso = value
        End Set
    End Property
    Public Property Volumen As Double
        Get
            Return _Volumen
        End Get
        Set(ByVal value As Double)
            _Volumen = value
        End Set
    End Property
    Public Property Sobre As Double
        Get
            Return _Sobre
        End Get
        Set(ByVal value As Double)
            _Sobre = value
        End Set
    End Property
    Public Property FleteMinimoPeso As Double
        Get
            Return _FleteMinimoPeso
        End Get
        Set(ByVal value As Double)
            _FleteMinimoPeso = value
        End Set
    End Property
    Public Property PesoMinimo As Double
        Get
            Return _PesoMinimo
        End Get
        Set(ByVal value As Double)
            _PesoMinimo = value
        End Set
    End Property
    Public Property FleteMinimoVol As Double
        Get
            Return _FleteMinimoVol
        End Get
        Set(ByVal value As Double)
            _FleteMinimoVol = value
        End Set
    End Property
    Public Property VolumenMinimo As Double
        Get
            Return _VolMinimo
        End Get
        Set(ByVal value As Double)
            _VolMinimo = value
        End Set
    End Property
    Public Property CargoReparto As Double
        Get
            Return _CargoReparto
        End Get
        Set(ByVal value As Double)
            _CargoReparto = value
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
    Public Property fechaCaducidad As String
        Get
            Return _fechaCaducidad
        End Get
        Set(ByVal value As String)
            _fechaCaducidad = value
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

    Private intCiudad As Integer
    Public Property Ciudad() As Integer
        Get
            Return intCiudad
        End Get
        Set(ByVal value As Integer)
            intCiudad = value
        End Set
    End Property

End Class
