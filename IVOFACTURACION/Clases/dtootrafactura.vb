Imports AccesoDatos
Public Class dto_otras_facturas
#Region "Recordset"
    'Public rst_usuarios As New ADODB.Recordset
    Public rst_usuarios As New DataTable
    'Public rst_tipo_factura As New ADODB.Recordset
    Public rst_tipo_factura As New DataTable
    'Public rst_forma_pago As New ADODB.Recordset
    Public rst_forma_pago As New DataTable
    'Public rst_moneda As New ADODB.Recordset
    Public rst_moneda As New DataTable
    'Public rst_rubro As New ADODB.Recordset
    Public rst_rubro As New DataTable

    'Public rst_verifica_factura As New ADODB.Recordset
    Public rst_verifica_factura As New DataTable

    'Public rst_Lista_Personas As New ADODB.Recordset
    Public rst_Lista_Personas As DataTable

    'Public rst_msj_grabar As New ADODB.Recordset
    Public rst_msj_grabar As DataTable

    'Public rst_busqueda_otrafactura As New ADODB.Recordset
    Public rst_busqueda_otrafactura As DataTable

    'Public rst_busca_direccion_clte As New ADODB.Recordset
    Public rst_busca_direccion_clte As DataTable

    'Public rst_edita_otra_factura As New ADODB.Recordset
    Public rst_edita_otra_factura As DataTable

    'Public rst_anula_otra_factura As New ADODB.Recordset
    Public rst_anula_otra_factura As DataTable
#End Region
#Region "Variables"
    ' Busqueda 
    Public sfecha_inicio As String
    Public sfecha_final As String
    ' Grabar 
    Public icontrol As Integer
    Public sidfactura_otro As String
    Public motivo As String
    Public sidpersona As String
    Public iidtipo_comprobante As Integer
    Public sserie_factura As String
    Public snro_factura As String
    Public sfecha_factura As String
    Public iidforma_pago As Integer
    Public dmonto_subtotal As Double
    Public dmonto_impuesto As Double
    Public dtotal_costo As Double
    Public iidtipo_moneda As Integer
    Public iidestado_factura_otro As Integer
    Public dmonto_tipo_cambio As Double
    Public iidagencias As Integer
    Public lidusuario_personal As Long
    Public sip As String
    Public lidrol As Long
    Public lidproceso As Long
    Public sglosa As String
    Public digv As Double
    Public lcantidad As Long
    Public dprecio_unitario As Double
    Public TipoComprobante As Integer
    'Busca dirección clientes 
    Public liddireccion_consignado As Long
    Public sdireccion_cliente As String
    Public lidpais As Long
    Public liddepartamento As Long
    Public glosa02 As String
    Public lidprovincia As Long
    Public liddistrito As Long
    ' Mensaje 
    Public lcod_mensaje As Long
    Public smensaje As String
    Public memo As String
    Public direccion_facturacion As Integer
    Public tipo_afectacion As Integer
