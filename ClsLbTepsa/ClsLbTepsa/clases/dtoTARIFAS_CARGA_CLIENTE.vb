Imports AccesoDatos

Public Class dtoTARIFAS_CARGA_CLIENTE
#Region "VARIABLES"
    Dim MyORIGEN As String
    Dim MyDESTINO As String
    Dim MyIDTARIFAS_CARGA_CLIENTE As Integer
    Dim MyIDPERSONA As Integer
    Dim MyIDUNIDAD_AGENCIA As Integer
    Dim MyIDUNIDAD_AGENCIA_DESTINO As Integer
    Dim MyCG_MONTO_BASE As Double
    Dim MyCG_X_PESO As Double
    Dim MyCG_X_VOLUMEN As Double
    Dim MyCG_X_SOBRE As Double
    '
    Dim MyEC_MONTO_BASE As Integer
    Dim MyEC_X_PESO As Integer
    Dim MyEC_X_VOLUMEN As Integer
    Dim MyPO_MONTO_BASE As Integer
    Dim MyPO_X_PESO As Integer
    Dim MyPO_X_VOLUMEN As Integer
    Dim MyGI_MONTO_BASE As Integer
    Dim MyGI_NORMAL As Integer
    Dim MyGI_TELEFONICO As Integer
    Dim MyFECHA_ACTIVACION As String
    Dim MyFECHA_DESACTIVACION As String
    Dim MyES_VIGENTE As Integer
    Dim MyIDESTADO_REGISTRO As Integer
    Dim MyIDUSUARIO_PERSONAL As Integer
    Dim MyIDROL_USUARIO As Integer
    Dim MyIP As String
    Dim MyIDUSUARIO_PERSONALMOD As Integer
    Dim MyIDROL_USUARIOMOD As Integer
    Dim MyIPMOD As String
    Dim MyFECHA_REGISTRO As String
    Dim MyFECHA_ACTUALIZACION As String
