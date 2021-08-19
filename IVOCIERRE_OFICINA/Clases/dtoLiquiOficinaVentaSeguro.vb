Imports System.Data.OracleClient
Public Class dtoLiquiOficinaVentaSeguro
    Dim conexion As String = "data source=SISVYR; password=positiva5110; user id=lapositiva" '-->Produccion
    'Dim conexion As String = "data source=VYR; password=positiva5110; user id=lapositiva" '-->Desarrollo
#Region "VAIABLES DE CONEXION"
    Dim cnn As New OracleConnection(conexion) '==>Produccion
    Dim dataAdapter As OracleDataAdapter
#End Region
    ''' <summary>
    ''' CREA EL COMANDO
    ''' </summary>
    ''' <param name="commandContex">Nombre del PKG Y/O SP</param>
    ''' <returns>command</returns>
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
    ''' <summary>
    ''' BUSCA LAS VENTAS DE SEGUROS 
    ''' </summary>
    ''' <param name="idAgenicasisvyr">Identificador de la agencia</param>
    ''' <param name="fechaLiquidacion">Fecha a la que corresponde la liquidacion</param>
    ''' <returns>DataSet</returns>
    Public Function buscarVentas(ByVal idAgenica As Integer, ByVal fechaLiquidacion As String, ByVal idUsuario As Integer) As DataSet
        With command("PKG_LIQOFI_TITAN.SP_BUSCA_VENTAS_TRANS")
            .Parameters.Add(New OracleClient.OracleParameter("v_idAgencia", OracleClient.OracleType.Number)).Value = idAgenica
            .Parameters.Add(New OracleClient.OracleParameter("v_fechaLiquidacion", OracleClient.OracleType.NVarChar)).Value = fechaLiquidacion
            .Parameters.Add(New OracleClient.OracleParameter("v_idUsuario", OracleClient.OracleType.Number)).Value = idUsuario
            .Parameters.Add(New OracleClient.OracleParameter("cur_ventas", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
            .Parameters.Add(New OracleClient.OracleParameter("co_error", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
        End With

        Dim ds As New DataSet
        dataAdapter.Fill(ds)

        Return ds
    End Function


End Class
