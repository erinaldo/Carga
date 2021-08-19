Imports AccesoDatos
Public Class dtoCliente_Rubro
    Public Function LISTA_RUBRO() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_RUBRO", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_RUBRO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function INSUPD_RUBRO(ByVal vAccionRegistro As Integer, ByVal idrubro As Integer, ByVal irubro As String, ByVal MyUsuario As Integer, ByVal MyRol As Integer, ByVal MyIP As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_RUBRO", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", vAccionRegistro, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDRUBRO", idrubro, OracleClient.OracleType.Int32)
            db.AsignarParametro("iRUBRO", irubro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", MyUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", MyRol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", MyIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_RUBRO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
