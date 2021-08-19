Imports AccesoDatos
Public Class dtoCONTROL_COMPROBANTES
#Region "VARIABLES"
    Dim MyNRO_DOCUMENTO_FIN As String
    Dim MyIPMAQUINA_IMPRESION As String
    Dim MyIDCONTROL_COMPROBANTES As Integer
    Dim MyIDTIPO_COMPROBANTE As Integer
    Dim MySERIE As String
    Dim MyNRODIGITOS_SERIE As Integer
    Dim MyNRO_DOCUMENTO As String
    Dim MyNRODIGITOS_DOCUMENTO As Integer
    Dim MyIP As String
    Dim MyIPMOD As String
    Dim MyIDROL_USUARIO As Integer
    Dim MyIDROL_USUARIOMOD As Integer
    Dim MyIDUSUARIO_PERSONAL As Integer
    Dim MyIDUSUARIO_PERSONALMOD As Integer
    Dim MyIDESTADO_REGISTRO As Integer
    Dim MyFECHA_REGISTRO As String
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyIDAGENCIAS As Integer

#End Region
#Region "PROPIEDADES"
    Public Property NRO_DOCUMENTO_FIN() As String
        Get
            NRO_DOCUMENTO_FIN = MyNRO_DOCUMENTO_FIN
        End Get
        Set(ByVal value As String)
            MyNRO_DOCUMENTO_FIN = value
        End Set
    End Property
    Public Property IPMAQUINA_IMPRESION() As String
        Get
            IPMAQUINA_IMPRESION = MyIPMAQUINA_IMPRESION
        End Get
        Set(ByVal value As String)
            MyIPMAQUINA_IMPRESION = value
        End Set
    End Property
    Public Property IDCONTROL_COMPROBANTES() As Integer
        Get
            IDCONTROL_COMPROBANTES = MyIDCONTROL_COMPROBANTES
        End Get
        Set(ByVal value As Integer)
            MyIDCONTROL_COMPROBANTES = value
        End Set
    End Property
    Public Property IDTIPO_COMPROBANTE() As Integer
        Get
            IDTIPO_COMPROBANTE = MyIDTIPO_COMPROBANTE
        End Get
        Set(ByVal value As Integer)
            MyIDTIPO_COMPROBANTE = value
        End Set
    End Property
    Public Property SERIE() As String
        Get
            SERIE = MySERIE
        End Get
        Set(ByVal value As String)
            MySERIE = value
        End Set
    End Property
    Public Property NRODIGITOS_SERIE() As Integer
        Get
            NRODIGITOS_SERIE = MyNRODIGITOS_SERIE
        End Get
        Set(ByVal value As Integer)
            MyNRODIGITOS_SERIE = value
        End Set
    End Property
    Public Property NRO_DOCUMENTO() As String
        Get
            NRO_DOCUMENTO = MyNRO_DOCUMENTO
        End Get
        Set(ByVal value As String)
            MyNRO_DOCUMENTO = value
        End Set
    End Property
    Public Property NRODIGITOS_DOCUMENTO() As Integer
        Get
            NRODIGITOS_DOCUMENTO = MyNRODIGITOS_DOCUMENTO
        End Get
        Set(ByVal value As Integer)
            MyNRODIGITOS_DOCUMENTO = value
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
    Public Property IPMOD() As String
        Get
            IPMOD = MyIPMOD
        End Get
        Set(ByVal value As String)
            MyIPMOD = value
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
    Public Property IDROL_USUARIOMOD() As Integer
        Get
            IDROL_USUARIOMOD = MyIDROL_USUARIOMOD
        End Get
        Set(ByVal value As Integer)
            MyIDROL_USUARIOMOD = value
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
    Public Property IDUSUARIO_PERSONALMOD() As Integer
        Get
            IDUSUARIO_PERSONALMOD = MyIDUSUARIO_PERSONALMOD
        End Get
        Set(ByVal value As Integer)
            MyIDUSUARIO_PERSONALMOD = value
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
    Public Property IDAGENCIAS() As Integer
        Get
            IDAGENCIAS = MyIDAGENCIAS
        End Get
        Set(ByVal value As Integer)
            MyIDAGENCIAS = value
        End Set
    End Property

