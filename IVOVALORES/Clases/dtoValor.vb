Imports System.Data.OracleClient
Public Class dtoValor
    Dim cnn As New OracleConnection("data source=SISVYR; password=ventas5110; user id=vyr") '==>Produccion
    'Dim cnn As New OracleConnection("data source=VYR; password=ventas5110; user id=vyr") '==>Desarrollo
    Dim dataAdapter As OracleDataAdapter

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

    Private intIdIncidencia As Integer
    Public Property IdIncidencia() As Integer
        Get
            Return intIdIncidencia
        End Get
        Set(ByVal value As Integer)
            intIdIncidencia = value
        End Set
    End Property

    Private strIncidencia As String
    Public Property Incidencia() As String
        Get
            Return strIncidencia
        End Get
        Set(ByVal value As String)
            strIncidencia = value
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

    Private Function command(ByVal commandContex As String)
        Dim cmd As New OracleCommand
        cnn.Open() '-->Abre la conexión
        cmd.Connection = cnn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = commandContex
        dataAdapter = New OracleDataAdapter(cmd)
        cnn.Close() '-->Cierra la conexión
        Return cmd
    End Function

    Public Function LeerVenta(ByVal agencia As String, ByVal fecha As String, ByVal usuario As String) As DataTable
        With command("sp_leer_venta")
            .Parameters.Add(New OracleClient.OracleParameter("vi_agencia", OracleClient.OracleType.NVarChar)).Value = agencia
            .Parameters.Add(New OracleClient.OracleParameter("vi_fecha", OracleClient.OracleType.NVarChar)).Value = fecha
            .Parameters.Add(New OracleClient.OracleParameter("vi_usuario", OracleClient.OracleType.NVarChar)).Value = usuario
            .Parameters.Add(New OracleClient.OracleParameter("co_venta", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
        End With

        Dim dt As New DataTable
        dataAdapter.Fill(dt)

        Return dt
    End Function

End Class
