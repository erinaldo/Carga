Imports AccesoDatos
Public Class dtoComisiones
    Dim MyFECHA As String
    Dim MyTIPO_COMPROBANTE As String
    Dim MyIDUSUARIO_FUNCI_STRING As String
    Dim MyIDAGENCIAS_STRING As String
    Dim MyIDESTADO_REGISTRO As Long
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDUSUARIO_PERSONAL_FUNCI As Long
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIDROL_USUARIO As Long
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyFECHA_REGISTRO As String
    Dim MyIP As String
    Dim MyIPMOD As String
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyIDCOMI_CALCU As Long
    Dim MyFECHA_INI As String
    Dim MyFECHA_FINAL As String
    Dim MyIDTIPO_COMPROBANTE As Long
    Dim MyIDAGENCIAS As Long
    Dim MyPORCEN As Double
    Dim MyMONTO_X_COMPROBANTE As Double
    Dim MyCANTI_SERVI As Double
    Dim MyOCUPABILIDAD As Double
    Dim MyOTROS As Double
    Dim MyIDCOMI_CALCU_FUNCI As Long
    Dim MyIDFUNCIONARIO As Long
    Dim MyIDCOMI_CALCU_DETALL_FUNCI As Long
    Dim MySUB_TOTAL_PAGAR_COMI As Double
    Dim MyNRO As Long
    Dim MyAFEC_COMI As String
    Dim MyTOTAL_COSTO As Double
    Dim MySUB_TOTAL As Double
    Dim MyTOTAL_POR_COMPRO As Double
    Dim MyMONTO_PORCEN As Double
    Dim Mypara_monto_comi_ocu As Double
    Dim Mymonto_ocupa_calcu As Double
    Dim MyParaMontoCarga As Double
    Dim MyMontoCargaCalcu As Double
    Dim MyPorcenCarga As Double
    Dim Mymonto_meta As Double

    '
    Dim MyPorcentajeVenta As Double
    Dim MyPorcentajeVentaLima As Double
    Dim MyPorcentajeVentaProvincia As Double
    Dim MyTASA As Double
    Dim MyTASA2 As Double
    Dim MyTASA_LIMA As Double
    Dim MyTASA_PROVINCIA As Double
    Dim MyOrigen As Integer
    Dim MyMetaLima As Double
    Dim MyMetaProvincia As Double

    Dim MyConcepto As String
    Dim MyNombreOrigen As String
    Dim MyTipo As String
    Dim MyTotalTipo As Double

    Dim MyIdGrupo As Integer
    Dim MyGrupo As String
    Dim MyTipoCobranza As String
    Dim MyPorcentajeComision As Double
    Dim MyTotalCobranza As Double
    Dim MyTotalComision As Double
    Dim MyExisteRegistro As Integer

    Public Property PorcenCarga() As Double
        Get
            PorcenCarga = MyPorcenCarga
        End Get
        Set(ByVal value As Double)
            MyPorcenCarga = value
        End Set
    End Property
    Public Property MontoCargaCalcu() As Double

        Get
            MontoCargaCalcu = MyMontoCargaCalcu
        End Get
        Set(ByVal value As Double)
            MyMontoCargaCalcu = value
        End Set
    End Property
    Public Property ParaMontoCarga() As Double

        Get
            ParaMontoCarga = MyParaMontoCarga
        End Get
        Set(ByVal value As Double)
            MyParaMontoCarga = value
        End Set
    End Property

    Public Property monto_ocupa_calcu() As Double

        Get
            monto_ocupa_calcu = Mymonto_ocupa_calcu
        End Get
        Set(ByVal value As Double)
            Mymonto_ocupa_calcu = value
        End Set
    End Property

    Public Property monto_meta() As Double

        Get
            monto_meta = Mymonto_meta
        End Get
        Set(ByVal value As Double)
            Mymonto_meta = value
        End Set
    End Property

    Public Property para_monto_comi_ocu() As Double

        Get
            para_monto_comi_ocu = Mypara_monto_comi_ocu
        End Get
        Set(ByVal value As Double)
            Mypara_monto_comi_ocu = value
        End Set
    End Property

    Public Property IDCOMI_CALCU_DETALL_FUNCI() As Long

        Get
            IDCOMI_CALCU_DETALL_FUNCI = MyIDCOMI_CALCU_DETALL_FUNCI
        End Get
        Set(ByVal value As Long)
            MyIDCOMI_CALCU_DETALL_FUNCI = value
        End Set
    End Property

    Public Property SUB_TOTAL_PAGAR_COMI() As Double

        Get
            SUB_TOTAL_PAGAR_COMI = MySUB_TOTAL_PAGAR_COMI
        End Get
        Set(ByVal value As Double)
            MySUB_TOTAL_PAGAR_COMI = value
        End Set
    End Property
    Public Property OTROS() As Double

        Get
            OTROS = MyOTROS
        End Get
        Set(ByVal value As Double)
            MyOTROS = value
        End Set
    End Property
    Public Property NRO() As Long

        Get
            NRO = MyNRO
        End Get
        Set(ByVal value As Long)
            MyNRO = value
        End Set
    End Property
    Public Property TIPO_COMPROBANTE() As String
        Get
            TIPO_COMPROBANTE = MyTIPO_COMPROBANTE
        End Get
        Set(ByVal value As String)
            MyTIPO_COMPROBANTE = value
        End Set
    End Property
    Public Property AFEC_COMI() As String
        Get
            AFEC_COMI = MyAFEC_COMI
        End Get
        Set(ByVal value As String)
            MyAFEC_COMI = value
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
    Public Property SUB_TOTAL() As Double
        Get
            SUB_TOTAL = MySUB_TOTAL
        End Get
        Set(ByVal value As Double)
            MySUB_TOTAL = value
        End Set
    End Property
    Public Property TOTAL_POR_COMPRO() As Double
        Get
            TOTAL_POR_COMPRO = MyTOTAL_POR_COMPRO
        End Get
        Set(ByVal value As Double)
            MyTOTAL_POR_COMPRO = value
        End Set
    End Property
    Public Property MONTO_PORCEN() As Double
        Get
            MONTO_PORCEN = MyMONTO_PORCEN
        End Get
        Set(ByVal value As Double)
            MyMONTO_PORCEN = value
        End Set
    End Property
    Public Property IDCOMI_CALCU_FUNCI() As Long
        Get
            IDCOMI_CALCU_FUNCI = MyIDCOMI_CALCU_FUNCI
        End Get
        Set(ByVal value As Long)
            MyIDCOMI_CALCU_FUNCI = value
        End Set
    End Property
    Public Property IDFUNCIONARIO() As Long
        Get
            IDFUNCIONARIO = MyIDFUNCIONARIO
        End Get
        Set(ByVal value As Long)
            MyIDFUNCIONARIO = value
        End Set
    End Property
    Public Property IDUSUARIO_FUNCI_STRING() As String
        Get
            IDUSUARIO_FUNCI_STRING = MyIDUSUARIO_FUNCI_STRING
        End Get
        Set(ByVal value As String)
            MyIDUSUARIO_FUNCI_STRING = value
        End Set
    End Property
    Public Property IDAGENCIAS_STRING() As String
        Get
            IDAGENCIAS_STRING = MyIDAGENCIAS_STRING
        End Get
        Set(ByVal value As String)
            MyIDAGENCIAS_STRING = value
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
    Public Property IDUSUARIO_PERSONALMOD() As Long
        Get
            IDUSUARIO_PERSONALMOD = MyIDUSUARIO_PERSONALMOD
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONALMOD = value
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
    Public Property FECHA_REGISTRO() As String
        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = value
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
    Public Property FECHA_ACTUALIZACION() As String
        Get
            FECHA_ACTUALIZACION = MyFECHA_ACTUALIZACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ACTUALIZACION = value
        End Set
    End Property
    Public Property IDCOMI_CALCU() As Long
        Get
            IDCOMI_CALCU = MyIDCOMI_CALCU
        End Get
        Set(ByVal value As Long)
            MyIDCOMI_CALCU = value
        End Set
    End Property
    Public Property FECHA_INI() As String
        Get
            FECHA_INI = MyFECHA_INI
        End Get
        Set(ByVal value As String)
            MyFECHA_INI = value
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
    Public Property PORCEN() As Double
        Get
            PORCEN = MyPORCEN
        End Get
        Set(ByVal value As Double)
            MyPORCEN = value
        End Set
    End Property
    Public Property MONTO_X_COMPROBANTE() As Double
        Get
            MONTO_X_COMPROBANTE = MyMONTO_X_COMPROBANTE
        End Get
        Set(ByVal value As Double)
            MyMONTO_X_COMPROBANTE = value
        End Set
    End Property
    Public Property CANTI_SERVI() As Double
        Get
            CANTI_SERVI = MyCANTI_SERVI
        End Get
        Set(ByVal value As Double)
            MyCANTI_SERVI = value
        End Set
    End Property
    Public Property OCUPABILIDAD() As Double
        Get
            OCUPABILIDAD = MyOCUPABILIDAD
        End Get
        Set(ByVal value As Double)
            MyOCUPABILIDAD = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL_FUNCI() As Long
        Get
            IDUSUARIO_PERSONAL_FUNCI = MyIDUSUARIO_PERSONAL_FUNCI
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL_FUNCI = value
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
    Public Property IDAGENCIAS() As Integer
        Get
            IDAGENCIAS = MyIDAGENCIAS
        End Get
        Set(ByVal value As Integer)
            MyIDAGENCIAS = value
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
    Public Property FECHA() As String
        Get
            FECHA = MyFECHA
        End Get
        Set(ByVal value As String)
            MyFECHA = value
        End Set
    End Property
    Public Property TASA() As Double
        Get
            TASA = MyTASA
        End Get
        Set(ByVal value As Double)
            MyTASA = value
        End Set
    End Property

    Public Property TASA2() As Double
        Get
            TASA2 = MyTASA2
        End Get
        Set(ByVal value As Double)
            MyTASA2 = value
        End Set
    End Property

    Public Property TASA_LIMA() As Double
        Get
            TASA_LIMA = MyTASA_LIMA
        End Get
        Set(ByVal value As Double)
            MyTASA_LIMA = value
        End Set
    End Property
    Public Property TASA_PROVINCIA() As Double
        Get
            TASA_PROVINCIA = MyTASA_PROVINCIA
        End Get
        Set(ByVal value As Double)
            MyTASA_PROVINCIA = value
        End Set
    End Property
    Public Property PorcentajeVenta() As Double
        Get
            PorcentajeVenta = MyPorcentajeVenta
        End Get
        Set(ByVal value As Double)
            MyPorcentajeVenta = value
        End Set
    End Property
    Public Property PorcentajeVentaLima() As Double
        Get
            PorcentajeVentaLima = MyPorcentajeVentaLima
        End Get
        Set(ByVal value As Double)
            MyPorcentajeVentaLima = value
        End Set
    End Property
    Public Property PorcentajeVentaProvincia() As Double
        Get
            PorcentajeVentaProvincia = MyPorcentajeVentaProvincia
        End Get
        Set(ByVal value As Double)
            MyPorcentajeVentaProvincia = value
        End Set
    End Property
    Public Property Origen() As Integer
        Get
            Origen = MyOrigen
        End Get
        Set(ByVal value As Integer)
            MyOrigen = value
        End Set
    End Property
    Public Property MetaLima() As Double
        Get
            MetaLima = MyMetaLima
        End Get
        Set(ByVal value As Double)
            MyMetaLima = value
        End Set
    End Property
    Public Property MetaProvincia() As Double
        Get
            MetaProvincia = MyMetaProvincia
        End Get
        Set(ByVal value As Double)
            MyMetaProvincia = value
        End Set
    End Property

    Public Property CONCEPTO() As String
        Get
            CONCEPTO = MyConcepto
        End Get
        Set(ByVal value As String)
            MyConcepto = value
        End Set
    End Property
    Public Property NOMBRE_ORIGEN() As String
        Get
            NOMBRE_ORIGEN = MyNombreOrigen
        End Get
        Set(ByVal value As String)
            MyNombreOrigen = value
        End Set
    End Property
    Public Property FORMA_PAGO() As String
        Get
            FORMA_PAGO = MyTipo
        End Get
        Set(ByVal value As String)
            MyTipo = value
        End Set
    End Property
    Public Property TOTAL_FORMA_PAGO() As Double
        Get
            TOTAL_FORMA_PAGO = MyTotalTipo
        End Get
        Set(ByVal value As Double)
            MyTotalTipo = value
        End Set
    End Property
    Public Property IDGRUPO() As Integer
        Get
            IDGRUPO = MyIdGrupo
        End Get
        Set(ByVal value As Integer)
            MyIdGrupo = value
        End Set
    End Property
    Public Property GRUPO() As String
        Get
            GRUPO = MyGrupo
        End Get
        Set(ByVal value As String)
            MyGrupo = value
        End Set
    End Property
    Public Property TIPO_COBRANZA() As String
        Get
            TIPO_COBRANZA = MyTipoCobranza
        End Get
        Set(ByVal value As String)
            MyTipoCobranza = value
        End Set
    End Property
    Public Property PORCENTAJE_COMISION() As Double
        Get
            PORCENTAJE_COMISION = MyPorcentajeComision
        End Get
        Set(ByVal value As Double)
            MyPorcentajeComision = value
        End Set
    End Property
    Public Property TOTAL_COBRANZA() As Double
        Get
            TOTAL_COBRANZA = MyTotalCobranza
        End Get
        Set(ByVal value As Double)
            MyTotalCobranza = value
        End Set
    End Property
    Public Property TOTAL_COMISION() As Double
        Get
            TOTAL_COMISION = MyTotalComision
        End Get
        Set(ByVal value As Double)
            MyTotalComision = value
        End Set
    End Property
    Public Property EXISTE_COMISION() As Integer
        Get
            EXISTE_COMISION = MyExisteRegistro
        End Get
        Set(ByVal value As Integer)
            MyExisteRegistro = value
        End Set
    End Property

    Private intProducto As Integer
    Public Property Producto() As Integer
        Get
            Return intProducto
        End Get
        Set(ByVal value As Integer)
            intProducto = value
        End Set
    End Property
    Private strProducto As String
    Public Property NombreProducto() As String
        Get
            Return strProducto
        End Get
        Set(ByVal value As String)
            strProducto = value
        End Set
    End Property


    'Function SP_L_SERVICIOS_MONTO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataTable
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.SP_L_SERVICIOS_MONTO"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INICIAL", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_SERVICIOS_MONTO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        Dim dt As New DataTable
    '        daora.Fill(dt)
    '        Return dt
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Function SP_L_SERVICIOS_MONTO() As DataTable
        Try
            Dim db As New BaseDatos
            Dim lds_tmp As New DataSet
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_L_SERVICIOS_MONTO", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_SERVICIOS_MONTO", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Function SP_L_SERVICIOS_FUNCI_MONTO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataSet
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.SP_L_SERVICIOS_FUNCI_MONTO"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL_FUNCI", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL_FUNCI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INICIAL", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_SERVICIOS_FUNCI_MONTO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        'Dim dv As New DataView
    '        'dv = ds.Tables(0).DefaultView
    '        'Return dv
    '        Return ds
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Function SP_L_SERVICIOS_FUNCI_MONTO() As DataTable
        Try
            Dim db As New BaseDatos
            Dim lds_tmp As DataTable
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("PKG_IVOCOMISIONES.SP_L_SERVICIOS_FUNCI_MONTO", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOCOMISIONES.SP_L_SERVICIOS_FUNCI_MONTO_CAR", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_IDUSUARIO_PERSONAL_FUNCI", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            If TASA <> 0 Then
                db.AsignarParametro("P_TASA", TASA, OracleClient.OracleType.Double)
            Else
                db.AsignarParametro("P_TASA", 0, OracleClient.OracleType.Double)
            End If
            If TASA2 <> 0 Then
                db.AsignarParametro("P_TASA_2", TASA2, OracleClient.OracleType.Double)
            Else
                db.AsignarParametro("P_TASA_2", 0, OracleClient.OracleType.Double)
            End If

            If MyTASA_LIMA <> 0 Then
                db.AsignarParametro("PORCENTAJE_LIMA", TASA_LIMA, OracleClient.OracleType.Double)
            Else
                db.AsignarParametro("PORCENTAJE_LIMA", 0, OracleClient.OracleType.Double)
            End If

            If MyTASA_PROVINCIA <> 0 Then
                db.AsignarParametro("PORCENTAJE_PROV", TASA_PROVINCIA, OracleClient.OracleType.Double)
            Else
                db.AsignarParametro("PORCENTAJE_PROV", 0, OracleClient.OracleType.Double)
            End If
            db.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_SERVICIOS_FUNCI_MONTO", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            lds_tmp = db.EjecutarDataTable
            Return lds_tmp
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Sub SP_IUPD_COMISIONES_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.SP_IUPD_COMISIONES"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_IDAGENCIAS_STRING", OracleClient.OracleType.VarChar)).Value = IDAGENCIAS_STRING
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIO", OracleClient.OracleType.Number)).Value = IDROL_USUARIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("OP_SITU", OracleClient.OracleType.VarChar, 4)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("OP_IDCOMI_CALCU", OracleClient.OracleType.Number)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_IUPD_COMISIONES", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        cmd.ExecuteNonQuery()
    '        If Not cmd.Parameters("OP_SITU").Value Is DBNull.Value Then
    '            If cmd.Parameters("OP_SITU").Value = "EXRA" Then
    '                MsgBox("Ya existe un cálculo dentro de esta fecha para esta agencia...", MsgBoxStyle.Critical, "Seguridad del Sistema")
    '            End If
    '        End If
    '        If Not cmd.Parameters("OP_IDCOMI_CALCU").Value Is DBNull.Value Then
    '            IDCOMI_CALCU = cmd.Parameters("OP_IDCOMI_CALCU").Value
    '        Else
    '            IDCOMI_CALCU = Nothing
    '        End If
    '        'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        'Dim ds As New DataSet
    '        'daora.Fill(ds)
    '        'Dim dv As New DataView
    '        'dv = ds.Tables(0).DefaultView
    '        'IDCOMI_CALCU = ds.Tables(0).Rows(0)("IDCOMI_CALCU")
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub
    Sub SP_IUPD_COMISIONES()
        '
        Dim db As New BaseDatos
        Dim ldt_tmp As New DataTable
        '
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_IUPD_COMISIONES", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("p_IDAGENCIAS_STRING", IDAGENCIAS_STRING, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIO", IDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("OP_SITU", 4, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db.AsignarParametro("OP_IDCOMI_CALCU", OracleClient.OracleType.Int32, ParameterDirection.Output)
            db.AsignarParametro("CUR_IUPD_COMISIONES", OracleClient.OracleType.Cursor, ParameterDirection.Output)
            '
            db.EjecutarComando()
            If db.Parametros.Length > 0 Then
                If Not (db.Parametros(1) Is DBNull.Value) Then
                    If db.Parametros(1) = "EXRA" Then
                        MsgBox("Ya existe un cálculo dentro de esta fecha para esta agencia...", MsgBoxStyle.Critical, "Seguridad del Sistema")
                    End If
                End If
                If Not (db.Parametros(2) Is DBNull.Value) Then
                    IDCOMI_CALCU = db.Parametros(2)
                Else
                    IDCOMI_CALCU = Nothing
                End If
                '
                ldt_tmp = IIf(db.Parametros(3) Is DBNull.Value, Nothing, db.Parametros(3))
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
    'Function SP_L_COMI_CONCE_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.SP_L_COMI_CONCE"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_COMI_CONCE", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '        Dim ds As New DataSet
    '        daora.Fill(ds)


    '        Dim dv As New DataView

    '        dv = ds.Tables(0).DefaultView

    '        Return dv


    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Function SP_L_COMI_CONCE() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_L_COMI_CONCE", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_COMI_CONCE", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Function SP_L_COMI_CONCE_detall_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.SP_L_COMI_CONCE_detall"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCOMI_CALCU", OracleClient.OracleType.VarChar)).Value = IDCOMI_CALCU
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_COMI_CONCE_DETALL", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Function SP_L_COMI_CONCE_detall() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_L_COMI_CONCE_detall", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_IDCOMI_CALCU", IDCOMI_CALCU, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_COMI_CONCE_DETALL", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Function SP_L_COMI_CONCE_FUNCI_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.SP_L_COMI_CONCE_FUNCI"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_COMI_CONCE_FUNCI", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

    '        Dim ds As New DataSet
    '        daora.Fill(ds)


    '        Dim dv As New DataView

    '        dv = ds.Tables(0).DefaultView

    '        Return dv


    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function


    '-------------------------------------------------------------------------------
    'Consulta las comisiones de los funcionarios de carga y pasaje
    '-------------------------------------------------------------------------------
    Function SP_L_COMI_CONCE_FUNCI() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_L_COMI_CONCE_FUNCI", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_COMI_CONCE_FUNCI", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function SP_COMISION_FUNCI_PASAJE() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_COMISION_FUNCI_PASAJE", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_COMI_CONCE_FUNCI", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    '-------------------------------------------------------------------------------
    '-------------------------------------------------------------------------------


    'Function SP_L_COMI_CONCE_detall_FUNCI_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.SP_L_COMI_CONCE_DETALL_FUNCI"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_Idcomi_Calcu_FUNCI", OracleClient.OracleType.VarChar)).Value = IDCOMI_CALCU_FUNCI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_COMI_CONCE_DETALL_FUNCI", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        '
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Function SP_L_COMI_CONCE_detall_FUNCI() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_L_COMI_CONCE_DETALL_FUNCI", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_Idcomi_Calcu_FUNCI", IDCOMI_CALCU_FUNCI, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_COMI_CONCE_DETALL_FUNCI", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Function SP_IUPD_COMISIONES_FUNCI_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.SP_IUPD_COMISIONES_FUNCI"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("p_IDUSUARIO_FUNCI_STRING", OracleClient.OracleType.VarChar)).Value = IDUSUARIO_FUNCI_STRING
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDROL_USUARIO", OracleClient.OracleType.Number)).Value = IDROL_USUARIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IP", OracleClient.OracleType.VarChar)).Value = IP
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("OP_SITU", OracleClient.OracleType.VarChar, 4)).Direction = ParameterDirection.Output
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_IUPD_COMISIONES_FUNCI", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        cmd.ExecuteNonQuery()
    '        'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        'Dim ds As New DataSet
    '        'daora.Fill(ds)
    '        'Dim dv As New DataView
    '        'dv = ds.Tables(0).DefaultView
    '        'Return dv
    '        If Not cmd.Parameters("OP_SITU").Value Is DBNull.Value Then
    '            If cmd.Parameters("OP_SITU").Value = "EXRA" Then
    '                MsgBox("Ya existe un cálculo dentro de esta fecha para este funcionario...", MsgBoxStyle.Critical, "Seguridad del Sistema")
    '            End If
    '        End If
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function

    Function SP_IUPD_COMISIONES_FUNCI()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_IUPD_COMISIONES_FUNCI", CommandType.StoredProcedure)
            'Asgina Parametros de entrada

            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("p_IDUSUARIO_FUNCI_STRING", IDUSUARIO_PERSONAL_FUNCI.ToString & ";", OracleClient.OracleType.VarChar)
            'db.AsignarParametro("p_IDUSUARIO_FUNCI_STRING", IDUSUARIO_FUNCI_STRING, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIO", IDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("OP_SITU", 4, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db.AsignarParametro("CUR_IUPD_COMISIONES_FUNCI", OracleClient.OracleType.Cursor, ParameterDirection.Output)
            '
            db.EjecutarComando()
            If db.Parametros.Length > 0 Then
                If Not (db.Parametros(1) Is DBNull.Value) Then
                    If db.Parametros(1) = "EXRA" Then
                        MsgBox("Ya existe un cálculo dentro de esta fecha para este funcionario...", MsgBoxStyle.Critical, "Seguridad del Sistema")
                    End If
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'Function SP_ANU_COMI_CONCE_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.SP_ANU_COMI_CONCE"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_Idcomi_Calcu", OracleClient.OracleType.Number)).Value = IDCOMI_CALCU
    '        cmd.ExecuteNonQuery()
    '        'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        'Dim ds As New DataSet
    '        'daora.Fill(ds)
    '        'Dim dv As New DataView
    '        'dv = ds.Tables(0).DefaultView
    '        'Return dv
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Function SP_ANU_COMI_CONCE()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_ANU_COMI_CONCE", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_Idcomi_Calcu", IDCOMI_CALCU, OracleClient.OracleType.Int32)
            'Asigna parametro de salida 
            '
            db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'Function SP_ANU_COMI_FUNCI_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.SP_ANU_COMI_FUNCI"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_Idcomi_Calcu_FUNCI", OracleClient.OracleType.Number)).Value = IDCOMI_CALCU_FUNCI
    '        cmd.ExecuteNonQuery()
    '        'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        'Dim ds As New DataSet
    '        'daora.Fill(ds)
    '        'Dim dv As New DataView
    '        'dv = ds.Tables(0).DefaultView
    '        'Return dv
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Function SP_ANU_COMI_FUNCI()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_ANU_COMI_FUNCI", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_Idcomi_Calcu_FUNCI", IDCOMI_CALCU_FUNCI, OracleClient.OracleType.Int32)
            'Asigna parametro de salida 
            '
            db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'Function sp_up_TIPO_COMPRO_AGEN_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.sp_up_TIPO_COMPRO_AGEN"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_PORCEN", OracleClient.OracleType.Double)).Value = PORCEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_X_COMPROBANTE", OracleClient.OracleType.Double)).Value = MONTO_X_COMPROBANTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_OCUPABILIDAD", OracleClient.OracleType.Double)).Value = OCUPABILIDAD
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_AFEC_COMI", OracleClient.OracleType.Number)).Value = CInt(AFEC_COMI)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_CANTI_SERVI", OracleClient.OracleType.Double)).Value = CANTI_SERVI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_OTROS", OracleClient.OracleType.Double)).Value = OTROS
    '        cmd.ExecuteNonQuery()
    '        'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        'Dim ds As New DataSet
    '        'daora.Fill(ds)
    '        'Dim dv As New DataView
    '        'dv = ds.Tables(0).DefaultView
    '        'Return dv
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Function sp_up_TIPO_COMPRO_AGEN()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.sp_up_TIPO_COMPRO_AGEN", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDTIPO_COMPROBANTE", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_PORCEN", PORCEN, OracleClient.OracleType.Double)
            db.AsignarParametro("P_MONTO_X_COMPROBANTE", MONTO_X_COMPROBANTE, OracleClient.OracleType.Double)
            db.AsignarParametro("P_OCUPABILIDAD", OCUPABILIDAD, OracleClient.OracleType.Double)
            db.AsignarParametro("P_AFEC_COMI", CInt(AFEC_COMI), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_CANTI_SERVI", CANTI_SERVI, OracleClient.OracleType.Double)
            db.AsignarParametro("P_OTROS", OTROS, OracleClient.OracleType.Double)
            'Asigna parametro de salida 
            '
            db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'Public Function sp_up_TIPO_COMPRO_FUNCI_2009(ByVal cnn As System.Data.OracleClient.OracleConnection)
    '    Try
    '        TIPO_COMPROBANTE = Mid(TIPO_COMPROBANTE, Len(TIPO_COMPROBANTE) - 3, 4)
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.sp_up_TIPO_COMPRO_FUNCI"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL_FUNCI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_PORCEN", OracleClient.OracleType.Double)).Value = PORCEN
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_MONTO_X_COMPROBANTE", OracleClient.OracleType.Double)).Value = MONTO_X_COMPROBANTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_AFEC_COMI", OracleClient.OracleType.Number)).Value = CInt(AFEC_COMI)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_ANTI_NUE", OracleClient.OracleType.VarChar)).Value = TIPO_COMPROBANTE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_OTROS", OracleClient.OracleType.Double)).Value = OTROS
    '        '
    '        cmd.ExecuteNonQuery()
    '        '
    '        'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        'Dim ds As New DataSet
    '        'daora.Fill(ds)
    '        'Dim dv As New DataView
    '        'dv = ds.Tables(0).DefaultView
    '        'Return dv
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Public Function sp_up_TIPO_COMPRO_FUNCI()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.sp_up_TIPO_COMPRO_FUNCI", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDTIPO_COMPROBANTE", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_PORCEN", PORCEN, OracleClient.OracleType.Double)
            db.AsignarParametro("P_MONTO_X_COMPROBANTE", MONTO_X_COMPROBANTE, OracleClient.OracleType.Double)
            db.AsignarParametro("P_AFEC_COMI", CInt(AFEC_COMI), OracleClient.OracleType.Number)
            db.AsignarParametro("P_ANTI_NUE", TIPO_COMPROBANTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_OTROS", OTROS, OracleClient.OracleType.Double)
            'Asigna parametro de salida 
            '
            db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    'Public Sub SP_SELEC_TIPO_COMPRO_AGEN_2009(ByVal CNN As OracleClient.OracleConnection)
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = CNN
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOCOMISIONES.SP_SELEC_TIPO_COMPRO_AGEN"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDTIPO_COMPROBANTE", OracleClient.OracleType.Number)).Value = IDTIPO_COMPROBANTE
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_SELEC_TIPO_COMPRO_AGEN", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim DA As New OracleClient.OracleDataAdapter(cmd)
    '    Dim DS As New DataSet
    '    DA.Fill(DS)
    '    Dim DV As New DataView
    '    DV = DS.Tables(0).DefaultView
    '    If DV.Count <= 0 Then Exit Sub
    '    If Not DV.Table.Rows(0).IsNull("OTROS") Then OTROS = DV.Table.Rows(0)("OTROS") Else OTROS = 0
    '    If Not DV.Table.Rows(0).IsNull("IDTIPO_COMPROBANTE") Then IDTIPO_COMPROBANTE = DV.Table.Rows(0)("IDTIPO_COMPROBANTE") Else IDTIPO_COMPROBANTE = 0
    '    If Not DV.Table.Rows(0).IsNull("IDAGENCIAS") Then IDAGENCIAS = DV.Table.Rows(0)("IDAGENCIAS") Else IDAGENCIAS = 0
    '    If Not DV.Table.Rows(0).IsNull("PORCEN") Then PORCEN = DV.Table.Rows(0)("PORCEN") Else PORCEN = ""
    '    If Not DV.Table.Rows(0).IsNull("MONTO_X_COMPROBANTE") Then MONTO_X_COMPROBANTE = DV.Table.Rows(0)("MONTO_X_COMPROBANTE") Else MONTO_X_COMPROBANTE = ""
    '    If Not DV.Table.Rows(0).IsNull("OCUPABILIDAD") Then OCUPABILIDAD = DV.Table.Rows(0)("OCUPABILIDAD") Else OCUPABILIDAD = 0
    '    If Not DV.Table.Rows(0).IsNull("CANTI_SERVI") Then CANTI_SERVI = DV.Table.Rows(0)("CANTI_SERVI") Else CANTI_SERVI = ""
    'End Sub
    Public Sub SP_SELEC_TIPO_COMPRO_AGEN()
        Try
            Dim db As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_SELEC_TIPO_COMPRO_AGEN", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDTIPO_COMPROBANTE", IDTIPO_COMPROBANTE, OracleClient.OracleType.Int32)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_SELEC_TIPO_COMPRO_AGEN", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            '
            ldt_tmp = db.EjecutarDataTable
            Dim DV As New DataView
            DV = ldt_tmp.DefaultView
            '
            If DV.Count <= 0 Then Exit Sub
            If Not DV.Table.Rows(0).IsNull("OTROS") Then OTROS = DV.Table.Rows(0)("OTROS") Else OTROS = 0
            If Not DV.Table.Rows(0).IsNull("IDTIPO_COMPROBANTE") Then IDTIPO_COMPROBANTE = DV.Table.Rows(0)("IDTIPO_COMPROBANTE") Else IDTIPO_COMPROBANTE = 0
            If Not DV.Table.Rows(0).IsNull("IDAGENCIAS") Then IDAGENCIAS = DV.Table.Rows(0)("IDAGENCIAS") Else IDAGENCIAS = 0
            If Not DV.Table.Rows(0).IsNull("PORCEN") Then PORCEN = DV.Table.Rows(0)("PORCEN") Else PORCEN = ""
            If Not DV.Table.Rows(0).IsNull("MONTO_X_COMPROBANTE") Then MONTO_X_COMPROBANTE = DV.Table.Rows(0)("MONTO_X_COMPROBANTE") Else MONTO_X_COMPROBANTE = ""
            If Not DV.Table.Rows(0).IsNull("OCUPABILIDAD") Then OCUPABILIDAD = DV.Table.Rows(0)("OCUPABILIDAD") Else OCUPABILIDAD = 0
            If Not DV.Table.Rows(0).IsNull("CANTI_SERVI") Then CANTI_SERVI = DV.Table.Rows(0)("CANTI_SERVI") Else CANTI_SERVI = ""
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
    'Public Function f_monto_ocupa_2009(ByVal cnn As OracleClient.OracleConnection) As Double
    '    Dim DA As New OracleClient.OracleDataAdapter("select PKG_IVOCOMISIONES.f_monto_ocupa(" & para_monto_comi_ocu & ") valor from dual", cnn)
    '    Dim DS As New DataSet
    '    DA.Fill(DS, "mitabla")
    '    monto_ocupa_calcu = DS.Tables("mitabla").Rows(0)("valor")
    '    Return monto_ocupa_calcu
    'End Function
    Public Function f_monto_ocupa() As Double
        Dim db As New BaseDatos
        Dim ls_sql As String = "select PKG_IVOCOMISIONES.f_monto_ocupa(" & para_monto_comi_ocu & ") valor from dual"
        Try
            'Connectar 
            db.Conectar()
            'Invocando al procedimiento 
            db.CrearComando(ls_sql, CommandType.Text)
            'Parametro Ingreso             
            'Parametro de Salida
            '
            'db.EjecutarComando()
            monto_ocupa_calcu = db.EjecutarEscalar()
            'If db.Parametros.Length > 0 Then
            '    monto_ocupa_calcu = CType(IIf(db.Parametros(1) Is DBNull.Value, "", db.Parametros(1)), Double)
            'Else
            '    monto_ocupa_calcu = 0
            'End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
        Return monto_ocupa_calcu
    End Function
    'Public Function f_porcen_carga_2009(ByVal cnn As OracleClient.OracleConnection) As Double
    '    Dim DA As New OracleClient.OracleDataAdapter("select PKG_IVOCOMISIONES.f_porcen_carga(" & ParaMontoCarga & ") valor from dual", cnn)
    '    Dim DS As New DataSet
    '    DA.Fill(DS, "mitabla")
    '    PorcenCarga = DS.Tables("mitabla").Rows(0)("valor")
    '    Return PorcenCarga
    'End Function
    Public Function f_porcen_carga() As Double
        Dim db As New BaseDatos
        Dim ls_sql As String = "select PKG_IVOCOMISIONES.f_porcen_carga(" & ParaMontoCarga & ") valor from dual"
        Try
            'Connectar 
            db.Conectar()
            'Invocando al procedimiento 
            db.CrearComando(ls_sql, CommandType.Text)
            'Parametro Ingreso             
            'Parametro de Salida
            '
            PorcenCarga = db.EjecutarEscalar()
            'If db.Parametros.Length > 0 Then
            '    PorcenCarga = CType(IIf(db.Parametros(1) Is DBNull.Value, "", db.Parametros(1)), Double)
            'Else
            '    PorcenCarga = 0
            'End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
        Return PorcenCarga
    End Function
    'Sub SP_IUPDE_AGRE_OTROS_DESCU_2009(ByVal CNN As OracleClient.OracleConnection)
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = CNN
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOCOMISIONES.SP_IUPDE_AGRE_OTROS_DESCU"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDCOMI_CALCU", OracleClient.OracleType.Number)).Value = IDCOMI_CALCU
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_TIPO_COMPROBANTE", OracleClient.OracleType.VarChar)).Value = TIPO_COMPROBANTE
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_SUB_TOTAL_PAGAR_COMI", OracleClient.OracleType.Double)).Value = SUB_TOTAL_PAGAR_COMI
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA", OracleClient.OracleType.VarChar)).Value = FECHA
    '    cmd.ExecuteNonQuery()
    'End Sub
    Sub SP_IUPDE_AGRE_OTROS_DESCU()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_IUPDE_AGRE_OTROS_DESCU", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_IDCOMI_CALCU", IDCOMI_CALCU, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_TIPO_COMPROBANTE", TIPO_COMPROBANTE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_SUB_TOTAL_PAGAR_COMI", SUB_TOTAL_PAGAR_COMI, OracleClient.OracleType.Double)
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA", FECHA, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            '
            db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
    'Sub sp_cierre_comi_funci_2009(ByVal CNN As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = CNN
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.sp_cierre_comi_funci"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Sub sp_cierre_comi_funci()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.sp_cierre_comi_funci", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            '
            db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
    'Sub sp_cierre_comi_2009(ByVal CNN As OracleClient.OracleConnection)
    '    Try

    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = CNN
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.sp_cierre_comi"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL

    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
    Sub sp_cierre_comi()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.sp_cierre_comi", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            '
            db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
    'Function SP_L_COMI_CONCE_FUNCI_II_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.SP_L_COMI_CONCE_FUNCI_II"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_Idfuncionario", OracleClient.OracleType.Number)).Value = IDFUNCIONARIO
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_COMI_CONCE_FUNCI", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Function SP_L_COMI_CONCE_FUNCI_II() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_L_COMI_CONCE_FUNCI_II", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_Idfuncionario", IDFUNCIONARIO, OracleClient.OracleType.Number)
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_COMI_CONCE_FUNCI", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Function SP_L_COMI_CONCE_II_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCOMISIONES.SP_L_COMI_CONCE_II"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDAGENCIAS", OracleClient.OracleType.Number)).Value = IDAGENCIAS
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_INI", OracleClient.OracleType.VarChar)).Value = FECHA_INI
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FECHA_FINAL", OracleClient.OracleType.VarChar)).Value = FECHA_FINAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_L_COMI_CONCE", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        Return dv
    '    Catch OEx As System.Data.OracleClient.OracleException
    '        MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Function
    Function SP_L_COMI_CONCE_II() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_L_COMI_CONCE_II", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_IDAGENCIAS", IDAGENCIAS, OracleClient.OracleType.Number)
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_COMI_CONCE", OracleClient.OracleType.Cursor)
            '
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function SP_L_COMI_CONCE_detall_FUNCI(ByVal codigo As String) As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_L_COMI_CONCE_DETALL_FUNCI", CommandType.StoredProcedure)
            'Asgina Parametros de entrada
            db.AsignarParametro("P_Idcomi_Calcu_FUNCI", IDCOMI_CALCU_FUNCI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_codigo", codigo, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_COMI_CONCE_DETALL_FUNCI", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ID_COMI_FUNCI() As DataTable
        Try
            Dim db As New BaseDatos
            Dim dt As DataTable
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.sp_ID_COMI_FUNCI", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL_FUNCI", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("CO_ID_COMI_FUNCI", OracleClient.OracleType.Cursor)
            db.Desconectar()
            dt = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function



#Region "Calculo de las Comisiones para los Funcionarios de Carga - FrmCalcComi"

    Function ListarPorcentajeCarga() As DataSet
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet = Nothing
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_LISTAR_OBJETIVO", CommandType.StoredProcedure)
            db.AsignarParametro("Cursor_Objetivo", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function

    Function ListarVentaTotalFuncionario() As DataSet
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Try
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("PKG_IVOCOMISIONES.SP_VENTA_FUNCIONARIO", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOCOMISIONES.SP_VENTA_FUNCIONARIO_CARTERA", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL_FUNCI", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_SERVICIOS_FUNCI_MONTO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function

    Function ObtnerMetaFuncionario() As DataTable
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Dim dbluMeta As Double = 0
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_OBTENER_META_FUNCIONARIO", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL_FUNCI", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Asigna parametro de salida 
            db.AsignarParametro("Cursor_Meta", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
            'dbluMeta = Convert.ToDouble(lds_tmp.Tables(0).Rows(0)(0).ToString())
            Return lds_tmp.Tables(0)
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        'Return dbluMeta
    End Function

    Function ObtnerBonoPenalidad() As Integer
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Dim intBonoPena As Double = 0
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_OBTENER_BONO_PENALIDAD", CommandType.StoredProcedure)
            db.AsignarParametro("p_porcentaje_venta", PorcentajeVenta, OracleClient.OracleType.Double)
            'Asigna parametro de salida 
            db.AsignarParametro("Cursor_Comision", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
            If (lds_tmp.Tables(0).Rows.Count = 1) Then
                intBonoPena = Convert.ToDouble(lds_tmp.Tables(0).Rows(0)(0).ToString())
            Else
                intBonoPena = 0
            End If

        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return intBonoPena
    End Function

    Function ListarCobranzaTotalFuncionario() As DataSet
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Try
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("PKG_IVOCOMISIONES.SP_COBRANZA_FUNCIONARIO", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOCOMISIONES.SP_COBRANZA_FUNCIONARIO_CAR", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL_FUNCI", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_producto", Producto, OracleClient.OracleType.Int32)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_SERVICIOS_FUNCI_MONTO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function


#End Region


#Region "Calculo de las Comisiones para los Funcionarios de Pasaje - FrmCalcComi"

    Function ListarPorcentajePasaje() As DataSet
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_LISTAR_OBJETIVO_PASAJE", CommandType.StoredProcedure)
            db.AsignarParametro("P_IdUsuario_Personal", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_Fecha_Inicio", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_Fecha_Final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("Cursor_Objetivo", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function

    Function ListarVentaTotalFuncionarioPasaje() As DataSet
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Try
            db.Conectar()
            'hlamas 03-02-2014
            db.CrearComando("PKG_IVOCOMISIONES.SP_VENTA_FUNCIONARIO_PASAJE_1", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL_FUNCI", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_SERVICIOS_FUNCI_MONTO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function

    Function ListarBaseTotalFuncionarioPasaje(ByVal IdTipoFuncionario As String) As DataSet
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Try
            db.Conectar()
            'hlamas 03-02-2014
            db.CrearComando("PKG_IVOCOMISIONES.SP_OBTE_BASE_FUNCI_PASAJE_1", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDTIPO_FUNCIONARIO", IdTipoFuncionario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL_FUNCI", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("Cursor_Base", OracleClient.OracleType.Cursor)
            db.AsignarParametro("Cursor_Error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function

    Function ObtnerMetaFuncionarioPasaje() As DataSet
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_OBTE_META_FUNCI_PASAJE", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL_FUNCI", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("Cursor_Meta", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function

    Function ObtenerBonoPenalidadPasaje() As Double
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Dim intBonoPena As Double = 0
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_OBT_BONO_PEN_LIMA_PROV", CommandType.StoredProcedure)
            db.AsignarParametro("P_IdUsuario_Personal", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_Fecha_Inicio", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_Fecha_Final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            If Origen = 1 Then
                db.AsignarParametro("p_porcentaje_venta", PorcentajeVentaLima, OracleClient.OracleType.Double)
            ElseIf Origen = 2 Then
                db.AsignarParametro("p_porcentaje_venta", PorcentajeVentaProvincia, OracleClient.OracleType.Double)
            End If
            db.AsignarParametro("p_origen", Origen, OracleClient.OracleType.Int32)
            'Asigna parametro de salida 
            db.AsignarParametro("Cursor_Comision", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
            If (lds_tmp.Tables(0).Rows.Count = 1) Then
                intBonoPena = Convert.ToDouble(lds_tmp.Tables(0).Rows(0)(0).ToString())
            Else
                intBonoPena = 0
            End If

        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return intBonoPena
    End Function

    Function ListarCobranzaTotalFuncionarioPasaje() As DataSet
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_COB_FUNCI_PASAJE", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL_FUNCI", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_SERVICIOS_FUNCI_MONTO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function

    Function ListarCobranzaTotalFuncionarioPasaje2(ByVal IdTipoFuncionario As String) As DataSet
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Try
            db.Conectar()
            'hlamas 03-02-2014
            db.CrearComando("PKG_IVOCOMISIONES.SP_COB_FUNCI_PASAJE_2_1", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDTIPO_FUNCIONARIO", IdTipoFuncionario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL_FUNCI", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_CANTIDAD_DOCUMENTOS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_L_SERVICIOS_FUNCI_MONTO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_PORCENTAJE_COMERCIAL", OracleClient.OracleType.Cursor)
            db.AsignarParametro("CUR_ERROR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function

    Function InsertCabeceraComisionCargaPasaje()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_INSERT_COMISION_CAB", CommandType.StoredProcedure)

            'Asgina Parametros de entrada
            db.AsignarParametro("P_FECHA_INI", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDAGENCIA", IDAGENCIAS, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL_USUARIO", IDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL_FUNCI", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_META_LIMA", MetaLima, OracleClient.OracleType.Double)
            db.AsignarParametro("P_META_PROVINCIA", MetaProvincia, OracleClient.OracleType.Double)

            'Asigna parametro de salida 
            db.AsignarParametro("OP_SITU", 4, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db.AsignarParametro("P_IDCOMI_CALCU_FUNCI", OracleClient.OracleType.Int32, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db.AsignarParametro("Cursor_IDComision", OracleClient.OracleType.Cursor, ParameterDirection.Output)
            '
            db.EjecutarComando()
            If db.Parametros.Length > 0 Then
                If Not (db.Parametros(2) Is DBNull.Value) Then
                    IDCOMI_CALCU_FUNCI = db.Parametros(2).ToString
                End If
            End If

            If db.Parametros.Length > 0 Then
                If Not (db.Parametros(1) Is DBNull.Value) Then
                    If db.Parametros(1) = "EXRA" Then
                        MsgBox("Ya existe un cálculo dentro de esta fecha para este funcionario...", MsgBoxStyle.Critical, "Seguridad del Sistema")
                        EXISTE_COMISION = 1
                    Else
                        EXISTE_COMISION = 0
                    End If
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function InsertDetalleComisionCargaPasaje()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_INSERT_COMI_VENTA_COBRO_DET", CommandType.StoredProcedure)

            'Asgina Parametros de entrada
            db.AsignarParametro("P_IDCOMI_CALCU_FUNCI", IDCOMI_CALCU_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_CONCEPTO", CONCEPTO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_ORIGEN", NOMBRE_ORIGEN, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_TIPO", FORMA_PAGO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_TOTAL", TOTAL_FORMA_PAGO, OracleClient.OracleType.Double)

            'Asigna parametro de salida 
            'db.AsignarParametro("OP_SITU", 4, OracleClient.OracleType.VarChar, ParameterDirection.Output)
            db.AsignarParametro("Cursor_Comision_Detalle", OracleClient.OracleType.Cursor, ParameterDirection.Output)
            '
            db.EjecutarComando()
            'If db.Parametros.Length > 0 Then
            '    If Not (db.Parametros(1) Is DBNull.Value) Then
            '        If db.Parametros(1) = "EXRA" Then
            '            MsgBox("Ya existe un detalle dentro de esta fecha para este funcionario...", MsgBoxStyle.Critical, "Seguridad del Sistema")
            '        End If
            '    End If
            'End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function InsertTotalComisionCargaPasaje()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_INSERT_COMI_TOTAL_FUNCI_DET", CommandType.StoredProcedure)

            'Asgina Parametros de entrada
            db.AsignarParametro("P_IDCOMI_CALCU_FUNCI", IDCOMI_CALCU_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDGRUPO", IDGRUPO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_GRUPO", GRUPO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_ORIGEN", NOMBRE_ORIGEN, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_TIPO_COBRANZA", TIPO_COBRANZA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_PORCENTAJE", PORCENTAJE_COMISION, OracleClient.OracleType.Double)
            db.AsignarParametro("P_TOTAL", TOTAL_COBRANZA, OracleClient.OracleType.Double)
            db.AsignarParametro("P_COMISION", TOTAL_COMISION, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_producto", NombreProducto, OracleClient.OracleType.VarChar)

            'Asigna parametro de salida 
            db.AsignarParametro("Cursor_Comision_Total", OracleClient.OracleType.Cursor, ParameterDirection.Output)
            '
            db.EjecutarComando()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

#End Region

#Region "Calculo de las Comisiones para el Ejecutivo de Pasajes"
    Function ListarPorcentajeEjecutivoPasaje() As DataSet
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_PORCEN_EJEC_PASAJE", CommandType.StoredProcedure)
            db.AsignarParametro("Cursor_Objetivo", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function

    Function ListarVentaEjecutivoPasaje() As DataSet
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_VENTA_EJECUTIVO_PASAJE", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL_FUNCI", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_SERVICIOS_FUNCI_MONTO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function

    Function ListarCobranzaTotalEjecutivoPasaje() As DataSet
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Try
            db.Conectar()
            'hlamas 01-06-2014
            'db.CrearComando("PKG_IVOCOMISIONES.SP_COBRO_EJECUTIVO_PASAJE", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOCOMISIONES.SP_COBRO_EJECUTIVO_PASAJE_CAR", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL_FUNCI", IDUSUARIO_PERSONAL_FUNCI, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_FECHA_INICIAL", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_FECHA_FINAL", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_L_SERVICIOS_FUNCI_MONTO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function

    Function ReporteTotalComisiones() As DataSet
        Dim db As New BaseDatos
        Dim lds_tmp As DataSet
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCOMISIONES.SP_REP_TOTAL_COMISION_FUNCI", CommandType.StoredProcedure)
            db.AsignarParametro("p_fecha_ini", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            'Asigna parametro de salida 
            db.AsignarParametro("CUR_REP_TOTAL_COMI_FUNCI", OracleClient.OracleType.Cursor)
            db.Desconectar()
            lds_tmp = db.EjecutarDataSet
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
        Return lds_tmp
    End Function

#End Region

End Class
