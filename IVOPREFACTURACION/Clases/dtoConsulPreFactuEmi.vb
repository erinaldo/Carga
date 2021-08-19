Imports AccesoDatos
Class dtoConsulPreFactuEmi
    Private snro_prefactura As String
    Private sip As String
    Private iidusuario_personal As Integer
    Private iidrol_usuario As Integer
    Public Property nro_prefactura() As String
        Get
            Return snro_prefactura
        End Get
        Set(ByVal value As String)
            snro_prefactura = value
        End Set
    End Property
    Public Property ip() As String
        Get
            Return sip
        End Get
        Set(ByVal value As String)
            sip = value
        End Set
    End Property
    Public Property idusuario_personal() As String
        Get
            Return iidusuario_personal
        End Get
        Set(ByVal value As String)
            iidusuario_personal = value
        End Set
    End Property
    Public Property idrol_usuario() As String
        Get
            Return iidrol_usuario
        End Get
        Set(ByVal value As String)
            iidrol_usuario = value
        End Set
    End Property
    'Public Function fn_AnularPrefactura2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_ANULA_PREFACTURA", 10, _
    '                                 snro_prefactura, 2, _
    '                                 sip, 2, _
    '                                 iidusuario_personal, 1, _
    '                                 iidrol_usuario, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    Public Function fn_AnularPrefactura() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_ANULA_PREFACTURA", CommandType.StoredProcedure)
            db.AsignarParametro("inro_prefactura", snro_prefactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iip", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iidusuario_personal", iidusuario_personal, OracleClient.OracleType.Number)
            db.AsignarParametro("iidrol_usuario", iidrol_usuario, OracleClient.OracleType.Number)
            db.AsignarParametro("oCUR_resultado", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class