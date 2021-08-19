Imports AccesoDatos
Public Class dtoGENERAL
#Region "Atributos"
    Dim my_iddprovincia As Long
    Dim my_iddepartamento As Long
    Dim my_idpais As Long
    Dim my_nro_meses_linea_credito As Long
    Dim my_fecha_inicio_lc As String
    '15/10/2008 
    Dim my_idusuario_personal As Long
    Dim my_login As String
    Dim my_password As String
    Dim my_retorno As Long
    Dim my_mensaje As String
    Dim my_clave As String
    Dim my_clave_final As String
    Dim my_patron As String
    Dim my_usuario As String
    Dim my_unidad As Integer
#End Region
#Region "Propiedades"
    Public Property mensaje() As String
        Get
            mensaje = my_mensaje
        End Get
        Set(ByVal value As String)
            my_mensaje = value
        End Set
    End Property
    Public Property retorno() As Long
        Get
            retorno = my_retorno
        End Get
        Set(ByVal value As Long)
            my_retorno = value
        End Set
    End Property
    Public Property password() As String
        Get
            password = my_password
        End Get
        Set(ByVal value As String)
            my_password = value
        End Set
    End Property
    Public Property login() As String
        Get
            login = my_login
        End Get
        Set(ByVal value As String)
            my_login = value
        End Set
    End Property
    Public Property idusuario_personal() As Long
        Get
            idusuario_personal = my_idusuario_personal
        End Get
        Set(ByVal value As Long)
            my_idusuario_personal = value
        End Set
    End Property
    Public Property clave() As String
        Get
            clave = my_clave
        End Get
        Set(ByVal value As String)
            my_clave = value
        End Set
    End Property

    Public Property clavefinal() As String
        Get
            clavefinal = my_clave_final
        End Get
        Set(ByVal value As String)
            my_clave = value
        End Set
    End Property

    Public Property patron() As String
        Get
            patron = my_patron
        End Get
        Set(ByVal value As String)
            my_patron = value
        End Set
    End Property

    Public Property fecha_inicio_lc() As String
        Get
            fecha_inicio_lc = my_fecha_inicio_lc
        End Get
        Set(ByVal value As String)
            my_fecha_inicio_lc = value
        End Set
    End Property
    Public Property nro_meses_linea_cred() As Long
        Get
            nro_meses_linea_cred = my_nro_meses_linea_credito
        End Get
        Set(ByVal value As Long)
            my_nro_meses_linea_credito = value
        End Set
    End Property
    Public Property idprovincia() As Long
        Get
            idprovincia = my_iddprovincia
        End Get
        Set(ByVal value As Long)
            my_iddprovincia = value
        End Set
    End Property
    Public Property iddepartamento() As Long
        Get
            iddepartamento = my_iddepartamento
        End Get
        Set(ByVal value As Long)
            my_iddepartamento = value
        End Set
    End Property
    Public Property idpais() As Long
        Get
            idpais = my_idpais
        End Get
        Set(ByVal value As Long)
            my_idpais = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Usuario = my_usuario
        End Get
        Set(ByVal value As String)
            my_usuario = value
        End Set
    End Property

    Public Property unidad() As Integer
        Get
            unidad = my_unidad
        End Get
        Set(ByVal value As Integer)
            my_unidad = value
        End Set
    End Property

