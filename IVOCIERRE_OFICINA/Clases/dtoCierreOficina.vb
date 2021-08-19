Imports AccesoDatos
Public Class dtoCierreOficina

#Region "FRM: APERTURA OFICINA"
    Function ListarAgencia() As DataSet
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_Lista_Agencia", CommandType.StoredProcedure)
            db.AsignarParametro("co_Lista_Agencias", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function Aperturar(ByVal FECHA_APERTURA As String, ByVal ID_AGENCIA As Integer, ByVal USUARIO_CREACION As String, _
                       ByVal IP_CREACION As String, ByVal ESTADO As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_Ins_Apertura_Oficina", CommandType.StoredProcedure)
            db.AsignarParametro("vi_FECHA_APERTURA", FECHA_APERTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ID_AGENCIA", ID_AGENCIA, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_USUARIO_CREACION", USUARIO_CREACION, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_IP_CREACION", IP_CREACION, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ESTADO", ESTADO, OracleClient.OracleType.Int32)
            '---
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            MsgBox(dt.Rows(0)(0), MsgBoxStyle.Information, "Seguridad Sistema")
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarAperturaOficina(ByVal IDUsuario_Personal As Integer, ByVal IDAgencias As Integer, ByVal FechaApertura As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_Listar_Apertura_Oficina", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDUsuario_Personal", IDUsuario_Personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDAgencias", IDAgencias, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_FechaApertura", FechaApertura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("Co_ListarAperturaCerrado", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("Co_ListarAperturaOficina", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

#End Region

#Region "FRM: LIQUIDACION DIARIA"
    Function Inicio(ByVal IDUsuario_Personal As Integer, ByVal IDAgencias As Integer, ByVal FechaApertura As String, Optional ByVal opcion As Integer = 0) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_Inicio", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDUsuario_Personal", IDUsuario_Personal, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDAgencias", IDAgencias, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_FechaApertura", FechaApertura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_ValidacionAperturado", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_Lista_TipoMovimientos", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_Lista_AgenciaDestino", OracleClient.OracleType.Cursor) '2
            db.AsignarParametro("co_ListaPiloto", OracleClient.OracleType.Cursor) '3
            db.AsignarParametro("co_FechaApertura", OracleClient.OracleType.Cursor) '4
            db.AsignarParametro("co_UsuariosCajasAperturas", OracleClient.OracleType.Cursor) '5
            db.AsignarParametro("co_ListaGastosLiquidacion", OracleClient.OracleType.Cursor) '6
            db.AsignarParametro("co_ListaTotalGastos", OracleClient.OracleType.Cursor) '7
            db.AsignarParametro("co_ListaTotalTarjetas", OracleClient.OracleType.Cursor) '8
            db.AsignarParametro("co_listaCounter", OracleClient.OracleType.Cursor) '9            
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '10
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ListarCounterAsociadas(ByVal IDLiquidacionOficina As Integer, ByVal IDAgencias As Integer, ByVal FechaApertura As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_listaCounterAsociadas", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDOficinaLiquidacion", IDLiquidacionOficina, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDAgencias", IDAgencias, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_FechaApertura", FechaApertura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_listaCounterAsociadas", OracleClient.OracleType.Cursor) '0               
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '10
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function


    Function ListaCaja(ByVal IDAgencias As Integer, ByVal FechaLiquidacion As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_ListaCaja", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDAgencia", IDAgencias, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_FechaLiquidacion", FechaLiquidacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_Datos", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_listaCounter", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '2
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function GrabacionGastosLiquidacion(ByVal IDGastosLiquidacion As String, ByVal IDLiquidacionOficina As Integer, ByVal IDTipoLiquidacionDiaria As Integer, _
                                      ByVal iOpcion As Integer, ByVal Nro_Documento As String, ByVal Codigo_Peaje As String, _
                                      ByVal Cuenta_Bancaria As String, ByVal Monto As Double, ByVal Nro_Bus As String, _
                                      ByVal ID_Destino As Integer, ByVal ID_Piloto As Integer, ByVal Depositante As String, _
                                      ByVal Contacto As String, ByVal Observaciones As String, _
                                      ByVal Fecha_Apertura As String, ByVal IDUsuario_Sistema As Integer, ByVal usuario As Integer, ByVal negocio As Integer, _
                                      Optional ByVal agencia As Integer = 0, Optional ByVal unidad As Integer = 1) As Boolean
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_InsUpd_GastosLiquidacion", CommandType.StoredProcedure)
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_InsUpd_GastosLiquidacion3", CommandType.StoredProcedure)
            db.AsignarParametro("vi_IDGastosLiquidacion", Trim(IDGastosLiquidacion), OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_IDLiquidacionOficina", IDLiquidacionOficina, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDTipoLiquidacionDiaria", IDTipoLiquidacionDiaria, OracleClient.OracleType.Int32)
            'db.AsignarParametro("Nro_Guia", Nro_Guia, OracleClient.OracleType.NVarChar)
            db.AsignarParametro("ni_opcion", iOpcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Nro_Documento", Trim(Nro_Documento), OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Codigo_Peaje", Trim(Codigo_Peaje), OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Cuenta_Bancaria", Trim(Cuenta_Bancaria), OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_Monto", Monto, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_Nro_Bus", Trim(Nro_Bus), OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ID_Destino", ID_Destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ID_Piloto", ID_Piloto, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Depositante", Trim(Depositante), OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Contacto", Trim(Contacto), OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Observaciones", Trim(Observaciones), OracleClient.OracleType.VarChar)
            'db.AsignarParametro("vi_Fecha_Registro", Fecha_Registro, OracleClient.OracleType.VarChar)
            'db.AsignarParametro("ni_IDUsuario_Registro", IDUsuario_Registro, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_Fecha_Apertura", Trim(Fecha_Apertura), OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_IDUsuario_Sistema", IDUsuario_Sistema, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_unidad", unidad, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_negocio", negocio, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Excepcion(ds.Tables(0).Rows(0).Item(1))
                    flat = False
                Else
                    flat = True
                End If
            Else
                flat = True
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function

    Function ListaGastoLiquidacion(ByVal IDAgencia As Integer, ByVal Fecha_Apertura As String, ByVal IDLiquidacionOficina As Integer, ByVal Usuario As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_ListaGastoLiquidacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_agencia", IDAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Fecha_Apertura", Fecha_Apertura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Usuario", Usuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_IDLiquidacionOficina", IDLiquidacionOficina, OracleClient.OracleType.Int32)
            'hlamas 16-05-2017
            db.AsignarParametro("ni_version", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("Co_ListaGastosLiquidacion", OracleClient.OracleType.Cursor) '0            
            db.AsignarParametro("Co_ListaTotalGastos", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '2
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function AsociarOficina(ByVal Opcion As Integer, ByVal IDLiquidacionOficina As Integer, ByVal IDLiquiTurno As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_AsociarOficinaCounter", CommandType.StoredProcedure)
            db.AsignarParametro("ni_Opcion", Opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDLiquidacionOficina", IDLiquidacionOficina, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDLiquiTurnos", IDLiquiTurno, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '2
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function CierreLiquidacion(ByVal IDOficinaLiquidacion As Integer, ByVal total_efectivo As Double, ByVal total_pce As Double, ByVal total_tarjeta As Double, ByVal Usuario_Cierre As String) 'As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_CerrarLiquidacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDOficinaLiquidacion", IDOficinaLiquidacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_total_efectivo", total_efectivo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_total_pce", total_pce, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Usuario_Cierre", Usuario_Cierre, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_total_tarjeta", total_tarjeta, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '10
            db.Desconectar()
            Dim ds As DataTable = db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function DetalleLiquidacion(ByVal IDOficinaLiquidacion As String, ByVal IDUsuario As Integer, ByVal totalfacturas As Double, ByVal totalpcefacturas As Double, _
                                ByVal totalBoletas As Double, ByVal totalPceBoletas As Double, ByVal totalingreso As Double, ByVal totalegreso As Double) 'As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_GeneraDetalleLiquidacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDOficinaLiquidacion", IDOficinaLiquidacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_IDUsuario", IDUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_totalfacturas", totalfacturas, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_totalpcefacturas", totalpcefacturas, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_totalBoletas", totalBoletas, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_totalPceBoletas", totalPceBoletas, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_totalIngreso", totalingreso, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_totalEgreso", totalegreso, OracleClient.OracleType.Double)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '
            db.Desconectar()
            Dim ds As DataTable = db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function Transferencia_InsDel(ByVal Opcion As Integer, ByVal ID_Usuario As Integer, ByVal Fecha_Registro As String, ByVal IDAgencia As Integer, ByVal UsuarioCreacion As Integer, ByVal IP As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_InsDel_Transferencia", CommandType.StoredProcedure)
            db.AsignarParametro("ni_Opcion", Opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_Usuario", ID_Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Fecha_Registro", Fecha_Registro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ID_AGENCIA", IDAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_USUARIO_CREACION", UsuarioCreacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_IP_CREACION", IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function TransferenciaPase_Pasajes(ByVal iIDVENTA As Long, ByVal iIDCLASE As Long, ByVal iIDITINERARIO As Long, ByVal iIDCLIENTE As Long, ByVal iRUC As String, _
                                       ByVal iRAZON As String, ByVal iEMPRESA As Long, ByVal iTIPODOCEMPRESA As Integer, ByVal iIDPASAJERO As Long, _
                                       ByVal iAPEPATPAS As String, ByVal iAPEMATPAS As String, ByVal iNOMBREPAS As String, ByVal iNOMBRE1PAS As String, _
                                       ByVal iFECHANACIMIENTO As String, ByVal iDNI As String, ByVal iTIPODOCPASAJERO As Integer, ByVal iOFICINAVENTA As Long, _
                                       ByVal iIDRUTA As Long, ByVal iORIGEN As Long, ByVal iDESTINO As Long, ByVal iOFICINAEMBARQUE As Long, _
                                       ByVal iSERIE As String, ByVal iNUMERO As String, ByVal iSERIEREF As String, ByVal iNUMEROREF As String, _
                                       ByVal iNROCONTROL As String, ByVal iASIENTO As Integer, ByVal iFECHAPARTIDA As String, ByVal iHORAPARTIDA As String, _
                                       ByVal iFECHALLEGADA As String, ByVal iHORALLEGADA As String, ByVal iMONTOBASE As Double, ByVal iRECARGO As Double, _
                                       ByVal iDESCUENTO As Double, ByVal iACUENTA As Double, ByVal iPENALIDAD As Double, ByVal iCONCEPTOPENALIDAD As String, _
                                       ByVal iNETOPAGADO As Double, ByVal iTIPODEVOLUCION As Long, ByVal iIDFORMAPAGO As Long, ByVal iTIPOTARJETA As String, _
                                       ByVal iFECHAVENTA As String, ByVal iHORAVENTA As String, ByVal iIDUSUARIOSISTEMA As Long, ByVal iUSUARIOSISTEMA As String, _
                                       ByVal iAPEPATUSUARIO As String, ByVal iAPEMATUSUARIO As String, ByVal iNOMBREUSUARIO As String, ByVal iSEXOUSUARIO As String, _
                                       ByVal iTIPOTRANSACCION As String, ByVal iFLAGS As Long, ByVal iTIPOOPERACION As String, ByVal iCODIGOCUENTA As Long, _
                                       ByVal iIDTIPOCOMPROBANTE As Long, ByVal RUC_AGENCIA As String, ByVal EfectivoIngresado As Double) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_INS_PASE_PASAJES", CommandType.StoredProcedure)
            db.AsignarParametro("iIDVENTA", iIDVENTA, OracleClient.OracleType.Double)
            db.AsignarParametro("iIDCLASE", iIDCLASE, OracleClient.OracleType.Double)
            db.AsignarParametro("iIDITINERARIO", iIDITINERARIO, OracleClient.OracleType.Double)
            db.AsignarParametro("iIDCLIENTE", iIDCLIENTE, OracleClient.OracleType.Double)
            db.AsignarParametro("iRUC", iRUC, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iRAZON", iRAZON, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iEMPRESA", iEMPRESA, OracleClient.OracleType.Double)
            db.AsignarParametro("iTIPODOCEMPRESA", iTIPODOCEMPRESA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPASAJERO", iIDPASAJERO, OracleClient.OracleType.Double)
            db.AsignarParametro("iAPEPATPAS", iAPEPATPAS, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iAPEMATPAS", iAPEMATPAS, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNOMBREPAS", iNOMBREPAS, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNOMBRE1PAS", iNOMBRE1PAS, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iFECHANACIMIENTO", iFECHANACIMIENTO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDNI", iDNI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iTIPODOCPASAJERO", iTIPODOCPASAJERO, OracleClient.OracleType.Double)
            db.AsignarParametro("iOFICINAVENTA", iOFICINAVENTA, OracleClient.OracleType.Double)
            db.AsignarParametro("iIDRUTA", iIDRUTA, OracleClient.OracleType.Double)
            db.AsignarParametro("iORIGEN", iORIGEN, OracleClient.OracleType.Double)
            db.AsignarParametro("iDESTINO", iDESTINO, OracleClient.OracleType.Double)
            db.AsignarParametro("iOFICINAEMBARQUE", iOFICINAEMBARQUE, OracleClient.OracleType.Double)
            db.AsignarParametro("iSERIE", iSERIE, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNUMERO", iNUMERO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iSERIEREF", iSERIEREF, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNUMEROREF", iNUMEROREF, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNROCONTROL", iNROCONTROL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iASIENTO", iASIENTO, OracleClient.OracleType.Double)
            db.AsignarParametro("iFECHAPARTIDA", iFECHAPARTIDA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iHORAPARTIDA", iHORAPARTIDA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iFECHALLEGADA", iFECHALLEGADA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iHORALLEGADA", iHORALLEGADA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iMONTOBASE", iMONTOBASE, OracleClient.OracleType.Double)
            db.AsignarParametro("iRECARGO", iRECARGO, OracleClient.OracleType.Double)
            db.AsignarParametro("iDESCUENTO", iDESCUENTO, OracleClient.OracleType.Double)
            db.AsignarParametro("iACUENTA", iACUENTA, OracleClient.OracleType.Double)
            db.AsignarParametro("iPENALIDAD", iPENALIDAD, OracleClient.OracleType.Double)
            db.AsignarParametro("iCONCEPTOPENALIDAD", iCONCEPTOPENALIDAD, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNETOPAGADO", iNETOPAGADO, OracleClient.OracleType.Double)
            db.AsignarParametro("iTIPODEVOLUCION", iTIPODEVOLUCION, OracleClient.OracleType.Double)
            db.AsignarParametro("iIDFORMAPAGO", iIDFORMAPAGO, OracleClient.OracleType.Double)
            db.AsignarParametro("iTIPOTARJETA", iTIPOTARJETA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iFECHAVENTA", iFECHAVENTA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iHORAVENTA", iHORAVENTA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIOSISTEMA", iIDUSUARIOSISTEMA, OracleClient.OracleType.Double)
            db.AsignarParametro("iUSUARIOSISTEMA", iUSUARIOSISTEMA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iAPEPATUSUARIO", iAPEPATUSUARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iAPEMATUSUARIO", iAPEMATUSUARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNOMBREUSUARIO", iNOMBREUSUARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iSEXOUSUARIO", iSEXOUSUARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iTIPOTRANSACCION", iTIPOTRANSACCION, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iFLAGS", iFLAGS, OracleClient.OracleType.Double)
            db.AsignarParametro("iTIPOOPERACION", iTIPOOPERACION, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iCODIGOCUENTA", iCODIGOCUENTA, OracleClient.OracleType.Double)
            db.AsignarParametro("iIDTIPOCOMPROBANTE", iIDTIPOCOMPROBANTE, OracleClient.OracleType.Double)
            db.AsignarParametro("iRUC_AGENCIA", RUC_AGENCIA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iEfectivoIngresado", EfectivoIngresado, OracleClient.OracleType.Double)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function InsVtaPasaje(ByVal FECHAINICIO As String, ByVal FECHAFIN As String, ByVal UNIDAD_AGENCIA As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_INS_VTAPASAJE", CommandType.StoredProcedure)
            db.AsignarParametro("iFECHAINICIO", FECHAINICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iFECHAFIN", FECHAFIN, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iUNIDAD_AGENCIA", UNIDAD_AGENCIA, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR_DATOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function TransferenciaGastos_Pasajes(ByVal IDLiquidacionOficina As String, ByVal IDGastosLiquidacionPorTurno As Integer, ByVal IDTipoLiquidacionDiaria As Integer, _
                                      ByVal Nro_Documento As String, ByVal Codigo_Peaje As String, _
                                      ByVal Monto As Double, ByVal Nro_Bus As String, _
                                      ByVal Destino As String, ByVal Piloto As String, ByVal Depositante As String, _
                                      ByVal Contacto As String, ByVal Observaciones As String, _
                                      ByVal Fecha_Registro As String, ByVal Hora_Registro As String, _
                                      ByVal fecha_actualizacion As String, ByVal Hora_actualizacion As String, ByVal estado As String, _
                                      ByVal Fecha_Operacion As String, ByVal IDAGENCIA_UNIX As Integer, ByVal Login As String) As Boolean
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_TRANSFERENCIAGASTO_PASAJE_2", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDLiquidacionOficina", IDLiquidacionOficina, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDGastosLiquidacionPorTurno", IDGastosLiquidacionPorTurno, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDTipoLiquidacionDiaria", IDTipoLiquidacionDiaria, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Nro_Documento", Nro_Documento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Codigo_Peaje", Codigo_Peaje, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_Monto", Monto, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_Nro_Bus", Nro_Bus, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_Destino", Destino, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_Piloto", Piloto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Depositante", Depositante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Contacto", Contacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Observaciones", Observaciones, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Fecha_Registro", Fecha_Registro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Hora_Registro", Hora_Registro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha_actualizacion", fecha_actualizacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Hora_actualizacion", Hora_actualizacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Fecha_Operacion", Fecha_Operacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Login", Login, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Excepcion(ds.Tables(0).Rows(0).Item(1))
                    flat = False
                Else
                    flat = True
                End If
            Else
                flat = True
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function

    Function ListadoUsuario(ByVal FechaApertura As String, ByVal OficinaLiquidacion As String, ByVal IDAgencia As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_LISTADOUSUARIOS", CommandType.StoredProcedure)
            db.AsignarParametro("vi_FechaApertura", FechaApertura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_idOficinaLiquidacion", OficinaLiquidacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_IDAgencia", IDAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("CO_DATOS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function Detalle(ByVal FECHAINICIO As String, ByVal FECHAFIN As String, ByVal IdUsuario As String, ByVal OficinaLiquidacion As String, ByVal IDAgencia As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_Detalle", CommandType.StoredProcedure)
            db.AsignarParametro("iFECHAINICIO", FECHAINICIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iFECHAFIN", FECHAFIN, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iUsuario", IdUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_liquidacionOficina", OficinaLiquidacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Agencia", IDAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_VentaContado", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_Cortesia", OracleClient.OracleType.Cursor) '2
            db.AsignarParametro("co_prepagados", OracleClient.OracleType.Cursor) '3
            db.AsignarParametro("co_Creditos", OracleClient.OracleType.Cursor) '4
            db.AsignarParametro("co_Correlativo", OracleClient.OracleType.Cursor) '5
            db.AsignarParametro("co_CajaPrepagados", OracleClient.OracleType.Cursor) '6 
            db.AsignarParametro("co_Devolucion", OracleClient.OracleType.Cursor) '7
            db.AsignarParametro("co_EfectivoIngresado", OracleClient.OracleType.Cursor) '8
            db.AsignarParametro("co_Egresos", OracleClient.OracleType.Cursor) '8
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '8
            db.AsignarParametro("co_ventaSeguros", OracleClient.OracleType.Cursor) '8
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function DetalleVenta(ByVal Opcion As Integer, ByVal ID_Usuario As Integer, ByVal Fecha_Registro As String, ByVal IDAgencia As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 16-05-2017
            'db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_Monto", CommandType.StoredProcedure)
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_listar_Monto", CommandType.StoredProcedure)
            db.AsignarParametro("ni_Opcion", Opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_Usuario", ID_Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Fecha", Fecha_Registro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_Agencia", IDAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function OficinaXUsuariosPasajes(ByVal Opcion As Integer, ByVal IDOficinaLiquidacion As String, ByVal Login As String, ByVal MontoEfectivo As Double, ByVal EfectivoIngresado As Double, _
                                     ByVal Fecha_Apertura As String, ByVal CANTCONTADO As Integer, ByVal TOTVTACONTADO As Double, _
                                     ByVal CANTPREPA As Integer, ByVal TOTPREPA As Double, _
                                     ByVal CANTCRED As Integer, ByVal TOTCRED As Double, _
                                     ByVal CANTCORTE As Integer, ByVal TOTCORTE As Double, _
                                     ByVal CANTRECIBO As Integer, ByVal TOTRECIBO As Double, _
                                     ByVal CANTTC As Integer, ByVal TOTTC As Double, _
                                     ByVal CANTPEAJES As Integer, ByVal TOTPEAJES As Double, _
                                     ByVal CANTDEVPSJES As Integer, ByVal TOTDEVPSJES As Double, ByVal TOTGASTOS As Double, ByVal IDPasaje As Integer, _
                                     ByVal IDAGENCIA As Integer,
                                     ByVal IDLIQ_SISVYR As Long) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_OficinaXUsuariosPasajes2", CommandType.StoredProcedure)
            db.AsignarParametro("ni_Opcion", Opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDOficinaLiquidacion", IDOficinaLiquidacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Login", Login, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_MontoEfectivo", MontoEfectivo, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_EfectivoIngresado", EfectivoIngresado, OracleClient.OracleType.Double)
            db.AsignarParametro("vi_Fecha_Apertura", Fecha_Apertura, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_CANTCONTADO", CANTCONTADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_TOTVTACONTADO", TOTVTACONTADO, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_CANTPREPA", CANTPREPA, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_TOTPREPA", TOTPREPA, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_CANTCRED", CANTCRED, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_TOTCRED", TOTCRED, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_CANTCORTE", CANTCORTE, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_TOTCORTE", TOTCORTE, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_CANTRECIBO", CANTRECIBO, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_TOTRECIBO", TOTRECIBO, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_CANTTC", CANTTC, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_TOTTC", TOTTC, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_CANTPEAJES", CANTPEAJES, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_TOTPEAJES", TOTPEAJES, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_CANTDEVPSJES", CANTDEVPSJES, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_TOTDEVPSJES", TOTDEVPSJES, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_TOTGASTOS", TOTGASTOS, OracleClient.OracleType.Double) '
            db.AsignarParametro("ni_IDUSRPASAJE", IDPasaje, OracleClient.OracleType.Double)
            db.AsignarParametro("ni_IDAGENCIA", IDAGENCIA, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_IDLIQ_SISVYR", IDLIQ_SISVYR, OracleClient.OracleType.Double)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ListaCounterPsjesAsociadas(ByVal IDOficinaLiquidacion As String, ByVal FechaApertura As String, ByVal IDAgencia As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_ListaCounterPsjesAsociadas", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDOficinaLiquidacion", IDOficinaLiquidacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_FechaApertura", FechaApertura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_IDAgencia", IDAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function PrevistaReporte(ByVal Opcion As Integer, ByVal IDOficinaLiquidacion As String, ByVal Fecha As String, ByVal IDAGENCIA As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_PrevistaReporte", CommandType.StoredProcedure)
            db.AsignarParametro("ni_Opcion", Opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDOficinaLiquidacion", IDOficinaLiquidacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", Fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ID_AGENCIA", IDAGENCIA, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_Usuarios_Pasajes", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ActualizarEstadoPasaje(ByVal IDOficinaLiquidacion As String, ByVal FechaApertura As String, ByVal login As String)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_ActualizarEstadoPasaje", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDOficinaLiquidacion", IDOficinaLiquidacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_FechaApertura", FechaApertura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_login", login, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.EjecutarEscalar()
            db.Desconectar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ActualizarEstadoCarga(ByVal IDOficinaLiquidacion As String, ByVal FechaApertura As String, ByVal login As String)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_ActualizarEstadoCarga", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDOficinaLiquidacion", IDOficinaLiquidacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_FechaApertura", FechaApertura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_login", login, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.EjecutarEscalar()
            db.Desconectar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function Gastos(ByVal IDOficinaLiquidacion As String, ByVal Fecha As String, ByVal IDUsuario As Integer, ByVal IDLiquiTurno As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_GastosXCounter", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDOficinaLiquidacion", IDOficinaLiquidacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_Fecha", Fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_idUsuario", IDUsuario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_IDLiquiTurno", IDLiquiTurno, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function Concesionario(ByVal IDAgencias As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_CONCESIONARIOS", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ID_Agencia", IDAgencias, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_Datos", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '1
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ValidarCierreLiquidacion(ByVal IDOficinaLiquidacion As String, ByVal FechaApertura As String, ByVal IDAgencia As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_VERIFICAR_LIQUIDACION", CommandType.StoredProcedure)
            db.AsignarParametro("IdLiquidacionOficina", IDOficinaLiquidacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("Fecha_Liquidacion", FechaApertura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("IdAgencia", IDAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("Cur_Validar_Liquidacion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("Cur_Gastos_Liquidacion", OracleClient.OracleType.Cursor)
            db.AsignarParametro("Co_Error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Function ValidarCierreCajaCarga(ByVal FechaApertura As String, ByVal IDAgencia As Integer) As DataTable
    '    Try
    '        Dim db As New BaseDatos
    '        db.Conectar()
    '        db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_VERIFICAR_COUNTER_CARGA", CommandType.StoredProcedure)
    '        db.AsignarParametro("Id_Agencia", IDAgencia, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("Fecha_Liquidacion", FechaApertura, OracleClient.OracleType.VarChar)
    '        db.AsignarParametro("Cur_Counter_carga", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("Cur_Error", OracleClient.OracleType.Cursor)
    '        db.Desconectar()
    '        Dim dt As DataTable = db.EjecutarDataTable
    '        Return dt
    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    End Try
    'End Function

    Function ValidarCierreCajaCarga(ByVal FechaApertura As String, ByVal IDAgencia As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_VERIFICAR_COUNTER_CARGA", CommandType.StoredProcedure)
            db.AsignarParametro("Id_Agencia", IDAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("Fecha_Liquidacion", FechaApertura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("Cur_Counter_carga", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_comprobante", OracleClient.OracleType.Cursor)
            db.AsignarParametro("Cur_Error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function TotalLiquidacion(ByVal ID_Usuario As Integer, ByVal Fecha_Registro As String, ByVal IDAgencia As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_total_liquidacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_Usuario", ID_Usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_Fecha", Fecha_Registro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_Agencia", IDAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor) '0
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Sub AbrirLiquidacion(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String)
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_AbrirLiquidacion", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Excepcion(ds.Tables(0).Rows(0).Item(1))
                End If
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

    Public Sub AbrirLiquidacionPasaje(ByVal id As Integer, ByVal fecha As String, ByVal agencia As Integer)
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_AbrirLiquidacionPasaje", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Excepcion(ds.Tables(0).Rows(0).Item(1))
                End If
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub


    Public Sub AbrirLiquidacionOficina(ByVal id As Integer, ByVal usuario As Integer, ByVal ip As String, ByVal fecha As String, ByVal rol As Integer)
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_AbrirLiquidacionOficina", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Excepcion(ds.Tables(0).Rows(0).Item(1))
                End If
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

    Function EstadoLiquidacionOficina(ByVal fecha As String, ByVal agencia As Integer) As Integer
        Dim flag As String = "..."
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_LIQUIDACION_OFICINAS.sf_get_estado_liquidacion('" & fecha & "'," & agencia & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            flag = db_bd.EjecutarEscalar()
            db_bd.Desconectar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function

    Function ListarMovimiento(ByVal inicio As String, ByVal fin As String, ByVal agencia As Integer, ByVal usuario As Integer) As DataTable
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_listar_movimiento", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Excepcion(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ListarMovimiento(ByVal id As Integer) As DataTable
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_listar_movimiento", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Excepcion(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Sub AnularMovimiento(ByVal id As Integer)
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_anular_movimiento", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Excepcion(ds.Tables(0).Rows(0).Item(1))
                End If
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

    Function TotalMovimiento(ByVal fecha As String, ByVal agencia As Integer, ByVal usuario As Integer) As DataTable
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_total_movimiento", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Excepcion(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function PrevistaReporteUsuario(ByVal Opcion As Integer, ByVal IDOficinaLiquidacion As String, ByVal Fecha As String, ByVal IDAGENCIA As Integer, ByVal usuario As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.SP_PrevistaReporteUsuario", CommandType.StoredProcedure)
            db.AsignarParametro("ni_Opcion", Opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDOficinaLiquidacion", IDOficinaLiquidacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_fecha", Fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_ID_AGENCIA", IDAGENCIA, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_Usuarios_Pasajes", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Return ds
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function ListarUsuarioLiquidacion(ByVal fecha As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_listar_usuario_liquidacion", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Sub GrabarOficinaValor(ByVal fecha As String, ByVal agencia As Integer, ByVal usuario As Integer, ByVal monto As Double, _
                                ByVal oficina As Integer, ByVal usuario_registro As Integer, ByVal ip As String)
        Dim flat As Boolean = False
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_grabar_oficina_valor", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_monto", monto, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_oficina", oficina, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario_registro", usuario_registro, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Excepcion(ds.Tables(0).Rows(0).Item(1))
                End If
            End If

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub

    Function ListarCaja(ByVal fecha As String, ByVal agencia As Integer, ByVal opcion As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_LIQUIDACION_OFICINAS.sp_listar_caja", CommandType.StoredProcedure)
            db.AsignarParametro("vi_fecha", fecha, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_agencia", agencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor) '1
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor) '2
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class
