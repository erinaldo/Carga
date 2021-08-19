Imports AccesoDatos
Public Class Cls_DevolucionLimiteTiempo_AD
    Public Function BuscarDevolucion_AD(ByVal agencia As Integer, ByVal dias As Integer) As DataTable
        Dim db As New BaseDatos
        db.Conectar()
        Try
            db.CrearComando("SP_DXLT", CommandType.StoredProcedure)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_dias", dias, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            Return db.EjecutarDataSet.Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function
End Class
