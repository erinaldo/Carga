Public Class Boleto
    Public Property numeroBoleto As String
    Public Property idCiudadOrigen As Integer
    Public Property ciudadOrigen As String
    Public Property idAgenciaOrigen As Integer
    Public Property agenciaOrigen As String
    Public Property idCiudadDestino As Integer
    Public Property ciudadDestino As String
    Public Property idAgenciaDestino As Integer
    Public Property agenciaDestino As String
    Public Property numeroDocumento As String
    Public Property apellidoPaterno As String
    Public Property apellidoMaterno As String
    Public Property nombes As String

    Public Property titan_idPersona As Long = 0
    Public Property titan_idTipoDocumento As Integer
    Public Property titan_rw_cliente As DataRow = Nothing

    Public Property fechaPartida As String
    Public Property horaPartida As String
    Public Property frecuente As Integer
    Public Property servicio As String

    Public Property asiento As Integer
    Public Property total_boleto As Double

    'Public Property idTipoEntrega As Integer



    'Public Property numeroBoleto As String
    '    Get
    '        Return _numeroBoleto
    '    End Get
    '    Set(ByVal value As String)
    '        _numeroBoleto = value
    '    End Set
    'End Property
    'Public Property idCiudadOrigen As Integer
    '    Get
    '        Return _idCiudadOrigen
    '    End Get
    '    Set(ByVal value As Integer)
    '        _idCiudadOrigen = value
    '    End Set
    'End Property
    'Public Property ciudadOrigen As String
    '    Get
    '        Return _ciudadOrigen
    '    End Get
    '    Set(ByVal value As String)
    '        _ciudadOrigen = value
    '    End Set
    'End Property
    'Public Property idAgenciaOrigen As Integer
    '    Get
    '        Return _idAgenciaOrigen
    '    End Get
    '    Set(ByVal value As Integer)
    '        _idAgenciaOrigen = value
    '    End Set
    'End Property

    'Public Property idCiudadDestino As Integer
    '    Get
    '        Return _idCiudadDestino
    '    End Get
    '    Set(ByVal value As Integer)
    '        _idCiudadDestino = value
    '    End Set
    'End Property
    'Public Property idAgenciaDestino As Integer
    '    Get
    '        Return _idAgenciaDestino
    '    End Get
    '    Set(ByVal value As Integer)
    '        _idAgenciaDestino = value
    '    End Set
    'End Property
End Class
