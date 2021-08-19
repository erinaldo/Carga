Imports AccesoDatos
Module ModVOCONTROLUSUARIO
#Region "CONTROL ACCESOS"
    Public dtoCont_usuario As New dtoCONTROLUSUARIOS
    'Public rstLogin As ADODB.Recordset
    'Public rstArea As ADODB.Recordset
    'Public rstRol As ADODB.Recordset

    Public IDcmbUsuario As Collection
    Public IDcmbRol As Collection
    Public IDcmbArea As Collection
#End Region
#Region "VARIABLES" 'orden de las variables en  nuestro procedure 
    'query.Format(_T("PKG_CONTROL_USUARIO.SP_LIST_INICIAL_USUARIO"));

    'Public rst_usuario_Personal As ADODB.Recordset
    'Public rst_EstadoCivil As ADODB.Recordset
    'Public rst_TipoDocIndentiadad As ADODB.Recordset
    'Public rst_Sexo As ADODB.Recordset
    'Public rst_Pais As ADODB.Recordset
    'Public rst_Departamento As ADODB.Recordset
    'Public rst_Provincia As ADODB.Recordset
    'Public rst_Distrito As ADODB.Recordset
    'Public rst_TipoUsuario As ADODB.Recordset
    'Public rst_Turnos_Agencia As ADODB.Recordset
    '''''
    Public dt_rst_usuario_Personal As New DataTable
    Public dt_rst_EstadoCivil As New DataTable
    Public dt_rst_TipoDocIndentiadad As New DataTable
    Public dt_rst_Sexo As New DataTable
    Public dt_rst_Pais As New DataTable
    Public dt_rst_Departamento As New DataTable
    Public dt_rst_Provincia As New DataTable
    Public dt_rst_Distrito As New DataTable
    Public dt_rst_TipoUsuario As New DataTable ' Realmente se obtiene las ciudades 
    Public dt_rst_Turnos_Agencia As New DataTable
#End Region
#Region "VARIABLES ARRAY IDs" 'Los Id para nuestros cmb... 
    Public coll_EstadoCivil As New Collection()
    Public coll_TipoDocIndentiadad As New Collection()
    Public coll_Sexo As New Collection()
    Public coll_Pais As New Collection()
    Public coll_Departamento As New Collection()
    Public coll_Provincia As New Collection()
    Public coll_Distrito As New Collection()
    Public coll_TipoUsuario As New Collection()
    Public coll_Turnos_Agencia As New Collection()
    Public ListRoles As New Collection()
    Public coll_Roles_Usuario As New Collection()
    Public coll_Roles_Defecto As New Collection()
#End Region
#Region "FUNCIONES IDISPATHS **"
    'Public Sub ListaDatosUsuarios_2009(ByVal iControl As Integer, ByVal idUsuarios As Integer)
    '    Try
    '        rst_EstadoCivil = Nothing
    '        rst_TipoDocIndentiadad = Nothing
    '        rst_Sexo = Nothing
    '        rst_Pais = Nothing
    '        rst_Departamento = Nothing
    '        rst_Provincia = Nothing
    '        rst_Distrito = Nothing
    '        rst_TipoUsuario = Nothing
    '        '
    '        rst = VOCONTROLUSUARIO.ListaDatosUsuarios(1, -1)
    '        '
    '        rst_EstadoCivil = rst.NextRecordset
    '        rst_TipoDocIndentiadad = rst.NextRecordset
    '        rst_Sexo = rst.NextRecordset
    '        rst_Pais = rst.NextRecordset
    '        rst_Departamento = rst.NextRecordset
    '        rst_Provincia = rst.NextRecordset
    '        rst_Distrito = rst.NextRecordset
    '        rst_TipoUsuario = rst.NextRecordset   ' Realmente se obtiene las ciudades 
    '        rst_Turnos_Agencia = rst.NextRecordset
    '    Catch ex As Exception
    '        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub
    Public Sub ListaDatosUsuarios(ByVal iControl As Integer, ByVal idUsuarios As Integer)
        Dim db_bd As New BaseDatos
        Try
            '
            Dim ll_error As Long
            Dim lobj_tmp As New Object
            'Iniciando variables 
            dt_rst_EstadoCivil = Nothing
            dt_rst_EstadoCivil = New DataTable
            ' 
            dt_rst_TipoDocIndentiadad = Nothing
            dt_rst_TipoDocIndentiadad = New DataTable
            '
            dt_rst_Sexo = Nothing
            dt_rst_Sexo = New DataTable
            '
            dt_rst_Pais = Nothing
            dt_rst_Pais = New DataTable
            '
            dt_rst_Departamento = Nothing
            dt_rst_Departamento = New DataTable
            '
            dt_rst_Provincia = Nothing
            dt_rst_Provincia = New DataTable
            '
            dt_rst_Distrito = Nothing
            dt_rst_Distrito = New DataTable
            '
            dt_rst_TipoUsuario = Nothing
            dt_rst_TipoUsuario = New DataTable
            '
            dt_rst_Turnos_Agencia = Nothing
            dt_rst_Turnos_Agencia = New DataTable

            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCONTROLUSUARIO.SP_LISTA_INICIAL_USUARIO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            db_bd.AsignarParametro("err", OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("cur_usuario_Personal", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_usuario_Personal", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_EstadoCivil", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Sexo", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Pais", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Departamento", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Provincia", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Distrito", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_TipoUsuario", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_TurnoAgencia", OracleClient.OracleType.Cursor)
            '
            db_bd.EjecutarComando()
            '            
            If db_bd.Parametros.Length > 0 Then
                ll_error = IIf(db_bd.Parametros(0) Is DBNull.Value, 0, db_bd.Parametros(0)) ' Para verificar que valor sale 
                '
                dt_rst_EstadoCivil = IIf(db_bd.Parametros(2) = Nothing, dt_rst_EstadoCivil, CType(db_bd.Parametros(2), DataTable)) ' Para verificar que valor sale 
                dt_rst_TipoDocIndentiadad = IIf(db_bd.Parametros(3) = Nothing, dt_rst_TipoDocIndentiadad, CType(db_bd.Parametros(3), DataTable))
                dt_rst_Sexo = IIf(db_bd.Parametros(4) = Nothing, dt_rst_Sexo, CType(db_bd.Parametros(4), DataTable))
                dt_rst_Pais = IIf(db_bd.Parametros(5) = Nothing, dt_rst_Pais, CType(db_bd.Parametros(5), DataTable))
                dt_rst_Departamento = IIf(db_bd.Parametros(6) = Nothing, dt_rst_Departamento, CType(db_bd.Parametros(6), DataTable))
                dt_rst_Provincia = IIf(db_bd.Parametros(7) = Nothing, dt_rst_Provincia, CType(db_bd.Parametros(7), DataTable))
                dt_rst_Distrito = IIf(db_bd.Parametros(8) = Nothing, dt_rst_Distrito, CType(db_bd.Parametros(8), DataTable))
                dt_rst_TipoUsuario = IIf(db_bd.Parametros(9) = Nothing, dt_rst_TipoUsuario, CType(db_bd.Parametros(9), DataTable))
                dt_rst_Turnos_Agencia = IIf(db_bd.Parametros(10) = Nothing, dt_rst_TipoUsuario, CType(db_bd.Parametros(10), DataTable))
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try


    End Sub
    'Public Sub INSUPD_USUARIO_PERSONAL_2009(ByVal dto As dtoCONTROLUSUARIOS)
    '    Try

    '    Catch ex As Exception

    '    End Try
    'End Sub
    'ref: Realiza la insercion y modificacion de un usuario
    Public Sub InsertUpdateUsuarioPersona2009(ByVal objDto() As Object)
        'Try
        '    rst_usuario_Personal = Nothing
        '    rst_usuario_Personal = VOCONTROLUSUARIO.InsertUpdateUsuarioPersona(objDto)
        'Catch ex As Exception
        '    MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        'End Try
    End Sub
    Public Sub ListaUsuarios(ByVal idAreaSistema As Integer)
        Try
            'rstLogin = Nothing
            'rstArea = Nothing
            'rstRol = Nothing
            'rstArea = VOCONTROLUSUARIO.ListaUsuarios(idAreaSistema) 'Retorna todos los Iten de la clase CControlUser
            ' rstLogin = rstArea.NextRecordset
            ' rstRol = rstArea.NextRecordset
            'MsgBox(rstRol.Fields(0).Value, MsgBoxStyle.Critical, "Seguridad ")

        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    'Public Sub InsertUpdateDatos(ByVal datos(,) As Object)
    '    Try
    '    Catch ex As Exception
    '        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub

#End Region
    '.....
    '.....
End Module
