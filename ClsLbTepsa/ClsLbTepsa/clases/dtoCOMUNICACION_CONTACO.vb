Imports AccesoDatos
Public Class dtoCOMUNICACION_CONTACO
#Region "VARIABLES"
    Dim MyIDCOMUNICACION_CONTACTO As Integer
    Dim MyNROCOMUNICACION_CONTACTO As String
    Dim MyIDTIPO_COMUNICACION As Integer
    Dim MyIDCONTACTO_PERSONA As Integer
#End Region

#Region "PROPIEDADES"
    Public Property IDCOMUNICACION_CONTACTO() As Integer
        Get
            IDCOMUNICACION_CONTACTO = MyIDCOMUNICACION_CONTACTO
        End Get
        Set(ByVal value As Integer)
            MyIDCOMUNICACION_CONTACTO = value
        End Set
    End Property
    Public Property NROCOMUNICACION_CONTACTO() As String
        Get
            NROCOMUNICACION_CONTACTO = MyNROCOMUNICACION_CONTACTO
        End Get
        Set(ByVal value As String)
            MyNROCOMUNICACION_CONTACTO = value
        End Set
    End Property
    Public Property IDTIPO_COMUNICACION() As Integer
        Get
            IDTIPO_COMUNICACION = MyIDTIPO_COMUNICACION
        End Get
        Set(ByVal value As Integer)
            MyIDTIPO_COMUNICACION = value
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

#End Region

#Region "METODOS"
    'Public Function FN_L_Comunicacion_Contacto_D_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_Idcontacto_Persona As Integer) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_Comunicacion_Contacto_D", 4, P_Idcontacto_Persona, 1}
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

    Public Function FN_L_Comunicacion_Contacto_D(ByVal P_Idcontacto_Persona As Integer) As DataView
        Try
            Dim dv As New DataView
            'Dim Rst As New ADODB.Recordset
            'Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_Comunicacion_Contacto_D", 4, P_Idcontacto_Persona, 1}
            'Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            'Dim DA As New OleDb.OleDbDataAdapter
            Dim DT As New DataTable
            'DA.Fill(DT, Rst)
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_L_Comunicacion_Contacto_D", CommandType.StoredProcedure)
            db.AsignarParametro("P_Idcontacto_Persona", P_Idcontacto_Persona, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_L_Comunicacion_Contacto_D", OracleClient.OracleType.Cursor)
            db.Desconectar()
            DT = db.EjecutarDataTable
            dv = DT.DefaultView
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_L_Comunicacion_Contacto_RP2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_Idcontacto_Persona As Integer) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_Comunicacion_Contacto_RP", 4, P_Idcontacto_Persona, 1}
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
    Public Function FN_L_Comunicacion_Contacto_RP(ByVal P_Idcontacto_Persona As Integer) As DataView
        Try
            Dim dv As New DataView
            Dim DT As New DataTable
            '
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_L_Comunicacion_Contacto_RP", CommandType.StoredProcedure)
            db.AsignarParametro("P_Idcontacto_Persona", P_Idcontacto_Persona, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_L_Comunicacion_Contacto_RP", OracleClient.OracleType.Cursor)
            db.Desconectar()
            '
            DT = db.EjecutarDataTable
            dv = DT.DefaultView
            '
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_L_Comunicacion_Contacto_R_2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_Idcontacto_Persona As Integer) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_Comunicacion_Contacto_R", 4, P_Idcontacto_Persona, 1}
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        '
    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
#End Region
End Class
