Imports AccesoDatos
Public Class dtorefacturacion
#Region "Record Set"
    'Public rst_usuarios As New ADODB.Recordset
    Public rst_usuarios As New DataTable
    'Public rst_refactura As New ADODB.Recordset
    Public rst_refactura As New DataTable
    'Private rst_verifica_comp As New ADODB.Recordset
    Private rst_verifica_comp As New DataTable
    'Private rst_valida_factura As New ADODB.Recordset
    Private rst_valida_factura As New DataTable

    'Private rst_graba_refacturacion As New ADODB.Recordset
    Private rst_graba_refacturacion As DataTable

    'Public rst_busqueda_refacturacion As New ADODB.Recordset
    Public rst_busqueda_refacturacion As New DataTable
#End Region
#Region "Variables"
    Public s_mensaje As String
    Public s_cod_mensaje As Long
    Public l_control As Long
    '
    Public sserie_factura As String
    Public snro_factura As String
    Public sserie_nota_cred As String
    Public snro_nota_cred As String
    '
    Public sidfactura As String
    Public sfecha_factura As String
    Public sfecha_nota_credito As String
    Public dsubtotal As Double
    Public dimpuesto As Double
    Public dtotal_costo As Double
    Public srazon_social As String
    Public stipoDcoumentoIdentidad As Integer
    Public sruc As String
    Public iesrefacturado As Integer
    Public iesfactura As Integer
    Public emite_nc As Integer
    Public direccion As String
    Public moneda As Integer
    '
    Public imes_factura As Integer
    Public imes_sistema As Integer
    Public lidusuario_personal As Long
    Public sip As String
    Public iidrol As Long
    '
    Public sfecha_inicio As String
    Public sfecha_final As String
    '15/04/2008 
    Public smemo_nota_credito As String
    Public smonto_impuesto_nota_cred As Double
    Public ses_refactura As Long
    Public stotal_costo_nota_cred As Double
    Public intTipoComprobante As Integer
    Public intAgencia As Integer

    Public afectacion As Integer
    '
