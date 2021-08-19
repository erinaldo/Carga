Imports AccesoDatos
Public Class dtosolicitudcomun
    Private stideagencia As Integer
    Private iidnro_solicitud As Integer
    Private sipmod As String
    Private iidrol_usuariomod As Integer
    Private iidusurio_personalmod As Integer
    Private iidpais As Integer
    Private iiddepartamento As Integer
    Private iidprovincia As Integer
    Private iiddistrito As Integer
    Public Property idagencia() As Integer
        Get
            Return stideagencia
        End Get
        Set(ByVal value As Integer)
            stideagencia = value
        End Set
    End Property
    Public Property idnro_solicitud() As Integer
        Get
            Return iidnro_solicitud
        End Get
        Set(ByVal value As Integer)
            iidnro_solicitud = value
        End Set
    End Property
    Public Property ipmod() As String
        Get
            Return sipmod
        End Get
        Set(ByVal value As String)
            sipmod = value
        End Set
    End Property
    Public Property idrol_usuariomod() As Integer
        Get
            Return iidrol_usuariomod
        End Get
        Set(ByVal value As Integer)
            iidrol_usuariomod = value
        End Set
    End Property
    Public Property idusurio_personalmod() As Integer
        Get
            Return iidusurio_personalmod
        End Get
        Set(ByVal value As Integer)
            iidusurio_personalmod = value
        End Set
    End Property
    Public Property idpais() As Integer
        Get
            Return iidpais
        End Get
        Set(ByVal value As Integer)
            iidpais = value
        End Set
    End Property
    Public Property iddepartamento() As Integer
        Get
            Return iiddepartamento
        End Get
        Set(ByVal value As Integer)
            iiddepartamento = value
        End Set
    End Property
    Public Property idprovincia() As Integer
        Get
            Return iidprovincia
        End Get
        Set(ByVal value As Integer)
            iidprovincia = value
        End Set
    End Property
    Public Property iddistrito() As Integer
        Get
            Return iiddistrito
        End Get
        Set(ByVal value As Integer)
            iiddistrito = value
        End Set
    End Property
    'Public Function ListaAgencia2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_LISTA_AGENCIA", 4, iidusurio_personalmod, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function

    Public Function ListaAgencia() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'acceso 21/04/2010
            'db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_LISTA_AGENCIA", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_LISTA_AGENCIA_1", CommandType.StoredProcedure)
            db.AsignarParametro("nidusuario_personal", iidusurio_personalmod, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCURSOR_AGENCIA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCURSOR_procesorecojo", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function get_unidad_trans_x_agencia2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_GETUNIDAD_TRANS_X_AGENCIA", 4, stideagencia, 1}
    '    'Dim Obj As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_SOLICITUD_MOVIL", 4, stideagencia, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function
    'Public Function get_unidad_trans_x_agencia() As DataTable  --- No existe en la bd 
    '    Try
    '        Dim db As New BaseDatos
    '        db.Conectar()
    '        db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_GETUNIDAD_TRANS_X_AGENCIA", CommandType.StoredProcedure)
    '        '
    '        db.AsignarParametro("idagencia", stideagencia, OracleClient.OracleType.Int32)
    '        '
    '        db.AsignarParametro("oCUR_RUTA", OracleClient.OracleType.Cursor)
    '        '
    '        db.Desconectar()
    '        Return db.EjecutarDataTable
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    End Try
    'End Function
    Public Function get_combo() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_CMB_AGENCIA_RUTA_1", CommandType.StoredProcedure)
            'acceso 21/04/2010
            'db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_CMB_AGENCIA_RUTA", CommandType.StoredProcedure)
            db.AsignarParametro("iidusuario_personal", iidusurio_personalmod, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidprovincia", iidprovincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCURSOR_AGENCIA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_ruta", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_udtransporte", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_tipoobservacion", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function get_ruta_xagencia2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_CMB_RUTA_XAGENCIA", 4, iidprovincia, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function

    Public Function get_ruta_xagencia() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_CMB_RUTA_XAGENCIA", CommandType.StoredProcedure)
            db.AsignarParametro("iidprovincia", iidprovincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCUR_RUTA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function suspender_solicitud2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_susp_solicitudrecojo", 10, _
    '                                                                  iidnro_solicitud, 1, _
    '                                                                  sipmod, 2, _
    '                                                                  iidrol_usuariomod, 1, _
    '                                                                  iidusurio_personalmod, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function

    Public Function suspender_solicitud() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_susp_solicitudrecojo", CommandType.StoredProcedure)
            db.AsignarParametro("iidsolicitudrecojocarga", iidnro_solicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("vipmod", sipmod, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iidrol_usuariomod", iidrol_usuariomod, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidusurio_personalmod", iidusurio_personalmod, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocurdatos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCur_control", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class