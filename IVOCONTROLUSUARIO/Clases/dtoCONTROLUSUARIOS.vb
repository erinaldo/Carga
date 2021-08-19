'Imports System
'Imports System.Net
'Imports System.Net.Sockets
'Imports System.Threading
'Imports System.Text
'Imports System.IO
Imports AccesoDatos
'ref:
'Definiendo los parametros para el acceso al sistema...
'el IP ya esta en el lado del cliente...
'la definicion de los parametros de traida son
'    m_iIdUsuario donde
'm : de varaible miembro
'i : es el tipo de datos
'IdUsuario descripcion de la varaible asociado al cámpo de la base de datos
Public Class dtoCONTROLUSUARIOS
#Region "VARIABLES"
    Private m_iIdLogin As Integer
    Private m_iIdLogin2 As Integer
    Public m_iNombreAgencia As String
    Public m_iNombreUnidadAgencia As String
    '
    Private m_sNameLogin As String
    Public m_idciudad As Integer
    '
    Public dfecha_sistema As String
    Public m_iIdAreaSistema As Integer
    Public m_sNameAreaSistema As String
    'Public m_iOficinaVenta As Integer 'Nuevo Codigo Agregado
    '
    Public m_iIdAgencia As Integer
    Public m_iIdAgenciaReal As Integer
    Public m_iIdUnidadAgencia As Integer
    Public m_iIdUnidadAgenciaReal As Integer
    Public m_iIdRol As Integer
    Public m_sRol As String
    Public m_sPassword As String
    Public m_sIP As String 'definida en el lado del usuario
    Public m_sIP2 As String 'definida en el lado del usuario
    Public m_sMSG As String
    Public m_sFecha As String
    '
    Public iCONTROL As Integer
    Public iIDTURNOS_AGENCIA As Integer
    Public iIDAGENCIAS As Integer
    Public iIDUSUARIO_PERSONAL As Integer
    'iIP in T_AGENCIA_USUARIOS.IP%type,                      
    'Public iIDROL_USUARIO As Integer
    Public iNOMPER As String
    Public iAPEMAT As String
    Public iAPEPAT As String
    Public iIDTIPO_DOC_IDENTIDAD As Integer
    Public iNRODOC As String
    Public iFECHA_NACIMIENTO As String
    Public iIDTIPO_USUARIO_PERSONAL As Integer
    Public iLOGIN As String
    Public iPASSWORD As String
    Public iE_MAIL As String
    Public iTELEFONO As String
    Public iCELULAR As String
    Public iDIRECCION As String
    Public iIDUSUARIO_CREADOR As Integer
    Public iIDAREA_SISTEMA As Integer
    Public iIDROL_CREADOR As Integer
    Public iIDSEXO As Integer
    Public iIDESTADO_REGISTRO As Integer
    Public iIDDISTRITO As Integer
    Public iIDPROVINCIA As Integer
    Public iIDDEPARTAMENTO As Integer
    Public iIDPAIS As Integer
    Public iFOTO As String
    Public iIDUBIGEO As Integer
    Public iIDESTADO_CIVIL As Integer
    Public iFAX As String
    Public snro_licencia As String
    '
    Public iIGV As Double = 0.18 ' Inicializando el impuesto
    Public vImpuesto As Double = 0.18 ' Ritcher
    '
    Public iRPM As String
    Public iBlobFoto() As Byte
    Public iIDUSUARIO_MODIFICADOR As Integer

    Public idListRoles As String
    'Public rst_usuarios As ADODB.Recordset
    Public dt_usuarios As DataTable
    'Public rst_User_Modicado As ADODB.Recordset

    Public iIDOTRAS_AGENCIAS As Integer
    Public iind_autoriza_entrega As Integer

    Public dt_Rol_Usuario As DataTable
    Public dt_Rol_Usuario2 As DataTable

    Public TipoIp As Integer
    Public RolDefecto As Integer

    'hlamas 02-02-2016
    Public FormatoBoleta As String
    Public huella As Integer
    Public win As Integer

    Public ciudad As Integer
    Public agencia As Integer

    'hlamas 03-11-2017
    Public Portavalor As Integer

    'hlamas 25-05-2018
    Public CentroCosto As Integer
    Public CentroCostoDescripcion As String

    Public CodigoPlanilla As String

    'hlamas 10-08-2018
    Public Cierre As Integer

    'hlamas 05-09-2018
    Public marcador As Integer

    'hlamas 09-07-2019
    Public FormatoTicket As Integer

    Private m_codAgenciaSisvyr As String
