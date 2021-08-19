Imports AccesoDatos
Public Class dtoLISTAAGENCIAUSUARIOS
#Region "VARIABLES"
    Public iIDUSUARIO_PERSONAL As Integer
    Public iIDAGENCIAS As Integer
    Public iNOMBRE_AGENCIA As String
    Public iNombres As String
    Public iE_MAIL As String
    Public iCOMUNICACION As String
    Public iIDESTADO_REGISTRO As Integer
    Public iFILTROBUSQUEDA As String
    Public iCONTROLFILTRO As Integer


#End Region
#Region "FILTROS RST"
    'Public rst_List_User_Agencias As ADODB.Recordset
    Public rst_List_User_Agencias As DataTable
#End Region
#Region "METODOS"
    'Public Sub SetCliente2009(ByVal rst As ADODB.Recordset)
    'Try
    '    iIDUSUARIO_PERSONAL = Int(rst.Fields.Item(0).Value)
    '    iIDAGENCIAS = Int(rst.Fields.Item(0).Value)
    '    iNOMBRE_AGENCIA = rst.Fields.Item(0).Value.ToString()
    '    iNombres = rst.Fields.Item(0).Value.ToString()
    '    iE_MAIL = rst.Fields.Item(0).Value.ToString()
    '    iCOMUNICACION = rst.Fields.Item(0).Value.ToString()
    '    iIDESTADO_REGISTRO = Int(rst.Fields.Item(0).Value)
    'Catch ex As Exception
    '    ' MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    'End Try
    'End Sub
    Public Sub SetCliente(ByVal rst As DataTable)
        Try
            iIDUSUARIO_PERSONAL = Int(rst.Rows(0).Item(0).ToString)
            iIDAGENCIAS = Int(rst.Rows(0).Item(0).ToString)
            iNOMBRE_AGENCIA = rst.Rows(0).Item(0).ToString()
            iNombres = rst.Rows(0).Item(0).ToString()
            iE_MAIL = rst.Rows(0).Item(0).ToString()
            iCOMUNICACION = rst.Rows(0).Item(0).ToString()
            iIDESTADO_REGISTRO = Int(rst.Rows(0).Item(0).ToString)
        Catch ex As Exception
            ' MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    'Public Sub GetFiltrodatos2009()
    'Try
    '    Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLUSUARIO.SP_FILTRO_USUARIO_AGENCIA", 6, iCONTROLFILTRO, 1, iFILTROBUSQUEDA, 2}
    '    'rst_List_User_Agencias = Nothing
    '    'rst_List_User_Agencias = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    'Catch ex As Exception
    '    MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    'End Try
    'End Sub
    Public Sub GetFiltrodatos()
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'acceso 21/04/2010
            'db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_FILTRO_USUARIO_AGENCIA", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_FILTRO_USUARIO_AGENCIA_1", CommandType.StoredProcedure)
            db.AsignarParametro("idControl", iCONTROLFILTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iFiltro", iFILTROBUSQUEDA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_usuario_Agencia", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_List_User_Agencias = ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        'datahelper
        'Try
        '    Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLUSUARIO.SP_FILTRO_USUARIO_AGENCIA", 6, iCONTROLFILTRO, 1, iFILTROBUSQUEDA, 2}
        '    rst_List_User_Agencias = Nothing
        '    rst_List_User_Agencias = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        'Catch ex As Exception
        '    MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        'End Try
    End Sub

#End Region
#Region "PROPIEDADES"
    Public Property IDUSUARIO_PERSONAL() As Integer
        Get
            IDUSUARIO_PERSONAL = iIDUSUARIO_PERSONAL
        End Get
        Set(ByVal Value As Integer)
            iIDUSUARIO_PERSONAL = Value
        End Set
    End Property
    Public Property IDAGENCIAS() As Integer
        Get
            IDAGENCIAS = iIDAGENCIAS
        End Get
        Set(ByVal Value As Integer)
            iIDAGENCIAS = Value
        End Set
    End Property
    Public Property NOMBRE_AGENCIA() As String
        Get
            NOMBRE_AGENCIA = iNOMBRE_AGENCIA
        End Get
        Set(ByVal Value As String)
            iNOMBRE_AGENCIA = Value
        End Set
    End Property
    Public Property Nombres() As String
        Get
            Nombres = iNombres
        End Get
        Set(ByVal Value As String)
            iNombres = Value
        End Set
    End Property
    Public Property E_MAIL() As String
        Get
            E_MAIL = iE_MAIL
        End Get
        Set(ByVal Value As String)
            iE_MAIL = Value
        End Set
    End Property
    Public Property COMUNICACION() As String
        Get
            COMUNICACION = iCOMUNICACION
        End Get
        Set(ByVal Value As String)
            iCOMUNICACION = Value
        End Set
    End Property
    Public Property IDESTADO_REGISTRO() As Integer
        Get
            IDESTADO_REGISTRO = iIDESTADO_REGISTRO
        End Get
        Set(ByVal Value As Integer)
            iIDESTADO_REGISTRO = Value
        End Set
    End Property

    Public Property FILTROBUSQUEDA() As String
        Get
            FILTROBUSQUEDA = iFILTROBUSQUEDA
        End Get
        Set(ByVal Value As String)
            iFILTROBUSQUEDA = Value
        End Set
    End Property

    Public Property CONTROLFILTRO() As Integer
        Get
            CONTROLFILTRO = iCONTROLFILTRO
        End Get
        Set(ByVal Value As Integer)
            iCONTROLFILTRO = Value
        End Set
    End Property

#End Region
End Class

