Imports AccesoDatos
Public Class dtorecojopactado
    Private iidagencias As Integer
    Private icontrol As Integer
    Private iidrecojo_carga_pactado As Integer
    Private iidpersona As Integer
    Private iidireccion_consignado As Integer
    Private iidcontacto_persona As Integer
    Private vfecha_inicio As String
    Private vfecha_fin_pacto As String
    Private iidusuario_personal As Integer
    Private vip As String
    Private iidrol_usuario As Integer
    Private iidestado_registrado As Integer
    Private iidtipodireccion As Integer
    Private sdireccion As String
    Private srefllegada As String
    Private iidubigeo As Integer
    Private iidpais As Integer
    Private iidepartamento As Integer
    Private iidprovincia As Integer
    Private iidistrito As Integer
    Private iidcargo As Integer
    Private snombre As String
    Private sapepaterno As String
    Private sapematerno As String
    Private iidtipdcto As Integer
    Private snrodocumento As String
    Private iidsexo As Integer
    Private iidsucuenta As Integer
    Public Property idagencias() As Integer
        Get
            Return iidagencias
        End Get
        Set(ByVal value As Integer)
            iidagencias = value
        End Set
    End Property
    Public Property idsucuenta() As Integer
        Get
            Return iidsucuenta
        End Get
        Set(ByVal value As Integer)
            iidsucuenta = value
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
    Public Property nrodocumento() As String
        Get
            Return snrodocumento
        End Get
        Set(ByVal value As String)
            snrodocumento = value
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
    Public Property apematerno() As String
        Get
            Return sapematerno
        End Get
        Set(ByVal value As String)
            sapematerno = value
        End Set
    End Property
    Public Property apepaterno() As String
        Get
            Return sapepaterno
        End Get
        Set(ByVal value As String)
            sapepaterno = value
        End Set
    End Property
    Public Property nombre() As String
        Get
            Return snombre
        End Get
        Set(ByVal value As String)
            snombre = value
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
    Public Property idistrito() As Integer
        Get
            Return iidistrito
        End Get
        Set(ByVal value As Integer)
            iidistrito = value
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
    Public Property idepartamento() As Integer
        Get
            Return iidepartamento
        End Get
        Set(ByVal value As Integer)
            iidepartamento = value
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
    Public Property idubigeo() As Integer
        Get
            Return iidubigeo
        End Get
        Set(ByVal value As Integer)
            iidubigeo = value
        End Set
    End Property
    Public Property refllegada() As String
        Get
            Return srefllegada
        End Get
        Set(ByVal value As String)
            srefllegada = value
        End Set
    End Property
    Public Property direccion() As String
        Get
            Return sdireccion
        End Get
        Set(ByVal value As String)
            sdireccion = value
        End Set
    End Property
    Public Property idtipodireccion() As Integer
        Get
            Return iidtipodireccion
        End Get
        Set(ByVal value As Integer)
            iidtipodireccion = value
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
    Public Property idrecojo_carga_pactado() As Integer
        Get
            Return iidrecojo_carga_pactado
        End Get
        Set(ByVal value As Integer)
            iidrecojo_carga_pactado = value
        End Set
    End Property
    Public Property idpersona() As Integer
        Get
            Return iidpersona
        End Get
        Set(ByVal value As Integer)
            iidpersona = value
        End Set
    End Property
    Public Property idireccion_consignado() As Integer
        Get
            Return iidireccion_consignado
        End Get
        Set(ByVal value As Integer)
            iidireccion_consignado = value
        End Set
    End Property
    Public Property idcontacto_persona() As Integer
        Get
            Return iidcontacto_persona
        End Get
        Set(ByVal value As Integer)
            iidcontacto_persona = value
        End Set
    End Property
    Public Property fecha_inicio() As String
        Get
            Return vfecha_inicio
        End Get
        Set(ByVal value As String)
            vfecha_inicio = value
        End Set
    End Property
    Public Property fecha_fin_pacto() As String
        Get
            Return vfecha_fin_pacto
        End Get
        Set(ByVal value As String)
            vfecha_fin_pacto = value
        End Set
    End Property
    Public Property idusuario_personal() As Integer
        Get
            Return iidusuario_personal
        End Get
        Set(ByVal value As Integer)
            iidusuario_personal = value
        End Set
    End Property
    Public Property ip() As String
        Get
            Return vip
        End Get
        Set(ByVal value As String)
            vip = value
        End Set
    End Property
    Public Property idrol_usuario() As Integer
        Get
            Return iidrol_usuario
        End Get
        Set(ByVal value As Integer)
            iidrol_usuario = value
        End Set
    End Property
    Public Property idestado_registrado() As Integer
        Get
            Return iidestado_registrado
        End Get
        Set(ByVal value As Integer)
            iidestado_registrado = value
        End Set
    End Property
    'Public Function GetComborecojoacordado2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.COMBO_RECOJO_ACORDADO", 6, _
    '                                                                     iidusuario_personal, 1, _
    '                                                                     iidagencias, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function

    Public Function GetComborecojoacordado() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'acceso 21/04/2010
            'db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.COMBO_RECOJO_ACORDADO", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.COMBO_RECOJO_ACORDADO_1", CommandType.StoredProcedure)
            db.AsignarParametro("iidusuario", iidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidagencias", iidagencias, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCURSOR_INICIO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCURSOR_AGENCIA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCURSOR_clientes", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCursor_semana", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocursor_tipopacto", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function actualizarecojo_pactado2009() As ADODB.Recordset
    '    Dim Obj As Object() = {"PKG_IVORECEPCION_RECOJO_CARGA.SP_ACTUALIZA_RECOJO_PACTADO", 58, _
    '                                                          icontrol, 1, _
    '                                                          iidrecojo_carga_pactado, 1, _
    '                                                          iidagencias, 1, _
    '                                                          iidpersona, 1, _
    '                                                          iidireccion_consignado, 1, _
    '                                                          iidcontacto_persona, 1, _
    '                                                          vfecha_inicio, 2, _
    '                                                          vfecha_fin_pacto, 2, _
    '                                                          iidusuario_personal, 1, _
    '                                                          vip, 2, _
    '                                                          iidrol_usuario, 1, _
    '                                                          iidestado_registrado, 1, _
    '                                                          iidtipodireccion, 1, _
    '                                                          sdireccion, 2, _
    '                                                          srefllegada, 2, _
    '                                                          iidubigeo, 1, _
    '                                                          iidpais, 1, _
    '                                                          iidepartamento, 1, _
    '                                                          iidprovincia, 1, _
    '                                                          iidistrito, 1, _
    '                                                          iidcargo, 1, _
    '                                                          snombre, 2, _
    '                                                          sapepaterno, 2, _
    '                                                          sapematerno, 2, _
    '                                                          iidtipdcto, 1, _
    '                                                          snrodocumento, 2, _
    '                                                          iidsexo, 1, _
    '                                                          iidsucuenta, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    'End Function
    Public Function actualizarecojo_pactado() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVORECEPCION_RECOJO_CARGA.SP_ACTUALIZA_RECOJO_PACTADO", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidrecojo_carga_pactado", iidrecojo_carga_pactado, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidagencias", iidagencias, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidpersona", iidpersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidireccion_consignado", iidireccion_consignado, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidcontacto_persona", iidcontacto_persona, OracleClient.OracleType.Int32)
            db.AsignarParametro("vfecha_inicio", vfecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_fin_pacto", vfecha_fin_pacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iidusuario_personal", iidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("vip", vip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iidrol_usuario", iidrol_usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidestado_registrado", iidestado_registrado, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidtipodireccion", iidtipodireccion, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_direccion", sdireccion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_refllegada", srefllegada, OracleClient.OracleType.VarChar)
            db.AsignarParametro("n_idubigeo", iidubigeo, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_idpais", iidpais, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_departamento", iidepartamento, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_provincia", iidprovincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_iddistrito", iidistrito, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_idcargo", iidcargo, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_nombre", snombre, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apepaterno", sapepaterno, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_apematerno", sapematerno, OracleClient.OracleType.VarChar)
            db.AsignarParametro("n_idtipdcto", iidtipdcto, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_nrodocumento", snrodocumento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("n_idsexo", iidsexo, OracleClient.OracleType.Int32)
            db.AsignarParametro("n_idsucuenta", iidsucuenta, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCur_msg", OracleClient.OracleType.Cursor)
            db.AsignarParametro("Ocur_Datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

End Class
