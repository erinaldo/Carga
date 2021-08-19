'Imports System.Data.OracleClient
Imports AccesoDatos
Public Class dtoPersona
    Inherits ClsLbTepsa.dtoVERSIONES_TITAN
#Region "VARIABLES"
    Dim MyPASSWORD_CAMBIADO As String
    Dim MyESTADO As String
    Dim MyPASSWORD As String
    Dim MyPASSWORD_NUEVO As String
    Dim MyIDPERSONA As Long
    Dim MyIDTIPO_PERSONA As Long
    Dim MyCODIGO_CLIENTE As String
    Dim MyCLIENTE_CORPORATIVO As Long
    Dim MyRAZON_SOCIAL As String
    Dim MyGERENTE_GENERAL As String
    Dim MyREPRESENTANTE_LEGAL As String
    Dim MyFECHA_INGRESO As String
    Dim MyPAGO_POST_FACTURACION As Long
    Dim MyEMAIL As String
    Dim MyAPELLIDO_PATERNO As String
    Dim MyAPELLIDO_MATERNO As String
    Dim MyNOMPRE_PERSONA As String
    Dim MyNOMPRE_PERSONA1 As String
    Dim MyFECHA_NACIMIENTO As String
    Dim MySEXO_PERSONA As String
    Dim MyESMENOREDAD As Long
    Dim MyAGENTE_RETENCION As Long
    Dim MyIDTIPO_DOC_IDENTIDAD As Long
    Dim MyNU_DOCU_SUNA As String
    Dim MyNU_RETE_SUNA As String
    Dim MyIDRUBRO As Long
    Dim MyIDCLASIFICACION_PERSONA As Long
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDROL_USUARIO As Long
    Dim MyIP As String
    Dim MyFECHA_REGISTRO As String
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyIPMOD As String
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyIDPAIS As Long
    Dim MyIDDEPARTAMENTO As Long
    Dim MyIDPROVINCIA As Long
    Dim MyIDDISTRITO As Long
    Dim MyIDTIPO_FACTURACION As Long
    '18/11/2008 - Saldo del Cliente 
    Dim MySaldo_cliente As Double
    Dim MyLinea_Credito As Double
    Dim MyfuncionarioNegocio As String
    '03/03/2009 
    Dim MyidfuncionarioNegocio As Long
#End Region
    '03/03/2009 
