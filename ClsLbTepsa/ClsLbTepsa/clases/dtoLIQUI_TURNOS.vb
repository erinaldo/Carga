Imports AccesoDatos
Public Class dtoLIQUI_TURNOS
    Dim MyEntre_Soles As Double
    Dim MyEntre_Dola As Double
    Dim MyEntre_Tipo_Cambi As Double

    Dim MyObser As String
    Dim MyOPERACION As Long
    Dim MyIDLIQUI_TURNOS As Long
    Dim MyNRO_FACTU As Long
    Dim MyTOTAL_MONTO_FACTU As Long
    Dim MyNRO_BOLE As Long
    Dim MyTOTAL_MONTO_BOLE As Long
    Dim MyNRO_ANULA As Long
    Dim MyTOTAL_MONTO_ANULA As Long
    Dim MyNRO_PAGO_ENTRE As Long
    Dim MyTOTAL_MONTO_PAGO_ENTRE As Long
    Dim MyNRO_DEVO As Long
    Dim MyTOTAL_MONTO_DEVO As Long
    Dim MyNRO_TARJE_CREDI As Long
    Dim MyTOTAL_MONTO_TARJE_CREDI As Long
    Dim MyNRO_SOBRES As Long
    Dim MyTOTAL_MONTO_SOBRES As Long
    Dim MyTOTAL_PESO As Long
    Dim MyTOTAL_VOLU As Long
    Dim MyTOTAL_SOBRES As Long
    Dim MyTIPO_CAMBI As Long
    Dim MyTOTAL_MONTO_SOLES As Long
    Dim MyTOTAL_MONTO_DOLA As Long
    Dim MyTOTAL_MONTO_BOUCHER_SOLES As Long
    Dim MyTOTAL_MONTO_BOUCHER_DOLA As Long
    Dim MyFECHA_APER As String
    Dim MyFECHA_CIERRE As String
    Dim MyIMPRESO As Long
    Dim MyCERRADO As Long
    Dim MyIP As String
    Dim MyIPMOD As String
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyFECHA_REGISTRO As String
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyIDROL_USUARIO As Long
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyIDAGENCIAS As Long
    Dim MyIDUNIDAD_AGENCIA As Long
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyFECHA_INICIAL As String
    Dim MyFECHA_FINAL As String

    Public Property Entre_Soles() As Double
        Get
            Entre_Soles = MyEntre_Soles
        End Get
        Set(ByVal value As Double)
            MyEntre_Soles = value
        End Set
    End Property
    Public Property Entre_Dola() As Double
        Get
            Entre_Dola = MyEntre_Dola
        End Get
        Set(ByVal value As Double)
            MyEntre_Dola = value
        End Set
    End Property

    Public Property Entre_Tipo_Cambi() As Double
        Get
            Entre_Tipo_Cambi = MyEntre_Tipo_Cambi
        End Get
        Set(ByVal value As Double)
            MyEntre_Tipo_Cambi = value
        End Set
    End Property
    Public Property obser() As String
        Get
            obser = MyObser
        End Get
        Set(ByVal value As String)
            MyObser = value
        End Set
    End Property
    Public Property FECHA_INICIAL() As String
        Get
            FECHA_INICIAL = MyFECHA_INICIAL
        End Get
        Set(ByVal value As String)
            MyFECHA_INICIAL = value
        End Set
    End Property
    Public Property FECHA_FINAL() As String

        Get
            FECHA_FINAL = MyFECHA_FINAL
        End Get
        Set(ByVal value As String)
            MyFECHA_FINAL = value
        End Set
    End Property
    Public Property OPERACION() As Long

        Get
            OPERACION = MyOPERACION
        End Get
        Set(ByVal value As Long)
            MyOPERACION = value
        End Set
    End Property
    Public Property IDLIQUI_TURNOS() As Long

        Get
            IDLIQUI_TURNOS = MyIDLIQUI_TURNOS
        End Get
        Set(ByVal value As Long)
            MyIDLIQUI_TURNOS = value
        End Set
    End Property
    Public Property NRO_FACTU() As Long

        Get
            NRO_FACTU = MyNRO_FACTU
        End Get
        Set(ByVal value As Long)
            MyNRO_FACTU = value
        End Set
    End Property
    Public Property TOTAL_MONTO_FACTU() As Long

        Get
            TOTAL_MONTO_FACTU = MyTOTAL_MONTO_FACTU
        End Get
        Set(ByVal value As Long)
            MyTOTAL_MONTO_FACTU = value
        End Set
    End Property
    Public Property NRO_BOLE() As Long

        Get
            NRO_BOLE = MyNRO_BOLE
        End Get
        Set(ByVal value As Long)
            MyNRO_BOLE = value
        End Set
    End Property
    Public Property TOTAL_MONTO_BOLE() As Long

        Get
            TOTAL_MONTO_BOLE = MyTOTAL_MONTO_BOLE
        End Get
        Set(ByVal value As Long)
            MyTOTAL_MONTO_BOLE = value
        End Set
    End Property
    Public Property NRO_ANULA() As Long

        Get
            NRO_ANULA = MyNRO_ANULA
        End Get
        Set(ByVal value As Long)
            MyNRO_ANULA = value
        End Set
    End Property
    Public Property TOTAL_MONTO_ANULA() As Long

        Get
            TOTAL_MONTO_ANULA = MyTOTAL_MONTO_ANULA
        End Get
        Set(ByVal value As Long)
            MyTOTAL_MONTO_ANULA = value
        End Set
    End Property
    Public Property NRO_PAGO_ENTRE() As Long

        Get
            NRO_PAGO_ENTRE = MyNRO_PAGO_ENTRE
        End Get
        Set(ByVal value As Long)
            MyNRO_PAGO_ENTRE = value
        End Set
    End Property
    Public Property TOTAL_MONTO_PAGO_ENTRE() As Long

        Get
            TOTAL_MONTO_PAGO_ENTRE = MyTOTAL_MONTO_PAGO_ENTRE
        End Get
        Set(ByVal value As Long)
            MyTOTAL_MONTO_PAGO_ENTRE = value
        End Set
    End Property
    Public Property NRO_DEVO() As Long

        Get
            NRO_DEVO = MyNRO_DEVO
        End Get
        Set(ByVal value As Long)
            MyNRO_DEVO = value
        End Set
    End Property
    Public Property TOTAL_MONTO_DEVO() As Long

        Get
            TOTAL_MONTO_DEVO = MyTOTAL_MONTO_DEVO
        End Get
        Set(ByVal value As Long)
            MyTOTAL_MONTO_DEVO = value
        End Set
    End Property
    Public Property NRO_TARJE_CREDI() As Long

        Get
            NRO_TARJE_CREDI = MyNRO_TARJE_CREDI
        End Get
        Set(ByVal value As Long)
            MyNRO_TARJE_CREDI = value
        End Set
    End Property
    Public Property TOTAL_MONTO_TARJE_CREDI() As Long

        Get
            TOTAL_MONTO_TARJE_CREDI = MyTOTAL_MONTO_TARJE_CREDI
        End Get
        Set(ByVal value As Long)
            MyTOTAL_MONTO_TARJE_CREDI = value
        End Set
    End Property
    Public Property NRO_SOBRES() As Long

        Get
            NRO_SOBRES = MyNRO_SOBRES
        End Get
        Set(ByVal value As Long)
            MyNRO_SOBRES = value
        End Set
    End Property
    Public Property TOTAL_MONTO_SOBRES() As Long

        Get
            TOTAL_MONTO_SOBRES = MyTOTAL_MONTO_SOBRES
        End Get
        Set(ByVal value As Long)
            MyTOTAL_MONTO_SOBRES = value
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
    Public Property TOTAL_VOLU() As Long

        Get
            TOTAL_VOLU = MyTOTAL_VOLU
        End Get
        Set(ByVal value As Long)
            MyTOTAL_VOLU = value
        End Set
    End Property
    Public Property TOTAL_SOBRES() As Long

        Get
            TOTAL_SOBRES = MyTOTAL_SOBRES
        End Get
        Set(ByVal value As Long)
            MyTOTAL_SOBRES = value
        End Set
    End Property
    Public Property TIPO_CAMBI() As Long

        Get
            TIPO_CAMBI = MyTIPO_CAMBI
        End Get
        Set(ByVal value As Long)
            MyTIPO_CAMBI = value
        End Set
    End Property
    Public Property TOTAL_MONTO_SOLES() As Long

        Get
            TOTAL_MONTO_SOLES = MyTOTAL_MONTO_SOLES
        End Get
        Set(ByVal value As Long)
            MyTOTAL_MONTO_SOLES = value
        End Set
    End Property
    Public Property TOTAL_MONTO_DOLA() As Long

        Get
            TOTAL_MONTO_DOLA = MyTOTAL_MONTO_DOLA
        End Get
        Set(ByVal value As Long)
            MyTOTAL_MONTO_DOLA = value
        End Set
    End Property
    Public Property TOTAL_MONTO_BOUCHER_SOLES() As Long

        Get
            TOTAL_MONTO_BOUCHER_SOLES = MyTOTAL_MONTO_BOUCHER_SOLES
        End Get
        Set(ByVal value As Long)
            MyTOTAL_MONTO_BOUCHER_SOLES = value
        End Set
    End Property
    Public Property TOTAL_MONTO_BOUCHER_DOLA() As Long

        Get
            TOTAL_MONTO_BOUCHER_DOLA = MyTOTAL_MONTO_BOUCHER_DOLA
        End Get
        Set(ByVal value As Long)
            MyTOTAL_MONTO_BOUCHER_DOLA = value
        End Set
    End Property
    Public Property FECHA_APER() As String

        Get
            FECHA_APER = MyFECHA_APER
        End Get
        Set(ByVal value As String)
            MyFECHA_APER = value
        End Set
    End Property
    Public Property FECHA_CIERRE() As String

        Get
            FECHA_CIERRE = MyFECHA_CIERRE
        End Get
        Set(ByVal value As String)
            MyFECHA_CIERRE = value
        End Set
    End Property
    Public Property IMPRESO() As Long

        Get
            IMPRESO = MyIMPRESO
        End Get
        Set(ByVal value As Long)
            MyIMPRESO = value
        End Set
    End Property
    Public Property CERRADO() As Long

        Get
            CERRADO = MyCERRADO
        End Get
        Set(ByVal value As Long)
            MyCERRADO = value
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
    Public Property IDUSUARIO_PERSONAL() As Long

        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL = value
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
    Public Property IDROL_USUARIO() As Long

        Get
            IDROL_USUARIO = MyIDROL_USUARIO
        End Get
        Set(ByVal value As Long)
            MyIDROL_USUARIO = value
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
    Public Property IDAGENCIAS() As Long

        Get
            IDAGENCIAS = MyIDAGENCIAS
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS = value
        End Set
    End Property
    Public Property IDUNIDAD_AGENCIA() As Long

        Get
            IDUNIDAD_AGENCIA = MyIDUNIDAD_AGENCIA
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIA = value
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
    'Public Function SP_INSUPD_LIQUI_TURNOS_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim DT As New DataTable
    '    Dim Rst As New ADODB.Recordset
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_INSUPD_LIQUI_TURNOS_", 78, _
    '        OPERACION, 1, _
    '        NRO_FACTU, 1, _
    '        TOTAL_MONTO_FACTU, 3, _
    '        NRO_BOLE, 1, _
    '        TOTAL_MONTO_BOLE, 3, _
    '        NRO_ANULA, 1, _
    '        TOTAL_MONTO_ANULA, 3, _
    '        NRO_PAGO_ENTRE, 1, _
    '        TOTAL_MONTO_PAGO_ENTRE, 3, _
    '        NRO_DEVO, 1, _
    '        TOTAL_MONTO_DEVO, 3, _
    '        NRO_TARJE_CREDI, 1, _
    '        TOTAL_MONTO_TARJE_CREDI, 3, _
    '        NRO_SOBRES, 1, _
    '        TOTAL_MONTO_SOBRES, 3, _
    '        TOTAL_PESO, 3, _
    '        TOTAL_VOLU, 3, _
    '        TOTAL_SOBRES, 3, _
    '        TIPO_CAMBI, 3, _
    '        TOTAL_MONTO_SOLES, 3, _
    '        TOTAL_MONTO_DOLA, 3, _
    '        TOTAL_MONTO_BOUCHER_SOLES, 3, _
    '        TOTAL_MONTO_BOUCHER_DOLA, 3, _
    '        Format("DD/MM/YYYY", FECHA_APER), 2, _
    '        FECHA_CIERRE, 2, _
    '        IMPRESO, 1, _
    '        CERRADO, 1, _
    '        IP, 2, _
    '        IPMOD, 2, _
    '        IDUSUARIO_PERSONAL, 1, _
    '        IDUSUARIO_PERSONALMOD, 1, _
    '        FECHA_REGISTRO, 2, _
    '        FECHA_ACTUALIZACION, 2, _
    '        IDROL_USUARIO, 1, _
    '        IDROL_USUARIOMOD, 1, _
    '        IDAGENCIAS, 1, _
    '        IDUNIDAD_AGENCIA, 1, _
    '        IDESTADO_REGISTRO, 1 _
    '        }
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView
    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If dv.Table.Rows(0)(0) = -666 Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    Return dv
    'End Function

    Public Function SP_INSUPD_LIQUI_TURNOS_() As DataView
        'datahelper
        Dim dv As DataView
        Try
            Dim m As Integer
            Dim a As Integer = 0
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_INSUPD_LIQUI_TURNOS_", CommandType.StoredProcedure)
            db.AsignarParametro("P_OPERACION", OPERACION, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_NRO_FACTU", NRO_FACTU, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_TOTAL_MONTO_FACTU", TOTAL_MONTO_FACTU, OracleClient.OracleType.Number)
            db.AsignarParametro("P_NRO_BOLE", NRO_BOLE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_TOTAL_MONTO_BOLE", TOTAL_MONTO_BOLE, OracleClient.OracleType.Number)
            db.AsignarParametro("P_NRO_ANULA", NRO_ANULA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_TOTAL_MONTO_ANULA", TOTAL_MONTO_ANULA, OracleClient.OracleType.Number)
            db.AsignarParametro("P_NRO_PAGO_ENTRE", NRO_PAGO_ENTRE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_TOTAL_MONTO_PAGO_ENTRE", TOTAL_MONTO_PAGO_ENTRE, OracleClient.OracleType.Number)
            db.AsignarParametro("P_NRO_DEVO", NRO_DEVO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_TOTAL_MONTO_DEVO", TOTAL_MONTO_DEVO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_NRO_TARJE_CREDI", NRO_TARJE_CREDI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_TOTAL_MONTO_TARJE_CREDI", TOTAL_MONTO_TARJE_CREDI, OracleClient.OracleType.Number)
            db.AsignarParametro("P_NRO_SOBRES", NRO_SOBRES, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_TOTAL_MONTO_SOBRES", TOTAL_MONTO_SOBRES, OracleClient.OracleType.Number)
            db.AsignarParametro("P_TOTAL_PESO", TOTAL_PESO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_TOTAL_VOLU", TOTAL_VOLU, OracleClient.OracleType.Number)
            db.AsignarParametro("P_TOTAL_SOBRES", TOTAL_SOBRES, OracleClient.OracleType.Number)
            db.AsignarParametro("P_TIPO_CAMBI", TIPO_CAMBI, OracleClient.OracleType.Number)
            db.AsignarParametro("P_TOTAL_MONTO_SOLES", TOTAL_MONTO_SOLES, OracleClient.OracleType.Number)
            db.AsignarParametro("P_TOTAL_MONTO_DOLA", TOTAL_MONTO_DOLA, OracleClient.OracleType.Number)
            db.AsignarParametro("P_TOTAL_MONTO_BOUCHER_SOLES", TOTAL_MONTO_BOUCHER_SOLES, OracleClient.OracleType.Number)
            db.AsignarParametro("P_TOTAL_MONTO_BOUCHER_DOLA", TOTAL_MONTO_BOUCHER_DOLA, OracleClient.OracleType.Number)
            db.AsignarParametro("P_FECHA_APER", Format("DD/MM/YYYY", FECHA_APER), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_CIERRE", FECHA_CIERRE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IMPRESO", IMPRESO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_CERRADO", CERRADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IPMOD", IPMOD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONALMOD", IDUSUARIO_PERSONALMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_REGISTRO", FECHA_REGISTRO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_ACTUALIZACION", FECHA_ACTUALIZACION, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDROL_USUARIO", IDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIOMOD", IDROL_USUARIOMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUNIDAD_AGENCIA", IDUNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDESTADO_REGISTRO", IDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_INSUPD_LIQUI_TURNOS", OracleClient.OracleType.Cursor)
            db.Desconectar()

            Dim dt As DataTable = db.EjecutarDataTable
            dv = dt.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If dv.Table.Rows(0)(0) = -666 Then
                        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
                    End If
                End If
            End If

        Catch ex As Excepcion
            'MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
            Throw New Exception(ex.Excepcion)
        End Try
        Return dv
    End Function
    'Public Function SP_L_LIQUI_OFI_TURNOS_PEND2009(ByVal VOCONTROLUSUARIO As Object, ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim DT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim m As Integer

    '    Dim a As Integer = 0

    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_L_LIQUI_OFI_TURNOS_PEND", 8, _
    '        IDAGENCIAS, 1, _
    '        FECHA_INICIAL, 2, _
    '        FECHA_FINAL, 2 _
    '        }

    '        DA.Fill(DT, VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT))
    '        dv = DT.DefaultView

    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If IsNumeric(dv.Table.Rows(0)(0)) Then
    '                    If (dv.Table.Rows(0)(0)) = -666 Then
    '                        m = 1 / a
    '                    End If
    '                End If
    '            End If
    '        End If

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    Return dv




    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    'Dim cmd As New System.Data.OracleClient.OracleCommand
    '    'cmd.Connection = cnn
    '    'cmd.CommandType = CommandType.StoredProcedure
    '    'cmd.CommandText = "PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_LIQUI_TURNO_PEND"
    '    'cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '    'cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    'cmd.Parameters.Add(New OracleClient.OracleParameter("p_FECHA_INICIAL", OracleClient.OracleType.VarChar)).Value = FECHA_INICIAL
    '    'cmd.Parameters.Add(New OracleClient.OracleParameter("p_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '    'cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LISTAR_LIQUI_TURNO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '    'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '    'Dim ds As New DataSet
    '    'daora.Fill(ds)


    '    'Dim dv As New DataView


    '    'Try

    '    '    dv = ds.Tables(0).DefaultView


    '    '    Return dv

    '    'Catch ex As System.Exception
    '    '    MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    '    'Catch OEx As System.Data.OracleClient.OracleException
    '    '    MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    'End Try

    'End Function

    Public Function SP_L_LIQUI_OFI_TURNOS_PEND() As DataView
        Try
            Dim m As Integer
            Dim a As Integer = 0
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_L_LIQUI_OFI_TURNOS_PEND", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INICIAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_L_LIQUI_OFI_TURNOS_PEND", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Dim dv As DataView
            dv = dt.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If IsNumeric(dv.Table.Rows(0)(0)) Then
                        If (dv.Table.Rows(0)(0)) = -666 Then
                            m = 1 / a
                        End If
                    End If
                End If
            End If
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_LISTAR_LIQUI_TURNO_PEND2009(ByVal VOCONTROLUSUARIO As Object, ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim DT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim m As Integer

    '    Dim a As Integer = 0

    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_LIQUI_TURNO_PEND", 10, _
    '        IDUSUARIO_PERSONAL, 1, _
    '        IDAGENCIAS, 1, _
    '        FECHA_INICIAL, 2, _
    '        FECHA_FINAL, 2 _
    '        }

    '        DA.Fill(DT, VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT))
    '        dv = DT.DefaultView

    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If IsNumeric(dv.Table.Rows(0)(0)) Then
    '                    If (dv.Table.Rows(0)(0)) = -666 Then
    '                        m = 1 / a
    '                    End If
    '                End If
    '            End If
    '        End If

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    Return dv
    'End Function

    Public Function SP_LISTAR_LIQUI_TURNO_PEND() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_LIQUI_TURNO_PEND", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INICIAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR_LISTAR_LIQUI_TURNO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Dim m As Integer
            Dim a As Integer = 0

            Dim dv As DataView = dt.DefaultView
            If Not dv.Count = 0 Then
                If Not dv.Table.Rows(0).IsNull(0) Then
                    If IsNumeric(dv.Table.Rows(0)(0)) Then
                        If (dv.Table.Rows(0)(0)) = -666 Then
                            m = 1 / a
                        End If
                    End If
                End If
            End If
            Return dv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function SP_LISTAR_LIQUI_TURNO_2009(ByVal VOCONTROLUSUARIO As Object) As DataView
    '    Dim DT As New DataTable
    '    Dim Rst As New ADODB.Recordset
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim m As Integer
    '    Dim a As Integer = 0
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_LIQUI_TURNO", 6, _
    '        IDUSUARIO_PERSONAL, 1, _
    '        IDAGENCIAS, 1 _
    '        }
    '        Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        DA.Fill(DT, Rst)
    '        dv = DT.DefaultView

    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If dv.Table.Rows(0)(0) = -666 Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    Return dv
    'End Function
    Public Function SP_LISTAR_LIQUI_TURNO() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_LIQUI_TURNO", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PEROSNAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_LISTAR_LIQUI_TURNO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

    End Function

    'Public Function SP_LIQUI_TURNO_2009(ByVal VOCONTROLUSUARIO As Object, ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView

    '    Dim DT As New DataTable
    '    Dim dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim m As Integer

    '    Dim a As Integer = 0
    '    ' Modifica 05/06/2008 -> IDLIQUI_TURNOS, 1, _
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCIERRE_LIQUIDACIONES.SP_LIQUI_TURNO", 28, _
    '        CType(IDLIQUI_TURNOS, String), 2, _
    '        IDUSUARIO_PERSONAL, 1, _
    '        IDAGENCIAS, 1, _
    '        FECHA_INICIAL, 2, _
    '        FECHA_FINAL, 2, _
    '        IPMOD, 2, _
    '        IDUSUARIO_PERSONALMOD, 1, _
    '        obser, 2, _
    '        CERRADO, 1, _
    '        IDROL_USUARIOMOD, 1, _
    '        Entre_Soles, 3, _
    '        Entre_Dola, 3, _
    '        Entre_Tipo_Cambi, 3 _
    '        }

    '        DA.Fill(DT, VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT))
    '        dv = DT.DefaultView

    '        If Not dv.Count = 0 Then
    '            If Not dv.Table.Rows(0).IsNull(0) Then
    '                If IsNumeric(dv.Table.Rows(0)(0)) Then
    '                    If (dv.Table.Rows(0)(0)) = -666 Then
    '                        m = 1 / a
    '                    End If
    '                End If
    '            End If
    '        End If

    '    Catch ex As System.Exception
    '        MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    '    Return dv




    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    'Dim cmd As New System.Data.OracleClient.OracleCommand
    'cmd.Connection = cnn
    'cmd.CommandType = CommandType.StoredProcedure
    'cmd.CommandText = "PKG_IVOCIERRE_LIQUIDACIONES.SP_LISTAR_LIQUI_TURNO_PEND"
    'cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    'cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    'cmd.Parameters.Add(New OracleClient.OracleParameter("p_FECHA_INICIAL", OracleClient.OracleType.VarChar)).Value = FECHA_INICIAL
    'cmd.Parameters.Add(New OracleClient.OracleParameter("p_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    'cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LISTAR_LIQUI_TURNO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    'Dim ds As New DataSet
    'daora.Fill(ds)


    'Dim dv As New DataView


    'Try

    '    dv = ds.Tables(0).DefaultView


    '    Return dv

    'Catch ex As System.Exception
    '    MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")

    'Catch OEx As System.Data.OracleClient.OracleException
    '    MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
    'End Try
    'End Function
    Public Function SP_LIQUI_TURNO() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LIQUI_TURNO", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDLIQUI_TURNOS", CType(IDLIQUI_TURNOS, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INICIAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IPMOD", IPMOD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONALMOD", IDUSUARIO_PERSONALMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_OBsER", obser, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_CERRADO", CERRADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIOMOD", IDROL_USUARIOMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_ENTRE_SOLES", Entre_Soles, OracleClient.OracleType.Number)
            db.AsignarParametro("p_ENTRE_DOLA", Entre_Dola, OracleClient.OracleType.Number)
            db.AsignarParametro("p_ENTRE_TIPO_CAMBI", Entre_Tipo_Cambi, OracleClient.OracleType.Number)
            db.AsignarParametro("CUR_LIQUI_TURNO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If

            Return dt.DefaultView

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Agregado x Liquidacion Oficina
    Public total_Monto_Factura As Double, total_Monto_Boleta As Double, Total_Monto_PCE As Double, Total_Venta_Carga_Credito As Double
    Public total_Visa_Carga As Double, total_MaterCard_Carga As Double, total_Devolucion_Carga As Double
    Public total_Visa_Otros As Double, total_MaterCard_Otros As Double, total_monto_otros As Double
    Public total_nota_credito_boleta As Double
    Public total_nota_credito_factura As Double
    Public movimiento_ingreso As Double, movimiento_egreso As Double

    Public Function SP_LIQUI_TURNO_1() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LIQUI_TURNO_I", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.SP_LIQUI_TURNO_II", CommandType.StoredProcedure)
            'db.CrearComando("PKG_IVOCIERRE_LIQUIDACIONES.sp_cerrar_liquidacion", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDLIQUI_TURNOS", CType(IDLIQUI_TURNOS, String), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INICIAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IPMOD", IPMOD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONALMOD", IDUSUARIO_PERSONALMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_OBsER", obser, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_CERRADO", CERRADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIOMOD", IDROL_USUARIOMOD, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_ENTRE_SOLES", Entre_Soles, OracleClient.OracleType.Number)
            db.AsignarParametro("p_ENTRE_DOLA", Entre_Dola, OracleClient.OracleType.Number)
            db.AsignarParametro("p_ENTRE_TIPO_CAMBI", Entre_Tipo_Cambi, OracleClient.OracleType.Number)
            '----
            db.AsignarParametro("p_total_Monto_Factura", total_Monto_Factura, OracleClient.OracleType.Double)
            db.AsignarParametro("p_total_Monto_Boleta", total_Monto_Boleta, OracleClient.OracleType.Double)
            db.AsignarParametro("p_Total_Monto_PCE", Total_Monto_PCE, OracleClient.OracleType.Double)
            db.AsignarParametro("p_total_Visa_Carga", total_Visa_Carga, OracleClient.OracleType.Double)
            db.AsignarParametro("p_total_masterCard_Carga", total_MaterCard_Carga, OracleClient.OracleType.Double)
            db.AsignarParametro("p_total_Devolucion_Carga", total_Devolucion_Carga, OracleClient.OracleType.Double)

            db.AsignarParametro("p_total_Tarjeta_Otros", total_Visa_Otros + total_MaterCard_Otros, OracleClient.OracleType.Double)
            db.AsignarParametro("p_total_monto_otros", total_monto_otros, OracleClient.OracleType.Double)

            'hlamas 28/10/2017
            db.AsignarParametro("p_total_nota_credito_boleta", total_nota_credito_boleta, OracleClient.OracleType.Double)
            db.AsignarParametro("p_total_nota_credito_factura", total_nota_credito_factura, OracleClient.OracleType.Double)

            'hlamas 16/05/2017
            db.AsignarParametro("p_movimiento_ingreso", movimiento_ingreso, OracleClient.OracleType.Double)
            db.AsignarParametro("p_movimiento_egreso", movimiento_egreso, OracleClient.OracleType.Double)

            db.AsignarParametro("CUR_LIQUI_TURNO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If

            Return dt.DefaultView

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
