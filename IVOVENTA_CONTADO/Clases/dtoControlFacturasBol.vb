Imports AccesoDatos
Public Class dtoControlFacturasBol
#Region "Variables"
    Public iControl As Integer
    Public origen As Integer
    Public destino As Integer
    Public idUsuario As Integer
    Public serie As String
    Public nrodoc As String
    Public RucRazonSocial As String
    Public nu_docu_suna As String
    Public estadoFactura As Integer
    Public fecha_inicio As String
    Public fecha_final As String
    Public TipoComprobante As Integer
    Public fecha_factura As String
    Public monto_descuento As Double
    Public Monto_Sub_Total As Double
    Public Monto_Impuesto As Double
    Public Total_Costo As Double
    Public monto_base As Double
    Public Agencia As Integer
    Public boleto As String
    '
    'Public rstFacturasBol As New ADODB.Recordset
    'Public rstControlDatos As New ADODB.Recordset
    '
#End Region
#Region "Datatables"
    Public dt_rstFacturasBol As New DataTable
#End Region
#Region "Metodos"
    'Public Function fnControlfacturasBol_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim varSP_OBJECT As Object() = {"PKG_IVOVENTACARGA.SP_FILTRO_FACBOL", 22, iControl, 1, origen, 1, destino, 1, idUsuario, 1, serie, 2, nrodoc, 2, RucRazonSocial, 2, estadoFactura, 1, fecha_inicio, 2, fecha_final, 2}
    '        rstFacturasBol = Nothing
    '        rstFacturasBol = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flag = True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnControlfacturasBol() As Boolean
        Dim flag As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'Limpiando el data table 
            dt_rstFacturasBol.Clear()
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_FILTRO_FACBOL", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("origen", origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("destino", destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("idUsuario", idUsuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("serie", serie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("nrodoc", nrodoc, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("RucRazonSocial", RucRazonSocial, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("estadoFactura", estadoFactura, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("fecha_inicio", fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("fecha_final", fecha_final, OracleClient.OracleType.VarChar)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flag = True                
            End If
            dt_rstFacturasBol = lds_tmp.Tables(0)
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Public Function fnControlfacturasBol_2() As Boolean
        Dim flag As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'Limpiando el data table 
            dt_rstFacturasBol.Clear()
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.SP_FILTRO_FACBOL", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("origen", origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("destino", destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("idAgencia", Agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("idUsuario", idUsuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("serie", serie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("nrodoc", nrodoc, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("RucRazonSocial", RucRazonSocial, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("estadoFactura", estadoFactura, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("fecha_inicio", fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("fecha_final", fecha_final, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_tipo", TipoComprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_boleto", boleto, OracleClient.OracleType.VarChar)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flag = True
            End If
            dt_rstFacturasBol = lds_tmp.Tables(0)
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnBuscarDatos_2009(ByVal idFactura As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim varSP_OBJECT As Object() = {"PKG_IVOVENTACARGA.SP_CONSULTA_ANUL_DEVO_I", 4, idFactura.ToString, 2}
    '        rstControlDatos = Nothing
    '        rstControlDatos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rstControlDatos.State = 1 Then

    '            'serie = rstControlDatos.Fields.Item("").Value.ToString
    '            nrodoc = rstControlDatos.Fields.Item("NroDoc").Value.ToString
    '            RucRazonSocial = rstControlDatos.Fields.Item("razon_social").Value.ToString
    '            nu_docu_suna = rstControlDatos.Fields.Item("nu_docu_suna").Value.ToString
    '            fecha_factura = rstControlDatos.Fields.Item("FECHA").Value.ToString
    '            ' estadoFactura = rstControlDatos.Fields.Item("Estado_Registro").Value.ToString
    '            Monto_Sub_Total = rstControlDatos.Fields.Item("Monto_Sub_Total").Value
    '            Monto_Impuesto = rstControlDatos.Fields.Item("Monto_Impuesto").Value
    '            Total_Costo = rstControlDatos.Fields.Item("Total_Costo").Value
    '        End If
    '        flag = True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnBuscarDatos(ByVal idFactura As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable

            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_CONSULTA_ANUL_DEVO_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("x_idfactura", idFactura.ToString, OracleClient.OracleType.VarChar)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                flag = True
                nrodoc = ldt_tmp.Rows(0).Item("NroDoc").ToString
                RucRazonSocial = ldt_tmp.Rows(0).Item("razon_social").ToString
                nu_docu_suna = ldt_tmp.Rows(0).Item("nu_docu_suna").ToString
                fecha_factura = ldt_tmp.Rows(0).Item("FECHA").ToString
                Monto_Sub_Total = ldt_tmp.Rows(0).Item("Monto_Sub_Total")
                Monto_Impuesto = ldt_tmp.Rows(0).Item("Monto_Impuesto")
                Total_Costo = ldt_tmp.Rows(0).Item("Total_Costo")
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnControlfacturasBol__2009() As Boolean   'Creado por Ritcher 05/02/2007 
    '    Dim flag As Boolean = False
    '    Try
    '        Dim varSP_OBJECT As Object() = {"PKG_IVOVENTACARGA.SP_FILTRO_FACBOL_RGT", 22, iControl, 1, origen, 1, destino, 1, idUsuario, 1, serie, 2, nrodoc, 2, RucRazonSocial, 2, estadoFactura, 1, fecha_inicio, 2, fecha_final, 2}
    '        rstFacturasBol = Nothing
    '        rstFacturasBol = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flag = True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnControlfacturasBol_() As Boolean   'Creado por Ritcher 05/02/2007 
        Dim flag As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'Limpiando el data table 
            dt_rstFacturasBol.Clear()
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_FILTRO_FACBOL_RGT", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("origen", origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("destino", destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("idUsuario", idUsuario, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("serie", serie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("nrodoc", nrodoc, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("RucRazonSocial", RucRazonSocial, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("estadoFactura", estadoFactura, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("fecha_inicio", fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("fecha_final", fecha_final, OracleClient.OracleType.VarChar)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flag = True
            End If
            dt_rstFacturasBol = lds_tmp.Tables(0)
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function fnBuscarDatos_rgt_2009(ByVal idFactura As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim varSP_OBJECT As Object() = {"PKG_IVOVENTACARGA.SP_CONSULTA_ANUL_DEVO_II", 4, idFactura.ToString, 2}
    '        rstControlDatos = Nothing
    '        rstControlDatos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rstControlDatos.State = 1 Then

    '            'serie = rstControlDatos.Fields.Item("").Value.ToString
    '            nrodoc = rstControlDatos.Fields.Item("NroDoc").Value.ToString
    '            RucRazonSocial = rstControlDatos.Fields.Item("razon_social").Value.ToString
    '            nu_docu_suna = rstControlDatos.Fields.Item("nu_docu_suna").Value.ToString
    '            fecha_factura = rstControlDatos.Fields.Item("FECHA").Value.ToString
    '            ' estadoFactura = rstControlDatos.Fields.Item("Estado_Registro").Value.ToString
    '            Monto_Sub_Total = rstControlDatos.Fields.Item("Monto_Sub_Total").Value
    '            Monto_Impuesto = rstControlDatos.Fields.Item("Monto_Impuesto").Value
    '            Total_Costo = rstControlDatos.Fields.Item("Total_Costo").Value
    '            monto_base = rstControlDatos.Fields.Item("monto_base").Value
    '            monto_descuento = rstControlDatos.Fields.Item("monto_descuento").Value
    '        End If
    '        flag = True
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnBuscarDatos_rgt(ByVal idFactura As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'Limpiando el data table 
            dt_rstFacturasBol.Clear()
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_CONSULTA_ANUL_DEVO_II", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("x_idfactura", iControl, OracleClient.OracleType.VarChar)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                nrodoc = lds_tmp.Tables(0).Rows(0).Item("NroDoc").ToString
                RucRazonSocial = lds_tmp.Tables(0).Rows(0).Item("razon_social").ToString
                nu_docu_suna = lds_tmp.Tables(0).Rows(0).Item("nu_docu_suna").ToString
                fecha_factura = lds_tmp.Tables(0).Rows(0).Item("FECHA").ToString
                Monto_Sub_Total = lds_tmp.Tables(0).Rows(0).Item("Monto_Sub_Total")
                Monto_Impuesto = lds_tmp.Tables(0).Rows(0).Item("Monto_Impuesto")
                Total_Costo = lds_tmp.Tables(0).Rows(0).Item("Total_Costo")
                monto_base = lds_tmp.Tables(0).Rows(0).Item("monto_base")
                monto_descuento = lds_tmp.Tables(0).Rows(0).Item("monto_descuento")
                flag = True
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Public Function ListaTmp() As Boolean
        Dim flag As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            'Limpiando el data table 
            dt_rstFacturasBol.Clear()
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_VENTACONTADO.sp_listar_tmp", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            '
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flag = True
            End If
            dt_rstFacturasBol = lds_tmp.Tables(0)
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

#End Region
End Class