#Region "PROPIEDADES"
    Public Property idfuncionarioNegocio() As Long
        Get
            '
            idfuncionarioNegocio = MyidfuncionarioNegocio
            '
        End Get
        Set(ByVal value As Long)
            '
            MyidfuncionarioNegocio = value
            '
        End Set
    End Property
    Public Property funcionarioNegocio() As String
        Get
            funcionarioNegocio = MyfuncionarioNegocio
        End Get
        Set(ByVal value As String)
            MyfuncionarioNegocio = value
        End Set
    End Property
    Public Property Linea_Credito() As Double
        Get
            Linea_Credito = MyLinea_Credito
        End Get
        Set(ByVal value As Double)
            MyLinea_Credito = value
        End Set
    End Property

    Public Property Saldo_cliente() As Double
        Get
            Saldo_cliente = MySaldo_cliente
        End Get
        Set(ByVal value As Double)
            MySaldo_cliente = value
        End Set
    End Property
    Public Property PASSWORD_CAMBIADO() As Integer
        Get
            PASSWORD_CAMBIADO = MyPASSWORD_CAMBIADO
        End Get
        Set(ByVal value As Integer)
            MyPASSWORD_CAMBIADO = value
        End Set
    End Property
    Public Property ESTADO() As String
        Get
            ESTADO = MyESTADO
        End Get
        Set(ByVal value As String)
            MyESTADO = value
        End Set
    End Property
    Public Property PASSWORD_NUEVO() As String
        Get
            PASSWORD_NUEVO = MyPASSWORD_NUEVO
        End Get
        Set(ByVal value As String)
            MyPASSWORD_NUEVO = value
        End Set
    End Property
    Public Property PASSWORD() As String
        Get
            PASSWORD = MyPASSWORD
        End Get
        Set(ByVal value As String)
            MyPASSWORD = value
        End Set
    End Property
    Public Property IDPERSONA() As Long
        Get
            IDPERSONA = MyIDPERSONA
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA = value
        End Set
    End Property
    Public Property IDTIPO_PERSONA() As Integer
        Get
            IDTIPO_PERSONA = MyIDTIPO_PERSONA
        End Get
        Set(ByVal value As Integer)
            MyIDTIPO_PERSONA = value
        End Set
    End Property
    Public Property CODIGO_CLIENTE() As String
        Get
            CODIGO_CLIENTE = MyCODIGO_CLIENTE
        End Get
        Set(ByVal value As String)
            MyCODIGO_CLIENTE = value
        End Set
    End Property
    Public Property CLIENTE_CORPORATIVO() As Integer
        Get
            CLIENTE_CORPORATIVO = MyCLIENTE_CORPORATIVO
        End Get
        Set(ByVal value As Integer)
            MyCLIENTE_CORPORATIVO = value
        End Set
    End Property
    Public Property RAZON_SOCIAL() As String
        Get
            RAZON_SOCIAL = MyRAZON_SOCIAL
        End Get
        Set(ByVal value As String)
            MyRAZON_SOCIAL = value
        End Set
    End Property
    Public Property GERENTE_GENERAL() As String
        Get
            GERENTE_GENERAL = MyGERENTE_GENERAL
        End Get
        Set(ByVal value As String)
            MyGERENTE_GENERAL = value
        End Set
    End Property
    Public Property REPRESENTANTE_LEGAL() As String
        Get
            REPRESENTANTE_LEGAL = MyREPRESENTANTE_LEGAL
        End Get
        Set(ByVal value As String)
            MyREPRESENTANTE_LEGAL = value
        End Set
    End Property
    Public Property FECHA_INGRESO() As String 'NO_DEFINIDO 
        Get
            FECHA_INGRESO = MyFECHA_INGRESO
        End Get
        Set(ByVal value As String)
            MyFECHA_INGRESO = value
        End Set
    End Property
    Public Property PAGO_POST_FACTURACION() As Integer
        Get
            PAGO_POST_FACTURACION = MyPAGO_POST_FACTURACION
        End Get
        Set(ByVal value As Integer)
            MyPAGO_POST_FACTURACION = value
        End Set
    End Property
    Public Property EMAIL() As String
        Get
            EMAIL = MyEMAIL
        End Get
        Set(ByVal value As String)
            MyEMAIL = value
        End Set
    End Property
    Public Property APELLIDO_PATERNO() As String
        Get
            APELLIDO_PATERNO = MyAPELLIDO_PATERNO
        End Get
        Set(ByVal value As String)
            MyAPELLIDO_PATERNO = value
        End Set
    End Property
    Public Property APELLIDO_MATERNO() As String
        Get
            APELLIDO_MATERNO = MyAPELLIDO_MATERNO
        End Get
        Set(ByVal value As String)
            MyAPELLIDO_MATERNO = value
        End Set
    End Property
    Public Property NOMPRE_PERSONA() As String
        Get
            NOMPRE_PERSONA = MyNOMPRE_PERSONA
        End Get
        Set(ByVal value As String)
            MyNOMPRE_PERSONA = value
        End Set
    End Property
    Public Property NOMPRE_PERSONA1() As String
        Get
            NOMPRE_PERSONA1 = MyNOMPRE_PERSONA1
        End Get
        Set(ByVal value As String)
            MyNOMPRE_PERSONA1 = value
        End Set
    End Property
    Public Property FECHA_NACIMIENTO() As String 'NO_DEFINIDO 
        Get
            FECHA_NACIMIENTO = MyFECHA_NACIMIENTO
        End Get
        Set(ByVal value As String)
            MyFECHA_NACIMIENTO = value
        End Set
    End Property
    Public Property SEXO_PERSONA() As String
        Get
            SEXO_PERSONA = MySEXO_PERSONA
        End Get
        Set(ByVal value As String)
            MySEXO_PERSONA = value
        End Set
    End Property
    Public Property ESMENOREDAD() As Integer
        Get
            ESMENOREDAD = MyESMENOREDAD
        End Get
        Set(ByVal value As Integer)
            MyESMENOREDAD = value
        End Set
    End Property
    Public Property AGENTE_RETENCION() As Integer
        Get
            AGENTE_RETENCION = MyAGENTE_RETENCION
        End Get
        Set(ByVal value As Integer)
            MyAGENTE_RETENCION = value
        End Set
    End Property
    Public Property IDTIPO_DOC_IDENTIDAD() As Integer
        Get
            IDTIPO_DOC_IDENTIDAD = MyIDTIPO_DOC_IDENTIDAD
        End Get
        Set(ByVal value As Integer)
            MyIDTIPO_DOC_IDENTIDAD = value
        End Set
    End Property
    Public Property NU_DOCU_SUNA() As String
        Get
            NU_DOCU_SUNA = MyNU_DOCU_SUNA
        End Get
        Set(ByVal value As String)
            MyNU_DOCU_SUNA = value
        End Set
    End Property
    Public Property NU_RETE_SUNA() As String
        Get
            NU_RETE_SUNA = MyNU_RETE_SUNA
        End Get
        Set(ByVal value As String)
            MyNU_RETE_SUNA = value
        End Set
    End Property
    Public Property IDRUBRO() As Integer
        Get
            IDRUBRO = MyIDRUBRO
        End Get
        Set(ByVal value As Integer)
            MyIDRUBRO = value
        End Set
    End Property
    Public Property IDCLASIFICACION_PERSONA() As Integer
        Get
            IDCLASIFICACION_PERSONA = MyIDCLASIFICACION_PERSONA
        End Get
        Set(ByVal value As Integer)
            MyIDCLASIFICACION_PERSONA = value
        End Set
    End Property
    Public Property IDESTADO_REGISTRO() As Integer
        Get
            IDESTADO_REGISTRO = MyIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Integer)
            MyIDESTADO_REGISTRO = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL() As Integer
        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Integer)
            MyIDUSUARIO_PERSONAL = value
        End Set
    End Property
    Public Property IDROL_USUARIO() As Integer
        Get
            IDROL_USUARIO = MyIDROL_USUARIO
        End Get
        Set(ByVal value As Integer)
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
    Public Property FECHA_REGISTRO() As String
        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONALMOD() As Integer
        Get
            IDUSUARIO_PERSONALMOD = MyIDUSUARIO_PERSONALMOD
        End Get
        Set(ByVal value As Integer)
            MyIDUSUARIO_PERSONALMOD = value
        End Set
    End Property
    Public Property IDROL_USUARIOMOD() As Integer
        Get
            IDROL_USUARIOMOD = MyIDROL_USUARIOMOD
        End Get
        Set(ByVal value As Integer)
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
    Public Property FECHA_ACTUALIZACION() As String
        Get
            FECHA_ACTUALIZACION = MyFECHA_ACTUALIZACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ACTUALIZACION = value
        End Set
    End Property
    Public Property IDPAIS() As Integer
        Get
            IDPAIS = MyIDPAIS
        End Get
        Set(ByVal value As Integer)
            MyIDPAIS = value
        End Set
    End Property
    Public Property IDDEPARTAMENTO() As Integer
        Get
            IDDEPARTAMENTO = MyIDDEPARTAMENTO
        End Get
        Set(ByVal value As Integer)
            MyIDDEPARTAMENTO = value
        End Set
    End Property
    Public Property IDPROVINCIA() As Integer
        Get
            IDPROVINCIA = MyIDPROVINCIA
        End Get
        Set(ByVal value As Integer)
            MyIDPROVINCIA = value
        End Set
    End Property
    Public Property IDDISTRITO() As Integer
        Get
            IDDISTRITO = MyIDDISTRITO
        End Get
        Set(ByVal value As Integer)
            MyIDDISTRITO = value
        End Set
    End Property
    Public Property IDTIPO_FACTURACION() As Integer
        Get
            IDTIPO_FACTURACION = MyIDTIPO_FACTURACION
        End Get
        Set(ByVal value As Integer)
            MyIDTIPO_FACTURACION = value
        End Set
    End Property
#End Region