#End Region
#Region "METODOS"
    'Public Function FNLISTAR_CONTROL_COMPROBANTES2009(ByVal VOCONTROLUSUARIO As Object, ByVal P_IP As String, ByVal P_IDAGENCIAS As Integer, ByVal P_IDUSUARIO_PERSONAL As Integer, ByVal P_IDTIPO_COMPROBANTE As Integer) As DataView
    '    Try
    '        Dim dvLISTAR_CONTROL_COMPROBANTES As New DataView

    '        Dim Rst As New ADODB.Recordset
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_LISTAR_CONTROL_COMPROBANTES", 10, P_IP, 2, P_IDAGENCIAS, 1, P_IDUSUARIO_PERSONAL, 1, P_IDTIPO_COMPROBANTE, 1}
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        Dim DA As New OleDb.OleDbDataAdapter
    '        Dim DT As New DataTable
    '        DA.Fill(DT, Rst)
    '        dvLISTAR_CONTROL_COMPROBANTES = DT.DefaultView
    '        If dvLISTAR_CONTROL_COMPROBANTES.Count = 1 Then
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("NRO_DOCUMENTO_FIN") Then NRO_DOCUMENTO_FIN = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("NRO_DOCUMENTO_FIN") Else NRO_DOCUMENTO_FIN = ""
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IPMAQUINA_IMPRESION") Then IPMAQUINA_IMPRESION = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IPMAQUINA_IMPRESION") Else IPMAQUINA_IMPRESION = ""
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDCONTROL_COMPROBANTES") Then IDCONTROL_COMPROBANTES = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDCONTROL_COMPROBANTES") Else IDCONTROL_COMPROBANTES = 0
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDTIPO_COMPROBANTE") Then IDTIPO_COMPROBANTE = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDTIPO_COMPROBANTE") Else IDTIPO_COMPROBANTE = 0
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("SERIE") Then SERIE = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("SERIE") Else SERIE = ""
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("NRODIGITOS_SERIE") Then NRODIGITOS_SERIE = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("NRODIGITOS_SERIE") Else NRODIGITOS_SERIE = 0
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("NRO_DOCUMENTO") Then NRO_DOCUMENTO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("NRO_DOCUMENTO") Else NRO_DOCUMENTO = ""
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("NRODIGITOS_DOCUMENTO") Then NRODIGITOS_DOCUMENTO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("NRODIGITOS_DOCUMENTO") Else NRODIGITOS_DOCUMENTO = 0
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IP") Then IP = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IP") Else IP = ""
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IPMOD") Then IPMOD = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IPMOD") Else IPMOD = ""
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDROL_USUARIO") Then IDROL_USUARIO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDROL_USUARIO") Else IDROL_USUARIO = 0
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDROL_USUARIOMOD") Then IDROL_USUARIOMOD = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDROL_USUARIOMOD") Else IDROL_USUARIOMOD = 0
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDUSUARIO_PERSONALMOD") Then IDUSUARIO_PERSONALMOD = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDUSUARIO_PERSONALMOD") Else IDUSUARIO_PERSONALMOD = 0
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("FECHA_ACTUALIZACION") Then FECHA_ACTUALIZACION = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("FECHA_ACTUALIZACION") Else FECHA_ACTUALIZACION = ""
    '            If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDAGENCIAS") Then IDAGENCIAS = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDAGENCIAS") Else IDAGENCIAS = 0

    '        End If
    '        Return dvLISTAR_CONTROL_COMPROBANTES
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Public Function FNLISTAR_CONTROL_COMPROBANTES(ByVal P_IP As String, ByVal P_IDAGENCIAS As Integer, ByVal P_IDUSUARIO_PERSONAL As Integer, ByVal P_IDTIPO_COMPROBANTE As Integer) As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_LISTAR_CONTROL_COMPROBANTES", CommandType.StoredProcedure)
            db.AsignarParametro("P_IP", P_IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDAGENCIAS", P_IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", P_IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDTIPO_COMPROBANTE", P_IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_LISTAR_CONTROL_COMPRO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dvLISTAR_CONTROL_COMPROBANTES As DataView
            Dim ds As DataSet = db.EjecutarDataSet
            dvLISTAR_CONTROL_COMPROBANTES = ds.Tables(0).DefaultView
            If dvLISTAR_CONTROL_COMPROBANTES.Count = 1 Then
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("NRO_DOCUMENTO_FIN") Then NRO_DOCUMENTO_FIN = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("NRO_DOCUMENTO_FIN") Else NRO_DOCUMENTO_FIN = ""
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IPMAQUINA_IMPRESION") Then IPMAQUINA_IMPRESION = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IPMAQUINA_IMPRESION") Else IPMAQUINA_IMPRESION = ""
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDCONTROL_COMPROBANTES") Then IDCONTROL_COMPROBANTES = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDCONTROL_COMPROBANTES") Else IDCONTROL_COMPROBANTES = 0
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDTIPO_COMPROBANTE") Then IDTIPO_COMPROBANTE = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDTIPO_COMPROBANTE") Else IDTIPO_COMPROBANTE = 0
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("SERIE") Then SERIE = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("SERIE") Else SERIE = ""
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("NRODIGITOS_SERIE") Then NRODIGITOS_SERIE = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("NRODIGITOS_SERIE") Else NRODIGITOS_SERIE = 0
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("NRO_DOCUMENTO") Then NRO_DOCUMENTO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("NRO_DOCUMENTO") Else NRO_DOCUMENTO = ""
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("NRODIGITOS_DOCUMENTO") Then NRODIGITOS_DOCUMENTO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("NRODIGITOS_DOCUMENTO") Else NRODIGITOS_DOCUMENTO = 0
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IP") Then IP = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IP") Else IP = ""
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IPMOD") Then IPMOD = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IPMOD") Else IPMOD = ""
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDROL_USUARIO") Then IDROL_USUARIO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDROL_USUARIO") Else IDROL_USUARIO = 0
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDROL_USUARIOMOD") Then IDROL_USUARIOMOD = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDROL_USUARIOMOD") Else IDROL_USUARIOMOD = 0
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDUSUARIO_PERSONALMOD") Then IDUSUARIO_PERSONALMOD = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDUSUARIO_PERSONALMOD") Else IDUSUARIO_PERSONALMOD = 0
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("FECHA_ACTUALIZACION") Then FECHA_ACTUALIZACION = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("FECHA_ACTUALIZACION") Else FECHA_ACTUALIZACION = ""
                If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDAGENCIAS") Then IDAGENCIAS = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDAGENCIAS") Else IDAGENCIAS = 0
            End If
            Return dvLISTAR_CONTROL_COMPROBANTES

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        'Try
        '    Dim dvLISTAR_CONTROL_COMPROBANTES As New DataView

        '    Dim Rst As New ADODB.Recordset
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_LISTAR_CONTROL_COMPROBANTES", 10, P_IP, 2, P_IDAGENCIAS, 1, P_IDUSUARIO_PERSONAL, 1, P_IDTIPO_COMPROBANTE, 1}
        '    Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

        '    Dim DA As New OleDb.OleDbDataAdapter
        '    Dim DT As New DataTable
        '    DA.Fill(DT, Rst)
        '    dvLISTAR_CONTROL_COMPROBANTES = DT.DefaultView
        '    If dvLISTAR_CONTROL_COMPROBANTES.Count = 1 Then
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("NRO_DOCUMENTO_FIN") Then NRO_DOCUMENTO_FIN = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("NRO_DOCUMENTO_FIN") Else NRO_DOCUMENTO_FIN = ""
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IPMAQUINA_IMPRESION") Then IPMAQUINA_IMPRESION = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IPMAQUINA_IMPRESION") Else IPMAQUINA_IMPRESION = ""
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDCONTROL_COMPROBANTES") Then IDCONTROL_COMPROBANTES = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDCONTROL_COMPROBANTES") Else IDCONTROL_COMPROBANTES = 0
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDTIPO_COMPROBANTE") Then IDTIPO_COMPROBANTE = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDTIPO_COMPROBANTE") Else IDTIPO_COMPROBANTE = 0
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("SERIE") Then SERIE = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("SERIE") Else SERIE = ""
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("NRODIGITOS_SERIE") Then NRODIGITOS_SERIE = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("NRODIGITOS_SERIE") Else NRODIGITOS_SERIE = 0
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("NRO_DOCUMENTO") Then NRO_DOCUMENTO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("NRO_DOCUMENTO") Else NRO_DOCUMENTO = ""
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("NRODIGITOS_DOCUMENTO") Then NRODIGITOS_DOCUMENTO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("NRODIGITOS_DOCUMENTO") Else NRODIGITOS_DOCUMENTO = 0
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IP") Then IP = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IP") Else IP = ""
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IPMOD") Then IPMOD = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IPMOD") Else IPMOD = ""
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDROL_USUARIO") Then IDROL_USUARIO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDROL_USUARIO") Else IDROL_USUARIO = 0
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDROL_USUARIOMOD") Then IDROL_USUARIOMOD = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDROL_USUARIOMOD") Else IDROL_USUARIOMOD = 0
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDUSUARIO_PERSONAL") Then IDUSUARIO_PERSONAL = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDUSUARIO_PERSONAL") Else IDUSUARIO_PERSONAL = 0
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDUSUARIO_PERSONALMOD") Then IDUSUARIO_PERSONALMOD = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDUSUARIO_PERSONALMOD") Else IDUSUARIO_PERSONALMOD = 0
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDESTADO_REGISTRO") Then IDESTADO_REGISTRO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDESTADO_REGISTRO") Else IDESTADO_REGISTRO = 0
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("FECHA_ACTUALIZACION") Then FECHA_ACTUALIZACION = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("FECHA_ACTUALIZACION") Else FECHA_ACTUALIZACION = ""
        '        If Not dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0).IsNull("IDAGENCIAS") Then IDAGENCIAS = dvLISTAR_CONTROL_COMPROBANTES.Table.Rows(0)("IDAGENCIAS") Else IDAGENCIAS = 0

        '    End If
        '    Return dvLISTAR_CONTROL_COMPROBANTES
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        'End Try
    End Function

#End Region
End Class
