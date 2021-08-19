Imports AccesoDatos
Public Class dtoDIRECCION_CONSIGNADO
#Region "VARIABLES"
    Dim MyIDDIRECCION_CONSIGNADO As Integer
    Dim MyIDTIPO_DIRECCION As Integer
    Dim MyIDPERSONA As Integer
    Dim MyDIRECCION As String
    Dim MyDE_REFERENCIA As String
    Dim MyCO_UBIC_GEOG As String
    Dim MyDIRECCION_FACTURACION As Integer
    Dim MyCODIGO_UBIGEO As String
    Dim MyHORA_RECOJO_INICIO As String
    Dim MyHORA_RECOJO_FIN As String
    Dim MyHORA_ENTREGA_INICIO As String
    Dim MyHORA_ENTREGA_FIN As String
    Dim MyIDUSUARIO_PERSONAL As Integer
    Dim MyIDROL_USUARIO As Integer
    Dim MyIP As String
    Dim MyFECHA_REGISTRO As String
    Dim MyIDUSUARIO_PERSONALMOD As Integer
    Dim MyIDROL_USUARIOMOD As Integer
    Dim MyIPMOD As String
    Dim MyFECHA_ACTUALZIACION As String
    Dim MyIDPAIS As Integer
    Dim MyIDDEPARTAMENTO As Integer
    Dim MyIDPROVINCIA As Integer
    Dim MyIDDISTRITO As Integer
    Dim MyIDESTADO_REGISTRO As Integer

#End Region

#Region "PROPIEDADES"
    Public Property IDDIRECCION_CONSIGNADO() As Integer
        Get
            IDDIRECCION_CONSIGNADO = MyIDDIRECCION_CONSIGNADO
        End Get
        Set(ByVal value As Integer)
            MyIDDIRECCION_CONSIGNADO = value
        End Set
    End Property
    Public Property IDTIPO_DIRECCION() As Integer
        Get
            IDTIPO_DIRECCION = MyIDTIPO_DIRECCION
        End Get
        Set(ByVal value As Integer)
            MyIDTIPO_DIRECCION = value
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
    Public Property DIRECCION() As String
        Get
            DIRECCION = MyDIRECCION
        End Get
        Set(ByVal value As String)
            MyDIRECCION = value
        End Set
    End Property
    Public Property DE_REFERENCIA() As String
        Get
            DE_REFERENCIA = MyDE_REFERENCIA
        End Get
        Set(ByVal value As String)
            MyDE_REFERENCIA = value
        End Set
    End Property
    Public Property CO_UBIC_GEOG() As String
        Get
            CO_UBIC_GEOG = MyCO_UBIC_GEOG
        End Get
        Set(ByVal value As String)
            MyCO_UBIC_GEOG = value
        End Set
    End Property
    Public Property DIRECCION_FACTURACION() As Integer
        Get
            DIRECCION_FACTURACION = MyDIRECCION_FACTURACION
        End Get
        Set(ByVal value As Integer)
            MyDIRECCION_FACTURACION = value
        End Set
    End Property
    Public Property CODIGO_UBIGEO() As String
        Get
            CODIGO_UBIGEO = MyCODIGO_UBIGEO
        End Get
        Set(ByVal value As String)
            MyCODIGO_UBIGEO = value
        End Set
    End Property
    Public Property HORA_RECOJO_INICIO() As String
        Get
            HORA_RECOJO_INICIO = MyHORA_RECOJO_INICIO
        End Get
        Set(ByVal value As String)
            MyHORA_RECOJO_INICIO = value
        End Set
    End Property
    Public Property HORA_RECOJO_FIN() As String
        Get
            HORA_RECOJO_FIN = MyHORA_RECOJO_FIN
        End Get
        Set(ByVal value As String)
            MyHORA_RECOJO_FIN = value
        End Set
    End Property
    Public Property HORA_ENTREGA_INICIO() As String
        Get
            HORA_ENTREGA_INICIO = MyHORA_ENTREGA_INICIO
        End Get
        Set(ByVal value As String)
            MyHORA_ENTREGA_INICIO = value
        End Set
    End Property
    Public Property HORA_ENTREGA_FIN() As String
        Get
            HORA_ENTREGA_FIN = MyHORA_ENTREGA_FIN
        End Get
        Set(ByVal value As String)
            MyHORA_ENTREGA_FIN = value
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
    Public Property FECHA_ACTUALZIACION() As String
        Get
            FECHA_ACTUALZIACION = MyFECHA_ACTUALZIACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ACTUALZIACION = value
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
    Public Property IDESTADO_REGISTRO() As Integer
        Get
            IDESTADO_REGISTRO = MyIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Integer)
            MyIDESTADO_REGISTRO = value
        End Set
    End Property

#End Region

#Region "METODOS"
    'Public Function FN_L_DIECCION_CONSIGNADO_R2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_IDPERSONA As Integer) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_DIECCION_CONSIGNADO_R", 4, P_IDPERSONA, 1}
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

    'Public Function FN_L_DIECCION_CONSIGNADO_RP2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_IDPERSONA As Integer) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_DIECCION_CONSIGNADO_RP", 4, P_IDPERSONA, 1}
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

    Public Function FN_L_DIECCION_CONSIGNADO_RP(ByVal P_IDPERSONA As Integer) As DataView
        Try
            Dim dv As New DataView
            'Dim Rst As New ADODB.Recordset
            'Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_L_DIECCION_CONSIGNADO_RP", 4, P_IDPERSONA, 1}
            'Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            'Dim DA As New OleDb.OleDbDataAdapter
            Dim DT As New DataTable
            'DA.Fill(DT, Rst)

            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_L_DIECCION_CONSIGNADO_RP", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDPERSONA", P_IDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_L_DIECCION_CONSIGNADO_RP", OracleClient.OracleType.Cursor)
            db.Desconectar()
            DT = db.EjecutarDataTable

            dv = DT.DefaultView

            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function FN_L_DIECCION_CONSIGNADO_D2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_IDPERSONA As Integer) As DataView
    '    Try
    '        Dim dv As New DataView
    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.sp_l_direccion_consignado_d", 4, P_IDPERSONA, 1}
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
    Public Function FN_L_DIECCION_CONSIGNADO_D(ByVal P_IDPERSONA As Integer) As DataView
        Try
            Dim dv As New DataView
            'Dim Rst As New ADODB.Recordset
            'Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.sp_l_direccion_consignado_d", 4, P_IDPERSONA, 1}
            'Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            'Dim DA As New OleDb.OleDbDataAdapter
            Dim DT As New DataTable
            'DA.Fill(DT, Rst)
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.sp_l_direccion_consignado_d", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDPERSONA", P_IDPERSONA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_L_Direccion_Consignado_D", OracleClient.OracleType.Cursor)
            db.Desconectar()
            DT = db.EjecutarDataTable
            '
            dv = DT.DefaultView
            '
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class
