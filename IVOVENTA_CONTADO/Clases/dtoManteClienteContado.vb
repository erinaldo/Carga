Imports AccesoDatos
Public Class dtoManteClienteContado
#Region "VARIABLES"
    Public iCONTROLINSUP As Integer
    Public iCONTROTABLAS As Integer
    Public v_idpersona As Integer
    Public v_idContacto As Integer
    Public v_NroDoc As String
    Public v_Rason_Social As String
    Public v_idDireccion As Integer
    Public v_Direccion As String
    Public v_idunidad_agencia As Integer
    Public v_idDistrito As Integer
    Public v_sexo As String
    Public v_fecha_nacimiento As String
    Public v_telefono As String
    Public v_porcentage_descuento As Double
    Public v_base As Integer = 1
    Public v_Facturacion As Integer = 0

    Public v_idProvedor As Integer = 0
    Public v_Mail As String = 0

    Public Envio_Mensageria As Integer

#End Region
#Region "CURSORES"
    'Public cur_datos As New ADODB.Recordset
    'Public cur_tipo_celulares As New ADODB.Recordset
    'Public cur_celulares As New ADODB.Recordset
    'Public cur_E_Mail As New ADODB.Recordset
    'Dim Err_datos As New ADODB.Recordset
#End Region
#Region "Datatable"
    Public dt_cur_datos As New DataTable
    Public dt_cur_tipo_celulares As New DataTable
    Public dt_cur_celulares As New DataTable
    Public dt_cur_E_Mail As New DataTable
    Dim dt_Err_datos As New DataTable
#End Region
#Region "METODOS"
    Public Function fnClearDTO() As Boolean
        Try
            iCONTROLINSUP = 0
            iCONTROTABLAS = 0
            v_idpersona = 0
            v_idContacto = 0
            v_NroDoc = ""
            v_Rason_Social = ""
            v_idDireccion = 0
            v_Direccion = ""
            v_idunidad_agencia = 0
            v_idDistrito = 0
            v_sexo = ""
            v_fecha_nacimiento = ""
            v_telefono = ""
            v_porcentage_descuento = 0
        Catch ex As Exception
        End Try
        Return False
    End Function
    'Public Function fnManteClientes_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        iCONTROLINSUP = 2
    '        v_Direccion = IIf(v_Direccion <> "", v_Direccion, "@")
    '        v_telefono = IIf(v_telefono <> "" And v_telefono <> "0", v_telefono, "@")

    '        'Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_INSUPD_CLIENTE", 32, iCONTROLINSUP, 1, iCONTROTABLAS, 1, v_idpersona, 1, v_idContacto, 1, v_NroDoc, 2, v_Rason_Social, 2, v_idDireccion, 1, v_Direccion, 2, v_idunidad_agencia, 1, v_idDistrito, 1, v_sexo, 2, v_fecha_nacimiento, 2, v_telefono, 2, v_porcentage_descuento, 3, v_base, 1}
    '        Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_INSUPD_CLIENTE_I", 32, iCONTROLINSUP, 1, iCONTROTABLAS, 1, v_idpersona.ToString(), 2, v_idContacto.ToString(), 2, v_NroDoc, 2, v_Rason_Social, 2, v_idDireccion.ToString(), 2, v_Direccion, 2, v_idunidad_agencia, 1, v_idDistrito, 1, v_sexo, 2, v_fecha_nacimiento, 2, v_telefono, 2, v_porcentage_descuento, 3, v_base, 1}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If cur_datos.State = 1 Then
    '            If cur_datos.EOF = False And cur_datos.BOF = False Then
    '                MsgBox(cur_datos.Fields.Item(1).Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '                If cur_datos.Fields.Item(0).Value = 1 Then
    '                    flag = True
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnManteClientes() As Boolean
        Dim flag As Boolean = False
        iCONTROLINSUP = 2
        v_Direccion = IIf(v_Direccion <> "", v_Direccion, "@")
        v_telefono = IIf(v_telefono <> "" And v_telefono <> "0", v_telefono, "@")
        '
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_INSUPD_CLIENTE_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROLINSUP", iCONTROLINSUP, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iCONTROTABLAS", iCONTROTABLAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("x_idpersona", v_idpersona.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("x_idContacto", v_idContacto.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_NroDoc", v_NroDoc, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Rason_Social", v_Rason_Social, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idDireccion", v_idDireccion.ToString(), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Direccion", v_Direccion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_idunidad_agencia", v_idunidad_agencia, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idDistrito", v_idDistrito, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_sexo", v_sexo, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fecha_nacimiento", v_fecha_nacimiento, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_telefono", v_telefono, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_porcentage_descuento", v_porcentage_descuento, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_base", v_base, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("Err_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                MsgBox(lds_tmp.Tables(0).Rows(0).Item(1), MsgBoxStyle.Information, "Seguridad Sistema")
                If lds_tmp.Tables(0).Rows(0).Item(0) = 1 Then
                    flag = True
                End If
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        '
        Return flag
    End Function
    'Public Function fnListaContactoPersona_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        'Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_LISTAR_CONTACTOS", 6, iCONTROTABLAS, 1, v_idContacto, 1}
    '        Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_LISTAR_CONTACTOS_I", 6, iCONTROTABLAS, 1, v_idContacto.ToString(), 2}
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If cur_datos.State = 1 Then
    '            If cur_datos.EOF = False And cur_datos.BOF = False Then
    '                flag = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = True
    '    End Try
    '    Return flag
    'End Function
    Public Function fnListaContactoPersona() As Boolean
        Dim flag As Boolean = False
        '
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_LISTAR_CONTACTOS_I", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iCONTROTABLAS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("x_idContacto_Persona", v_idContacto.ToString(), OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Movil", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_celulares", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_email", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                flag = True
                dt_cur_datos = lds_tmp.Tables(0)
                dt_cur_tipo_celulares = lds_tmp.Tables(1)
                dt_cur_celulares = lds_tmp.Tables(2)
                dt_cur_E_Mail = lds_tmp.Tables(3)
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
#End Region
End Class
