Imports AccesoDatos
Public Class dtoVentaGiroContado
#Region "VARIBLES"

    Public v_nro_solicitud_giros As String
    Public v_DNI_RESPONSABLE As String
    Public v_NOMBRE_RESPONSABLE As String


    Public v_pregunta_giro As String
    Public v_respuesta_giro As String
    Public v_respuesta_entre_giro As String


    Public v_IDTIPO_TARIFAS_GIROS As String
    Public V_PASSWORD_GIRO As String
    Public V_FECHA_ENTREGA As String
    Public V_HORA_ENTREGA As String
    Public V_OBS As String
    Public V_NOMBRE_ENTREGA As String
    Public V_DOC_ENTREGA As String
    Public iCONTROL As Integer
    Public v_IDFACTURA As Integer
    Public v_IDTIPO_COMPROBANTE As Integer
    Public v_SERIE_FACTURA As String
    Public v_NRO_FACTURA As String
    Public v_FECHA_FACTURA As String
    Public v_IDTIPO_PAGO As Integer
    Public v_IDFORMA_PAGO As Integer
    Public v_IDTARJETAS As Integer
    Public v_NROTARJETA As String
    Public v_IDUNIDAD_ORIGEN As Integer
    Public v_IDAGENCIAS As Integer
    Public v_IDUNIDAD_DESTINO As Integer
    Public v_IDAGENCIAS_DESTINO As Integer
    Public v_IDPERSONA As Integer
    Public v_NOMBRES_RASONSOCIAL As String
    Public v_NRO_DNI_RUC As String
    Public v_IDPERSONA_ORIGEN As Integer
    Public v_NOMBRES_REMITENTE As String
    Public v_NRO_DOC_REMITENTE As String
    Public v_IDDIREECION_ORIGEN As Integer
    Public v_DIRECCION_REMITENTE As String
    Public v_TELEFONO_REMITENTE As String
    Public v_IDCONTACTO_DESTINO As Integer
    Public v_NRO_DOC_DESTINATARIO As String
    Public v_NOMBRES_DESTINATARIO As String
    Public v_DIRECCION_DESTINATARIO As String
    Public v_IDDIREECION_DESTINO As Integer
    Public v_TELEFONO_DESTINATARIO As String
    Public v_MEMO As String
    Public v_MONTO_DESCUENTO As Double
    Public v_CANTIDAD_X_PESO As Integer
    Public v_CANTIDAD_X_VOLUMEN As Integer
    Public v_CANTIDAD_X_SOBRE As Integer

    Public v_MONTO_BASE As Double
    Public v_PRECIO_X_PESO As Double
    Public v_PRECIO_X_VOLUMEN As Double
    Public v_PRECIO_X_SOBRE As Double

    Public v_TOTAL_PESO As Double
    Public v_TOTAL_VOLUMEN As Double

    Public v_MONTO_SUB_TOTAL As Double
    Public v_MONTO_IMPUESTO As Double
    Public v_TOTAL_COSTO As Double
    Public v_IDTIPO_MONEDA As Integer
    Public v_IDUSUARIO_PERSONAL As Integer
    Public v_IP As String

    Public v_IDROL_USUARIO As Integer

    Public v_MONTO_PENALIDAD As Double
    Public v_IDFUNCIONARIO_AUTORIZACION As Integer

    Public v_IGV As Double
    Public v_PORCENT_DEVOLUCION As Double
    Public v_PORCENT_DESCUENTO As Double
    Public v_MONTO_RECARGO As Double
    Public v_IDTIPO_ENTREGA As Integer
    Public v_CANTIDAD_ETIQUETAS As Integer = 0
    'Public Cur_CODIGOBARRAS As New ADODB.Recordset
    Public Cur_CODIGOBARRAS As New DataTable
    '
    'Public Cur_DATOS_VENTA As New ADODB.Recordset
    Public Cur_DATOS_VENTA_dt As DataTable

    '------Datos de Reporte
    Public v_UNIDAD_ORIGEN As String
    Public v_UNIDAD_DESTINO As String

    Public v_CONTROL_ANUDEV As String = 0


    Public v_IDTIPO_GIRO As String
    Public v_IDDESCUENTO_GIRO As String
    Public v_IDCONDI_GIRO As String
    Public v_MONTO_GIRADO As Double
    Public v_TELE_DESTI As String

#End Region
#Region "CONTROL ACCESOS"

    'Public cur_persona As New ADODB.Recordset
    'Public cur_cont_origen As New ADODB.Recordset
    'Public cur_cont_destino As New ADODB.Recordset
    'Public cur_dire_origen As New ADODB.Recordset
    'Public cur_dire_destino As New ADODB.Recordset

    Public cur_persona_dt As DataTable
    Public cur_cont_origen_dt As DataTable
    Public cur_cont_destino_dt As DataTable
    Public cur_dire_origen_dt As DataTable
    Public cur_dire_destino_dt As DataTable

    'Public cur_datos_eliminacion As New ADODB.Recordset
    Public cur_datos_eliminacion_dt As DataTable
#End Region
#Region "VALORES NUMERICOS"
    Public Serie As String = ""
    Public NroDoc As String = ""
#End Region
#Region "FUNCIONES"
    Public cur_t_tipo_comprobante As New ADODB.Recordset
    Public cur_t_tipo_comprobante_dt As DataTable

    Public cur_UNIDAD_AGENCIAS As New ADODB.Recordset
    Public cur_UNIDAD_AGENCIAS_dt As DataTable

    Public cur_t_Tipo_Entrega As New ADODB.Recordset
    Public cur_t_Tipo_Entrega_dt As DataTable

    Public cur_t_Forma_Pago As New ADODB.Recordset
    Public cur_t_Forma_Pago_dt As DataTable

    Public cur_T_TARJETAS As New ADODB.Recordset
    Public cur_T_TARJETAS_dt As DataTable

    Public cur_Tipo_Pago As New ADODB.Recordset
    Public cur_Tipo_Pago_dt As DataTable

    Public cur_Tipo_Pago_sin_cortesia As New ADODB.Recordset
    Public cur_Tipo_Pago_sin_cortesia_dt As DataTable

    Public cur_AgenciasVenta As New ADODB.Recordset

    Public coll_t_tipo_comprobante As New Collection
    Public coll_UNIDAD_AGENCIAS As New Collection
    Public coll_t_Tipo_Entrega As New Collection
    Public coll_t_Forma_Pago As New Collection
    Public coll_T_TARJETAS As New Collection
    Public coll_Tipo_Pago As New Collection
    Public coll_AgenciasVenta As New Collection

    Public rstVarAgencias As New ADODB.Recordset
    Public rstVarAgencias_dt As DataTable

    Public rstVarGrabarEditar As New ADODB.Recordset

    'Public rstEstadoReg As New ADODB.Recordset
    Public rstEstadoReg As DataTable
