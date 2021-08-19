Imports AccesoDatos
Public Class dtoCobranza
    Function CargarCobranza(ByVal tipo As Integer, ByVal idfactura As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOBRANZA.SP_CARGAR_COBRANZA", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idfactura", idfactura, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_cobranza", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function CargarHistorico(ByVal CO_EMPR As String, ByVal CO_BANC As String, ByVal AA_BNCO As String, _
                             ByVal MM_BNCO As String, ByVal TI_MOVI_BANC As String, ByVal NU_COMP_BANC As String, _
                             ByVal NU_SECU As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOBRANZA.SP_CARGAR_HISTORICO", CommandType.StoredProcedure)
            db.AsignarParametro("ni_CO_EMPR", CO_EMPR, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_CO_BANC", CO_BANC, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_AA_BNCO", AA_BNCO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_MM_BNCO", MM_BNCO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_TI_MOVI_BANC", TI_MOVI_BANC, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_NU_COMP_BANC", NU_COMP_BANC, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_NU_SECU", NU_SECU, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_historico", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function CargarHistorico(ByVal CO_EMPR As String, ByVal CO_UNID_CONC As String, ByVal NU_AMAR As String, _
                             ByVal FE_AMAR As String, ByVal NU_SECU As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOBRANZA.SP_CARGAR_HISTORICO", CommandType.StoredProcedure)
            db.AsignarParametro("ni_CO_EMPR", CO_EMPR, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_CO_UNID_CONC", CO_UNID_CONC, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_NU_AMAR", NU_AMAR, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_FE_AMAR", FE_AMAR, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_NU_SECU", NU_SECU, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_historico", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function CargarHistorico(ByVal CO_EMPR As String, ByVal CO_CAJA As String, ByVal AA_CAJA As String, _
                             ByVal MM_CAJA As String, ByVal TI_MOVI As String, ByVal NU_COMP_CAJA As String, _
                             ByVal NU_SECU As Integer, ByVal a As Integer, ByVal b As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOBRANZA.SP_CARGAR_HISTORICO", CommandType.StoredProcedure)
            db.AsignarParametro("ni_CO_EMPR", CO_EMPR, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_CO_CAJA", CO_CAJA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_AA_CAJA", AA_CAJA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_MM_CAJA", MM_CAJA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_TI_MOVI", TI_MOVI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_NU_COMP_CAJA", NU_COMP_CAJA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_NU_SECU", NU_SECU, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ID", a, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_historico", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function CargarHistorico(ByVal CO_EMPR As String, ByVal CO_UNID_CONC As String, ByVal NU_AMAR As String, ByVal FE_AMAR As String, ByVal NU_SECU As Integer, ByVal a As Integer, ByVal b As String, ByVal c As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOBRANZA.SP_CARGAR_HISTORICO", CommandType.StoredProcedure)
            db.AsignarParametro("ni_CO_EMPR", CO_EMPR, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_CO_UNID_CONC", CO_UNID_CONC, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_NU_AMAR", NU_AMAR, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_FE_AMAR", FE_AMAR, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_NU_SECU", NU_SECU, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ID", a, OracleClient.OracleType.Int32)
            'db.AsignarParametro("ni_ID_2", b, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_historico", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function CargarHistorico(ByVal CO_EMPR As String, ByVal CO_UNID_CONC As String, ByVal CO_CLIE As String, ByVal NU_CANJ As String, ByVal FE_CANJ As String, ByVal NU_SECU_CANJ As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOBRANZA.SP_CARGAR_HISTORICO", CommandType.StoredProcedure)
            db.AsignarParametro("ni_CO_EMPR", CO_EMPR, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_CO_UNID_CONC", CO_UNID_CONC, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_CO_CLIE", CO_CLIE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_NU_CANJ", NU_CANJ, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_FE_CANJ", FE_CANJ, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_NU_SECU_CANJ", NU_SECU_CANJ, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_historico", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function TotalCobranza(ByVal idfactura As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOBRANZA.SP_TOTAL_COBRANZA", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idfactura", idfactura, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_cobranza", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function CargarHistoricoTodo _
    (ByVal a As String, ByVal b As String, ByVal c As String, ByVal cc As String, _
    ByVal dd As String, ByVal ee As String, ByVal ff As String, _
    ByVal gg As String, ByVal d As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOBRANZA.SP_CARGAR_HISTORICO_TODO", CommandType.StoredProcedure)
            db.AsignarParametro("a", a, OracleClient.OracleType.VarChar)
            db.AsignarParametro("b", b, OracleClient.OracleType.VarChar)
            db.AsignarParametro("c", c, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cc", cc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("dd", dd, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ee", ee, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ff", ff, OracleClient.OracleType.VarChar)
            db.AsignarParametro("gg", gg, OracleClient.OracleType.VarChar)
            db.AsignarParametro("d", d, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_historico", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

End Class
