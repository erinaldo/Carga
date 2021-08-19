Imports AccesoDatos
Public Class dtoCargaAsegurada
    Private Mymonto_minimo_PCE As Double
    Private MyFECHA_REGISTRO As String
    Private MyPORCEN_IMPUESTO As Long
    Private MyIDUSUARIO_PERSONAL As Long
    Private MyIDROL_USUARIO As Long
    Private MyIDTIPO_COMPROBANTE As Long
    Private MyFECHA As String
    Private MyIPMOD As String
    Private MyMONTO_TIPO_CAMBIO As Double
    Private MyMONTO_SUB_TOTAL As Double
    Private MyMONTO_IMPUESTO As Double
    Private MyTOTAL_COSTO As Double
    Private MyPORCEN As Double
    Private MyID_GUIAS_ENVIO_DOC As Long
    Private MyNRO_SERIE As String
    Private MyOBS As String
    Private MyIDUSUARIO_PERSONALMOD As Long
    Private MyIP As String
    Private MyIDESTADO_REGISTRO As Long
    Private MyMONTO_BASE As Double
    Private MyNRO_DOCU As String
    Private MyIDGUIAS_ENVIO As Long
    Private MyIDROL_USUARIOMOD As Long
    Private MyFECHA_ACTUALIZACION As String
    Private MyTIPO As Integer

    Structure ComprobanteAsegurada
        Private MyPORCEN_IMPUESTO As Long
        Private MyFECHA_REGISTRO As String
        Private MyIDUSUARIO_PERSONAL As Long
        Private MyIDROL_USUARIO As Long
        Private MyIDTIPO_COMPROBANTE As Long
        Private MyFECHA As String
        Private MyIPMOD As String
        Private MyPORCEN As Double
        Private MyMONTO_TIPO_CAMBIO As Double
        Private MyMONTO_IMPUESTO As Double
        Private MyTOTAL_COSTO As Double
        Private MyMONTO_SUB_TOTAL
        Private MyID_GUIAS_ENVIO_DOC As Long
        Private MyNRO_SERIE As String
        Private MyOBS As String
        Private MyIDUSUARIO_PERSONALMOD As Long
        Private MyIP As String
        Private MyIDESTADO_REGISTRO As Long
        Private MyMONTO_BASE As Double
        Private MyNRO_DOCU As String
        Private MyIDGUIAS_ENVIO As Long
        Private MyIDROL_USUARIOMOD As Long
        Private MyFECHA_ACTUALIZACION As String
        Private MyIDTIPO_MONEDA As Long
        Private Mymonto_minimo_PCE As Double
        Private MyTIPO As Integer
        Private MyPROCEDENCIA As Integer
        Public Property monto_minimo_PCE() As Double
            Get
                monto_minimo_PCE = Mymonto_minimo_PCE
            End Get
            Set(ByVal value As Double)
                Mymonto_minimo_PCE = value
            End Set
        End Property
        Public Property IDTIPO_MONEDA() As Long

            Get
                IDTIPO_MONEDA = MyIDTIPO_MONEDA
            End Get
            Set(ByVal value As Long)
                MyIDTIPO_MONEDA = value
            End Set
        End Property

        Public Property TIPO() As Integer
            Get
                TIPO = MyTIPO
            End Get
            Set(ByVal value As Integer)
                MyTIPO = value
            End Set
        End Property
        Public Property PROCEDENCIA() As Integer
            Get
                PROCEDENCIA = MyPROCEDENCIA
            End Get
            Set(ByVal value As Integer)
                MyPROCEDENCIA = value
            End Set
        End Property

        Public Property MONTO_TIPO_CAMBIO() As Double

            Get
                MONTO_TIPO_CAMBIO = MyMONTO_TIPO_CAMBIO
            End Get
            Set(ByVal value As Double)
                MyMONTO_TIPO_CAMBIO = value
            End Set
        End Property
        Public Property TOTAL_COSTO() As Double

            Get
                TOTAL_COSTO = MyTOTAL_COSTO
            End Get
            Set(ByVal value As Double)
                MyTOTAL_COSTO = value
            End Set
        End Property
        Public Property PORCEN_IMPUESTO() As Double

            Get
                PORCEN_IMPUESTO = MyPORCEN_IMPUESTO
            End Get
            Set(ByVal value As Double)
                MyPORCEN_IMPUESTO = value
            End Set
        End Property
        Public Property MONTO_SUB_TOTAL() As Double

            Get
                MONTO_SUB_TOTAL = MyMONTO_SUB_TOTAL
            End Get
            Set(ByVal value As Double)
                MyMONTO_SUB_TOTAL = value
            End Set
        End Property
        Public Property OBS() As String
            Get
                OBS = MyOBS
            End Get
            Set(ByVal value As String)
                MyOBS = value
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
        Public Property IDESTADO_REGISTRO() As Long

            Get
                IDESTADO_REGISTRO = MyIDESTADO_REGISTRO
            End Get
            Set(ByVal value As Long)
                MyIDESTADO_REGISTRO = value
            End Set
        End Property
        Public Property MONTO_BASE() As Double
            Get
                MONTO_BASE = MyMONTO_BASE
            End Get
            Set(ByVal value As Double)
                MyMONTO_BASE = value
            End Set
        End Property
        Public Property ID_GUIAS_ENVIO_DOC() As Long

            Get
                ID_GUIAS_ENVIO_DOC = MyID_GUIAS_ENVIO_DOC
            End Get
            Set(ByVal value As Long)
                MyID_GUIAS_ENVIO_DOC = value
            End Set
        End Property
        Public Property NRO_SERIE() As String

            Get
                NRO_SERIE = MyNRO_SERIE
            End Get
            Set(ByVal value As String)
                MyNRO_SERIE = value
            End Set
        End Property
        Public Property NRO_DOCU() As String

            Get
                NRO_DOCU = MyNRO_DOCU
            End Get
            Set(ByVal value As String)
                MyNRO_DOCU = value
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
        Public Property FECHA() As String

            Get
                FECHA = MyFECHA
            End Get
            Set(ByVal value As String)
                MyFECHA = value
            End Set
        End Property
        Public Property MONTO_IMPUESTO() As Double

            Get
                MONTO_IMPUESTO = MyMONTO_IMPUESTO
            End Get
            Set(ByVal value As Double)
                MyMONTO_IMPUESTO = value
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
        Public Property IDGUIAS_ENVIO() As Long

            Get
                IDGUIAS_ENVIO = MyIDGUIAS_ENVIO
            End Get
            Set(ByVal value As Long)
                MyIDGUIAS_ENVIO = value
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
        Public Property IP() As String

            Get
                IP = MyIP
            End Get
            Set(ByVal value As String)
                MyIP = value
            End Set
        End Property
        Public Property PORCEN() As Double

            Get
                PORCEN = MyPORCEN
            End Get
            Set(ByVal value As Double)
                MyPORCEN = value
            End Set
        End Property
    End Structure
    Public Property MONTO_TIPO_CAMBIO() As Double

        Get
            MONTO_TIPO_CAMBIO = MyMONTO_TIPO_CAMBIO
        End Get
        Set(ByVal value As Double)
            MyMONTO_TIPO_CAMBIO = value
        End Set
    End Property
    Public Property TOTAL_COSTO() As Double

        Get
            TOTAL_COSTO = MyTOTAL_COSTO
        End Get
        Set(ByVal value As Double)
            MyTOTAL_COSTO = value
        End Set
    End Property
    Public Property MONTO_SUB_TOTAL() As Double

        Get
            MONTO_SUB_TOTAL = MyMONTO_SUB_TOTAL
        End Get
        Set(ByVal value As Double)
            MyMONTO_SUB_TOTAL = value
        End Set
    End Property
    Public Property OBS() As String

        Get
            OBS = MyOBS
        End Get
        Set(ByVal value As String)
            MyOBS = value
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
    Public Property IDESTADO_REGISTRO() As Long

        Get
            IDESTADO_REGISTRO = MyIDESTADO_REGISTRO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_REGISTRO = value
        End Set
    End Property
    Public Property MONTO_BASE() As Double

        Get
            MONTO_BASE = MyMONTO_BASE
        End Get
        Set(ByVal value As Double)
            MyMONTO_BASE = value
        End Set
    End Property
    Public Property ID_GUIAS_ENVIO_DOC() As Long

        Get
            ID_GUIAS_ENVIO_DOC = MyID_GUIAS_ENVIO_DOC
        End Get
        Set(ByVal value As Long)
            MyID_GUIAS_ENVIO_DOC = value
        End Set
    End Property
    Public Property NRO_SERIE() As String

        Get
            NRO_SERIE = MyNRO_SERIE
        End Get
        Set(ByVal value As String)
            MyNRO_SERIE = value
        End Set
    End Property
    Public Property NRO_DOCU() As String

        Get
            NRO_DOCU = MyNRO_DOCU
        End Get
        Set(ByVal value As String)
            MyNRO_DOCU = value
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
    Public Property FECHA() As String

        Get
            FECHA = MyFECHA
        End Get
        Set(ByVal value As String)
            MyFECHA = value
        End Set
    End Property
    Public Property MONTO_IMPUESTO() As Double

        Get
            MONTO_IMPUESTO = MyMONTO_IMPUESTO
        End Get
        Set(ByVal value As Double)
            MyMONTO_IMPUESTO = value
        End Set
    End Property
    Public Property PORCEN() As Double

        Get
            PORCEN = MyPORCEN
        End Get
        Set(ByVal value As Double)
            MyPORCEN = value
        End Set
    End Property

    Public Property TIPO() As Integer
        Get
            Return MyTIPO
        End Get
        Set(ByVal value As Integer)
            MyTIPO = value
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
    Public Property IDGUIAS_ENVIO() As Long

        Get
            IDGUIAS_ENVIO = MyIDGUIAS_ENVIO
        End Get
        Set(ByVal value As Long)
            MyIDGUIAS_ENVIO = value
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
    Public Property IP() As String

        Get
            IP = MyIP
        End Get
        Set(ByVal value As String)
            MyIP = value
        End Set
    End Property
    Public Property monto_minimo_PCE() As Double

        Get
            monto_minimo_PCE = Mymonto_minimo_PCE
        End Get
        Set(ByVal value As Double)
            Mymonto_minimo_PCE = value
        End Set
    End Property
    Public Property PORCEN_IMPUESTO() As Double

        Get
            PORCEN_IMPUESTO = MyPORCEN_IMPUESTO
        End Get
        Set(ByVal value As Double)
            MyPORCEN_IMPUESTO = value
        End Set
    End Property
    'Public Sub SP_RECUPERA_MONTO_PORCE_2009(ByVal monto As Double, ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        'hlamas
    '        'cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_MONTO_PORCE"
    '        cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_MONTO_PORCE"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("monto", OracleClient.OracleType.Number)).Value = monto
    '        'cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("tipo", OracleClient.OracleType.Int32)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_porcen_carga_ase", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output

    '        cmd.ExecuteNonQuery()

    '        If Not cmd.Parameters("oP_porcen_carga_ase").Value Is DBNull.Value Then
    '            PORCEN = cmd.Parameters("oP_porcen_carga_ase").Value
    '            TIPO = cmd.Parameters("tipo").Value
    '        End If

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    '    'Try
    '    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    '    cmd.Connection = cnn
    '    '    cmd.CommandType = CommandType.StoredProcedure
    '    '    cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_MONTO_PORCE"
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("oP_porcen_carga_ase", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output

    '    '    cmd.ExecuteNonQuery()


    '    '    If Not cmd.Parameters("oP_porcen_carga_ase").Value Is DBNull.Value Then
    '    '        PORCEN = cmd.Parameters("oP_porcen_carga_ase").Value
    '    '    End If

    '    'Catch OEx As System.Data.OracleClient.OracleException
    '    '    MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    'End Try
    'End Sub
    Public Sub SP_RECUPERA_MONTO_PORCE(ByVal monto As Double)
        Dim db_bd As New BaseDatos
        Dim lobj_tmp As New Object
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_MONTO_PORCE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("MONTO", monto, OracleClient.OracleType.Double)
            'Variables de salidas 
            db_bd.AsignarParametro("TIPO", OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("oP_porcen_carga_ase", OracleClient.OracleType.Double)
            '
            db_bd.EjecutarComando()
            '
            If db_bd.Parametros.Length > 0 Then
                TIPO = IIf(db_bd.Parametros(1) Is DBNull.Value, 0, db_bd.Parametros(1))
                PORCEN = IIf(db_bd.Parametros(2) Is DBNull.Value, 0, db_bd.Parametros(2))
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub
    'Public Sub SP_RECUPERA_PORCEN_IMPU_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_PORCEN_IMPU"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_Porcen_Impuesto", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        '
    '        cmd.ExecuteNonQuery()
    '        '
    '        If Not cmd.Parameters("oP_Porcen_Impuesto").Value Is DBNull.Value Then
    '            PORCEN_IMPUESTO = cmd.Parameters("oP_Porcen_Impuesto").Value
    '        End If

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try

    'End Sub
    Public Sub SP_RECUPERA_PORCEN_IMPU()
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_PORCEN_IMPU", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            '
            'Variables de salidas 
            db_bd.AsignarParametro("oP_Porcen_Impuesto", OracleClient.OracleType.Double)
            '
            db_bd.EjecutarComando()

            If db_bd.Parametros.Length > 0 Then
                PORCEN_IMPUESTO = IIf(db_bd.Parametros(1) Is DBNull.Value, 0, db_bd.Parametros(1))
            End If
            'PORCEN_IMPUESTO = db_bd.EjecutarEscalar()
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub
    'Public Sub SP_RECUPERA_MONTO_MINIMO_PCE_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_MONTO_MINI_PCE"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("oP_Monto_Minimo_Pce", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output

    '        cmd.ExecuteNonQuery()

    '        If Not cmd.Parameters("oP_Monto_Minimo_Pce").Value Is DBNull.Value Then
    '            Me.monto_minimo_PCE = cmd.Parameters("oP_Monto_Minimo_Pce").Value
    '        End If

    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    Public Sub SP_RECUPERA_MONTO_MINIMO_PCE()
        Dim db_bd As New BaseDatos
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_MONTO_MINI_PCE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            '
            'Variables de salidas 
            db_bd.AsignarParametro("oP_Monto_Minimo_Pce", OracleClient.OracleType.Double)
            '
            db_bd.EjecutarComando()
            '
            If db_bd.Parametros.Length > 0 Then
                Me.monto_minimo_PCE = IIf(db_bd.Parametros(1) Is DBNull.Value, 0, db_bd.Parametros(1))
            End If
            'Me.monto_minimo_PCE = db_bd.EjecutarEscalar()
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub
    'Public Sub SP_RECUPERA_MONTO_PORCE_CLI_2009(ByVal documento As String, ByVal monto As Double, ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        'hlamas
    '        'cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_MONTO_PORCE"
    '        cmd.CommandText = "PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_MONTO_PORCE_CLI"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("documento", OracleClient.OracleType.VarChar)).Value = documento
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("monto", OracleClient.OracleType.Number)).Value = monto
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("tipo", OracleClient.OracleType.Int32)).Direction = ParameterDirection.Output
    '        'cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("porcentaje", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output

    '        cmd.ExecuteNonQuery()

    '        If Not cmd.Parameters("porcentaje").Value Is DBNull.Value Then
    '            PORCEN = cmd.Parameters("porcentaje").Value
    '            TIPO = cmd.Parameters("tipo").Value
    '        End If

    '    Catch OEx As Exception
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    Public Sub SP_RECUPERA_MONTO_PORCE_CLI(ByVal documento As String, ByVal monto As Double)
        Dim db_bd As New BaseDatos
        Dim lobj_tmp As New Object
        Try
            'conecta con la Bd
            db_bd.Conectar()
            'hlamas
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_MONTO_PORCE_CLI", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("DOCUMENTO", documento, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("MONTO", monto, OracleClient.OracleType.Double)
            'Variables de salidas 
            db_bd.AsignarParametro("TIPO", OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("PORCENTAJE", OracleClient.OracleType.Double)
            '
            db_bd.EjecutarComando()
            '
            If db_bd.Parametros.Length > 0 Then
                TIPO = IIf(db_bd.Parametros(1) Is DBNull.Value, 0, db_bd.Parametros(1))
                PORCEN = IIf(db_bd.Parametros(2) Is DBNull.Value, 0, db_bd.Parametros(2))
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub
End Class