#End Region
#Region "Procedimiento y Funciones"

    'Reemplazado el 14/04/2008 
    'Function fnbusqueda_refactura() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        rst_busqueda_refacturacion = Nothing
    '        '
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOREFACTURACION.sp_get_refactura", 14, _
    '                                                              l_control, 1, _
    '                                                              lidusuario_personal, 1, _
    '                                                              sfecha_inicio, 2, _
    '                                                              sfecha_final, 2, _
    '                                                              sserie_factura, 2, _
    '                                                              snro_factura, 2}
    '        rst_busqueda_refacturacion = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        '
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    'Public Function fnLISTA_INICIAL_refacturacion2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOREFACTURACION.sp_lista_refactura", 2}
    '        rst_usuarios = Nothing
    '        rst_usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        'If rst_usuarios.EOF = False And rst_usuarios.BOF = False Then
    '        'rst_refactura = rst_usuarios.NextRecordset
    '        'End If
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    Public Function fnLISTA_INICIAL_refacturacion() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'acceso 21/04/2010
            'db.CrearComando("PKG_IVOREFACTURACION.sp_lista_refactura", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOREFACTURACION.sp_lista_refactura_1", CommandType.StoredProcedure)
            db.AsignarParametro("ocur_Lista_Usuarios", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_refactura", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_usuarios = ds.Tables(0)
            If rst_usuarios.Rows.Count > 0 Then
                rst_refactura = ds.Tables(1)
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnLISTA_verifica_dcto2009(ByVal lcontrol As Long) As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        rst_verifica_comp = Nothing
    '        If lcontrol = 1 Then
    '            Dim varSP_OBJECT() As Object = {"PKG_IVOREFACTURACION.sp_verifica_nota_credito", 6, _
    '                                                                  sserie_factura, 2, _
    '                                                                  snro_factura, 2}
    '            rst_verifica_comp = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        Else
    '            Dim varSP_OBJECT() As Object = {"PKG_IVOREFACTURACION.sp_verifica_factura", 6, _
    '                                                                  sserie_factura, 2, _
    '                                                                  snro_factura, 2}
    '            rst_verifica_comp = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        End If
    '        '
    '        'If rst_verifica_comp.State = 1 Then
    '        's_cod_mensaje = CType(rst_verifica_comp.Fields.Item("codmsj").Value, Long)
    '        's_mensaje = CType(rst_verifica_comp.Fields.Item("mensaje").Value, String)
    '        'End If
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    Public Function fnLISTA_verifica_dcto(ByVal lcontrol As Long) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            If lcontrol = 1 Then
                db.CrearComando("PKG_IVOREFACTURACION.sp_verifica_nota_credito", CommandType.StoredProcedure)
            Else
                db.CrearComando("PKG_IVOREFACTURACION.sp_verifica_factura", CommandType.StoredProcedure)
            End If
            db.AsignarParametro("vserie_fact", sserie_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_fact", snro_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_verifica_comp = db.EjecutarDataTable
            s_cod_mensaje = CType(rst_verifica_comp.Rows(0).Item("codmsj").ToString, Long)
            s_mensaje = CType(rst_verifica_comp.Rows(0).Item("mensaje").ToString, String)
            Return True

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        'Dim flat As Boolean = False
        'Try
        '    rst_verifica_comp = Nothing
        '    If lcontrol = 1 Then
        '        Dim varSP_OBJECT() As Object = {"PKG_IVOREFACTURACION.sp_verifica_nota_credito", 6, _
        '                                                              sserie_factura, 2, _
        '                                                              snro_factura, 2}
        '        rst_verifica_comp = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    Else
        '        Dim varSP_OBJECT() As Object = {"PKG_IVOREFACTURACION.sp_verifica_factura", 6, _
        '                                                              sserie_factura, 2, _
        '                                                              snro_factura, 2}
        '        rst_verifica_comp = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    End If
        '    '
        '    If rst_verifica_comp.State = 1 Then
        '        s_cod_mensaje = CType(rst_verifica_comp.Fields.Item("codmsj").Value, Long)
        '        s_mensaje = CType(rst_verifica_comp.Fields.Item("mensaje").Value, String)
        '    End If
        '    flat = True
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function
    'Public Function fnverifica_factura_actual2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        rst_valida_factura = Nothing

    '        Dim varSP_OBJECT() As Object = {"PKG_IVOREFACTURACION.sp_verifica_fact_act", 6, _
    '                                                              sserie_factura, 2, _
    '                                                              snro_factura, 2}
    '        rst_valida_factura = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        '
    '        'If rst_valida_factura.State = 1 Then
    '        '    If rst_valida_factura.EOF = False And rst_valida_factura.BOF = False Then
    '        '        sidfactura = CType(rst_valida_factura.Fields.Item("idfactura").Value, String)
    '        '        sfecha_factura = CType(rst_valida_factura.Fields.Item("fecha").Value, String)
    '        '        dsubtotal = CType(rst_valida_factura.Fields.Item("subtotal").Value, Double)
    '        '        dimpuesto = CType(rst_valida_factura.Fields.Item("impuesto").Value, Double)
    '        '        dtotal_costo = CType(rst_valida_factura.Fields.Item("total_costo").Value, Double)
    '        '        srazon_social = CType(rst_valida_factura.Fields.Item("razon_social").Value, String)
    '        '        sruc = CType(rst_valida_factura.Fields.Item("nu_docu_suna").Value, String)
    '        '        iesrefacturado = CType(rst_valida_factura.Fields.Item("refacturado").Value, Integer)
    '        '        imes_factura = CType(rst_valida_factura.Fields.Item("mes_factura").Value, Integer)
    '        '        imes_sistema = CType(rst_valida_factura.Fields.Item("mes_actual").Value, Integer)
    '        '        flat = True
    '        '    Else
    '        '        flat = False
    '        '    End If
    '        'End If
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    Public Function fnverifica_factura_actual(tipo As Integer) As Boolean
        Dim db As New BaseDatos
        db.Conectar()
        db.CrearComando("PKG_IVOREFACTURACION.sp_verifica_fact_act", CommandType.StoredProcedure)
        db.AsignarParametro("vserie", sserie_factura, OracleClient.OracleType.VarChar)
        db.AsignarParametro("vnrofactura", snro_factura, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
        db.AsignarParametro("ocur_factura", OracleClient.OracleType.Cursor)
        db.Desconectar()
        rst_valida_factura = db.EjecutarDataTable
        If rst_valida_factura.Rows.Count > 0 Then
            sidfactura = CType(rst_valida_factura.Rows(0).Item("idfactura").ToString, String)
            sfecha_factura = CType(rst_valida_factura.Rows(0).Item("fecha").ToString, String)
            dsubtotal = CType(rst_valida_factura.Rows(0).Item("subtotal").ToString, Double)
            dimpuesto = CType(rst_valida_factura.Rows(0).Item("impuesto").ToString, Double)
            dtotal_costo = CType(rst_valida_factura.Rows(0).Item("total_costo").ToString, Double)
            srazon_social = CType(rst_valida_factura.Rows(0).Item("razon_social").ToString, String)
            sruc = CType(rst_valida_factura.Rows(0).Item("nu_docu_suna").ToString, String)
            iesrefacturado = CType(rst_valida_factura.Rows(0).Item("refacturado").ToString, Integer)
            imes_factura = CType(rst_valida_factura.Rows(0).Item("mes_factura").ToString, Integer)
            imes_sistema = CType(rst_valida_factura.Rows(0).Item("mes_actual").ToString, Integer)
            iesfactura = CType(rst_valida_factura.Rows(0).Item("idestado_factura").ToString, Integer)
            intTipoComprobante = CType(rst_valida_factura.Rows(0).Item("tipo").ToString, Integer)
            stipoDcoumentoIdentidad = CType(rst_valida_factura.Rows(0).Item("idtipo_doc_identidad").ToString, Integer)
            emite_nc = CType(rst_valida_factura.Rows(0).Item("emite_nc").ToString, Integer)
            direccion = rst_valida_factura.Rows(0).Item("direccion").ToString
            moneda = CType(rst_valida_factura.Rows(0).Item("moneda").ToString, Integer)
            afectacion = CType(rst_valida_factura.Rows(0).Item("afectacion").ToString, Integer)
            Return True
        Else
            Return False
        End If

        'Dim flat As Boolean = False
        'Try
        '    rst_valida_factura = Nothing

        '    Dim varSP_OBJECT() As Object = {"PKG_IVOREFACTURACION.sp_verifica_fact_act", 6, _
        '                                                          sserie_factura, 2, _
        '                                                          snro_factura, 2}
        '    rst_valida_factura = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    '
        '    If rst_valida_factura.State = 1 Then
        '        If rst_valida_factura.EOF = False And rst_valida_factura.BOF = False Then
        '            sidfactura = CType(rst_valida_factura.Fields.Item("idfactura").Value, String)
        '            sfecha_factura = CType(rst_valida_factura.Fields.Item("fecha").Value, String)
        '            dsubtotal = CType(rst_valida_factura.Fields.Item("subtotal").Value, Double)
        '            dimpuesto = CType(rst_valida_factura.Fields.Item("impuesto").Value, Double)
        '            dtotal_costo = CType(rst_valida_factura.Fields.Item("total_costo").Value, Double)
        '            srazon_social = CType(rst_valida_factura.Fields.Item("razon_social").Value, String)
        '            sruc = CType(rst_valida_factura.Fields.Item("nu_docu_suna").Value, String)
        '            iesrefacturado = CType(rst_valida_factura.Fields.Item("refacturado").Value, Integer)
        '            imes_factura = CType(rst_valida_factura.Fields.Item("mes_factura").Value, Integer)
        '            imes_sistema = CType(rst_valida_factura.Fields.Item("mes_actual").Value, Integer)
        '            flat = True
        '        Else
        '            flat = False
        '        End If
        '    End If
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function

    Public Function fngraba_refacturacionII2009(ByVal cnn As OracleClient.OracleConnection) As Boolean
        Dim flat As Boolean = False
        'Try
        '    rst_graba_refacturacion = Nothing
        '    '            
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOREFACTURACION.sp_act_refacturacionII", 26, _
        '                                                          sidfactura, 2, _
        '                                                          sserie_nota_cred, 2, _
        '                                                          snro_nota_cred, 2, _
        '                                                          sserie_factura, 2, _
        '                                                          snro_factura, 2, _
        '                                                          sfecha_nota_credito, 2, _
        '                                                          sfecha_factura, 2, _
        '                                                          dimpuesto, 3, _
        '                                                          dtotal_costo, 3, _
        '                                                          lidusuario_personal, 1, _
        '                                                          sip, 2, _
        '                                                          iidrol, 1}
        '    rst_graba_refacturacion = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    '
        '    If rst_verifica_comp.State = 1 Then
        '        s_cod_mensaje = CType(rst_graba_refacturacion.Fields.Item("codmsj").Value, Long)
        '        s_mensaje = CType(rst_graba_refacturacion.Fields.Item("mensaje").Value, String)
        '    End If
        '    flat = True
        Try
            Dim cmd As New OracleClient.OracleCommand
            cmd.Connection = cnn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "PKG_IVOREFACTURACION.sp_act_refacturacionII"


            cmd.Parameters.Add(New OracleClient.OracleParameter("vidfactura", OracleClient.OracleType.VarChar)).Value = sidfactura
            cmd.Parameters.Add(New OracleClient.OracleParameter("vserie_notacred", OracleClient.OracleType.VarChar)).Value = sserie_nota_cred
            cmd.Parameters.Add(New OracleClient.OracleParameter("vnro_nota_cred", OracleClient.OracleType.VarChar)).Value = snro_nota_cred
            cmd.Parameters.Add(New OracleClient.OracleParameter("vfecha_nota_cred", OracleClient.OracleType.VarChar)).Value = sfecha_nota_credito
            cmd.Parameters.Add(New OracleClient.OracleParameter("vmemo_nora_cred", OracleClient.OracleType.VarChar)).Value = smemo_nota_credito
            cmd.Parameters.Add(New OracleClient.OracleParameter("vmonto_impuesto_nota_cred", OracleClient.OracleType.Number)).Value = smonto_impuesto_nota_cred
            cmd.Parameters.Add(New OracleClient.OracleParameter("vtotal_costo_nota_cred", OracleClient.OracleType.Number)).Value = stotal_costo_nota_cred

            cmd.Parameters.Add(New OracleClient.OracleParameter("vserie_facturanew", OracleClient.OracleType.VarChar)).Value = sserie_factura
            cmd.Parameters.Add(New OracleClient.OracleParameter("vnro_facturanew", OracleClient.OracleType.VarChar)).Value = snro_factura
            cmd.Parameters.Add(New OracleClient.OracleParameter("vfecha_fact_new", OracleClient.OracleType.VarChar)).Value = sfecha_factura
            cmd.Parameters.Add(New OracleClient.OracleParameter("nimpuesto", OracleClient.OracleType.Number)).Value = dimpuesto
            cmd.Parameters.Add(New OracleClient.OracleParameter("ntotal", OracleClient.OracleType.Number)).Value = dtotal_costo
            cmd.Parameters.Add(New OracleClient.OracleParameter("nidusuario_personal", OracleClient.OracleType.Number)).Value = lidusuario_personal
            cmd.Parameters.Add(New OracleClient.OracleParameter("vip", OracleClient.OracleType.VarChar)).Value = sip
            cmd.Parameters.Add(New OracleClient.OracleParameter("nidrol", OracleClient.OracleType.Number)).Value = iidrol
            cmd.Parameters.Add(New OracleClient.OracleParameter("ves_refactura", OracleClient.OracleType.Number)).Value = ses_refactura
            cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_mensaje", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

            Dim da As New OracleClient.OracleDataAdapter(cmd)

            Dim ds As New DataSet

            da.Fill(ds)
            s_cod_mensaje = ds.Tables(0).Rows(0)(0)
            s_mensaje = ds.Tables(0).Rows(0)(1)

            flat = True
        Catch ex As OracleClient.OracleException
            flat = False
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function

    Public Function GrabarNotaCredito(Optional opcion As Integer = 0, Optional operacion As Integer = 0) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOREFACTURACION.sp_nc_otros", CommandType.StoredProcedure)
            db.AsignarParametro("vidfactura", sidfactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vserie_notacred", sserie_nota_cred, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_nota_cred", snro_nota_cred, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_nota_cred", sfecha_nota_credito, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vmemo_nora_cred", smemo_nota_credito, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vmonto_impuesto_nota_cred", smonto_impuesto_nota_cred, OracleClient.OracleType.Number)
            db.AsignarParametro("vtotal_costo_nota_cred", stotal_costo_nota_cred, OracleClient.OracleType.Number)
            db.AsignarParametro("nidusuario_personal", lidusuario_personal, OracleClient.OracleType.Number)
            db.AsignarParametro("vip", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidrol", iidrol, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", intAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", 30, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)

            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            s_cod_mensaje = ds.Tables(1).Rows(0)(0)
            s_mensaje = ds.Tables(1).Rows(0)(1)
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function GrabarRefacturacionCredito(Optional opcion As Integer = 0, Optional operacion As Integer = 0) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOREFACTURACION.sp_refactura_credito", CommandType.StoredProcedure)
            db.AsignarParametro("vidfactura", sidfactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vserie_facturanew", sserie_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_facturanew", snro_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vmemo_nora_cred", smemo_nota_credito, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_fact_new", sfecha_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nimpuesto", dimpuesto, OracleClient.OracleType.Number)
            db.AsignarParametro("ntotal", dtotal_costo, OracleClient.OracleType.Number)
            db.AsignarParametro("nidusuario_personal", lidusuario_personal, OracleClient.OracleType.Number)
            db.AsignarParametro("vip", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidrol", iidrol, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", intAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", intTipoComprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)

            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            s_cod_mensaje = ds.Tables(1).Rows(0)(0)
            s_mensaje = ds.Tables(1).Rows(0)(1)
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function GrabarNC(Optional opcion As Integer = 0, Optional operacion As Integer = 0) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOREFACTURACION.sp_nc_credito", CommandType.StoredProcedure)
            db.AsignarParametro("vidfactura", sidfactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vserie_notacred", sserie_nota_cred, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_nota_cred", snro_nota_cred, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_nota_cred", sfecha_nota_credito, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vmemo_nora_cred", smemo_nota_credito, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vmonto_impuesto_nota_cred", smonto_impuesto_nota_cred, OracleClient.OracleType.Number)
            db.AsignarParametro("vtotal_costo_nota_cred", stotal_costo_nota_cred, OracleClient.OracleType.Number)
            db.AsignarParametro("nidusuario_personal", lidusuario_personal, OracleClient.OracleType.Number)
            db.AsignarParametro("vip", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidrol", iidrol, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", intAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", 30, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)

            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            s_cod_mensaje = ds.Tables(1).Rows(0)(0)
            s_mensaje = ds.Tables(1).Rows(0)(1)
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function GrabarRefacturacion(Optional opcion As Integer = 0, Optional operacion As Integer = 0) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOREFACTURACION.sp_refactura_otros", CommandType.StoredProcedure)
            db.AsignarParametro("vidfactura", sidfactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vserie_facturanew", sserie_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_facturanew", snro_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_fact_new", sfecha_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nimpuesto", dimpuesto, OracleClient.OracleType.Number)
            db.AsignarParametro("ntotal", dtotal_costo, OracleClient.OracleType.Number)
            db.AsignarParametro("vmemo_nora_cred", smemo_nota_credito, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidusuario_personal", lidusuario_personal, OracleClient.OracleType.Number)
            db.AsignarParametro("vip", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidrol", iidrol, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", intAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo", intTipoComprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)

            db.AsignarParametro("ocur_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            s_cod_mensaje = ds.Tables(1).Rows(0)(0)
            s_mensaje = ds.Tables(1).Rows(0)(1)
            Return ds.Tables(0)

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function


    Public Function fngraba_refacturacionII11(Optional opcion As Integer = 0, Optional operacion As Integer = 0) As Boolean
        'Public Function fngraba_refacturacionII11(Optional opcion As Integer = 0, Optional operacion As Integer = 0) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOREFACTURACION.sp_act_refacturacionII", CommandType.StoredProcedure)
            db.AsignarParametro("vidfactura", sidfactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vserie_notacred", sserie_nota_cred, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_nota_cred", snro_nota_cred, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_nota_cred", sfecha_nota_credito, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vmemo_nora_cred", smemo_nota_credito, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vmonto_impuesto_nota_cred", smonto_impuesto_nota_cred, OracleClient.OracleType.Number)
            db.AsignarParametro("vtotal_costo_nota_cred", stotal_costo_nota_cred, OracleClient.OracleType.Number)
            db.AsignarParametro("vserie_facturanew", sserie_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_facturanew", snro_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_fact_new", sfecha_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nimpuesto", dimpuesto, OracleClient.OracleType.Number)
            db.AsignarParametro("ntotal", dtotal_costo, OracleClient.OracleType.Number)
            db.AsignarParametro("nidusuario_personal", lidusuario_personal, OracleClient.OracleType.Number)
            db.AsignarParametro("vip", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidrol", iidrol, OracleClient.OracleType.Number)
            db.AsignarParametro("ves_refactura", ses_refactura, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_operacion", operacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            s_cod_mensaje = ds.Tables(1).Rows(0)(0)
            s_mensaje = ds.Tables(1).Rows(0)(1)
            Return True
            'Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

        'Dim flat As Boolean = False
        'Try
        '    Dim cmd As New OracleClient.OracleCommand
        '    cmd.Connection = cnn
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.CommandText = "PKG_IVOREFACTURACION.sp_act_refacturacionII"
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("vidfactura", OracleClient.OracleType.VarChar)).Value = sidfactura
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("vserie_notacred", OracleClient.OracleType.VarChar)).Value = sserie_nota_cred
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("vnro_nota_cred", OracleClient.OracleType.VarChar)).Value = snro_nota_cred
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("vfecha_nota_cred", OracleClient.OracleType.VarChar)).Value = sfecha_nota_credito
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("vmemo_nora_cred", OracleClient.OracleType.VarChar)).Value = smemo_nota_credito
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("vmonto_impuesto_nota_cred", OracleClient.OracleType.Number)).Value = smonto_impuesto_nota_cred
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("vtotal_costo_nota_cred", OracleClient.OracleType.Number)).Value = stotal_costo_nota_cred
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("vserie_facturanew", OracleClient.OracleType.VarChar)).Value = sserie_factura
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("vnro_facturanew", OracleClient.OracleType.VarChar)).Value = snro_factura
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("vfecha_fact_new", OracleClient.OracleType.VarChar)).Value = sfecha_factura
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("nimpuesto", OracleClient.OracleType.Number)).Value = dimpuesto
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("ntotal", OracleClient.OracleType.Number)).Value = dtotal_costo
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("nidusuario_personal", OracleClient.OracleType.Number)).Value = lidusuario_personal
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("vip", OracleClient.OracleType.VarChar)).Value = sip
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("nidrol", OracleClient.OracleType.Number)).Value = iidrol
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("ves_refactura", OracleClient.OracleType.Number)).Value = ses_refactura
        '    cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_mensaje", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
        '    Dim da As New OracleClient.OracleDataAdapter(cmd)
        '    Dim ds As New DataSet
        '    da.Fill(ds)
        '    s_cod_mensaje = ds.Tables(0).Rows(0)(0)
        '    s_mensaje = ds.Tables(0).Rows(0)(1)
        '    flat = True
        'Catch ex As OracleClient.OracleException
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function
    'Function fnbusqueda_refactura2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        rst_busqueda_refacturacion = Nothing
    '        '
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOREFACTURACION.sp_get_refactura", 14, _
    '                                                              l_control, 1, _
    '                                                              lidusuario_personal, 1, _
    '                                                              sfecha_inicio, 2, _
    '                                                              sfecha_final, 2, _
    '                                                              Replace(sserie_factura, "", Nothing), 2, _
    '                                                              Replace(snro_factura, "", Nothing), 2}
    '        rst_busqueda_refacturacion = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        '
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Function fnbusqueda_refactura() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOREFACTURACION.sp_get_refactura", CommandType.StoredProcedure)
            db.AsignarParametro("ni_control", l_control, OracleClient.OracleType.Int32)
            db.AsignarParametro("nidusuario_personal", lidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("vfec_inicio", sfecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfec_final", sfecha_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vserie", IIf(sserie_factura Is Nothing, "", sserie_factura), OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnrofactura", IIf(snro_factura Is Nothing, "", snro_factura), OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_refactura", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_busqueda_refacturacion = db.EjecutarDataTable
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        'Dim flat As Boolean = False
        'Try
        '    rst_busqueda_refacturacion = Nothing
        '    '
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOREFACTURACION.sp_get_refactura", 14, _
        '                                                          l_control, 1, _
        '                                                          lidusuario_personal, 1, _
        '                                                          sfecha_inicio, 2, _
        '                                                          sfecha_final, 2, _
        '                                                          Replace(sserie_factura, "", Nothing), 2, _
        '                                                          Replace(snro_factura, "", Nothing), 2}
        '    rst_busqueda_refacturacion = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    '
        '    flat = True
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function

    Public Function fngraba_refacturacion2009() As Boolean
        'Dim flat As Boolean = False
        'Try
        '    rst_graba_refacturacion = Nothing
        '    '            
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOREFACTURACION.sp_act_refacturacion", 26, _
        '                                                          sidfactura, 2, _
        '                                                          sserie_nota_cred, 2, _
        '                                                          snro_nota_cred, 2, _
        '                                                          sserie_factura, 2, _
        '                                                          snro_factura, 2, _
        '                                                          sfecha_nota_credito, 2, _
        '                                                          sfecha_factura, 2, _
        '                                                          dimpuesto, 3, _
        '                                                          dtotal_costo, 3, _
        '                                                          lidusuario_personal, 1, _
        '                                                          sip, 2, _
        '                                                          iidrol, 1}
        '    rst_graba_refacturacion = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    '
        '    'If rst_verifica_comp.State = 1 Then
        '    s_cod_mensaje = CType(rst_graba_refacturacion.Fields.Item("codmsj").Value, Long)
        '    s_mensaje = CType(rst_graba_refacturacion.Fields.Item("mensaje").Value, String)
        '    'End If
        '    flat = True
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function

    Public Function fngraba_refacturacion() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOREFACTURACION.sp_act_refacturacion", CommandType.StoredProcedure)
            db.AsignarParametro("vidfactura", sidfactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vserie_notacred", sserie_nota_cred, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_nota_cred", snro_nota_cred, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vserie_facturanew", sserie_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vnro_facturanew", snro_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_nota_cred", sfecha_nota_credito, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vfecha_fact_new", sfecha_factura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nimpuesto", dimpuesto, OracleClient.OracleType.Number)
            db.AsignarParametro("ntotal", dtotal_costo, OracleClient.OracleType.Number)
            db.AsignarParametro("nidusuario_personal", lidusuario_personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("vip", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidrol", iidrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rst_graba_refacturacion = db.EjecutarDataTable
            s_cod_mensaje = CType(rst_graba_refacturacion.Rows(0).Item("codmsj"), Long)
            s_mensaje = CType(rst_graba_refacturacion.Rows(0).Item("mensaje"), String)
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function LISTA_TIPO_NORA_CREDI() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_LISTA_TIPO_NORA_CREDI", CommandType.StoredProcedure)
            db.AsignarParametro("CUR_LISTA_TIPO_NORA_CREDI", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function INSUPD_TIPO_NOTA_CREDI(ByVal accion As Integer, ByVal rubro As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOREFACTURACION.SP_INSUPD_TIPO_NOTA_CREDI", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", accion, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTIPO_NOTA_CREDI", rubro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_LISTA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class