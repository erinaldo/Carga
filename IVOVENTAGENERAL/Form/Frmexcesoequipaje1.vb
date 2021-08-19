Imports AccesoDatos
Public Class Frmexcesoequipaje
#Region "Variables"
    Public coll_iDestino As New Collection
    Public iWinDestino As New AutoCompleteStringCollection
    ' 
    Dim TipoComprobante As Integer = 15 'Por defecto debe ser 15 BOLETA DE EXCESO
    Dim inro_Digitos_Ventas As Integer = 7
    Dim inro_Digitos_SerieVentas As Integer = 3
    '
    Dim varIdtipo_comprobante As Integer = 0
    'Variables con respecto al pasajero  
    Dim stel_pasajero As String
    Dim lidpersona As Long
    Dim lidpersona_ruc As Long
    Dim lidUnidadAgencias_destino As Long
    ' Recuperando el valor del IGV 
    Dim IGV As Double = 19.0  ' dtoUSUARIOS.iIGV '/ 100  ' Recupera el valor de la bd, pero en pasaje no es necesario 
    '
    Dim li_control As Long
    Dim b_no_lee_campo As Boolean
    Dim bno_lee_condicion As Boolean
    'Dim odba As New OleDb.OleDbDataAdapter
    '
    Public dvControl, dvtarjeta As New DataView
    Public dtControl, dttarjeta As New DataTable
    '
    Public dvdocumento As New DataView
    Public dtdocumento As New DataTable
    '
    Public dvagencias As New DataView
    Public dvagencias_origen As New DataView
    '
    Public dtagencias As New DataTable
    Public dt_agencias_origen As New DataTable
    '
    Public lee_focus As Boolean = True
    '
    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    '
    Dim bIngreso As Boolean = False
    Public hnd As Long
