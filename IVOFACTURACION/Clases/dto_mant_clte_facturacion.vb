Imports AccesoDatos
Public Class dto_mant_clte_facturacion
#Region "Recordset"
    'Public rst_tipo_direccion As New ADODB.Recordset
    Public rst_tipo_direccion As New DataTable
    'Public rst_pais As New ADODB.Recordset
    Public rst_pais As New DataTable
    'Public rst_dptos As New ADODB.Recordset
    Public rst_dptos As New DataTable
    'Public rst_provincia As New ADODB.Recordset
    Public rst_provincia As New DataTable
    'Public rst_distrito As New ADODB.Recordset
    Public rst_distrito As New DataTable
    'Public rst_agencia As New ADODB.Recordset
    Public rst_agencia As New DataTable
    'Public rst_direccion_consignado As New ADODB.Recordset
    Public rst_direccion_consignado As New DataTable
    '
    'Public rst_cliente As New ADODB.Recordset
    Public rst_cliente As New DataTable
    'Public rst_direccion_local As New ADODB.Recordset
    Public rst_direccion_local As New DataTable
    '
    'Public rst_graba As New ADODB.Recordset
    Public rst_graba As New DataTable
    'Public rst_mensaje As New ADODB.Recordset
    Public rst_mensaje As New DataTable
#End Region
#Region "Variables"
    ' Load 
    Public sidpersona As String
    Public lidagencia As Long
    Public sidireccionconsignado As String
    ' Grabando 
    Public icontrol As Integer
    Public srazon_social As String
    Public srepresentante_legal As String
    Public sruc As String
    Public lidrubro As Long
    Public lidusuario_personal As Long
    Public lidrol As Long
    Public sip As String
    Public sididdireccion_consigna As String
    Public sdireccion As String
    Public lidpais As Long
    Public liddepartamento As Long
    Public lidprovincia As Long
    Public liddistrito As Long

