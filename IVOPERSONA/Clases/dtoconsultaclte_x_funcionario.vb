Imports AccesoDatos
Public Class dtoconsultaclte_x_funcionario
    Private lidfuncionarios As Long
    Private lidtipo_persona As Long
    Private lcliente_corporativo As Long
    Private lidestado_registro As Long

    Public rst_funcionario As ADODB.Recordset
    Public rst_tipo_persona As ADODB.Recordset
#Region "PROPIEDADES"
    Public Property idfuncionarios() As Long
        Get
            Return lidfuncionarios
        End Get
        Set(ByVal value As Long)
            lidfuncionarios = value
        End Set
    End Property
    Public Property idtipo_persona() As Long
        Get
            Return lidtipo_persona
        End Get
        Set(ByVal value As Long)
            lidtipo_persona = value
        End Set
    End Property
    Public Property cliente_corporativo() As Long
        Get
            Return lcliente_corporativo
        End Get
        Set(ByVal value As Long)
            lcliente_corporativo = value
        End Set
    End Property
    Public Property idestado_registro() As Long
        Get
            Return lidestado_registro
        End Get
        Set(ByVal value As Long)
            lidestado_registro = value
        End Set
    End Property
#End Region

#Region "METODOS"
    'Ref:
    'Recupera al usuario y tipo de persona 

    'Public Function fn_getcmb_usuario_persona2009() As ADODB.Recordset
    '    Try
    '        Dim Obj As Object() = {"PKG_IVOUUTILS.SP_GETCMB_USUARIO_PERSONA", 0}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function

    Public Function fn_getcmb_usuario_persona() As DataSet
        Dim db As New BaseDatos

        db.Conectar()
        'hlamas 06-01-2014
        'db.CrearComando("PKG_IVOUUTILS.SP_GETCMB_USUARIO_PERSONA", CommandType.StoredProcedure)
        db.CrearComando("PKG_IVOUUTILS.SP_GETCMB_USUARIO_PERSONA_CAR", CommandType.StoredProcedure)
        db.AsignarParametro("ocur_usuario", OracleClient.OracleType.Cursor)
        db.AsignarParametro("ocur_tipo_persona", OracleClient.OracleType.Cursor)
        db.AsignarParametro("ocur_estado_registro", OracleClient.OracleType.Cursor)
        db.AsignarParametro("ocur_corporativo", OracleClient.OracleType.Cursor)

        db.Desconectar()
        Return db.EjecutarDataSet

        'Try
        '    Dim Obj As Object() = {"PKG_IVOUUTILS.SP_GETCMB_USUARIO_PERSONA", 0}
        '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        '    Return Nothing
        'End Try
    End Function
    'Public Function fn_carga_cliente_x_funcionario2009()
    '    Try
    '        Dim Obj As Object() = {"PKG_IVOPERSONA.sp_getclte_xfuncionario", 10, _
    '                                lidfuncionarios, 1, _
    '                                lidtipo_persona, 1, _
    '                                lcliente_corporativo, 1, _
    '                                lidestado_registro, 1}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function

    Public Function fn_carga_cliente_x_funcionario() As DataTable
        Dim db As New BaseDatos
        db.Conectar()
        'hlamas 06-01-2014
        'db.CrearComando("PKG_IVOPERSONA.sp_getclte_xfuncionario", CommandType.StoredProcedure)
        db.CrearComando("PKG_IVOPERSONA.SP_GETCLTE_XFUNCIONARIO_car", CommandType.StoredProcedure)
        db.AsignarParametro("iidfuncionarios", lidfuncionarios, OracleClient.OracleType.Number)
        db.AsignarParametro("iidtipo_persona", lidtipo_persona, OracleClient.OracleType.Number)
        db.AsignarParametro("icliente_corporativo", lcliente_corporativo, OracleClient.OracleType.Number)
        db.AsignarParametro("iidestado_registro", lidestado_registro, OracleClient.OracleType.Number)
        db.AsignarParametro("ocur_cliente", OracleClient.OracleType.Cursor)

        db.Desconectar()
        Return db.EjecutarDataTable
    End Function

#End Region
End Class