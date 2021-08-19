Imports AccesoDatos
Public Class dtoEditarDatosDocumentos
#Region "Datatatables"
    Public v_idtip_comprobante As Integer
    Public v_idcomprobante As String
    Public v_idSolicitud As String
    '-------------------------------
    Public Serie As String
    Public NroDoc As String
    Public NROSUNAT As String
    Public Razon_Social As String
    Public Sobres As Integer
    Public Cantidad As Integer
    Public Fecha_Doc As String
    Public Direccion As String
    Public Iddireccion_Consignado As String
    Public idTipo_Entrega As Integer
    'Public cur_datos As New ADODB.Recordset
    'Public cur_Direcciones As New ADODB.Recordset
#End Region
    '
#Region "Datatatables"
    Public dt_cur_Direcciones As New DataTable
    Public dt_tipo_entrega As New DataTable
#End Region
    'Function fnCONTROL_DATOS_MOVIL_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_CONTROL_DATOS_MOVIL", 6, v_idtip_comprobante, 1, v_idcomprobante, 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_datos.EOF = False And cur_datos.BOF = False Then
    '            NroDoc = cur_datos.Fields.Item("NroDoc").Value
    '            NROSUNAT = cur_datos.Fields.Item("NROSUNAT").Value
    '            Razon_Social = cur_datos.Fields.Item("Razon_Social").Value
    '            Sobres = cur_datos.Fields.Item("Sobres").Value
    '            Cantidad = cur_datos.Fields.Item("Cantidad").Value
    '            Fecha_Doc = cur_datos.Fields.Item("Fecha_Doc").Value
    '            Direccion = cur_datos.Fields.Item("Direccion").Value
    '            Iddireccion_Consignado = cur_datos.Fields.Item("Iddireccion_Consignado").Value
    '            idTipo_Entrega = cur_datos.Fields.Item("idTipo_Entrega").Value
    '            flat = True
    '            cur_Direcciones = cur_datos.NextRecordset
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    'Function fnSP_CONTROL_DIRECION_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_CONTROL_DIRECION", 6, Serie, 2, NroDoc, 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_datos.EOF = False And cur_datos.BOF = False Then
    '            NroDoc = cur_datos.Fields.Item("NroDoc").Value
    '            NROSUNAT = cur_datos.Fields.Item("NROSUNAT").Value
    '            Razon_Social = cur_datos.Fields.Item("Razon_Social").Value
    '            Sobres = cur_datos.Fields.Item("Sobres").Value
    '            Cantidad = cur_datos.Fields.Item("Cantidad").Value
    '            Fecha_Doc = cur_datos.Fields.Item("Fecha_Doc").Value
    '            Direccion = cur_datos.Fields.Item("Direccion").Value
    '            Iddireccion_Consignado = cur_datos.Fields.Item("Iddireccion_Consignado").Value
    '            v_idtip_comprobante = cur_datos.Fields.Item("idTipo").Value
    '            v_idcomprobante = cur_datos.Fields.Item("idComprobante").Value
    '            idTipo_Entrega = cur_datos.Fields.Item("idTipo_Entrega").Value
    '            flat = True
    '            cur_Direcciones = cur_datos.NextRecordset
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Function fnSP_CONTROL_DIRECION() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_CONTROL_DIRECION", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_Serie", Serie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NroDocumento", NroDoc, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Direcciones", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Tipo_Entrega", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                NroDoc = lds_tmp.Tables(0).Rows(0).Item("NroDoc")
                NROSUNAT = lds_tmp.Tables(0).Rows(0).Item("NROSUNAT")
                Razon_Social = lds_tmp.Tables(0).Rows(0).Item("Razon_Social")
                Sobres = lds_tmp.Tables(0).Rows(0).Item("Sobres")
                Cantidad = lds_tmp.Tables(0).Rows(0).Item("Cantidad")
                Fecha_Doc = lds_tmp.Tables(0).Rows(0).Item("Fecha_Doc")
                Direccion = lds_tmp.Tables(0).Rows(0).Item("Direccion")
                Iddireccion_Consignado = lds_tmp.Tables(0).Rows(0).Item("Iddireccion_Consignado")
                v_idtip_comprobante = lds_tmp.Tables(0).Rows(0).Item("idTipo")
                v_idcomprobante = lds_tmp.Tables(0).Rows(0).Item("idComprobante")
                idTipo_Entrega = lds_tmp.Tables(0).Rows(0).Item("idTipo_Entrega")
                flat = True
                dt_cur_Direcciones = lds_tmp.Tables(1)
                dt_tipo_entrega = lds_tmp.Tables(2)
            End If
            '            
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function fnINSUD_DATOS_DOC_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOOPERACIONES_MOVILES.SP_INSUD_DATOS_DOC", 14, v_idSolicitud, 2, v_idtip_comprobante, 1, v_idcomprobante, 2, Iddireccion_Consignado, 2, Direccion, 2, idTipo_Entrega, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_datos.EOF = False And cur_datos.BOF = False Then
    '            MsgBox(cur_datos.Fields.Item("MGSBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '            Iddireccion_Consignado = cur_datos.Fields.Item("IdDireccion").Value
    '            flat = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnINSUD_DATOS_DOC() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOOPERACIONES_MOVILES.SP_INSUD_DATOS_DOC", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idSolicitud", v_idSolicitud, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idtip_comprobante", v_idtip_comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idcomprobante", v_idcomprobante, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IdDireccion", Iddireccion_Consignado, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("Direccion", Direccion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idTipo_Entrega", idTipo_Entrega, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                MsgBox(ldt_tmp.Rows(0).Item("MGSBOX"), MsgBoxStyle.Information, "Seguridad Sistema")
                Iddireccion_Consignado = ldt_tmp.Rows(0).Item("IdDireccion")
                flat = True
            End If
            '            
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function fnTipo_Entrega_2009() As ADODB.Recordset
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"select t_Tipo_Entrega.Idtipo_Entrega,t_Tipo_Entrega.Tipo_Entrega from t_Tipo_Entrega", 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '        'If cur_datos.EOF = False And cur_datos.BOF = False Then
    '        '    MsgBox(cur_datos.Fields.Item("MGSBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '        '    flat = True
    '        'End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return cur_datos
    'End Function
End Class
