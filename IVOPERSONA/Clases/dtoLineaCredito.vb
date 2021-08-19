Imports AccesoDatos
Public Class dtoLineaCredito
    Public Function linea_credito(ByVal iId As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("sp_linea_credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idpersona", iId, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function Obtener_Linea_Credito(ByVal IdSolicitud As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_OBTENER_LINEA_CREDITO", CommandType.StoredProcedure)
            db.AsignarParametro("P_IdSolicitud_Credito", IdSolicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function upd_linea_credito(ByVal IdSolicitud As String, ByVal IdPersona As String, ByVal sAccion As String, ByVal idTipo_Facturacion As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_UPD_LINEA_CREDITO", CommandType.StoredProcedure)
            db.AsignarParametro("P_IdSolicitud_Credito", IdSolicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IdPersona", IdPersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_Accion", sAccion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IdTipo_Facturacion", idTipo_Facturacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        End Try
    End Function
End Class