#End Region
#Region "PROPIEDADES"

    Public Property ORIGEN() As String
        Get
            ORIGEN = MyORIGEN
        End Get
        Set(ByVal value As String)
            MyORIGEN = value
        End Set
    End Property
    Public Property DESTINO() As String
        Get
            DESTINO = MyDESTINO
        End Get
        Set(ByVal value As String)
            MyDESTINO = value
        End Set
    End Property
    Public Property IDTARIFAS_CARGA_CLIENTE() As Integer
        Get
            IDTARIFAS_CARGA_CLIENTE = MyIDTARIFAS_CARGA_CLIENTE
        End Get
        Set(ByVal value As Integer)
            MyIDTARIFAS_CARGA_CLIENTE = value
        End Set
    End Property
    Public Property IDPERSONA() As Integer
        Get
            IDPERSONA = MyIDPERSONA
        End Get
        Set(ByVal value As Integer)
            MyIDPERSONA = value
        End Set
    End Property
    Public Property IDUNIDAD_AGENCIA() As Integer
        Get
            IDUNIDAD_AGENCIA = MyIDUNIDAD_AGENCIA
        End Get
        Set(ByVal value As Integer)
            MyIDUNIDAD_AGENCIA = value
        End Set
    End Property
    Public Property IDUNIDAD_AGENCIA_DESTINO() As Integer
        Get
            IDUNIDAD_AGENCIA_DESTINO = MyIDUNIDAD_AGENCIA_DESTINO
        End Get
        Set(ByVal value As Integer)
            MyIDUNIDAD_AGENCIA_DESTINO = value
        End Set
    End Property
    Public Property CG_MONTO_BASE() As Double
        Get
            CG_MONTO_BASE = MyCG_MONTO_BASE
        End Get
        Set(ByVal value As Double)
            MyCG_MONTO_BASE = value
        End Set
    End Property
    Public Property CG_X_SOBRE() As Double
        Get
            CG_X_SOBRE = MyCG_X_SOBRE
        End Get
        Set(ByVal value As Double)
            MyCG_X_SOBRE = value
        End Set
    End Property
    Public Property CG_X_PESO() As Double
        Get
            CG_X_PESO = MyCG_X_PESO
        End Get
        Set(ByVal value As Double)
            MyCG_X_PESO = value
        End Set
    End Property
    Public Property CG_X_VOLUMEN() As Double
        Get
            CG_X_VOLUMEN = MyCG_X_VOLUMEN
        End Get
        Set(ByVal value As Double)
            MyCG_X_VOLUMEN = value
        End Set
    End Property
    Public Property EC_MONTO_BASE() As Integer
        Get
            EC_MONTO_BASE = MyEC_MONTO_BASE
        End Get
        Set(ByVal value As Integer)
            MyEC_MONTO_BASE = value
        End Set
    End Property
    Public Property EC_X_PESO() As Integer
        Get
            EC_X_PESO = MyEC_X_PESO
        End Get
        Set(ByVal value As Integer)
            MyEC_X_PESO = value
        End Set
    End Property
    Public Property EC_X_VOLUMEN() As Integer
        Get
            EC_X_VOLUMEN = MyEC_X_VOLUMEN
        End Get
        Set(ByVal value As Integer)
            MyEC_X_VOLUMEN = value
        End Set
    End Property
    Public Property PO_MONTO_BASE() As Integer
        Get
            PO_MONTO_BASE = MyPO_MONTO_BASE
        End Get
        Set(ByVal value As Integer)
            MyPO_MONTO_BASE = value
        End Set
    End Property
    Public Property PO_X_PESO() As Integer
        Get
            PO_X_PESO = MyPO_X_PESO
        End Get
        Set(ByVal value As Integer)
            MyPO_X_PESO = value
        End Set
    End Property
    Public Property PO_X_VOLUMEN() As Integer
        Get
            PO_X_VOLUMEN = MyPO_X_VOLUMEN
        End Get
        Set(ByVal value As Integer)
            MyPO_X_VOLUMEN = value
        End Set
    End Property
    Public Property GI_MONTO_BASE() As Integer
        Get
            GI_MONTO_BASE = MyGI_MONTO_BASE
        End Get
        Set(ByVal value As Integer)
            MyGI_MONTO_BASE = value
        End Set
    End Property
    Public Property GI_NORMAL() As Integer
        Get
            GI_NORMAL = MyGI_NORMAL
        End Get
        Set(ByVal value As Integer)
            MyGI_NORMAL = value
        End Set
    End Property
    Public Property GI_TELEFONICO() As Integer
        Get
            GI_TELEFONICO = MyGI_TELEFONICO
        End Get
        Set(ByVal value As Integer)
            MyGI_TELEFONICO = value
        End Set
    End Property
    Public Property FECHA_ACTIVACION() As String 'NO_DEFINIDO
        Get
            FECHA_ACTIVACION = MyFECHA_ACTIVACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ACTIVACION = value
        End Set
    End Property
    Public Property FECHA_DESACTIVACION() As String 'NO_DEFINIDO
        Get
            FECHA_DESACTIVACION = MyFECHA_DESACTIVACION
        End Get
        Set(ByVal value As String)
            MyFECHA_DESACTIVACION = value
        End Set
    End Property
    Public Property ES_VIGENTE() As Integer
        Get
            ES_VIGENTE = MyES_VIGENTE
        End Get
        Set(ByVal value As Integer)
            MyES_VIGENTE = value
        End Set
    End Property
    Public Property IDESTADO_REGISTRO() As Integer
        Get
            IDESTADO_REGISTRO = MyIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Integer)
            MyIDESTADO_REGISTRO = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL() As Integer

        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Integer)
            MyIDUSUARIO_PERSONAL = value
        End Set
    End Property
    Public Property IDROL_USUARIO() As Integer

        Get
            IDROL_USUARIO = MyIDROL_USUARIO
        End Get
        Set(ByVal value As Integer)
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
    Public Property IDUSUARIO_PERSONALMOD() As Integer

        Get
            IDUSUARIO_PERSONALMOD = MyIDUSUARIO_PERSONALMOD
        End Get
        Set(ByVal value As Integer)
            MyIDUSUARIO_PERSONALMOD = value
        End Set
    End Property
    Public Property IDROL_USUARIOMOD() As Integer

        Get
            IDROL_USUARIOMOD = MyIDROL_USUARIOMOD
        End Get
        Set(ByVal value As Integer)
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
    Public Property FECHA_REGISTRO() As String 'NO_DEFINIDO
        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = value
        End Set
    End Property
    Public Property FECHA_ACTUALIZACION() As String 'NO_DEFINIDO
        Get
            FECHA_ACTUALIZACION = MyFECHA_ACTUALIZACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ACTUALIZACION = value
        End Set
    End Property
