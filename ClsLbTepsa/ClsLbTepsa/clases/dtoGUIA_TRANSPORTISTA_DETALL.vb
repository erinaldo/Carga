Imports AccesoDatos
Public Class dtoGUIA_TRANSPORTISTA_DETALL
    Dim MyCANTIDAD_RECEPCIONAR As Long
    Dim MyIDGUIA_TRANSPORTISTA_DETALL As Long
    Dim MyIDGUIA_TRANSPORTISTA As Long
    Dim MyDESCRIPCION As String
    Dim MyIDGUIAS_ENVIO As Long
    Dim MyCANTIDAD As Long
    Dim MyTOTAL_PESO As Long
    Dim MyTOTAL_VOLUMEN As Long
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDROL_USUARIO As Long
    Dim MyIP As String
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyIPMOD As String
    Dim MyFECHA_REGISTRO As String
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyNRO_DOC As String
    Dim MyIDTIPO_COMPROBANTE As Long
    Dim MyIDCOMPROBANTE As Long
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyIDUNIDAD_AGENCIA As Long
    Public Property IDUNIDAD_AGENCIA() As Long
        Get
            IDUNIDAD_AGENCIA = MyIDUNIDAD_AGENCIA
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA = value
        End Set
    End Property
    Public Property CANTIDAD_RECEPCIONAR() As Long
        Get
            CANTIDAD_RECEPCIONAR = MyCANTIDAD_RECEPCIONAR
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_RECEPCIONAR = value
        End Set
    End Property
    Public Property IDGUIA_TRANSPORTISTA_DETALL() As Long
        Get
            IDGUIA_TRANSPORTISTA_DETALL = MyIDGUIA_TRANSPORTISTA_DETALL
        End Get
        Set(ByVal value As Long)
            MyIDGUIA_TRANSPORTISTA_DETALL = value
        End Set
    End Property
    Public Property IDGUIA_TRANSPORTISTA() As Long
        Get
            IDGUIA_TRANSPORTISTA = MyIDGUIA_TRANSPORTISTA
        End Get
        Set(ByVal value As Long)
            MyIDGUIA_TRANSPORTISTA = value
        End Set
    End Property
    Public Property DESCRIPCION() As String
        Get
            DESCRIPCION = MyDESCRIPCION
        End Get
        Set(ByVal value As String)
            MyDESCRIPCION = value
        End Set
    End Property
    Public Property IDGUIAS_ENVIO() As Long
        Get
            IDGUIAS_ENVIO = MyIDGUIAS_ENVIO
        End Get
        Set(ByVal value As Long)
            MyIDGUIAS_ENVIO = value
        End Set
    End Property
    Public Property CANTIDAD() As Long
        Get
            CANTIDAD = MyCANTIDAD
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD = value
        End Set
    End Property
    Public Property TOTAL_PESO() As Long
        Get
            TOTAL_PESO = MyTOTAL_PESO
        End Get
        Set(ByVal value As Long)
            MyTOTAL_PESO = value
        End Set
    End Property
    Public Property TOTAL_VOLUMEN() As Long
        Get
            TOTAL_VOLUMEN = MyTOTAL_VOLUMEN
        End Get
        Set(ByVal value As Long)
            MyTOTAL_VOLUMEN = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL() As Long
        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL = value
        End Set
    End Property
    Public Property IDROL_USUARIO() As Long
        Get
            IDROL_USUARIO = MyIDROL_USUARIO
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIO = value
        End Set
    End Property
    Public Property IP() As String
        Get
            IP = MyIP
        End Get
        Set(ByVal value As String)
            MyIP = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONALMOD() As Long
        Get
            IDUSUARIO_PERSONALMOD = MyIDUSUARIO_PERSONALMOD
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONALMOD = value
        End Set
    End Property
    Public Property IDROL_USUARIOMOD() As Long
        Get
            IDROL_USUARIOMOD = MyIDROL_USUARIOMOD
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIOMOD = value
        End Set
    End Property
    Public Property IPMOD() As String
        Get
            IPMOD = MyIPMOD
        End Get
        Set(ByVal value As String)
            MyIPMOD = value
        End Set
    End Property
    Public Property FECHA_REGISTRO() As String
        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = value
        End Set
    End Property
    Public Property FECHA_ACTUALIZACION() As String
        Get
            FECHA_ACTUALIZACION = MyFECHA_ACTUALIZACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ACTUALIZACION = value
        End Set
    End Property
    Public Property NRO_DOC() As String
        Get
            NRO_DOC = MyNRO_DOC
        End Get
        Set(ByVal value As String)
            MyNRO_DOC = value
        End Set
    End Property
    Public Property IDTIPO_COMPROBANTE() As Long
        Get
            IDTIPO_COMPROBANTE = MyIDTIPO_COMPROBANTE
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_COMPROBANTE = value
        End Set
    End Property
    Public Property IDCOMPROBANTE() As Long
        Get
            IDCOMPROBANTE = MyIDCOMPROBANTE
        End Get
        Set(ByVal value As Long)
            MyIDCOMPROBANTE = value
        End Set
    End Property
    Public Property IDESTADO_REGISTRO() As Long
        Get
            IDESTADO_REGISTRO = MyIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_REGISTRO = value
        End Set
    End Property
    'Public Function sp_RECEPCIONAR_BULTOS_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_RECEPCIONAR_BULTOS1", 8, _
    '    CType(IDGUIA_TRANSPORTISTA_DETALL, String), 2, _
    '    CANTIDAD_RECEPCIONAR, 1, _
    '    IDUNIDAD_AGENCIA, 1}
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    DA.Fill(dT, Rst)
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        Return dv
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    'Public Function sp_RECEPCIONAR_BULTOS__2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_RECEPCIONAR_BULTOS_", 8, _
    '    CStr(IDGUIA_TRANSPORTISTA_DETALL), 2, _
    '    CANTIDAD_RECEPCIONAR, 1, _
    '    IDUNIDAD_AGENCIA, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    
    'Public Function sp_recepcionar_todos_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset

    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_recepcionar_todos1", 6, _
    '    CType(IDGUIA_TRANSPORTISTA, String), 2, _
    '    IDUNIDAD_AGENCIA, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_recepcionar_todos() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_recepcionar_todos1", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_idguia_transportista", CType(IDGUIA_TRANSPORTISTA, String), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idunidad_agencia", IDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_recepcionar_todos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable
            '
            dv = ldt_tmp.DefaultView
            '
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_RECEPCIONAR_BULTOSII_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_RECEPCIONAR_BULTOS_II", 8, _
    '    CStr(IDGUIA_TRANSPORTISTA_DETALL), 2, _
    '    CANTIDAD_RECEPCIONAR, 1, _
    '    IDUNIDAD_AGENCIA, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function

    'Public Function sp_recepcionar_todosII_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    '
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    '
    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_recepcionar_todosII", 6, _
    '    CType(IDGUIA_TRANSPORTISTA, String), 2, _
    '    IDUNIDAD_AGENCIA, 1}
    '    '
    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    '
    '    DA.Fill(dT, Rst)
    '    '
    '    Try
    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If
    '        '
    '        Return dv
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '        '
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_recepcionar_todosII() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_recepcionar_todosII", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_idguia_transportista", CType(IDGUIA_TRANSPORTISTA, String), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idunidad_agencia", IDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_recepcionar_todos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable
            '
            dv = ldt_tmp.DefaultView
            '
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_recepcionar_todosIII_2009(ByVal VOCONTROLUSUARIO As Object) As DataView

    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset

    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_recepcionar_todosIII", 8, _
    '    CType(IDGUIA_TRANSPORTISTA, String), 2, _
    '    IDUNIDAD_AGENCIA, 1, _
    '    IDUSUARIO_PERSONAL, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function
    Public Function sp_recepcionar_todosIII() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_recepcionar_todosIII", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_idguia_transportista", CType(IDGUIA_TRANSPORTISTA, String), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_idunidad_agencia", IDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_recepcionar_todos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable
            '
            dv = ldt_tmp.DefaultView
            '
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function sp_RECEPCIONAR_BULTOSIII_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Dim dT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Rst As New ADODB.Recordset
    '    Dim varSP_OBJECT() As Object = {"pkg_ivobultos.sp_RECEPCIONAR_BULTOS_III", 10, _
    '    CStr(IDGUIA_TRANSPORTISTA_DETALL), 2, _
    '    CANTIDAD_RECEPCIONAR, 1, _
    '    IDUNIDAD_AGENCIA, 1, _
    '    IDUSUARIO_PERSONAL, 1}

    '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    DA.Fill(dT, Rst)

    '    Try

    '        dv = dT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If Trim(CType(dv.Table.Rows(0)(0), String)) = Trim(CType(-666, String)) Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return dv

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Function
    Public Function sp_RECEPCIONAR_BULTOSIII() As DataView
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            Dim dv As New DataView
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("pkg_ivobultos.sp_RECEPCIONAR_BULTOS_III", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("p_Idguia_Transportista_Detall", CType(IDGUIA_TRANSPORTISTA_DETALL, String), OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("p_Cantidad_Recepcionar", CANTIDAD_RECEPCIONAR, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idunidad_agencia", IDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("p_idusuario_personal", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_RECEPCIONAR_BULTOS", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable
            '
            dv = ldt_tmp.DefaultView
            '
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