#End Region
#Region "Procediminetos y funciones"
    'Public Function fnlistar_tipo_comprobante_2009(ByRef dvlistar_tipo_comprobante As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    fnlistar_tipo_comprobante_2009 = True
    '    Try
    '        Dim Rstlistar_tipo_comprobante As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_listar_tipo_comprobante", 2}
    '        Rstlistar_tipo_comprobante = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        '
    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rstlistar_tipo_comprobante)
    '        dvlistar_tipo_comprobante = DT.DefaultView
    '        '
    '        With Cmb
    '            .DataSource = dvlistar_tipo_comprobante
    '            .DisplayMember = "TIPO_COMPROBANTE"
    '            .ValueMember = "IDTIPO_COMPROBANTE"
    '        End With
    '        '
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        fnlistar_tipo_comprobante_2009 = False
    '    End Try
    'End Function
    Public Function fnlistar_tipo_comprobante(ByRef dvlistar_tipo_comprobante As DataView, ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        'Mod.17/09/2009 -->Omendoza - Pasando al datahelper   - No se considera el objecto VOCONTROLUSUARIO de la función anterior 
        fnlistar_tipo_comprobante = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOGENERAL.SP_listar_tipo_comprobante", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_listar_tipo_comprobante", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            dvlistar_tipo_comprobante = lds_tmp.Tables(0).DefaultView

            With Cmb
                .DataSource = dvlistar_tipo_comprobante
                .DisplayMember = "TIPO_COMPROBANTE"
                .ValueMember = "IDTIPO_COMPROBANTE"
            End With            '
            fnlistar_tipo_comprobante = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_cmb_Listar_agencias_todos_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox)
    '    '
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.SP_LISTAR_AGENCIAS_todos"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LISTAR_AGENCIAS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "NOMBRE_UNIDAD"
    '            .ValueMember = "IDUNIDAD_AGENCIA"
    '        End With
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_cmb_Listar_agencias_todos(ByVal Cmb As System.Windows.Forms.ComboBox)
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOGENERAL.SP_LISTAR_AGENCIAS_todos", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_LISTAR_AGENCIAS", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '            
            Dim dv As New DataView
            '
            dv = ldt_tmp.DefaultView
            '
            With Cmb
                .DataSource = dv
                .DisplayMember = "NOMBRE_UNIDAD"
                .ValueMember = "IDUNIDAD_AGENCIA"
            End With
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_L_UNIDAD_agencia_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.SP_LISTAR_AGENCIAS"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LISTAR_AGENCIAS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    '
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function FN_L_UNIDAD_agencia__2009(ByVal VOCONTROLUSUARIO As Object, ByRef Cmb As System.Windows.Forms.ComboBox)
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_UNIDAD_agencia", 2}
    '    '
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        '
    '        dv = dT.DefaultView
    '        '
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "NOMBRE_UNIDAD"
    '            .ValueMember = "IDUNIDAD_AGENCIA"
    '        End With
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_L_UNIDAD_agencia_(ByRef Cmb As System.Windows.Forms.ComboBox)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_L_UNIDAD_agencia", CommandType.StoredProcedure)
            db.AsignarParametro("CUR_L_UNIDAD_agencia", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dv As DataView = db.EjecutarDataTable.DefaultView
            With Cmb
                .DataSource = dv
                .DisplayMember = "NOMBRE_UNIDAD"
                .ValueMember = "IDUNIDAD_AGENCIA"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_L_funcionario_carga_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.sp_L_funcionario_carga"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_L_funcionario_carga", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Try
    '        sp_L_funcionario_carga = ds.Tables(0).DefaultView
    '        Return sp_L_funcionario_carga
    '    Catch
    '        Throw

    '    End Try
    'End Function

    Public Function sp_L_funcionario_carga() As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            'jdelavega
            'hlamas 06-01-2014
            'db_bd.CrearComando("PKG_IVOGENERAL.sp_L_funcionario_carga_car", CommandType.StoredProcedure)
            'db_bd.CrearComando("PKG_IVOGENERAL.sp_L_funcionario_carga", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_L_funcionario_carga", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '            
            sp_L_funcionario_carga = ldt_tmp.DefaultView
            '
            Return sp_L_funcionario_carga
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function SP_LISTAR_FUNCIONARIO() As DataView
        Dim db_bd As New BaseDatos
        Try
            Dim ldt_tmp As New DataTable
            db_bd.Conectar()

            db_bd.CrearComando("PKG_IVOGENERAL.SP_LISTAR_FUNCIONARIO", CommandType.StoredProcedure)
            db_bd.AsignarParametro("CUR_LISTAR_FUNCIONARIOS", OracleClient.OracleType.Cursor)
            ldt_tmp = db_bd.EjecutarDataTable
            SP_LISTAR_FUNCIONARIO = ldt_tmp.DefaultView
            Return SP_LISTAR_FUNCIONARIO

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Function

    Public Function SP_LISTAR_FUNCIONARIO_PASAJE() As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOGENERAL.SP_LISTAR_FUNCIONARIO_PASAJE", CommandType.StoredProcedure)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_LISTAR_FUNCIONARIOS", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '            
            SP_LISTAR_FUNCIONARIO_PASAJE = ldt_tmp.DefaultView
            '
            Return SP_LISTAR_FUNCIONARIO_PASAJE
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function sp_L_ESTADO_REGISTRO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox)

    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.sp_L_ESTADO_REGISTRO"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_ESTADO_REGISTRO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "ESTADO_REGISTRO"
    '            .ValueMember = "IDESTADO_REGISTRO"
    '        End With
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function SP_L_ESTADO_ENVIO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox)
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.SP_L_ESTADO_ENVIO"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_ESTADO_ENVIO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "ESTADO_REGISTRO"
    '            .ValueMember = "IDESTADO_REGISTRO"
    '        End With
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_L_ESTADO_ENVIO(ByVal Cmb As System.Windows.Forms.ComboBox)
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOGENERAL.SP_L_ESTADO_ENVIO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_L_ESTADO_ENVIO", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '            
            Dim dv As New DataView
            '
            dv = ldt_tmp.DefaultView
            '
            With Cmb
                .DataSource = dv
                .DisplayMember = "ESTADO_REGISTRO"
                .ValueMember = "IDESTADO_REGISTRO"
            End With
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        '
    End Function
    'Public Function FN_cmb_sp_L_tipo_servicio_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox)
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.sp_L_tipo_servicio"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_tipo_servicio", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "tipo_servicio"
    '            .ValueMember = "idtipo_servicio"
    '        End With
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function FN_cmb_sp_L_tipo_servicio(ByVal Cmb As System.Windows.Forms.ComboBox)
    Sub FN_cmb_sp_L_tipo_servicio(ByVal Cmb As System.Windows.Forms.ComboBox)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_L_tipo_servicio", CommandType.StoredProcedure)
            '
            db.AsignarParametro("cur_L_tipo_servicio", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "tipo_servicio"
                .ValueMember = "idtipo_servicio"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub



    'Public Function FN_cmb_l_TIPOS_PAGOS_CREDITOS_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox)
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.sp_l_TIPOS_PAGOS_CREDITOS"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_l_TIPOS_PAGOS_CREDITOS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    '
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "TIPOS_PAGOS_CREDI"
    '            .ValueMember = "IDTIPOS_PAGOS_CREDI"
    '        End With
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_cmb_l_TIPOS_PAGOS_CREDITOS(ByVal Cmb As System.Windows.Forms.ComboBox)
        Try
            'Dim DA As New OleDb.OleDbDataAdapter
            Dim DT As New DataTable
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_l_TIPOS_PAGOS_CREDITOS", CommandType.StoredProcedure)
            '
            db.AsignarParametro("cur_l_TIPOS_PAGOS_CREDITOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            DT = db.EjecutarDataTable
            Dim dv As New DataView
            '
            dv = DT.DefaultView
            With Cmb
                .DataSource = dv
                .DisplayMember = "TIPOS_PAGOS_CREDI"
                .ValueMember = "IDTIPOS_PAGOS_CREDI"
            End With
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function fn_retorna_digito_checkeo(ByRef TXT As String) As String
        Dim VALOR_MULTIPLICADOR As Integer, MONTO As Long, digito_chk As Integer
        VALOR_MULTIPLICADOR = 3

        For I As Integer = Len(TXT) To 1 Step -1
            If VALOR_MULTIPLICADOR = 1 Then
                MONTO = MONTO + Mid(TXT, I, 1) * 1
                VALOR_MULTIPLICADOR = 3
            Else
                MONTO = MONTO + Mid(TXT, I, 1) * 3
                VALOR_MULTIPLICADOR = 1
            End If
        Next

        digito_chk = (Int(MONTO / 10) + 1) * 10 - MONTO

        digito_chk = IIf(digito_chk = 10, 0, digito_chk)

        Return CStr(digito_chk)
    End Function
    'Public Function fnlistar_tipo_consulta_2009(ByRef dvListar_tipo_consulta As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    fnlistar_tipo_consulta_2009 = True
    '    Try
    '        Dim RstListar_tipo_consulta As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_listar_tipo_consulta", 2}
    '        RstListar_tipo_consulta = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, RstListar_tipo_consulta)
    '        dvListar_tipo_consulta = DT.DefaultView

    '        With Cmb
    '            .DataSource = dvListar_tipo_consulta
    '            .DisplayMember = "consulta"
    '            .ValueMember = "tipo_consulta"
    '        End With
    '        '
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        fnlistar_tipo_consulta_2009 = False
    '    End Try
    'End Function
    Public Function fnlistar_tipo_consulta(ByRef dvListar_tipo_consulta As DataView, ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        'Mod.17/09/2009 -->Omendoza - Pasando al datahelper   - No se considera el objecto VOCONTROLUSUARIO de la función anterior 
        fnlistar_tipo_consulta = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOGENERAL.SP_listar_tipo_consulta", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_listar_forma_pago", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            dvListar_tipo_consulta = ldt_tmp.DefaultView
            With Cmb
                .DataSource = dvListar_tipo_consulta
                .DisplayMember = "consulta"
                .ValueMember = "tipo_consulta"
            End With
            '
            fnlistar_tipo_consulta = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnlistar_tipo_comprobanteBF(ByRef dvlistar_tipo_comprobante As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean

    '    fnlistar_tipo_comprobanteBF = True
    '    Try
    '        Dim Rstlistar_tipo_comprobante As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_listar_tipo_comprobanteBF", 2}
    '        Rstlistar_tipo_comprobante = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rstlistar_tipo_comprobante)
    '        dvlistar_tipo_comprobante = DT.DefaultView

    '        With Cmb
    '            .DataSource = dvlistar_tipo_comprobante
    '            .DisplayMember = "TIPO_COMPROBANTE"
    '            .ValueMember = "IDTIPO_COMPROBANTE"
    '        End With

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        fnlistar_tipo_comprobanteBF = False
    '    End Try
    'End Function

    Public Function fnlistar_tipo_comprobanteBF(ByRef dvlistar_tipo_comprobante As DataView, ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        fnlistar_tipo_comprobanteBF = True
        'Mod.21/09/2009 -->Omendoza - Pasando al datahelper   - No se considera el objecto VOCONTROLUSUARIO de la función anterior 
        fnlistar_tipo_comprobanteBF = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOGENERAL.SP_listar_tipo_comprobanteBF", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_listar_tipo_comprobante", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            dvlistar_tipo_comprobante = lds_tmp.Tables(0).DefaultView
            '
            With Cmb
                .DataSource = dvlistar_tipo_comprobante
                .DisplayMember = "TIPO_COMPROBANTE"
                .ValueMember = "IDTIPO_COMPROBANTE"
            End With            '
            fnlistar_tipo_comprobanteBF = True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    '04/09/2008 -> 
    'Public Sub sp_listar_t_tipo_facturacion_sin_contado_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox)
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.sp_get_tip_factura_sin_contado"
    '    '
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_listar_t_tipo_facturacion", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "TIPO_FACTURACION"
    '            .ValueMember = "IDTIPO_FACTURACION"
    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    'Public Function sp_listar_provincia_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try

    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOGENERAL.sp_get_provincia"
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_iddepartamento", OracleClient.OracleType.Number)).Value = iddepartamento
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idpais", OracleClient.OracleType.Number)).Value = idpais
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_provincia", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Dim dv As New DataView
    '        '

    '        dv = ds.Tables(0).DefaultView
    '        '
    '        Return dv

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    '
    'Public Function sp_listar_distrito_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOGENERAL.sp_get_distrito"
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idprovincia", OracleClient.OracleType.Number)).Value = idprovincia
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_iddepartamento", OracleClient.OracleType.Number)).Value = iddepartamento
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idpais", OracleClient.OracleType.Number)).Value = idpais
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_distrito", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Dim dv As New DataView
    '        '
    '        dv = ds.Tables(0).DefaultView
    '        '
    '        Return dv
    '        '            
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function FN_L_UNIDAD_agencia_ubigeo_2009(ByVal VOCONTROLUSUARIO As Object, ByRef Cmb As System.Windows.Forms.ComboBox, ByRef ldv_ciudad As DataView)
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_UNIDAD_agencia", 2}
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "NOMBRE_UNIDAD"
    '            .ValueMember = "IDUNIDAD_AGENCIA"
    '        End With
    '        '
    '        ldv_ciudad = dv
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function FN_tipo_operacion_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByRef adv_tipo_operacion As DataView)
    '    'Tipo de operaicón par a el recojo 
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOGENERAL.sp_get_tipo_operacion"
    '        'Parametros de Entrada 
    '        'Parametros de Salida
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_tipo_operacion", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '
    '        Dim dv As New DataView
    '        '
    '        adv_tipo_operacion = ds.Tables(0).DefaultView
    '        '
    '        Return adv_tipo_operacion
    '        '            
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Sub valida_usuario_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivogeneral.sp_valida_usuario"
    '        ' Ingresando los parametros 
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_login", OracleClient.OracleType.VarChar)).Value = my_login
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_pasword", OracleClient.OracleType.VarChar)).Value = my_password
    '        '-- Invocando los parametros
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("no_idusuario_personal", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("no_ret", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("no_sqlerrm", OracleClient.OracleType.VarChar, 200)).Direction = ParameterDirection.Output
    '        '
    '        cmd.ExecuteNonQuery()
    '        '
    '        If IsDBNull(cmd.Parameters("no_sqlerrm").Value) = True Then
    '            Me.mensaje = ""
    '        Else
    '            If Not cmd.Parameters("no_sqlerrm").Value Is DBNull.Value Then
    '                Me.mensaje = cmd.Parameters("no_sqlerrm").Value
    '            End If
    '        End If
    '        '
    '        If Not cmd.Parameters("no_ret").Value Is DBNull.Value Then
    '            Me.retorno = cmd.Parameters("no_ret").Value
    '        End If
    '        '
    '        If Not cmd.Parameters("no_idusuario_personal").Value Is DBNull.Value Then
    '            Me.idusuario_personal = cmd.Parameters("no_idusuario_personal").Value
    '        End If
    '        '---
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        Me.retorno = -1
    '        Me.mensaje = OEx.ToString
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch ex As Exception
    '        Me.retorno = -1
    '        Me.mensaje = ex.Message
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
    '    End Try
    'End Sub

    '20/10/2008 Recupera el tipo de operación - para la entrega y recojo  
    'Public Sub sp_tipo_operacion_entrega_reparto_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox)
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.sp_get_tipo_operacion"
    '    '
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_tipo_operacion", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "operacion_carga"
    '            .ValueMember = "idoperacion_carga"
    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    Public Sub sp_tipo_operacion_entrega_reparto(ByVal Cmb As System.Windows.Forms.ComboBox)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_get_tipo_operacion", CommandType.StoredProcedure)
            '
            db.AsignarParametro("ocur_tipo_operacion", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "operacion_carga"
                .ValueMember = "idoperacion_carga"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'Public Sub sp_get_responsable_movil_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal li_idunidad_agencia As Long)
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.sp_recupera_usuario_para_movil"
    '    '
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ni_idunidad_agencia", OracleClient.OracleType.Number)).Value = li_idunidad_agencia
    '    '
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_responsable_movil", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "apellidos_Nombres"
    '            .ValueMember = "Idusuario_Personal"
    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub

    Public Sub sp_get_responsable_movil(ByVal Cmb As System.Windows.Forms.ComboBox, ByVal li_idunidad_agencia As Long)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_recupera_usuario_para_movil", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idunidad_agencia", li_idunidad_agencia, OracleClient.OracleType.Int32)
            '
            db.AsignarParametro("ocur_responsable_movil", OracleClient.OracleType.Cursor)
            db.Desconectar()
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "apellidos_Nombres"
                .ValueMember = "Idusuario_Personal"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

    End Sub

    'Public Sub get_tipo_reporte_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox)
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.sp_tipo_reporte"
    '    '
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_tipo_reporte", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "descripcion"
    '            .ValueMember = "idtipo_reporte"
    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    Public Sub get_tipo_reporte(ByVal Cmb As System.Windows.Forms.ComboBox)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_tipo_reporte", CommandType.StoredProcedure)
            '
            db.AsignarParametro("ocur_tipo_reporte", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "descripcion"
                .ValueMember = "idtipo_reporte"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    ' 23/10/2008 - 
    'Public Function FN_L_UNIDAD_agencia_TODOS_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox)
    '    ' Version nueva

    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.SP_L_UNIDAD_agencia_TODOS"
    '    ''''''''
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_UNIDAD_agencia", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "NOMBRE_UNIDAD"
    '            .ValueMember = "IDUNIDAD_AGENCIA"
    '        End With
    '        'Catch OEx As System.Data.OracleClient.OracleException
    '        '    MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        'End Try
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Sub get_tipo_consulta_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox)
    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.sp_tipo_consulta"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_tipo_consulta", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "descripcion"
    '            .ValueMember = "idtipo_consulta"
    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    Public Sub get_tipo_consulta(ByVal Cmb As System.Windows.Forms.ComboBox)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_tipo_consulta", CommandType.StoredProcedure)
            db.AsignarParametro("ocur_tipo_consulta", OracleClient.OracleType.Cursor)
            db.Desconectar()
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "descripcion"
                .ValueMember = "idtipo_consulta"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'Public Function fn_L_TIPO_ENTREGA1_2009(ByVal dvListar_forma_pago As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    Try
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_l_TIPO_ENTREGA2", 2}
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        '
    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rst)
    '        dvListar_forma_pago = DT.DefaultView
    '        '
    '        With Cmb
    '            .DataSource = dvListar_forma_pago
    '            .DisplayMember = "TIPO_ENTREGA"
    '            .ValueMember = "IDTIPO_ENTREGA"
    '        End With
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function fn_L_TIPO_ENTREGA1(ByVal dvListar_forma_pago As DataView, ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_l_TIPO_ENTREGA2", CommandType.StoredProcedure)
            '
            db.AsignarParametro("CUR_LISTAR_TIPO_ENTREGA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "TIPO_ENTREGA"
                .ValueMember = "IDTIPO_ENTREGA"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnlistar_forma_pago_2009(ByRef dvListar_forma_pago As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    fnlistar_forma_pago_2009 = True
    '    Try
    '        Dim RstListar_forma_pago As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_listar_forma_pago", 2}
    '        RstListar_forma_pago = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, RstListar_forma_pago)
    '        dvListar_forma_pago = DT.DefaultView

    '        With Cmb
    '            .DataSource = dvListar_forma_pago
    '            .DisplayMember = "FORMA_PAGO"
    '            .ValueMember = "IDFORMA_PAGO"
    '        End With

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        fnlistar_forma_pago_2009 = False
    '    End Try
    'End Function
    Public Function fnlistar_forma_pago(ByRef dvListar_forma_pago As DataView, ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        fnlistar_forma_pago = True
        Try
            'Dim RstListar_forma_pago As New ADODB.Recordset
            'Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_listar_forma_pago", 2}
            'RstListar_forma_pago = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            'Dim DA As New OleDb.OleDbDataAdapter
            Dim DT As New DataTable
            'DA.Fill(DT, RstListar_forma_pago)

            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_listar_forma_pago", CommandType.StoredProcedure)
            db.AsignarParametro("cur_listar_forma_pago", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            DT = ds.Tables(0)
            dvListar_forma_pago = DT.DefaultView

            With Cmb
                .DataSource = dvListar_forma_pago
                .DisplayMember = "FORMA_PAGO"
                .ValueMember = "IDFORMA_PAGO"
            End With

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return fnlistar_forma_pago
    End Function
    'Public Function fn_L_TIPO_ENTREGA2009(ByVal dvListar_forma_pago As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean

    '    Try
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_l_TIPO_ENTREGA", 2}
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rst)
    '        dvListar_forma_pago = DT.DefaultView

    '        With Cmb
    '            .DataSource = dvListar_forma_pago
    '            .DisplayMember = "TIPO_ENTREGA"
    '            .ValueMember = "IDTIPO_ENTREGA"
    '        End With

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function fn_L_TIPO_ENTREGA(ByVal dvListar_forma_pago As DataView, ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            'Dim Rst As New ADODB.Recordset
            'Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_l_TIPO_ENTREGA", 2}
            'Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            'Dim DA As New OleDb.OleDbDataAdapter
            Dim DT As New DataTable
            'DA.Fill(DT, Rst)
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_l_TIPO_ENTREGA", CommandType.StoredProcedure)
            db.AsignarParametro("CUR_LISTAR_TIPO_ENTREGA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            DT = db.EjecutarDataSet.Tables(0)

            dvListar_forma_pago = DT.DefaultView

            With Cmb
                .DataSource = dvListar_forma_pago
                .DisplayMember = "TIPO_ENTREGA"
                .ValueMember = "IDTIPO_ENTREGA"
            End With

        Catch ex As Exception
            Return False
        End Try
    End Function
    'Public Function FN_L_UNIDAD_agencia_OK2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_UNIDAD_agencia", 2}
    '    '
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        '
    '        dv = dT.DefaultView
    '        Return dv
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_L_UNIDAD_agencia_OK() As DataView
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim dT As New DataTable
        Dim dv As New DataView
        Dim DA As New OleDb.OleDbDataAdapter
        'Dim Rst As New ADODB.Recordset
        'Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_UNIDAD_agencia", 2}
        '
        'Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        'DA.Fill(dT, Rst)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_L_UNIDAD_agencia", CommandType.StoredProcedure)
            db.AsignarParametro("CUR_L_UNIDAD_agencia", OracleClient.OracleType.Cursor)
            db.Desconectar()

            dT = db.EjecutarDataTable

            dv = dT.DefaultView
            Return dv
            '
            'Catch ex As System.Exception
            'MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

    End Function
    'Public Function fnL_CENTRO_COSTOS_PERSONAS2009(ByVal dv As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object, ByVal P_IDCONTACTO_PERSONA As Integer) As Boolean
    '    Dim Flat As Boolean
    '    Flat = True
    '    Try
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_CENTRO_COSTOS_PERSONAS", 4, Str(P_IDCONTACTO_PERSONA), 2}
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView

    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "CENTRO_COSTO"
    '            .ValueMember = "IDCENTRO_COSTO"
    '        End With

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Flat = False
    '    End Try
    '    Return Flat
    'End Function

    Public Function fnL_CENTRO_COSTOS_PERSONAS(ByVal dv As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal P_IDCONTACTO_PERSONA As Integer) As Boolean
        Dim Flat As Boolean
        Flat = True
        Try
            Dim DT As New DataTable
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_L_CENTRO_COSTOS_PERSONAS", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDCONTACTO_PERSONA", Str(P_IDCONTACTO_PERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_L_CENTRO_COSTOS_PERSONAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)

            db.Desconectar()
            DT = db.EjecutarDataSet.Tables(0)

            dv = DT.DefaultView

            With Cmb
                .DataSource = dv
                .DisplayMember = "CENTRO_COSTO"
                .ValueMember = "IDCENTRO_COSTO"
            End With

        Catch ex As Excepcion
            Flat = False
        End Try
        Return Flat
    End Function
    'Public Function FN_cmb_l_tipo_comprobante_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox) As DataView
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.sp_listar_tipo_comprobante"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_listar_tipo_comprobante", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_ERROR", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "TIPO_COMPROBANTE"
    '            .ValueMember = "IDTIPO_COMPROBANTE"
    '        End With
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_cmb_l_tipo_comprobante(ByVal Cmb As System.Windows.Forms.ComboBox) As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_listar_tipo_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("cur_listar_tipo_comprobante", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            Dim dv As New DataView
            dv = ds.Tables(0).DefaultView
            With Cmb
                .DataSource = dv
                .DisplayMember = "TIPO_COMPROBANTE"
                .ValueMember = "IDTIPO_COMPROBANTE"
            End With
            Return dv

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function FN_cmb_Listar_agencias(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox)
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.SP_LISTAR_AGENCIAS"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LISTAR_AGENCIAS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "NOMBRE_UNIDAD"
    '            .ValueMember = "IDUNIDAD_AGENCIA"
    '        End With

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Public Function FN_cmb_Listar_agencias(ByVal Cmb As System.Windows.Forms.ComboBox)
        Try
            Dim dv As New DataView
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_AGENCIAS", CommandType.StoredProcedure)
            db.AsignarParametro("CUR_LISTAR_AGENCIAS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            dv = ds.Tables(0).DefaultView
            With Cmb
                .DataSource = dv
                .DisplayMember = "NOMBRE_UNIDAD"
                .ValueMember = "IDUNIDAD_AGENCIA"
            End With

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function FNLISTAR_TIPO_MONEDA_2009(ByVal dvLISTAR_TIPO_MONEDA As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    FNLISTAR_TIPO_MONEDA = True
    '    Try
    '        Dim RstLISTAR_TIPO_MONEDA As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_LISTAR_TIPO_MONEDA", 2}
    '        RstLISTAR_TIPO_MONEDA = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, RstLISTAR_TIPO_MONEDA)
    '        dvLISTAR_TIPO_MONEDA = DT.DefaultView

    '        With Cmb
    '            .DataSource = dvLISTAR_TIPO_MONEDA
    '            .DisplayMember = "DESCRIPCION"
    '            .ValueMember = "IDTIPO_MONEDA"
    '        End With

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        FNLISTAR_TIPO_MONEDA = False
    '    End Try
    'End Function

    Public Function FNLISTAR_TIPO_MONEDA(ByVal dvLISTAR_TIPO_MONEDA As DataView, ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_TIPO_MONEDA", CommandType.StoredProcedure)
            db.AsignarParametro("CUR_LISTAR_TIPO_MONEDA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Dim RstLISTAR_TIPO_MONEDA As DataTable = ds.Tables(0)
            Dim DT As DataTable = RstLISTAR_TIPO_MONEDA
            dvLISTAR_TIPO_MONEDA = DT.DefaultView

            With Cmb
                .DataSource = dvLISTAR_TIPO_MONEDA
                .DisplayMember = "DESCRIPCION"
                .ValueMember = "IDTIPO_MONEDA"
            End With
            Return True

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    '26/04/2008 -> Creado 
    'Public Sub sp_listar_t_tipo_facturacion(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox)

    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.sp_listar_t_tipo_facturacion"


    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_listar_t_tipo_facturacion", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '    Dim ds As New DataSet
    '    daora.Fill(ds)


    '    Dim dv As New DataView


    '    Try

    '        dv = ds.Tables(0).DefaultView


    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "TIPO_FACTURACION"
    '            .ValueMember = "IDTIPO_FACTURACION"
    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub

    Public Sub sp_listar_t_tipo_facturacion(ByVal Cmb As System.Windows.Forms.ComboBox)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_listar_t_tipo_facturacion", CommandType.StoredProcedure)
            db.AsignarParametro("cur_listar_t_tipo_facturacion", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable

            Dim dv As DataView = dt.DefaultView
            With Cmb
                .DataSource = dv
                .DisplayMember = "TIPO_FACTURACION"
                .ValueMember = "IDTIPO_FACTURACION"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'Public Sub get_nro_meses_linea_credito_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "pkg_ivogeneral.sp_get_nro_meses_linea_credito"
    '        '-- Invocando los parametros
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("no_nro_meses_lc", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vo_fec_inicio", OracleClient.OracleType.VarChar, 10)).Direction = ParameterDirection.Output
    '        '
    '        cmd.ExecuteNonQuery()
    '        '
    '        If Not cmd.Parameters("no_nro_meses_lc").Value Is DBNull.Value Then
    '            Me.nro_meses_linea_cred = cmd.Parameters("no_nro_meses_lc").Value
    '        End If
    '        '
    '        If Not cmd.Parameters("vo_fec_inicio").Value Is DBNull.Value Then
    '            Me.fecha_inicio_lc = CType(cmd.Parameters("vo_fec_inicio").Value, String)
    '        End If
    '        '---
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
    '    End Try
    'End Sub

    Public Sub get_nro_meses_linea_credito()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_ivogeneral.sp_get_nro_meses_linea_credito", CommandType.StoredProcedure)
            db.AsignarParametro("no_nro_meses_lc", OracleClient.OracleType.Number, ParameterDirection.Output)
            db.AsignarParametro("vo_fec_inicio", 10, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db.EjecutarComando()
            If db.Parametros.Length > 0 Then
                Me.nro_meses_linea_cred = IIf(db.Parametros(1) Is DBNull.Value, "", db.Parametros(1))
                Me.fecha_inicio_lc = IIf(db.Parametros(2) Is DBNull.Value, "", db.Parametros(2))
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
    'Public Function FN_cmb_L_FUNCIONARIOS(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.sp_L_funcionario_carga"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_L_funcionario_carga", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    dv = ds.Tables(0).DefaultView
    '    Try
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "USUARIO_PERSONAL"
    '            .ValueMember = "IDUSUARIO_PERSONAL"
    '        End With
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_cmb_L_FUNCIONARIOS(ByVal Cmb As System.Windows.Forms.ComboBox) As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("PKG_IVOGENERAL.sp_L_funcionario_carga", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOGENERAL.sp_L_funcionario_carga_car", CommandType.StoredProcedure)
            db.AsignarParametro("cur_L_funcionario_carga", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dv As DataView = db.EjecutarDataTable.DefaultView
            With Cmb
                .DataSource = dv
                .DisplayMember = "USUARIO_PERSONAL"
                .ValueMember = "IDUSUARIO_PERSONAL"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_listar_tipo_nota_credito(ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean

    '    sp_listar_tipo_nota_credito = True
    '    Try
    '        Dim Rstlistar_tipo_comprobante As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.sp_listar_tipo_nota_credito", 2}
    '        Rstlistar_tipo_comprobante = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rstlistar_tipo_comprobante)


    '        With Cmb
    '            .DataSource = DT.DefaultView
    '            .DisplayMember = "TIPO_NOTA_CREDI"
    '            .ValueMember = "IDTIPO_NOTA_CREDI"
    '        End With

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        sp_listar_tipo_nota_credito = False
    '    End Try
    'End Function

    Public Function sp_listar_tipo_nota_credito(ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_listar_tipo_nota_credito", CommandType.StoredProcedure)
            db.AsignarParametro("cur_listar_tipo_nota_credito", OracleClient.OracleType.Cursor)
            db.Desconectar()
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "TIPO_NOTA_CREDI"
                .ValueMember = "IDTIPO_NOTA_CREDI"
            End With
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_L_tipos_giros_CB_2009(ByRef dv_L_tipos_giros As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    FN_L_tipos_giros_CB = True
    '    Try
    '        Dim rst_L_tipos_giros As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_tipos_giros", 2}
    '        rst_L_tipos_giros = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, rst_L_tipos_giros)
    '        dv_L_tipos_giros = DT.DefaultView

    '        With Cmb
    '            .DataSource = dv_L_tipos_giros
    '            .DisplayMember = "TIPO_GIRO"
    '            .ValueMember = "IDTIPO_GIRO"
    '        End With

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        FN_L_tipos_giros_CB = False
    '    End Try
    'End Function
    Public Function FN_L_tipos_giros_CB(ByRef dv_L_tipos_giros As DataView, ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_L_tipos_giros", CommandType.StoredProcedure)
            db.AsignarParametro("cur_L_tipos_giros", OracleClient.OracleType.Cursor)
            db.Desconectar()
            dv_L_tipos_giros = db.EjecutarDataTable.DefaultView
            With Cmb
                .DataSource = dv_L_tipos_giros
                .DisplayMember = "TIPO_GIRO"
                .ValueMember = "IDTIPO_GIRO"
            End With
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_L_condiciones_giros_CB_2009(ByRef dv_L_condiciones_giros As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    fn_L_condiciones_giros_CB = True
    '    Try
    '        Dim rst_L_condiciones_giros As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.sp_L_condiciones_giros", 2}
    '        rst_L_condiciones_giros = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, rst_L_condiciones_giros)
    '        dv_L_condiciones_giros = DT.DefaultView

    '        With Cmb
    '            .DataSource = dv_L_condiciones_giros
    '            .DisplayMember = "CONDI_GIRO"
    '            .ValueMember = "IDCONDI_GIRO"
    '        End With

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        fn_L_condiciones_giros_CB = False
    '    End Try
    'End Function
    Public Function fn_L_condiciones_giros_CB(ByRef dv_L_condiciones_giros As DataView, ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_L_condiciones_giros", CommandType.StoredProcedure)
            db.AsignarParametro("cur_L_condiciones_giros", OracleClient.OracleType.Cursor)
            db.Desconectar()
            dv_L_condiciones_giros = db.EjecutarDataTable.DefaultView
            With Cmb
                .DataSource = dv_L_condiciones_giros
                .DisplayMember = "CONDI_GIRO"
                .ValueMember = "IDCONDI_GIRO"
            End With
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_cmb_LISTAR_USUARIOS_AGENCIAS(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal P_IdRol_Usuario As Int64, ByVal P_idAgencia As Int64)
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.SP_LISTAR_USUARIOS_AGENCIAS"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IdRol_Usuario", OracleClient.OracleType.Number)).Value = P_IdRol_Usuario
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_idAgencia", OracleClient.OracleType.Number)).Value = P_idAgencia
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LISTAR_USUARIOS_AGENCIAS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        '
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "NOMBREUSUARIO"
    '            .ValueMember = "IDUSUARIO_PERSONAL"
    '        End With
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.Message, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Public Function FN_cmb_LISTAR_USUARIOS_AGENCIAS(ByVal Cmb As System.Windows.Forms.ComboBox, ByVal P_IdRol_Usuario As Int64, ByVal P_idAgencia As Int64)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'acceso 21/04/2010
            'db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_USUARIOS_AGENCIAS", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_USUARIOS_AGENCIAS_1", CommandType.StoredProcedure)
            db.AsignarParametro("P_IdRol_Usuario", P_IdRol_Usuario, OracleClient.OracleType.Number)
            db.AsignarParametro("P_idAgencia", P_idAgencia, OracleClient.OracleType.Number)
            db.AsignarParametro("CUR_LISTAR_USUARIOS_AGENCIAS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "NOMBREUSUARIO"
                .ValueMember = "IDUSUARIO_PERSONAL"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_Listar_agencias_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.SP_LISTAR_AGENCIAS_"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LISTAR_AGENCIAS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Try
    '        SP_Listar_agencias = ds.Tables(0).DefaultView
    '        Return SP_Listar_agencias

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_Listar_agencias() As DataView
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_AGENCIAS_", CommandType.StoredProcedure)
            '
            db.AsignarParametro("CUR_LISTAR_AGENCIAS", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_L_FUNCIONARIOS_2009(ByVal VOCONTROLUSUARIO As Object, ByRef Cmb As System.Windows.Forms.ComboBox, ByVal ParamArray Roles() As String)
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_FUNCIONARIOS", 2}
    '    Dim criterios As String = ""
    '    '
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        'For c As Integer = 0 To Roles.Length - 1
    '        'criterios = "and rol_crit=" & Roles(c)
    '        'Next
    '        'dv.RowFilter = Mid(criterios, 5, Len(criterios) - 4)
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "NOMBRE"
    '            .ValueMember = "IDUSUARIO_PERSONAL"
    '        End With
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_L_FUNCIONARIOS(ByRef Cmb As System.Windows.Forms.ComboBox, ByVal ParamArray Roles() As String)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("PKG_IVOGENERAL.SP_L_FUNCIONARIOS", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOGENERAL.SP_L_FUNCIONARIOS_CAR", CommandType.StoredProcedure)
            db.AsignarParametro("CUR_L_FUNCIONARIOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dv As DataView = db.EjecutarDataTable.DefaultView
            With Cmb
                .DataSource = dv
                .DisplayMember = "NOMBRE"
                .ValueMember = "IDUSUARIO_PERSONAL"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function FNLISTAR_CENTRO_COSTO_2009(ByVal dvLISTAR_CENTRO_COSTO As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    FNLISTAR_CENTRO_COSTO = True
    '    Try
    '        Dim RstLISTAR_CENTRO_COSTO As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_LISTAR_CENTRO_COSTO", 2}
    '        RstLISTAR_CENTRO_COSTO = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, RstLISTAR_CENTRO_COSTO)
    '        dvLISTAR_CENTRO_COSTO = DT.DefaultView

    '        With Cmb
    '            .DataSource = dvLISTAR_CENTRO_COSTO
    '            .DisplayMember = "CENTRO_COSTO"
    '            .ValueMember = "IDCENTRO_COSTO"
    '        End With

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        FNLISTAR_CENTRO_COSTO = False
    '    End Try
    'End Function

    Public Function FNLISTAR_CENTRO_COSTO(ByVal dvLISTAR_CENTRO_COSTO As DataView, ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_CENTRO_COSTO", CommandType.StoredProcedure)
            db.AsignarParametro("CUR_LISTAR_CENTRO_COSTO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            dvLISTAR_CENTRO_COSTO = ds.Tables(0).DefaultView
            With Cmb
                .DataSource = dvLISTAR_CENTRO_COSTO
                .DisplayMember = "CENTRO_COSTO"
                .ValueMember = "IDCENTRO_COSTO"
            End With
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_L_UNIDAD_agencia_TODOS_2009(ByVal VOCONTROLUSUARIO As Object, ByRef Cmb As System.Windows.Forms.ComboBox)
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_UNIDAD_agencia_TODOS", 2}
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "NOMBRE_UNIDAD"
    '            .ValueMember = "IDUNIDAD_AGENCIA"
    '        End With

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_L_UNIDAD_agencia_TODOS(ByRef Cmb As System.Windows.Forms.ComboBox)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_L_UNIDAD_agencia_TODOS", CommandType.StoredProcedure)
            db.AsignarParametro("CUR_L_UNIDAD_agencia", OracleClient.OracleType.Cursor)
            db.Desconectar()
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "NOMBRE_UNIDAD"
                .ValueMember = "IDUNIDAD_AGENCIA"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_cmb_L_tipo_recepcion_docu_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox)
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.SP_L_tipo_recepcion_docu"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CURR_L_tipo_recepcion_docu", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "TIPO_RECEPCION_DOCU"
    '            .ValueMember = "IDTIPO_RECEPCION_DOCU"
    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_cmb_L_tipo_recepcion_docu(ByVal Cmb As System.Windows.Forms.ComboBox)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_L_tipo_recepcion_docu", CommandType.StoredProcedure)
            db.AsignarParametro("CURR_L_tipo_recepcion_docu", OracleClient.OracleType.Cursor)
            db.Desconectar()
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "TIPO_RECEPCION_DOCU"
                .ValueMember = "IDTIPO_RECEPCION_DOCU"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_cmb_LIST_AGENCIAS_UNIDAD_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal p_idunidad_agencia As Long)
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOVENTACARGA.SP_LIST_AGENCIAS_UNIDAD"
    '    '
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("v_idUnidadAgencia", OracleClient.OracleType.Number)).Value = p_idunidad_agencia
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_datos_Agencias", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "NOMBRE_AGENCIA"
    '            .ValueMember = "IDAGENCIAS"
    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_cmb_LIST_AGENCIAS_UNIDAD(ByVal Cmb As System.Windows.Forms.ComboBox, ByVal p_idunidad_agencia As Long)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTACARGA.SP_LIST_AGENCIAS_UNIDAD", CommandType.StoredProcedure)
            db.AsignarParametro("v_idUnidadAgencia", p_idunidad_agencia, OracleClient.OracleType.Number)
            db.AsignarParametro("cur_datos_Agencias", OracleClient.OracleType.Cursor)
            db.Desconectar()
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "NOMBRE_AGENCIA"
                .ValueMember = "IDAGENCIAS"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fn_L_TIPO_comunicacion2009(ByVal dvListar_forma_pago As DataView, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    Try
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_TIPO_COMUNICACION", 2}
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        '
    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rst)
    '        dvListar_forma_pago = DT.DefaultView
    '        '
    '        With Cmb
    '            .DataSource = dvListar_forma_pago
    '            .DisplayMember = "TIPO_COMUNICACION"
    '            .ValueMember = "IDTIPO_COMUNICACION"
    '        End With
    '        '
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Public Function fn_L_TIPO_comunicacion(ByVal dvListar_forma_pago As DataView, ByVal Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_L_TIPO_COMUNICACION", CommandType.StoredProcedure)
            db.AsignarParametro("CUR_LISTAR_TIPO_COMUNICACION", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            With Cmb
                .DataSource = db.EjecutarDataSet.Tables(0).DefaultView
                .DisplayMember = "TIPO_COMUNICACION"
                .ValueMember = "IDTIPO_COMUNICACION"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_cmb_LISTAR_USUARIOS_VENDEDOR_2009(ByVal cnn As System.Data.OracleClient.OracleConnection, ByVal Cmb As System.Windows.Forms.ComboBox, ByVal P_IdRol_Usuario As Int64, ByVal P_idAgencia As Int64)
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOGENERAL.SP_LISTAR_USUARIOS_VENDEDOR"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IdRol_Usuario", OracleClient.OracleType.Number)).Value = P_IdRol_Usuario
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_idAgencia", OracleClient.OracleType.Number)).Value = P_idAgencia
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LISTAR_USUARIOS_AGENCIAS", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "NOMBREUSUARIO"
    '            .ValueMember = "IDUSUARIO_PERSONAL"
    '        End With
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_cmb_LISTAR_USUARIOS_VENDEDOR(ByVal Cmb As System.Windows.Forms.ComboBox, ByVal P_IdRol_Usuario As Int64, ByVal P_idAgencia As Int64)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'acceso 21/04/2010
            'db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_USUARIOS_VENDEDOR", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_USUARIOS_VENDEDOR_1", CommandType.StoredProcedure)
            db.AsignarParametro("P_IdRol_Usuario", P_IdRol_Usuario, OracleClient.OracleType.Number)
            db.AsignarParametro("P_idAgencia", P_idAgencia, OracleClient.OracleType.Number)
            db.AsignarParametro("CUR_LISTAR_USUARIOS_AGENCIAS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "NOMBREUSUARIO"
                .ValueMember = "IDUSUARIO_PERSONAL"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_estado_facturado_2009(ByVal VOCONTROLUSUARIO As Object, ByRef Cmb As System.Windows.Forms.ComboBox)
    '    ''''''''''''
    '    '10/09/2007'
    '    ''''''''''''
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_estado_dcto_guia_trans", 2}
    '    '
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .DisplayMember = "DESCRIPCION"
    '            .ValueMember = "FACTURADO"
    '        End With
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_estado_facturado(ByRef Cmb As System.Windows.Forms.ComboBox)
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOGENERAL.SP_estado_dcto_guia_trans", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("oCUR_estado", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '            
            Dim dv As New DataView
            '
            dv = ldt_tmp.DefaultView
            '
            With Cmb
                .DataSource = dv
                .DisplayMember = "DESCRIPCION"
                .ValueMember = "FACTURADO"
            End With
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    '04/09/2009 -> Creado 
    Public Sub sp_listar_t_tipo_facturacion_sin_contado(ByVal Cmb As System.Windows.Forms.ComboBox)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_get_tip_factura_sin_contado", CommandType.StoredProcedure)
            db.AsignarParametro("cur_listar_t_tipo_facturacion", OracleClient.OracleType.Cursor)
            db.Desconectar()
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "TIPO_FACTURACION"
                .ValueMember = "IDTIPO_FACTURACION"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

    Public Shared Function CarteraResponsable(Optional Cmb As System.Windows.Forms.ComboBox = Nothing, _
                                              Optional inicio As String = "", _
                                              Optional fin As String = "", _
                                              Optional opcion As Integer = 0,
                                              Optional cadena As String = "", _
                                              Optional usuario As Integer = 0) As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("PKG_IVOGENERAL.sp_L_funcionario_carga", CommandType.StoredProcedure)
            db.CrearComando("sp_responsable_cuenta", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_cadena", cadena, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_responsable", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dv As DataView = db.EjecutarDataTable.DefaultView
            If Not IsNothing(Cmb) Then
                With Cmb
                    .DataSource = Nothing
                    .DataSource = dv
                    .DisplayMember = "USUARIO_PERSONAL"
                    .ValueMember = "IDUSUARIO_PERSONAL"
                End With
            End If
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    '----------------------------------------------------------------------------------------------------------------------------

    Sub ValidarUsuario(login As String)
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_ivogeneral.sp_validar_usuario", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input            
            db_bd.AsignarParametro("vi_login", login, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("ni_usuario", OracleClient.OracleType.Number)
            db_bd.AsignarParametro("ni_error", OracleClient.OracleType.Number)
            db_bd.AsignarParametro("vi_error", 200, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db_bd.EjecutarComando()
            If db_bd.Parametros.Length > 0 Then
                Me.idusuario_personal = IIf(db_bd.Parametros(1) Is DBNull.Value, 0, db_bd.Parametros(1))
                Me.retorno = IIf(db_bd.Parametros(2) Is DBNull.Value, "", db_bd.Parametros(2))
                Me.mensaje = IIf(db_bd.Parametros(3) Is DBNull.Value, "", db_bd.Parametros(3))
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub

    Sub ObtieneClave()
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_ivogeneral.sp_obtiene_clave", CommandType.StoredProcedure)
            'Variables de salidas 
            db_bd.AsignarParametro("vi_patron", 20, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db_bd.AsignarParametro("vi_clave", 20, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db_bd.AsignarParametro("ni_error", OracleClient.OracleType.Number, ParameterDirection.Output)
            db_bd.AsignarParametro("vi_error", 200, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db_bd.EjecutarComando()
            If db_bd.Parametros.Length > 0 Then
                Me.patron = IIf(db_bd.Parametros(1) Is DBNull.Value, "", db_bd.Parametros(1))
                Me.clave = IIf(db_bd.Parametros(2) Is DBNull.Value, "", db_bd.Parametros(2))
                Me.retorno = IIf(db_bd.Parametros(3) Is DBNull.Value, 0, db_bd.Parametros(3))
                Me.mensaje = IIf(db_bd.Parametros(4) Is DBNull.Value, "", db_bd.Parametros(4))
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub

    Sub ObtieneClave(usuario As Integer, ip As String)
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_ivogeneral.sp_obtiene_clave", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("vi_patron", 20, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db_bd.AsignarParametro("vi_clave", 20, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db_bd.AsignarParametro("vi_clave_final", 20, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db_bd.AsignarParametro("ni_error", OracleClient.OracleType.Number, ParameterDirection.Output)
            db_bd.AsignarParametro("vi_error", 200, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db_bd.EjecutarComando()
            If db_bd.Parametros.Length > 0 Then
                Me.patron = IIf(db_bd.Parametros(1) Is DBNull.Value, "", db_bd.Parametros(1))
                Me.clave = IIf(db_bd.Parametros(2) Is DBNull.Value, "", db_bd.Parametros(2))
                Me.clavefinal = IIf(db_bd.Parametros(3) Is DBNull.Value, "", db_bd.Parametros(3))
                Me.retorno = IIf(db_bd.Parametros(4) Is DBNull.Value, 0, db_bd.Parametros(4))
                Me.mensaje = IIf(db_bd.Parametros(5) Is DBNull.Value, "", db_bd.Parametros(5))
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub

    Function ListarPatron(usuario As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_ivogeneral.sp_listar_patron", CommandType.StoredProcedure)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try

    End Function

    Function ListarUsuario(ByVal descuento As Double, ByVal agencia As Integer, Optional ByVal venta As Integer = 1) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_ivogeneral.sp_listar_usuario_descuento_2", CommandType.StoredProcedure)
            db.AsignarParametro("ni_descuento", descuento, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_venta", venta, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try

    End Function

    Function ListarUsuario(ByVal opcion As Integer, ByVal agencia As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_ivogeneral.sp_listar_usuario_autoriza", CommandType.StoredProcedure)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Number)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try

    End Function

    Sub GrabarPatron(ByVal usuario As Integer, ByVal patron As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("pkg_ivogeneral.sp_grabar_patron", CommandType.StoredProcedure)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_patron", patron, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function UsuarioDescuento(usuario As Integer, descuento As Double) As Boolean
        Dim flag As Integer = 0
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select pkg_ivogeneral.sf_get_usuario_descuento(" & usuario & "," & descuento & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            flag = db_bd.EjecutarEscalar()
            db_bd.Desconectar()

            If flag = 0 Then
                Return False
            Else
                Return True
            End If
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag

    End Function

    Function ObtieneExpresion(usuario As Integer, clave As String) As String
        Dim flag As Integer = 0
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select pkg_ivogeneral.sf_get_expresion(" & usuario & ",'" & clave & "') from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            Return db_bd.EjecutarEscalar()
            db_bd.Desconectar()

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag

    End Function

    Public Sub valida_usuario(Optional ByVal opcion As Integer = 0)
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("pkg_ivogeneral.sp_valida_usuario", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input            
            db_bd.AsignarParametro("vi_login", my_login, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_pasword", my_password, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("no_idusuario_personal", OracleClient.OracleType.Number)
            db_bd.AsignarParametro("no_ret", OracleClient.OracleType.Number)
            db_bd.AsignarParametro("no_sqlerrm", 200, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            If opcion = 1 Then
                db_bd.AsignarParametro("vo_usuario", 200, OracleClient.OracleType.VarChar, ParameterDirection.Output)
                db_bd.AsignarParametro("no_unidad", OracleClient.OracleType.Number)
            End If
            db_bd.EjecutarComando()
            If db_bd.Parametros.Length > 0 Then
                Me.idusuario_personal = IIf(db_bd.Parametros(1) Is DBNull.Value, 0, db_bd.Parametros(1))
                Me.retorno = IIf(db_bd.Parametros(2) Is DBNull.Value, "", db_bd.Parametros(2))
                Me.mensaje = IIf(db_bd.Parametros(3) Is DBNull.Value, "", db_bd.Parametros(3))
                If opcion = 1 Then
                    Me.Usuario = IIf(db_bd.Parametros(4) Is DBNull.Value, "", db_bd.Parametros(4))
                    Me.unidad = IIf(db_bd.Parametros(5) Is DBNull.Value, 0, db_bd.Parametros(5))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
    End Sub

    Public Function ListarProductos(ByVal opcion As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            Dim ldt_tmp As New DataTable
            '
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_listar_producto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function ListarAgenciaUsuario(ByVal Cmb As System.Windows.Forms.ComboBox, ByVal P_IdRol_Usuario As Int64, ByVal P_idAgencia As Int64, ByVal inicio As String, ByVal fin As String)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'acceso 21/04/2010
            'db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_USUARIOS_AGENCIAS", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOGENERAL.sp_listar_agencia_usuario", CommandType.StoredProcedure)
            db.AsignarParametro("P_IdRol_Usuario", P_IdRol_Usuario, OracleClient.OracleType.Number)
            db.AsignarParametro("P_idAgencia", P_idAgencia, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LISTAR_USUARIOS_AGENCIAS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            With Cmb
                .DataSource = db.EjecutarDataTable.DefaultView
                .DisplayMember = "NOMBREUSUARIO"
                .ValueMember = "IDUSUARIO_PERSONAL"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

#End Region
End Class