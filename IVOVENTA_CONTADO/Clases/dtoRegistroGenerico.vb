Imports AccesoDatos
Public Class dtoRegistroGenerico
    'Public CUR_DATOS As New ADODB.Recordset

    Public v_iControl As Integer
    Public v_idfactura As Integer
    Public v_idagencias As Integer
    Public v_idagencias_destino As Integer
    Public v_idforma_pago As Integer
    Public v_idtipo_pago As Integer
    Public v_idtipo_entrega As Integer
    Public v_idtarjetas As Integer
    Public v_serie_factura As String
    Public v_nro_factura As String
    Public v_fecha_factura As String
    Public v_idusuario_personal As Integer
    Public v_monto_base As Double
    Public v_total_costo As Double
    Public v_total_peso As Double
    Public v_total_volumen As Double
    Public v_cantidad_x_peso As Double
    Public v_cantidad_x_volumen As Integer
    Public v_cantidad_x_sobre As Integer
    Public v_idremitente As Integer
    Public v_iddireecion_origen As Integer
    Public v_iddireecion_destino As Integer
    Public v_idcontacto_destino As Integer

    Public v_Origen_Direccion As String
    Public v_Destino_Direccion As String
    Public v_Origen_Contacto As String
    Public v_DNIOrigen As String
    Public v_Destino_Contacto As String
    Public v_DNIDestino As String
    Public v_Razon_Social As String
    Public v_Nu_Docu_Suna As String
    Public v_porcent_descuento As Double
    Public v_memo As String
    Public v_nrotarjeta As String
    Public v_Idtipo_Comprobante As Integer
    Public v_Tipo_Comprobante As String

    Public v_idPersona As String
    'Public Function fnSP_LISTA_DATOS_GENERICOS_2009() As ADODB.Recordset
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOCARGA.SP_LISTA_DATOS_GENERICOS", 2}
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return CUR_DATOS
    'End Function
    Public Function fnSP_LISTA_DATOS_GENERICOS() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_LISTA_DATOS_GENERICOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Agencias", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_condicion", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Tipo_Pago", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Tipo_Entrega", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Tipo_Tarjeta", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            Return lds_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnSP_LISTA_USUARIOS_2009() As ADODB.Recordset
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOCARGA.SP_LISTA_USUARIOS", 4, v_idagencias, 1}
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return CUR_DATOS
    'End Function
    Public Function fnSP_LISTA_USUARIOS() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            'acceso 21/04/2010
            'db_bd.CrearComando("PKG_IVOCARGA.SP_LISTA_USUARIOS", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_IVOCARGA.SP_LISTA_USUARIOS_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idAgencias", v_idagencias, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            Return ldt_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fnSelIndex(ByVal cmb As ComboBox, ByVal list As Collection, ByVal idSel As Integer) As Boolean
        Try
            For i As Integer = 0 To list.Count - 1
                If Int(list.Item(i.ToString())) = idSel Then
                    cmb.SelectedIndex = i
                    GoTo salir
                End If
            Next
