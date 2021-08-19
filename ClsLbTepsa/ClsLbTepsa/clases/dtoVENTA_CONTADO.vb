Imports AccesoDatos
Public Class dtoVENTA_CONTADO
    Implements IDisposable


#Region "VARIABLES"
    Dim MyIDTIPO_ENTREGA As Long
    Dim MyFECHA_DEVOLUCION As String
    Dim MyIDUSUARIO_ANULACION As Long
    Dim MyIDUSUARIO_DEVOLUCION As Long
    Dim MyIDROL_ANULACION As Long
    Dim MyIDROL_DEVOLUCION As Long
    Dim MyIDTARJETAS As Long
    Dim MyNROTARJETA As String
    Dim MyIDTIPO_PAGO As Long
    Dim MyPRECIO_X_SOBRE As Long
    Dim MyMONTO_SUB_TOTAL As Long
    Dim MyIDCONTACTO_DESTINO As Long
    Dim MyMONTO_BASE As Long
    Dim MyIDLIQUI_TURNOS As Long
    Dim MyIDLIQUIDAQCION_OFICINA As Long
    Dim MyIDFACTURA As Long
    Dim MyIDPERSONA As Long
    Dim MySERIE_FACTURA As String
    Dim MyIDTIPO_COMPROBANTE As Long
    Dim MyNRO_FACTURA As String
    Dim MyFECHA_REGISTRO As String
    Dim MyMONTO_IMPUESTO As Long
    Dim MyTOTAL_COSTO As Long
    Dim MyIDFORMA_PAGO As Long
    Dim MyIDESTADO_ENVIO As Long
    Dim MyIDESTADO_FACTURA As Long
    Dim MyIDCIUDAD_TRANSITO As Long
    Dim MyCANTIDAD_X_PESO As Long
    Dim MyTOTAL_PESO As Long
    Dim MyTOTAL_VOLUMEN As Long
    Dim MyIDGUIA_TRANSPORTISTA As Long
    Dim MyIDGUIA_TRANSPORTISTA_UPD As Long
    Dim MyIDUNIDAD_ORIGEN As Long
    Dim MyIDUNIDAD_DESTINO As Long
    Dim MyIDDIREECION_ORIGEN As Long
    Dim MyIDDIREECION_DESTINO As Long
    Dim MyMONTO_TIPO_CAMBIO As Long
    Dim MyIDTIPO_MONEDA As Long
    Dim MyIDTIPO_SERVICIO_GIRO As Long
    Dim MyFECHA_FACTURA As String
    Dim MyFECHA_VENCIMIENTO As String
    Dim MyMEMO As String
    Dim MyIDPERSONA_ORIGEN As Long
    Dim MyIDPERSONA_DESTINO As Long
    Dim MyIDAGENCIAS As Long
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIP As String
    Dim MyIDROL_USUARIO As Long
    Dim MyIPMOD As String
    Dim MyIDROL_USUARIOMOD As Long
    Dim MyFECHA_REGISTRO_ACTUALIZACION As String
    Dim MyIMPRESO As Long
    Dim MyFECHA_CARGO As String
    Dim MyCARGO As Long
    Dim MyCANTIDAD_X_VOLUMEN As Long
    Dim MyCANTIDAD_X_SOBRE As Long
    Dim MyPRECIO_X_PESO As Long
    Dim MyPRECIO_X_VOLUMEN As Long
    Dim MyPRECIO_X_UNIDAD As Long
    Dim MyIDPROCESOS As Long
    Dim MyLIQUIDADO As Long
    Dim MyFECHA_CIERRE As String
    Dim MyIDAGENCIAS_DESTINO As Long
    Dim MyIDTEFONO_REMITENTE As Long
    Dim MyIDTEFONO_CONSIGNADO As Long
    Dim MyMONTO_DESCUENTO As Long
    Dim MyMONTO_PENALIDAD As Long
    Dim MyREF_IDFACTURA As Long
    Dim MyIDFUNCIONARIO_AUTORIZACION As Long
    Dim MyIGV As Long
    Dim MyPORCENT_DEVOLUCION As Long
    Dim MyPORCENT_DESCUENTO As Long
    Dim MyMONTO_RECARGO As Long
    Dim MyBILLETE_DE_PAGO As Long
    Dim MyCONTROL_CONTABLE As Long
    Dim MyIDREMITENTE As Long
    Dim MyFECHA_ACTUALIZACION As String
    Dim MyCONCEPTO_CONTROL As String
    Dim MyFECHA_ANULACION As String
    Dim mytipo_bole_impre As String
    Dim mytipo_factu_impre As String
    Dim mytipo_guia_transpor_impre As String

