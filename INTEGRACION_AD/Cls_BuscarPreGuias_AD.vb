Imports AccesoDatos
Public Class Cls_BuscarPreGuias_AD
    Public Function BuscarPreguias_AD(ByVal vi_PreGuias As String) As DataTable
        Try
            Dim db As New BaseDatos

            db.Conectar()
            db.CrearComando("SP_BUSCAR_PRE_GUIAS", CommandType.StoredProcedure)
            db.AsignarParametro("p_NumeroGuia", vi_PreGuias, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_BUSCAR_GUIAS", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            db.Desconectar()

            Return ds.Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
