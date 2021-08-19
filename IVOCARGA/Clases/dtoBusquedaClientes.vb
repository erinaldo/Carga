Imports AccesoDatos
Public Class dtoBusquedaClientes
    Public iControl As Integer = 0
    Public idPersona As Integer
    Public RUCDNI As String
    Public RAZON_SOCIAL As String
    Public v_fecha_inicio As String
    Public v_fecha_final As String
    Public v_CONTROL_BUSQUEDA As Integer = 0
    'Public rst_Clientes As New ADODB.Recordset
    Public dt_rst_Clientes As New DataTable
    '
    Public IDTIPO As Integer
    Public IDDOC As String
    'Public Function fnBuscarCliente_2009() As ADODB.Recordset
    '    Try
    '        'Dim SQLQuery As Object() = {"PKG_IVOMIGRACION_DATOS.SP_FILTRO_PERSONAS_II", 8, iControl, 1, RUCDNI, 2, RAZON_SOCIAL, 2}
    '        Dim SQLQuery As Object() = {"PKG_IVOMIGRACION_DATOS.SP_FILTRO_PERSONAS_II", 12, iControl, 1, v_fecha_inicio, 2, v_fecha_final, 2, RUCDNI, 2, RAZON_SOCIAL, 2}


    '        rst_Clientes = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        rst_Clientes = Nothing
    '    End Try
    '    Return rst_Clientes
    'End Function
    Public Function fnBuscarCliente() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            '17-10-2011
            'db_bd.CrearComando("PKG_IVOMIGRACION_DATOS.SP_FILTRO_PERSONAS_II", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_IVOMIGRACION_DATOS.SP_FILTRO_PERSONAS_III", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControl, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("v_fecha_inicio", v_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fecha_final", v_fecha_final, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_ruc_Dni", RUCDNI, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_Razon_Social", RAZON_SOCIAL, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)



            'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
            'Dim ds As New DataSet
            'daora.Fill(ds)
            'Dim dv As New DataView
            'dv = ds.Tables(0).DefaultView
            'If ds.Tables(0).Rows.Count < 1 Then
            '    IDUSUARIO_PERSONAL = 0
            '    Exit Sub
            'End If
            'If Not dv.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dv.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
            'If Not dv.Table.Rows(0).IsNull("LOGIN") Then LOGIN = dv.Table.Rows(0)("LOGIN") Else LOGIN = ""
            'If Not dv.Table.Rows(0).IsNull("PASSWORD") Then PASSWORD = dv.Table.Rows(0)("PASSWORD") Else PASSWORD = ""
            'If Not dv.Table.Rows(0).IsNull("IDAGENCIAS") Then IDAGENCIAS = dv.Table.Rows(0)("IDAGENCIAS") Else IDAGENCIAS = 0
            'If Not dv.Table.Rows(0).IsNull("NOMBRE_UNIDAD") Then NOMBRE_UNIDAD = dv.Table.Rows(0)("NOMBRE_UNIDAD") Else NOMBRE_UNIDAD = ""
            'If Not dv.Table.Rows(0).IsNull("IDUNIDAD_AGENCIA") Then IDUNIDAD_AGENCIA = dv.Table.Rows(0)("IDUNIDAD_AGENCIA") Else IDUNIDAD_AGENCIA = 0
            'If Not dv.Table.Rows(0).IsNull("NOMBRE_AGENCIA") Then NOMBRE_AGENCIA = dv.Table.Rows(0)("NOMBRE_AGENCIA") Else NOMBRE_AGENCIA = ""
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            Return db_bd.EjecutarDataTable
            'Manejo de errores 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnBuscarConsignado_2009() As ADODB.Recordset
    '    Try
    '        'Dim SQLQuery As Object() = {"PKG_IVOMIGRACION_DATOS.SP_FILTRO_CONSIGNADO_I", 8, v_fecha_inicio, 2, v_fecha_final, 2, RAZON_SOCIAL, 2}
    '        Dim SQLQuery As Object() = {"PKG_IVOMIGRACION_DATOS.SP_FILTRO_CONSIGNADO_I", 8, v_fecha_inicio, 2, v_fecha_final, 2, RAZON_SOCIAL, 2}
    '        rst_Clientes = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        rst_Clientes = Nothing
    '    End Try
    '    Return rst_Clientes
    'End Function
    Public Function fnBuscarConsignado() As DataTable
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            '17-10-2011
            'db_bd.CrearComando("PKG_IVOMIGRACION_DATOS.SP_FILTRO_CONSIGNADO_I", CommandType.StoredProcedure)
            db_bd.CrearComando("PKG_IVOMIGRACION_DATOS.SP_FILTRO_CONSIGNADO_III", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input  
            db_bd.AsignarParametro("v_fecha_inicio", v_fecha_inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fecha_final", v_fecha_final, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_nombres", RAZON_SOCIAL, OracleClient.OracleType.VarChar)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            ' Ejecuta lo que se ha recuperado 
            Return db_bd.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
