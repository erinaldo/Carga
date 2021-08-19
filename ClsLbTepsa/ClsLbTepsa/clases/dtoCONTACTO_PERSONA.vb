Imports AccesoDatos
Public Class dtoCONTACTO_PERSONA
#Region "VARIABLES"
    Dim MyESTADO_REGISTRO As Integer
    Dim MyDATOS_PERSONALES As String
    Dim MyDEFECTO As Integer
    Dim MyIDCONTACTO_PERSONA As Integer
    Dim MyIDTIPO_CONTACTO As Integer
    Dim MyIDPERSONA As Integer
    Dim MyNOMBRES As String
    Dim MyAPEPAT As String
    Dim MyAPEMAT As String
    Dim MyIDTIPO_DOCUMENTO_CONTACTO As Integer
    Dim MyNRODOCUMENTO As String
    Dim MyEMAIL_CONTACTO As String
    Dim MySEXO As String
    Dim MyIDUSUARIO_PERSONAL As Integer
    Dim MyIDROL_USUARIO As Integer
    Dim MyIP As String
    Dim MyFECHA_REGISTRO As String
    Dim MyIDUSUARIO_PERSONALMOD As Integer
    Dim MyIDROL_USUARIOMOD As Integer
    Dim MyIPMOD As String
    Dim MyFECHA_ACTUALIZACION As String
#End Region
#Region "PROPIEDADES"
    Public Property ESTADO_REGISTRO() As Integer
        Get
            ESTADO_REGISTRO = MyESTADO_REGISTRO
        End Get
        Set(ByVal value As Integer)
            MyESTADO_REGISTRO = value
        End Set
    End Property
    Public Property DATOS_PERSONALES() As String
        Get
            DATOS_PERSONALES = MyDATOS_PERSONALES
        End Get
        Set(ByVal value As String)
            MyDATOS_PERSONALES = value
        End Set
    End Property
    Public Property DEFECTO() As Integer
        Get
            DEFECTO = MyDEFECTO
        End Get
        Set(ByVal value As Integer)
            MyDEFECTO = value
        End Set
    End Property
    Public Property IDCONTACTO_PERSONA() As Integer
        Get
            IDCONTACTO_PERSONA = MyIDCONTACTO_PERSONA
        End Get
        Set(ByVal value As Integer)
            MyIDCONTACTO_PERSONA = value
        End Set
    End Property
    Public Property IDTIPO_CONTACTO() As Integer
        Get
            IDTIPO_CONTACTO = MyIDTIPO_CONTACTO
        End Get
        Set(ByVal value As Integer)
            MyIDTIPO_CONTACTO = value
        End Set
    End Property
    Public Property IDPERSONA() As Integer
        Get
            IDPERSONA = MyIDPERSONA
        End Get
        Set(ByVal value As Integer)
            MyIDPERSONA = value
        End Set
    End Property
    Public Property NOMBRES() As String
        Get
            NOMBRES = MyNOMBRES
        End Get
        Set(ByVal value As String)
            MyNOMBRES = value
        End Set
    End Property
    Public Property APEPAT() As String
        Get
            APEPAT = MyAPEPAT
        End Get
        Set(ByVal value As String)
            MyAPEPAT = value
        End Set
    End Property
    Public Property APEMAT() As String
        Get
            APEMAT = MyAPEMAT
        End Get
        Set(ByVal value As String)
            MyAPEMAT = value
        End Set
    End Property
    Public Property IDTIPO_DOCUMENTO_CONTACTO() As Integer
        Get
            IDTIPO_DOCUMENTO_CONTACTO = MyIDTIPO_DOCUMENTO_CONTACTO
        End Get
        Set(ByVal value As Integer)
            MyIDTIPO_DOCUMENTO_CONTACTO = value
        End Set
    End Property
    Public Property NRODOCUMENTO() As String
        Get
            NRODOCUMENTO = MyNRODOCUMENTO
        End Get
        Set(ByVal value As String)
            MyNRODOCUMENTO = value
        End Set
    End Property
    Public Property EMAIL_CONTACTO() As String
        Get
            EMAIL_CONTACTO = MyEMAIL_CONTACTO
        End Get
        Set(ByVal value As String)
            MyEMAIL_CONTACTO = value
        End Set
    End Property
    Public Property SEXO() As String
        Get
            SEXO = MySEXO
        End Get
        Set(ByVal value As String)
            MySEXO = value
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
#End Region
#Region "METODOS"

    'Public Function FN_L_CONTACTO_PERSONA_RP2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_IDPERSONA As Integer) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_CONTACTO_PERSONA_RP", 4, Str(P_IDPERSONA), 2}
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

    Public Function FN_L_CONTACTO_PERSONA_RP(ByVal P_IDPERSONA As Integer) As DataView
        Try
            Dim dv As New DataView
            'Dim Rst As New ADODB.Recordset
            'Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_CONTACTO_PERSONA_RP", 4, Str(P_IDPERSONA), 2}
            'Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            'Dim DA As New OleDb.OleDbDataAdapter
            Dim DT As New DataTable
            'DA.Fill(DT, Rst)

            Dim db As New BaseDatos

            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_L_CONTACTO_PERSONA_RP", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDPERSONA", Str(P_IDPERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LISTAR_CONTACTO_PERSONA_RP", OracleClient.OracleType.Cursor)
            db.Desconectar()

            DT = db.EjecutarDataTable
            dv = DT.DefaultView


            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function FN_L_CONTACTO_PERSONA_R2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_IDPERSONA As Integer) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_CONTACTO_PERSONA_R", 4, Str(P_IDPERSONA), 2}
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
    Public Function FN_L_CONTACTO_PERSONA_R(ByVal P_IDPERSONA As Integer) As DataView
        Try
            Dim dv As New DataView
            'Dim Rst As New ADODB.Recordset
            'Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_CONTACTO_PERSONA_R", 4, Str(P_IDPERSONA), 2}
            'Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            'Dim DA As New OleDb.OleDbDataAdapter
            Dim DT As New DataTable
            'DA.Fill(DT, Rst)

            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_L_CONTACTO_PERSONA_R", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDPERSONA", Str(P_IDPERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LISTAR_CONTACTO_PERSONA_R", OracleClient.OracleType.Cursor)
            db.Desconectar()
            DT = db.EjecutarDataTable
            dv = DT.DefaultView
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_L_CONTACTO_PERSONA_D2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_IDPERSONA As Integer) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_CONTACTO_PERSONA_D", 4, Str(P_IDPERSONA), 2}
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
    Public Function FN_L_CONTACTO_PERSONA_D(ByVal P_IDPERSONA As Integer) As DataView
        Try
            Dim dv As New DataView
            'Dim Rst As New ADODB.Recordset
            'Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_CONTACTO_PERSONA_D", 4, Str(P_IDPERSONA), 2}
            'Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            'Dim DA As New OleDb.OleDbDataAdapter
            Dim DT As New DataTable
            'DA.Fill(DT, Rst)
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_L_CONTACTO_PERSONA_D", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDPERSONA", Str(P_IDPERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_L_Contacto_Persona_D", OracleClient.OracleType.Cursor)
            db.Desconectar()
            DT = db.EjecutarDataTable

            dv = DT.DefaultView


            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

#End Region
End Class
