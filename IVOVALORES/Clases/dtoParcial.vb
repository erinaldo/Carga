Public Class dtoParcial
    Private intIdRemesa As Integer
    Public Property IdRemesa() As Integer
        Get
            Return intIdRemesa
        End Get
        Set(ByVal value As Integer)
            intIdRemesa = value
        End Set
    End Property

    Private intIdRemesaDet As Integer
    Public Property IdRemesaDet() As Integer
        Get
            Return intIdRemesaDet
        End Get
        Set(ByVal value As Integer)
            intIdRemesaDet = value
        End Set
    End Property

    Private intId As Integer
    Public Property Id() As Integer
        Get
            Return intId
        End Get
        Set(ByVal value As Integer)
            intId = value
        End Set
    End Property

    Private intBanco As Integer
    Public Property IDBanco() As Integer
        Get
            Return intBanco
        End Get
        Set(ByVal value As Integer)
            intBanco = value
        End Set
    End Property

    Private intCuentaCorriente As Integer
    Public Property IDCuentaCorriente() As Integer
        Get
            Return intCuentaCorriente
        End Get
        Set(ByVal value As Integer)
            intCuentaCorriente = value
        End Set
    End Property

    Private strBanco As String
    Public Property Banco() As String
        Get
            Return strBanco
        End Get
        Set(ByVal value As String)
            strBanco = value
        End Set
    End Property

    Private strCuentaCorriente As String
    Public Property CuentaCorriente() As String
        Get
            Return strCuentaCorriente
        End Get
        Set(ByVal value As String)
            strCuentaCorriente = value
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

    Private strNumero As String
    Public Property Numero() As String
        Get
            Return strNumero
        End Get
        Set(ByVal value As String)
            strNumero = value
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

    Private strObservacion As String
    Public Property Observacion() As String
        Get
            Return strObservacion
        End Get
        Set(ByVal value As String)
            strObservacion = value
        End Set
    End Property

    Private intFila As Integer
    Public Property Fila() As Integer
        Get
            Return intFila
        End Get
        Set(ByVal value As Integer)
            intFila = value
        End Set
    End Property


End Class
