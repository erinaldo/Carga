Imports AccesoDatos
Public Class ClsBuscarClienteAD
    ''' <summary>
    ''' REALIZA LA BUSQUEDA DEL CLIENTE, POR RAZÓN SOCIAL O RUC
    ''' </summary>
    ''' <param name="pStr_Filtro">Razon social del Cliente</param>
    ''' <param name="ruc">Ruc del Cliente</param>
    '''<returns>dataTable</returns>
    Public Function F_BuscarCliente_AD(Optional ByVal pStr_Filtro As String = "", Optional ByVal ruc As String = "", Optional usuario As Integer = 0) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("SP_BUSCAR_PERSONAS_I", CommandType.StoredProcedure)
            db.AsignarParametro("pvariable", pStr_Filtro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("pruc", ruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("pusuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_LISTAR_CLIENTE", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            db.Desconectar()

            Return ds.Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function F_BuscarClienteTodos_AD() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("SP_BUSCAR_CLIENTES", CommandType.StoredProcedure)
            db.AsignarParametro("CUR_LISTAR_CLIENTE", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            db.Desconectar()

            Return ds.Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