#End Region
#Region "Funciones"
    'Public Function fn_load_mant_clte_facturacion2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim Objmant_clte_facturacion As Object() = {"PKG_IVOFACTUACION_OTROS.sp_load_mant_clte_facturacion", 6, _
    '                                                                           lidagencia, 1, _
    '                                                                           sidireccionconsignado, 2}
    '        '
    '        rst_tipo_direccion = Nothing
    '        rst_pais = Nothing
    '        rst_dptos = Nothing
    '        rst_provincia = Nothing
    '        rst_distrito = Nothing
    '        rst_agencia = Nothing
    '        rst_direccion_consignado = Nothing
    '        '
    '        rst_tipo_direccion = VOCONTROLUSUARIO.fnSQLQuery(Objmant_clte_facturacion)
    '        'If rst_tipo_direccion.EOF = False And rst_tipo_direccion.BOF = False Then
    '        '    rst_pais = rst_tipo_direccion.NextRecordset
    '        '    rst_dptos = rst_tipo_direccion.NextRecordset
    '        '    rst_provincia = rst_tipo_direccion.NextRecordset
    '        '    rst_distrito = rst_tipo_direccion.NextRecordset
    '        '    rst_agencia = rst_tipo_direccion.NextRecordset
    '        '    rst_direccion_consignado = rst_tipo_direccion.NextRecordset
    '        'End If
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    Public Function fn_load_mant_clte_facturacion() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_load_mant_clte_facturacion", CommandType.StoredProcedure)
            db.AsignarParametro("nidagencias", lidagencia, OracleClient.OracleType.Number)
            db.AsignarParametro("vIDDIRECCION_CONSIGNADO", sidireccionconsignado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_TIPODIRECCION", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_PAIS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_DPTOS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_PROVINCIA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_DISTRITO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_agencia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_direccion", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_tipo_direccion = ds.Tables(0)
            If rst_tipo_direccion.Rows.Count > 0 Then
                rst_pais = ds.Tables(1)
                rst_dptos = ds.Tables(2)
                rst_provincia = ds.Tables(3)
                rst_distrito = ds.Tables(4)
                rst_agencia = ds.Tables(5)
                rst_direccion_consignado = ds.Tables(6)
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fn_recupera_persona2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim Objmant_clte_facturacion As Object() = {"PKG_IVOFACTUACION_OTROS.sp_get_persona_direccion", 4, _
    '                                                                           sidpersona, 2}
    '        '
    '        rst_cliente = Nothing
    '        rst_direccion_local = Nothing
    '        '
    '        rst_cliente = VOCONTROLUSUARIO.fnSQLQuery(Objmant_clte_facturacion)
    '        'If rst_cliente.EOF = False And rst_cliente.BOF = False Then
    '        'rst_direccion_local = rst_cliente.NextRecordset
    '        'End If
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    Public Function fn_recupera_persona() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_get_persona_direccion", CommandType.StoredProcedure)
            db.AsignarParametro("vidpersona", sidpersona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_dir_cliente", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_cliente = ds.Tables(0)
            If rst_cliente.Rows.Count > 0 Then
                rst_direccion_local = ds.Tables(1)
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

        'Dim flat As Boolean = False
        'Try
        '    Dim Objmant_clte_facturacion As Object() = {"PKG_IVOFACTUACION_OTROS.sp_get_persona_direccion", 4, _
        '                                                                       sidpersona, 2}
        '    '
        '    rst_cliente = Nothing
        '    rst_direccion_local = Nothing
        '    '
        '    rst_cliente = VOCONTROLUSUARIO.fnSQLQuery(Objmant_clte_facturacion)
        '    If rst_cliente.EOF = False And rst_cliente.BOF = False Then
        '        rst_direccion_local = rst_cliente.NextRecordset
        '    End If
        '    flat = True
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function

    Public Function fn_graba_cliente2009() As Boolean
        Dim flat As Boolean = False
        Try
            Dim Objmant_clte_facturacion As Object() = {"PKG_IVOFACTUACION_OTROS.sp_act_cliente_direccion", 32, _
                                                                               icontrol, 1, _
                                                                               sidpersona, 2, _
                                                                               srazon_social, 2, _
                                                                               srepresentante_legal, 2, _
                                                                               sruc, 2, _
                                                                               lidrubro, 1, _
                                                                               lidusuario_personal, 1, _
                                                                               lidrol, 1, _
                                                                               sip, 2, _
                                                                               sididdireccion_consigna, 2, _
                                                                               sdireccion, 2, _
                                                                               lidpais, 1, _
                                                                               liddepartamento, 1, _
                                                                               lidprovincia, 1, _
                                                                               liddistrito, 1}
            '
            'rst_graba = Nothing
            'rst_mensaje = Nothing
            '
            'rst_graba = VOCONTROLUSUARIO.fnSQLQuery(Objmant_clte_facturacion)
            'If rst_graba.EOF = False And rst_graba.BOF = False Then
            'rst_mensaje = rst_graba.NextRecordset
            'End If
            flat = True
        Catch ex As Exception
            flat = False
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function

    Public Function fn_graba_cliente() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTUACION_OTROS.sp_act_cliente_direccion", CommandType.StoredProcedure)
            db.AsignarParametro("ncontrol", icontrol, OracleClient.OracleType.Number)
            db.AsignarParametro("vidpersona", sidpersona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vrazon_social", srazon_social, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vrepresentante_legal", srepresentante_legal, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vruc", sruc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidrubro", lidrubro, OracleClient.OracleType.Number)
            db.AsignarParametro("nidusuario_personal", lidusuario_personal, OracleClient.OracleType.Number)
            db.AsignarParametro("nidrol", lidrol, OracleClient.OracleType.Number)
            db.AsignarParametro("vip", sip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vididdireccion_consigna", sididdireccion_consigna, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vdireccion", sdireccion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("nidpais", lidpais, OracleClient.OracleType.Number)
            db.AsignarParametro("niddepartamento", liddepartamento, OracleClient.OracleType.Number)
            db.AsignarParametro("nidprovincia", lidprovincia, OracleClient.OracleType.Number)
            db.AsignarParametro("niddistrito", liddistrito, OracleClient.OracleType.Number)
            db.AsignarParametro("ocur_graba", OracleClient.OracleType.Cursor)
            db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_graba = ds.Tables(0)
            If rst_graba.Rows.Count > 0 Then
                rst_mensaje = ds.Tables(1)
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        'Dim flat As Boolean = False
        'Try
        '    Dim Objmant_clte_facturacion As Object() = {"PKG_IVOFACTUACION_OTROS.sp_act_cliente_direccion", 32, _
        '                                                                       icontrol, 1, _
        '                                                                       sidpersona, 2, _
        '                                                                       srazon_social, 2, _
        '                                                                       srepresentante_legal, 2, _
        '                                                                       sruc, 2, _
        '                                                                       lidrubro, 1, _
        '                                                                       lidusuario_personal, 1, _
        '                                                                       lidrol, 1, _
        '                                                                       sip, 2, _
        '                                                                       sididdireccion_consigna, 2, _
        '                                                                       sdireccion, 2, _
        '                                                                       lidpais, 1, _
        '                                                                       liddepartamento, 1, _
        '                                                                       lidprovincia, 1, _
        '                                                                       liddistrito, 1}
        '    '
        '    rst_graba = Nothing
        '    rst_mensaje = Nothing
        '    '
        '    rst_graba = VOCONTROLUSUARIO.fnSQLQuery(Objmant_clte_facturacion)
        '    If rst_graba.EOF = False And rst_graba.BOF = False Then
        '        rst_mensaje = rst_graba.NextRecordset
        '    End If
        '    flat = True
        'Catch ex As Exception
        '    flat = False
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return flat
    End Function

#End Region
End Class