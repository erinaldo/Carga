Imports AccesoDatos
Public Class dtoAgencias
    Dim MyIDAGENCIAS As Long
    Dim MyIDDISTRITO As Long
    Dim MyIDPROVINCIA As Long
    Dim MyIDDEPARTAMENTO As Long
    Dim MyIDPAIS As Long
    Dim MyNOMBRE_AGENCIA As String
    Dim MyIDAGENCIA_CONCESIONARIOS As Long
    Dim MyNOMBRE_CONTACTO_APEPAT As String
    Dim MyNOMBRE_CONTACTO_APEMAT As String
    Dim MyNOMBRE_CONTACTO As String
    Dim MyCELULAR As String
    Dim MyTELEFONO1 As String
    Dim MyTELEFONO2 As String
    Dim MyFAX1 As String
    Dim MyFAX2 As String
    Dim MyE_MAIL As String
    Dim MyRPM1 As String
    Dim MyRPM2 As String
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDROL_USUARIO As Long
    Dim MyIP As String
    Dim MyFECHA_REGISTRO As String
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyNOMBRE_CORTO As String
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyIPMOD As String
    Dim MyIDUNIDAD_AGENCIA As Long
    Dim MyIDTIPO_COMI_AGEN As String
    Dim MyCODAGENCIA As String
    Dim MyDIRECCION_AGENCIA As String
    Dim MyIDEMPRESAS_CONCESION As Long
    Dim MyCODIGO_AGENCIA As String
    Dim MyIDAGENCIAS_UNIX As Long
    Dim MyTIPO_BOLE_IMPRE As String
    Dim MyTIPO_FACTU_IMPRE As String
    Dim MyTIPO_GUIA_TRANSPOR_IMPRE As String
    Dim MyES_TERMINAL As Long
    Public Property IDAGENCIAS() As Long
        Get
            IDAGENCIAS = MyIDAGENCIAS
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS = value
        End Set
    End Property
    Public Property IDDISTRITO() As Long

        Get
            IDDISTRITO = MyIDDISTRITO
        End Get
        Set(ByVal value As Long)
            MyIDDISTRITO = value
        End Set
    End Property
    Public Property IDPROVINCIA() As Long

        Get
            IDPROVINCIA = MyIDPROVINCIA
        End Get
        Set(ByVal value As Long)
            MyIDPROVINCIA = value
        End Set
    End Property
    Public Property IDDEPARTAMENTO() As Long

        Get
            IDDEPARTAMENTO = MyIDDEPARTAMENTO
        End Get
        Set(ByVal value As Long)
            MyIDDEPARTAMENTO = value
        End Set
    End Property
    Public Property IDPAIS() As Long

        Get
            IDPAIS = MyIDPAIS
        End Get
        Set(ByVal value As Long)
            MyIDPAIS = value
        End Set
    End Property
    Public Property NOMBRE_AGENCIA() As String

        Get
            NOMBRE_AGENCIA = MyNOMBRE_AGENCIA
        End Get
        Set(ByVal value As String)
            MyNOMBRE_AGENCIA = value
        End Set
    End Property
    Public Property IDAGENCIA_CONCESIONARIOS() As Long

        Get
            IDAGENCIA_CONCESIONARIOS = MyIDAGENCIA_CONCESIONARIOS
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIA_CONCESIONARIOS = value
        End Set
    End Property
    Public Property NOMBRE_CONTACTO_APEPAT() As String

        Get
            NOMBRE_CONTACTO_APEPAT = MyNOMBRE_CONTACTO_APEPAT
        End Get
        Set(ByVal value As String)
            MyNOMBRE_CONTACTO_APEPAT = value
        End Set
    End Property
    Public Property NOMBRE_CONTACTO_APEMAT() As String

        Get
            NOMBRE_CONTACTO_APEMAT = MyNOMBRE_CONTACTO_APEMAT
        End Get
        Set(ByVal value As String)
            MyNOMBRE_CONTACTO_APEMAT = value
        End Set
    End Property
    Public Property NOMBRE_CONTACTO() As String

        Get
            NOMBRE_CONTACTO = MyNOMBRE_CONTACTO
        End Get
        Set(ByVal value As String)
            MyNOMBRE_CONTACTO = value
        End Set
    End Property
    Public Property CELULAR() As String

        Get
            CELULAR = MyCELULAR
        End Get
        Set(ByVal value As String)
            MyCELULAR = value
        End Set
    End Property
    Public Property TELEFONO1() As String

        Get
            TELEFONO1 = MyTELEFONO1
        End Get
        Set(ByVal value As String)
            MyTELEFONO1 = value
        End Set
    End Property
    Public Property TELEFONO2() As String

        Get
            TELEFONO2 = MyTELEFONO2
        End Get
        Set(ByVal value As String)
            MyTELEFONO2 = value
        End Set
    End Property
    Public Property FAX1() As String

        Get
            FAX1 = MyFAX1
        End Get
        Set(ByVal value As String)
            MyFAX1 = value
        End Set
    End Property
    Public Property FAX2() As String

        Get
            FAX2 = MyFAX2
        End Get
        Set(ByVal value As String)
            MyFAX2 = value
        End Set
    End Property
    Public Property E_MAIL() As String

        Get
            E_MAIL = MyE_MAIL
        End Get
        Set(ByVal value As String)
            MyE_MAIL = value
        End Set
    End Property
    Public Property RPM1() As String
        Get
            RPM1 = MyRPM1
        End Get
        Set(ByVal value As String)
            MyRPM1 = value
        End Set
    End Property
    Public Property RPM2() As String
        Get
            RPM2 = MyRPM2
        End Get
        Set(ByVal value As String)
            MyRPM2 = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL() As Long

        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL = value
        End Set
    End Property
    Public Property IDROL_USUARIO() As Long

        Get
            IDROL_USUARIO = MyIDROL_USUARIO
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIO = value
        End Set
    End Property
    Public Property IP() As String

        Get
            IP = MyIP
        End Get
        Set(ByVal value As String)
            MyIP = value
        End Set
    End Property
    Public Property FECHA_REGISTRO() As String

        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = value
        End Set
    End Property
    Public Property FECHA_ACTUALIZACION() As String

        Get
            FECHA_ACTUALIZACION = MyFECHA_ACTUALIZACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ACTUALIZACION = value
        End Set
    End Property
    Public Property IDESTADO_REGISTRO() As Long

        Get
            IDESTADO_REGISTRO = MyIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_REGISTRO = value
        End Set
    End Property
    Public Property NOMBRE_CORTO() As String
        Get
            NOMBRE_CORTO = MyNOMBRE_CORTO
        End Get
        Set(ByVal value As String)
            MyNOMBRE_CORTO = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONALMOD() As Long

        Get
            IDUSUARIO_PERSONALMOD = MyIDUSUARIO_PERSONALMOD
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONALMOD = value
        End Set
    End Property
    Public Property IDROL_USUARIOMOD() As Long

        Get
            IDROL_USUARIOMOD = MyIDROL_USUARIOMOD
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIOMOD = value
        End Set
    End Property
    Public Property IPMOD() As String

        Get
            IPMOD = MyIPMOD
        End Get
        Set(ByVal value As String)
            MyIPMOD = value
        End Set
    End Property
    Public Property IDUNIDAD_AGENCIA() As Long

        Get
            IDUNIDAD_AGENCIA = MyIDUNIDAD_AGENCIA
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA = value
        End Set
    End Property
    Public Property IDTIPO_COMI_AGEN() As String

        Get
            IDTIPO_COMI_AGEN = MyIDTIPO_COMI_AGEN
        End Get
        Set(ByVal value As String)
            MyIDTIPO_COMI_AGEN = value
        End Set
    End Property
    Public Property CODAGENCIA() As String
        Get
            CODAGENCIA = MyCODAGENCIA
        End Get
        Set(ByVal value As String)
            MyCODAGENCIA = value
        End Set
    End Property
    Public Property DIRECCION_AGENCIA() As String
        Get
            DIRECCION_AGENCIA = MyDIRECCION_AGENCIA
        End Get
        Set(ByVal value As String)
            MyDIRECCION_AGENCIA = value
        End Set
    End Property
    Public Property IDEMPRESAS_CONCESION() As Long
        Get
            IDEMPRESAS_CONCESION = MyIDEMPRESAS_CONCESION
        End Get
        Set(ByVal value As Long)
            MyIDEMPRESAS_CONCESION = value
        End Set
    End Property
    Public Property CODIGO_AGENCIA() As String
        Get
            CODIGO_AGENCIA = MyCODIGO_AGENCIA
        End Get
        Set(ByVal value As String)
            MyCODIGO_AGENCIA = value
        End Set
    End Property
    Public Property IDAGENCIAS_UNIX() As Long
        Get
            IDAGENCIAS_UNIX = MyIDAGENCIAS_UNIX
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS_UNIX = value
        End Set
    End Property
    Public Property TIPO_BOLE_IMPRE() As String
        Get
            TIPO_BOLE_IMPRE = MyTIPO_BOLE_IMPRE
        End Get
        Set(ByVal value As String)
            MyTIPO_BOLE_IMPRE = value
        End Set
    End Property
    Public Property TIPO_FACTU_IMPRE() As String
        Get
            TIPO_FACTU_IMPRE = MyTIPO_FACTU_IMPRE
        End Get
        Set(ByVal value As String)
            MyTIPO_FACTU_IMPRE = value
        End Set
    End Property
    Public Property TIPO_GUIA_TRANSPOR_IMPRE() As String
        Get
            TIPO_GUIA_TRANSPOR_IMPRE = MyTIPO_GUIA_TRANSPOR_IMPRE
        End Get
        Set(ByVal value As String)
            MyTIPO_GUIA_TRANSPOR_IMPRE = value
        End Set
    End Property
    Public Property ES_TERMINAL() As Long
        Get
            ES_TERMINAL = MyES_TERMINAL
        End Get
        Set(ByVal value As Long)
            MyES_TERMINAL = value
        End Set
    End Property
    'Sub SP_SELEC_AGENCIA_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Dim cmd As New OracleClient.OracleCommand

    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.sp_selec_gencia"
    '    cmd.Parameters.Add(New OracleParameter("P_IDAGENCIAS", OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleParameter("CUR_selec_gencia", OracleType.Cursor)).Direction = ParameterDirection.Output

    '    Dim DA As New OracleDataAdapter(cmd)
    '    Dim dt As New DataTable

    '    DA.Fill(dt)

    '    Dim dv As New DataView

    '    dv = dt.DefaultView

    '    If dv.Count < 1 Then Exit Sub

    '    If Not dv.Table.Rows(0).IsNull("IDAGENCIAS") Then IDAGENCIAS = dv.Table.Rows(0)("IDAGENCIAS") Else IDAGENCIAS = 0
    '    If Not dv.Table.Rows(0).IsNull("IDDISTRITO") Then IDDISTRITO = dv.Table.Rows(0)("IDDISTRITO") Else IDDISTRITO = 0
    '    If Not dv.Table.Rows(0).IsNull("IDPROVINCIA") Then IDPROVINCIA = dv.Table.Rows(0)("IDPROVINCIA") Else IDPROVINCIA = 0
    '    If Not dv.Table.Rows(0).IsNull("IDDEPARTAMENTO") Then IDDEPARTAMENTO = dv.Table.Rows(0)("IDDEPARTAMENTO") Else IDDEPARTAMENTO = 0
    '    If Not dv.Table.Rows(0).IsNull("IDPAIS") Then IDPAIS = dv.Table.Rows(0)("IDPAIS") Else IDPAIS = 0
    '    If Not dv.Table.Rows(0).IsNull("NOMBRE_AGENCIA") Then NOMBRE_AGENCIA = dv.Table.Rows(0)("NOMBRE_AGENCIA") Else NOMBRE_AGENCIA = ""
    '    If Not dv.Table.Rows(0).IsNull("IDAGENCIA_CONCESIONARIOS") Then IDAGENCIA_CONCESIONARIOS = dv.Table.Rows(0)("IDAGENCIA_CONCESIONARIOS") Else IDAGENCIA_CONCESIONARIOS = 0
    '    If Not dv.Table.Rows(0).IsNull("NOMBRE_CONTACTO_APEPAT") Then NOMBRE_CONTACTO_APEPAT = dv.Table.Rows(0)("NOMBRE_CONTACTO_APEPAT") Else NOMBRE_CONTACTO_APEPAT = ""
    '    If Not dv.Table.Rows(0).IsNull("NOMBRE_CONTACTO_APEMAT") Then NOMBRE_CONTACTO_APEMAT = dv.Table.Rows(0)("NOMBRE_CONTACTO_APEMAT") Else NOMBRE_CONTACTO_APEMAT = ""
    '    If Not dv.Table.Rows(0).IsNull("NOMBRE_CONTACTO") Then NOMBRE_CONTACTO = dv.Table.Rows(0)("NOMBRE_CONTACTO") Else NOMBRE_CONTACTO = ""
    '    If Not dv.Table.Rows(0).IsNull("CELULAR") Then CELULAR = dv.Table.Rows(0)("CELULAR") Else CELULAR = ""
    '    If Not dv.Table.Rows(0).IsNull("TELEFONO1") Then TELEFONO1 = dv.Table.Rows(0)("TELEFONO1") Else TELEFONO1 = ""
    '    If Not dv.Table.Rows(0).IsNull("TELEFONO2") Then TELEFONO2 = dv.Table.Rows(0)("TELEFONO2") Else TELEFONO2 = ""
    '    If Not dv.Table.Rows(0).IsNull("FAX1") Then FAX1 = dv.Table.Rows(0)("FAX1") Else FAX1 = ""
    '    If Not dv.Table.Rows(0).IsNull("FAX2") Then FAX2 = dv.Table.Rows(0)("FAX2") Else FAX2 = ""
    '    If Not dv.Table.Rows(0).IsNull("E_MAIL") Then E_MAIL = dv.Table.Rows(0)("E_MAIL") Else E_MAIL = ""
    '    If Not dv.Table.Rows(0).IsNull("RPM1") Then RPM1 = dv.Table.Rows(0)("RPM1") Else RPM1 = ""
    '    If Not dv.Table.Rows(0).IsNull("RPM2") Then RPM2 = dv.Table.Rows(0)("RPM2") Else RPM2 = ""
    '    If Not dv.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dv.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
    '    If Not dv.Table.Rows(0).IsNull("IDROL_USUARIO") Then IDROL_USUARIO = dv.Table.Rows(0)("IDROL_USUARIO") Else IDROL_USUARIO = 0
    '    If Not dv.Table.Rows(0).IsNull("IP") Then IP = dv.Table.Rows(0)("IP") Else IP = ""
    '    If Not dv.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dv.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
    '    If Not dv.Table.Rows(0).IsNull("FECHA_ACTUALIZACION") Then FECHA_ACTUALIZACION = dv.Table.Rows(0)("FECHA_ACTUALIZACION") Else FECHA_ACTUALIZACION = ""
    '    If Not dv.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dv.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
    '    If Not dv.Table.Rows(0).IsNull("NOMBRE_CORTO") Then NOMBRE_CORTO = dv.Table.Rows(0)("NOMBRE_CORTO") Else NOMBRE_CORTO = ""
    '    If Not dv.Table.Rows(0).IsNull("IDUSUARIO_PERSONALMOD") Then IDUSUARIO_PERSONALMOD = dv.Table.Rows(0)("IDUSUARIO_PERSONALMOD") Else IDUSUARIO_PERSONALMOD = 0
    '    If Not dv.Table.Rows(0).IsNull("IDROL_USUARIOMOD") Then IDROL_USUARIOMOD = dv.Table.Rows(0)("IDROL_USUARIOMOD") Else IDROL_USUARIOMOD = 0
    '    If Not dv.Table.Rows(0).IsNull("IPMOD") Then IPMOD = dv.Table.Rows(0)("IPMOD") Else IPMOD = ""
    '    If Not dv.Table.Rows(0).IsNull("IDUNIDAD_AGENCIA") Then IDUNIDAD_AGENCIA = dv.Table.Rows(0)("IDUNIDAD_AGENCIA") Else IDUNIDAD_AGENCIA = 0
    '    If Not dv.Table.Rows(0).IsNull("IDTIPO_COMI_AGEN") Then IDTIPO_COMI_AGEN = dv.Table.Rows(0)("IDTIPO_COMI_AGEN") Else IDTIPO_COMI_AGEN = ""
    '    If Not dv.Table.Rows(0).IsNull("CODAGENCIA") Then CODAGENCIA = dv.Table.Rows(0)("CODAGENCIA") Else CODAGENCIA = ""
    '    If Not dv.Table.Rows(0).IsNull("DIRECCION_AGENCIA") Then DIRECCION_AGENCIA = dv.Table.Rows(0)("DIRECCION_AGENCIA") Else DIRECCION_AGENCIA = ""
    '    If Not dv.Table.Rows(0).IsNull("IDEMPRESAS_CONCESION") Then IDEMPRESAS_CONCESION = dv.Table.Rows(0)("IDEMPRESAS_CONCESION") Else IDEMPRESAS_CONCESION = 0
    '    If Not dv.Table.Rows(0).IsNull("CODIGO_AGENCIA") Then CODIGO_AGENCIA = dv.Table.Rows(0)("CODIGO_AGENCIA") Else CODIGO_AGENCIA = ""
    '    If Not dv.Table.Rows(0).IsNull("IDAGENCIAS_UNIX") Then IDAGENCIAS_UNIX = dv.Table.Rows(0)("IDAGENCIAS_UNIX") Else IDAGENCIAS_UNIX = 0
    '    If Not dv.Table.Rows(0).IsNull("TIPO_BOLE_IMPRE") Then TIPO_BOLE_IMPRE = dv.Table.Rows(0)("TIPO_BOLE_IMPRE") Else TIPO_BOLE_IMPRE = ""
    '    If Not dv.Table.Rows(0).IsNull("TIPO_FACTU_IMPRE") Then TIPO_FACTU_IMPRE = dv.Table.Rows(0)("TIPO_FACTU_IMPRE") Else TIPO_FACTU_IMPRE = ""
    '    If Not dv.Table.Rows(0).IsNull("TIPO_GUIA_TRANSPOR_IMPRE") Then TIPO_GUIA_TRANSPOR_IMPRE = dv.Table.Rows(0)("TIPO_GUIA_TRANSPOR_IMPRE") Else TIPO_GUIA_TRANSPOR_IMPRE = ""
    '    If Not dv.Table.Rows(0).IsNull("ES_TERMINAL") Then ES_TERMINAL = dv.Table.Rows(0)("ES_TERMINAL") Else ES_TERMINAL = 0
    'End Sub
    Sub SP_SELEC_AGENCIA()
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As DataTable
            Dim dv As New DataView
            '
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_selec_gencia", CommandType.StoredProcedure)
            '
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Number)

            '
            db.AsignarParametro("CUR_selec_gencia", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            ldt_tmp = db.EjecutarDataTable
            '
            dv = ldt_tmp.DefaultView
            If dv.Count < 1 Then Exit Sub
            If Not dv.Table.Rows(0).IsNull("IDAGENCIAS") Then IDAGENCIAS = dv.Table.Rows(0)("IDAGENCIAS") Else IDAGENCIAS = 0
            If Not dv.Table.Rows(0).IsNull("IDDISTRITO") Then IDDISTRITO = dv.Table.Rows(0)("IDDISTRITO") Else IDDISTRITO = 0
            If Not dv.Table.Rows(0).IsNull("IDPROVINCIA") Then IDPROVINCIA = dv.Table.Rows(0)("IDPROVINCIA") Else IDPROVINCIA = 0
            If Not dv.Table.Rows(0).IsNull("IDDEPARTAMENTO") Then IDDEPARTAMENTO = dv.Table.Rows(0)("IDDEPARTAMENTO") Else IDDEPARTAMENTO = 0
            If Not dv.Table.Rows(0).IsNull("IDPAIS") Then IDPAIS = dv.Table.Rows(0)("IDPAIS") Else IDPAIS = 0
            If Not dv.Table.Rows(0).IsNull("NOMBRE_AGENCIA") Then NOMBRE_AGENCIA = dv.Table.Rows(0)("NOMBRE_AGENCIA") Else NOMBRE_AGENCIA = ""
            If Not dv.Table.Rows(0).IsNull("IDAGENCIA_CONCESIONARIOS") Then IDAGENCIA_CONCESIONARIOS = dv.Table.Rows(0)("IDAGENCIA_CONCESIONARIOS") Else IDAGENCIA_CONCESIONARIOS = 0
            If Not dv.Table.Rows(0).IsNull("NOMBRE_CONTACTO_APEPAT") Then NOMBRE_CONTACTO_APEPAT = dv.Table.Rows(0)("NOMBRE_CONTACTO_APEPAT") Else NOMBRE_CONTACTO_APEPAT = ""
            If Not dv.Table.Rows(0).IsNull("NOMBRE_CONTACTO_APEMAT") Then NOMBRE_CONTACTO_APEMAT = dv.Table.Rows(0)("NOMBRE_CONTACTO_APEMAT") Else NOMBRE_CONTACTO_APEMAT = ""
            If Not dv.Table.Rows(0).IsNull("NOMBRE_CONTACTO") Then NOMBRE_CONTACTO = dv.Table.Rows(0)("NOMBRE_CONTACTO") Else NOMBRE_CONTACTO = ""
            If Not dv.Table.Rows(0).IsNull("CELULAR") Then CELULAR = dv.Table.Rows(0)("CELULAR") Else CELULAR = ""
            If Not dv.Table.Rows(0).IsNull("TELEFONO1") Then TELEFONO1 = dv.Table.Rows(0)("TELEFONO1") Else TELEFONO1 = ""
            If Not dv.Table.Rows(0).IsNull("TELEFONO2") Then TELEFONO2 = dv.Table.Rows(0)("TELEFONO2") Else TELEFONO2 = ""
            If Not dv.Table.Rows(0).IsNull("FAX1") Then FAX1 = dv.Table.Rows(0)("FAX1") Else FAX1 = ""
            If Not dv.Table.Rows(0).IsNull("FAX2") Then FAX2 = dv.Table.Rows(0)("FAX2") Else FAX2 = ""
            If Not dv.Table.Rows(0).IsNull("E_MAIL") Then E_MAIL = dv.Table.Rows(0)("E_MAIL") Else E_MAIL = ""
            If Not dv.Table.Rows(0).IsNull("RPM1") Then RPM1 = dv.Table.Rows(0)("RPM1") Else RPM1 = ""
            If Not dv.Table.Rows(0).IsNull("RPM2") Then RPM2 = dv.Table.Rows(0)("RPM2") Else RPM2 = ""
            If Not dv.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dv.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
            If Not dv.Table.Rows(0).IsNull("IDROL_USUARIO") Then IDROL_USUARIO = dv.Table.Rows(0)("IDROL_USUARIO") Else IDROL_USUARIO = 0
            If Not dv.Table.Rows(0).IsNull("IP") Then IP = dv.Table.Rows(0)("IP") Else IP = ""
            If Not dv.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dv.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
            If Not dv.Table.Rows(0).IsNull("FECHA_ACTUALIZACION") Then FECHA_ACTUALIZACION = dv.Table.Rows(0)("FECHA_ACTUALIZACION") Else FECHA_ACTUALIZACION = ""
            If Not dv.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dv.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
            If Not dv.Table.Rows(0).IsNull("NOMBRE_CORTO") Then NOMBRE_CORTO = dv.Table.Rows(0)("NOMBRE_CORTO") Else NOMBRE_CORTO = ""
            If Not dv.Table.Rows(0).IsNull("IDUSUARIO_PERSONALMOD") Then IDUSUARIO_PERSONALMOD = dv.Table.Rows(0)("IDUSUARIO_PERSONALMOD") Else IDUSUARIO_PERSONALMOD = 0
            If Not dv.Table.Rows(0).IsNull("IDROL_USUARIOMOD") Then IDROL_USUARIOMOD = dv.Table.Rows(0)("IDROL_USUARIOMOD") Else IDROL_USUARIOMOD = 0
            If Not dv.Table.Rows(0).IsNull("IPMOD") Then IPMOD = dv.Table.Rows(0)("IPMOD") Else IPMOD = ""
            If Not dv.Table.Rows(0).IsNull("IDUNIDAD_AGENCIA") Then IDUNIDAD_AGENCIA = dv.Table.Rows(0)("IDUNIDAD_AGENCIA") Else IDUNIDAD_AGENCIA = 0
            If Not dv.Table.Rows(0).IsNull("IDTIPO_COMI_AGEN") Then IDTIPO_COMI_AGEN = dv.Table.Rows(0)("IDTIPO_COMI_AGEN") Else IDTIPO_COMI_AGEN = ""
            If Not dv.Table.Rows(0).IsNull("CODAGENCIA") Then CODAGENCIA = dv.Table.Rows(0)("CODAGENCIA") Else CODAGENCIA = ""
            If Not dv.Table.Rows(0).IsNull("DIRECCION_AGENCIA") Then DIRECCION_AGENCIA = dv.Table.Rows(0)("DIRECCION_AGENCIA") Else DIRECCION_AGENCIA = ""
            If Not dv.Table.Rows(0).IsNull("IDEMPRESAS_CONCESION") Then IDEMPRESAS_CONCESION = dv.Table.Rows(0)("IDEMPRESAS_CONCESION") Else IDEMPRESAS_CONCESION = 0
            If Not dv.Table.Rows(0).IsNull("CODIGO_AGENCIA") Then CODIGO_AGENCIA = dv.Table.Rows(0)("CODIGO_AGENCIA") Else CODIGO_AGENCIA = ""
            If Not dv.Table.Rows(0).IsNull("IDAGENCIAS_UNIX") Then IDAGENCIAS_UNIX = dv.Table.Rows(0)("IDAGENCIAS_UNIX") Else IDAGENCIAS_UNIX = 0
            If Not dv.Table.Rows(0).IsNull("TIPO_BOLE_IMPRE") Then TIPO_BOLE_IMPRE = dv.Table.Rows(0)("TIPO_BOLE_IMPRE") Else TIPO_BOLE_IMPRE = ""
            If Not dv.Table.Rows(0).IsNull("TIPO_FACTU_IMPRE") Then TIPO_FACTU_IMPRE = dv.Table.Rows(0)("TIPO_FACTU_IMPRE") Else TIPO_FACTU_IMPRE = ""
            If Not dv.Table.Rows(0).IsNull("TIPO_GUIA_TRANSPOR_IMPRE") Then TIPO_GUIA_TRANSPOR_IMPRE = dv.Table.Rows(0)("TIPO_GUIA_TRANSPOR_IMPRE") Else TIPO_GUIA_TRANSPOR_IMPRE = ""
            If Not dv.Table.Rows(0).IsNull("ES_TERMINAL") Then ES_TERMINAL = dv.Table.Rows(0)("ES_TERMINAL") Else ES_TERMINAL = 0
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
End Class
