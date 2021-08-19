Imports AccesoDatos
Public Class dto_gestion_carga
#Region "Variables"
    Dim li_idtipo_comprobante As Long
    Dim li_idcomprobante As Long
#End Region
#Region "Propiedades"
    Public Property idtipo_comprobante() As Long
        Get
            idtipo_comprobante = li_idtipo_comprobante
        End Get
        Set(ByVal value As Long)
            li_idtipo_comprobante = value
        End Set
    End Property
    Public Property idcomprobante() As Long
        Get
            idcomprobante = li_idcomprobante
        End Get
        Set(ByVal value As Long)
            li_idcomprobante = value
        End Set
    End Property
#End Region
#Region "Métodos"
    Function sf_bultos_no_leidos() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("SP_BULTOS_NO_LEIDOS", CommandType.StoredProcedure)
            'Parametro entrada
            db.AsignarParametro("vi_tipo", li_idtipo_comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_documento", li_idcomprobante, OracleClient.OracleType.Int32)
            ''Parametro salida 
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

End Class