#Region "METODOS"
    'Function SP_LISTAR_CLIENTES_2009(ByVal cnn As OracleClient.OracleConnection) As DataView
    '    Dim crit1 As String = ""
    '    Dim crit2 As String = ""
    '    Dim blanco As Integer = 0
    '    Dim cadena As String = LTrim(RTrim(RAZON_SOCIAL))
    '    For i As Integer = 1 To Len(cadena)
    '        If ((Not (blanco = 1)) And (Not (Mid(cadena, i, 1) = " "))) Then
    '            crit1 = crit1 + (Mid(cadena, i, 1))
    '        Else
    '            blanco = 1
    '        End If

    '        If ((Not (blanco = 0)) And (Not (Mid(cadena, i, 1) = " "))) Then
    '            crit2 = crit2 + (Mid(cadena, i, 1))
    '        End If
    '    Next
    '    Dim cmd As New OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOFACTURACION.SP_LISTAR_CLIENTES"
    '    cmd.Parameters.Add(New OracleParameter("p_nu_docu_suna", OracleClient.OracleClient.OracleType.VarChar)).Value = IIf(NU_DOCU_SUNA = "", 0, NU_DOCU_SUNA)
    '    cmd.Parameters.Add(New OracleParameter("p_razon_sociala", OracleClient.OracleClient.OracleType.VarChar)).Value = crit1
    '    cmd.Parameters.Add(New OracleParameter("p_razon_socialb", OracleClient.OracleClient.OracleType.VarChar)).Value = crit2
    '    cmd.Parameters.Add(New OracleParameter("curr_LISTAR_CLIENTES", OracleClient.OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim DA As New OracleDataAdapter(cmd)
    '    Dim DT As New DataTable
    '    DA.Fill(DT)
    '    Dim DV As New DataView
    '    DV = DT.DefaultView
    '    Return DV
    'End Function
    Function SP_LISTAR_CLIENTES() As DataView
        Dim crit1 As String = ""
        Dim crit2 As String = ""
        Dim blanco As Integer = 0
        Dim cadena As String = LTrim(RTrim(RAZON_SOCIAL))
        For i As Integer = 1 To Len(cadena)
            If ((Not (blanco = 1)) And (Not (Mid(cadena, i, 1) = " "))) Then
                crit1 = crit1 + (Mid(cadena, i, 1))
            Else
                blanco = 1
            End If

            If ((Not (blanco = 0)) And (Not (Mid(cadena, i, 1) = " "))) Then
                crit2 = crit2 + (Mid(cadena, i, 1))
            End If
        Next
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            db.Conectar()
            'Invocando al procedimiento
            db.CrearComando("PKG_IVOFACTURACION.SP_LISTAR_CLIENTES", CommandType.StoredProcedure)
            'Parametros de entrada 
            NU_DOCU_SUNA = IIf(NU_DOCU_SUNA = "", 0, NU_DOCU_SUNA)
            '
            db.AsignarParametro("p_nu_docu_suna", NU_DOCU_SUNA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_razon_socialA", crit1, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_razon_socialB", crit2, OracleClient.OracleType.VarChar)
            'Parametros de Salida
            db.AsignarParametro("curr_LISTAR_CLIENTES", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            ldt_tmp = db.EjecutarDataTable
            Return ldt_tmp.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Function SP_CAMBIAR_PASSWORD_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOPERSONA.SP_CAMBIAR_PASSWORD"
    '        cmd.Parameters.Add(New OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleParameter("P_PASSWORD", OracleClient.OracleClient.OracleType.VarChar)).Value = PASSWORD
    '        cmd.Parameters.Add(New OracleParameter("P_PASSWORD_NUEVO", OracleClient.OracleClient.OracleType.VarChar)).Value = PASSWORD_NUEVO
    '        cmd.Parameters.Add(New OracleParameter("P_ESTADO", OracleClient.OracleClient.OracleType.VarChar, 20)).Direction = ParameterDirection.Output
    '        cmd.ExecuteNonQuery()
    '        ESTADO = cmd.Parameters("P_ESTADO").Value
    '        If ESTADO = "CAMBI" Then
    '            MsgBox("La clave cambio correctamente", MsgBoxStyle.Information, "Seguridad del Sistema...")
    '        End If
    '        If ESTADO = "CLAVE_INVA" Then
    '            MsgBox("Error de cambio de clave, la clave no coincide", MsgBoxStyle.Critical, "Seguridad del Sistema...")
    '        End If
    '    Catch Oex As OracleClient.OracleException
    '        MsgBox(Oex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Function SP_CAMBIAR_PASSWORD()
        Dim db As New BaseDatos
        Try
            Dim lobj_tmp As New Object
            db.Conectar()
            'Invocando al procedimiento
            db.CrearComando("PKG_IVOPERSONA.SP_CAMBIAR_PASSWORD", CommandType.StoredProcedure)
            'Parametros de entrada 
            NU_DOCU_SUNA = IIf(NU_DOCU_SUNA = "", 0, NU_DOCU_SUNA)
            '
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_PASSWORD", PASSWORD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_PASSWORD_NUEVO", PASSWORD_NUEVO, OracleClient.OracleType.VarChar)
            'Parametros de Salida
            db.AsignarParametro("P_ESTADO", 30, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            '
            lobj_tmp = db.EjecutarComando()
            '
            If db.Parametros.Length > 0 Then
                ESTADO = IIf(db.Parametros(1) Is DBNull.Value, "", db.Parametros(1))
            End If
            '
            If ESTADO = "CAMBI" Then
                MsgBox("La clave cambio correctamente", MsgBoxStyle.Information, "Seguridad del Sistema...")
            End If
            '
            If ESTADO = "CLAVE_INVA" Then
                MsgBox("Error de cambio de clave, la clave no coincide", MsgBoxStyle.Critical, "Seguridad del Sistema...")
            End If
            '            
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'Function SP_SI_PASSWORD_CAMBIADO_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOPERSONA.SP_SI_PASSWORD_CAMBIADO"
    '        cmd.Parameters.Add(New OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleParameter("P_VERSION", OracleClient.OracleClient.OracleType.VarChar)).Value = VERSION
    '        cmd.Parameters.Add(New OracleParameter("P_PASSWORD_CAMBIADO", OracleClient.OracleClient.OracleType.VarChar, 1)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleParameter("P_VERSION_ULTIMO", OracleClient.OracleClient.OracleType.VarChar, 20)).Direction = ParameterDirection.Output
    '        cmd.ExecuteNonQuery()
    '        If Not cmd.Parameters("P_PASSWORD_CAMBIADO").Value Is DBNull.Value Then
    '            PASSWORD_CAMBIADO = cmd.Parameters("P_PASSWORD_CAMBIADO").Value
    '        Else
    '            PASSWORD_CAMBIADO = Nothing
    '        End If
    '        If Not cmd.Parameters("P_VERSION_ULTIMO").Value Is DBNull.Value Then
    '            VERSION_ULTIMO = cmd.Parameters("P_VERSION_ULTIMO").Value
    '        Else
    '            VERSION_ULTIMO = Nothing
    '        End If
    '    Catch Oex As OracleClient.OracleException
    '        MsgBox(Oex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Function SP_SI_PASSWORD_CAMBIADO()
        Dim db As New BaseDatos
        Dim lobj_tmp As New Object
        Try
            db.Conectar()
            'Invocando al procedimiento
            db.CrearComando("PKG_IVOPERSONA.SP_SI_PASSWORD_CAMBIADO", CommandType.StoredProcedure)
            'Parametros de entrada 
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_VERSION", VERSION, OracleClient.OracleType.VarChar)
            'Parametros de Salida
            db.AsignarParametro("P_PASSWORD_CAMBIADO", 2, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db.AsignarParametro("P_VERSION_ULTIMO", 30, OracleClient.OracleType.Char, ParameterDirection.Output)
            '
            db.EjecutarComando()
            '
            '
            If db.Parametros.Length > 0 Then
                PASSWORD_CAMBIADO = IIf(db.Parametros(1) Is DBNull.Value, 0, db.Parametros(1))
                VERSION_ULTIMO = IIf(db.Parametros(2) Is DBNull.Value, 0, db.Parametros(2))
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'Public Function FNLISTAR_PERSONA(ByVal VOCONTROLUSUARIO As Object, ByVal P_IDTIPO_PERSONA As Long, ByVal P_IDPERSONA As Long, ByVal P_CODIGO_CLIENTE As String) As DataView
    '    Try
    '        Dim dvLISTAR_PERSONA As New DataView
    '        Dim RstLISTAR_PERSONA As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_LISTAR_PERSONA_", 8, P_IDTIPO_PERSONA, 1, Str(P_IDPERSONA), 2, P_CODIGO_CLIENTE, 2}
    '        RstLISTAR_PERSONA = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, RstLISTAR_PERSONA)
    '        dvLISTAR_PERSONA = DT.DefaultView

    '        If dvLISTAR_PERSONA.Count = 1 Then
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDPERSONA") Then IDPERSONA = dvLISTAR_PERSONA.Table.Rows(0)("IDPERSONA") Else IDPERSONA = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDTIPO_PERSONA") Then IDTIPO_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("IDTIPO_PERSONA") Else IDTIPO_PERSONA = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("CODIGO_CLIENTE") Then CODIGO_CLIENTE = dvLISTAR_PERSONA.Table.Rows(0)("CODIGO_CLIENTE") Else CODIGO_CLIENTE = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("CLIENTE_CORPORATIVO") Then CLIENTE_CORPORATIVO = dvLISTAR_PERSONA.Table.Rows(0)("CLIENTE_CORPORATIVO") Else CLIENTE_CORPORATIVO = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("RAZON_SOCIAL") Then RAZON_SOCIAL = dvLISTAR_PERSONA.Table.Rows(0)("RAZON_SOCIAL") Else RAZON_SOCIAL = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("GERENTE_GENERAL") Then GERENTE_GENERAL = dvLISTAR_PERSONA.Table.Rows(0)("GERENTE_GENERAL") Else GERENTE_GENERAL = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("REPRESENTANTE_LEGAL") Then REPRESENTANTE_LEGAL = dvLISTAR_PERSONA.Table.Rows(0)("REPRESENTANTE_LEGAL") Else REPRESENTANTE_LEGAL = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_INGRESO") Then FECHA_INGRESO = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_INGRESO") Else FECHA_INGRESO = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("PAGO_POST_FACTURACION") Then PAGO_POST_FACTURACION = dvLISTAR_PERSONA.Table.Rows(0)("PAGO_POST_FACTURACION") Else PAGO_POST_FACTURACION = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("EMAIL") Then EMAIL = dvLISTAR_PERSONA.Table.Rows(0)("EMAIL") Else EMAIL = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("APELLIDO_PATERNO") Then APELLIDO_PATERNO = dvLISTAR_PERSONA.Table.Rows(0)("APELLIDO_PATERNO") Else APELLIDO_PATERNO = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("APELLIDO_MATERNO") Then APELLIDO_MATERNO = dvLISTAR_PERSONA.Table.Rows(0)("APELLIDO_MATERNO") Else APELLIDO_MATERNO = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NOMPRE_PERSONA") Then NOMPRE_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("NOMPRE_PERSONA") Else NOMPRE_PERSONA = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NOMPRE_PERSONA1") Then NOMPRE_PERSONA1 = dvLISTAR_PERSONA.Table.Rows(0)("NOMPRE_PERSONA1") Else NOMPRE_PERSONA1 = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_NACIMIENTO") Then FECHA_NACIMIENTO = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_NACIMIENTO") Else FECHA_NACIMIENTO = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("SEXO_PERSONA") Then SEXO_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("SEXO_PERSONA") Else SEXO_PERSONA = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("ESMENOREDAD") Then ESMENOREDAD = dvLISTAR_PERSONA.Table.Rows(0)("ESMENOREDAD") Else ESMENOREDAD = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("AGENTE_RETENCION") Then AGENTE_RETENCION = dvLISTAR_PERSONA.Table.Rows(0)("AGENTE_RETENCION") Else AGENTE_RETENCION = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDTIPO_DOC_IDENTIDAD") Then IDTIPO_DOC_IDENTIDAD = dvLISTAR_PERSONA.Table.Rows(0)("IDTIPO_DOC_IDENTIDAD") Else IDTIPO_DOC_IDENTIDAD = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NU_DOCU_SUNA") Then NU_DOCU_SUNA = dvLISTAR_PERSONA.Table.Rows(0)("NU_DOCU_SUNA") Else NU_DOCU_SUNA = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NU_RETE_SUNA") Then NU_RETE_SUNA = dvLISTAR_PERSONA.Table.Rows(0)("NU_RETE_SUNA") Else NU_RETE_SUNA = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDRUBRO") Then IDRUBRO = dvLISTAR_PERSONA.Table.Rows(0)("IDRUBRO") Else IDRUBRO = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDCLASIFICACION_PERSONA") Then IDCLASIFICACION_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("IDCLASIFICACION_PERSONA") Else IDCLASIFICACION_PERSONA = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dvLISTAR_PERSONA.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dvLISTAR_PERSONA.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDROL_USUARIO") Then IDROL_USUARIO = dvLISTAR_PERSONA.Table.Rows(0)("IDROL_USUARIO") Else IDROL_USUARIO = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IP") Then IP = dvLISTAR_PERSONA.Table.Rows(0)("IP") Else IP = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDUSUARIO_PERSONALMOD") Then IDUSUARIO_PERSONALMOD = dvLISTAR_PERSONA.Table.Rows(0)("IDUSUARIO_PERSONALMOD") Else IDUSUARIO_PERSONALMOD = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDROL_USUARIOMOD") Then IDROL_USUARIOMOD = dvLISTAR_PERSONA.Table.Rows(0)("IDROL_USUARIOMOD") Else IDROL_USUARIOMOD = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IPMOD") Then IPMOD = dvLISTAR_PERSONA.Table.Rows(0)("IPMOD") Else IPMOD = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_ACTUALIZACION") Then FECHA_ACTUALIZACION = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_ACTUALIZACION") Else FECHA_ACTUALIZACION = ""
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDPAIS") Then IDPAIS = dvLISTAR_PERSONA.Table.Rows(0)("IDPAIS") Else IDPAIS = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDDEPARTAMENTO") Then IDDEPARTAMENTO = dvLISTAR_PERSONA.Table.Rows(0)("IDDEPARTAMENTO") Else IDDEPARTAMENTO = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDPROVINCIA") Then IDPROVINCIA = dvLISTAR_PERSONA.Table.Rows(0)("IDPROVINCIA") Else IDPROVINCIA = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDDISTRITO") Then IDDISTRITO = dvLISTAR_PERSONA.Table.Rows(0)("IDDISTRITO") Else IDDISTRITO = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDTIPO_FACTURACION") Then IDTIPO_FACTURACION = dvLISTAR_PERSONA.Table.Rows(0)("IDTIPO_FACTURACION") Else IDTIPO_FACTURACION = 0
    '            ''
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("SALDO_CLIENTE") Then Saldo_cliente = dvLISTAR_PERSONA.Table.Rows(0)("SALDO_CLIENTE") Else Saldo_cliente = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("LINEA_CREDITO") Then Linea_Credito = dvLISTAR_PERSONA.Table.Rows(0)("LINEA_CREDITO") Else Linea_Credito = 0
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("funcionario_carga") Then funcionarioNegocio = dvLISTAR_PERSONA.Table.Rows(0)("funcionario_carga") Else funcionarioNegocio = ""
    '            '
    '            If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("idfuncionario_carga") Then idfuncionarioNegocio = dvLISTAR_PERSONA.Table.Rows(0)("idfuncionario_carga") Else idfuncionarioNegocio = 0
    '            '
    '        End If
    '        Return dvLISTAR_PERSONA
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Public Function FNLISTAR_PERSONA(ByVal P_IDTIPO_PERSONA As Long, ByVal P_IDPERSONA As Long, ByVal P_CODIGO_CLIENTE As String) As DataView
        Try
            Dim dvLISTAR_PERSONA As New DataView
            'Dim RstLISTAR_PERSONA As New ADODB.Recordset
            'Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_LISTAR_PERSONA_", 8, P_IDTIPO_PERSONA, 1, Str(P_IDPERSONA), 2, P_CODIGO_CLIENTE, 2}
            'RstLISTAR_PERSONA = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            'Dim DA As New OleDb.OleDbDataAdapter
            Dim DT As New DataTable
            'DA.Fill(DT, RstLISTAR_PERSONA)

            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_PERSONA_", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDTIPO_PERSONA", P_IDTIPO_PERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", CStr(P_IDPERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_CODIGO_CLIENTE", P_CODIGO_CLIENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LISTAR_PERSONA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)

            db.Desconectar()
            DT = db.EjecutarDataSet.Tables(0)

            dvLISTAR_PERSONA = DT.DefaultView

            If dvLISTAR_PERSONA.Count = 1 Then
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDPERSONA") Then IDPERSONA = dvLISTAR_PERSONA.Table.Rows(0)("IDPERSONA") Else IDPERSONA = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDTIPO_PERSONA") Then IDTIPO_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("IDTIPO_PERSONA") Else IDTIPO_PERSONA = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("CODIGO_CLIENTE") Then CODIGO_CLIENTE = dvLISTAR_PERSONA.Table.Rows(0)("CODIGO_CLIENTE") Else CODIGO_CLIENTE = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("CLIENTE_CORPORATIVO") Then CLIENTE_CORPORATIVO = dvLISTAR_PERSONA.Table.Rows(0)("CLIENTE_CORPORATIVO") Else CLIENTE_CORPORATIVO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("RAZON_SOCIAL") Then RAZON_SOCIAL = dvLISTAR_PERSONA.Table.Rows(0)("RAZON_SOCIAL") Else RAZON_SOCIAL = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("GERENTE_GENERAL") Then GERENTE_GENERAL = dvLISTAR_PERSONA.Table.Rows(0)("GERENTE_GENERAL") Else GERENTE_GENERAL = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("REPRESENTANTE_LEGAL") Then REPRESENTANTE_LEGAL = dvLISTAR_PERSONA.Table.Rows(0)("REPRESENTANTE_LEGAL") Else REPRESENTANTE_LEGAL = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_INGRESO") Then FECHA_INGRESO = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_INGRESO") Else FECHA_INGRESO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("PAGO_POST_FACTURACION") Then PAGO_POST_FACTURACION = dvLISTAR_PERSONA.Table.Rows(0)("PAGO_POST_FACTURACION") Else PAGO_POST_FACTURACION = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("EMAIL") Then EMAIL = dvLISTAR_PERSONA.Table.Rows(0)("EMAIL") Else EMAIL = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("APELLIDO_PATERNO") Then APELLIDO_PATERNO = dvLISTAR_PERSONA.Table.Rows(0)("APELLIDO_PATERNO") Else APELLIDO_PATERNO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("APELLIDO_MATERNO") Then APELLIDO_MATERNO = dvLISTAR_PERSONA.Table.Rows(0)("APELLIDO_MATERNO") Else APELLIDO_MATERNO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NOMPRE_PERSONA") Then NOMPRE_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("NOMPRE_PERSONA") Else NOMPRE_PERSONA = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NOMPRE_PERSONA1") Then NOMPRE_PERSONA1 = dvLISTAR_PERSONA.Table.Rows(0)("NOMPRE_PERSONA1") Else NOMPRE_PERSONA1 = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_NACIMIENTO") Then FECHA_NACIMIENTO = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_NACIMIENTO") Else FECHA_NACIMIENTO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("SEXO_PERSONA") Then SEXO_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("SEXO_PERSONA") Else SEXO_PERSONA = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("ESMENOREDAD") Then ESMENOREDAD = dvLISTAR_PERSONA.Table.Rows(0)("ESMENOREDAD") Else ESMENOREDAD = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("AGENTE_RETENCION") Then AGENTE_RETENCION = dvLISTAR_PERSONA.Table.Rows(0)("AGENTE_RETENCION") Else AGENTE_RETENCION = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDTIPO_DOC_IDENTIDAD") Then IDTIPO_DOC_IDENTIDAD = dvLISTAR_PERSONA.Table.Rows(0)("IDTIPO_DOC_IDENTIDAD") Else IDTIPO_DOC_IDENTIDAD = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NU_DOCU_SUNA") Then NU_DOCU_SUNA = dvLISTAR_PERSONA.Table.Rows(0)("NU_DOCU_SUNA") Else NU_DOCU_SUNA = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NU_RETE_SUNA") Then NU_RETE_SUNA = dvLISTAR_PERSONA.Table.Rows(0)("NU_RETE_SUNA") Else NU_RETE_SUNA = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDRUBRO") Then IDRUBRO = dvLISTAR_PERSONA.Table.Rows(0)("IDRUBRO") Else IDRUBRO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDCLASIFICACION_PERSONA") Then IDCLASIFICACION_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("IDCLASIFICACION_PERSONA") Else IDCLASIFICACION_PERSONA = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dvLISTAR_PERSONA.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dvLISTAR_PERSONA.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDROL_USUARIO") Then IDROL_USUARIO = dvLISTAR_PERSONA.Table.Rows(0)("IDROL_USUARIO") Else IDROL_USUARIO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IP") Then IP = dvLISTAR_PERSONA.Table.Rows(0)("IP") Else IP = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDUSUARIO_PERSONALMOD") Then IDUSUARIO_PERSONALMOD = dvLISTAR_PERSONA.Table.Rows(0)("IDUSUARIO_PERSONALMOD") Else IDUSUARIO_PERSONALMOD = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDROL_USUARIOMOD") Then IDROL_USUARIOMOD = dvLISTAR_PERSONA.Table.Rows(0)("IDROL_USUARIOMOD") Else IDROL_USUARIOMOD = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IPMOD") Then IPMOD = dvLISTAR_PERSONA.Table.Rows(0)("IPMOD") Else IPMOD = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_ACTUALIZACION") Then FECHA_ACTUALIZACION = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_ACTUALIZACION") Else FECHA_ACTUALIZACION = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDPAIS") Then IDPAIS = dvLISTAR_PERSONA.Table.Rows(0)("IDPAIS") Else IDPAIS = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDDEPARTAMENTO") Then IDDEPARTAMENTO = dvLISTAR_PERSONA.Table.Rows(0)("IDDEPARTAMENTO") Else IDDEPARTAMENTO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDPROVINCIA") Then IDPROVINCIA = dvLISTAR_PERSONA.Table.Rows(0)("IDPROVINCIA") Else IDPROVINCIA = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDDISTRITO") Then IDDISTRITO = dvLISTAR_PERSONA.Table.Rows(0)("IDDISTRITO") Else IDDISTRITO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDTIPO_FACTURACION") Then IDTIPO_FACTURACION = dvLISTAR_PERSONA.Table.Rows(0)("IDTIPO_FACTURACION") Else IDTIPO_FACTURACION = 0
                ''
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("SALDO_CLIENTE") Then Saldo_cliente = dvLISTAR_PERSONA.Table.Rows(0)("SALDO_CLIENTE") Else Saldo_cliente = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("LINEA_CREDITO") Then Linea_Credito = dvLISTAR_PERSONA.Table.Rows(0)("LINEA_CREDITO") Else Linea_Credito = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("funcionario_carga") Then funcionarioNegocio = dvLISTAR_PERSONA.Table.Rows(0)("funcionario_carga") Else funcionarioNegocio = ""
                '
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("idfuncionario_carga") Then idfuncionarioNegocio = dvLISTAR_PERSONA.Table.Rows(0)("idfuncionario_carga") Else idfuncionarioNegocio = 0
                '
            End If
            Return dvLISTAR_PERSONA
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FNLISTAR_PERSONA_1_Y_2_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_IDPERSONA As Long, ByVal P_CODIGO_CLIENTE As String) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_LISTAR_PERSONA_1_Y_2", 8, P_IDPERSONA, 1, P_CODIGO_CLIENTE, 2}
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView
    '        Return dv
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Public Function FNLISTAR_PERSONA_1_Y_2(ByVal P_IDPERSONA As Long, ByVal P_CODIGO_CLIENTE As String) As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_PERSONA_1_Y_2", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDPERSONA", P_IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_CODIGO_CLIENTE", P_CODIGO_CLIENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LISTAR_PERSONA_1_Y_2", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet.Tables(0).DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    '29/10/2007 - Recupera las sub cuenta asociada al cliente 
    'Public Function SP_recupera_centro_costo_p(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataTable
    '    Dim dt_table As New DataTable
    '    Try

    '        dt_table = New DataTable
    '        'sp_recupera_centro_costo_m(vi_idpersona in varchar2, 
    '        '                                     ocur_centro_costo out types.cursor_type)
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOPERSONA.SP_recupera_centro_costo_p"
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("vi_idpersona", OracleClient.OracleClient.OracleType.VarChar)).Value = CType(IDPERSONA, String)
    '        '
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("ocur_centro_costo", OracleClient.OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        'Dim ds As New DataSet
    '        daora.Fill(dt_table)
    '        Return dt_table
    '        '
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    '29/10/2007 - Recupera las sub cuenta asociada al cliente 
    Public Function SP_recupera_centro_costo_p() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_recupera_centro_costo_p", CommandType.StoredProcedure)
            db.AsignarParametro("vi_idpersona", CType(IDPERSONA, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("ocur_centro_costo", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function BUSCA_CLIENTES(ByVal CodigoFuncionario As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_BUSCA_CLIENTES", CommandType.StoredProcedure)
            db.AsignarParametro("iID_CODIGO_CLIENTE", CodigoFuncionario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("OCURSOR_SALIDA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function BUSCA_CLIENTES_NOMBRE(ByVal CodigoFuncionario As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_BUSCA_CLIENTES", CommandType.StoredProcedure)
            db.AsignarParametro("iID_CODIGO_CLIENTE", CodigoFuncionario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("OCURSOR_SALIDA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function FNLISTAR_PERSONA_2(ByVal P_IDTIPO_PERSONA As Long, ByVal P_IDPERSONA As Long, ByVal P_CODIGO_CLIENTE As String) As DataView
        Try
            Dim dvLISTAR_PERSONA As New DataView
            'Dim RstLISTAR_PERSONA As New ADODB.Recordset
            'Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_LISTAR_PERSONA_", 8, P_IDTIPO_PERSONA, 1, Str(P_IDPERSONA), 2, P_CODIGO_CLIENTE, 2}
            'RstLISTAR_PERSONA = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            'Dim DA As New OleDb.OleDbDataAdapter
            Dim DT As New DataTable
            'DA.Fill(DT, RstLISTAR_PERSONA)

            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_PERSONA_2", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDTIPO_PERSONA", P_IDTIPO_PERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", CStr(P_IDPERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_CODIGO_CLIENTE", P_CODIGO_CLIENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LISTAR_PERSONA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)

            db.Desconectar()
            DT = db.EjecutarDataSet.Tables(0)

            dvLISTAR_PERSONA = DT.DefaultView

            If dvLISTAR_PERSONA.Count = 1 Then
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDPERSONA") Then IDPERSONA = dvLISTAR_PERSONA.Table.Rows(0)("IDPERSONA") Else IDPERSONA = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDTIPO_PERSONA") Then IDTIPO_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("IDTIPO_PERSONA") Else IDTIPO_PERSONA = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("CODIGO_CLIENTE") Then CODIGO_CLIENTE = dvLISTAR_PERSONA.Table.Rows(0)("CODIGO_CLIENTE") Else CODIGO_CLIENTE = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("CLIENTE_CORPORATIVO") Then CLIENTE_CORPORATIVO = dvLISTAR_PERSONA.Table.Rows(0)("CLIENTE_CORPORATIVO") Else CLIENTE_CORPORATIVO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("RAZON_SOCIAL") Then RAZON_SOCIAL = dvLISTAR_PERSONA.Table.Rows(0)("RAZON_SOCIAL") Else RAZON_SOCIAL = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("GERENTE_GENERAL") Then GERENTE_GENERAL = dvLISTAR_PERSONA.Table.Rows(0)("GERENTE_GENERAL") Else GERENTE_GENERAL = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("REPRESENTANTE_LEGAL") Then REPRESENTANTE_LEGAL = dvLISTAR_PERSONA.Table.Rows(0)("REPRESENTANTE_LEGAL") Else REPRESENTANTE_LEGAL = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_INGRESO") Then FECHA_INGRESO = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_INGRESO") Else FECHA_INGRESO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("PAGO_POST_FACTURACION") Then PAGO_POST_FACTURACION = dvLISTAR_PERSONA.Table.Rows(0)("PAGO_POST_FACTURACION") Else PAGO_POST_FACTURACION = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("EMAIL") Then EMAIL = dvLISTAR_PERSONA.Table.Rows(0)("EMAIL") Else EMAIL = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("APELLIDO_PATERNO") Then APELLIDO_PATERNO = dvLISTAR_PERSONA.Table.Rows(0)("APELLIDO_PATERNO") Else APELLIDO_PATERNO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("APELLIDO_MATERNO") Then APELLIDO_MATERNO = dvLISTAR_PERSONA.Table.Rows(0)("APELLIDO_MATERNO") Else APELLIDO_MATERNO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NOMPRE_PERSONA") Then NOMPRE_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("NOMPRE_PERSONA") Else NOMPRE_PERSONA = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NOMPRE_PERSONA1") Then NOMPRE_PERSONA1 = dvLISTAR_PERSONA.Table.Rows(0)("NOMPRE_PERSONA1") Else NOMPRE_PERSONA1 = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_NACIMIENTO") Then FECHA_NACIMIENTO = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_NACIMIENTO") Else FECHA_NACIMIENTO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("SEXO_PERSONA") Then SEXO_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("SEXO_PERSONA") Else SEXO_PERSONA = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("ESMENOREDAD") Then ESMENOREDAD = dvLISTAR_PERSONA.Table.Rows(0)("ESMENOREDAD") Else ESMENOREDAD = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("AGENTE_RETENCION") Then AGENTE_RETENCION = dvLISTAR_PERSONA.Table.Rows(0)("AGENTE_RETENCION") Else AGENTE_RETENCION = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDTIPO_DOC_IDENTIDAD") Then IDTIPO_DOC_IDENTIDAD = dvLISTAR_PERSONA.Table.Rows(0)("IDTIPO_DOC_IDENTIDAD") Else IDTIPO_DOC_IDENTIDAD = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NU_DOCU_SUNA") Then NU_DOCU_SUNA = dvLISTAR_PERSONA.Table.Rows(0)("NU_DOCU_SUNA") Else NU_DOCU_SUNA = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NU_RETE_SUNA") Then NU_RETE_SUNA = dvLISTAR_PERSONA.Table.Rows(0)("NU_RETE_SUNA") Else NU_RETE_SUNA = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDRUBRO") Then IDRUBRO = dvLISTAR_PERSONA.Table.Rows(0)("IDRUBRO") Else IDRUBRO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDCLASIFICACION_PERSONA") Then IDCLASIFICACION_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("IDCLASIFICACION_PERSONA") Else IDCLASIFICACION_PERSONA = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dvLISTAR_PERSONA.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dvLISTAR_PERSONA.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDROL_USUARIO") Then IDROL_USUARIO = dvLISTAR_PERSONA.Table.Rows(0)("IDROL_USUARIO") Else IDROL_USUARIO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IP") Then IP = dvLISTAR_PERSONA.Table.Rows(0)("IP") Else IP = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDUSUARIO_PERSONALMOD") Then IDUSUARIO_PERSONALMOD = dvLISTAR_PERSONA.Table.Rows(0)("IDUSUARIO_PERSONALMOD") Else IDUSUARIO_PERSONALMOD = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDROL_USUARIOMOD") Then IDROL_USUARIOMOD = dvLISTAR_PERSONA.Table.Rows(0)("IDROL_USUARIOMOD") Else IDROL_USUARIOMOD = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IPMOD") Then IPMOD = dvLISTAR_PERSONA.Table.Rows(0)("IPMOD") Else IPMOD = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_ACTUALIZACION") Then FECHA_ACTUALIZACION = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_ACTUALIZACION") Else FECHA_ACTUALIZACION = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDPAIS") Then IDPAIS = dvLISTAR_PERSONA.Table.Rows(0)("IDPAIS") Else IDPAIS = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDDEPARTAMENTO") Then IDDEPARTAMENTO = dvLISTAR_PERSONA.Table.Rows(0)("IDDEPARTAMENTO") Else IDDEPARTAMENTO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDPROVINCIA") Then IDPROVINCIA = dvLISTAR_PERSONA.Table.Rows(0)("IDPROVINCIA") Else IDPROVINCIA = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDDISTRITO") Then IDDISTRITO = dvLISTAR_PERSONA.Table.Rows(0)("IDDISTRITO") Else IDDISTRITO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDTIPO_FACTURACION") Then IDTIPO_FACTURACION = dvLISTAR_PERSONA.Table.Rows(0)("IDTIPO_FACTURACION") Else IDTIPO_FACTURACION = 0
                ''
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("SALDO_CLIENTE") Then Saldo_cliente = dvLISTAR_PERSONA.Table.Rows(0)("SALDO_CLIENTE") Else Saldo_cliente = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("LINEA_CREDITO") Then Linea_Credito = dvLISTAR_PERSONA.Table.Rows(0)("LINEA_CREDITO") Else Linea_Credito = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("funcionario_carga") Then funcionarioNegocio = dvLISTAR_PERSONA.Table.Rows(0)("funcionario_carga") Else funcionarioNegocio = ""
                '
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("idfuncionario_carga") Then idfuncionarioNegocio = dvLISTAR_PERSONA.Table.Rows(0)("idfuncionario_carga") Else idfuncionarioNegocio = 0
                '
            End If
            Return dvLISTAR_PERSONA
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function ListarClienteDescuento(ByVal P_IDTIPO_PERSONA As Long, ByVal P_IDPERSONA As Long, ByVal P_CODIGO_CLIENTE As String) As DataView
        Try
            Dim dvLISTAR_PERSONA As New DataView
            'Dim RstLISTAR_PERSONA As New ADODB.Recordset
            'Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_LISTAR_PERSONA_", 8, P_IDTIPO_PERSONA, 1, Str(P_IDPERSONA), 2, P_CODIGO_CLIENTE, 2}
            'RstLISTAR_PERSONA = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            'Dim DA As New OleDb.OleDbDataAdapter
            Dim DT As New DataTable
            'DA.Fill(DT, RstLISTAR_PERSONA)

            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_listar_cliente_descuento", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDTIPO_PERSONA", P_IDTIPO_PERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPERSONA", CStr(P_IDPERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_CODIGO_CLIENTE", P_CODIGO_CLIENTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LISTAR_PERSONA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)

            db.Desconectar()
            DT = db.EjecutarDataSet.Tables(0)

            dvLISTAR_PERSONA = DT.DefaultView

            If dvLISTAR_PERSONA.Count = 1 Then
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDPERSONA") Then IDPERSONA = dvLISTAR_PERSONA.Table.Rows(0)("IDPERSONA") Else IDPERSONA = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDTIPO_PERSONA") Then IDTIPO_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("IDTIPO_PERSONA") Else IDTIPO_PERSONA = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("CODIGO_CLIENTE") Then CODIGO_CLIENTE = dvLISTAR_PERSONA.Table.Rows(0)("CODIGO_CLIENTE") Else CODIGO_CLIENTE = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("CLIENTE_CORPORATIVO") Then CLIENTE_CORPORATIVO = dvLISTAR_PERSONA.Table.Rows(0)("CLIENTE_CORPORATIVO") Else CLIENTE_CORPORATIVO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("RAZON_SOCIAL") Then RAZON_SOCIAL = dvLISTAR_PERSONA.Table.Rows(0)("RAZON_SOCIAL") Else RAZON_SOCIAL = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("GERENTE_GENERAL") Then GERENTE_GENERAL = dvLISTAR_PERSONA.Table.Rows(0)("GERENTE_GENERAL") Else GERENTE_GENERAL = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("REPRESENTANTE_LEGAL") Then REPRESENTANTE_LEGAL = dvLISTAR_PERSONA.Table.Rows(0)("REPRESENTANTE_LEGAL") Else REPRESENTANTE_LEGAL = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_INGRESO") Then FECHA_INGRESO = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_INGRESO") Else FECHA_INGRESO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("PAGO_POST_FACTURACION") Then PAGO_POST_FACTURACION = dvLISTAR_PERSONA.Table.Rows(0)("PAGO_POST_FACTURACION") Else PAGO_POST_FACTURACION = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("EMAIL") Then EMAIL = dvLISTAR_PERSONA.Table.Rows(0)("EMAIL") Else EMAIL = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("APELLIDO_PATERNO") Then APELLIDO_PATERNO = dvLISTAR_PERSONA.Table.Rows(0)("APELLIDO_PATERNO") Else APELLIDO_PATERNO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("APELLIDO_MATERNO") Then APELLIDO_MATERNO = dvLISTAR_PERSONA.Table.Rows(0)("APELLIDO_MATERNO") Else APELLIDO_MATERNO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NOMPRE_PERSONA") Then NOMPRE_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("NOMPRE_PERSONA") Else NOMPRE_PERSONA = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NOMPRE_PERSONA1") Then NOMPRE_PERSONA1 = dvLISTAR_PERSONA.Table.Rows(0)("NOMPRE_PERSONA1") Else NOMPRE_PERSONA1 = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_NACIMIENTO") Then FECHA_NACIMIENTO = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_NACIMIENTO") Else FECHA_NACIMIENTO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("SEXO_PERSONA") Then SEXO_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("SEXO_PERSONA") Else SEXO_PERSONA = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("ESMENOREDAD") Then ESMENOREDAD = dvLISTAR_PERSONA.Table.Rows(0)("ESMENOREDAD") Else ESMENOREDAD = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("AGENTE_RETENCION") Then AGENTE_RETENCION = dvLISTAR_PERSONA.Table.Rows(0)("AGENTE_RETENCION") Else AGENTE_RETENCION = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDTIPO_DOC_IDENTIDAD") Then IDTIPO_DOC_IDENTIDAD = dvLISTAR_PERSONA.Table.Rows(0)("IDTIPO_DOC_IDENTIDAD") Else IDTIPO_DOC_IDENTIDAD = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NU_DOCU_SUNA") Then NU_DOCU_SUNA = dvLISTAR_PERSONA.Table.Rows(0)("NU_DOCU_SUNA") Else NU_DOCU_SUNA = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("NU_RETE_SUNA") Then NU_RETE_SUNA = dvLISTAR_PERSONA.Table.Rows(0)("NU_RETE_SUNA") Else NU_RETE_SUNA = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDRUBRO") Then IDRUBRO = dvLISTAR_PERSONA.Table.Rows(0)("IDRUBRO") Else IDRUBRO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDCLASIFICACION_PERSONA") Then IDCLASIFICACION_PERSONA = dvLISTAR_PERSONA.Table.Rows(0)("IDCLASIFICACION_PERSONA") Else IDCLASIFICACION_PERSONA = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dvLISTAR_PERSONA.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dvLISTAR_PERSONA.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDROL_USUARIO") Then IDROL_USUARIO = dvLISTAR_PERSONA.Table.Rows(0)("IDROL_USUARIO") Else IDROL_USUARIO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IP") Then IP = dvLISTAR_PERSONA.Table.Rows(0)("IP") Else IP = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDUSUARIO_PERSONALMOD") Then IDUSUARIO_PERSONALMOD = dvLISTAR_PERSONA.Table.Rows(0)("IDUSUARIO_PERSONALMOD") Else IDUSUARIO_PERSONALMOD = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDROL_USUARIOMOD") Then IDROL_USUARIOMOD = dvLISTAR_PERSONA.Table.Rows(0)("IDROL_USUARIOMOD") Else IDROL_USUARIOMOD = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IPMOD") Then IPMOD = dvLISTAR_PERSONA.Table.Rows(0)("IPMOD") Else IPMOD = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("FECHA_ACTUALIZACION") Then FECHA_ACTUALIZACION = dvLISTAR_PERSONA.Table.Rows(0)("FECHA_ACTUALIZACION") Else FECHA_ACTUALIZACION = ""
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDPAIS") Then IDPAIS = dvLISTAR_PERSONA.Table.Rows(0)("IDPAIS") Else IDPAIS = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDDEPARTAMENTO") Then IDDEPARTAMENTO = dvLISTAR_PERSONA.Table.Rows(0)("IDDEPARTAMENTO") Else IDDEPARTAMENTO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDPROVINCIA") Then IDPROVINCIA = dvLISTAR_PERSONA.Table.Rows(0)("IDPROVINCIA") Else IDPROVINCIA = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDDISTRITO") Then IDDISTRITO = dvLISTAR_PERSONA.Table.Rows(0)("IDDISTRITO") Else IDDISTRITO = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("IDTIPO_FACTURACION") Then IDTIPO_FACTURACION = dvLISTAR_PERSONA.Table.Rows(0)("IDTIPO_FACTURACION") Else IDTIPO_FACTURACION = 0
                ''
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("SALDO_CLIENTE") Then Saldo_cliente = dvLISTAR_PERSONA.Table.Rows(0)("SALDO_CLIENTE") Else Saldo_cliente = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("LINEA_CREDITO") Then Linea_Credito = dvLISTAR_PERSONA.Table.Rows(0)("LINEA_CREDITO") Else Linea_Credito = 0
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("funcionario_carga") Then funcionarioNegocio = dvLISTAR_PERSONA.Table.Rows(0)("funcionario_carga") Else funcionarioNegocio = ""
                '
                If Not dvLISTAR_PERSONA.Table.Rows(0).IsNull("idfuncionario_carga") Then idfuncionarioNegocio = dvLISTAR_PERSONA.Table.Rows(0)("idfuncionario_carga") Else idfuncionarioNegocio = 0
                '
            End If
            Return dvLISTAR_PERSONA
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class