#End Region
#Region "INICIO SESION"
    '*****************INICO DE SECION
    'Public rst_Rol_Usuario As ADODB.Recordset
    Public dt_rst_Rol_Usuario As DataTable

    'Public cur_Datos_Generales_Server As New ADODB.Recordset
    Public dt_cur_Datos_Generales_Server As DataTable

    'Public cur_Menu_Usuario As New ADODB.Recordset
    Public dt_cur_Menu_Usuario As DataTable

    'Public cur_Formularios_Usuario As New ADODB.Recordset
    Public dt_cur_Formularios_Usuario As DataTable

    Public dt_cur_cpu As DataTable

    'Public cur_Error As New ADODB.Recordset
    Public dt_cur_Error As DataTable
#End Region

#Region "METODOS"
    Public Function tmpSuma() As Integer
        tmpSuma = m_iIdLogin + m_iIdRol
    End Function

    'Public Function GetUsuarioEntregaCargaSinValidar2009() As Boolean
    'Dim bExito As Boolean
    'Try
    '    'Omendoza 15-10-2008
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLUSUARIO.SP_valida_usuario_entrega", 4, iIDUSUARIO_PERSONAL, 1}
    '    rst_usuarios = Nothing
    '    rst_usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    If rst_usuarios.EOF = False And rst_usuarios.BOF = False Then
    '        If IsDBNull(rst_usuarios.Fields.Item(0).Value) Then
    '            iind_autoriza_entrega = 0
    '        Else
    '            iind_autoriza_entrega = Int(rst_usuarios.Fields.Item(0).Value)
    '        End If
    '        bExito = True
    '    Else
    '        bExito = False
    '    End If
    '    '
    'Catch ex As Exception
    '    bExito = False
    '    MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    'End Try
    'Return bExito
    'End Function

    Public Function GetUsuarioEntregaCargaSinValidar() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_valida_usuario_entrega", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idUser", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_Usuario", OracleClient.OracleType.Cursor)
            db.Desconectar()
            dt_usuarios = db.EjecutarDataTable
            If dt_usuarios.Rows.Count > 0 Then
                If IsDBNull(dt_usuarios.Rows(0).Item(0)) Then
                    iind_autoriza_entrega = 0
                Else
                    iind_autoriza_entrega = Int(dt_usuarios.Rows(0).Item(0))
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function Grabar2009() As Boolean
    'Dim flat As Boolean = True
    'Dim mensaje As String
    'Dim usuario_personal As Long
    'Try
    '    If idListRoles <> "" Then
    '        iIDUSUARIO_MODIFICADOR = m_iIdLogin
    '        m_sIP = dtoUSUARIOS.IP
    '        'hlamas 15-10-2008
    '        'Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLUSUARIO.INSUPD_USUARIO_PERSONAL", 74, iCONTROL, 1, iIDTURNOS_AGENCIA, 1, iIDAGENCIAS, 1, iIDUSUARIO_PERSONAL, 1, m_sIP, 2, m_iIdRol, 1, iNOMPER, 2, iAPEMAT, 2, iAPEPAT, 2, iIDTIPO_DOC_IDENTIDAD, 1, iNRODOC, 2, iFECHA_NACIMIENTO, 4, iIDTIPO_USUARIO_PERSONAL, 1, iLOGIN, 2, iPASSWORD, 2, iE_MAIL, 2, iTELEFONO, 2, iCELULAR, 2, iDIRECCION, 2, iIDUSUARIO_CREADOR, 1, iIDAREA_SISTEMA, 1, iIDROL_CREADOR, 1, iIDSEXO, 1, iIDESTADO_REGISTRO, 1, iIDDISTRITO, 1, iIDPROVINCIA, 1, iIDDEPARTAMENTO, 1, iIDPAIS, 1, iIDUBIGEO, 1, iFOTO, 5, iIDESTADO_CIVIL, 1, iFAX, 2, iRPM, 2, iIDUSUARIO_MODIFICADOR, 1, idListRoles, 2, snro_licencia, 2}
    '        Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLUSUARIO.INSUPD_USUARIO_PERSONAL_1", 78, iCONTROL, 1, iIDTURNOS_AGENCIA, 1, iIDAGENCIAS, 1, iIDUSUARIO_PERSONAL, 1, m_sIP, 2, m_iIdRol, 1, iNOMPER, 2, iAPEMAT, 2, iAPEPAT, 2, iIDTIPO_DOC_IDENTIDAD, 1, iNRODOC, 2, iFECHA_NACIMIENTO, 4, iIDTIPO_USUARIO_PERSONAL, 1, iLOGIN, 2, iPASSWORD, 2, iE_MAIL, 2, iTELEFONO, 2, iCELULAR, 2, iDIRECCION, 2, iIDUSUARIO_CREADOR, 1, iIDAREA_SISTEMA, 1, iIDROL_CREADOR, 1, iIDSEXO, 1, iIDESTADO_REGISTRO, 1, iIDDISTRITO, 1, iIDPROVINCIA, 1, iIDDEPARTAMENTO, 1, iIDPAIS, 1, iIDUBIGEO, 1, iFOTO, 5, iIDESTADO_CIVIL, 1, iFAX, 2, iRPM, 2, iIDUSUARIO_MODIFICADOR, 1, idListRoles, 2, snro_licencia, 2, iIDOTRAS_AGENCIAS, 1, iind_autoriza_entrega, 1}
    '        rst = Nothing
    '        rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        'If rst.EOF = False And rst.BOF = False Then
    '        'rst.MoveFirst()                
    '        '
    '        MsgBox(rst.Fields.Item(1).Value.ToString(), 64, "Seguridad Sistema")
    '        dtoUSUARIOS.iIDUSUARIO_PERSONAL = Int(rst.Fields.Item(0).Value.ToString())
    '        '
    '        rst_User_Modicado = rst.NextRecordset
    '        dtoLista_Usuario.SetCliente(rst_User_Modicado)
    '        'Else
    '        '    MsgBox("El Registro ya existe, verifique su DNI", MsgBoxStyle.Information, "Seguridad Sistema")
    '        '    flat = False
    '        'End If
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    flat = False
    'End Try
    'Return flat
    'End Function

    Public Function Grabar() As Boolean
        If idListRoles <> "" Then
            Try
                Dim flat As Boolean = True
                Dim mensaje As String
                Dim usuario_personal As Long
                iIDUSUARIO_MODIFICADOR = m_iIdLogin
                m_sIP = dtoUSUARIOS.IP

                Dim db As New BaseDatos
                db.Conectar()
                'acceso 21/04/2010
                'db.CrearComando("PKG_IVOCONTROLUSUARIO.INSUPD_USUARIO_PERSONAL_1", CommandType.StoredProcedure)
                'db.CrearComando("PKG_IVOCONTROLUSUARIO.INSUPD_USUARIO_PERSONAL_2", CommandType.StoredProcedure)
                db.CrearComando("PKG_IVOCONTROLUSUARIO.INSUPD_USUARIO_PERSONAL_2", CommandType.StoredProcedure)
                db.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIDTURNOS_AGENCIA", iIDTURNOS_AGENCIA, OracleClient.OracleType.Int32)
                'db.AsignarParametro("iIDAGENCIAS", iIDAGENCIAS, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIDUSUARIO_PERSONAL", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIP", m_sIP, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iIDROL_USUARIO", m_iIdRol, OracleClient.OracleType.Int32)
                db.AsignarParametro("iNOMPER", iNOMPER, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iAPEMAT", iAPEMAT, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iAPEPAT", iAPEPAT, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iIDTIPO_DOC_IDENTIDAD", iIDTIPO_DOC_IDENTIDAD, OracleClient.OracleType.Int32)
                db.AsignarParametro("iNRODOC", iNRODOC, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iFECHA_NACIMIENTO", iFECHA_NACIMIENTO, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iIDTIPO_USUARIO_PERSONAL", iIDTIPO_USUARIO_PERSONAL, OracleClient.OracleType.Int32)
                db.AsignarParametro("iLOGIN", iLOGIN, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iPASSWORD", iPASSWORD, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iE_MAIL", iE_MAIL, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iTELEFONO", iTELEFONO, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iCELULAR", iCELULAR, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iDIRECCION", iDIRECCION, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iIDUSUARIO_CREADOR", iIDUSUARIO_CREADOR, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIDAREA_SISTEMA", iIDAREA_SISTEMA, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIDROL_CREADOR", iIDROL_CREADOR, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIDSEXO", iIDSEXO, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIDESTADO_REGISTRO", iIDESTADO_REGISTRO, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIDDISTRITO", iIDDISTRITO, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIDPROVINCIA", iIDPROVINCIA, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIDDEPARTAMENTO", iIDDEPARTAMENTO, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIDPAIS", iIDPAIS, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIDUBIGEO", iIDUBIGEO, OracleClient.OracleType.Int32)
                db.AsignarParametro("iFOTO", iFOTO, OracleClient.OracleType.Blob)
                db.AsignarParametro("iIDESTADO_CIVIL", iIDESTADO_CIVIL, OracleClient.OracleType.Int32)
                db.AsignarParametro("iFAX", iFAX, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iRPM", iRPM, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iIDUSUARIO_MODIFICADOR", iIDUSUARIO_MODIFICADOR, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIDSRoles", idListRoles, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iinro_licencia", snro_licencia, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iIDOTRAS_AGENCIAS", iIDOTRAS_AGENCIAS, OracleClient.OracleType.Int32)
                db.AsignarParametro("iind_autoriza_entrega", iind_autoriza_entrega, OracleClient.OracleType.Int32)
                db.AsignarParametro("iRolDefecto", RolDefecto, OracleClient.OracleType.Int32)
                db.AsignarParametro("cur_usuario_Personal", OracleClient.OracleType.Cursor)
                db.AsignarParametro("cur_usuario_Modificado", OracleClient.OracleType.Cursor)
                db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
                db.Desconectar()
                Dim ds As DataSet = db.EjecutarDataSet
                Dim rst As DataTable = ds.Tables(0)
                MsgBox(rst.Rows(0).Item(1).ToString(), 64, "Seguridad Sistema")
                dtoUSUARIOS.iIDUSUARIO_PERSONAL = Int(rst.Rows(0).Item(0).ToString())
                Dim rst_User_Modicado As DataTable = ds.Tables(1)
                dtoLista_Usuario.SetCliente(rst_User_Modicado)
                Return True
            Catch ex As Excepcion
                'Return False
                Throw New Exception(ex.Message)
            End Try
        End If
    End Function
    'Public Function GetUsuario2009() As Boolean
    'Try
    '    'hlamas 15-10-2008
    '    'Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLUSUARIO.SP_DATOS_USUARIO_ROL", 4, iIDUSUARIO_PERSONAL, 1}
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLUSUARIO.SP_DATOS_USUARIO_ROL_1", 4, iIDUSUARIO_PERSONAL, 1}
    '    rst_usuarios = Nothing
    '    rst_usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    '            If rst_usuarios.EOF = False And rst_usuarios.BOF = False Then

    '    iAPEPAT = rst_usuarios.Fields.Item(0).Value.ToString()
    '    iAPEMAT = rst_usuarios.Fields.Item(1).Value.ToString()
    '    iNOMPER = rst_usuarios.Fields.Item(2).Value.ToString()
    '    iFECHA_NACIMIENTO = rst_usuarios.Fields.Item(3).Value.ToString()

    '    iIDESTADO_CIVIL = Int(rst_usuarios.Fields.Item(4).Value)
    '    iIDSEXO = Int(rst_usuarios.Fields.Item(5).Value)

    '    iIDTIPO_DOC_IDENTIDAD = Int(rst_usuarios.Fields.Item(6).Value)
    '    iNRODOC = rst_usuarios.Fields.Item(7).Value.ToString()
    '    iDIRECCION = rst_usuarios.Fields.Item(8).Value.ToString()

    '    iIDPAIS = Int(rst_usuarios.Fields.Item(9).Value)
    '    iIDDEPARTAMENTO = Int(rst_usuarios.Fields.Item(10).Value)
    '    iIDPROVINCIA = Int(rst_usuarios.Fields.Item(11).Value)
    '    iIDDISTRITO = Int(rst_usuarios.Fields.Item(12).Value)

    '    iTELEFONO = rst_usuarios.Fields.Item(13).Value.ToString()
    '    iCELULAR = rst_usuarios.Fields.Item(14).Value.ToString()
    '    'iIDTIPO_USUARIO_PERSONAL = rst_usuarios.Fields.Item(0).Value
    '    iE_MAIL = rst_usuarios.Fields.Item(15).Value.ToString()
    '    iFAX = rst_usuarios.Fields.Item(16).Value.ToString()
    '    iRPM = rst_usuarios.Fields.Item(17).Value.ToString()

    '    iLOGIN = rst_usuarios.Fields.Item(18).Value.ToString()
    '    iPASSWORD = rst_usuarios.Fields.Item(19).Value.ToString()
    '    iIDESTADO_REGISTRO = Int(rst_usuarios.Fields.Item(20).Value)
    '    If IsNothing(rst_usuarios.Fields.Item(21).Value) = True Then
    '        iBlobFoto = rst_usuarios.Fields.Item(21).Value
    '    End If
    '    '
    '    iIDTIPO_USUARIO_PERSONAL = Int(rst_usuarios.Fields.Item(22).Value)
    '    snro_licencia = CType(rst_usuarios.Fields.Item(23).Value, String)

    '    If IsDBNull(rst_usuarios.Fields.Item(24).Value) Then
    '        iIDOTRAS_AGENCIAS = 0
    '    Else
    '        iIDOTRAS_AGENCIAS = Int(rst_usuarios.Fields.Item(24).Value)
    '    End If
    '    '
    '    If IsDBNull(rst_usuarios.Fields.Item(25).Value) Then
    '        iind_autoriza_entrega = 0
    '    Else
    '        iind_autoriza_entrega = Int(rst_usuarios.Fields.Item(25).Value)
    '    End If
    '    '
    '    'rst_Rol_Usuario = rst_usuarios.NextRecordset
    '    GetUsuario2009 = True
    '    'Else
    '    'MsgBox("Error en el filtro de Datos, revise sus datos", MsgBoxStyle.Critical, "Seguridad Sistema")
    '    'GetUsuario = False
    '    'End If
    '    '

    '    '
    'Catch ex As Exception
    '    MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    'End Try
    'End Function

    Public Function GetUsuario() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_DATOS_USUARIO_ROL_2", CommandType.StoredProcedure)
            db.AsignarParametro("idUser", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_Usuario", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Roles", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Roles2", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Dim rst_usuarios As DataTable = ds.Tables(0)

            iAPEPAT = rst_usuarios.Rows(0).Item(0).ToString()
            iAPEMAT = rst_usuarios.Rows(0).Item(1).ToString()
            iNOMPER = rst_usuarios.Rows(0).Item(2).ToString()
            iFECHA_NACIMIENTO = rst_usuarios.Rows(0).Item(3).ToString()
            iIDESTADO_CIVIL = Int(rst_usuarios.Rows(0).Item(4).ToString)
            iIDSEXO = Int(rst_usuarios.Rows(0).Item(5).ToString)
            iIDTIPO_DOC_IDENTIDAD = Int(rst_usuarios.Rows(0).Item(6).ToString)
            iNRODOC = rst_usuarios.Rows(0).Item(7).ToString()
            iDIRECCION = rst_usuarios.Rows(0).Item(8).ToString()
            iIDPAIS = Int(rst_usuarios.Rows(0).Item(9).ToString)
            iIDDEPARTAMENTO = Int(rst_usuarios.Rows(0).Item(10).ToString)
            iIDPROVINCIA = Int(rst_usuarios.Rows(0).Item(11).ToString)
            iIDDISTRITO = Int(rst_usuarios.Rows(0).Item(12).ToString)
            iTELEFONO = rst_usuarios.Rows(0).Item(13).ToString()
            iCELULAR = rst_usuarios.Rows(0).Item(14).ToString()
            iE_MAIL = rst_usuarios.Rows(0).Item(15).ToString()
            iFAX = rst_usuarios.Rows(0).Item(16).ToString()
            iRPM = rst_usuarios.Rows(0).Item(17).ToString()
            iLOGIN = rst_usuarios.Rows(0).Item(18).ToString()
            iPASSWORD = rst_usuarios.Rows(0).Item(19).ToString()
            iIDESTADO_REGISTRO = Int(rst_usuarios.Rows(0).Item(20).ToString)
            If IsNothing(rst_usuarios.Rows(0).Item(21).ToString) = True Then
                iBlobFoto = rst_usuarios.Rows(0).Item(21)
            End If
            iIDTIPO_USUARIO_PERSONAL = Int(rst_usuarios.Rows(0).Item(22).ToString)
            snro_licencia = CType(rst_usuarios.Rows(0).Item(23), String)

            If IsDBNull(rst_usuarios.Rows(0).Item(24)) Then
                iIDOTRAS_AGENCIAS = 0
            Else
                iIDOTRAS_AGENCIAS = Int(rst_usuarios.Rows(0).Item(24))
            End If
            '
            If IsDBNull(rst_usuarios.Rows(0).Item(25)) Then
                iind_autoriza_entrega = 0
            Else
                iind_autoriza_entrega = Int(rst_usuarios.Rows(0).Item(25))
            End If
            '
            'rst_Rol_Usuario = rst_usuarios.NextRecordset
            dt_Rol_Usuario = ds.Tables(1)
            dt_Rol_Usuario2 = ds.Tables(2)
            RolDefecto = Int(rst_usuarios.Rows(0).Item("rol"))
            Return True
        Catch ex As Excepcion
            'MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function SetEliminar2009() As Boolean
    'Dim var As Boolean = True
    'Try
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLUSUARIO.SP_ELIMINAR_USUARIO", 6, iIDUSUARIO_PERSONAL, 1, iIDESTADO_REGISTRO, 1}
    '    rst_usuarios = Nothing
    '    rst_usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    If rst_usuarios.EOF = False And rst_usuarios.BOF = False Then
    '        MsgBox(rst_usuarios.Fields.Item(0).Value.ToString(), 64, "Seguridad Sistema")
    '        iIDUSUARIO_PERSONAL = rst_usuarios.Fields.Item(1).Value
    '        iIDESTADO_REGISTRO = rst_usuarios.Fields.Item(2).Value
    '        var = True
    '    Else
    '        MsgBox("Error en la Actualizacion de Datos", MsgBoxStyle.Critical, "Seguridad Sistema")
    '        var = False
    '    End If

    'Catch ex As Exception
    '    MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    var = False
    'End Try
    'Return var
    'End Function
    '
    Public Function SetEliminar() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_ELIMINAR_USUARIO", CommandType.StoredProcedure)
            db.AsignarParametro("iidusuario_personal", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidestado_registro", iIDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("r_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("r_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Dim rst_usuarios As DataTable = ds.Tables(0)
            If rst_usuarios.Rows.Count > 0 Then
                MsgBox(rst_usuarios.Rows(0).Item(0).ToString(), 64, "Seguridad Sistema")
                iIDUSUARIO_PERSONAL = rst_usuarios.Rows(0).Item(1).ToString
                iIDESTADO_REGISTRO = rst_usuarios.Rows(0).Item(2).ToString
                Return True
            Else
                Throw New Exception("Error en la Actualizacion de Datos")
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
     End Function
    'Public Function GetOtrasAgencias2009() As Boolean
    'Dim bExito As Boolean
    'Try
    '    'hlamas 15-10-2008
    '    'Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLUSUARIO.SP_DATOS_USUARIO_ROL", 4, iIDUSUARIO_PERSONAL, 1}
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLUSUARIO.SP_OTRAS_AGENCIAS", 4, iIDUSUARIO_PERSONAL, 1}
    '    rst_usuarios = Nothing
    '    rst_usuarios = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '    If rst_usuarios.EOF = False And rst_usuarios.BOF = False Then
    '        If IsDBNull(rst_usuarios.Fields.Item(0).Value) Then
    '            iIDOTRAS_AGENCIAS = 0
    '        Else
    '            iIDOTRAS_AGENCIAS = Int(rst_usuarios.Fields.Item(0).Value)
    '        End If
    '        bExito = True
    '    Else
    '        bExito = False
    '    End If

    'Catch ex As Exception
    '    bExito = False
    '    MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    'End Try
    'Return bExito
    'End Function
    Public Function GetOtrasAgencias() As Boolean
        Dim bExito As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_OTRAS_AGENCIAS", CommandType.StoredProcedure)
            db.AsignarParametro("idUser", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_Usuario", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim rst_usuarios As DataTable = db.EjecutarDataTable
            If rst_usuarios.Rows.Count > 0 Then
                If IsDBNull(rst_usuarios.Rows(0).Item(0)) Then
                    iIDOTRAS_AGENCIAS = 0
                Else
                    iIDOTRAS_AGENCIAS = Int(rst_usuarios.Rows(0).Item(0))
                End If
                bExito = True
            Else
                bExito = False
            End If
        Catch ex As Excepcion
            Return False
        End Try
        Return bExito
    End Function
    Public Function GET_AGENCIA() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GENERICO.SP_GET_AGENCIA", CommandType.StoredProcedure)
            db.AsignarParametro("cur_agencia", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function Lista_Datos_Usuarios() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GENERICO.sp_lista_datos_usuarios", CommandType.StoredProcedure)
            db.AsignarParametro("cur1", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur3", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur4", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur5", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur6", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur7", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur8", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur9", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function Lista_Datos_Usuarios(ByVal usuario As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GENERICO.sp_lista_datos_usuarios", CommandType.StoredProcedure)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur1", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur3", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur4", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur5", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur6", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur7", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur8", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur9", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur10", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function LISTA_USUARIOS_AGENCIAS(ByVal agencia As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'acceso 21/04/2010
            'db.CrearComando("PKG_GENERICO.SP_LISTA_USUARIOS_AGENCIAS", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_LISTA_USUARIOS_AGENCIAS_1", CommandType.StoredProcedure)
            db.AsignarParametro("vi_agencia", agencia, OracleClient.OracleType.Number)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function LISTA_ROL_USUARIO(ByVal icontrol As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_LISTA_ROL_USUARIO", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function LISTA_ROL_USUARIO(ByVal iusuario As Integer, ByVal icontrol As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_LISTA_ROL_USUARIO", CommandType.StoredProcedure)
            db.AsignarParametro("iusuario", iusuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("icontrol", icontrol, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function DesactivarAgencia() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_DESACTIVAR_AGENCIA", CommandType.StoredProcedure)
            db.AsignarParametro("iidusuario_personal", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iidagencia", iIDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("r_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("r_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Dim rst_usuarios As DataTable = ds.Tables(0)
            If rst_usuarios.Rows.Count > 0 Then
                MsgBox(rst_usuarios.Rows(0).Item(0).ToString(), 64, "Seguridad Sistema")
                iIDUSUARIO_PERSONAL = rst_usuarios.Rows(0).Item(1).ToString
                iIDESTADO_REGISTRO = rst_usuarios.Rows(0).Item(2).ToString
                Return True
            Else
                Throw New Exception("Error en la Actualizacion de Datos")
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function LISTA_USUARIOS_AGENCIAS_TODO() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_LISTA_USUARIOS_AGENCIAS_2", CommandType.StoredProcedure)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function GET_AGENCIA_USUARIO(ByVal usuario As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_GET_AGENCIA_USUARIO", CommandType.StoredProcedure)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_agencia", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function EliminarUsuario() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_ELIMINAR_USUARIO", CommandType.StoredProcedure)
            db.AsignarParametro("iidusuario_personal", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("r_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function ListarChofer() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_CHOFER_SEL", CommandType.StoredProcedure)
            db.AsignarParametro("co_chofer", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
            'dtoUSUARIOS.iIDUSUARIO_PERSONAL = Int(rst.Rows(0).Item(0).ToString())
            'Dim rst_User_Modicado As DataTable = ds.Tables(1)
            'dtoLista_Usuario.SetCliente(rst_User_Modicado)

        Catch ex As Excepcion
            'Return False
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try

    End Function

    Public Sub GrabarChofer()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_CHOFER_IU", CommandType.StoredProcedure)
            db.AsignarParametro("ni_control", iCONTROL, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ap", iAPEPAT, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_am", iAPEMAT, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_nombres", iNOMPER, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_licencia", snro_licencia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_usuario", iIDUSUARIO_CREADOR, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_rol", iIDROL_CREADOR, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable

            'dtoUSUARIOS.iIDUSUARIO_PERSONAL = Int(rst.Rows(0).Item(0).ToString())
            'Dim rst_User_Modicado As DataTable = ds.Tables(1)
            'dtoLista_Usuario.SetCliente(rst_User_Modicado)

        Catch ex As Excepcion
            'Return False
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
#End Region
#Region "PROPIEDADES"
    Public Property codAgenciaSisvyr As String
        Get
            Return m_codAgenciaSisvyr
        End Get
        Set(ByVal value As String)
            m_codAgenciaSisvyr = value
        End Set
    End Property
    Public Property NameLogin() As String
        Get
            NameLogin = m_sNameLogin
        End Get
        Set(ByVal Value As String)
            m_sNameLogin = Value
        End Set
    End Property
    Public Property IdLogin() As Integer
        Get
            IdLogin = m_iIdLogin
        End Get
        Set(ByVal Value As Integer)
            m_iIdLogin = Value
        End Set
    End Property
    Public Property IdLoginReal() As Integer
        Get
            IdLoginReal = m_iIdLogin2
        End Get
        Set(ByVal Value As Integer)
            m_iIdLogin2 = Value
        End Set
    End Property
    Public Property IdRol() As Integer
        Get
            IdRol = m_iIdRol
        End Get
        Set(ByVal Value As Integer)
            m_iIdRol = Value
        End Set
    End Property
    Public Property Rol() As String
        Get
            Rol = m_sRol
        End Get
        Set(ByVal Value As String)
            m_sRol = Value
        End Set
    End Property
    Public Property NameAreaSistema() As String
        Get
            NameAreaSistema = m_sNameAreaSistema
        End Get
        Set(ByVal Value As String)
            m_sNameAreaSistema = Value
        End Set
    End Property

    Public Property IdAreaSistema() As Integer
        Get
            IdAreaSistema = m_iIdAreaSistema
        End Get
        Set(ByVal Value As Integer)
            m_iIdAreaSistema = Value
        End Set
    End Property
    Public Property Password() As String
        Get
            Password = m_sPassword
        End Get
        Set(ByVal Value As String)
            m_sPassword = Value
        End Set
    End Property
    Public Property IP() As String
        Get
            IP = Me.m_sIP
        End Get
        Set(ByVal value As String)
            m_sIP = value
        End Set
    End Property
    Public Property IPReal() As String
        Get
            IPReal = Me.m_sIP2
        End Get
        Set(ByVal value As String)
            m_sIP2 = value
        End Set
    End Property

    Public Property IdAgenciaReal() As String
        Get
            IdAgenciaReal = Me.m_iIdAgenciaReal
        End Get
        Set(ByVal value As String)
            m_iIdAgenciaReal = value
        End Set
    End Property

    Public Property IdUnidadAgenciaReal() As String
        Get
            IdUnidadAgenciaReal = Me.m_iIdUnidadAgenciaReal
        End Get
        Set(ByVal value As String)
            m_iIdUnidadAgenciaReal = value
        End Set
    End Property

    Private intUnidad As Integer
    Public Property Unidad() As Integer
        Get
            Return intUnidad
        End Get
        Set(ByVal value As Integer)
            intUnidad = value
        End Set
    End Property

    Private intCofre As Integer
    Public Property Cofre() As Integer
        Get
            Return intCofre
        End Get
        Set(ByVal value As Integer)
            intCofre = value
        End Set
    End Property

    Private strLoginPasaje As String
    Public Property LoginPasaje() As String
        Get
            Return strLoginPasaje
        End Get
        Set(ByVal value As String)
            strLoginPasaje = value
        End Set
    End Property

    Private strDni As String
    Public Property DNI() As String
        Get
            Return strDni
        End Get
        Set(ByVal value As String)
            strDni = value
        End Set
    End Property

    Private intTipoDocumento As Integer
    Public Property TipoDocumento() As Integer
        Get
            Return intTipoDocumento
        End Get
        Set(ByVal value As Integer)
            intTipoDocumento = value
        End Set
    End Property


#End Region
End Class

