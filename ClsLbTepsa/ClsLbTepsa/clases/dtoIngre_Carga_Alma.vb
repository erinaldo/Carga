Imports AccesoDatos
Public Class dtoIngre_Carga_Alma
    Inherits ClsLbTepsa.dtoFACTURA
    Dim MyNOMBRE_AGENCIA_ORIGEN As String
    Dim MyNOMBRE_AGENCIA_DESTINO As String
    Dim MyID_EXIS As Integer
    Dim MyCODIGO_UBICACION As String
    Dim MyNRO_BULTO As String
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyAREA As String
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDUSUARIO_PERSONAL_MOD As Long
    Dim MyANA As String
    Dim MyALMA As String
    Dim MyIDAGENCIAS As Long
    Dim MyCOLUM As Long
    Dim MyFILA As Long
    Dim MyIPMOD As String
    Dim MyFECHA_REGISTRO As String
    Dim MyABRE As String
    Dim MyIP As String
    Dim MyIDALMA As Long
    Dim MyIDANA As Long
    Dim MyIDROL As Long
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyIDAREA As Long
    Dim MyCODIGO_BARRA As String
    Dim MyIDROL_MOD As Long
    Dim MyMAX_COLUM As Long
    Dim MyMAX_FILA As Long
    Public Property NOMBRE_AGENCIA_ORIGEN() As String

        Get
            NOMBRE_AGENCIA_ORIGEN = MyNOMBRE_AGENCIA_ORIGEN
        End Get
        Set(ByVal value As String)
            MyNOMBRE_AGENCIA_ORIGEN = value
        End Set
    End Property
    Public Property NOMBRE_AGENCIA_DESTINO() As String

        Get
            NOMBRE_AGENCIA_DESTINO = MyNOMBRE_AGENCIA_DESTINO
        End Get
        Set(ByVal value As String)
            MyNOMBRE_AGENCIA_DESTINO = value
        End Set
    End Property
    Public Property ID_EXIS() As Integer

        Get
            ID_EXIS = MyID_EXIS
        End Get
        Set(ByVal value As Integer)
            MyID_EXIS = value
        End Set
    End Property
    Public Property NRO_BULTO() As String

        Get
            NRO_BULTO = MyNRO_BULTO
        End Get
        Set(ByVal value As String)
            MyNRO_BULTO = value
        End Set
    End Property
    Public Property CODIGO_UBICACION() As String

        Get
            CODIGO_UBICACION = MyCODIGO_UBICACION
        End Get
        Set(ByVal value As String)
            MyCODIGO_UBICACION = value
        End Set
    End Property
    Public Property MAX_COLUM() As Long

        Get
            MAX_COLUM = MyMAX_COLUM
        End Get
        Set(ByVal value As Long)
            MyMAX_COLUM = value
        End Set
    End Property
    Public Property MAX_FILA() As Long

        Get
            MAX_FILA = MyMAX_FILA
        End Get
        Set(ByVal value As Long)
            MyMAX_FILA = value
        End Set
    End Property

    Public Property IDROL() As Long

        Get
            IDROL = MyIDROL
        End Get
        Set(ByVal value As Long)
            MyIDROL = value
        End Set
    End Property
    Public Property ABRE() As String

        Get
            ABRE = MyABRE
        End Get
        Set(ByVal value As String)
            MyABRE = value
        End Set
    End Property
    Public Property CODIGO_BARRA() As String

        Get
            CODIGO_BARRA = MyCODIGO_BARRA
        End Get
        Set(ByVal value As String)
            MyCODIGO_BARRA = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL_MOD() As Long

        Get
            IDUSUARIO_PERSONAL_MOD = MyIDUSUARIO_PERSONAL_MOD
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL_MOD = value
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
    Public Property AREA() As String

        Get
            AREA = MyAREA
        End Get
        Set(ByVal value As String)
            MyAREA = value
        End Set
    End Property
    Public Property IDALMA() As Long

        Get
            IDALMA = MyIDALMA
        End Get
        Set(ByVal value As Long)
            MyIDALMA = value
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
    Public Property COLUM() As Long

        Get
            COLUM = MyCOLUM
        End Get
        Set(ByVal value As Long)
            MyCOLUM = value
        End Set
    End Property
    Public Property IDROL_MOD() As Long

        Get
            IDROL_MOD = MyIDROL_MOD
        End Get
        Set(ByVal value As Long)
            MyIDROL_MOD = value
        End Set
    End Property
    Public Property ANA() As String

        Get
            ANA = MyANA
        End Get
        Set(ByVal value As String)
            MyANA = value
        End Set
    End Property
    Public Property IDAREA() As Long

        Get
            IDAREA = MyIDAREA
        End Get
        Set(ByVal value As Long)
            MyIDAREA = value
        End Set
    End Property
    Public Property FILA() As Long

        Get
            FILA = MyFILA
        End Get
        Set(ByVal value As Long)
            MyFILA = value
        End Set
    End Property

    Public Property ALMA() As String

        Get
            ALMA = MyALMA
        End Get
        Set(ByVal value As String)
            MyALMA = value
        End Set
    End Property
    Public Property IDANA() As Long

        Get
            IDANA = MyIDANA
        End Get
        Set(ByVal value As Long)
            MyIDANA = value
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
    'Public Sub SP_IN_T_INGRE_ANAQUELES_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOIngre_Carga_Alma.SP_IN_T_INGRE_ANAQUELES"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDALMA", OracleClient.OracleType.Number)).Value = IDALMA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAREA", OracleClient.OracleType.Number)).Value = IDAREA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDANA", OracleClient.OracleType.Number)).Value = IDANA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_CODIGO_BARRA", OracleClient.OracleType.VarChar)).Value = CODIGO_BARRA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_COLUM", OracleClient.OracleType.Number)).Value = COLUM
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FILA", OracleClient.OracleType.Number)).Value = FILA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL_MOD", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL_MOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IPMOD", OracleClient.OracleType.VarChar)).Value = IPMOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_REGISTRO", OracleClient.OracleType.VarChar)).Value = FECHA_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_ACTUALIZACION", OracleClient.OracleType.VarChar)).Value = FECHA_ACTUALIZACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL", OracleClient.OracleType.Number)).Value = IDROL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_MOD", OracleClient.OracleType.Number)).Value = IDROL_MOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub SP_IN_T_INGRE_ANAQUELES()
        Dim db_bd As New BaseDatos
        Try
            '
            IDPERSONA = IIf(IDPERSONA = 0, -666, IDPERSONA)
            IDUSUARIO_PERSONAL = IIf(IDUSUARIO_PERSONAL = 0, -666, IDUSUARIO_PERSONAL)
            '
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOIngre_Carga_Alma.SP_IN_T_INGRE_ANAQUELES", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDALMA", IDALMA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDAREA", IDAREA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDANA", IDANA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_CODIGO_BARRA", CODIGO_BARRA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_COLUM", COLUM, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_FILA", FILA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUSUARIO_PERSONAL_MOD", IDUSUARIO_PERSONAL_MOD, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IPMOD", IPMOD, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_FECHA_REGISTRO", FECHA_REGISTRO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_FECHA_ACTUALIZACION", FECHA_ACTUALIZACION, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDROL", IDROL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDROL_MOD", IDROL_MOD, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDESTADO_REGISTRO", IDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            'Variables de salidas 
            '
            db_bd.EjecutarEscalar()
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub
    'Public Sub SP_UP_T_INGRE_ANAQUELES_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOIngre_Carga_Alma.SP_UP_T_INGRE_ANAQUELES"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDALMA", OracleClient.OracleType.Number)).Value = IDALMA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAREA", OracleClient.OracleType.Number)).Value = IDAREA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDANA", OracleClient.OracleType.Number)).Value = IDANA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_CODIGO_BARRA", OracleClient.OracleType.VarChar)).Value = CODIGO_BARRA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_COLUM", OracleClient.OracleType.Number)).Value = COLUM
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FILA", OracleClient.OracleType.Number)).Value = FILA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL_MOD", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL_MOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IPMOD", OracleClient.OracleType.VarChar)).Value = IPMOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_REGISTRO", OracleClient.OracleType.VarChar)).Value = FECHA_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_RECHA_ACTUALIZACION", OracleClient.OracleType.VarChar)).Value = FECHA_ACTUALIZACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL", OracleClient.OracleType.Number)).Value = IDROL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_MOD", OracleClient.OracleType.Number)).Value = IDROL_MOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Sub SP_DE_T_INGRE_ANAQUELES_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOIngre_Carga_Alma.SP_DE_T_INGRE_ANAQUELES"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDALMA", OracleClient.OracleType.Number)).Value = IDALMA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAREA", OracleClient.OracleType.Number)).Value = IDAREA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDANA", OracleClient.OracleType.Number)).Value = IDANA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_CODIGO_BARRA", OracleClient.OracleType.VarChar)).Value = CODIGO_BARRA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_COLUM", OracleClient.OracleType.Number)).Value = COLUM
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FILA", OracleClient.OracleType.Number)).Value = FILA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL_MOD", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL_MOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IPMOD", OracleClient.OracleType.VarChar)).Value = IPMOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_REGISTRO", OracleClient.OracleType.VarChar)).Value = FECHA_REGISTRO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_ACTUALIZACION", OracleClient.OracleType.VarChar)).Value = FECHA_ACTUALIZACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL", OracleClient.OracleType.Number)).Value = IDROL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_MOD", OracleClient.OracleType.Number)).Value = IDROL_MOD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    'Public Function sp_cb_l_almacenes_2009(ByRef Cmb As System.Windows.Forms.ComboBox, ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_ivoingre_carga_alma.sp_cb_l_almacenes"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_cb_l_almacenes", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .ValueMember = "IDALMA"
    '            .DisplayMember = "ALMA"
    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_cb_l_almacenes(ByRef Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOIngre_Carga_Alma.sp_CB_l_almacenes", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_cb_l_almacenes", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            dv = ldt_tmp.DefaultView
            With Cmb
                .DataSource = dv
                .ValueMember = "IDALMA"
                .DisplayMember = "ALMA"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_cb_l_areas_2009(ByRef Cmb As System.Windows.Forms.ComboBox, ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_ivoingre_carga_alma.sp_cb_l_areas"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idalma", OracleClient.OracleType.Number)).Value = IDALMA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_cb_l_areas", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    '
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    '
    '    Try
    '        '
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .ValueMember = "IDAREA"
    '            .DisplayMember = "AREA"
    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_cb_l_areas(ByRef Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivoingre_carga_alma.sp_cb_l_areas", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idalma", IDALMA, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_cb_l_areas", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            dv = ldt_tmp.DefaultView
            With Cmb
                .DataSource = dv
                .ValueMember = "IDAREA"
                .DisplayMember = "AREA"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_cb_l_ANAQUELES_2009(ByRef Cmb As System.Windows.Forms.ComboBox, ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_ivoingre_carga_alma.sp_cb_l_ANAQUELES"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idalma", OracleClient.OracleType.Number)).Value = IDALMA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idaREA", OracleClient.OracleType.Number)).Value = IDAREA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_cb_l_ANAQUELES", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .ValueMember = "IDANA"
    '            .DisplayMember = "ANA"
    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_cb_l_ANAQUELES(ByRef Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivoingre_carga_alma.sp_cb_l_ANAQUELES", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idalma", IDALMA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idaREA", IDAREA, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_cb_l_ANAQUELES", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            dv = ldt_tmp.DefaultView
            With Cmb
                .DataSource = dv
                .ValueMember = "IDANA"
                .DisplayMember = "ANA"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Sub SP_SELEC_T_ALMA_ANAQUELES_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOIngre_Carga_Alma.SP_SELEC_T_ALMA_ANAQUELES"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDALMA", OracleClient.OracleType.Number)).Value = IDALMA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAREA", OracleClient.OracleType.Number)).Value = IDAREA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDANA", OracleClient.OracleType.Number)).Value = IDANA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("cur_SELEC_T_ALMA_ANAQUELES", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        If Not dv.Table.Rows(0).IsNull("MAX_COLUM") Then MAX_COLUM = dv.Table.Rows(0)("MAX_COLUM") Else MAX_COLUM = 0
    '        If Not dv.Table.Rows(0).IsNull("MAX_FILA") Then MAX_FILA = dv.Table.Rows(0)("MAX_FILA") Else MAX_FILA = 0
    '        If Not dv.Table.Rows(0).IsNull("IDAGENCIAS") Then IDAGENCIAS = dv.Table.Rows(0)("IDAGENCIAS") Else IDAGENCIAS = 0
    '        If Not dv.Table.Rows(0).IsNull("IDALMA") Then IDALMA = dv.Table.Rows(0)("IDALMA") Else IDALMA = 0
    '        If Not dv.Table.Rows(0).IsNull("IDAREA") Then IDAREA = dv.Table.Rows(0)("IDAREA") Else IDAREA = 0
    '        If Not dv.Table.Rows(0).IsNull("IDANA") Then IDANA = dv.Table.Rows(0)("IDANA") Else IDANA = 0
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub SP_SELEC_T_ALMA_ANAQUELES()
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOIngre_Carga_Alma.SP_SELEC_T_ALMA_ANAQUELES", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDALMA", IDALMA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDAREA", IDAREA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDANA", IDANA, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_SELEC_T_ALMA_ANAQUELES", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()

            If Not ldt_tmp.Rows(0).IsNull("MAX_COLUM") Then MAX_COLUM = ldt_tmp.Rows(0)("MAX_COLUM") Else MAX_COLUM = 0
            If Not ldt_tmp.Rows(0).IsNull("MAX_FILA") Then MAX_FILA = ldt_tmp.Rows(0)("MAX_FILA") Else MAX_FILA = 0
            If Not ldt_tmp.Rows(0).IsNull("IDAGENCIAS") Then IDAGENCIAS = ldt_tmp.Rows(0)("IDAGENCIAS") Else IDAGENCIAS = 0
            If Not ldt_tmp.Rows(0).IsNull("IDALMA") Then IDALMA = ldt_tmp.Rows(0)("IDALMA") Else IDALMA = 0
            If Not ldt_tmp.Rows(0).IsNull("IDAREA") Then IDAREA = ldt_tmp.Rows(0)("IDAREA") Else IDAREA = 0
            If Not ldt_tmp.Rows(0).IsNull("IDANA") Then IDANA = ldt_tmp.Rows(0)("IDANA") Else IDANA = 0
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'Public Function SP_SELEC_VENTA_2009(ByVal cnn As OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOIngre_Carga_Alma.SP_SELEC_VENTA"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_serie_factura", OracleClient.OracleType.VarChar)).Value = SERIE_FACTURA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_nro_factura", OracleClient.OracleType.VarChar)).Value = NRO_FACTURA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_comprobante", OracleClient.OracleType.VarChar)).Value = IDTIPO_COMPROBANTE
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_SELEC_VENTA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_SELEC_VENTA() As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOIngre_Carga_Alma.SP_SELEC_VENTA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("P_SERIE_FACTURA", SERIE_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_NRO_FACTURA", NRO_FACTURA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDTIPO_COMPROBANTE", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_SELEC_VENTA", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            dv = ldt_tmp.DefaultView
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_SELEC_VENTA_UBICA_2009(ByVal cnn As OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOIngre_Carga_Alma.SP_SELEC_VENTA_UBICA"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idtipo_comprobante", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idcomprobante", OracleClient.OracleType.Number)).Value = IDFACTURA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_SELEC_VENTA_UBICA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_SELEC_VENTA_UBICA() As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOIngre_Carga_Alma.SP_SELEC_VENTA_UBICA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_idtipo_comprobante", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idcomprobante", IDFACTURA, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_SELEC_VENTA_UBICA", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            dv = ldt_tmp.DefaultView
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_RECU_INGRE_ALMA_2009(ByVal cnn As OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOIngre_Carga_Alma.SP_RECU_INGRE_ALMA"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDALMA", OracleClient.OracleType.Number)).Value = IDALMA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAREA", OracleClient.OracleType.Number)).Value = IDAREA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDANA", OracleClient.OracleType.Number)).Value = IDANA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_RECU_INGRE_ALMA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    '
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function SP_RECU_INGRE_ALMA() As DataView
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOIngre_Carga_Alma.SP_RECU_INGRE_ALMA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDALMA", IDALMA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDAREA", IDAREA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDANA", IDANA, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_RECU_INGRE_ALMA", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            dv = ldt_tmp.DefaultView
            Return dv
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_cb_l_almacenes_TODOS_2009(ByRef Cmb As System.Windows.Forms.ComboBox, ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_ivoingre_carga_alma.sp_cb_l_almacenes_todos"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_cb_l_almacenes", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
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
    '            .ValueMember = "IDALMA"
    '            .DisplayMember = "ALMA"

    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_cb_l_almacenes_TODOS(ByRef Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivoingre_carga_alma.sp_cb_l_almacenes_todos", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_cb_l_almacenes", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            dv = ldt_tmp.DefaultView
            With Cmb
                .DataSource = dv
                .ValueMember = "IDALMA"
                .DisplayMember = "ALMA"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_cb_l_areas_TODOS_2009(ByRef Cmb As System.Windows.Forms.ComboBox, ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_ivoingre_carga_alma.sp_cb_l_areas_TODOS"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idalma", OracleClient.OracleType.Number)).Value = IDALMA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_cb_l_areas", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Dim dv As New DataView
    '    Try
    '        dv = ds.Tables(0).DefaultView
    '        With Cmb
    '            .DataSource = dv
    '            .ValueMember = "IDAREA"
    '            .DisplayMember = "AREA"
    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_cb_l_areas_TODOS(ByRef Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivoingre_carga_alma.sp_cb_l_areas_TODOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_IDALMA", IDALMA, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_cb_l_AREAS", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            dv = ldt_tmp.DefaultView
            With Cmb
                .DataSource = dv
                .ValueMember = "IDAREA"
                .DisplayMember = "AREA"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_cb_l_ANAQUELES_TODOS_2009(ByRef Cmb As System.Windows.Forms.ComboBox, ByVal cnn As OracleClient.OracleConnection) As Boolean
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_ivoingre_carga_alma.sp_cb_l_ANAQUELES_TODOS"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idagencias", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idalma", OracleClient.OracleType.Number)).Value = IDALMA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("p_idaREA", OracleClient.OracleType.Number)).Value = IDAREA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_cb_l_ANAQUELES", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
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
    '            .ValueMember = "IDANA"
    '            .DisplayMember = "ANA"
    '        End With
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_cb_l_ANAQUELES_TODOS(ByRef Cmb As System.Windows.Forms.ComboBox) As Boolean
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView           
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivoingre_carga_alma.sp_cb_l_ANAQUELES_TODOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_IDALMA", IDALMA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_IDAREA", IDAREA, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_cb_l_ANAQUELES", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            dv = ldt_tmp.DefaultView
            With Cmb
                .DataSource = dv
                .ValueMember = "IDANA"
                .DisplayMember = "ANA"
            End With
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function Valida_Anaquel_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_PDT_ALMACEN.Valida_Anaquel"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_CODIGO_UBICACION", OracleClient.OracleType.VarChar)).Value = CODIGO_UBICACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_Almacen", OracleClient.OracleType.VarChar, 30)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_Area", OracleClient.OracleType.VarChar, 30)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_Anaquel", OracleClient.OracleType.VarChar, 30)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_Fila", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_Columna", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_ID_EXIS", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.ExecuteNonQuery()
    '        ID_EXIS = cmd.Parameters("oP_ID_EXIS").Value
    '        If ID_EXIS = 1 Then
    '            MsgBox("Anquel no existe", MsgBoxStyle.Information, "Seguridad del Sistema")
    '            ALMA = ""
    '            AREA = ""
    '            ANA = ""
    '            FILA = 0
    '            COLUM = 0
    '        End If
    '        If ID_EXIS = 2 Then
    '            MsgBox("Agencia no corresponde al usuario", MsgBoxStyle.Information, "Seguridad del Sistema")
    '            ALMA = ""
    '            AREA = ""
    '            ANA = ""
    '            FILA = 0
    '            COLUM = 0
    '        End If
    '        If ID_EXIS = 3 Then
    '            MsgBox("Error no definido", MsgBoxStyle.Information, "Seguridad del Sistema")
    '            AREA = ""
    '            ANA = ""
    '            FILA = 0
    '            COLUM = 0
    '        End If
    '        If ID_EXIS = 0 Then
    '            ALMA = cmd.Parameters("oP_ALMACEN").Value
    '            AREA = cmd.Parameters("oP_Area").Value
    '            ANA = cmd.Parameters("oP_Anaquel").Value
    '            FILA = cmd.Parameters("oP_Fila").Value
    '            COLUM = cmd.Parameters("oP_Columna").Value
    '        End If
    '    Catch Ex As Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function Act_Ubicacion_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try

    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure


    '        cmd.CommandText = "PKG_PDT_ALMACEN.Act_Ubicacion"

    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_CODIGO_UBICACION", OracleClient.OracleType.VarChar)).Value = CODIGO_UBICACION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_CODIGO_BARRA", OracleClient.OracleType.VarChar)).Value = CODIGO_BARRA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_OPERACION", OracleClient.OracleType.Int16)).Value = OPE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_NroBulto", OracleClient.OracleType.VarChar, 30)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_NroGE", OracleClient.OracleType.VarChar, 15)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_Origen", OracleClient.OracleType.VarChar, 30)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_Destino", OracleClient.OracleType.VarChar, 30)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_ID_EXIS", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output


    '        cmd.ExecuteNonQuery()

    '        ID_EXIS = cmd.Parameters("oP_ID_EXIS").Value
    '        If ID_EXIS = 1 Then
    '            MsgBox("Bulto no existe", MsgBoxStyle.Information, "Seguridad del Sistema")
    '            NRO_BULTO = ""
    '            NRO_FACTURA = ""
    '            NOMBRE_AGENCIA_ORIGEN = ""
    '            NOMBRE_AGENCIA_DESTINO = ""
    '        End If

    '        If ID_EXIS = 2 Then
    '            If Not OPE = 1 Then
    '                If MsgBox("El bulto ya esta en el almacén, ¿Desea cambiar de ubicación?", MsgBoxStyle.YesNo, "Seguridad del Sistema") = MsgBoxResult.Yes Then
    '                    OPE = 1
    '                End If

    '                NRO_BULTO = cmd.Parameters("oP_NroBulto").Value
    '                NRO_FACTURA = cmd.Parameters("oP_NroGE").Value
    '                NOMBRE_AGENCIA_ORIGEN = cmd.Parameters("oP_Origen").Value
    '                NOMBRE_AGENCIA_DESTINO = cmd.Parameters("oP_Destino").Value
    '            End If
    '        End If

    '        If ID_EXIS = 3 Then
    '            MsgBox("Error no definido", MsgBoxStyle.Information, "Seguridad del Sistema")
    '            NRO_BULTO = ""
    '            NRO_FACTURA = ""
    '            NOMBRE_AGENCIA_ORIGEN = ""
    '            NOMBRE_AGENCIA_DESTINO = ""
    '        End If

    '        If ID_EXIS = 0 Then
    '            NRO_BULTO = cmd.Parameters("oP_NroBulto").Value
    '            NRO_FACTURA = cmd.Parameters("oP_NroGE").Value
    '            NOMBRE_AGENCIA_ORIGEN = cmd.Parameters("oP_Origen").Value
    '            NOMBRE_AGENCIA_DESTINO = cmd.Parameters("oP_Destino").Value
    '        End If
    '    Catch Ex As Exception
    '        MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Sub SP_SELEC_T_ANAQUELES_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOIngre_Carga_Alma.SP_SELEC_T_ANAQUELES"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDANA", OracleClient.OracleType.Number)).Value = IDANA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CURR_SELEC_T_ANAQUELES", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        If Not dv.Table.Rows(0).IsNull("ANA") Then ANA = dv.Table.Rows(0)("ANA") Else ANA = ""
    '        If Not dv.Table.Rows(0).IsNull("ABRE") Then ABRE = dv.Table.Rows(0)("ABRE") Else ABRE = ""
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Public Sub SP_SELEC_T_ANAQUELES()
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOIngre_Carga_Alma.SP_SELEC_T_ANAQUELES", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("P_IDANA", IDANA, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CURR_SELEC_T_ANAQUELES", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            If Not ldt_tmp.Rows(0).IsNull("ANA") Then ANA = ldt_tmp.Rows(0)("ANA") Else ANA = ""
            If Not ldt_tmp.Rows(0).IsNull("ABRE") Then ABRE = ldt_tmp.Rows(0)("ABRE") Else ABRE = ""
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
End Class
