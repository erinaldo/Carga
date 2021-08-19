Imports AccesoDatos
Public Class dtoControlDescuento
#Region "VARIBLES"
    Public v_IDFACTURA As Integer
    Public v_FECHA_FACTURA As String
    Public v_ORIGEN As String
    Public v_DESTINO As String
    Public v_NRO_GUIA As String
    Public v_FORMA_PAGO As String
    Public v_CANTIDAD As Integer
    Public v_CANTIDAD_X_SOBRE As Integer
    Public v_TOTAL_PESO As Double
    Public v_TOTAL_VOLUMEN As Double
    Public v_CLIENTE As String
    Public v_CLIENTE_FACTURADOR As String
    Public v_MEMO As String
    Public v_MONTO_DESCUENTO As Double
    Public v_MONTO_SUB_TOTAL As Double
    Public v_MONTO_IMPUESTO As Double
    Public v_TOTAL_COSTO As Double
    Public v_TOTAL_COSTO_REAL As Double
    '
    Public V_FECHA_ACTUALIZACION As String
    Public V_USUARIO_MODIFICAION As String
    Public V_FACTURADA As Integer
    '
    Public v_Comprobante_venta As String
    '
    'Public Cur_DATOS_VENTA As New ADODB.Recordset
    '
#End Region
    'Public Function fnSP_UDP_DESCUENTOS_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"AA_TEST.SP_UDP_DESCUENTOS", 20, v_IDFACTURA.ToString(), 2, v_MONTO_DESCUENTO, 3, v_MEMO, 2, v_MONTO_SUB_TOTAL, 3, v_MONTO_IMPUESTO, 3, v_TOTAL_COSTO, 3, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IdRol, 1}
    '        Cur_DATOS_VENTA = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If Cur_DATOS_VENTA.BOF = False And Cur_DATOS_VENTA.EOF = False Then
    '            flag = True
    '            MsgBox(Cur_DATOS_VENTA.Fields.Item("MSGBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If
    '    Catch ex As Exception
    '        MsgBox("No puede Realizar Esta Operaciones...", MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '    End Try
    '    Return flag

    'End Function
    Public Function fnSP_UDP_DESCUENTOS() As Boolean
        Dim flag As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("AA_TEST.SP_UDP_DESCUENTOS", CommandType.StoredProcedure)

            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_IDFACTURA", v_IDFACTURA.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("V_DESCUENTO", v_MONTO_DESCUENTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("V_MEMO", v_MEMO, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("V_Monto_Sub_Total", v_MONTO_SUB_TOTAL, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("V_Monto_Impuesto", v_MONTO_IMPUESTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("V_TOTAL_COSTO", v_TOTAL_COSTO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_IP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("V_IDUSUARIO", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("V_IDROL", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_DATOS", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                flag = True
                MsgBox(ldt_tmp.Rows(0).Item("MSGBOX"), MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnSP_CONTROL_DESCUENTO_2009() As Boolean
    '    '
    '    Dim flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"AA_TEST.SP_CONTROL_DESCUENTO", 4, v_IDFACTURA.ToString(), 2}
    '        Cur_DATOS_VENTA = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If Cur_DATOS_VENTA.BOF = False And Cur_DATOS_VENTA.EOF = False Then
    '            flag = True
    '            ' v_IDFACTURA As Integer
    '            v_FECHA_FACTURA = Cur_DATOS_VENTA.Fields.Item("FECHA").Value
    '            v_ORIGEN = Cur_DATOS_VENTA.Fields.Item("Origen").Value
    '            v_DESTINO = Cur_DATOS_VENTA.Fields.Item("Destino").Value
    '            v_NRO_GUIA = Cur_DATOS_VENTA.Fields.Item("Nro_Guia").Value
    '            v_FORMA_PAGO = Cur_DATOS_VENTA.Fields.Item("Forma_Pago").Value
    '            v_CANTIDAD = Cur_DATOS_VENTA.Fields.Item("Cantidad").Value
    '            v_CANTIDAD_X_SOBRE = Cur_DATOS_VENTA.Fields.Item("Cantidad_x_Sobre").Value
    '            v_TOTAL_PESO = Cur_DATOS_VENTA.Fields.Item("Total_Peso").Value
    '            v_TOTAL_VOLUMEN = Cur_DATOS_VENTA.Fields.Item("Total_Volumen").Value
    '            v_CLIENTE = Cur_DATOS_VENTA.Fields.Item("Cliente").Value
    '            v_CLIENTE_FACTURADOR = Cur_DATOS_VENTA.Fields.Item("Facturador").Value
    '            v_MEMO = Cur_DATOS_VENTA.Fields.Item("Memo").Value
    '            v_MONTO_DESCUENTO = Cur_DATOS_VENTA.Fields.Item("Monto_Descuento").Value
    '            v_MONTO_SUB_TOTAL = Cur_DATOS_VENTA.Fields.Item("Monto_Sub_Total").Value
    '            v_MONTO_IMPUESTO = Cur_DATOS_VENTA.Fields.Item("Monto_Impuesto").Value
    '            v_TOTAL_COSTO = Cur_DATOS_VENTA.Fields.Item("Total_Costo").Value                
    '            V_FECHA_ACTUALIZACION = Cur_DATOS_VENTA.Fields.Item("Fecha_Actualizacion").Value
    '            V_USUARIO_MODIFICAION = Cur_DATOS_VENTA.Fields.Item("Login").Value
    '            V_FACTURADA = Cur_DATOS_VENTA.Fields.Item("Facturado").Value
    '        End If
    '    Catch ex As Exception
    '        MsgBox("No puede Realizar Esta Operaciones...", MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnSP_CONTROL_DESCUENTO() As Boolean
        Dim flag As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("AA_TEST.SP_CONTROL_DESCUENTO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_IDCOMPROBANTE", v_IDFACTURA.ToString(), OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("CUR_DATOS", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                flag = True
                v_FECHA_FACTURA = ldt_tmp.Rows(0).Item("FECHA")
                v_ORIGEN = ldt_tmp.Rows(0).Item("Origen")
                v_DESTINO = ldt_tmp.Rows(0).Item("Destino")
                v_NRO_GUIA = IIf(IsDBNull(ldt_tmp.Rows(0).Item("Nro_Guia")) = True, "", ldt_tmp.Rows(0).Item("Nro_Guia"))
                v_FORMA_PAGO = ldt_tmp.Rows(0).Item("Forma_Pago")
                v_CANTIDAD = ldt_tmp.Rows(0).Item("Cantidad")
                v_CANTIDAD_X_SOBRE = ldt_tmp.Rows(0).Item("Cantidad_x_Sobre")
                v_TOTAL_PESO = ldt_tmp.Rows(0).Item("Total_Peso")
                v_TOTAL_VOLUMEN = ldt_tmp.Rows(0).Item("Total_Volumen")
                v_CLIENTE = ldt_tmp.Rows(0).Item("Cliente")
                v_CLIENTE_FACTURADOR = ldt_tmp.Rows(0).Item("Facturador")
                v_MEMO = ldt_tmp.Rows(0).Item("Memo")
                v_MONTO_DESCUENTO = ldt_tmp.Rows(0).Item("Monto_Descuento")
                v_MONTO_SUB_TOTAL = ldt_tmp.Rows(0).Item("Monto_Sub_Total")
                v_MONTO_IMPUESTO = ldt_tmp.Rows(0).Item("Monto_Impuesto")
                v_TOTAL_COSTO = ldt_tmp.Rows(0).Item("Total_Costo")
                v_TOTAL_COSTO_REAL = ldt_tmp.Rows(0).Item("costo_real")
                '
                V_FECHA_ACTUALIZACION = ldt_tmp.Rows(0).Item("Fecha_Actualizacion")
                V_USUARIO_MODIFICAION = ldt_tmp.Rows(0).Item("Login")
                V_FACTURADA = ldt_tmp.Rows(0).Item("Facturado")
                v_Comprobante_venta = ldt_tmp.Rows(0).Item("comp_venta")
                '
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
End Class
