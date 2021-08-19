Imports AccesoDatos
Public Class dtoSolicitudRecojoCarga
    Private icontrol As Integer
    Private inrosolicitud As Integer
    Private Stidcltellamada As String
    Private Stidcliente As Integer
    Private Stiddireccion As Integer
    Private Stcliente As String
    Private StDireccion As String
    Private stideagencia As Integer
    Private stfecha_hora_recojo As String
    Private sthora_ini As String
    Private sthora_fin As String
    Private stnro_paquetes As Long
    Private stpeso_kg As Double
    Private stvolumen As Double
    Private stobservacion As String
    Private stestado_recojo As Integer
    Private stidusuario_personal As Integer
    Private stip As String
    Private stidrol_usuario As Integer
    Private stidnrosolicitud As Integer
    'Para el ingreso de direccion y contacto 
    Private stidcontacto_persona As Integer
    Private stdireccionconsignado As Integer
    Private itipodireccion As Integer
    Private iidubigeo As Integer
    Private iidpais As Integer
    Private iiddpto As Integer
    Private iidprov As Integer
    Private iiddistrito As Integer
    Private ssdireccion As String
    Private ssrefllegada As String
    Private ssnrodcto As String
    Private sapellido_y_nombres As String
    'Private ssnombre As String
    'Private ssapepaterno As String
    'Private ssapematerno As String
    Private iidsucuenta As Integer
    Private iidcargo As Integer
    Private iidtipdcto As Integer
    Private iidsexo As Integer
    Private iitiposubcuenta As Integer
    Private sdestino As String '
    '
    Private ll_idunidad_agencia As Long
    Private myl_idagencia As Long
    Private ls_fecha_solicitud As String
    Private ls_telefono_contacto As String
    Private ls_emnail As String
    '
    Public Property fechasolicitud() As String
        Get
            Return ls_fecha_solicitud
        End Get
        Set(ByVal value As String)
            ls_fecha_solicitud = value
        End Set
    End Property
    Public Property emnail() As String
        Get
            Return ls_emnail
        End Get
        Set(ByVal value As String)
            ls_emnail = value
        End Set
    End Property
    Public Property telefono_contacto() As String
        Get
            Return ls_telefono_contacto
        End Get
        Set(ByVal value As String)
            ls_telefono_contacto = value
        End Set
    End Property

    Public Property idagencias() As Long
        Get
            Return myl_idagencia
        End Get
        Set(ByVal value As Long)
            myl_idagencia = value
        End Set
    End Property
    Public Property idunidad_agencia() As Long
        Get
            Return idunidad_agencia
        End Get
        Set(ByVal value As Long)
            ll_idunidad_agencia = value
        End Set
    End Property
    Public Property contacto_persona() As Integer
        Get
            Return stidcontacto_persona
        End Get
        Set(ByVal value As Integer)
            stidcontacto_persona = value
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
    Public Property idrol_usuario() As Integer
        Get
            Return stidrol_usuario
        End Get
        Set(ByVal value As Integer)
            stidrol_usuario = value
        End Set
    End Property
    Public Property idusuario() As Integer
        Get
            Return stidusuario_personal
        End Get
        Set(ByVal value As Integer)
            stidusuario_personal = value
        End Set
    End Property
    Public Property observacion() As String
        Get
            Return stobservacion
        End Get
        Set(ByVal value As String)
            stobservacion = value
        End Set
    End Property
    Public Property ip() As String
        Get
            Return stip
        End Get
        Set(ByVal value As String)
            stip = value
        End Set
    End Property
    Public Property clientellamada() As String
        Get
            Return Stidcltellamada
        End Get
        Set(ByVal value As String)
            Stidcltellamada = value
        End Set
    End Property
    Public Property estadorecojo() As Integer
        Get
            Return stestado_recojo
        End Get
        Set(ByVal value As Integer)
            stestado_recojo = value
        End Set
    End Property
    Public Property volumen() As Double
        Get
            Return stvolumen
        End Get
        Set(ByVal value As Double)
            stvolumen = value
        End Set
    End Property
    Public Property nropaquetes() As Double
        Get
            Return stnro_paquetes
        End Get
        Set(ByVal value As Double)
            stnro_paquetes = value
        End Set
    End Property
    Public Property peso_kg() As Double
        Get
            Return stpeso_kg
        End Get
        Set(ByVal value As Double)
            stpeso_kg = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return Stcliente
        End Get
        Set(ByVal value As String)
            Stcliente = value
        End Set
    End Property
    Public Property hora_ini() As String
        Get
            Return sthora_ini
        End Get
        Set(ByVal value As String)
            sthora_ini = value
        End Set
    End Property
    Public Property hora_fin() As String
        Get
            Return sthora_fin
        End Get
        Set(ByVal value As String)
            sthora_fin = value
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
    Public Property Direccion() As String
        Get
            Return StDireccion
        End Get
        Set(ByVal value As String)
            StDireccion = value
        End Set
    End Property
    Public Property Iddireccion() As Integer
        Get
            Return Stiddireccion
        End Get
        Set(ByVal value As Integer)
            Stiddireccion = value
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
    Public Property tipodireccion() As Integer
        Get
            Return itipodireccion
        End Get
        Set(ByVal value As Integer)
            itipodireccion = value
        End Set
    End Property
    Public Property idubigeo() As Integer
        Get
            Return iidubigeo
        End Get
        Set(ByVal value As Integer)
            iidubigeo = value
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
    Public Property iddpto() As Integer
        Get
            Return iiddpto
        End Get
        Set(ByVal value As Integer)
            iiddpto = value
        End Set
    End Property
    Public Property idprov() As Integer
        Get
            Return iidprov
        End Get
        Set(ByVal value As Integer)
            iidprov = value
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
    Public Property sdireccion() As String
        Get
            Return ssdireccion
        End Get
        Set(ByVal value As String)
            ssdireccion = value
        End Set
    End Property
    Public Property srefllegada() As String
        Get
            Return ssrefllegada
        End Get
        Set(ByVal value As String)
            ssrefllegada = value
        End Set
    End Property
    Public Property snrodcto() As String
        Get
            Return ssnrodcto
        End Get
        Set(ByVal value As String)
            ssnrodcto = value
        End Set
    End Property
    Public Property apellido_y_nombres() As String
        Get
            Return sapellido_y_nombres
        End Get
        Set(ByVal value As String)
            sapellido_y_nombres = value
        End Set
    End Property
    'Public Property snombre() As String
    '    Get
    '        Return ssnombre
    '    End Get
    '    Set(ByVal value As String)
    '        ssnombre = value
    '    End Set
    'End Property
    'Public Property sapepaterno() As String
    '    Get
    '        Return ssapepaterno
    '    End Get
    '    Set(ByVal value As String)
    '        ssapepaterno = value
    '    End Set
    'End Property
    'Public Property sapematerno() As String
    '    Get
    '        Return ssapematerno
    '    End Get
    '    Set(ByVal value As String)
    '        ssapematerno = value
    '    End Set
    'End Property
    Public Property idsucuenta() As Integer
        Get
            Return iidsucuenta
        End Get
        Set(ByVal value As Integer)
            iidsucuenta = value
        End Set
    End Property
    Public Property idcargo() As Integer
        Get
            Return iidcargo
        End Get
        Set(ByVal value As Integer)
            iidcargo = value
        End Set
    End Property
    Public Property idtipdcto() As Integer
        Get
            Return iidtipdcto
        End Get
        Set(ByVal value As Integer)
            iidtipdcto = value
        End Set
    End Property
    Public Property idsexo() As Integer
        Get
            Return iidsexo
        End Get
        Set(ByVal value As Integer)
            iidsexo = value
        End Set
    End Property
    'Public Property tiposubcuenta() As Integer
    '    Get
    '        Return iitiposubcuenta
    '    End Get
    '    Set(ByVal value As Integer)
    '        iitiposubcuenta = value
    '    End Set
    'End Property
    Public Property nrosolicitud() As Integer
        Get
            Return stidnrosolicitud
        End Get
        Set(ByVal value As Integer)
            stidnrosolicitud = value
        End Set
    End Property
    Public Property direccionconsignado() As Integer
        Get
            Return stdireccionconsignado
        End Get
        Set(ByVal value As Integer)
            stdireccionconsignado = value
        End Set
    End Property
    Public Property destino() As String
        Get
            Return sdestino
        End Get
        Set(ByVal value As String)
            sdestino = value
        End Set
    End Property
    Public Function get_recupera_ciudad(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
        Try
            Dim cmd As New System.Data.OracleClient.OracleCommand
            '
            cmd.Connection = cnn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "PKG_IVORECEPCION_RECOJO_CARGA.sp_get_recupera_ciudad"
            '
            'Paramtetro de ingresos 
            cmd.Parameters.Add(New OracleClient.OracleParameter("ni_agencia", OracleClient.OracleType.Number)).Value = idagencias
            'Parametro de Salidas 
            cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_ciudad", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
            '
            Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
            '
            Dim ds As New DataSet
            daora.Fill(ds)
            '
            Dim dv As New DataView
            '
            dv = ds.Tables(0).DefaultView
            '
            Return dv
            '
        Catch Ex As System.Exception
            MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        Catch OEx As System.Data.OracleClient.OracleException
            MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Function
    'Public Function get_solicitud_unica2009() As ADODB.Recordset
    '    Dim ObjSolCarga As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_SOLICITUD_UNICA", 4, _
    '                                                                       stidnrosolicitud, 3}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjSolCarga)
    'End Function
    Public Function get_solicitud_unica() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_SOLICITUD_UNICA", CommandType.StoredProcedure)
            db.AsignarParametro("iidsolicitud_recojo_carga", stidnrosolicitud, OracleClient.OracleType.Number)
            db.AsignarParametro("oCUR_SOLICITUD", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function get_solicitud2009() As ADODB.Recordset
    '    stidnrosolicitud = Nothing  'No se porque se ha puesto ...
    '    Dim ObjSolCarga As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_SOLICITUD", 6, stideagencia, 1, stfecha_hora_recojo, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjSolCarga)
    'End Function

    Public Function get_solicitud() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_GET_SOLICITUD", CommandType.StoredProcedure)
            db.AsignarParametro("IN_IDAGENCIA", stideagencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("IV_FEC_SOLICITADA", stfecha_hora_recojo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_SOLICITUD", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function actualizar2009() As ADODB.Recordset
    '    Dim Objinsertasolicitud As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_ACTUALIZA_SOLICITUD", 68, _
    '                                    icontrol, 1, _
    '                                    stidnrosolicitud, 1, _
    '                                    stideagencia, 1, _
    '                                    stfecha_hora_recojo, 2, _
    '                                    Stidcltellamada, 2, _
    '                                    Stidcliente, 1, _
    '                                    Stiddireccion, 1, _
    '                                    stidcontacto_persona, 1, _
    '                                    sthora_ini, 2, _
    '                                    sthora_fin, 2, _
    '                                    stnro_paquetes, 1, _
    '                                    stpeso_kg, 3, _
    '                                    stvolumen, 3, _
    '                                    stobservacion, 2, _
    '                                    stestado_recojo, 1, _
    '                                    stidusuario_personal, 1, _
    '                                    stip, 2, _
    '                                    stidrol_usuario, 1, _
    '                                    itipodireccion, 1, _
    '                                    ssdireccion, 2, _
    '                                    ssrefllegada, 2, _
    '                                    iidubigeo, 1, _
    '                                    iidpais, 1, _
    '                                    iiddpto, 1, _
    '                                    iidprov, 1, _
    '                                    iiddistrito, 1, _
    '                                    iidcargo, 1, _
    '                                    sapellido_y_nombres, 2, _
    '                                    iidtipdcto, 1, _
    '                                    snrodcto, 2, _
    '                                    iidsexo, 1, _
    '                                    iidsucuenta, 1, _
    '                                    sdestino, 2}
    '    'Dim Objinsertasolicitud As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_ACTUALIZA_SOLICITUD", 72, _
    '    '                                        icontrol, 1, _
    '    '                                        stidnrosolicitud, 1, _
    '    '                                        stideagencia, 1, _
    '    '                                        stfecha_hora_recojo, 2, _
    '    '                                        Stidcltellamada, 2, _
    '    '                                        Stidcliente, 1, _
    '    '                                        Stiddireccion, 1, _
    '    '                                        stidcontacto_persona, 1, _
    '    '                                        sthora_ini, 2, _
    '    '                                        sthora_fin, 2, _
    '    '                                        stnro_paquetes, 1, _
    '    '                                        stpeso_kg, 3, _
    '    '                                        stvolumen, 3, _
    '    '                                        stobservacion, 2, _
    '    '                                        stestado_recojo, 1, _
    '    '                                        stidusuario_personal, 1, _
    '    '                                        stip, 2, _
    '    '                                        stidrol_usuario, 1, _
    '    '                                        itipodireccion, 1, _
    '    '                                        ssdireccion, 2, _
    '    '                                        ssrefllegada, 2, _
    '    '                                        iidubigeo, 1, _
    '    '                                        iidpais, 1, _
    '    '                                        iiddpto, 1, _
    '    '                                        iidprov, 1, _
    '    '                                        iiddistrito, 1, _
    '    '                                        iidcargo, 1, _
    '    '                                        snombre, 2, _
    '    '                                        sapepaterno, 2, _
    '    '                                        sapematerno, 2, _
    '    '                                        iidtipdcto, 1, _
    '    '                                        snrodcto, 2, _
    '    '                                        iidsexo, 1, _
    '    '                                        iidsucuenta, 1, _
    '    '                                        sdestino, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Objinsertasolicitud)
    'End Function

    Public Function actualizar() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_ACTUALIZA_SOLICITUD", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidnrosolicitud", stidnrosolicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_idagencias", stideagencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_fecha_hora_recojo", stfecha_hora_recojo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_nombre_cliente_llamada", Stidcltellamada, OracleClient.OracleType.VarChar)
            db.AsignarParametro("n_idpersona", Stidcliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("i_direccion_consignado", Stiddireccion, OracleClient.OracleType.Int32)
            db.AsignarParametro("i_idcontacto_persona", stidcontacto_persona, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_hora_ini", sthora_ini, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_hora_fin", sthora_fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("n_nro_paquetes", stnro_paquetes, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_peso_kg", stpeso_kg, OracleClient.OracleType.Number)
            db.AsignarParametro("n_volumen", stvolumen, OracleClient.OracleType.Number)
            db.AsignarParametro("v_obs", stobservacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("n_estado_recojo", stestado_recojo, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_idusuario_personal", stidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_ip", stip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("n_idrol_usuario", stidrol_usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("idtipodireccion", itipodireccion, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_direccion", ssdireccion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_refllegada", ssrefllegada, OracleClient.OracleType.VarChar)
            db.AsignarParametro("n_idubigeo", iidubigeo, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_idpais", iidpais, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_departamento", iiddpto, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_provincia", iidprov, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_iddistrito", iiddistrito, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_idcargo", iidcargo, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_apellido_y_nombre", sapellido_y_nombres, OracleClient.OracleType.VarChar)
            db.AsignarParametro("n_idtipdcto", iidtipdcto, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_nrodocumento", snrodcto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("n_idsexo", iidsexo, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_idsucuenta", iidsucuenta, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_destino", sdestino, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCur_nrosolcitud", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCur_control", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function get_persona2009() As ADODB.Recordset
    '    Dim ObjSolCarga As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_COMBOSPERSONA", 6, _
    '                                                                       stideagencia, 1, _
    '                                                                       stdireccionconsignado, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjSolCarga)
    'End Function
    Public Function get_persona() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_COMBOSPERSONA", CommandType.StoredProcedure)
            db.AsignarParametro("nidagencias", stideagencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("nIDDIRECCION_CONSIGNADO", stdireccionconsignado, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCUR_TIPODIRECCION", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_PAIS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_DEPTOS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_PROVINCIA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_DISTRITO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_CENTRO_COSTO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_TIPOCONTACTO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_TIPODOCTO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_agencia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_direccion", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

End Class