#End Region
#Region "Procedimientos y Funciones"
    Public Function fnLISTA_PERSONAS2009() As Boolean
        'Dim flat As Boolean = False
        'Try
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTUACION_OTROS.SP_LISTA_PERSONAS", 2}
        '    rst_Lista_Personas = Nothing
        '    rst_Lista_Personas = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    flat = True
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function
    Public Function fnLISTA_PERSONAS() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTUACION_OTROS.SP_LISTA_PERSONAS", CommandType.StoredProcedure)
            db.AsignarParametro("cur_Lista_Personas", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_Lista_Personas = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Function fn_grabar() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTUACION_OTROS.sp_act_otra_factura", 48, _
    '                                                                             icontrol, 1, _
    '                                                                             sidfactura_otro, 2, _
    '                                                                             sidpersona, 2, _
    '                                                                             iidtipo_comprobante, 1, _
    '                                                                             sserie_factura, 2, _
    '                                                                             snro_factura, 2, _
    '                                                                             sfecha_factura, 2, _
    '                                                                             iidforma_pago, 1, _
    '                                                                             dmonto_subtotal, 3, _
    '                                                                             dmonto_impuesto, 3, _
    '                                                                             dtotal_costo, 3, _
    '                                                                             iidtipo_moneda, 1, _
    '                                                                             iidestado_factura_otro, 1, _
    '                                                                             dmonto_tipo_cambio, 3, _
    '                                                                             iidagencias, 1, _
    '                                                                             lidusuario_personal, 1, _
    '                                                                             sip, 2, _
    '                                                                             lidrol, 1, _
    '                                                                             lidproceso, 1, _
    '                                                                             sglosa, 2, _
    '                                                                             digv, 3, _
    '                                                                             lcantidad, 1, _
    '                                                                             dprecio_unitario, 3}
    '        rst_msj_grabar = Nothing
    '        rst_msj_grabar = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst_msj_grabar.State = 1 Then
    '            lcod_mensaje = CType(rst_msj_grabar.Fields.Item("codmsj").Value, Long)
    '            smensaje = CType(rst_msj_grabar.Fields.Item("mensaje").Value, String)
    '        End If
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    'Public Function fnLISTA_INICIAL_otro_factura2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOFACTUACION_OTROS.sp_load_otrafactura", 2}
    '        rst_usuarios = Nothing
    '        rst_tipo_factura = Nothing
    '        rst_forma_pago = Nothing
    '        rst_moneda = Nothing
    '        rst_rubro = Nothing
    '        '
    '        rst_usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        'If rst_usuarios.EOF = False And rst_usuarios.BOF = False Then
    '        'rst_tipo_factura = rst_usuarios.NextRecordset
    '        'rst_forma_pago = rst_usuarios.NextRecordset
    '        'rst_moneda = rst_usuarios.NextRecordset
    '        'rst_rubro = rst_usuarios.NextRecordset
    '        'End If
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    Public Function fnLISTA_INICIAL_otro_factura() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'acceso 21/04/2010
            'db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_load_otrafactura", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_load_otrafactura_1", CommandType.StoredProcedure)
            db.AsignarParametro("ocur_usuario", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_tipo_factura", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_forma_pago", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_moneda", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_rubro", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_usuarios = ds.Tables(0)
            If rst_usuarios.Rows.Count > 0 Then
                rst_tipo_factura = ds.Tables(1)
                rst_forma_pago = ds.Tables(2)
                rst_moneda = ds.Tables(3)
                rst_rubro = ds.Tables(4)
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_verifica_factura2009()
        Dim flat As Boolean = False
        Try
            Dim varSP_OBJECT() As Object = {"PKG_IVOFACTUACION_OTROS.sp_verifica_factura", 6, _
                                                                     sserie_factura, 2, _
                                                                     snro_factura, 2}
            'rst_verifica_factura = Nothing
            'rst_verifica_factura = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
            flat = True
        Catch ex As Exception
            flat = False
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function

    Public Function fn_verifica_factura() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_verifica_factura", CommandType.StoredProcedure)
            db.AsignarParametro("vserie_factura", sserie_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_factura", snro_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_factura", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_verifica_factura = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        'Dim flat As Boolean = False
        'Try
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTUACION_OTROS.sp_verifica_factura", 6, _
        '                                                             sserie_factura, 2, _
        '                                                             snro_factura, 2}
        '    rst_verifica_factura = Nothing
        '    rst_verifica_factura = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    flat = True
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function

    Function fn_grabar2009() As Boolean
        'Dim flat As Boolean = False
        'Dim valor As DBNull
        'Try
        '    'Dim varSP_OBJECT() As Object = {"PKG_IVOFACTUACION_OTROS.sp_act_otra_factura4", 54, _
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTUACION_OTROS.sp_act_otra_factura4", 54, _
        '                                                                         icontrol, 1, _
        '                                                                         sidfactura_otro, 2, _
        '                                                                         sidpersona, 2, _
        '                                                                         iidtipo_comprobante, 1, _
        '                                                                         sserie_factura, 2, _
        '                                                                         snro_factura, 2, _
        '                                                                         sfecha_factura, 2, _
        '                                                                         iidforma_pago, 1, _
        '                                                                         dmonto_subtotal, 3, _
        '                                                                         dmonto_impuesto, 3, _
        '                                                                         dtotal_costo, 3, _
        '                                                                         iidtipo_moneda, 1, _
        '                                                                         iidestado_factura_otro, 1, _
        '                                                                         dmonto_tipo_cambio, 3, _
        '                                                                         iidagencias, 1, _
        '                                                                         lidusuario_personal, 1, _
        '                                                                         sip, 2, _
        '                                                                         lidrol, 1, _
        '                                                                         lidproceso, 1, _
        '                                                                         IIf(sglosa = "", "NULL", sglosa), 2, _
        '                                                                         digv, 3, _
        '                                                                         lcantidad, 1, _
        '                                                                         dprecio_unitario, 3, _
        '                                                                         IIf(memo = "", "NULL", memo), 2, _
        '                                                                         glosa02, 2, _
        '                                                                         direccion_facturacion.ToString, 2}

        '    'Dim varSP_OBJECT() As Object = {"PKG_IVOFACTUACION_OTROS.sp_act_otra_facturaIII", 52, _
        '    '                                                                     icontrol, 1, _
        '    '                                                                     sidfactura_otro, 2, _
        '    '                                                                     sidpersona, 2, _
        '    '                                                                     iidtipo_comprobante, 1, _
        '    '                                                                     sserie_factura, 2, _
        '    '                                                                     snro_factura, 2, _
        '    '                                                                     sfecha_factura, 2, _
        '    '                                                                     iidforma_pago, 1, _
        '    '                                                                     dmonto_subtotal, 3, _
        '    '                                                                     dmonto_impuesto, 3, _
        '    '                                                                     dtotal_costo, 3, _
        '    '                                                                     iidtipo_moneda, 1, _
        '    '                                                                     iidestado_factura_otro, 1, _
        '    '                                                                     dmonto_tipo_cambio, 3, _
        '    '                                                                     iidagencias, 1, _
        '    '                                                                     lidusuario_personal, 1, _
        '    '                                                                     sip, 2, _
        '    '                                                                     lidrol, 1, _
        '    '                                                                     lidproceso, 1, _
        '    '                                                                     sglosa, 2, _
        '    '                                                                     digv, 3, _
        '    '                                                                     lcantidad, 1, _
        '    '                                                                     dprecio_unitario, 3, _
        '    '                                                                     IIf(memo = "", "NULL", memo), 2, _
        '    '                                                                     glosa02, 2}
        '    rst_msj_grabar = Nothing
        '    rst_msj_grabar = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    If rst_msj_grabar.State = 1 Then
        '        lcod_mensaje = CType(rst_msj_grabar.Fields.Item("codmsj").Value, Long)
        '        smensaje = CType(rst_msj_grabar.Fields.Item("mensaje").Value, String)
        '    End If
        '    flat = True
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function

    Function fn_grabar() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 15-04-2016
            'db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_act_otra_factura4", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_grabar_factura", CommandType.StoredProcedure)
            db.AsignarParametro("ncontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vidfactura_otro", sidfactura_otro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vidpersona", sidpersona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidtipo_comprobante", iidtipo_comprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("vserie_factura", sserie_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_factura", snro_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_factura", sfecha_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidforma_pago", iidforma_pago, OracleClient.OracleType.Int32)
            db.AsignarParametro("nmonto_subtotal", dmonto_subtotal, OracleClient.OracleType.Number)
            db.AsignarParametro("nmonto_impuesto", dmonto_impuesto, OracleClient.OracleType.Number)
            db.AsignarParametro("ntotal_costo", dtotal_costo, OracleClient.OracleType.Number)
            db.AsignarParametro("nidtipo_moneda", iidtipo_moneda, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidestado_factura_otro", iidestado_factura_otro, OracleClient.OracleType.Int32)
            db.AsignarParametro("nmonto_tipo_cambio", dmonto_tipo_cambio, OracleClient.OracleType.Number)
            db.AsignarParametro("nidagencias", iidagencias, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidusuario_personal", lidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("vip", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidrol", lidrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidproceso", lidproceso, OracleClient.OracleType.Int32)
            db.AsignarParametro("vglosa", IIf(sglosa = "", "NULL", sglosa), OracleClient.OracleType.VarChar)
            db.AsignarParametro("nigv", digv, OracleClient.OracleType.Number)
            db.AsignarParametro("ncantidad", lcantidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("nprecio_unitario", dprecio_unitario, OracleClient.OracleType.Number)
            db.AsignarParametro("p_memo", IIf(memo = "", "NULL", memo), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_glosa02", glosa02, OracleClient.OracleType.VarChar)
            db.AsignarParametro("direccion_facturacion", direccion_facturacion.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo_afectacion", tipo_afectacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_msj_grabar = db.EjecutarDataTable
            If rst_msj_grabar.Rows.Count > 0 Then
                lcod_mensaje = CType(rst_msj_grabar.Rows(0).Item("codmsj"), Long)
                smensaje = CType(rst_msj_grabar.Rows(0).Item("mensaje"), String)
                Return True
            Else
                lcod_mensaje = 0
                smensaje = ""
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function fnbusqueda_otrafactura2009() As Boolean
        'Dim flat As Boolean = False
        'Try
        '    '
        '    rst_busqueda_otrafactura = Nothing
        '    '
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTUACION_OTROS.sp_get_otrafactura", 14, _
        '                                                          icontrol, 1, _
        '                                                          sfecha_inicio, 2, _
        '                                                          sfecha_final, 2, _
        '                                                          sserie_factura, 2, _
        '                                                          snro_factura, 2, _
        '                                                          lidusuario_personal, 1}
        '    rst_busqueda_otrafactura = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    '
        '    flat = True
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function

    Function fnbusqueda_otrafactura() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_get_otrafactura", CommandType.StoredProcedure)
            db.AsignarParametro("nicontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vfecha_inicial", sfecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_final", sfecha_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_serie", sserie_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_nro_factura", snro_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidusuario", lidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", TipoComprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_otrafactura", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_busqueda_otrafactura = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function fnbusqueda_direccion_cliente2009() As Boolean
        'Dim flat As Boolean = False
        'Try
        '    '
        '    rst_busca_direccion_clte = Nothing
        '    '
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTUACION_OTROS.sp_get_direccion_legal", 4, _
        '                                                          sidpersona, 2}
        '    '
        '    rst_busca_direccion_clte = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    '-- 
        '    liddireccion_consignado = -666
        '    sdireccion_cliente = "null"
        '    lidpais = -666
        '    liddepartamento = -666
        '    lidprovincia = -666
        '    liddistrito = -666
        '    '--
        '    If rst_busca_direccion_clte.BOF = True And rst_busca_direccion_clte.EOF = True Then
        '        flat = False
        '        Return flat
        '    End If
        '    If rst_busca_direccion_clte.State = 1 Then
        '        If IsDBNull(rst_busca_direccion_clte.Fields.Item("iddireccion_consignado").Value) = False Then
        '            liddireccion_consignado = CType(rst_busca_direccion_clte.Fields.Item("iddireccion_consignado").Value, Long)
        '        End If
        '        If IsDBNull(rst_busca_direccion_clte.Fields.Item("direccion").Value) = False Then
        '            sdireccion_cliente = CType(rst_busca_direccion_clte.Fields.Item("direccion").Value, String)
        '        End If
        '        If IsDBNull(rst_busca_direccion_clte.Fields.Item("idpais").Value) = False Then
        '            lidpais = CType(rst_busca_direccion_clte.Fields.Item("idpais").Value, Long)
        '        End If
        '        If IsDBNull(rst_busca_direccion_clte.Fields.Item("iddepartamento").Value) = False Then
        '            liddepartamento = CType(rst_busca_direccion_clte.Fields.Item("iddepartamento").Value, Long)
        '        End If
        '        If IsDBNull(rst_busca_direccion_clte.Fields.Item("idprovincia").Value) = False Then
        '            lidprovincia = CType(rst_busca_direccion_clte.Fields.Item("idprovincia").Value, Long)
        '        End If
        '        If IsDBNull(rst_busca_direccion_clte.Fields.Item("iddistrito").Value) = False Then
        '            liddistrito = CType(rst_busca_direccion_clte.Fields.Item("iddistrito").Value, Long)
        '        End If
        '    End If
        '    flat = True
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function

    Function fnbusqueda_direccion_cliente() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_get_direccion_legal", CommandType.StoredProcedure)
            db.AsignarParametro("vidpersona", sidpersona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_direccion", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_busca_direccion_clte = db.EjecutarDataTable
            liddireccion_consignado = -666
            sdireccion_cliente = "null"
            lidpais = -666
            liddepartamento = -666
            lidprovincia = -666
            liddistrito = -666

            If rst_busca_direccion_clte.Rows.Count > 0 Then
                If IsDBNull(rst_busca_direccion_clte.Rows(0).Item("iddireccion_consignado")) = False Then
                    liddireccion_consignado = CType(rst_busca_direccion_clte.Rows(0).Item("iddireccion_consignado"), Long)
                End If
                If IsDBNull(rst_busca_direccion_clte.Rows(0).Item("direccion")) = False Then
                    sdireccion_cliente = CType(rst_busca_direccion_clte.Rows(0).Item("direccion"), String)
                End If
                If IsDBNull(rst_busca_direccion_clte.Rows(0).Item("idpais")) = False Then
                    lidpais = CType(rst_busca_direccion_clte.Rows(0).Item("idpais"), Long)
                End If
                If IsDBNull(rst_busca_direccion_clte.Rows(0).Item("iddepartamento")) = False Then
                    liddepartamento = CType(rst_busca_direccion_clte.Rows(0).Item("iddepartamento"), Long)
                End If
                If IsDBNull(rst_busca_direccion_clte.Rows(0).Item("idprovincia")) = False Then
                    lidprovincia = CType(rst_busca_direccion_clte.Rows(0).Item("idprovincia"), Long)
                End If
                If IsDBNull(rst_busca_direccion_clte.Rows(0).Item("iddistrito")) = False Then
                    liddistrito = CType(rst_busca_direccion_clte.Rows(0).Item("iddistrito"), Long)
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function fn_edita_otra_factura2009()
        'Dim flat As Boolean = False
        'Try
        '    'hlamas
        '    'Dim varSP_OBJECT() As Object = {"PKG_IVOFACTUACION_OTROS.sp_editar_otrafactura", 4, _
        '    'sidfactura_otro, 2}
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTUACION_OTROS.sp_editar_otrafactura", 4, _
        '                                                             sidfactura_otro, 2}
        '    rst_edita_otra_factura = Nothing
        '    rst_edita_otra_factura = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    flat = True
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function

    Public Function fn_edita_otra_factura() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_editar_otrafactura", CommandType.StoredProcedure)
            db.AsignarParametro("vidfactura_otro", sidfactura_otro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_factura_otro", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_edita_otra_factura = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_anula_otra_factura2009()
        'Dim flat As Boolean = False
        'Try
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOFACTUACION_OTROS.sp_anula_otrafactura", 8, _
        '                                                                 sidfactura_otro, 2, _
        '                                                                 lidusuario_personal, 1, _
        '                                                                 sip, 2}
        '    rst_anula_otra_factura = Nothing
        '    rst_anula_otra_factura = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    flat = True
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function

    Public Function fn_anula_otra_factura() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_anula_otrafactura", CommandType.StoredProcedure)
            db.AsignarParametro("vidfactura_otro", sidfactura_otro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_motivo", motivo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidusuario_anulacion", lidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("vip", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_anula_otra_factura = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

#End Region
End Class