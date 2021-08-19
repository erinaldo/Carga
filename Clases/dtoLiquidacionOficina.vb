Imports AccesoDatos
Public Class dtoLiquidacionOficina
    Function ListarAgencia() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ds As New DataSet
            db_bd.Conectar()
            db_bd.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_Lista_Agencia", CommandType.StoredProcedure)
            '
            db_bd.AsignarParametro("co_Lista_Agencias", OracleClient.OracleType.Cursor) '0
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '1

            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet

            Dim dt As DataTable = ds.Tables(0)
            Return dt

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

    End Function

    Function ListarLiquidacion(ByVal tipo As Integer, ByVal agencia As Integer, ByVal inicio As String, ByVal fin As String) As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ds As New DataSet
            db_bd.Conectar()
            db_bd.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_listar_liquidacion", CommandType.StoredProcedure)
            '
            db_bd.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32) '0
            db_bd.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32) '0
            db_bd.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar) '0
            db_bd.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar) '0
            db_bd.AsignarParametro("co_liquidacion", OracleClient.OracleType.Cursor) '0
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '1

            db_bd.Desconectar()
            ds = db_bd.EjecutarDataSet

            Dim dt As DataTable = ds.Tables(0)
            Return dt

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ListarLiquidacion(ByVal liquidacion As Integer, ByVal Fecha As String, ByVal IDAgencia As Integer) As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim dt As New DataTable
            db_bd.Conectar()
            db_bd.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_listar_CounterVenta", CommandType.StoredProcedure)
            '
            db_bd.AsignarParametro("ni_liquidacion", liquidacion, OracleClient.OracleType.Int32) 'v1
            db_bd.AsignarParametro("vi_fecha", Fecha, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_ID_AGENCIA", IDAgencia, OracleClient.OracleType.Int32)
            'db_bd.AsignarParametro("co_liquidacion", OracleClient.OracleType.Cursor) 'v1
            db_bd.AsignarParametro("co_UsuariosVenta", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor) 'v1

            db_bd.Desconectar()
            dt = db_bd.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ListarLiquidacion(ByVal fecha As String) As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim dt As New DataTable
            db_bd.Conectar()
            db_bd.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_listar_liquidacion", CommandType.StoredProcedure)
            '
            db_bd.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar) '0
            db_bd.AsignarParametro("co_liquidacion", OracleClient.OracleType.Cursor) '0
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '1

            db_bd.Desconectar()
            dt = db_bd.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
