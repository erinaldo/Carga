Imports AccesoDatos
Public Class dtoSolatendida
    Private Stidcliente As Integer
    Private Stcliente As String
    Private stfecha_hora_recojo As String
    Private stideagencia As Integer
    Private icontrol As Integer
    Private iidsolicitudrecojocarga As Integer
    Private inro_paquete_recojidos As Integer
    Private ipeso_kg_recojidos As Integer
    Private ivolumen_recogido As Integer
    Private iidtipoobservacion As Integer
    Private icierre_solicitud As Integer
    Private vobservacion As String
    Private vipmod As String
    Private iidrol_usuariomod As Integer
    Private iidusurio_personalmod As Integer
    Private vifeccierra As String
    Public Property Cliente() As String
        Get
            Return Stcliente
        End Get
        Set(ByVal value As String)
            Stcliente = value
        End Set
    End Property
    Public Property Idcliente() As Integer
        Get
            Return Stidcliente
        End Get
        Set(ByVal value As Integer)
            Stidcliente = value
        End Set
    End Property
    Public Property fecharecojo() As String
        Get
            Return stfecha_hora_recojo
        End Get
        Set(ByVal value As String)
            stfecha_hora_recojo = value
        End Set
    End Property
    Public Property idagencia() As Integer
        Get
            Return stideagencia
        End Get
        Set(ByVal value As Integer)
            stideagencia = value
        End Set
    End Property
    Public Property control() As Integer
        Get
            Return icontrol
        End Get
        Set(ByVal value As Integer)
            icontrol = value
        End Set
    End Property
    Public Property idsolicitudrecojocarga() As Integer
        Get
            Return iidsolicitudrecojocarga
        End Get
        Set(ByVal value As Integer)
            iidsolicitudrecojocarga = value
        End Set
    End Property
    Public Property nro_paquete_recojidos() As Integer
        Get
            Return inro_paquete_recojidos
        End Get
        Set(ByVal value As Integer)
            inro_paquete_recojidos = value
        End Set
    End Property
    Public Property peso_kg_recojidos() As Integer
        Get
            Return ipeso_kg_recojidos
        End Get
        Set(ByVal value As Integer)
            ipeso_kg_recojidos = value
        End Set
    End Property
    Public Property volumen_recogido() As Integer
        Get
            Return ivolumen_recogido
        End Get
        Set(ByVal value As Integer)
            ivolumen_recogido = value
        End Set
    End Property
    Public Property idtipoobservacion() As Integer
        Get
            Return iidtipoobservacion
        End Get
        Set(ByVal value As Integer)
            iidtipoobservacion = value
        End Set
    End Property
    Public Property cierre_solicitud() As Integer
        Get
            Return icierre_solicitud
        End Get
        Set(ByVal value As Integer)
            icierre_solicitud = value
        End Set
    End Property
    Public Property observacion() As String
        Get
            Return vobservacion
        End Get
        Set(ByVal value As String)
            vobservacion = value
        End Set
    End Property
    Public Property ipmod() As String
        Get
            Return vipmod
        End Get
        Set(ByVal value As String)
            vipmod = value
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
    Public Property feccierra() As String
        Get
            Return vifeccierra
        End Get
        Set(ByVal value As String)
            vifeccierra = value
        End Set
    End Property
    'Public Function Get_movil_recoge2009() As ADODB.Recordset
    '    Dim ObjAge As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_GETSOL_MOVIL_RECOGE", 6, stideagencia, 1, stfecha_hora_recojo, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjAge)
    'End Function
    Public Function Get_movil_recoge() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_GETSOL_MOVIL_RECOGE", CommandType.StoredProcedure)
            db.AsignarParametro("in_idagencia", stideagencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iv_fec_solicitada", stfecha_hora_recojo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_solicitud_porMovil", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function actualiza_resumenrecogido2009() As ADODB.Recordset
    '    Dim ObjAge As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_upd_solicitudrecogido", 26, _
    '                                                             icontrol, 1, _
    '                                                             iidsolicitudrecojocarga, 1, _
    '                                                             inro_paquete_recojidos, 1, _
    '                                                             ipeso_kg_recojidos, 1, _
    '                                                             ivolumen_recogido, 1, _
    '                                                             iidtipoobservacion, 1, _
    '                                                             icierre_solicitud, 1, _
    '                                                             vobservacion, 2, _
    '                                                             vipmod, 2, _
    '                                                             iidrol_usuariomod, 1, _
    '                                                             iidusurio_personalmod, 1, _
    '                                                             vifeccierra, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjAge)
    'End Function

    Public Function actualiza_resumenrecogido() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_upd_solicitudrecogido", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidsolicitudrecojocarga", iidsolicitudrecojocarga, OracleClient.OracleType.Int32)
            db.AsignarParametro("inro_paquete_recojidos", iidsolicitudrecojocarga, OracleClient.OracleType.Int32)
            db.AsignarParametro("ipeso_kg_recojidos", ipeso_kg_recojidos, OracleClient.OracleType.Int32)
            db.AsignarParametro("ivolumen_recogido", ivolumen_recogido, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidtipoobservacion", iidtipoobservacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("icierre_solicitud", icierre_solicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("vobservacion", vobservacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vipmod", vipmod, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iidrol_usuariomod", iidrol_usuariomod, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidusurio_personalmod", iidusurio_personalmod, OracleClient.OracleType.Int32)
            db.AsignarParametro("vifeccierra", vifeccierra, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocurdatos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCur_control", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

End Class