#End Region


#Region "METODOS"
    'Public Function FN_L_TARIFAS_CLIEN_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOTARIFAS.SP_L_TARIFAS_CLIEN", 6, _
    '    IIf(IDPERSONA = 0, -666, IDPERSONA), 1, _
    '    IIf(IDUSUARIO_PERSONAL = 0, -666, IDUSUARIO_PERSONAL), 1}
    '    '
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try

    '        dv = dT.DefaultView
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_L_TARIFAS_CLIEN() As DataView
        Try
            '
            IDPERSONA = IIf(IDPERSONA = 0, -666, IDPERSONA)
            IDUSUARIO_PERSONAL = IIf(IDUSUARIO_PERSONAL = 0, -666, IDUSUARIO_PERSONAL)
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOTARIFAS.SP_L_TARIFAS_CLIEN", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("P_IDPERSONA", IDPERSONA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_L_TARIFAS_CLIEN", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable
            '
            dv = ldt_tmp.DefaultView
            '
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_L_TARIFAS_CARGA(ByVal VOCONTROLUSUARIO As Object) As DataView

    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOTARIFAS.SP_L_TARIFAS_CARGA", 6, _
    '    IIf(IDUNIDAD_AGENCIA = 0, -666, IDUNIDAD_AGENCIA), 1, _
    '    IIf(IDUNIDAD_AGENCIA_DESTINO = 0, -666, IDUNIDAD_AGENCIA_DESTINO), 1}


    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    MsgBox("paso")
    '    DA.Fill(dT, Rst)
    '    Try

    '        dv = dT.DefaultView
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function FN_L_TARIFAS_CARGA_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    'hlamas 13-10-2008
    '    'Dim varSP_OBJECT() As Object = {"PKG_IVOTARIFAS.SP_L_TARIFAS_CARGA", 6, _
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOTARIFAS.SP_L_TARIFAS_CARGA_1", 6, _
    '    IIf(IDUNIDAD_AGENCIA = 0, -666, IDUNIDAD_AGENCIA), 1, _
    '    IIf(IDUNIDAD_AGENCIA_DESTINO = 0, -666, IDUNIDAD_AGENCIA_DESTINO), 1}


    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    'MsgBox("paso")
    '    DA.Fill(dT, Rst)
    '    Try

    '        dv = dT.DefaultView
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function FN_L_TARIFAS_CARGA() As DataView
        Try
            '
            IDUNIDAD_AGENCIA = IIf(IDUNIDAD_AGENCIA = 0, -666, IDUNIDAD_AGENCIA)
            IDUNIDAD_AGENCIA_DESTINO = IIf(IDUNIDAD_AGENCIA_DESTINO = 0, -666, IDUNIDAD_AGENCIA_DESTINO)
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            'hlamas 13-10-2008
            db_bd.CrearComando("PKG_IVOTARIFAS.SP_L_TARIFAS_CARGA_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA", IDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_IDUNIDAD_AGENCIA_DESTINO", IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_L_TARIFAS_CARGA", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable
            '
            dv = ldt_tmp.DefaultView
            '
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Sub get_recupera_tarifa_x_ruta_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        'Recupera tarifa por ruta de la pública 
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOPERSONA.sp_get_tarifa_x_ruta"
    '        '-- Pasando los parametros
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_ideagencia_unidad", OracleClient.OracleType.Number)).Value = IDUNIDAD_AGENCIA
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ni_ideagencia_unidad_destino", OracleClient.OracleType.Number)).Value = IDUNIDAD_AGENCIA_DESTINO
    '        '-- Recuperando parametros
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_tarifa_x_ruta", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '---
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        '---
    '        'Dim dv As New DataView
    '        'dv = ds.Tables(0).DefaultView
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            If IsDBNull(ds.Tables(0).Rows(0)(0)) = True Then
    '                CG_MONTO_BASE = 0
    '            Else
    '                CG_MONTO_BASE = CType(ds.Tables(0).Rows(0)(0), Double)
    '            End If
    '            If IsDBNull(ds.Tables(0).Rows(0)(1)) = True Then
    '                CG_X_PESO = 0
    '            Else
    '                CG_X_PESO = CType(ds.Tables(0).Rows(0)(1), Double)
    '            End If
    '            If IsDBNull(ds.Tables(0).Rows(0)(2)) = True Then
    '                CG_X_VOLUMEN = 0
    '            Else
    '                CG_X_VOLUMEN = CType(ds.Tables(0).Rows(0)(2), Double)
    '            End If
    '            '
    '            If IsDBNull(ds.Tables(0).Rows(0)(3)) = True Then
    '                CG_X_SOBRE = CG_MONTO_BASE
    '            Else
    '                CG_X_SOBRE = CType(ds.Tables(0).Rows(0)(3), Double)
    '            End If
    '        Else
    '            CG_MONTO_BASE = 0
    '            CG_X_PESO = 0
    '            CG_X_VOLUMEN = 0
    '            CG_X_SOBRE = 0
    '        End If
    '        '---
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
    '    End Try
    'End Sub
    Public Sub get_recupera_tarifa_x_ruta()
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable

            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOPERSONA.sp_get_tarifa_x_ruta", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("ni_ideagencia_unidad", IDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_ideagencia_unidad_destino", IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            'Variables de salidas           
            db_bd.AsignarParametro("ocur_tarifa_x_ruta", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()

            ldt_tmp = db_bd.EjecutarDataTable

            ' Validacion cuando no encuentre nada en el select, insertara Ceros 13/07/2013
            If ldt_tmp.Rows.Count > 0 Then
                CG_MONTO_BASE = ldt_tmp.Rows(0).Item("cg_monto_base")
                CG_X_PESO = ldt_tmp.Rows(0).Item("cg_x_peso")
                CG_X_VOLUMEN = ldt_tmp.Rows(0).Item("cg_x_volumen")
                CG_X_SOBRE = ldt_tmp.Rows(0).Item("cg_x_sobre")
            End If

            ' Comentado por Diego Zegarra s13/07/2013
            '            
            'If ldt_tmp.Rows.Count >= 0 Then
            '    If IsDBNull(ldt_tmp.Rows(0)(0)) = True Then
            '        CG_MONTO_BASE = 0
            '    Else
            '        CG_MONTO_BASE = CType(ldt_tmp.Rows(0)(0), Double)
            '    End If
            '    If IsDBNull(ldt_tmp.Rows(0)(1)) = True Then
            '        CG_X_PESO = 0
            '    Else
            '        CG_X_PESO = CType(ldt_tmp.Rows(0)(1), Double)
            '    End If
            '    If IsDBNull(ldt_tmp.Rows(0)(2)) = True Then
            '        CG_X_VOLUMEN = 0
            '    Else
            '        CG_X_VOLUMEN = CType(ldt_tmp.Rows(0)(2), Double)
            '    End If
            '    '
            '    If IsDBNull(ldt_tmp.Rows(0)(3)) = True Then
            '        CG_X_SOBRE = CG_MONTO_BASE
            '    Else
            '        CG_X_SOBRE = CType(ldt_tmp.Rows(0)(3), Double)
            '    End If
            'Else
            '    CG_MONTO_BASE = 0
            '    CG_X_PESO = 0
            '    CG_X_VOLUMEN = 0
            '    CG_X_SOBRE = 0
            'End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
#End Region
End Class