#End Region

    Private Sub Frmexcesoequipaje_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmexcesoequipaje_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'datahelper
            'dtoUSUARIOS.m_iNombreUnidadAgencia = fnGetCiudad(dtoUSUARIOS.m_idciudad.ToString)
            dtoUSUARIOS.m_iNombreUnidadAgencia = fnGetCiudad(dtoUSUARIOS.m_idciudad.ToString)

            'datahelper
            'dtoUSUARIOS.m_iNombreAgencia = fnGetAGENCIA(dtoUSUARIOS.m_iIdAgencia.ToString)
            dtoUSUARIOS.m_iNombreAgencia = fnGetAGENCIA(dtoUSUARIOS.m_iIdAgencia.ToString)

            ToolStripMenuItem1.Text = "&BUSCAR"
            ToolStripMenuItem2.Text = "&EXCESO "
            '
            SelectMenu(1)
            li_control = 1 ' Por defecto 1 para grabar, la primera vez 
            '
            If Objexcesoequipaje.fnLISTA_INICIAL_exceso_equipaje() = True Then
                'datahelper
                'odba.Fill(dtdocumento, Objexcesoequipaje.rst_documento)
                'ModuUtil.LlenarComboIDs(Objexcesoequipaje.rst_documento, cmbtipocomprobante, Objexcesoequipaje.coll_documento, 15)

                'odba.Fill(dtagencias, Objexcesoequipaje.rst_agencias)
                'bno_lee_condicion = False
                'dt_agencias_origen = dtagencias.Copy
                'dvagencias_origen = CargarCombo(Me.cmb_agencia_origen, dt_agencias_origen, "nombre_agencia", "idagencias", dtoUSUARIOS.iIDAGENCIAS)
                'dvagencias = CargarCombo(Me.cmbagenciadestino, dtagencias, "nombre_agencia", "idagencias", -1)
                'bno_lee_condicion = True
                ' Recupera la tarjeta de credito 
                'odba.Fill(dttarjeta, Objexcesoequipaje.rst_tarjeta_credito)
                'dvtarjeta = CargarCombo(Me.cmbtarjeta, dttarjeta, "descripcion", "idtarjetas", -666)
                '
                'ObjVentaPasaje.rst_agencias = Nothing
                'ObjVentaPasaje.rst_tarjeta = Nothing
                '
                'fnCargar_iWin(txtiWinDestino, Objexcesoequipaje.rst_unidad_agencia, coll_iDestino, iWinDestino, 0)
                'Me.cmbagenciadestino.SelectedIndex = -1

                dtdocumento = Objexcesoequipaje.rst_documento
                ModuUtil.LlenarCombo2(Objexcesoequipaje.rst_documento, cmbtipocomprobante, Objexcesoequipaje.coll_documento, 15)

                dtagencias = Objexcesoequipaje.rst_agencias
                bno_lee_condicion = False
                dt_agencias_origen = dtagencias.Copy
                dvagencias_origen = CargarCombo(Me.cmb_agencia_origen, dt_agencias_origen, "nombre_agencia", "idagencias", dtoUSUARIOS.iIDAGENCIAS)
                dvagencias = CargarCombo(Me.cmbagenciadestino, dtagencias, "nombre_agencia", "idagencias", -1)
                bno_lee_condicion = True
                'Recupera la tarjeta de credito 
                dttarjeta = Objexcesoequipaje.rst_tarjeta_credito
                dvtarjeta = CargarCombo(Me.cmbtarjeta, dttarjeta, "descripcion", "idtarjetas", -666)

                fnCargar_iWin_dt(txtiWinDestino, Objexcesoequipaje.rst_unidad_agencia, coll_iDestino, iWinDestino, 0)
                Me.cmbagenciadestino.SelectedIndex = -1

            End If
            'Desahabilito p'q' solo es el exceso.
            Me.cmbtipocomprobante.Enabled = False
            '
            ' Para la pantalla de busqueda -- Omendoza 
            '
            If Objexcesoequipaje.fnLISTA_AGENCIAS_UNIDADES() = True Then
                'datahelper
                'ModuUtil.LlenarComboIDs2(Objexcesoequipaje.rst_Lista_Unidades_Agencia, cmbOrigen, Objexcesoequipaje.coll_Lista_Origen, 9999, cmbDestino, Objexcesoequipaje.coll_Lista_Destino, 9999)
                ModuUtil.LlenarComboIDs2(Objexcesoequipaje.rst_Lista_Unidades_Agencia, cmbOrigen, Objexcesoequipaje.coll_Lista_Origen, 9999, cmbDestino, Objexcesoequipaje.coll_Lista_Destino, 9999)
            End If
            '
            'datahelper
            'rst = New ADODB.Recordset
            'rst = VOCONTROLUSUARIO.ListarAgencias(-1)
            Dim rst As DataTable
            'Dim db As New BaseDatos
            'db.Conectar()
            'db.CrearComando("PKG_GENERICO.sp_get_agencia", CommandType.StoredProcedure)
            'db.AsignarParametro("cur_agencia", OracleClient.OracleType.Cursor)
            'db.Desconectar()
            Dim obj As New dtoexcesoequipaje
            rst = obj.get_agencia()
            'datahelper
            'ModuUtil.LlenarComboIDs(rst, cmbAgencia, Objexcesoequipaje.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            ModuUtil.LlenarCombo2(rst, cmbAgencia, Objexcesoequipaje.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            '
            If Objexcesoequipaje.fnFILTRO_USUARIO_X_AGENCIA_exceso(dtoUSUARIOS.m_iIdAgencia) = True Then
                'datahelper
                'ModuUtil.LlenarComboIDs(Objexcesoequipaje.rst_Lista_Usuarios, cmbUsuarios, Objexcesoequipaje.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
                ModuUtil.LlenarCombo2(Objexcesoequipaje.rst_Lista_Usuarios, cmbUsuarios, Objexcesoequipaje.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
            Else
                NingunoComboIDs(cmbUsuarios, Objexcesoequipaje.coll_Lista_Usuarios)
            End If
            rst = Nothing
            fnLoadGrid()
            '' Fin de la grilla  y busqueda  omendoza 

            dtp_fec_emision.Text = dtoUSUARIOS.m_sFecha
            DTPfec_viaje.Text = dtoUSUARIOS.m_sFecha
            txtiWinDestino.Focus()
            txtiWinDestino.SelectAll()
            '
            If Objexcesoequipaje.fnNroDocumento(TipoComprobante) = True Then
                If IsDBNull(Objexcesoequipaje.Serie) = True Or RellenoRight(inro_Digitos_SerieVentas, Objexcesoequipaje.Serie) = "000" Then
                    MessageBox.Show("No ha configurado la serie del exceso", "Venta de Pasajes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    Exit Sub
                End If
                TXTSER_COMPROBANTE.Text = RellenoRight(inro_Digitos_SerieVentas, Objexcesoequipaje.Serie)
                TXTNRO_COMPROBANTE.Text = RellenoRight(inro_Digitos_Ventas, Objexcesoequipaje.NroDoc)
            End If
            b_no_lee_campo = True
            '
            Me.txtidunidadagencia.Focus()
            get_nombre_agencia()
            '

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Private Sub txtiWinDestino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtiWinDestino.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            If Not IsNumeric(e.KeyChar) And Char.IsLetter(e.KeyChar) Then
                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub txtiWinDestino_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtiWinDestino.Validated
        Objexcesoequipaje.iIDAGENCIAS_DESTINO = 0
        fnAgenciaDestino()
    End Sub
    Private Sub fnAgenciaDestino()
        Try
            Dim idUnidadAgencias As Integer = iWinDestino.IndexOf(txtiWinDestino.Text)
            If idUnidadAgencias >= 0 Then
                idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))
                lidUnidadAgencias_destino = CType(idUnidadAgencias, Long)
                ''''''''''''''''''''
                'Me.cmbagenciadestino.Controls.Clear()
                'Me.cmbagenciadestino.Items.Clear()
                '
                If lidUnidadAgencias_destino >= 0 Then
                    recupera_agencia_destino(lidUnidadAgencias_destino)
                End If
                Me.txtidunidadagencia.Text = CType(lidUnidadAgencias_destino, String)
                fn_valida_ciudad()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSER_COMPROBANTE.KeyPress, TXTNRO_COMPROBANTE.KeyPress, Txtdni.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Private Sub Txtdni_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txtdni.Validating
        Try
            If Txtdni.Text <> "" Then
                Txtdni.Text = RellenoRight(8, Txtdni.Text)
                '
                If Txtdni.Text.Length <> 8 Then
                    MsgBox("El Nº de Documento no es válido ", MsgBoxStyle.Information, "Seguridad Sistema")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            '
        End Try
    End Sub

    Private Sub Txtdni_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdni.Leave
        'Recupera los datos y colocas el valor 
        Try
            If b_no_lee_campo = True Then
                If Txtdni.Text = "" Then
                    Me.txtpasajero.Focus()
                    Exit Sub
                End If
                fnrecuperacliente()
                If lidpersona <= 0 Then
                    Me.txtpasajero.Focus()
                Else
                    Me.txtcantidad.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Public Function fnrecuperacliente() As Boolean
        Dim flag As Boolean = False
        Try
            ''Trae la tarifa Origen Destino
            'Objexcesoequipaje.iidagencias = dtoUSUARIOS.m_idciudad
            ''Recuperando la agencia destino 
            'Dim idUnidadAgencias_dest As Integer = iWinDestino.IndexOf(txtiWinDestino.Text)
            'idUnidadAgencias_dest = Int(coll_iDestino.Item(idUnidadAgencias_dest.ToString))
            'If idUnidadAgencias_dest > 0 Then
            ' Objexcesoequipaje.v_IDUNIDAD_DESTINO = idUnidadAgencias_dest
            'ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = Int(Objexcesoequipaje.coll_AgenciasVenta(cmbAgenciaVenta.SelectedIndex.ToString))
            'ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = idUnidadAgencias_dest
            'Else
            'MsgBox("No es Correcto la Ciudad Destino...", MsgBoxStyle.Information, "Seguridad Sistema")
            'Return False
            'End If
            ' Venta al contado 
            Objexcesoequipaje.sNU_DOCU_SUNAT = IIf(Me.Txtdni.Text <> "", Me.Txtdni.Text, "@")
            If Objexcesoequipaje.fnLISTA_GET_CLIENTE = True Then
                stel_pasajero = Objexcesoequipaje.stelefono
                Me.txtpasajero.Text = Objexcesoequipaje.snombre_pasajero
                lidpersona = Objexcesoequipaje.lidpersona
                flag = True
            Else
                flag = False
                'MsgBox("No tiene documento de identidad", MsgBoxStyle.Information, "Revisar los datos")
            End If
        Catch ex As Exception
            flag = False
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            Throw New Exception(ex.Message)
        End Try
        Return flag
    End Function
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        ' Salir del sistema 
        If msg.WParam.ToInt32() = CInt(Keys.Escape) Then
            Me.Close()
        End If
        If msg.WParam.ToInt32() = CInt(Keys.F5) Then
            ' Grabar 
            'cambio tecla funcion
            If btngrabar.Enabled Then
                fn_grabar_exceso()
            End If
        End If
    End Function
    Private Sub txtiWinDestino_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtiWinDestino.Leave
        Txtdni.Focus()
    End Sub
    Sub fn_grabar_exceso()
        Dim smensaje As String
        Dim lnromensaje As Long
        Dim ll_agencia_origen As Long
        Dim ll_idunidad_origen As Long
        '
        Try
            ' Validar los campos que son principales 
            Dim MyObligatorios As Object() = {Me.txtidunidadagencia, Me.txttotal, Me.txtpasajero, Me.TXTSER_COMPROBANTE, Me.TXTNRO_COMPROBANTE}
            '
            If Me.txttotal.Text = "0.00" Or Me.txttotal.Text = "" Then
                MsgBox("Falta ingresar el total del boleto", MsgBoxStyle.Information, "Venta Boleto")
                Me.txttotal.Focus()
                Exit Sub
            End If

            '''''''''''''''''
            'Validando con la agencia origen 
            ll_agencia_origen = Me.cmb_agencia_origen.SelectedValue
            Dim dr_agencias As DataRowView
            '
            dr_agencias = dvagencias_origen.Item(Me.cmb_agencia_origen.SelectedIndex)
            ll_idunidad_origen = CType(dr_agencias("idunidad_agencia"), Long)
            '
            If lidUnidadAgencias_destino = ll_idunidad_origen Then
                MsgBox("El destino coincide con la ciudad origen (agencia), ¿verificar?", MsgBoxStyle.Information, "Venta Boleto")
                Me.cmbagenciadestino.SelectedValue = 0
                Me.txtidunidadagencia.Text = ""
                Me.txtiWinDestino.Text = ""
                Me.txtidunidadagencia.Focus()
                Exit Sub
            End If
            '''''''''''''''''
            Objexcesoequipaje.icontrol = li_control
            If Me.txtidventa_pasaje.Text = "" Or IsDBNull(Me.txtidventa_pasaje.Text) = True Then
                Objexcesoequipaje.sidventa_pasaje = "null"
            Else
                Objexcesoequipaje.sidventa_pasaje = Me.txtidventa_pasaje.Text
            End If
            If IsDBNull(lidpersona) = True Or lidpersona = 0 Then
                Objexcesoequipaje.sidpersona_dni = "null"
            Else
                Objexcesoequipaje.sidpersona_dni = CType(lidpersona, String)
            End If
            'ledad As Integer
            ' Public scodigo_cuenta
            Objexcesoequipaje.sapellidos_nombre_dni = Me.txtpasajero.Text
            If Me.Txtdni.Text = "" Then
                Objexcesoequipaje.snrodctoidentidad_dni = "null"
            Else
                Objexcesoequipaje.snrodctoidentidad_dni = Me.Txtdni.Text
            End If
            'Objexcesoequipaje.lidtipo_comprobante = Int(Objexcesoequipaje.coll_documento(Me.cmbtipocomprobante.SelectedIndex.ToString))
            Objexcesoequipaje.lidtipo_comprobante = Int(Objexcesoequipaje.coll_documento(Me.cmbtipocomprobante.SelectedIndex.ToString)) 'Int(Me.cmbtipocomprobante.SelectedValue)
            Objexcesoequipaje.sserie_comprobante = Me.TXTSER_COMPROBANTE.Text
            Objexcesoequipaje.snro_comprobante = RellenoRight(inro_Digitos_Ventas, Me.TXTNRO_COMPROBANTE.Text)
            '
            Objexcesoequipaje.lidforma_pago = 1 ' Siempre va hacer contado -> En caso que tenga credito poner igual que la venta de pasajes 
            Objexcesoequipaje.lidtipo_moneda = -666 '1 'Por ahora va hacer Nuevo Soles 
            Objexcesoequipaje.d_igv = IGV  ' Porcentaje del igv 
            If Me.txtcantidad.Text = "" Or IsDBNull(Me.txtcantidad.Text) Then
                Objexcesoequipaje.lcantidad = 0
            Else
                Objexcesoequipaje.lcantidad = CType(Me.txtcantidad.Text, Long)
            End If
            If Me.txtpeso.Text = "" Or IsDBNull(Me.txtpeso.Text) Then
                Objexcesoequipaje.dpeso = 0
            Else
                Objexcesoequipaje.dpeso = CType(Me.txtpeso.Text, Double)
            End If
            'Objexcesoequipaje.lidtipo_operacion = 1 ' Venta Normal 
            Objexcesoequipaje.dmonto_base = 0
            Objexcesoequipaje.dmonto_penalidad = 0
            Objexcesoequipaje.dmonto_descuento = 0
            Objexcesoequipaje.dmonto_recargo = 0
            ''''''''''''''''''''''
            Objexcesoequipaje.lidunidad_agencia_ori = ll_idunidad_origen  'CType(dtoUSUARIOS.m_idciudad, Integer)    ' LONG 
            Objexcesoequipaje.iidagencias = ll_agencia_origen '18/12/2008 - dtoUSUARIOS.m_iIdAgencia 
            Objexcesoequipaje.iIDAGENCIAS_DESTINO = Me.cmbagenciadestino.SelectedValue  'Int(Objexcesoequipaje.coll_agencia(Me.cmbagenciadestino.SelectedIndex.ToString))
            Objexcesoequipaje.lidunidad_agencia_des = CType(lidUnidadAgencias_destino, Integer) 'LONG 
            Objexcesoequipaje.liestado_registro = 1 ' Siempre Activo 
            Objexcesoequipaje.sip = dtoUSUARIOS.IP
            Objexcesoequipaje.sfecha_emision = CType(Me.dtp_fec_emision.Value, String)
            Objexcesoequipaje.sfecha_viaje = CType(Me.DTPfec_viaje.Value, String)
            If Me.txthora.Text = "" Then
                Objexcesoequipaje.shora_salida = "null"
            Else
                Objexcesoequipaje.shora_salida = CType(Me.txthora.Text, String)
            End If
            Objexcesoequipaje.dmonto_total = CType(Me.txttotal.Text, Double)
            Objexcesoequipaje.lidusuario_personal = dtoUSUARIOS.IdLogin
            Objexcesoequipaje.lidrol_usuario = dtoUSUARIOS.m_iIdRol
            Objexcesoequipaje.lidtarjeta1 = Me.cmbtarjeta.SelectedValue
            If Objexcesoequipaje.fngraba_exceso = True Then
                'datahelper
                'lnromensaje = CType(Objexcesoequipaje.rst_mensaje_oracle.Fields.Item(0).Value, Long)   ' Se observara si necesita algun mensaje  
                'smensaje = CType(Objexcesoequipaje.rst_mensaje_oracle.Fields.Item(1).Value, String)   ' Se observara si necesita algun mensaje  
                lnromensaje = CType(Objexcesoequipaje.rst_mensaje_oracle.Rows(0).Item(0), Long)   ' Se observara si necesita algun mensaje  
                smensaje = CType(Objexcesoequipaje.rst_mensaje_oracle.Rows(0).Item(1), String)   ' Se observara si necesita algun mensaje  
                If lnromensaje <> 0 Then
                    MsgBox(smensaje, MsgBoxStyle.Information, "Venta de Pasaje")
                    Exit Sub
                Else
                    If li_control <> 2 Then
                        Dim lidtipo_documento As Integer
                        'lidtipo_documento = Int(Objexcesoequipaje.coll_documento.Item(cmbtipocomprobante.SelectedIndex.ToString))
                        lidtipo_documento = TipoComprobante 'cmbtipocomprobante.SelectedValue como es un solo tipo no es necesario 
                        ' Incrementar la boleta del comprobante
                        Objexcesoequipaje.fnIncrementarNroDoc(lidtipo_documento)
                        If Objexcesoequipaje.fnNroDocumento(lidtipo_documento) = True Then
                            TXTSER_COMPROBANTE.Text = RellenoRight(inro_Digitos_SerieVentas, Objexcesoequipaje.Serie)
                            TXTNRO_COMPROBANTE.Text = RellenoRight(inro_Digitos_Ventas, Objexcesoequipaje.NroDoc)
                        End If
                    End If
                End If
            End If
            '                
            limpiar_variables()
            If li_control = 1 Then
                lee_focus = True
                Me.txtidunidadagencia.Focus()
            Else
                SelectMenu(0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Sub limpiar_variables()
        Try
            lidpersona = 0
            Me.txtidventa_pasaje.Text = ""
            Me.txtpasajerobusqueda.Text = ""
            Me.txtpasajero.Text = ""
            Me.Txtdni.Text = ""
            ' cmbtipocomprobante.SelectedValue = 12 ' Siempre vuelve al servicio presidencial  
            'Me.TXTSER_COMPROBANTE.Text = ""
            'Me.TXTNRO_COMPROBANTE.Text = ""
            lidUnidadAgencias_destino = 0
            'Me.dtp_fec_emision.Value = dtoUSUARIOS.dfecha_sistema
            Me.DTPfec_viaje.Value = dtoUSUARIOS.dfecha_sistema
            '
            Me.txtidunidadagencia.Text = ""
            Me.txtiWinDestino.Text = ""
            Me.txthora.Text = ""
            Me.txttotal.Text = "0.00"
            Me.cmbagenciadestino.SelectedValue = -1
            Me.txtpeso.Text = "0.00"
            Me.txtcantidad.Text = "0"
            Me.cmbtarjeta.SelectedValue = -666
            ' Me.cmbagenciadestino.SelectedIndex = -1
        Catch ex As Exception
            '
        End Try
    End Sub
    Private Sub txtidunidadagencia_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidunidadagencia.Leave
        Dim l_idunidad_agencia As Integer
        'datahelper
        'Dim l_rstunidad_agencia As New ADODB.Recordset
        Dim l_rstunidad_agencia As DataTable
        Try
            If b_no_lee_campo = True Then
                If txtidunidadagencia.Text <> "" Then
                    l_idunidad_agencia = CType(txtidunidadagencia.Text, Integer)
                    '
                    l_rstunidad_agencia = Objexcesoequipaje.fnGetunidadagencia(l_idunidad_agencia)
                    If l_rstunidad_agencia.Rows.Count > 0 Then
                        Me.txtiWinDestino.Text = l_rstunidad_agencia.Rows(0).Item(1) ' Recupera la ciudad 
                        ' Recupera las agecias asociadas 
                        If fn_recupera_agencias(l_idunidad_agencia) = True Then
                            lidUnidadAgencias_destino = l_idunidad_agencia
                            'Recupera la ciudad origen - 18/12/2008  
                            If fn_valida_ciudad() = False Then
                                Exit Sub
                            End If
                            Me.dtp_fec_emision.Focus()
                        Else
                            Me.txtidunidadagencia.Focus()
                        End If
                    Else
                        Me.txtiWinDestino.Text = ""
                        Me.txtidunidadagencia.Text = ""
                        Me.txtidunidadagencia.Focus()
                    End If
                End If

                    'datahelper
                    '    If l_rstunidad_agencia.BOF = False And l_rstunidad_agencia.EOF = False Then
                    '        Me.txtiWinDestino.Text = l_rstunidad_agencia.Fields(1).Value ' Recupera la ciudad 
                    '        ' Recupera las agecias asociadas 
                    '        If fn_recupera_agencias(l_idunidad_agencia) = True Then
                    '            lidUnidadAgencias_destino = l_idunidad_agencia
                    '            'Recupera la ciudad origen - 18/12/2008  
                    '            If fn_valida_ciudad() = False Then
                    '                Exit Sub
                    '            End If
                    '            Me.dtp_fec_emision.Focus()
                    '        Else
                    '            Me.txtidunidadagencia.Focus()
                    '        End If
                    '    Else
                    '        Me.txtiWinDestino.Text = ""
                    '        Me.txtidunidadagencia.Text = ""
                    '        Me.txtidunidadagencia.Focus()
                    '    End If
                    'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Function fn_recupera_agencias(ByVal lidUnidadAgencias_destino As Integer) As Boolean
        Dim bencontro As Boolean = False
        Dim agencia As Integer
        If lidUnidadAgencias_destino > 0 Then
            Objexcesoequipaje.fnGetAgencias(lidUnidadAgencias_destino)
            'datahelper
            'If Objexcesoequipaje.rst_agencias.BOF = False And Objexcesoequipaje.rst_agencias.EOF = False Then
            If Objexcesoequipaje.rst_agencias.Rows.Count > 0 Then
                If lidUnidadAgencias_destino = 5100 Then   'Solo el caso de Lima 
                    agencia = 51  'Por defecto toma JP 
                Else
                    'datahelper
                    'agencia = Int(Objexcesoequipaje.rst_agencias.Fields(0).Value)
                    agencia = Int(Objexcesoequipaje.rst_agencias.Rows(0).Item(0))
                End If
                '
                Me.cmbagenciadestino.SelectedValue = agencia
                bencontro = True
            Else
                MsgBox("No existe agencia asociada a la ciudad", MsgBoxStyle.Information, "Venta de Pasajes")
                Me.txtiWinDestino.Text = ""
                Me.txtidunidadagencia.Text = ""
                bencontro = False
            End If
        End If
        Return bencontro
    End Function
    Public Function fnLoadGrid() As Boolean
        Try
            With dtGridViewControl_pasaje
                '    .AllowUserToAddRows = False
                '    .AllowUserToDeleteRows = False
                '    .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                '    .AutoGenerateColumns = False
                '    '.DataSource = dtable_Lista_Control_Comprobante
                '    .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            'Dim idEstadoImage As New DataGridViewImageColumn
            'With idEstadoImage
            '    .DataPropertyName = "imagen"
            '    .HeaderText = "CL"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            '    .DisplayIndex = 0
            '    .Visible = True
            '    '.ValuesAreIcons = True
            '    '.InheritedStyle.BackColor = Color.Transparent
            '    .Image = bmActivo
            'End With
            'dtGridViewControl_FACBOL.Columns.Add(idEstadoImage)

            Dim colTipo_Comprobante As New DataGridViewTextBoxColumn
            With colTipo_Comprobante  '0
                .DisplayIndex = 0
                .DataPropertyName = "Tipo_Comprobante"
                .Name = "Tipo_Comprobante"
                .HeaderText = "Tipo Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colTipo_Comprobante)

            Dim colserie_comprobante As New DataGridViewTextBoxColumn
            With colserie_comprobante '1 
                .DisplayIndex = 1
                .DataPropertyName = "serie_comprobante"
                .Name = "serie_comprobante"
                .HeaderText = "Serie"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_pasaje.Columns.Add(colserie_comprobante)

            Dim colnro_comprobante As New DataGridViewTextBoxColumn
            With colnro_comprobante '2
                .DisplayIndex = 2
                .DataPropertyName = "nro_comprobante"
                .Name = "nro_comprobante"
                .HeaderText = "Nº Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colnro_comprobante)

            Dim colfecha_emision As New DataGridViewTextBoxColumn
            With colfecha_emision '3
                .DisplayIndex = 3
                .DataPropertyName = "fecha_emision"
                .Name = "fecha_emision"
                .HeaderText = "Fecha emisión"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colfecha_emision)

            Dim coldatos_personales As New DataGridViewTextBoxColumn
            With coldatos_personales  '4
                .DisplayIndex = 4
                .DataPropertyName = "datos_personales"
                .Name = "datos_personales"
                .HeaderText = "Pasajero"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(coldatos_personales)

            Dim colfecha_viaje As New DataGridViewTextBoxColumn
            With colfecha_viaje '5
                .DisplayIndex = 5
                .DataPropertyName = "fecha_viaje"
                .Name = "fecha_viaje"
                .HeaderText = "ORIGEN"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colfecha_viaje)

            Dim colorigen As New DataGridViewTextBoxColumn
            With colorigen  '6
                .DisplayIndex = 6
                .DataPropertyName = "origen"
                .Name = "origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colorigen)

            Dim coldestino As New DataGridViewTextBoxColumn
            With coldestino ' 7
                .DisplayIndex = 7
                .DataPropertyName = "destino"
                .Name = "destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(coldestino)

            Dim coltotal As New DataGridViewTextBoxColumn
            With coltotal ' 8
                .DisplayIndex = 8
                .DataPropertyName = "monto_total"
                .Name = "monto_total"
                .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(coltotal)

            Dim colfecha_registro As New DataGridViewTextBoxColumn
            With colfecha_registro '9
                .DisplayIndex = 9
                .Name = "fecha_registro"
                .DataPropertyName = "fecha_registro"
                .HeaderText = "Fecha registro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colfecha_registro)

            Dim colusuario As New DataGridViewTextBoxColumn
            With colusuario '10
                .DisplayIndex = 10
                .DataPropertyName = "usuario"
                .Name = "usuario"
                .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colusuario)

            Dim colidventa_pasajes As New DataGridViewTextBoxColumn
            With colidventa_pasajes '11
                .DisplayIndex = 11
                .DataPropertyName = "idventa_pasajes"
                .Name = "idventa_pasajes"
                .HeaderText = "idVtaPasaje"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_pasaje.Columns.Add(colidventa_pasajes)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Objexcesoequipaje.icontrol = 1
        fnBuscarexceso()
    End Sub
    Public Function fnBuscarexceso() As Boolean
        Try
            Objexcesoequipaje.lidunidad_agencia_ori = Int(Objexcesoequipaje.coll_Lista_Origen(cmbOrigen.SelectedIndex.ToString))
            If Objexcesoequipaje.lidunidad_agencia_ori = 9999 Then
                Objexcesoequipaje.lidunidad_agencia_ori = -666
            End If
            Objexcesoequipaje.lidunidad_agencia_des = Int(Objexcesoequipaje.coll_Lista_Destino(cmbDestino.SelectedIndex.ToString))
            If Objexcesoequipaje.lidunidad_agencia_des = 9999 Then
                Objexcesoequipaje.lidunidad_agencia_des = -666
            End If
            '
            Objexcesoequipaje.lidagencia_origen1 = Int(Objexcesoequipaje.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString()))
            If Objexcesoequipaje.lidagencia_origen1 = 9999 Or Objexcesoequipaje.lidagencia_origen1 = 0 Then
                Objexcesoequipaje.lidagencia_origen1 = -666
            End If
            '
            'Objexcesoequipaje.lidagencia_origen1
            Objexcesoequipaje.lidusuario_personal = Int(Objexcesoequipaje.coll_Lista_Usuarios(cmbUsuarios.SelectedIndex.ToString))
            If Objexcesoequipaje.lidusuario_personal = 0 Or Objexcesoequipaje.lidusuario_personal = 9999 Then
                Objexcesoequipaje.lidusuario_personal = -666
            End If
            '--
            Dim strNroDoc As String() = Split(txtNroSerieDoc.Text, "-")
            If strNroDoc.Length > 1 Then
                If Val(strNroDoc(0)) > 0 And Val(strNroDoc(1)) > 0 Then
                    'Objexcesoequipaje.sserie_complrobante = strNroDoc(0)
                    'Objexcesoequipaje.snro_comprobante = strNroDoc(1)
                    Objexcesoequipaje.Serie = RellenoRight(inro_Digitos_SerieVentas, strNroDoc(0))
                    Objexcesoequipaje.NroDoc = RellenoRight(inro_Digitos_Ventas, strNroDoc(1))
                Else
                    Objexcesoequipaje.Serie = "0"
                    Objexcesoequipaje.NroDoc = "0"
                End If
            End If
            Objexcesoequipaje.sapellidos_nombre_dni = IIf(txtpasajerobusqueda.Text <> "", txtpasajerobusqueda.Text, "%")
            Objexcesoequipaje.sfecha_inicio = dtFechaInicio.Text
            Objexcesoequipaje.sfecha_final = dtFechaFin.Text
            ' 
            If Objexcesoequipaje.fnControlexceso() = True Then
                'datahelper
                'dtControl.Clear()
                'dtGridViewControl_pasaje.Refresh()
                'odba.Fill(dtControl, Objexcesoequipaje.rstvtaexceso)
                dtControl = Objexcesoequipaje.rstvtaexceso
                dvControl = dtControl.DefaultView

                dtGridViewControl_pasaje.DataSource = dvControl
                dtGridViewControl_pasaje.Refresh()
                lbNroRegistro.Text = dvControl.Count
                If dvControl.Count = 0 Then
                    MsgBox("No se ha encontrado ningún resultado para esta busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
                ' bformatImage = True
            Else
                MsgBox("No se ha encontrado ningún resultado para esta busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function

    Private Sub btneditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneditar.Click
        Try
            If dtGridViewControl_pasaje.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_pasaje.SelectedRows.Item(0).Index
            If dtGridViewControl_pasaje.Rows().Count - 1 = row Then
                Return
            End If
            ' Recuperando los datos de la IDventa de pasaje 
            'Objexcesoequipaje.sidventa_pasajes = CType(dtGridViewControl_pasaje.Rows(row).Cells(1).Value, String)
            Objexcesoequipaje.sidventa_pasajes = CType(dtGridViewControl_pasaje.Rows(row).Cells(11).Value, String)
            '
            If CType(Objexcesoequipaje.sidventa_pasajes, Long) <= 0 Then
                MsgBox("No se puede realizar está operación ...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            ''
            fnControl_ventaexceso(True)
            'fnVer_Datos(True)
            'objGuiaEnvio.iCONTROL = 2
            'fnCONTROLDATOS = True
            'TxtGuiaEnvio.ReadOnly = True
            '''
        Catch ex As Exception

        End Try
    End Sub
    Public Sub fnControl_ventaexceso(ByVal rflag As Boolean)
        Dim flat As Boolean = False
        Try
            If dtGridViewControl_pasaje.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_pasaje.SelectedRows.Item(0).Index
            If dtGridViewControl_pasaje.Rows().Count - 1 = row Then
                Return
            End If
            If row >= 0 Then
                limpiar_variables() ' Limpiando variables
                SelectMenu(1)
                Objexcesoequipaje.sidventa_pasajes = CType(dtGridViewControl_pasaje.Rows(row).Cells("idventa_pasajes").Value, String)
                If Objexcesoequipaje.fnEDIT_ventaexceso() = True Then
                    ''''''''''''''''''''''''''''''''''''''                    
                    'Public lidunidad_agencia_origen As Long
                    'Public sorigen As String
                    'Public lidagencia_origen1 As Long
                    li_control = 2 ' Para actualizar los datos
                    Me.txtidventa_pasaje.Text = Objexcesoequipaje.lidventa_pasajes
                    Me.cmbtipocomprobante.SelectedValue = Objexcesoequipaje.lidtipo_comprobante1
                    '''' 
                    Me.TXTSER_COMPROBANTE.Text = Objexcesoequipaje.sserie_comprobante1
                    Me.TXTNRO_COMPROBANTE.Text = Objexcesoequipaje.snro_comprobante1
                    Me.txtidunidadagencia.Text = Objexcesoequipaje.lidunidad_agencia_destino
                    Me.txtiWinDestino.Text = Objexcesoequipaje.sdestino
                    fn_recupera_agencias(Int(Me.txtidunidadagencia.Text))
                    'Me.cmbagenciadestino.SelectedIndex = Objexcesoequipaje.lidagencia_destino1
                    Me.cmbagenciadestino.SelectedValue = Objexcesoequipaje.lidagencia_destino1
                    Me.dtp_fec_emision.Value = Objexcesoequipaje.sfecha_emision1
                    '
                    lidpersona = Objexcesoequipaje.lidpersona1
                    Me.Txtdni.Text = Objexcesoequipaje.sdni1
                    Me.txtpasajero.Text = Objexcesoequipaje.spasajero
                    Me.DTPfec_viaje.Value = Objexcesoequipaje.sfecha_viaje1
                    Me.txthora.Text = Objexcesoequipaje.shora_salida1
                    Me.txttotal.Text = Objexcesoequipaje.dmonto_total1
                    Me.txtpeso.Text = Objexcesoequipaje.dpeso
                    Me.txtcantidad.Text = Objexcesoequipaje.lcantidad
                    '
                    Me.cmbtarjeta.SelectedValue = Objexcesoequipaje.litarjeta
                    '
                End If
            Else
                MsgBox("No Puede Realizar esta Operación...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            '            
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            flat = False
        End Try
    End Sub
    Private Sub txthora_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txthora.Validating
        Try
            Dim shora As String
            '
            shora = CType(txthora.Text, String)
            shora = validar_hora_salida(shora)
            If shora = "" Then
                txthora.Text = shora
                txthora.Focus()
                Exit Sub
            End If
            '
            txthora.Text = shora
        Catch ex As Exception
            '
        End Try
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        bno_lee_condicion = False
        Me.Close()
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        fn_grabar_exceso()
    End Sub
    Private Sub Frmexcesoequipaje_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If lee_focus Then
            Me.txtidunidadagencia.Focus()
        End If
    End Sub
    Private Sub txtidunidadagencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidunidadagencia.TextChanged
        lee_focus = False
    End Sub
    Private Sub dtp_fec_emision_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fec_emision.Leave
        Me.Txtdni.Focus()
        'DTPfec_viaje.Focus()
    End Sub
    Private Sub txtNroSerieDoc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroSerieDoc.Leave
        Objexcesoequipaje.icontrol = 2
        fnBuscarexceso()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport
        Dim lsidunidad_origen As String
        Dim lsidunidad_destino As String
        Dim lsidusuario As String
        Dim lsidagencia As String
        Dim lsfecha_inicio As String
        Dim lsfecha_final As String
        'Recuperando los datos 
        lsidunidad_origen = CType(Int(Objexcesoequipaje.coll_Lista_Origen(cmbOrigen.SelectedIndex.ToString)), String)
        If lsidunidad_origen = "9999" Then
            lsidunidad_origen = "NULL"
        End If
        lsidunidad_destino = CType(Int(Objexcesoequipaje.coll_Lista_Destino(cmbDestino.SelectedIndex.ToString)), String)
        If lsidunidad_destino = "9999" Then
            lsidunidad_destino = "NULL"
        End If
        lsidusuario = CType(Int(Objexcesoequipaje.coll_Lista_Usuarios(cmbUsuarios.SelectedIndex.ToString)), String)
        If lsidusuario = "0" Or lsidusuario = "9999" Then
            lsidusuario = "NULL"
        End If
        lsidagencia = CType(Int(Objexcesoequipaje.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString())), String)
        If lsidagencia = "9999" Or lsidagencia = "0" Then
            lsidagencia = "NULL"
        End If
        '--
        lsfecha_inicio = dtFechaInicio.Text
        lsfecha_final = dtFechaFin.Text
        'Impresión 
        ObjReport.rutaRpt = PathFrmReport
        ObjReport.conectar(rptservice, rptuser, rptpass)
        '
        ObjReport.printrpt(False, "", "PAS003.RPT", _
        "P_SUBTITULO;" & "Del " + lsfecha_inicio + " hasta " + lsfecha_final, _
        "NORIGEN;" & lsidunidad_origen, _
        "NDESTINO;" & lsidunidad_destino, _
        "NIDUSUARIO;" & lsidusuario, _
        "NIDAGENCIA;" & lsidagencia, _
        "VFECHA_INICIO;" & lsfecha_inicio, _
        "VFECHA_FINAL;" & lsfecha_final)
        '
    End Sub
    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Try
            Dim idAgencia As Integer
            idAgencia = Int(cmbAgencia.SelectedIndex)
            If idAgencia >= 0 Then
                idAgencia = IIf(cmbAgencia.SelectedIndex.ToString() <> "", Int(Objexcesoequipaje.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString())), 0)
                If Objexcesoequipaje.fnFILTRO_USUARIO_X_AGENCIA_exceso(idAgencia) = True Then
                    'datahelper
                    'ModuUtil.LlenarComboIDs(Objexcesoequipaje.rst_Lista_Usuarios, cmbUsuarios, Objexcesoequipaje.coll_Lista_Usuarios, 0)
                    ModuUtil.LlenarCombo2(Objexcesoequipaje.rst_Lista_Usuarios, cmbUsuarios, Objexcesoequipaje.coll_Lista_Usuarios, 0)
                Else
                    NingunoComboIDs(cmbUsuarios, Objexcesoequipaje.coll_Lista_Usuarios)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        'Recuperando los datos 
        Dim dgrv0 As DataGridViewRow
        Dim s_comprobante As String
        Dim s_idventa_pasaje As String
        Dim lnromensaje As Long
        Dim smensaje As String
        Try
            '
            If Me.dtGridViewControl_pasaje.Rows.Count < 1 Then
                Exit Sub
            End If
            dgrv0 = Me.dtGridViewControl_pasaje.CurrentRow()
            s_comprobante = CType(dgrv0.Cells("nro_comprobante").Value, String)
            Dim resp As DialogResult = MessageBox.Show("Está seguro de eliminar el exceso Nº " & s_comprobante & " ? ", "Recibo por Exceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = Windows.Forms.DialogResult.Yes Then
                s_idventa_pasaje = CType(dgrv0.Cells("idventa_pasajes").Value, String)
                '
                Objexcesoequipaje.sidventa_pasaje = s_idventa_pasaje
                '
                If Objexcesoequipaje.fnElimina_exceso Then
                    'datahelper
                    'lnromensaje = CType(Objexcesoequipaje.rst_elimina_exceso.Fields.Item("codsql").Value, Long)
                    'smensaje = CType(Objexcesoequipaje.rst_elimina_exceso.Fields.Item("msjsql").Value, String)
                    lnromensaje = CType(Objexcesoequipaje.rst_elimina_exceso.Rows(0).Item("codsql"), Long)
                    smensaje = CType(Objexcesoequipaje.rst_elimina_exceso.Rows(0).Item("msjsql"), String)
                    If lnromensaje <> 0 Then
                        MsgBox(smensaje, MsgBoxStyle.Exclamation, "Venta de Pasajes")
                    Else
                        'Refresca la pantalla 
                        Objexcesoequipaje.icontrol = 1
                        fnBuscarexceso()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub TXTNRO_COMPROBANTE_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTNRO_COMPROBANTE.Leave
        Me.TXTNRO_COMPROBANTE.Text = RellenoRight(inro_Digitos_Ventas, Me.TXTNRO_COMPROBANTE.Text)
    End Sub
    Private Sub AnularToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularToolStripMenuItem.Click
        'Recuperando los datos 
        Dim dgrv0 As DataGridViewRow
        Dim s_comprobante As String
        Dim s_idventa_pasaje As String
        Dim lnromensaje As Long
        Dim smensaje As String
        Try
            '
            If Me.dtGridViewControl_pasaje.Rows.Count < 1 Then
                Exit Sub
            End If
            dgrv0 = Me.dtGridViewControl_pasaje.CurrentRow()
            s_comprobante = CType(dgrv0.Cells("nro_comprobante").Value, String)
            Dim resp As DialogResult = MessageBox.Show("Está seguro de anular el exceso Nº " & s_comprobante & " ? ", "Recibo por Exceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = Windows.Forms.DialogResult.Yes Then
                s_idventa_pasaje = CType(dgrv0.Cells("idventa_pasajes").Value, String)
                '
                Objexcesoequipaje.sidventa_pasaje = s_idventa_pasaje
                '
                If Objexcesoequipaje.fnanular_exceso Then
                    'datahelper
                    'lnromensaje = CType(Objexcesoequipaje.rst_anular_exceso.Fields.Item("codsql").Value, Long)
                    'smensaje = CType(Objexcesoequipaje.rst_anular_exceso.Fields.Item("msjsql").Value, String)
                    lnromensaje = CType(Objexcesoequipaje.rst_anular_exceso.Rows(0).Item("codsql"), Long)
                    smensaje = CType(Objexcesoequipaje.rst_anular_exceso.Rows(0).Item("msjsql"), String)
                    If lnromensaje <> 0 Then
                        MsgBox(smensaje, MsgBoxStyle.Exclamation, "Venta de Pasajes")
                    Else
                        'Refresca la pantalla 
                        Objexcesoequipaje.icontrol = 1
                        fnBuscarexceso()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub
    Private Sub cmb_agencia_origen_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_agencia_origen.SelectedValueChanged
        Dim ls_ciudad As String
        Dim ll_agencia_origen As Long
        Try
            If bno_lee_condicion = True Then
                get_nombre_agencia()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
    Sub get_nombre_agencia()
        Dim ls_ciudad As String
        Dim ll_agencia_origen As Long
        Try
            Dim dr_agencias As DataRowView
            dr_agencias = dvagencias_origen.Item(Me.cmb_agencia_origen.SelectedIndex)
            ls_ciudad = CType(dr_agencias("ciudad"), String)
            Me.txt_ciudad_origen.Text = ls_ciudad
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
    Function fn_valida_ciudad() As Boolean
        '
        Dim dr_agencias As DataRowView
        Dim ll_idunidad_agencia As String
        Dim b_valida As Boolean
        '
        Try
            b_valida = True
            dr_agencias = dvagencias_origen.Item(Me.cmb_agencia_origen.SelectedIndex)
            ll_idunidad_agencia = CType(dr_agencias("idunidad_agencia"), String)
            If ll_idunidad_agencia = lidUnidadAgencias_destino Then
                '
                MsgBox("El destino coincide con la ciudad origen (agencia), ¿verificar?", MsgBoxStyle.Information, "Venta Boleto")
                b_no_lee_campo = False
                Me.cmbagenciadestino.SelectedValue = 0
                Me.txtidunidadagencia.Text = ""
                Me.txtiWinDestino.Text = ""
                Me.txtidunidadagencia.Focus()
                b_valida = False
                b_no_lee_campo = True
                '
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
        Return b_valida
    End Function
    Sub recupera_agencia_destino(ByVal ll_idunidad_agencia)
        Dim dr_agencias As DataRowView
        Dim ll_fila, ll_tot_fila As Long
        Dim ll_idunidad_agencia_local, ll_idagencia As Long
        Try
            ll_tot_fila = dvagencias.Count
            For ll_fila = 0 To ll_tot_fila - 1
                'dvagencias Recupera la agencia del destino 
                dr_agencias = dvagencias.Item(ll_fila)
                ll_idunidad_agencia_local = CType(dr_agencias("idunidad_agencia"), Long)
                'Objexcesoequipaje.fnGetAgencias(idUnidadAgencias)
                'ModuUtil.LlenarComboIDs(Objexcesoequipaje.rst_agencias, Me.cmbagenciadestino, Objexcesoequipaje.coll_agencia, Int(Objexcesoequipaje.rst_agencias.Fields(0).Value))
                If ll_idunidad_agencia = ll_idunidad_agencia_local Then
                    ll_idagencia = CType(dr_agencias("idagencias"), Long)
                    If ll_idunidad_agencia = 5100 Then
                        Me.cmbagenciadestino.SelectedValue = 51 ' Solo Lima por defecto será JP
                    Else
                        Me.cmbagenciadestino.SelectedValue = ll_idagencia
                    End If
                    Exit Sub
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevo.EnabledChanged, btneditar.EnabledChanged, btnVerData.EnabledChanged, btnImprimir.EnabledChanged, btnCerrar.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
