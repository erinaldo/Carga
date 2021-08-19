Imports AccesoDatos
Public Class dtoTarifaSubCuenta
    Public cur_datos As New ADODB.Recordset
    Public iControl As Integer
    Public v_Origen As Integer
    Public v_Destino As Integer
    'Public v_idPersona As String
    Public v_iControl As Integer
    Public v_IDTARIFA_SUB_CUENTA As String
    Public v_IDPERSONA As String
    Public v_IDCLIENTE_SUBCUENTA As String
    Public v_IDCENTRO_COSTO As Integer
    Public v_IDUNIDAD_AGENCIA As Integer
    Public v_IDUNIDAD_AGENCIA_DESTINO As Integer
    Public v_PRECIO_X_PESO As Double
    Public v_PRECIO_X_VOLUMEN As Double
    Public v_PRECIO_X_SOBRE As Double
    Public v_MONTO_BASE As Double
    Public v_ES_VIGENTE As Integer
    Public v_IDTIPO_MONEDA As Integer
    Public v_IP As String
    Public v_IDUSUARIO_PERSONAL As Integer
    Public v_IDESTADO_REGISTRO As Integer
    Public v_FECHA_ACTIVACION As String
    Public v_FECHA_DESACTIVACION As String
    Public v_IDROL_USUARIO As Integer
    Public v_RUC As String
    Public v_RAZON_SOCIAL As String

    Public Cg_Monto_Base As Double
    Public Cg_x_Peso As Double
    Public Cg_x_Volumen As Double
    '
    Public ls_idcentro_costo As String
    'Public Function fnSP_LISTA_DATOS_TARIFARIOS_2009() As ADODB.Recordset
    '    Dim flat As String = "..."
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_LISTA_DATOS_TARIFARIOS", 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = "...xxx"
    '    End Try
    '    Return cur_datos
    'End Function
    Public Function fnSP_LISTA_DATOS_TARIFARIOS() As DataSet
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_LISTA_DATOS_TARIFARIOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas             
            db_bd.AsignarParametro("cur_Agencia", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Funcionario", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            Return lds_tmp
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnSP_LISTA_CLIENTES_2009(ByVal idFuncionario As Integer) As ADODB.Recordset
    '    Dim flat As String = "..."
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_LISTA_CLIENTES", 4, idFuncionario, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = "...xxx"
    '    End Try
    '    Return cur_datos
    'End Function
    Public Function fnSP_LISTA_CLIENTES(ByVal idFuncionario As Integer) As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado
            'hlamas 06-01-2013
            'db_bd.CrearComando("PKG_IVOCARGA.SP_LISTA_CLIENTES", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_IVOCARGA.SP_LISTA_CLIENTES_CARTERA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idFuncionario", idFuncionario, OracleClient.OracleType.Int32)
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
    'Public Function fnSP_CENTRO_COSTO_2009() As ADODB.Recordset
    '    Dim flat As String = "..."
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_CENTRO_COSTO", 4, v_IDPERSONA, 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = "...xxx"
    '    End Try
    '    Return cur_datos
    'End Function
    Public Function fnSP_CENTRO_COSTO() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_CENTRO_COSTO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idPersona", v_IDPERSONA, OracleClient.OracleType.VarChar)
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
    'Public Function fnSP_BUSCAR_TARIFARIOS_2009() As ADODB.Recordset
    '    Dim flat As String = "..."
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_BUSCAR_TARIFARIOS", 10, iControl, 1, v_Origen, 1, v_Destino, 1, v_idPersona, 2}
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_BUSCAR_TARIFARIOS_1", 12, iControl, 1, v_Origen, 1, v_Destino, 1, v_IDPERSONA, 2, ls_idcentro_costo, 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = "....."
    '    End Try
    '    Return cur_datos
    'End Function
    Public Function fnSP_BUSCAR_TARIFARIOS() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_BUSCAR_TARIFARIOS_1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControl, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("v_Origen", v_Origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Destino", v_Destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idPersona", v_IDPERSONA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idsub_cuenta", ls_idcentro_costo, OracleClient.OracleType.VarChar)
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
    'Public Function fnSP_INSUPD_TARIFA_SUB_CUENTA_2009() As ADODB.Recordset
    '    Dim flat As String = "..."
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_INSUPD_TARIFA_SUB_CUENTA", 40, v_iControl, 1, v_IDTARIFA_SUB_CUENTA, 2, v_IDPERSONA, 2, v_IDCLIENTE_SUBCUENTA, 2, v_IDCENTRO_COSTO, 1, v_IDUNIDAD_AGENCIA, 1, v_IDUNIDAD_AGENCIA_DESTINO, 1, v_PRECIO_X_PESO, 3, v_PRECIO_X_VOLUMEN, 3, v_PRECIO_X_SOBRE, 3, v_MONTO_BASE, 3, v_ES_VIGENTE, 1, v_IDTIPO_MONEDA, 1, v_IP, 2, v_IDUSUARIO_PERSONAL, 1, v_IDESTADO_REGISTRO, 1, v_FECHA_ACTIVACION, 2, v_FECHA_DESACTIVACION, 2, v_IDROL_USUARIO, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_datos.EOF = False And cur_datos.BOF = False Then
    '            MsgBox(cur_datos.Fields.Item("MSGBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = "....."
    '    End Try
    '    Return cur_datos
    'End Function
    Public Function fnSP_INSUPD_TARIFA_SUB_CUENTA() As DataTable
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_INSUPD_TARIFA_SUB_CUENTA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_iControl", v_iControl, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("v_IDTARIFA_SUB_CUENTA", v_IDTARIFA_SUB_CUENTA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDPERSONA", v_IDPERSONA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDCLIENTE_SUBCUENTA", v_IDCLIENTE_SUBCUENTA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDCENTRO_COSTO", v_IDCENTRO_COSTO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUNIDAD_AGENCIA", v_IDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDUNIDAD_AGENCIA_DESTINO", v_IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_PRECIO_X_PESO", v_PRECIO_X_PESO, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_VOLUMEN", v_PRECIO_X_VOLUMEN, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_PRECIO_X_SOBRE", v_PRECIO_X_SOBRE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_MONTO_BASE", v_MONTO_BASE, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_ES_VIGENTE", v_ES_VIGENTE, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("v_IDTIPO_MONEDA", v_IDTIPO_MONEDA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", v_IP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDUSUARIO_PERSONAL", v_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IDESTADO_REGISTRO", v_IDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_FECHA_ACTIVACION", v_FECHA_ACTIVACION, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_FECHA_DESACTIVACION", v_FECHA_ACTIVACION, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IDROL_USUARIO", v_IDROL_USUARIO, OracleClient.OracleType.Int32)
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
    'Public Function fnSP_LISTA_TARIFA_PUBLICA_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_LISTA_TARIFA_PUBLICA", 6, v_IDUNIDAD_AGENCIA, 1, v_IDUNIDAD_AGENCIA_DESTINO, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_datos.EOF = False And cur_datos.BOF = False Then
    '            Cg_Monto_Base = cur_datos.Fields.Item("cg_monto_base").Value
    '            Cg_x_Peso = cur_datos.Fields.Item("cg_x_peso").Value
    '            Cg_x_Volumen = cur_datos.Fields.Item("cg_x_volumen").Value
    '            flat = True
    '        Else
    '            MsgBox("No Existen resultados para esta Busqueda....", MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnSP_LISTA_TARIFA_PUBLICA() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_LISTA_TARIFA_PUBLICA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_Origen", v_IDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Destino", v_IDUNIDAD_AGENCIA_DESTINO, OracleClient.OracleType.Int32)
            'Variables de salidas             
            db_bd.AsignarParametro("cur_dato", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable

            If ldt_tmp.Rows.Count > 0 Then
                Cg_Monto_Base = ldt_tmp.Rows(0).Item("cg_monto_base")
                Cg_x_Peso = ldt_tmp.Rows(0).Item("cg_x_peso")
                Cg_x_Volumen = ldt_tmp.Rows(0).Item("cg_x_volumen")
                flat = True
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function fnSP_ANULAR_TARIFARIO_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_ANULAR_TARIFARIO", 8, v_IDTARIFA_SUB_CUENTA, 2, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_datos.EOF = False And cur_datos.BOF = False Then
    '            MsgBox(cur_datos.Fields.Item("MSGBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '            flat = True
    '        Else
    '            MsgBox("No Puede Realizar esta Operacion....", MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnSP_ANULAR_TARIFARIO() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_ANULAR_TARIFARIO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_IDTARIFA_SUB_CUENTA", v_IDTARIFA_SUB_CUENTA, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_IdFuncionario", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_IP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
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
            Else
                MsgBox("No puede realizar está Operación....", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function fnSP_DATOS_TARIFA_SUBCUENTA_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_DATOS_TARIFA_SUBCUENTA", 4, v_IDTARIFA_SUB_CUENTA, 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_datos.EOF = False And cur_datos.BOF = False Then
    '            v_RUC = cur_datos.Fields.Item("Nu_Docu_Suna").Value
    '            v_RAZON_SOCIAL = cur_datos.Fields.Item("Razon_Social").Value
    '            'v_IDTARIFA_SUB_CUENTA = cur_datos.Fields.Item("").Value
    '            'v_IDPERSONA = cur_datos.Fields.Item("").Value
    '            'v_IDCLIENTE_SUBCUENTA = cur_datos.Fields.Item("").Value
    '            v_IDCENTRO_COSTO = cur_datos.Fields.Item("Idcentro_Costo").Value
    '            v_IDUNIDAD_AGENCIA = cur_datos.Fields.Item("Idunidad_Agencia").Value
    '            v_IDUNIDAD_AGENCIA_DESTINO = cur_datos.Fields.Item("Idunidad_Agencia_Destino").Value
    '            v_PRECIO_X_PESO = cur_datos.Fields.Item("Precio_x_Peso").Value
    '            v_PRECIO_X_VOLUMEN = cur_datos.Fields.Item("Precio_x_Volumen").Value
    '            v_PRECIO_X_SOBRE = cur_datos.Fields.Item("Precio_x_Sobre").Value
    '            v_MONTO_BASE = cur_datos.Fields.Item("Monto_Base").Value
    '            v_ES_VIGENTE = cur_datos.Fields.Item("Es_Vigente").Value
    '            v_IDTIPO_MONEDA = 1

    '            Cg_Monto_Base = cur_datos.Fields.Item("Cg_Monto_Base").Value
    '            Cg_x_Peso = cur_datos.Fields.Item("Cg_x_Peso").Value
    '            Cg_x_Volumen = cur_datos.Fields.Item("Cg_x_Volumen").Value

    '            'v_FECHA_ACTIVACION = cur_datos.Fields.Item("").Value
    '            'v_FECHA_DESACTIVACION = cur_datos.Fields.Item("").Value
    '            flat = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnSP_DATOS_TARIFA_SUBCUENTA() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOCARGA.SP_DATOS_TARIFA_SUBCUENTA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_Idtarifa_Sub_Cuenta", v_IDTARIFA_SUB_CUENTA, OracleClient.OracleType.VarChar)
            'Variables de salidas             
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                v_RUC = ldt_tmp.Rows(0).Item("Nu_Docu_Suna")
                v_RAZON_SOCIAL = ldt_tmp.Rows(0).Item("Razon_Social")
                v_IDCENTRO_COSTO = ldt_tmp.Rows(0).Item("Idcentro_Costo")
                v_IDUNIDAD_AGENCIA = ldt_tmp.Rows(0).Item("Idunidad_Agencia")
                v_IDUNIDAD_AGENCIA_DESTINO = ldt_tmp.Rows(0).Item("Idunidad_Agencia_Destino")
                v_PRECIO_X_PESO = ldt_tmp.Rows(0).Item("Precio_x_Peso")
                v_PRECIO_X_VOLUMEN = ldt_tmp.Rows(0).Item("Precio_x_Volumen")
                v_PRECIO_X_SOBRE = ldt_tmp.Rows(0).Item("Precio_x_Sobre")
                v_MONTO_BASE = ldt_tmp.Rows(0).Item("Monto_Base")
                v_ES_VIGENTE = ldt_tmp.Rows(0).Item("Es_Vigente")
                v_IDTIPO_MONEDA = 1
                Cg_Monto_Base = ldt_tmp.Rows(0).Item("Cg_Monto_Base")
                Cg_x_Peso = ldt_tmp.Rows(0).Item("Cg_x_Peso")
                Cg_x_Volumen = ldt_tmp.Rows(0).Item("Cg_x_Volumen")
                v_FECHA_ACTIVACION = ldt_tmp.Rows(0).Item("fecha_activacion")

                flat = True
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
End Class