#End Region
    'Public Function Grabar2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        iCONTROL = 1
    '        v_IDFACTURA = 0
    '        v_IDTIPO_MONEDA = 1
    '        v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
    '        v_IP = dtoUSUARIOS.IP
    '        v_IDROL_USUARIO = dtoUSUARIOS.IdRol
    '        v_MONTO_PENALIDAD = 0
    '        v_IDFUNCIONARIO_AUTORIZACION = 0
    '        v_MONTO_RECARGO = 0

    '        Dim SQLQUERY As Object() = {"PKG_IVOVENTACARGA.SP_VENTA_CONTADO_CARGA", 110, iCONTROL, 1, v_IDFACTURA, 1, v_IDTIPO_COMPROBANTE, 1, v_SERIE_FACTURA, 2, _
    '        v_NRO_FACTURA, 2, v_FECHA_FACTURA, 2, v_IDTIPO_PAGO, 1, v_IDFORMA_PAGO, 1, v_IDTARJETAS, 1, _
    '        v_NROTARJETA, 2, v_IDUNIDAD_ORIGEN, 1, v_IDAGENCIAS, 1, v_IDUNIDAD_DESTINO, 1, v_IDAGENCIAS_DESTINO, 1, v_IDPERSONA, 1, v_NOMBRES_RASONSOCIAL, 2, _
    '        v_NRO_DNI_RUC, 2, v_IDPERSONA_ORIGEN, 1, v_NOMBRES_REMITENTE, 2, v_NRO_DOC_REMITENTE, 2, v_IDDIREECION_ORIGEN, 1, _
    '        v_DIRECCION_REMITENTE, 2, v_TELEFONO_REMITENTE, 2, v_IDCONTACTO_DESTINO, 1, _
    '        v_NRO_DOC_DESTINATARIO, 2, v_NOMBRES_DESTINATARIO, 2, _
    '        v_DIRECCION_DESTINATARIO, 2, v_IDDIREECION_DESTINO, 1, v_TELEFONO_DESTINATARIO, 2, v_MEMO, 2, v_MONTO_DESCUENTO, 3, _
    '        v_CANTIDAD_X_PESO, 1, v_CANTIDAD_X_VOLUMEN, 1, v_CANTIDAD_X_SOBRE, 1, v_PRECIO_X_PESO, 3, v_PRECIO_X_VOLUMEN, 3, v_PRECIO_X_SOBRE, 3, v_TOTAL_PESO, 3, _
    '        v_TOTAL_VOLUMEN, 3, v_MONTO_SUB_TOTAL, 3, v_MONTO_IMPUESTO, 3, v_TOTAL_COSTO, 3, v_IDTIPO_MONEDA, 1, v_IDUSUARIO_PERSONAL, 1, v_IP, 2, v_IDROL_USUARIO, 1, _
    '        v_MONTO_PENALIDAD, 3, v_IDFUNCIONARIO_AUTORIZACION, 1, v_IGV, 3, v_PORCENT_DEVOLUCION, 3, v_PORCENT_DESCUENTO, 3, v_MONTO_RECARGO, 3, v_MONTO_BASE, 3, v_IDTIPO_ENTREGA, 1}

    '        rstVarGrabarEditar = Nothing
    '        rstVarGrabarEditar = VOCONTROLUSUARIO.fnSQLQuery(SQLQUERY)

    '        v_CANTIDAD_ETIQUETAS = 0
    '        If rstVarGrabarEditar.State = 1 Then
    '            If rstVarGrabarEditar.BOF = False And rstVarGrabarEditar.EOF = False Then
    '                Cur_CODIGOBARRAS = rstVarGrabarEditar.NextRecordset
    '                v_IDFACTURA = rstVarGrabarEditar.Fields.Item(0).Value
    '                v_CANTIDAD_ETIQUETAS = rstVarGrabarEditar.Fields.Item(2).Value
    '                MsgBox(rstVarGrabarEditar.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '                If v_IDFACTURA = 0 Then
    '                    flag = False
    '                Else
    '                    flag = True
    '                End If

    '            End If
    '        Else
    '            MsgBox("Vefique sus datos...No ha Grabado", MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    'Dim cur_cierre As New ADODB.Recordset
    'Public Function fnValidarCierre2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOCARGA.SP_CONTROL_APERTURA_TURNO", 4, dtoUSUARIOS.IdLogin, 1}
    '        cur_cierre = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If cur_cierre.EOF = False And cur_cierre.BOF = False Then
    '            Dim var1 As Integer = cur_cierre.Fields.Item("cierre_Anterior").Value
    '            Dim var2 As Integer = cur_cierre.Fields.Item("cierre_Actual").Value
    '            If var1 = 0 Then
    '                MsgBox("NO HA CERRADO LA CAJA DEL DIA ANTERIOR...", MsgBoxStyle.Information, "")
    '                flag = False
    '            End If
    '            If var2 = 0 Then
    '                MsgBox("NO TIENE APERTURADO UNA CAJA PARA HOY..., REVICE SU CIERRES..", MsgBoxStyle.Information, "")
    '                flag = False
    '            End If
    '        Else
    '            flag = False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flag
    'End Function
    ' Dim rstNroDocumentos As New ADODB.Recordset
    'Public Function fnTarjetas() As ADODB.Recordset
    '    Dim SQLQuery As Object() = {"select t_Tarjetas.Idtarjetas,t_Tarjetas.Descripcion from t_Tarjetas where t_Tarjetas.Idestado_Registro=1 order by t_Tarjetas.Descripcion  asc", 2}
    '    Try
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    'End Function
    'Public Function fnTipoMonedas() As ADODB.Recordset
    '    Dim SQLQuery As Object() = {"select t_Tipo_Moneda.Idtipo_Moneda,t_Tipo_Moneda.Simbolo_Moneda from t_Tipo_Moneda  order by t_Tipo_Moneda.Simbolo_Moneda  asc", 2}
    '    Try
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    'End Function
    Public Function fnClearOBJ() As Boolean
        Try
            v_SERIE_FACTURA = ""
            v_NRO_FACTURA = ""
            v_UNIDAD_ORIGEN = ""
            v_UNIDAD_DESTINO = ""
            v_IDTIPO_ENTREGA = 0
            v_IDFORMA_PAGO = 0
            v_IDUNIDAD_DESTINO = 0
            v_IDAGENCIAS_DESTINO = 0
            v_FECHA_FACTURA = dtoUSUARIOS.m_sFecha
            v_IDTIPO_PAGO = 0
            v_IDTARJETAS = 0
            v_NROTARJETA = ""
            v_NRO_DNI_RUC = ""
            v_NOMBRES_RASONSOCIAL = ""

            v_DIRECCION_REMITENTE = ""
            v_DIRECCION_DESTINATARIO = ""
            v_TELEFONO_REMITENTE = ""
            v_PORCENT_DESCUENTO = 0
            v_MEMO = ""
            v_NOMBRES_REMITENTE = ""
            v_NRO_DOC_REMITENTE = ""
            v_NOMBRES_DESTINATARIO = ""
            v_NRO_DOC_DESTINATARIO = ""
            v_TOTAL_PESO = 0
            v_TOTAL_VOLUMEN = 0
            v_CANTIDAD_X_PESO = 0
            v_CANTIDAD_X_VOLUMEN = 0
            v_CANTIDAD_X_SOBRE = 0
            v_PRECIO_X_PESO = 0
            v_PRECIO_X_VOLUMEN = 0
            v_PRECIO_X_SOBRE = 0
            v_MONTO_BASE = 0
            v_MONTO_SUB_TOTAL = 0
            v_MONTO_IMPUESTO = 0
            v_TOTAL_COSTO = 0
            v_IDTIPO_COMPROBANTE = 0
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function
    'Dim rstControlProceso As New ADODB.Recordset

    'Public Function fnVERDATA_RGT_2009(ByVal x_IDFACTURA As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_VER_VENTACONTADO_III_RGT", 4, Str(x_IDFACTURA), 2}
    '        Cur_DATOS_VENTA = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If Cur_DATOS_VENTA.State = 1 Then
    '            If Cur_DATOS_VENTA.EOF = False And Cur_DATOS_VENTA.BOF = False Then
    '                flag = True

    '                v_IDTIPO_GIRO = Cur_DATOS_VENTA.Fields.Item("idtipo_giro").Value
    '                'If IsNothing(Cur_DATOS_VENTA.Fields.Item("iddescuento_giro").Value) Then v_IDDESCUENTO_GIRO = Cur_DATOS_VENTA.Fields.Item("iddescuento_giro").Value Else v_IDDESCUENTO_GIRO = ""
    '                v_IDCONDI_GIRO = Cur_DATOS_VENTA.Fields.Item("idcondi_giro").Value
    '                v_MONTO_GIRADO = Cur_DATOS_VENTA.Fields.Item("monto_girado").Value
    '                If IsDBNull(Cur_DATOS_VENTA.Fields.Item("tele_desti").Value) = False Then
    '                    v_TELE_DESTI = Cur_DATOS_VENTA.Fields.Item("tele_desti").Value
    '                Else
    '                    v_TELE_DESTI = ""
    '                End If
    '                v_MONTO_DESCUENTO = Cur_DATOS_VENTA.Fields.Item("monto_descuento").Value
    '                v_SERIE_FACTURA = Cur_DATOS_VENTA.Fields.Item("Serie_Factura").Value
    '                v_NRO_FACTURA = Cur_DATOS_VENTA.Fields.Item("Nro_Factura").Value
    '                v_UNIDAD_ORIGEN = Cur_DATOS_VENTA.Fields.Item("origen").Value
    '                v_IDUNIDAD_DESTINO = Cur_DATOS_VENTA.Fields.Item("iddestino").Value
    '                v_IDAGENCIAS_DESTINO = Cur_DATOS_VENTA.Fields.Item("Idagencias_Destino").Value '
    '                v_UNIDAD_DESTINO = Cur_DATOS_VENTA.Fields.Item("destino").Value
    '                v_IDTIPO_ENTREGA = Cur_DATOS_VENTA.Fields.Item("Idtipo_Entrega").Value
    '                v_IDFORMA_PAGO = Cur_DATOS_VENTA.Fields.Item("Idforma_Pago").Value
    '                v_IDAGENCIAS_DESTINO = Cur_DATOS_VENTA.Fields.Item("Idagencias_Destino").Value
    '                v_FECHA_FACTURA = Cur_DATOS_VENTA.Fields.Item("FECHA_FACTURA").Value

    '                v_IDTIPO_PAGO = Cur_DATOS_VENTA.Fields.Item("Idtipo_Pago").Value

    '                v_IDTARJETAS = Cur_DATOS_VENTA.Fields.Item("Idtarjetas").Value
    '                v_IDTIPO_COMPROBANTE = Cur_DATOS_VENTA.Fields.Item("Idtipo_Comprobante").Value

    '                v_NROTARJETA = Cur_DATOS_VENTA.Fields.Item("NROTARJETA").Value
    '                v_NRO_DNI_RUC = Cur_DATOS_VENTA.Fields.Item("Nu_Docu_Suna").Value
    '                v_NOMBRES_RASONSOCIAL = Cur_DATOS_VENTA.Fields.Item("Razon_Social").Value

    '                v_DIRECCION_REMITENTE = Cur_DATOS_VENTA.Fields.Item("DirOrigen").Value
    '                v_DIRECCION_DESTINATARIO = Cur_DATOS_VENTA.Fields.Item("DirDestino").Value
    '                v_TELEFONO_REMITENTE = IIf(Cur_DATOS_VENTA.Fields.Item("telefono").Value = " ", "", Cur_DATOS_VENTA.Fields.Item("telefono").Value)
    '                v_PORCENT_DESCUENTO = Cur_DATOS_VENTA.Fields.Item("Porcent_Descuento").Value
    '                v_MEMO = Cur_DATOS_VENTA.Fields.Item("Memo").Value
    '                v_NOMBRES_REMITENTE = Cur_DATOS_VENTA.Fields.Item("remitente").Value
    '                v_NRO_DOC_REMITENTE = Cur_DATOS_VENTA.Fields.Item("dniremitente").Value
    '                v_NOMBRES_DESTINATARIO = Cur_DATOS_VENTA.Fields.Item("Destinatario").Value
    '                v_NRO_DOC_DESTINATARIO = Cur_DATOS_VENTA.Fields.Item("dniDestinatario").Value
    '                v_TOTAL_PESO = Cur_DATOS_VENTA.Fields.Item("Total_Peso").Value
    '                v_TOTAL_VOLUMEN = Cur_DATOS_VENTA.Fields.Item("Total_Volumen").Value
    '                v_CANTIDAD_X_PESO = Cur_DATOS_VENTA.Fields.Item("Cantidad_x_Peso").Value
    '                v_CANTIDAD_X_VOLUMEN = Cur_DATOS_VENTA.Fields.Item("Cantidad_x_Volumen").Value
    '                v_CANTIDAD_X_SOBRE = Cur_DATOS_VENTA.Fields.Item("Cantidad_x_Sobre").Value
    '                v_PRECIO_X_PESO = Cur_DATOS_VENTA.Fields.Item("Precio_x_Peso").Value
    '                v_PRECIO_X_VOLUMEN = Cur_DATOS_VENTA.Fields.Item("Precio_x_Volumen").Value
    '                v_PRECIO_X_SOBRE = Cur_DATOS_VENTA.Fields.Item("Precio_x_Sobre").Value
    '                v_MONTO_BASE = Cur_DATOS_VENTA.Fields.Item("Monto_Base").Value
    '                v_MONTO_SUB_TOTAL = Cur_DATOS_VENTA.Fields.Item("Monto_Sub_Total").Value
    '                v_MONTO_IMPUESTO = Cur_DATOS_VENTA.Fields.Item("MONTO_IMPUESTO").Value
    '                v_TOTAL_COSTO = Cur_DATOS_VENTA.Fields.Item("Total_Costo").Value

    '                v_IDTIPO_TARIFAS_GIROS = Cur_DATOS_VENTA.Fields.Item("IDTIPO_TARIFAS_GIROS").Value


    '                If Not Cur_DATOS_VENTA.Fields.Item("NOMBRE_ENTREGA").Value Is DBNull.Value Then
    '                    V_NOMBRE_ENTREGA = Cur_DATOS_VENTA.Fields.Item("NOMBRE_ENTREGA").Value
    '                Else
    '                    V_NOMBRE_ENTREGA = ""
    '                End If
    '                If Not Cur_DATOS_VENTA.Fields.Item("DOC_ENTREGA").Value Is DBNull.Value Then
    '                    V_DOC_ENTREGA = Cur_DATOS_VENTA.Fields.Item("DOC_ENTREGA").Value
    '                Else
    '                    V_DOC_ENTREGA = ""
    '                End If
    '                If Not Cur_DATOS_VENTA.Fields.Item("HORA_ENTREGA").Value Is DBNull.Value Then
    '                    V_HORA_ENTREGA = Cur_DATOS_VENTA.Fields.Item("HORA_ENTREGA").Value
    '                Else
    '                    V_HORA_ENTREGA = ""
    '                End If
    '                If Not Cur_DATOS_VENTA.Fields.Item("OBS").Value Is DBNull.Value Then
    '                    V_OBS = Cur_DATOS_VENTA.Fields.Item("OBS").Value
    '                Else
    '                    V_OBS = ""
    '                End If
    '                If Not Cur_DATOS_VENTA.Fields.Item("FECHA_ENTREGA").Value Is DBNull.Value Then
    '                    V_FECHA_ENTREGA = Cur_DATOS_VENTA.Fields.Item("FECHA_ENTREGA").Value
    '                Else
    '                    V_FECHA_ENTREGA = ""
    '                End If
    '                If Not Cur_DATOS_VENTA.Fields.Item("PASSWORD_GIRO").Value Is DBNull.Value Then
    '                    V_PASSWORD_GIRO = Cur_DATOS_VENTA.Fields.Item("PASSWORD_GIRO").Value
    '                Else
    '                    V_PASSWORD_GIRO = ""
    '                End If

    '                If Not Cur_DATOS_VENTA.Fields.Item("pregunta_giro").Value Is DBNull.Value Then
    '                    v_pregunta_giro = Cur_DATOS_VENTA.Fields.Item("pregunta_giro").Value
    '                Else
    '                    v_pregunta_giro = ""
    '                End If

    '                If Not Cur_DATOS_VENTA.Fields.Item("respuesta_giro").Value Is DBNull.Value Then
    '                    v_respuesta_giro = Cur_DATOS_VENTA.Fields.Item("respuesta_giro").Value
    '                Else
    '                    v_respuesta_giro = ""
    '                End If

    '                If Not Cur_DATOS_VENTA.Fields.Item("respuesta_entre_giro").Value Is DBNull.Value Then
    '                    v_respuesta_entre_giro = Cur_DATOS_VENTA.Fields.Item("respuesta_entre_giro").Value
    '                Else
    '                    v_respuesta_entre_giro = ""
    '                End If


    '                If Not Cur_DATOS_VENTA.Fields.Item("nro_solicitud_giros").Value Is DBNull.Value Then
    '                    v_nro_solicitud_giros = Cur_DATOS_VENTA.Fields.Item("nro_solicitud_giros").Value
    '                Else
    '                    v_nro_solicitud_giros = ""
    '                End If

    '                If Not Cur_DATOS_VENTA.Fields.Item("DNI_RESPONSABLE").Value Is DBNull.Value Then
    '                    v_DNI_RESPONSABLE = Cur_DATOS_VENTA.Fields.Item("DNI_RESPONSABLE").Value
    '                Else
    '                    v_DNI_RESPONSABLE = ""
    '                End If

    '                If Not Cur_DATOS_VENTA.Fields.Item("NOMBRE_RESPONSABLE").Value Is DBNull.Value Then
    '                    v_NOMBRE_RESPONSABLE = Cur_DATOS_VENTA.Fields.Item("NOMBRE_RESPONSABLE").Value
    '                Else
    '                    v_NOMBRE_RESPONSABLE = ""
    '                End If



    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    'Public Function fnANULDEVVENAS_II(ByVal cnn As OracleClient.OracleConnection, ByVal iControlANUDEV As Integer, ByVal x_IDFACTURA As Integer, ByVal x_PORCENT_DEVOLUCION As Double) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_ANUL_DEVO_VENTA_II", 14, iControlANUDEV, 1, Str(x_IDFACTURA.ToString), 2, x_PORCENT_DEVOLUCION, 3, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IP, 2}
    '        rstNroDocumentos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        objLOG.fnLog("[dtoVentaCargaContado.fnANULDEVVENAS] " & fnLoagObj(SQLQuery))
    '        If rstNroDocumentos.State = 1 Then
    '            If rstNroDocumentos.EOF = False And rstNroDocumentos.BOF = False Then
    '                MsgBox(rstNroDocumentos.Fields.Item(0).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '                v_CONTROL_ANUDEV = rstNroDocumentos.Fields.Item(1).Value
    '                flag = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try

    '    'Try
    '    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    '    cmd.Connection = cnn
    '    '    cmd.CommandType = CommandType.StoredProcedure

    '    '    cmd.CommandText = "PKG_IVOVENTACARGA.SP_ANUL_DEVO_VENTA_II"
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("icontrol", OracleClient.OracleType.Number)).Value = iControlANUDEV
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("x_idfactura", OracleClient.OracleType.VarChar)).Value = x_IDFACTURA
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("v_porcent_devolucion", OracleClient.OracleType.Number)).Value = x_PORCENT_DEVOLUCION
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("v_idusuario_personal", OracleClient.OracleType.VarChar, 10)).Value = dtoUSUARIOS.IdLogin
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("v_idrol_usuario", OracleClient.OracleType.Number)).Value = dtoUSUARIOS.IdRol
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("v_ip", OracleClient.OracleType.VarChar)).Value = dtoUSUARIOS.IP
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_controldatos", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    '    cmd.Parameters.Add(New OracleClient.OracleParameter("cur_err", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output




    '    '    cmd.ExecuteNonQuery()



    '    'Catch Ex As System.Exception
    '    '    MsgBox(Ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

    '    'Catch OEx As System.Data.OracleClient.OracleException
    '    '    MsgBox(OEx.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    'End Try
    '    Return flag
    'End Function

    'Public Function fnLoadVentaCarga2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_INICIAR_VENTA_CONT_GIRO", 2}
    '        cur_t_tipo_comprobante = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        cur_UNIDAD_AGENCIAS = cur_t_tipo_comprobante.NextRecordset
    '        cur_t_Tipo_Entrega = cur_t_tipo_comprobante.NextRecordset
    '        cur_t_Forma_Pago = cur_t_tipo_comprobante.NextRecordset
    '        cur_T_TARJETAS = cur_t_tipo_comprobante.NextRecordset
    '        cur_Tipo_Pago = cur_t_tipo_comprobante.NextRecordset
    '        cur_Tipo_Pago_sin_cortesia = cur_t_tipo_comprobante.NextRecordset

    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Public Function fnLoadVentaCarga() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTACARGA.SP_INICIAR_VENTA_CONT_GIRO", CommandType.StoredProcedure)
            db.AsignarParametro("cur_t_tipo_comprobante", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_UNIDAD_AGENCIAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_t_Tipo_Entrega", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_t_Forma_Pago", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_T_TARJETAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Tipo_Pago", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Tipo_Pago_corte", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_t_tipo_comprobante_dt = ds.Tables(0)
            cur_UNIDAD_AGENCIAS_dt = ds.Tables(1)
            cur_t_Tipo_Entrega_dt = ds.Tables(2)
            cur_t_Forma_Pago_dt = ds.Tables(3)
            cur_T_TARJETAS_dt = ds.Tables(4)
            cur_Tipo_Pago_dt = ds.Tables(5)
            cur_Tipo_Pago_sin_cortesia_dt = ds.Tables(6)
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fnListarEstadoFactura2009() As ADODB.Recordset
        'Try
        '    Dim SQLQuery As Object() = {"select t_Estado_Registro.Idestado_Registro,t_Estado_Registro.Estado_Registro from t_Estado_Registro  where t_Estado_Registro.Idestado_Registro in (2,27,29) union all select 999 Idestado_Registro, '-TODOS-' Estado_Registro from dual  order by Estado_Registro asc", 2}
        '    rstEstadoReg = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        'Return rstEstadoReg
    End Function

    Public Function fnListarEstadoFactura() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("select t_Estado_Registro.Idestado_Registro,t_Estado_Registro.Estado_Registro from t_Estado_Registro  where t_Estado_Registro.Idestado_Registro in (2,27,29) union all select 999 Idestado_Registro, '-TODOS-' Estado_Registro from dual  order by Estado_Registro asc", CommandType.Text)
            db.Desconectar()
            rstEstadoReg = db.EjecutarDataTable
            Return rstEstadoReg
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnGetAgencias(ByVal idUnidadAge As Integer) As ADODB.Recordset
    '    Try
    '        Dim SQLQUERY As Object() = {"PKG_IVOVENTACARGA.SP_LIST_AGENCIAS_UNIDAD", 4, idUnidadAge, 1}
    '        rstVarAgencias = VOCONTROLUSUARIO.fnSQLQuery(SQLQUERY)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return rstVarAgencias
    'End Function

    Public Function fnGetAgencias_dt(ByVal idUnidadAge As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTACARGA.SP_LIST_AGENCIAS_UNIDAD", CommandType.StoredProcedure)
            db.AsignarParametro("v_idUnidadAgencia", idUnidadAge, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_datos_Agencias", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rstVarAgencias_dt = db.EjecutarDataTable
            Return rstVarAgencias_dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnNroDocuemnto(ByVal idDocumento As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"select t_Control_Comprobantes.Serie,t_Control_Comprobantes.Nro_Documento from  t_Control_Comprobantes where t_Control_Comprobantes.Ip='" & dtoUSUARIOS.IP & "' and t_Control_Comprobantes.Idtipo_Comprobante= " & idDocumento.ToString & "  and t_Control_Comprobantes.Idagencias=" & dtoUSUARIOS.m_iIdAgencia.ToString & " and t_Control_Comprobantes.Idestado_Registro=1", 2}
    '        rstNroDocumentos = Nothing
    '        rstNroDocumentos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If rstNroDocumentos.State = 1 Then
    '            If rstNroDocumentos.EOF = False And rstNroDocumentos.BOF = False Then
    '                Serie = rstNroDocumentos.Fields.Item(0).Value.ToString
    '                NroDoc = rstNroDocumentos.Fields.Item(1).Value.ToString
    '                If idDocumento = 3 Then
    '                    '    NroDoc = NroDoc.Substring(2, NroDoc.Length - 2)
    '                    NroDoc = fnGeneraDigitoChequeo(NroDoc)
    '                End If
    '                flag = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Public Function fnNroDocuemnto2(ByVal idDocumento As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GENERICO.sp_get_comprobante", CommandType.StoredProcedure)
            db.AsignarParametro("vi_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_idtipo_comprobante", idDocumento.ToString, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_idagencias", dtoUSUARIOS.m_iIdAgencia.ToString, OracleClient.OracleType.Number)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                Serie = dt.Rows(0).Item(0).ToString
                NroDoc = dt.Rows(0).Item(1).ToString
                If idDocumento = 3 Then
                    NroDoc = fnGeneraDigitoChequeo(NroDoc)
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    ' Public Function fnIncrementarNroDoc2009(ByVal idTipoComprobante As Integer)
    'Dim flag As Boolean = False
    'Try
    '    Dim SQLQuery As Object() = {"sp_INCREMENTAR_NRO_DOCUMENTO", 8, dtoUSUARIOS.IP, 2, dtoUSUARIOS.m_iIdAgencia, 1, idTipoComprobante, 1}
    '    objLOG.fnLog("[sp_INCREMENTAR_NRO_DOCUMENTO] " & fnLoagObj(SQLQuery))
    '    rstNroDocumentos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    If rstNroDocumentos.State = 1 Then
    '        If rstNroDocumentos.EOF = False And rstNroDocumentos.BOF = False Then
    '            flag = True
    '        End If
    '    End If

    'Catch ex As Exception
    '    flag = False
    'End Try
    'Return flag
    'End Function
    Public Function fnIncrementarNroDoc(ByVal idTipoComprobante As Integer) As Boolean
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("sp_INCREMENTAR_NRO_DOCUMENTO", CommandType.StoredProcedure)
            db.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDAGENCIAS", dtoUSUARIOS.m_iIdAgencia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDTIPO_COMPROBANTE", idTipoComprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnANULDEVVENAS_2009(ByVal iControlANUDEV As Integer, ByVal x_IDFACTURA As Integer, ByVal x_PORCENT_DEVOLUCION As Double) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_ANUL_DEVO_VENTA_II", 14, iControlANUDEV, 1, Str(x_IDFACTURA.ToString), 2, x_PORCENT_DEVOLUCION, 3, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IP, 2}
    '        rstNroDocumentos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        objLOG.fnLog("[dtoVentaCargaContado.fnANULDEVVENAS] " & fnLoagObj(SQLQuery))
    '        If rstNroDocumentos.State = 1 Then
    '            If rstNroDocumentos.EOF = False And rstNroDocumentos.BOF = False Then
    '                MsgBox(rstNroDocumentos.Fields.Item(0).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '                v_CONTROL_ANUDEV = rstNroDocumentos.Fields.Item(1).Value
    '                flag = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnANULDEVVENAS_dt(ByVal iControlANUDEV As Integer, ByVal x_IDFACTURA As Integer, ByVal x_PORCENT_DEVOLUCION As Double) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTACARGA.SP_ANUL_DEVO_VENTA_II", CommandType.StoredProcedure)
            db.AsignarParametro("iControl", iControlANUDEV, OracleClient.OracleType.Int32)
            db.AsignarParametro("x_idfactura", Str(x_IDFACTURA.ToString), OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_Porcent_Devolucion", x_PORCENT_DEVOLUCION, OracleClient.OracleType.Number)
            db.AsignarParametro("v_Idusuario_Personal", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_idrol_usuario", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_controldatos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Dim dt As DataTable = ds.Tables(0)

            If dt.Rows.Count > 0 Then
                'MsgBox(rstNroDocumentos.Fields.Item(0).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
                v_CONTROL_ANUDEV = dt.Rows(0).Item(1)
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnVERDATA_2009(ByVal x_IDFACTURA As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_VER_VENTACONTADO_III", 4, Str(x_IDFACTURA), 2}
    '        Cur_DATOS_VENTA = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If Cur_DATOS_VENTA.State = 1 Then
    '            If Cur_DATOS_VENTA.EOF = False And Cur_DATOS_VENTA.BOF = False Then
    '                flag = True

    '                v_IDTIPO_GIRO = Cur_DATOS_VENTA.Fields.Item("idtipo_giro").Value
    '                'If IsNothing(Cur_DATOS_VENTA.Fields.Item("iddescuento_giro").Value) Then v_IDDESCUENTO_GIRO = Cur_DATOS_VENTA.Fields.Item("iddescuento_giro").Value Else v_IDDESCUENTO_GIRO = ""
    '                v_IDCONDI_GIRO = Cur_DATOS_VENTA.Fields.Item("idcondi_giro").Value
    '                v_MONTO_GIRADO = Cur_DATOS_VENTA.Fields.Item("monto_girado").Value
    '                If IsDBNull(Cur_DATOS_VENTA.Fields.Item("tele_desti").Value) = False Then
    '                    v_TELE_DESTI = Cur_DATOS_VENTA.Fields.Item("tele_desti").Value
    '                Else
    '                    v_TELE_DESTI = ""
    '                End If
    '                v_MONTO_DESCUENTO = Cur_DATOS_VENTA.Fields.Item("monto_descuento").Value
    '                v_SERIE_FACTURA = Cur_DATOS_VENTA.Fields.Item("Serie_Factura").Value
    '                v_NRO_FACTURA = Cur_DATOS_VENTA.Fields.Item("Nro_Factura").Value
    '                v_UNIDAD_ORIGEN = Cur_DATOS_VENTA.Fields.Item("origen").Value
    '                v_IDUNIDAD_DESTINO = Cur_DATOS_VENTA.Fields.Item("iddestino").Value
    '                v_IDAGENCIAS_DESTINO = Cur_DATOS_VENTA.Fields.Item("Idagencias_Destino").Value '
    '                v_UNIDAD_DESTINO = Cur_DATOS_VENTA.Fields.Item("destino").Value
    '                v_IDTIPO_ENTREGA = Cur_DATOS_VENTA.Fields.Item("Idtipo_Entrega").Value
    '                v_IDFORMA_PAGO = Cur_DATOS_VENTA.Fields.Item("Idforma_Pago").Value
    '                v_IDAGENCIAS_DESTINO = Cur_DATOS_VENTA.Fields.Item("Idagencias_Destino").Value
    '                v_FECHA_FACTURA = Cur_DATOS_VENTA.Fields.Item("FECHA_FACTURA").Value
    '                v_IDTIPO_PAGO = Cur_DATOS_VENTA.Fields.Item("Idtipo_Pago").Value
    '                v_IDTARJETAS = Cur_DATOS_VENTA.Fields.Item("Idtarjetas").Value
    '                v_IDTIPO_COMPROBANTE = Cur_DATOS_VENTA.Fields.Item("Idtipo_Comprobante").Value

    '                v_NROTARJETA = Cur_DATOS_VENTA.Fields.Item("NROTARJETA").Value
    '                v_NRO_DNI_RUC = Cur_DATOS_VENTA.Fields.Item("Nu_Docu_Suna").Value
    '                v_NOMBRES_RASONSOCIAL = Cur_DATOS_VENTA.Fields.Item("Razon_Social").Value

    '                v_DIRECCION_REMITENTE = Cur_DATOS_VENTA.Fields.Item("DirOrigen").Value
    '                v_DIRECCION_DESTINATARIO = Cur_DATOS_VENTA.Fields.Item("DirDestino").Value
    '                v_TELEFONO_REMITENTE = IIf(Cur_DATOS_VENTA.Fields.Item("telefono").Value = " ", "", Cur_DATOS_VENTA.Fields.Item("telefono").Value)
    '                v_PORCENT_DESCUENTO = Cur_DATOS_VENTA.Fields.Item("Porcent_Descuento").Value
    '                v_MEMO = Cur_DATOS_VENTA.Fields.Item("Memo").Value
    '                v_NOMBRES_REMITENTE = Cur_DATOS_VENTA.Fields.Item("remitente").Value
    '                v_NRO_DOC_REMITENTE = Cur_DATOS_VENTA.Fields.Item("dniremitente").Value
    '                v_NOMBRES_DESTINATARIO = Cur_DATOS_VENTA.Fields.Item("Destinatario").Value
    '                v_NRO_DOC_DESTINATARIO = Cur_DATOS_VENTA.Fields.Item("dniDestinatario").Value
    '                v_TOTAL_PESO = Cur_DATOS_VENTA.Fields.Item("Total_Peso").Value
    '                v_TOTAL_VOLUMEN = Cur_DATOS_VENTA.Fields.Item("Total_Volumen").Value
    '                v_CANTIDAD_X_PESO = Cur_DATOS_VENTA.Fields.Item("Cantidad_x_Peso").Value
    '                v_CANTIDAD_X_VOLUMEN = Cur_DATOS_VENTA.Fields.Item("Cantidad_x_Volumen").Value
    '                v_CANTIDAD_X_SOBRE = Cur_DATOS_VENTA.Fields.Item("Cantidad_x_Sobre").Value
    '                v_PRECIO_X_PESO = Cur_DATOS_VENTA.Fields.Item("Precio_x_Peso").Value
    '                v_PRECIO_X_VOLUMEN = Cur_DATOS_VENTA.Fields.Item("Precio_x_Volumen").Value
    '                v_PRECIO_X_SOBRE = Cur_DATOS_VENTA.Fields.Item("Precio_x_Sobre").Value
    '                v_MONTO_BASE = Cur_DATOS_VENTA.Fields.Item("Monto_Base").Value
    '                v_MONTO_SUB_TOTAL = Cur_DATOS_VENTA.Fields.Item("Monto_Sub_Total").Value
    '                v_MONTO_IMPUESTO = Cur_DATOS_VENTA.Fields.Item("MONTO_IMPUESTO").Value
    '                v_TOTAL_COSTO = Cur_DATOS_VENTA.Fields.Item("Total_Costo").Value


    '                If Not Cur_DATOS_VENTA.Fields.Item("IDTIPO_TARIFAS_GIROS").Value Is DBNull.Value Then
    '                    v_IDTIPO_TARIFAS_GIROS = Cur_DATOS_VENTA.Fields.Item("IDTIPO_TARIFAS_GIROS").Value
    '                Else
    '                    v_IDTIPO_TARIFAS_GIROS = ""
    '                End If


    '                If Not Cur_DATOS_VENTA.Fields.Item("NOMBRE_ENTREGA").Value Is DBNull.Value Then
    '                    V_NOMBRE_ENTREGA = Cur_DATOS_VENTA.Fields.Item("NOMBRE_ENTREGA").Value
    '                Else
    '                    V_NOMBRE_ENTREGA = ""
    '                End If
    '                If Not Cur_DATOS_VENTA.Fields.Item("DOC_ENTREGA").Value Is DBNull.Value Then
    '                    V_DOC_ENTREGA = Cur_DATOS_VENTA.Fields.Item("DOC_ENTREGA").Value
    '                Else
    '                    V_DOC_ENTREGA = ""
    '                End If
    '                If Not Cur_DATOS_VENTA.Fields.Item("HORA_ENTREGA").Value Is DBNull.Value Then
    '                    V_HORA_ENTREGA = Cur_DATOS_VENTA.Fields.Item("HORA_ENTREGA").Value
    '                Else
    '                    V_HORA_ENTREGA = ""
    '                End If
    '                If Not Cur_DATOS_VENTA.Fields.Item("OBS").Value Is DBNull.Value Then
    '                    V_OBS = Cur_DATOS_VENTA.Fields.Item("OBS").Value
    '                Else
    '                    V_OBS = ""
    '                End If
    '                If Not Cur_DATOS_VENTA.Fields.Item("FECHA_ENTREGA").Value Is DBNull.Value Then
    '                    V_FECHA_ENTREGA = Cur_DATOS_VENTA.Fields.Item("FECHA_ENTREGA").Value
    '                Else
    '                    V_FECHA_ENTREGA = ""
    '                End If
    '                If Not Cur_DATOS_VENTA.Fields.Item("PASSWORD_GIRO").Value Is DBNull.Value Then
    '                    V_PASSWORD_GIRO = Cur_DATOS_VENTA.Fields.Item("PASSWORD_GIRO").Value
    '                Else
    '                    V_PASSWORD_GIRO = ""
    '                End If

    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Public Function fnVERDATA_dt(ByVal x_IDFACTURA As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTACARGA.SP_VER_VENTACONTADO_III", CommandType.StoredProcedure)
            db.AsignarParametro("v_Idfactura", Str(x_IDFACTURA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_data", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Cur_DATOS_VENTA_dt = db.EjecutarDataTable
            If Cur_DATOS_VENTA_dt.Rows.Count > 0 Then
                v_IDTIPO_GIRO = Cur_DATOS_VENTA_dt.Rows(0).Item("idtipo_giro")
                v_IDCONDI_GIRO = Cur_DATOS_VENTA_dt.Rows(0).Item("idcondi_giro")
                v_MONTO_GIRADO = Cur_DATOS_VENTA_dt.Rows(0).Item("monto_girado")
                If IsDBNull(Cur_DATOS_VENTA_dt.Rows(0).Item("tele_desti")) = False Then
                    v_TELE_DESTI = Cur_DATOS_VENTA_dt.Rows(0).Item("tele_desti")
                Else
                    v_TELE_DESTI = ""
                End If
                v_MONTO_DESCUENTO = Cur_DATOS_VENTA_dt.Rows(0).Item("monto_descuento")
                v_SERIE_FACTURA = Cur_DATOS_VENTA_dt.Rows(0).Item("Serie_Factura")
                v_NRO_FACTURA = Cur_DATOS_VENTA_dt.Rows(0).Item("Nro_Factura")
                v_UNIDAD_ORIGEN = Cur_DATOS_VENTA_dt.Rows(0).Item("origen")
                v_IDUNIDAD_DESTINO = Cur_DATOS_VENTA_dt.Rows(0).Item("iddestino")
                v_IDAGENCIAS_DESTINO = Cur_DATOS_VENTA_dt.Rows(0).Item("Idagencias_Destino")  '
                v_UNIDAD_DESTINO = Cur_DATOS_VENTA_dt.Rows(0).Item("destino")
                v_IDTIPO_ENTREGA = Cur_DATOS_VENTA_dt.Rows(0).Item("Idtipo_Entrega")
                v_IDFORMA_PAGO = Cur_DATOS_VENTA_dt.Rows(0).Item("Idforma_Pago")
                v_IDAGENCIAS_DESTINO = Cur_DATOS_VENTA_dt.Rows(0).Item("Idagencias_Destino")
                v_FECHA_FACTURA = Cur_DATOS_VENTA_dt.Rows(0).Item("FECHA_FACTURA")
                v_IDTIPO_PAGO = Cur_DATOS_VENTA_dt.Rows(0).Item("Idtipo_Pago")
                v_IDTARJETAS = Cur_DATOS_VENTA_dt.Rows(0).Item("Idtarjetas")
                v_IDTIPO_COMPROBANTE = Cur_DATOS_VENTA_dt.Rows(0).Item("Idtipo_Comprobante")

                v_NROTARJETA = Cur_DATOS_VENTA_dt.Rows(0).Item("NROTARJETA")
                v_NRO_DNI_RUC = Cur_DATOS_VENTA_dt.Rows(0).Item("Nu_Docu_Suna")
                v_NOMBRES_RASONSOCIAL = Cur_DATOS_VENTA_dt.Rows(0).Item("Razon_Social")

                v_DIRECCION_REMITENTE = Cur_DATOS_VENTA_dt.Rows(0).Item("DirOrigen")
                v_DIRECCION_DESTINATARIO = Cur_DATOS_VENTA_dt.Rows(0).Item("DirDestino")
                v_TELEFONO_REMITENTE = IIf(Cur_DATOS_VENTA_dt.Rows(0).Item("telefono") = " ", "", Cur_DATOS_VENTA_dt.Rows(0).Item("telefono"))
                v_PORCENT_DESCUENTO = Cur_DATOS_VENTA_dt.Rows(0).Item("Porcent_Descuento")
                v_MEMO = Cur_DATOS_VENTA_dt.Rows(0).Item("Memo")
                v_NOMBRES_REMITENTE = Cur_DATOS_VENTA_dt.Rows(0).Item("remitente")
                v_NRO_DOC_REMITENTE = Cur_DATOS_VENTA_dt.Rows(0).Item("dniremitente")
                v_NOMBRES_DESTINATARIO = Cur_DATOS_VENTA_dt.Rows(0).Item("Destinatario")
                v_NRO_DOC_DESTINATARIO = Cur_DATOS_VENTA_dt.Rows(0).Item("dniDestinatario")
                v_TOTAL_PESO = Cur_DATOS_VENTA_dt.Rows(0).Item("Total_Peso")
                v_TOTAL_VOLUMEN = Cur_DATOS_VENTA_dt.Rows(0).Item("Total_Volumen")
                v_CANTIDAD_X_PESO = Cur_DATOS_VENTA_dt.Rows(0).Item("Cantidad_x_Peso")
                v_CANTIDAD_X_VOLUMEN = Cur_DATOS_VENTA_dt.Rows(0).Item("Cantidad_x_Volumen")
                v_CANTIDAD_X_SOBRE = Cur_DATOS_VENTA_dt.Rows(0).Item("Cantidad_x_Sobre")
                v_PRECIO_X_PESO = Cur_DATOS_VENTA_dt.Rows(0).Item("Precio_x_Peso")
                v_PRECIO_X_VOLUMEN = Cur_DATOS_VENTA_dt.Rows(0).Item("Precio_x_Volumen")
                v_PRECIO_X_SOBRE = Cur_DATOS_VENTA_dt.Rows(0).Item("Precio_x_Sobre")
                v_MONTO_BASE = Cur_DATOS_VENTA_dt.Rows(0).Item("Monto_Base")
                v_MONTO_SUB_TOTAL = Cur_DATOS_VENTA_dt.Rows(0).Item("Monto_Sub_Total")
                v_MONTO_IMPUESTO = Cur_DATOS_VENTA_dt.Rows(0).Item("MONTO_IMPUESTO")
                v_TOTAL_COSTO = Cur_DATOS_VENTA_dt.Rows(0).Item("Total_Costo")

                If Not Cur_DATOS_VENTA_dt.Rows(0).Item("IDTIPO_TARIFAS_GIROS") Is DBNull.Value Then
                    v_IDTIPO_TARIFAS_GIROS = Cur_DATOS_VENTA_dt.Rows(0).Item("IDTIPO_TARIFAS_GIROS")
                Else
                    v_IDTIPO_TARIFAS_GIROS = ""
                End If


                If Not Cur_DATOS_VENTA_dt.Rows(0).Item("NOMBRE_ENTREGA") Is DBNull.Value Then
                    V_NOMBRE_ENTREGA = Cur_DATOS_VENTA_dt.Rows(0).Item("NOMBRE_ENTREGA")
                Else
                    V_NOMBRE_ENTREGA = ""
                End If
                If Not Cur_DATOS_VENTA_dt.Rows(0).Item("DOC_ENTREGA") Is DBNull.Value Then
                    V_DOC_ENTREGA = Cur_DATOS_VENTA_dt.Rows(0).Item("DOC_ENTREGA")
                Else
                    V_DOC_ENTREGA = ""
                End If
                If Not Cur_DATOS_VENTA_dt.Rows(0).Item("HORA_ENTREGA") Is DBNull.Value Then
                    V_HORA_ENTREGA = Cur_DATOS_VENTA_dt.Rows(0).Item("HORA_ENTREGA")
                Else
                    V_HORA_ENTREGA = ""
                End If
                If Not Cur_DATOS_VENTA_dt.Rows(0).Item("OBS") Is DBNull.Value Then
                    V_OBS = Cur_DATOS_VENTA_dt.Rows(0).Item("OBS")
                Else
                    V_OBS = ""
                End If
                If Not Cur_DATOS_VENTA_dt.Rows(0).Item("FECHA_ENTREGA") Is DBNull.Value Then
                    V_FECHA_ENTREGA = Cur_DATOS_VENTA_dt.Rows(0).Item("FECHA_ENTREGA")
                Else
                    V_FECHA_ENTREGA = ""
                End If
                If Not Cur_DATOS_VENTA_dt.Rows(0).Item("PASSWORD_GIRO") Is DBNull.Value Then
                    V_PASSWORD_GIRO = Cur_DATOS_VENTA_dt.Rows(0).Item("PASSWORD_GIRO")
                Else
                    V_PASSWORD_GIRO = ""
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnValidarProceso_2009(ByVal x_idFactura As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"select coalesce(count(*),0) VALIDAR from t_factura_contado  where t_factura_contado.idfactura=" & x_idFactura.ToString & " and t_factura_contado .idestado_factura = 27 ", 2}
    '        rstControlProceso = Nothing
    '        rstControlProceso = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If rstControlProceso.State = 1 Then
    '            If rstControlProceso.EOF = False And rstControlProceso.BOF = False Then
    '                If rstControlProceso.Fields.Item("VALIDAR").Value = 1 Then
    '                    flag = True
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flag
    'End Function

    Public Function fnValidarProceso_dt(ByVal x_idFactura As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GENERICO.sp_validar_proceso", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idfactura", x_idFactura.ToString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("VALIDAR") = 1 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnBuscarCliente_2009(ByVal iControl As Integer, ByVal NroDoc As String, ByVal RasonSocial As String, ByVal idOrigen As Integer, ByVal idDestino As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_FILTRO_CLIENTES", 12, iControl, 1, NroDoc, 2, RasonSocial, 2, idOrigen, 1, idDestino, 1}
    '        cur_persona = Nothing
    '        cur_cont_origen = Nothing
    '        cur_cont_destino = Nothing
    '        cur_dire_origen = Nothing
    '        cur_dire_destino = Nothing


    '        cur_persona = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If cur_persona.State = 1 Then
    '            If cur_persona.EOF = False And cur_persona.BOF = False Then
    '                If cur_persona.Fields.Item(0).Value > 0 Then
    '                    cur_cont_origen = cur_persona.NextRecordset
    '                    cur_cont_destino = cur_persona.NextRecordset
    '                    cur_dire_origen = cur_persona.NextRecordset
    '                    cur_dire_destino = cur_persona.NextRecordset
    '                    flag = True
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flag
    'End Function

    Public Function fnBuscarCliente_dt(ByVal iControl As Integer, ByVal NroDoc As String, ByVal RasonSocial As String, ByVal idOrigen As Integer, ByVal idDestino As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTACARGA.SP_FILTRO_CLIENTES", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", iControl, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_nu_docu_suna", NroDoc, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_razon_social", RasonSocial, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_IdUnidadOrigen", idOrigen, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_IdUnidadDestino", idDestino, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_persona", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_cont_origen", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_cont_destino", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_dire_origen", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_dire_destino", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_persona_dt = ds.Tables(0)
            If cur_persona_dt.Rows.Count > 0 Then
                If cur_persona_dt.Rows(0).Item(0) > 0 Then
                    cur_cont_origen_dt = ds.Tables(1)
                    cur_cont_destino_dt = ds.Tables(2)
                    cur_dire_origen_dt = ds.Tables(3)
                    cur_dire_destino_dt = ds.Tables(4)
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnREIMPRESIONCODIGOS_2009(ByVal iControl As Integer, ByVal x_IDFACTURA As String) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_REIMPRESION_CODIGO_BARRAS", 6, iControl, 1, x_IDFACTURA, 2}
    '        Cur_DATOS_VENTA = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)

    '        If Cur_DATOS_VENTA.State = 1 Then
    '            If Cur_DATOS_VENTA.EOF = False And Cur_DATOS_VENTA.BOF = False Then
    '                flag = True
    '                ObjCODIGOBARRA.clinte = Cur_DATOS_VENTA.Fields.Item("Razon_Social").Value
    '                ObjCODIGOBARRA.Cantidad = Cur_DATOS_VENTA.Fields.Item("Cantidad").Value
    '                ObjCODIGOBARRA.NroDOC = Cur_DATOS_VENTA.Fields.Item("NroDoc").Value
    '                ObjCODIGOBARRA.Origen = Cur_DATOS_VENTA.Fields.Item("Origen").Value
    '                ObjCODIGOBARRA.Destino = Cur_DATOS_VENTA.Fields.Item("Destino").Value
    '                ObjCODIGOBARRA.CodigoBarra = ""
    '                ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
    '                ObjCODIGOBARRA.HoraImpresion = ObjCODIGOBARRA.fnGetHora()
    '                ObjCODIGOBARRA.AGEDOM = Cur_DATOS_VENTA.Fields.Item("Tipo_Entrega").Value
    '                ObjVentaCargaContado.Cur_CODIGOBARRAS = Cur_DATOS_VENTA.NextRecordset
    '            End If
    '        End If
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnREIMPRESIONCODIGOS_dt(ByVal iControl As Integer, ByVal x_IDFACTURA As String) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTACARGA.SP_REIMPRESION_CODIGO_BARRAS", CommandType.StoredProcedure)
            db.AsignarParametro("iControl", iControl, OracleClient.OracleType.Int32)
            db.AsignarParametro("xidComprobante", x_IDFACTURA, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_cabecera", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_codigos", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            '
            Cur_DATOS_VENTA_dt = ds.Tables(0)
            '
            If Cur_DATOS_VENTA_dt.Rows.Count > 0 Then
                ObjCODIGOBARRA.clinte = Cur_DATOS_VENTA_dt.Rows(0).Item("Razon_Social")
                ObjCODIGOBARRA.Cantidad = Cur_DATOS_VENTA_dt.Rows(0).Item("Cantidad")
                ObjCODIGOBARRA.NroDOC = Cur_DATOS_VENTA_dt.Rows(0).Item("NroDoc")
                ObjCODIGOBARRA.Origen = Cur_DATOS_VENTA_dt.Rows(0).Item("Origen")
                ObjCODIGOBARRA.Destino = Cur_DATOS_VENTA_dt.Rows(0).Item("Destino")
                ObjCODIGOBARRA.CodigoBarra = ""
                ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
                ObjCODIGOBARRA.HoraImpresion = ObjCODIGOBARRA.fnGetHora()
                ObjCODIGOBARRA.AGEDOM = Cur_DATOS_VENTA_dt.Rows(0).Item("Tipo_Entrega")
                'ObjVentaCargaContado.Cur_CODIGOBARRAS_dt = ds.Tables(1)
                Return True
            Else
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function fnELIMINAR_DOCUMENTO(ByVal v_idFactura As String) As Boolean
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOVENTACARGA.SP_ELIMINAR_FACTURA", 8, v_idFactura, 2, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IP, 2}
    '        cur_datos_eliminacion = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If cur_datos_eliminacion.State = 1 Then
    '            If cur_datos_eliminacion.EOF = False And cur_datos_eliminacion.BOF = False Then
    '                MsgBox(cur_datos_eliminacion.Fields.Item(0).Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '            End If
    '        Else
    '            MsgBox("No se ha podido eliminar el registro...", MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return False
    'End Function

    Public Function fnELIMINAR_DOCUMENTO_dt(ByVal v_idFactura As String) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOVENTACARGA.SP_ELIMINAR_FACTURA", CommandType.StoredProcedure)
            db.AsignarParametro("v_idFactura", v_idFactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("v_idUsuario", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_ip", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            cur_datos_eliminacion_dt = ds.Tables(0)
            If cur_datos_eliminacion_dt.Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        End Try
    End Function

    Public Function fnGetAgencias_dt() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_GENERICO.sp_get_agencia", CommandType.StoredProcedure)
            db.AsignarParametro("cur_agencia", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
