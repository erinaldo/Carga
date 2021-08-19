Imports AccesoDatos
Class AdoServer
#Region "Variables"

#End Region
#Region "Datatables"
    Public dt_Listar_agencias As New DataTable
#End Region

#Region "Propiedades"

#End Region
#Region "Procedimientos"
    Public Function ListarAgencias()
        Dim flag As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            dt_Listar_agencias = Nothing
            dt_Listar_agencias = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCONTROLUSUARIO.SP_LISTAR_AGENCIAS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_agencias", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            ' 
            dt_Listar_agencias = ldt_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
#End Region

End Class