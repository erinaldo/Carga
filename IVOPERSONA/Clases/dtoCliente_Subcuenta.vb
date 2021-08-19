Imports AccesoDatos
Public Class dtoCliente_Subcuenta
    Public Function LISTA_SUB_CUENTA() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_SUB_CUENTA", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_SUB_CUENTA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function INSUPD_SUBCUENTA(ByVal vAccionRegistro As Integer, ByVal rubro As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_SUBCUENTA", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", vAccionRegistro, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNOMBRE_SUB_CUENTA", rubro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_LISTA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