#End Region
#Region "PROPIEDADES"
    Public Property tipo_guia_transpor_impre() As String
        Get
            tipo_guia_transpor_impre = mytipo_guia_transpor_impre
        End Get
        Set(ByVal value As String)
            mytipo_guia_transpor_impre = value
        End Set
    End Property
    Public Property tipo_factu_impre() As String
        Get
            tipo_factu_impre = mytipo_factu_impre
        End Get
        Set(ByVal value As String)
            mytipo_factu_impre = value
        End Set
    End Property
    Public Property tipo_bole_impre() As String
        Get
            tipo_bole_impre = mytipo_bole_impre
        End Get
        Set(ByVal value As String)
            mytipo_bole_impre = value
        End Set
    End Property
    Public Property MONTO_RECARGO() As Long
        Get
            MONTO_RECARGO = MyMONTO_RECARGO
        End Get
        Set(ByVal value As Long)
            MyMONTO_RECARGO = value
        End Set
    End Property
    Public Property BILLETE_DE_PAGO() As Long
        Get
            BILLETE_DE_PAGO = MyBILLETE_DE_PAGO
        End Get
        Set(ByVal value As Long)
            MyBILLETE_DE_PAGO = value
        End Set
    End Property
    Public Property CONTROL_CONTABLE() As Long
        Get
            CONTROL_CONTABLE = MyCONTROL_CONTABLE
        End Get
        Set(ByVal value As Long)
            MyCONTROL_CONTABLE = value
        End Set
    End Property
    Public Property IDREMITENTE() As Long
        Get
            IDREMITENTE = MyIDREMITENTE
        End Get
        Set(ByVal value As Long)
            MyIDREMITENTE = value
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
    Public Property CONCEPTO_CONTROL() As String
        Get
            CONCEPTO_CONTROL = MyCONCEPTO_CONTROL
        End Get
        Set(ByVal value As String)
            MyCONCEPTO_CONTROL = value
        End Set
    End Property
    Public Property IDLIQUIDAQCION_OFICINA() As Long
        Get
            IDLIQUIDAQCION_OFICINA = MyIDLIQUIDAQCION_OFICINA
        End Get
        Set(ByVal value As Long)
            MyIDLIQUIDAQCION_OFICINA = value
        End Set
    End Property
    Public Property IDTIPO_ENTREGA() As Long
        Get
            IDTIPO_ENTREGA = MyIDTIPO_ENTREGA
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_ENTREGA = value
        End Set
    End Property
    Public Property FECHA_ANULACION() As String
        Get
            FECHA_ANULACION = MyFECHA_ANULACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ANULACION = value
        End Set
    End Property
    Public Property FECHA_DEVOLUCION() As String
        Get
            FECHA_DEVOLUCION = MyFECHA_DEVOLUCION
        End Get
        Set(ByVal value As String)
            MyFECHA_DEVOLUCION = value
        End Set
    End Property
    Public Property IDUSUARIO_ANULACION() As Long
        Get
            IDUSUARIO_ANULACION = MyIDUSUARIO_ANULACION
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_ANULACION = value
        End Set
    End Property
    Public Property IDUSUARIO_DEVOLUCION() As Long
        Get
            IDUSUARIO_DEVOLUCION = MyIDUSUARIO_DEVOLUCION
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_DEVOLUCION = value
        End Set
    End Property
    Public Property IDROL_ANULACION() As Long
        Get
            IDROL_ANULACION = MyIDROL_ANULACION
        End Get
        Set(ByVal value As Long)
            MyIDROL_ANULACION = value
        End Set
    End Property
    Public Property IDROL_DEVOLUCION() As Long
        Get
            IDROL_DEVOLUCION = MyIDROL_DEVOLUCION
        End Get
        Set(ByVal value As Long)
            MyIDROL_DEVOLUCION = value
        End Set
    End Property
    Public Property IDTARJETAS() As Long
        Get
            IDTARJETAS = MyIDTARJETAS
        End Get
        Set(ByVal value As Long)
            MyIDTARJETAS = value
        End Set
    End Property
    Public Property IDTIPO_PAGO() As Long
        Get
            IDTIPO_PAGO = MyIDTIPO_PAGO
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_PAGO = value
        End Set
    End Property
    Public Property NROTARJETA() As String
        Get
            NROTARJETA = MyNROTARJETA
        End Get
        Set(ByVal value As String)
            MyNROTARJETA = value
        End Set
    End Property
    Public Property PRECIO_X_SOBRE() As Long
        Get
            PRECIO_X_SOBRE = MyPRECIO_X_SOBRE
        End Get
        Set(ByVal value As Long)
            MyPRECIO_X_SOBRE = value
        End Set
    End Property
    Public Property MONTO_SUB_TOTAL() As Long
        Get
            MONTO_SUB_TOTAL = MyMONTO_SUB_TOTAL
        End Get
        Set(ByVal value As Long)
            MyMONTO_SUB_TOTAL = value
        End Set
    End Property
    Public Property IDCONTACTO_DESTINO() As Long
        Get
            IDCONTACTO_DESTINO = MyIDCONTACTO_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDCONTACTO_DESTINO = value
        End Set
    End Property
    Public Property MONTO_BASE() As Long
        Get
            MONTO_BASE = MyMONTO_BASE
        End Get
        Set(ByVal value As Long)
            MyMONTO_BASE = value
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
    Public Property IDFACTURA() As Long
        Get
            IDFACTURA = MyIDFACTURA
        End Get
        Set(ByVal value As Long)
            MyIDFACTURA = value
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
    Public Property SERIE_FACTURA() As String
        Get
            SERIE_FACTURA = MySERIE_FACTURA
        End Get
        Set(ByVal value As String)
            MySERIE_FACTURA = value
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
    Public Property NRO_FACTURA() As String
        Get
            NRO_FACTURA = MyNRO_FACTURA
        End Get
        Set(ByVal value As String)
            MyNRO_FACTURA = value
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
    Public Property MONTO_IMPUESTO() As Long
        Get
            MONTO_IMPUESTO = MyMONTO_IMPUESTO
        End Get
        Set(ByVal value As Long)
            MyMONTO_IMPUESTO = value
        End Set
    End Property
    Public Property TOTAL_COSTO() As Long
        Get
            TOTAL_COSTO = MyTOTAL_COSTO
        End Get
        Set(ByVal value As Long)
            MyTOTAL_COSTO = value
        End Set
    End Property
    Public Property IDFORMA_PAGO() As Long
        Get
            IDFORMA_PAGO = MyIDFORMA_PAGO
        End Get
        Set(ByVal value As Long)
            MyIDFORMA_PAGO = value
        End Set
    End Property
    Public Property IDESTADO_ENVIO() As Long
        Get
            IDESTADO_ENVIO = MyIDESTADO_ENVIO
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_ENVIO = value
        End Set
    End Property
    Public Property IDESTADO_FACTURA() As Long
        Get
            IDESTADO_FACTURA = MyIDESTADO_FACTURA
        End Get
        Set(ByVal value As Long)
            MyIDESTADO_FACTURA = value
        End Set
    End Property
    Public Property IDCIUDAD_TRANSITO() As Long
        Get
            IDCIUDAD_TRANSITO = MyIDCIUDAD_TRANSITO
        End Get
        Set(ByVal value As Long)
            MyIDCIUDAD_TRANSITO = value
        End Set
    End Property
    Public Property CANTIDAD_X_PESO() As Long
        Get
            CANTIDAD_X_PESO = MyCANTIDAD_X_PESO
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_X_PESO = value
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
    Public Property TOTAL_VOLUMEN() As Long
        Get
            TOTAL_VOLUMEN = MyTOTAL_VOLUMEN
        End Get
        Set(ByVal value As Long)
            MyTOTAL_VOLUMEN = value
        End Set
    End Property
    Public Property IDGUIA_TRANSPORTISTA() As Long
        Get
            IDGUIA_TRANSPORTISTA = MyIDGUIA_TRANSPORTISTA
        End Get
        Set(ByVal value As Long)
            MyIDGUIA_TRANSPORTISTA = value
        End Set
    End Property
    Public Property IDGUIA_TRANSPORTISTA_UPD() As Long
        Get
            IDGUIA_TRANSPORTISTA_UPD = MyIDGUIA_TRANSPORTISTA_UPD
        End Get
        Set(ByVal value As Long)
            MyIDGUIA_TRANSPORTISTA_UPD = value
        End Set
    End Property
    Public Property IDUNIDAD_ORIGEN() As Long
        Get
            IDUNIDAD_ORIGEN = MyIDUNIDAD_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_ORIGEN = value
        End Set
    End Property
    Public Property IDUNIDAD_DESTINO() As Long
        Get
            IDUNIDAD_DESTINO = MyIDUNIDAD_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_DESTINO = value
        End Set
    End Property
    Public Property IDDIREECION_ORIGEN() As Long
        Get
            IDDIREECION_ORIGEN = MyIDDIREECION_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDDIREECION_ORIGEN = value
        End Set
    End Property
    Public Property IDDIREECION_DESTINO() As Long
        Get
            IDDIREECION_DESTINO = MyIDDIREECION_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDDIREECION_DESTINO = value
        End Set
    End Property
    Public Property MONTO_TIPO_CAMBIO() As Long
        Get
            MONTO_TIPO_CAMBIO = MyMONTO_TIPO_CAMBIO
        End Get
        Set(ByVal value As Long)
            MyMONTO_TIPO_CAMBIO = value
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
    Public Property IDTIPO_SERVICIO_GIRO() As Long
        Get
            IDTIPO_SERVICIO_GIRO = MyIDTIPO_SERVICIO_GIRO
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_SERVICIO_GIRO = value
        End Set
    End Property
    Public Property FECHA_FACTURA() As String
        Get
            FECHA_FACTURA = MyFECHA_FACTURA
        End Get
        Set(ByVal value As String)
            MyFECHA_FACTURA = value
        End Set
    End Property
    Public Property FECHA_VENCIMIENTO() As String
        Get
            FECHA_VENCIMIENTO = MyFECHA_VENCIMIENTO
        End Get
        Set(ByVal value As String)
            MyFECHA_VENCIMIENTO = value
        End Set
    End Property
    Public Property MEMO() As String
        Get
            MEMO = MyMEMO
        End Get
        Set(ByVal value As String)
            MyMEMO = value
        End Set
    End Property
    Public Property IDPERSONA_ORIGEN() As Long
        Get
            IDPERSONA_ORIGEN = MyIDPERSONA_ORIGEN
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA_ORIGEN = value
        End Set
    End Property
    Public Property IDPERSONA_DESTINO() As Long
        Get
            IDPERSONA_DESTINO = MyIDPERSONA_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA_DESTINO = value
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
    Public Property IP() As String
        Get
            IP = MyIP
        End Get
        Set(ByVal value As String)
            MyIP = value
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
    Public Property IPMOD() As String
        Get
            IPMOD = MyIPMOD
        End Get
        Set(ByVal value As String)
            MyIPMOD = value
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
    Public Property FECHA_REGISTRO_ACTUALIZACION() As String
        Get
            FECHA_REGISTRO_ACTUALIZACION = MyFECHA_REGISTRO_ACTUALIZACION
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO_ACTUALIZACION = value
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
    Public Property FECHA_CARGO() As String
        Get
            FECHA_CARGO = MyFECHA_CARGO
        End Get
        Set(ByVal value As String)
            MyFECHA_CARGO = value
        End Set
    End Property
    Public Property CARGO() As Long
        Get
            CARGO = MyCARGO
        End Get
        Set(ByVal value As Long)
            MyCARGO = value
        End Set
    End Property
    Public Property CANTIDAD_X_VOLUMEN() As Long
        Get
            CANTIDAD_X_VOLUMEN = MyCANTIDAD_X_VOLUMEN
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_X_VOLUMEN = value
        End Set
    End Property
    Public Property CANTIDAD_X_SOBRE() As Long
        Get
            CANTIDAD_X_SOBRE = MyCANTIDAD_X_SOBRE
        End Get
        Set(ByVal value As Long)
            MyCANTIDAD_X_SOBRE = value
        End Set
    End Property
    Public Property PRECIO_X_PESO() As Long
        Get
            PRECIO_X_PESO = MyPRECIO_X_PESO
        End Get
        Set(ByVal value As Long)
            MyPRECIO_X_PESO = value
        End Set
    End Property
    Public Property PRECIO_X_VOLUMEN() As Long
        Get
            PRECIO_X_VOLUMEN = MyPRECIO_X_VOLUMEN
        End Get
        Set(ByVal value As Long)
            MyPRECIO_X_VOLUMEN = value
        End Set
    End Property
    Public Property PRECIO_X_UNIDAD() As Long
        Get
            PRECIO_X_UNIDAD = MyPRECIO_X_UNIDAD
        End Get
        Set(ByVal value As Long)
            MyPRECIO_X_UNIDAD = value
        End Set
    End Property
    Public Property IDPROCESOS() As Long
        Get
            IDPROCESOS = MyIDPROCESOS
        End Get
        Set(ByVal value As Long)
            MyIDPROCESOS = value
        End Set
    End Property
    Public Property LIQUIDADO() As Long
        Get
            LIQUIDADO = MyLIQUIDADO
        End Get
        Set(ByVal value As Long)
            MyLIQUIDADO = value
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
    Public Property IDTEFONO_REMITENTE() As Long
        Get
            IDTEFONO_REMITENTE = MyIDTEFONO_REMITENTE
        End Get
        Set(ByVal value As Long)
            MyIDTEFONO_REMITENTE = value
        End Set
    End Property
    Public Property IDAGENCIAS_DESTINO() As Long
        Get
            IDAGENCIAS_DESTINO = MyIDAGENCIAS_DESTINO
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS_DESTINO = value
        End Set
    End Property
    Public Property IDTEFONO_CONSIGNADO() As Long
        Get
            IDTEFONO_CONSIGNADO = MyIDTEFONO_CONSIGNADO
        End Get
        Set(ByVal value As Long)
            MyIDTEFONO_CONSIGNADO = value
        End Set
    End Property
    Public Property MONTO_DESCUENTO() As Long
        Get
            MONTO_DESCUENTO = MyMONTO_DESCUENTO
        End Get
        Set(ByVal value As Long)
            MyMONTO_DESCUENTO = value
        End Set
    End Property
    Public Property MONTO_PENALIDAD() As Long
        Get
            MONTO_PENALIDAD = MyMONTO_PENALIDAD
        End Get
        Set(ByVal value As Long)
            MyMONTO_PENALIDAD = value
        End Set
    End Property
    Public Property REF_IDFACTURA() As Long
        Get
            REF_IDFACTURA = MyREF_IDFACTURA
        End Get
        Set(ByVal value As Long)
            MyREF_IDFACTURA = value
        End Set
    End Property
    Public Property IDFUNCIONARIO_AUTORIZACION() As Long
        Get
            IDFUNCIONARIO_AUTORIZACION = MyIDFUNCIONARIO_AUTORIZACION
        End Get
        Set(ByVal value As Long)
            MyIDFUNCIONARIO_AUTORIZACION = value
        End Set
    End Property
    Public Property IGV() As Long
        Get
            IGV = MyIGV
        End Get
        Set(ByVal value As Long)
            MyIGV = value
        End Set
    End Property
    Public Property PORCENT_DEVOLUCION() As Long
        Get
            PORCENT_DEVOLUCION = MyPORCENT_DEVOLUCION
        End Get
        Set(ByVal value As Long)
            MyPORCENT_DEVOLUCION = value
        End Set
    End Property
    Public Property PORCENT_DESCUENTO() As Long
        Get
            PORCENT_DESCUENTO = MyPORCENT_DESCUENTO
        End Get
        Set(ByVal value As Long)
            MyPORCENT_DESCUENTO = value
        End Set
    End Property

    Function sp_tipo_format_impre(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
        Try
            Dim cmd As New System.Data.OracleClient.OracleCommand
            cmd.Connection = cnn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "PKG_IVOFACTURACION.sp_tipo_format_impre"
            cmd.Parameters.Add(New OracleClient.OracleParameter("P_idagencias", OracleClient.OracleType.VarChar)).Value = IDAGENCIAS
            cmd.Parameters.Add(New OracleClient.OracleParameter("curr_tipo_format_impre", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

            Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

            Dim ds As New DataSet
            daora.Fill(ds)


            Dim dv As New DataView

            dv = ds.Tables(0).DefaultView

            Return dv


        Catch OEx As System.Data.OracleClient.OracleException
            MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Function
    Function sp_tipo_format_impre() As DataView
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOFACTURACION.sp_tipo_format_impre", CommandType.StoredProcedure)
            db.AsignarParametro("p_idagencias", IDAGENCIAS, OracleClient.OracleType.VarChar)
            db.AsignarParametro("curr_tipo_format_impre", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable.DefaultView
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

#End Region

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
