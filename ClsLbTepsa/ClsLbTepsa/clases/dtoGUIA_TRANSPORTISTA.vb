Imports AccesoDatos
Public Class dtoGUIA_TRANSPORTISTA

    Dim Mytipo_guia As String

    Dim Mynro_unidad_transporte As Long
    Dim MyFECHA_INICIAL As String
    Dim MyFECHA_FINAL As String
    Dim MyNRO_SALIDA As String
    Dim MyIDTIPO_SERVICIO As Long
    Dim MyPLACA_BUS As String
    Dim MyNRO_LICENCIA As String
    Dim MyRUC_TERCERO As String
    Dim MyMARCA_BUS As String
    Dim MyNOM_TERCERO As String
    Dim MyIDGUIA_TRANSPORTISTA As Long
    Dim MySERIE_GUIA_TRANSPORTISTA As Long
    Dim MyNRO_GUIA_TRANSPORTISTA As Long
    Dim MyIDUNIDAD_AGENCIA As Long
    Dim MyIDUNIDAD_AGENCIA_DESTINO As Long
    Dim MyIDITINERARIOS As Long
    Dim MyIDUNIDAD_TRANSPORTE As Long
    Dim MyIDUSUARIO_PERSONAL_PILOTO As Long
    Dim MyFECHA_SALIDA As String
    Dim MyHORA_SALIDA As String
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDROL_USUARIO As Long
    Dim MyIP As String
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyIPMOD As String
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyIDESTADO_ENVIO As Long
    Dim MyIDPERSONA As Long
    Dim MyIDAGENCIAS As Long
    Dim MyIDAGENCIAS_DESTINO As Long
    Dim MyFECHA_REGISTRO As String
    Dim MyFECHA_ACTUALIZACION As String
    ' 11/09/2007 - Omendoza 
    Dim SMySERIE_GUIA_TRANSPORTISTA As String
    Dim SMyNRO_GUIA_TRANSPORTISTA As String
    Dim Myestado_factura_guia_trans As Long
    '13/05/2008
    Dim myIDA_RETORNO As String
    '
    Dim my_consulta As Long
    Dim my_entregado As Long
    Dim MyIDFUNCIONARIO As Long
    Dim MyIDPROCESO As Long
    Dim MyTipoComprobante As Integer
    Public Property entregado_a() As Long
        Get
            entregado_a = my_entregado
        End Get
        Set(ByVal value As Long)
            my_entregado = value
        End Set
    End Property
    Public Property consulta_por() As Long
        Get
            consulta_por = my_consulta
        End Get
        Set(ByVal value As Long)
            my_consulta = value
        End Set
    End Property
    Public Property IDA_RETORNO() As String
        Get
            IDA_RETORNO = myIDA_RETORNO
        End Get
        Set(ByVal value As String)
            myIDA_RETORNO = value
        End Set
    End Property
    Public Property s_SERIE_GUIA_TRANSPORTISTA() As String
        Get
            s_SERIE_GUIA_TRANSPORTISTA = SMySERIE_GUIA_TRANSPORTISTA
        End Get
        Set(ByVal value As String)
            SMySERIE_GUIA_TRANSPORTISTA = value
        End Set
    End Property
    Public Property s_NRO_GUIA_TRANSPORTISTA() As String
        Get
            s_NRO_GUIA_TRANSPORTISTA = SMyNRO_GUIA_TRANSPORTISTA
        End Get
        Set(ByVal value As String)
            SMyNRO_GUIA_TRANSPORTISTA = value
        End Set
    End Property
    Public Property factura_guia_transportista() As Long
        Get
            factura_guia_transportista = Myestado_factura_guia_trans
        End Get
        Set(ByVal value As Long)
            Myestado_factura_guia_trans = value
        End Set
    End Property
    Public Property TIPO_GUIA() As String
        Get
            TIPO_GUIA = Mytipo_guia
        End Get
        Set(ByVal value As String)
            Mytipo_guia = value
        End Set
    End Property
    Public Property IDPERSONA() As Long
        Get
            IDPERSONA = MyIDPERSONA
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA = value
        End Set
    End Property
    Public Property IDESTADO_ENVIO() As Long
        Get
            IDESTADO_ENVIO = MyIDESTADO_ENVIO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_ENVIO = value
        End Set
    End Property
    Public Property IDAGENCIAS() As Long
        Get
            IDAGENCIAS = MyIDAGENCIAS
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS = value
        End Set
    End Property
    Public Property IDAGENCIAS_DESTINO() As Long
        Get
            IDAGENCIAS_DESTINO = MyIDAGENCIAS_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS_DESTINO = value
        End Set
    End Property
    Public Property nro_unidad_transporte() As Long
        Get
            nro_unidad_transporte = Mynro_unidad_transporte
        End Get
        Set(ByVal value As Long)
            Mynro_unidad_transporte = value
        End Set
    End Property
    Public Property FECHA_INICIAL() As String
        Get
            FECHA_INICIAL = MyFECHA_INICIAL
        End Get
        Set(ByVal value As String)
            MyFECHA_INICIAL = value
        End Set
    End Property
    Public Property FECHA_FINAL() As String
        Get
            FECHA_FINAL = MyFECHA_FINAL
        End Get
        Set(ByVal value As String)
            MyFECHA_FINAL = value
        End Set
    End Property
    Public Property NRO_SALIDA() As String
        Get
            NRO_SALIDA = MyNRO_SALIDA
        End Get
        Set(ByVal value As String)
            MyNRO_SALIDA = value
        End Set
    End Property
    Public Property IDTIPO_SERVICIO() As Long
        Get
            IDTIPO_SERVICIO = MyIDTIPO_SERVICIO
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_SERVICIO = value
        End Set
    End Property
    Public Property PLACA_BUS() As String
        Get
            PLACA_BUS = MyPLACA_BUS
        End Get
        Set(ByVal value As String)
            MyPLACA_BUS = value
        End Set
    End Property
    Public Property NRO_LICENCIA() As String
        Get
            NRO_LICENCIA = MyNRO_LICENCIA
        End Get
        Set(ByVal value As String)
            MyNRO_LICENCIA = value
        End Set
    End Property
    Public Property RUC_TERCERO() As String
        Get
            RUC_TERCERO = MyRUC_TERCERO
        End Get
        Set(ByVal value As String)
            MyRUC_TERCERO = value
        End Set
    End Property
    Public Property MARCA_BUS() As String
        Get
            MARCA_BUS = MyMARCA_BUS
        End Get
        Set(ByVal value As String)
            MyMARCA_BUS = value
        End Set
    End Property
    Public Property NOM_TERCERO() As String
        Get
            NOM_TERCERO = MyNOM_TERCERO
        End Get
        Set(ByVal value As String)
            MyNOM_TERCERO = value
        End Set
    End Property
    Public Property IDGUIA_TRANSPORTISTA() As Long
        Get
            IDGUIA_TRANSPORTISTA = MyIDGUIA_TRANSPORTISTA
        End Get
        Set(ByVal value As Long)
            MyIDGUIA_TRANSPORTISTA = value
        End Set
    End Property
    Public Property SERIE_GUIA_TRANSPORTISTA() As Long
        Get
            SERIE_GUIA_TRANSPORTISTA = MySERIE_GUIA_TRANSPORTISTA
        End Get
        Set(ByVal value As Long)
            MySERIE_GUIA_TRANSPORTISTA = value
        End Set
    End Property
    Public Property NRO_GUIA_TRANSPORTISTA() As Long
        Get
            NRO_GUIA_TRANSPORTISTA = MyNRO_GUIA_TRANSPORTISTA
        End Get
        Set(ByVal value As Long)
            MyNRO_GUIA_TRANSPORTISTA = value
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
    Public Property IDUNIDAD_AGENCIA_DESTINO() As Long
        Get
            IDUNIDAD_AGENCIA_DESTINO = MyIDUNIDAD_AGENCIA_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA_DESTINO = value
        End Set
    End Property
    Public Property IDITINERARIOS() As Long
        Get
            IDITINERARIOS = MyIDITINERARIOS
        End Get
        Set(ByVal value As Long)
            MyIDITINERARIOS = value
        End Set
    End Property
    Public Property IDUNIDAD_TRANSPORTE() As Long
        Get
            IDUNIDAD_TRANSPORTE = MyIDUNIDAD_TRANSPORTE
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_TRANSPORTE = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL_PILOTO() As Long
        Get
            IDUSUARIO_PERSONAL_PILOTO = MyIDUSUARIO_PERSONAL_PILOTO
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL_PILOTO = value
        End Set
    End Property
    Public Property FECHA_SALIDA() As String
        Get
            FECHA_SALIDA = MyFECHA_SALIDA
        End Get
        Set(ByVal value As String)
            MyFECHA_SALIDA = value
        End Set
    End Property
    Public Property HORA_SALIDA() As String
        Get
            HORA_SALIDA = MyHORA_SALIDA
        End Get
        Set(ByVal value As String)
            MyHORA_SALIDA = value
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
    Public Property IDESTADO_REGISTRO() As Long
        Get
            IDESTADO_REGISTRO = MyIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_REGISTRO = value
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

    '****nuevo Agregado******
    Public Property IDFUNCIONARIO() As Long
        Get
            IDFUNCIONARIO = MyIDFUNCIONARIO
        End Get
        Set(ByVal value As Long)
            MyIDFUNCIONARIO = value
        End Set
    End Property
    Public Property IDPRODUCTO() As Long
        Get
            IDPRODUCTO = MyIDPROCESO
        End Get
        Set(ByVal value As Long)
            MyIDPROCESO = value
        End Set
    End Property
    Public Property TipoComprobante() As Long
        Get
            TipoComprobante = MyTipoComprobante
        End Get
        Set(ByVal value As Long)
            MyTipoComprobante = value
        End Set
    End Property
    '**************************

    'Public Function sp_list_guia_transporII_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    ' Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_list_guia_transporII", 16, _
    '    'Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_list_guia_transporIII", 18, _
    '    ' Modificado 16/01/2009 se agregado 2 campos,consulta_por (credito,contado y pce)  
    '    '                                            entregado_a   (domicilio o agencia)  
    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_list_guia_transpor5", 22, _
    '    TIPO_GUIA, 2, _
    '    IDUNIDAD_AGENCIA, 1, _
    '    IDUNIDAD_AGENCIA_DESTINO, 1, _
    '    FECHA_INICIAL, 2, _
    '    FECHA_FINAL, 2, _
    '    nro_unidad_transporte, 1, _
    '    IDTIPO_SERVICIO, 1, _
    '    factura_guia_transportista, 1, _
    '    consulta_por, 1, _
    '    entregado_a, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function sp_list_guia_transporII() As DataView
    '    Try
    '        Dim db_bd As New BaseDatos
    '        Dim ldt_tmp As New DataTable
    '        Dim dv As New DataView
    '        '
    '        'conecta con la Bd
    '        db_bd.Conectar()
    '        ' Invocando  al procedimiento almacenado 
    '        'db_bd.CrearComando("pkg_ivobultos.sp_list_guia_transpor5", CommandType.StoredProcedure)
    '        db_bd.CrearComando("pkg_ivobultos.sp_list_guia_transpor6", CommandType.StoredProcedure)

    '        'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
    '        db_bd.AsignarParametro("p_tipo_guia", TIPO_GUIA, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_idunidad_agencia", IDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("p_idunidad_agencia_destino", IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("p_fecha_inIcial", FECHA_INICIAL, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_nro_unidad_transporte", nro_unidad_transporte, OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_idtipo_servicio", IDTIPO_SERVICIO, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("p_idestado_facturado", factura_guia_transportista, OracleClient.OracleType.Int32)
    '        db_bd.AsignarParametro("p_consulta", consulta_por, OracleClient.OracleType.Int16)
    '        db_bd.AsignarParametro("p_entrega_en", entregado_a, OracleClient.OracleType.Int16)
    '        db_bd.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Int32)
    '        'Variables de salidas 
    '        db_bd.AsignarParametro("cur_list_guia_tran", OracleClient.OracleType.Cursor)
    '        'Desconectar 
    '        db_bd.Desconectar()
    '        ldt_tmp = db_bd.EjecutarDataTable
    '        '
    '        dv = ldt_tmp.DefaultView
    '        '
    '        Return dv
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    End Try
    'End Function
    'Public Function sp_list_guia_transpor_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_list_guia_transpor", 14, _
    '    IDUNIDAD_AGENCIA, 1, _
    '    IDUNIDAD_AGENCIA_DESTINO, 1, _
    '    FECHA_INICIAL, 2, _
    '    FECHA_FINAL, 2, _
    '    nro_unidad_transporte, 1, _
    '    IDTIPO_SERVICIO, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function
    'Public Function sp_list_guia_transpor_deta_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    'Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_list_guia_transpor_deta", 4, _
    '    'Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_list_guia_transpor_deta_i", 6, _
    '    'Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_list_guia_transpor_deta_2", 6, _
    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_list_guia_transpor_deta_3", 10, _
    '    CType(IDGUIA_TRANSPORTISTA, String), 2, _
    '    factura_guia_transportista, 1, _
    '    consulta_por, 1, _
    '    entregado_a, 1}
    '    '
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function sp_list_guia_transpor_deta() As DataView
    '    Try
    '        Dim db_bd As New BaseDatos
    '        Dim ldt_tmp As New DataTable
    '        Dim dv As New DataView
    '        '
    '        'conecta con la Bd
    '        db_bd.Conectar()
    '        ' Invocando  al procedimiento almacenado 
    '        'hlamas 12-11-2010
    '        'db_bd.CrearComando("pkg_ivobultos.sp_list_guia_transpor_deta_3", CommandType.StoredProcedure)
    '        db_bd.CrearComando("pkg_ivobultos.sp_list_guia_transpor_deta_4", CommandType.StoredProcedure)
    '        'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
    '        db_bd.AsignarParametro("p_idguia_transportista", CType(IDGUIA_TRANSPORTISTA, String), OracleClient.OracleType.VarChar)
    '        db_bd.AsignarParametro("p_facturado", factura_guia_transportista, OracleClient.OracleType.Int16)
    '        db_bd.AsignarParametro("p_por_documento", consulta_por, OracleClient.OracleType.Int16)
    '        db_bd.AsignarParametro("p_por_entrega", entregado_a, OracleClient.OracleType.Int16)
    '        db_bd.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Int32)
    '        'Variables de salidas 
    '        db_bd.AsignarParametro("cur_list_guia_transpor_deta", OracleClient.OracleType.Cursor)
    '        'Desconectar 
    '        db_bd.Desconectar()
    '        ldt_tmp = db_bd.EjecutarDataTable
    '        '
    '        dv = ldt_tmp.DefaultView
    '        '
    '        Return dv
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    End Try
    'End Function
    'Function sp_l_guias_despachadas__no_usado_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView -- 12/10/2009
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "pkg_ivoconsultas_tranportista.sp_l_guias_despachadas"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_REGISTRO", OracleClient.OracleType.Number)).Value = IDESTADO_REGISTRO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDESTADO_ENVIO", OracleClient.OracleType.Number)).Value = IDESTADO_ENVIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INICIAL", OracleClient.OracleType.VarChar)).Value = FECHA_INICIAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDPERSONA", OracleClient.OracleType.Number)).Value = IDPERSONA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_l_guias_despachadas", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '    Dim ds As New DataSet
    '    daora.Fill(ds)


    '    Dim dv As New DataView

    '    dv = ds.Tables(0).DefaultView

    '    Return dv

    '    Try
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function sp_list_guia_trans_deta_agru_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_list_guia_trans_deta_agru", 14, _
    '    IDAGENCIAS, 1, _
    '    IDAGENCIAS_DESTINO, 1, _
    '    FECHA_INICIAL, 2, _
    '    FECHA_FINAL, 2, _
    '    nro_unidad_transporte, 1, _
    '    IDTIPO_SERVICIO, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function
    '
    'Public Function sp_list_guia_transporAgru_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_list_guia_transporAgru", 14, _
    '    IDAGENCIAS, 1, _
    '    IDAGENCIAS_DESTINO, 1, _
    '    FECHA_INICIAL, 2, _
    '    FECHA_FINAL, 2, _
    '    nro_unidad_transporte, 1, _
    '    IDTIPO_SERVICIO, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function sp_get_guia_transportista_i_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    '
    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_get_guia_transportista_i", 8, _
    '       s_SERIE_GUIA_TRANSPORTISTA, 2, _
    '       s_NRO_GUIA_TRANSPORTISTA, 2, _
    '       factura_guia_transportista, 1}
    '    '
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    '
    '    DA.Fill(dT, Rst)
    '    '
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_get_guia_transportista_i() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_get_guia_transportista_i", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_serie_trans", s_SERIE_GUIA_TRANSPORTISTA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_nro_trans", s_NRO_GUIA_TRANSPORTISTA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idestado_facturado", factura_guia_transportista, OracleClient.OracleType.Int16)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_list_guia_transpor_deta", OracleClient.OracleType.Cursor)
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
    'Function SP_IDA_RETORNO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_REP_GUIAS_ENVIO.SP_IDA_RETORNO"


    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INICIAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_TIPO_GUIA", OracleClient.OracleType.VarChar)).Value = TIPO_GUIA
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_SERVICIO", OracleClient.OracleType.Number)).Value = IDTIPO_SERVICIO
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDA_RETORNO", OracleClient.OracleType.VarChar)).Value = IDA_RETORNO

    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_IDA_RETORNO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output


    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '    Dim ds As New DataSet
    '    daora.Fill(ds)


    '    Dim dv As New DataView

    '    dv = ds.Tables(0).DefaultView

    '    Return dv

    '    Try
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Function SP_IDA_RETORNO() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_REP_GUIAS_ENVIO.SP_IDA_RETORNO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("P_FECHA_INI", FECHA_INICIAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_TIPO_GUIA", TIPO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDTIPO_SERVICIO", IDTIPO_SERVICIO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("P_IDA_RETORNO", IDA_RETORNO, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_IDA_RETORNO", OracleClient.OracleType.Cursor)
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
    'Public Function sp_list_guia_transporIV_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    ' Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_list_guia_transporII", 16, _
    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_list_guia_transporIV", 22, _
    '    TIPO_GUIA, 2, _
    '    IDUNIDAD_AGENCIA, 1, _
    '    IDUNIDAD_AGENCIA_DESTINO, 1, _
    '    FECHA_INICIAL, 2, _
    '    FECHA_FINAL, 2, _
    '    nro_unidad_transporte, 1, _
    '    IDTIPO_SERVICIO, 1, _
    '    factura_guia_transportista, 1, _
    '    IDAGENCIAS, 1, _
    '    IDAGENCIAS_DESTINO, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_list_guia_transporIV() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_list_guia_transporIV", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_tipo_guia", TIPO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idunidad_agencia", IDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inIcial", FECHA_INICIAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_nro_unidad_transporte", nro_unidad_transporte, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idtipo_servicio", IDTIPO_SERVICIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idestado_facturado", factura_guia_transportista, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idagencias_destino", IDAGENCIAS_DESTINO, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_list_guia_tran", OracleClient.OracleType.Cursor)
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

    Public Function sp_list_guia_transporII() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            'db_bd.CrearComando("pkg_ivobultos.sp_list_guia_transpor5", CommandType.StoredProcedure)
            'db_bd.CrearComando("pkg_ivobultos.sp_list_guia_transpor7", CommandType.StoredProcedure)
            db_bd.CrearComando("pkg_ivobultos.sp_list_guia_transpor8", CommandType.StoredProcedure)

            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_tipo_guia", TIPO_GUIA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idunidad_agencia", IDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia_destino", IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_fecha_inIcial", FECHA_INICIAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_nro_unidad_transporte", nro_unidad_transporte, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idtipo_servicio", IDTIPO_SERVICIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idestado_facturado", factura_guia_transportista, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_consulta", consulta_por, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("p_entrega_en", entregado_a, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idFuncionario", IDFUNCIONARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("P_idProducto", IDPRODUCTO, OracleClient.OracleType.Int32) 'axl
            db_bd.AsignarParametro("ni_TipoComprobante", TipoComprobante, OracleClient.OracleType.Int32)

            'Variables de salidas 
            db_bd.AsignarParametro("cur_list_guia_tran", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable
            '
            For Each row As DataRow In ldt_tmp.Rows
                row("monto_impuesto") = row("sub_total") * 0.18
                row("total_costo") = row("sub_total") * 1.18
            Next
            '
            dv = ldt_tmp.DefaultView
            '
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function sp_list_guia_transpor_deta() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            'hlamas 12-11-2010
            'db_bd.CrearComando("pkg_ivobultos.sp_list_guia_transpor_deta_3", CommandType.StoredProcedure)
            'db_bd.CrearComando("pkg_ivobultos.sp_list_guia_transpor_deta_5", CommandType.StoredProcedure)
            db_bd.CrearComando("pkg_ivobultos.sp_list_guia_transpor_deta_6", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_idguia_transportista", CType(IDGUIA_TRANSPORTISTA, String), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_facturado", factura_guia_transportista, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("p_por_documento", consulta_por, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("p_por_entrega", entregado_a, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("p_idpersona", IDPERSONA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idFuncionario", IDFUNCIONARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idproducto", IDPRODUCTO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_TipoComprobante", TipoComprobante, OracleClient.OracleType.Int32)

            'Variables de salidas 
            db_bd.AsignarParametro("cur_list_guia_transpor_deta", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable
            '
            For Each row As DataRow In ldt_tmp.Rows
                row("monto_impuesto") = row("sub_total") * 0.18
                row("total_costo") = row("sub_total") * 1.18
            Next
            '
            dv = ldt_tmp.DefaultView

            '
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

End Class