salir:
        Catch ex As Exception

        End Try
    End Function
    'Public Function fnSP_BUSCAR_DOCUEMENTO_2009(ByVal serie As String, ByVal NroDoc As String) As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOCARGA.SP_BUSCAR_DOCUEMENTO", 6, serie, 2, NroDoc, 2}
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If CUR_DATOS.BOF = False And CUR_DATOS.EOF = False Then
    '            v_idfactura = CUR_DATOS.Fields.Item("idfactura").Value
    '            v_idagencias = CUR_DATOS.Fields.Item("idagencias").Value
    '            v_idagencias_destino = CUR_DATOS.Fields.Item("idagencias_destino").Value
    '            v_idforma_pago = CUR_DATOS.Fields.Item("idforma_pago").Value
    '            v_idtipo_pago = CUR_DATOS.Fields.Item("idtipo_pago").Value
    '            v_idtipo_entrega = CUR_DATOS.Fields.Item("idtipo_entrega").Value
    '            v_idtarjetas = CUR_DATOS.Fields.Item("idtarjetas").Value
    '            v_serie_factura = CUR_DATOS.Fields.Item("serie_factura").Value
    '            v_nro_factura = CUR_DATOS.Fields.Item("nro_factura").Value
    '            v_fecha_factura = CUR_DATOS.Fields.Item("fecha_factura").Value
    '            v_idusuario_personal = CUR_DATOS.Fields.Item("idusuario_personal").Value
    '            v_monto_base = CUR_DATOS.Fields.Item("monto_base").Value
    '            v_total_costo = CUR_DATOS.Fields.Item("total_costo").Value
    '            v_total_peso = CUR_DATOS.Fields.Item("total_peso").Value
    '            v_total_volumen = CUR_DATOS.Fields.Item("total_volumen").Value
    '            v_cantidad_x_peso = CUR_DATOS.Fields.Item("cantidad_x_peso").Value
    '            v_cantidad_x_volumen = CUR_DATOS.Fields.Item("cantidad_x_volumen").Value
    '            v_cantidad_x_sobre = CUR_DATOS.Fields.Item("cantidad_x_sobre").Value
    '            v_idremitente = CUR_DATOS.Fields.Item("idremitente").Value
    '            v_iddireecion_origen = CUR_DATOS.Fields.Item("iddireecion_origen").Value
    '            v_iddireecion_destino = CUR_DATOS.Fields.Item("iddireecion_destino").Value
    '            v_idcontacto_destino = CUR_DATOS.Fields.Item("idcontacto_destino").Value

    '            v_Origen_Direccion = CUR_DATOS.Fields.Item("Origen_Direccion").Value
    '            v_Destino_Direccion = CUR_DATOS.Fields.Item("Destino_Direccion").Value
    '            v_Origen_Contacto = CUR_DATOS.Fields.Item("Origen_Contacto").Value
    '            v_DNIOrigen = CUR_DATOS.Fields.Item("DNIOrigen").Value
    '            v_Destino_Contacto = CUR_DATOS.Fields.Item("Destino_Contacto").Value
    '            v_DNIDestino = CUR_DATOS.Fields.Item("DNIDestino").Value
    '            v_Razon_Social = CUR_DATOS.Fields.Item("Razon_Social").Value
    '            v_Nu_Docu_Suna = CUR_DATOS.Fields.Item("Nu_Docu_Suna").Value
    '            v_porcent_descuento = CUR_DATOS.Fields.Item("porcent_descuento").Value
    '            v_memo = CUR_DATOS.Fields.Item("memo").Value
    '            v_nrotarjeta = CUR_DATOS.Fields.Item("nrotarjeta").Value
    '            v_Idtipo_Comprobante = CUR_DATOS.Fields.Item("Idtipo_Comprobante").Value
    '            v_Tipo_Comprobante = CUR_DATOS.Fields.Item("Tipo_Comprobante").Value
    '            flat = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnSP_BUSCAR_DOCUEMENTO(ByVal serie As String, ByVal NroDoc As String) As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_BUSCAR_DOCUEMENTO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_Serie", serie, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NroDoc", NroDoc, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                v_idfactura = ldt_tmp.Rows(0).Item("idfactura")
                v_idagencias = ldt_tmp.Rows(0).Item("idagencias")
                v_idagencias_destino = ldt_tmp.Rows(0).Item("idagencias_destino")
                v_idforma_pago = ldt_tmp.Rows(0).Item("idforma_pago")
                v_idtipo_pago = ldt_tmp.Rows(0).Item("idtipo_pago")
                v_idtipo_entrega = ldt_tmp.Rows(0).Item("idtipo_entrega")
                v_idtarjetas = ldt_tmp.Rows(0).Item("idtarjetas")
                v_serie_factura = ldt_tmp.Rows(0).Item("serie_factura")
                v_nro_factura = ldt_tmp.Rows(0).Item("nro_factura")
                v_fecha_factura = ldt_tmp.Rows(0).Item("fecha_factura")
                v_idusuario_personal = ldt_tmp.Rows(0).Item("idusuario_personal")
                v_monto_base = ldt_tmp.Rows(0).Item("monto_base")
                v_total_costo = ldt_tmp.Rows(0).Item("total_costo")
                v_total_peso = ldt_tmp.Rows(0).Item("total_peso")
                v_total_volumen = ldt_tmp.Rows(0).Item("total_volumen")
                v_cantidad_x_peso = ldt_tmp.Rows(0).Item("cantidad_x_peso")
                v_cantidad_x_volumen = ldt_tmp.Rows(0).Item("cantidad_x_volumen")
                v_cantidad_x_sobre = ldt_tmp.Rows(0).Item("cantidad_x_sobre")
                v_idremitente = ldt_tmp.Rows(0).Item("idremitente")
                v_iddireecion_origen = ldt_tmp.Rows(0).Item("iddireecion_origen")
                v_iddireecion_destino = ldt_tmp.Rows(0).Item("iddireecion_destino")
                v_idcontacto_destino = ldt_tmp.Rows(0).Item("idcontacto_destino")
                v_Origen_Direccion = ldt_tmp.Rows(0).Item("Origen_Direccion")
                v_Destino_Direccion = ldt_tmp.Rows(0).Item("Destino_Direccion")
                v_Origen_Contacto = ldt_tmp.Rows(0).Item("Origen_Contacto")
                v_DNIOrigen = ldt_tmp.Rows(0).Item("DNIOrigen")
                v_Destino_Contacto = ldt_tmp.Rows(0).Item("Destino_Contacto")
                v_DNIDestino = ldt_tmp.Rows(0).Item("DNIDestino")
                v_Razon_Social = ldt_tmp.Rows(0).Item("Razon_Social")
                v_Nu_Docu_Suna = ldt_tmp.Rows(0).Item("Nu_Docu_Suna")
                v_porcent_descuento = ldt_tmp.Rows(0).Item("porcent_descuento")
                v_memo = ldt_tmp.Rows(0).Item("memo")
                v_nrotarjeta = ldt_tmp.Rows(0).Item("nrotarjeta")
                v_Idtipo_Comprobante = ldt_tmp.Rows(0).Item("Idtipo_Comprobante")
                v_Tipo_Comprobante = ldt_tmp.Rows(0).Item("Tipo_Comprobante")
                flat = True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    Public Function fnClear() As Boolean
        Try
            v_idfactura = 0
            v_idagencias = 0
            v_idagencias_destino = 0
            v_idforma_pago = 0
            v_idtipo_pago = 0
            v_idtipo_entrega = 0
            v_idtarjetas = 0
            v_serie_factura = ""
            v_nro_factura = ""
            v_fecha_factura = ""
            v_idusuario_personal = 0
            v_monto_base = 0
            v_total_costo = 0
            v_total_peso = 0
            v_total_volumen = 0
            v_cantidad_x_peso = 0
            v_cantidad_x_volumen = 0
            v_cantidad_x_sobre = 0
            v_idremitente = 0
            v_iddireecion_origen = 0
            v_iddireecion_destino = 0
            v_idcontacto_destino = 0
            v_Origen_Direccion = ""
            v_Destino_Direccion = ""
            v_Origen_Contacto = ""
            v_DNIOrigen = ""
            v_Destino_Contacto = ""
            v_DNIDestino = ""
            v_Razon_Social = ""
            v_Nu_Docu_Suna = ""
            v_porcent_descuento = 0
            v_memo = ""
            v_nrotarjeta = ""
            v_Idtipo_Comprobante = 0
            v_Tipo_Comprobante = ""
        Catch ex As Exception

        End Try
    End Function
    'Public Function fnSP_INSUP_REGISTRO_GENERICO_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOCARGA.SP_INSUP_REGISTRO_GENERICO", 80, v_iControl, 1, v_idfactura, 1, v_idPersona, 2, v_idagencias, 1, v_idagencias_destino, 1, v_idforma_pago, 1, v_idtipo_pago, 1, v_idtipo_entrega, 1, v_idtarjetas, 1, v_serie_factura, 2, v_nro_factura, 2, v_fecha_factura, 2, v_idusuario_personal, 1, dtoUSUARIOS.IdLogin, 1, v_monto_base, 3, v_total_costo, 3, v_total_peso, 3, v_total_volumen, 3, v_cantidad_x_peso, 1, v_cantidad_x_volumen, 1, v_cantidad_x_sobre, 1, v_idremitente, 2, v_iddireecion_origen, 2, v_iddireecion_destino, 2, v_idcontacto_destino, 2, v_Origen_Direccion, 2, v_Destino_Direccion, 2, v_Origen_Contacto, 2, v_DNIOrigen, 2, v_Destino_Contacto, 2, v_DNIDestino, 2, v_Razon_Social, 2, v_Nu_Docu_Suna, 2, v_porcent_descuento, 3, v_memo, 2, v_nrotarjeta, 2, v_Idtipo_Comprobante, 1, dtoUSUARIOS.IP, 2, dtoUSUARIOS.IdRol, 1}
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If CUR_DATOS.BOF = False And CUR_DATOS.EOF = False Then
    '            MsgBox(CUR_DATOS.Fields.Item("MSGBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '            flat = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnSP_INSUP_REGISTRO_GENERICO() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_INSUP_REGISTRO_GENERICO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_iControl", v_iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idfactura", v_idfactura, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idPersona", v_idPersona, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idagencias", v_idagencias, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idagencias_destino", v_idagencias_destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idforma_pago", v_idforma_pago, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idtipo_pago", v_idtipo_pago, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idtipo_entrega", v_idtipo_entrega, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idtarjetas", v_idtarjetas, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_serie_factura", v_serie_factura, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_nro_factura", v_nro_factura, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fecha_factura", v_fecha_factura, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idusuario_personal", v_idusuario_personal, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idusuario_Liquidacion", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_monto_base", v_monto_base, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_total_costo", v_total_costo, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_total_peso", v_total_peso, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_total_volumen", v_total_volumen, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_cantidad_x_peso", v_cantidad_x_peso, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_cantidad_x_volumen", v_cantidad_x_volumen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_cantidad_x_sobre", v_cantidad_x_sobre, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idremitente", v_idremitente, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_iddireecion_origen", v_iddireecion_origen, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_iddireecion_destino", v_iddireecion_destino, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idcontacto_destino", v_idcontacto_destino, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Origen_Direccion", v_Origen_Direccion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Destino_Direccion", v_Destino_Direccion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Origen_Contacto", v_Origen_Contacto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DNIOrigen", v_DNIOrigen, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Destino_Contacto", v_Destino_Contacto, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_DNIDestino", v_DNIDestino, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Razon_Social", v_Razon_Social, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Nu_Docu_Suna", v_porcent_descuento, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_porcent_descuento", v_porcent_descuento, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_memo", v_memo, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_nrotarjeta", v_nrotarjeta, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Idtipo_Comprobante", v_Idtipo_Comprobante, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idrol_usuario", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                MsgBox(ldt_tmp.Rows(0).Item("MSGBOX"), MsgBoxStyle.Information, "Seguridad Sistema")
                flat = True
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function fnSP_DESBLOQUEAR_REGISTRO_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOCARGA.SP_DESBLOQUEAR_REGISTRO", 1, v_idfactura.ToString(), 2}
    '        CUR_DATOS = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If CUR_DATOS.BOF = False And CUR_DATOS.EOF = False Then
    '            MsgBox(CUR_DATOS.Fields.Item("MSGBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '            flat = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnSP_DESBLOQUEAR_REGISTRO() As Boolean
        Dim flat As Boolean = False
        '
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_DESBLOQUEAR_REGISTRO", CommandType.StoredProcedure)
            '-- Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input -- '
            db_bd.AsignarParametro("v_idfactura", v_idfactura.ToString(), OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                MsgBox(ldt_tmp.Rows(0).Item("MSGBOX"), MsgBoxStyle.Information, "Seguridad Sistema")
                flat = True
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
