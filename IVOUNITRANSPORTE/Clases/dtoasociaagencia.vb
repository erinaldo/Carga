Imports AccesoDatos
Public Class dtoasociaagencia
    Private iidunidadtransporte As Integer
    Public Property idunidadtransporte() As Integer
        Get
            Return iidunidadtransporte
        End Get
        Set(ByVal value As Integer)
            iidunidadtransporte = value
        End Set
    End Property
    'Recupera las agencias asociar 
    'Public Function getagenciaasociar2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVOUNIDADTRANSPORTE.SP_AGENCIAS_ASOCIAR", 4, _
    '                                                    iidunidadtransporte, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function
    Public Function getagenciaasociar() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOUNIDADTRANSPORTE.SP_AGENCIAS_ASOCIAR", CommandType.StoredProcedure)
            db.AsignarParametro("iID_UNI_TRANSporte", iidunidadtransporte, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_agenciaterm", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
