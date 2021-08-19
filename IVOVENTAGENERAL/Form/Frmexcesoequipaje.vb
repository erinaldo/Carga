Imports AccesoDatos
Imports INTEGRACION_LN

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
    Dim IGV As Double = dtoUSUARIOS.iIGV  ' dtoUSUARIOS.iIGV '/ 100  ' Recupera el valor de la bd, pero en pasaje no es necesario 
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

    Dim bIngreso As Boolean = False
    Public hnd As Long

    '
#End Region

    Private Sub Frmexcesoequipaje_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmexcesoequipaje_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load        
        Try
            Dim dv_comprobante As New DataView
            Dim dv_concepto As New DataView
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
                '
                dtdocumento = Objexcesoequipaje.rst_documento
                '
                bno_lee_condicion = False
                '20/07/2010  - 
                'ModuUtil.LlenarCombo2(Objexcesoequipaje.rst_documento, , Objexcesoequipaje.coll_documento, 15)                
                dv_concepto = CargarCombo(cmbtipocomprobante, Objexcesoequipaje.rst_documento, "tipo_comprobante", "idtipo_comprobante", 15) ' Por defecto siempre es por exceso 
                dv_comprobante = CargarCombo(cmb_comprobante, Objexcesoequipaje.rst_tipo_comprobante, "comprobante", "idtipo_comprobante", 0) ' Por defecto siempre es 0 sin comprobante 
                '
                dtagencias = Objexcesoequipaje.rst_agencias
                '
                dt_agencias_origen = dtagencias.Copy
                dvagencias_origen = CargarCombo(Me.cmb_agencia_origen, dt_agencias_origen, "nombre_agencia", "idagencias", dtoUSUARIOS.iIDAGENCIAS)
                dvagencias = CargarCombo(Me.cmbagenciadestino, dtagencias, "nombre_agencia", "idagencias", -1)
                '19/07/2010 - Configurando por defecto 
                cmb_comprobante.SelectedValue = 0 ' Por defecto se considera 0 (Signifca nulo) 
                '
                bno_lee_condicion = True
                'Recupera la tarjeta de credito 
                dttarjeta = Objexcesoequipaje.rst_tarjeta_credito
                dvtarjeta = CargarCombo(Me.cmbtarjeta, dttarjeta, "descripcion", "idtarjetas", -666)

                fnCargar_iWin_dt(txtiWinDestino, Objexcesoequipaje.rst_unidad_agencia, coll_iDestino, iWinDestino, 0)
                Me.cmbagenciadestino.SelectedIndex = -1

            End If

            '19/07/2010 Desahabilito p'q' solo es el exceso también Delivery se trabaja por acá
            'Me.cmbtipocomprobante.Enabled = False
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
            If Objexcesoequipaje.fnFILTRO_USUARIO_X_AGENCIA_exceso(dtoUSUARIOS.m_iIdAgencia, Me.dtFechaInicio.Value.ToShortDateString, Me.dtFechaFin.Value.ToShortDateString) = True Then
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
                'If IsDBNull(Objexcesoequipaje.Serie) = True Or RellenoRight(inro_Digitos_SerieVentas, Objexcesoequipaje.Serie) = "000" Then
                '    MessageBox.Show("No ha configurado la serie del exceso", "Venta de Pasajes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Me.Close()
                '    Exit Sub
                'End If
                TXTSER_COMPROBANTE.Text = "" 'RellenoRight(inro_Digitos_SerieVentas, Objexcesoequipaje.Serie)
                TXTNRO_COMPROBANTE.Text = "" 'RellenoRight(inro_Digitos_Ventas, Objexcesoequipaje.NroDoc)
            End If
            b_no_lee_campo = True
            '
            Me.txtidunidadagencia.Focus()
            get_nombre_agencia()
            '20/07/2010 - Configuración de comprobante de venta 
            configura_comprobante_venta()

            cmbtipocomprobante.SelectedIndex = 0

            btneditar.Enabled = dtoUSUARIOS.IdRol = 1036


            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

            '
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
        'Try
        '    If Txtdni.Text <> "" Then
        '        Txtdni.Text = RellenoRight(8, Txtdni.Text)
        '        '
        '        If Txtdni.Text.Length <> 8 Then
        '            MsgBox("El Nº de Documento no es válido ", MsgBoxStyle.Information, "Seguridad Sistema")
        '            e.Cancel = True
        '        End If
        '    End If
        'Catch ex As Exception
        '    '
        'End Try
    End Sub

    Private Sub Txtdni_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdni.Leave
        'Recupera los datos y colocas el valor 
        Try
            If b_no_lee_campo = True Then
                If Txtdni.Text = "" Then
                    lidpersona = 0
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
                lidpersona = 0
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
            fn_grabar_exceso()
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

            'If Me.cmb_comprobante.SelectedValue = 1 Then
            '    If Not fnValidarRUC(Me.Txtdni.Text.Trim) Then
            '        MessageBox.Show("Ingrese RUC válido","",MessageBoxButtons.OK,
            '    End If
            'End If

            If Me.cmb_comprobante.SelectedValue = 1 Then
                If Not fnValidarRUC(Me.Txtdni.Text.Trim) Then
                    MessageBox.Show("Ingrese RUC Válido", "Otros Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Txtdni.Text = Me.Txtdni.Text.Trim
                    Me.Txtdni.Focus()
                    Exit Sub
                End If
            Else
                If Me.Txtdni.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese DNI del Cliente", "Otros Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Txtdni.Text = Me.Txtdni.Text.Trim
                    Me.Txtdni.Focus()
                    Exit Sub
                End If
            End If

            If Me.txtpasajero.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombre del Cliente", "Otros Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtpasajero.Text = Me.txtpasajero.Text.Trim
                Me.txtpasajero.Focus()
                Exit Sub
            End If

            If Me.txttotal.Text = "0.00" Or Me.txttotal.Text = "" Then
                MessageBox.Show("Ingrese Monto Total", "Otros Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            '-- Valida si es delivery o Exceso 
            If Me.cmbtipocomprobante.SelectedValue = 15 Then '19/07/2010 Si es exceso debe validar 
                '
                If lidUnidadAgencias_destino = ll_idunidad_origen Then
                    MsgBox("El destino coincide con la ciudad origen (agencia), ¿verificar?", MsgBoxStyle.Information, "Venta Exceso")
                    Me.cmbagenciadestino.SelectedValue = 0
                    Me.txtidunidadagencia.Text = ""
                    Me.txtiWinDestino.Text = ""
                    Me.txtidunidadagencia.Focus()
                    Exit Sub
                End If
            End If
            '''''''''''''''''
            Objexcesoequipaje.icontrol = li_control
            If Me.txtidventa_pasaje.Text = "" Or IsDBNull(Me.txtidventa_pasaje.Text) = True Then
                Objexcesoequipaje.sidventa_pasaje = "null"
            Else
                Objexcesoequipaje.sidventa_pasaje = Me.txtidventa_pasaje.Text
            End If
            If IsDBNull(lidpersona) = True Or lidpersona = 0 Then
                Objexcesoequipaje.sidpersona_dni = 0
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
            'Modificado 20-jul-2010  
            'Objexcesoequipaje.lidtipo_comprobante = Int(Objexcesoequipaje.coll_documento(Me.cmbtipocomprobante.SelectedIndex.ToString)) 'Int(Me.cmbtipocomprobante.SelectedValue)
            Objexcesoequipaje.lidtipo_comprobante = Me.cmbtipocomprobante.SelectedValue
            '
            If Me.cmbtipocomprobante.SelectedValue <> 15 Then '19/07/2010 Debe validar el ingreso de la serie del Delivery
                If Me.cmb_comprobante.SelectedValue = 0 Then
                    MsgBox("Debe ingresar el comprobante para el delivery", MsgBoxStyle.Information, "Venta Exceso")
                    Me.cmb_comprobante.Focus()
                    Exit Sub
                End If
                Objexcesoequipaje.ll_idtipo_comprobante_d = Me.cmb_comprobante.SelectedValue
            End If
            '
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
                            TXTSER_COMPROBANTE.Text = "" 'RellenoRight(inro_Digitos_SerieVentas, Objexcesoequipaje.Serie)
                            TXTNRO_COMPROBANTE.Text = "" 'RellenoRight(inro_Digitos_Ventas, Objexcesoequipaje.NroDoc)
                        End If
                    End If
                End If



                '************************************************************************************
                '-->EMISION DE LA FE - jabanto - 20/06/2016
                '************************************************************************************
                If (Objexcesoequipaje.dt_datosVenta.Rows.Count > 0) Then
                    Dim dataRow As DataRow = Objexcesoequipaje.dt_datosVenta.Rows(0)

                    Dim cliente As New FECliente
                    cliente.tipoDocumentoID = dataRow.Item("idtipo_doc_identidad")
                    cliente.tipoDocumento = dataRow.Item("tipo_doc_identidad")
                    cliente.numeroDocumento = dataRow.Item("nu_docu_suna")
                    cliente.nombres = dataRow.Item("razon_social")

                    Dim venta As New FEVenta
                    venta.cliente = cliente
                    venta.isCredito = False
                    venta.numeroSerie = dataRow.Item("serie_comprobante")
                    venta.numeroCorrelativo = dataRow.Item("nro_comprobante")
                    venta.isMonedaSoles = True
                    venta.fechaEmision = dataRow.Item("fecha_emision")
                    venta.tipoComprobanteID = dataRow.Item("idtipo_comprobante_d")
                    venta.total = dataRow.Item("monto_total")
                    venta.opGravada = FormatNumber(venta.total / ((FEManager.VAL_IGV / 100) + 1), 2)
                    venta.igv = FormatNumber(venta.total - venta.opGravada, 2)
                    venta.totalLetras = ConvercionNroEnLetras(venta.total)
                    venta.isSOUE = True
                    '-->Para la impresion
                    venta.producto = "---"
                    venta.origen = "---"
                    venta.destino = "---"
                    venta.remitenete = "---"
                    venta.consignado = "---"
                    venta.tipoEntrega = "---"
                    venta.direccionEntrega = "---"
                    venta.agenciaEmision = dtoUSUARIOS.m_iNombreAgencia
                    venta.usuarioEmision = dtoUSUARIOS.NameLogin
                    venta.formaPago = dataRow.Item("tipo_pago")
                    venta.id = dataRow.Item("idventa_pasajes")
                    venta.tabla = "T_VENTA_PASAJES"

                    Dim detalleVenta As New FEDetalleVenta
                    detalleVenta.descripcion = dataRow.Item("tipo_comprobante")
                    detalleVenta.cantidad = 1
                    detalleVenta.tarifa = venta.total
                    detalleVenta.unidadMedida = FEManager.SUNAT_UNIMED_UNIDAD

                    Dim listaDetalle As New List(Of FEDetalleVenta)
                    listaDetalle.Add(detalleVenta)
                    venta.detalleVenta = listaDetalle


                    'Dim result = FEManager.result
                    Dim result = FEManager.sendVentaSunat(venta, FEManager.buscarPrint)
                    If (result.IsCorrect) Then
                        Dim objFac As New ClsLbTepsa.dtoFACTURA
                        Dim idFactura As Long = dataRow.Item("idventa_pasajes")
                        objFac.actualizarEmisonFE(idFactura, "T_VENTA_PASAJES")
                    End If
                    MessageBox.Show(result.Message, "Emisión F.E.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                'MessageBox.Show("Registro Actualizado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            '
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
            '
            Me.txt_total.Text = "0.00"
            Me.lab_total.Text = "Total x Exceso : "
            dtGridViewControl_pasaje.DataSource = Nothing
            '
            dtGridViewControl_pasaje.Columns.Clear()
            '
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
                .Visible = True
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

            Dim col_n_emife As New DataGridViewTextBoxColumn
            With col_n_emife '10
                .DisplayIndex = 12
                .DataPropertyName = "n_emife"
                .Name = "n_emife"
                .HeaderText = "n_emife"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_pasaje.Columns.Add(col_n_emife)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Objexcesoequipaje.icontrol = 1
        If Me.RB_exceso.Checked = True Then
            fnLoadGrid()
            fnBuscarexceso()
        Else
            fnLoadGrid_DELIVERY()
            fnBuscar_delivery()
        End If
        resumen_total()
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
            If Me.RB_exceso.Checked = True Then
                Objexcesoequipaje.sidventa_pasajes = CType(dtGridViewControl_pasaje.Rows(row).Cells(11).Value, String)
            Else
                Objexcesoequipaje.sidventa_pasajes = CType(dtGridViewControl_pasaje.Rows(row).Cells(12).Value, String)
            End If
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
            'If Me.dtGridViewControl_pasaje.CurrentRow.Cells("n_emife").Value = 0 Then
            'Me.btngrabar.Enabled = False
            'Else
            'Me.btngrabar.Enabled = True
            'End If
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
        If Me.RB_exceso.Checked = True Then
            fnBuscarexceso()
        Else
            fnBuscar_delivery()
        End If
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
        If Me.RB_Delivery.Checked = True Then
            lsidunidad_destino = "NULL"
        End If
        '--
        lsfecha_inicio = dtFechaInicio.Text
        lsfecha_final = dtFechaFin.Text
        'Impresión 
        ObjReport.rutaRpt = PathFrmReport
        ObjReport.conectar(rptservice, rptuser, rptpass)
        '
        If RB_exceso.Checked = True Then
            ObjReport.printrpt(False, "", "PAS003.RPT", _
            "P_SUBTITULO;" & "Del " + lsfecha_inicio + " hasta " + lsfecha_final, _
            "NORIGEN;" & lsidunidad_origen, _
            "NDESTINO;" & lsidunidad_destino, _
            "NIDUSUARIO;" & lsidusuario, _
            "NIDAGENCIA;" & lsidagencia, _
            "VFECHA_INICIO;" & lsfecha_inicio, _
            "VFECHA_FINAL;" & lsfecha_final)
        Else
            ObjReport.printrpt(False, "", "PAS005.RPT", _
            "P_SUBTITULO;" & "Del " + lsfecha_inicio + " hasta " + lsfecha_final, _
            "NORIGEN;" & lsidunidad_origen, _
            "NIDUSUARIO;" & lsidusuario, _
            "NIDAGENCIA;" & lsidagencia, _
            "VFECHA_INICIO;" & lsfecha_inicio, _
            "VFECHA_FINAL;" & lsfecha_final)
        End If
    End Sub
    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Try
            Dim idAgencia As Integer
            idAgencia = Int(cmbAgencia.SelectedIndex)
            If idAgencia >= 0 Then

                idAgencia = IIf(cmbAgencia.SelectedIndex.ToString() <> "", Int(Objexcesoequipaje.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString())), 0)
                If Objexcesoequipaje.fnFILTRO_USUARIO_X_AGENCIA_exceso(idAgencia, Me.dtFechaInicio.Value.ToShortDateString, Me.dtFechaFin.Value.ToShortDateString) = True Then
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
        Return
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
            Dim resp As DialogResult = MessageBox.Show("Está seguro de anular el Comprobante Nº " & s_comprobante & " ? ", "Anular Comprobante", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = Windows.Forms.DialogResult.Yes Then
                s_idventa_pasaje = CType(dgrv0.Cells("idventa_pasajes").Value, String)
                Objexcesoequipaje.sidventa_pasaje = s_idventa_pasaje

                Dim intOrigen As Integer = 0
                Dim strFecha As String = Me.dtGridViewControl_pasaje.CurrentRow.Cells("fecha_emision").Value
                Dim strFechaServidor As String = FechaServidor(1)
                Dim dias As Long = DateDiff(DateInterval.Day, CType(strFecha, Date), CType(strFechaServidor, Date))
                If dias <= 3 Then 'validar si mes de comprobante es diferente a mes del sistema
                    If DatePart(DateInterval.Month, CDate(strFecha)) <> DatePart(DateInterval.Month, CDate(strFechaServidor)) Then
                        intOrigen = 2
                    Else
                        intOrigen = 1
                    End If
                Else
                    intOrigen = 2
                End If

                If intOrigen = 2 Then 'Cancelación por nota de crédito
                    'Genera Nota de credito
                    Dim obj As New dtoexcesoequipaje
                    Dim dataRowNota
                    Dim noteTotal As Double
                    Dim noteSubTotal As Double
                    Dim noteImpuesto As Double
                    Dim intComprobante As Integer
                    Dim intOperacion As Integer
                    Dim strGlosa As String
                    Dim dblSubtotal As Double, dblImpuesto As Double, dblTotal As Double
                    Dim intUsuario As Integer, intAgencia As Integer, strIp As String
                    intUsuario = dtoUSUARIOS.IdLogin
                    intAgencia = dtoUSUARIOS.iIDAGENCIAS
                    strIp = dtoUSUARIOS.IP

                    intComprobante = Me.dtGridViewControl_pasaje.CurrentRow.Cells("idventa_pasajes").Value
                    strFecha = Format(Now, "dd/MM/yyyy")
                    intOperacion = 18 'Me.dtGridViewControl_pasaje.CurrentRow.Cells("idtipo_operacion").Value
                    strGlosa = "ANULACION DE LA OPERACION" 'Me.dtGridViewControl_pasaje.CurrentRow.Cells("tipo_operacion").Value

                    dblTotal = Me.dtGridViewControl_pasaje.CurrentRow.Cells("monto_total").Value
                    dblSubtotal = dblTotal / (1 + (dtoUSUARIOS.iIGV / 100))
                    dblImpuesto = dblTotal - dblSubtotal
                    dblTotal = Format(dblTotal * -1, "0.00")
                    dblSubtotal = Format(dblSubtotal * -1, "0.00")
                    dblImpuesto = Format(dblImpuesto * -1, "0.00")

                    noteTotal = dblTotal * -1
                    noteSubTotal = dblSubtotal * -1
                    noteImpuesto = dblImpuesto * -1
                    dataRowNota = obj.GrabarNotaCredito(30, intComprobante, strFecha, intOperacion, _
                                          strGlosa, intAgencia, dblSubtotal, dblImpuesto, dblTotal, _
                                          intUsuario, strIp)


                    '========================================================================================
                    '-->GENERA LA NOTA DE CREDITO Y LA FACTURA Y/O BOLETA ELECTRONICA - jabanto - 07/06/2016
                    '========================================================================================
                    'Busca el Comprobante original
                    Dim strComprobante As String = dtGridViewControl_pasaje.CurrentRow.Cells("serie_comprobante").Value & "-" & dtGridViewControl_pasaje.CurrentRow.Cells("nro_comprobante").Value
                    Dim comprobanteReferenciaID As String = dtGridViewControl_pasaje.CurrentRow.Cells("idtipo_comprobante").Value 'dgvLista.CurrentRow.Cells("idtipo").Value
                    Dim comprobanteReferenciaNumero As String = strComprobante
                    Dim comprobanteReferenciaFecha As String = dtGridViewControl_pasaje.CurrentRow.Cells("fecha_emision").Value

                    '-->Nota de credito
                    '******************************
                    Dim fenote As FENota = Nothing
                    If Not (dataRowNota Is Nothing) Then
                        Dim fecliente As New FECliente
                        fecliente.tipoDocumentoID = dataRowNota(3).ToString
                        fecliente.numeroDocumento = dataRowNota(4).ToString
                        fecliente.nombres = dataRowNota(5).ToString
                        If Not (IsDBNull(dataRowNota(6))) Then _
                            fecliente.direccion = dataRowNota(6).ToString

                        Dim documentoReferencia As New FEDocumentoReferencia
                        documentoReferencia.tipoDocumentoID = comprobanteReferenciaID
                        documentoReferencia.numeroDocumento = comprobanteReferenciaNumero
                        documentoReferencia.fechaEmision = comprobanteReferenciaFecha

                        fenote = New FENota
                        fenote.numeroSerie = dataRowNota(0).ToString()
                        fenote.numeroCorrelativo = dataRowNota(1).ToString()
                        fenote.cliente = fecliente
                        fenote.documentoReferencia = documentoReferencia
                        fenote.fechaEmison = FechaServidor()
                        fenote.igv = noteImpuesto
                        fenote.subTotal = noteSubTotal
                        fenote.total = noteTotal
                        fenote.tipoNota = "01" 'DirectCast(dgvLista.CurrentRow.Tag, DataRow)("codigo_sunat")
                        fenote.descripcionTipoNota = "ANULACION DE LA OPERACION" 'DirectCast(dgvLista.CurrentRow.Tag, DataRow)("descripcion_sunat")
                        fenote.totalLentras = ConvercionNroEnLetras(fenote.total)
                        fenote.descripcionSustento = strGlosa.Trim.ToUpper()
                        'hlamas 12-04-2017
                        fenote.agenciaId = dtoUSUARIOS.iIDAGENCIAS
                        fenote.usuarioID = dtoUSUARIOS.IdLogin
                        fenote.usuarioInsercion = dtoUSUARIOS.IdLogin
                        fenote.usuarioModificacion = dtoUSUARIOS.IdLogin

                        fenote.id = dataRowNota(2)
                        fenote.tabla = "T_VENTA_PASAJES"
                        fenote.isMonedaSoles = True
                        Try
                            '-->Aplica Solamente una nota de credito
                            Dim result = FEManager.sendNota(fenote, True)
                            If (result.isCorrect) Then
                                Dim idNotaCredito As Long = dataRowNota(2)
                                Dim objFac As New ClsLbTepsa.dtoFACTURA
                                objFac.actualizarEmisonFE(idNotaCredito, "T_VENTA_PASAJES")
                            End If
                            MessageBox.Show(result.Message, "Respuesta WSSunat", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Catch ex As Exception
                            MessageBox.Show("La Nota de Crédito Electrónica no pudo ser registrada, por favor comuníquese con el Area de Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If


                Else 'Anulación
                    Dim frm As New frmMotivoAnulacion
                    frm.ShowDialog()
                    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                        Dim strMotivo As String = frm.txtMotivo.Text.Trim
                        'Dim strFecha1 As String = DateAdd(DateInterval.Day, 1, Me.dtGridViewControl_pasaje.CurrentRow.Cells("fecha_emision").Value)
                        'Dim strFechaServidor As String = FechaServidor(1)
                        'Dim dias As Long = DateDiff(DateInterval.Day, CType(strFecha1, Date), CType(strFechaServidor, Date))
                        'If dias > 3 Then
                        'MessageBox.Show("El Comprobante ha excedido el plazo de 3 dias, No podrá ser Anulado", "Otros Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Return
                        'End If

                        'hlamas 01-06-2016
                        'Valida si comprobante puede ser anulado
                        Dim iTipo As Integer = cmb_comprobante.SelectedValue
                        Dim strTipo As String = IIf(iTipo = 1, "01", "03")
                        Dim strSerie As String = Me.dtGridViewControl_pasaje.CurrentRow.Cells("serie_comprobante").Value 'IIf(iTipo = 1, "F", "B") & strComprobante.Substring(0, intPosicion - 1)
                        Dim strNumero As String = Me.dtGridViewControl_pasaje.CurrentRow.Cells("nro_comprobante").Value
                        strNumero = strNumero.PadLeft(8, "0")
                        Dim blnAnulable As Boolean = FEManager.isAvoidable(strTipo, strFecha, strSerie, strNumero, strMotivo)
                        If Not blnAnulable Then
                            Cursor = Cursors.Default
                            MessageBox.Show("El Comprobante no puede ser Anulado F.E.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
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
    Private Sub cmbtipocomprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtipocomprobante.SelectedIndexChanged
        '19/07/2010 - Modificado 
        If b_no_lee_campo Then
            configura_comprobante_venta()
        End If
    End Sub
    Sub configura_comprobante_venta()
        Try
            If cmbtipocomprobante.SelectedValue <> "15" Then
                lab_comprobante.Visible = True
                cmb_comprobante.Visible = True
                TXTSER_COMPROBANTE.Enabled = True
                '
                txtidunidadagencia.Enabled = False
                txtidunidadagencia.Text = ""
                txtiWinDestino.Text = ""
                cmbagenciadestino.SelectedValue = 0
                '
                txtiWinDestino.Enabled = False
                cmbagenciadestino.Enabled = False
                Me.cmb_comprobante.SelectedValue = 2 ' Por defecto tiene que se Boleta de Venta 
            Else
                lab_comprobante.Visible = False
                cmb_comprobante.Visible = False
                cmb_comprobante.SelectedValue = 0
                '
                txtidunidadagencia.Enabled = True
                txtiWinDestino.Enabled = True
                cmbagenciadestino.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Public Function fnBuscar_delivery() As Boolean
        Try
            Objexcesoequipaje.lidunidad_agencia_ori = Int(Objexcesoequipaje.coll_Lista_Origen(cmbOrigen.SelectedIndex.ToString))
            If Objexcesoequipaje.lidunidad_agencia_ori = 9999 Then
                Objexcesoequipaje.lidunidad_agencia_ori = -666
            End If
            'Objexcesoequipaje.lidunidad_agencia_des = Int(Objexcesoequipaje.coll_Lista_Destino(cmbDestino.SelectedIndex.ToString))
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
            If Objexcesoequipaje.FnControl_Delivery() = True Then
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
    Private Sub RB_Delivery_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Delivery.CheckedChanged
        If RB_Delivery.Checked = True Then
            fnLoadGrid_DELIVERY()
            cmbDestino.Visible = False
        Else
            cmbDestino.Visible = True
        End If
    End Sub
    Private Sub RB_exceso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_exceso.CheckedChanged
        If RB_exceso.Checked = True Then
            fnLoadGrid()
            cmbDestino.Visible = True
        Else
            cmbDestino.Visible = False
        End If
    End Sub
    Private Sub TabMante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabMante.SelectedIndexChanged
        Select Case TabMante.SelectedIndex
            Case 0
                RB_Delivery.Checked = True ' Por defecto está activo 
        End Select
    End Sub
    Public Function fnLoadGrid_DELIVERY() As Boolean
        Try
            '
            Me.txt_total.Text = "0.00"
            Me.lab_total.Text = "Total x Delivery : "
            dtGridViewControl_pasaje.DataSource = Nothing
            '
            dtGridViewControl_pasaje.Columns.Clear()
            '
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
            '
            Dim colpor As New DataGridViewTextBoxColumn
            With colpor  '0
                .DisplayIndex = 0
                .DataPropertyName = "Por"
                .Name = "Por"
                .HeaderText = "Por"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colpor)



            Dim colTipo_Comprobante As New DataGridViewTextBoxColumn
            With colTipo_Comprobante  '0
                .DisplayIndex = 1
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
                .DisplayIndex = 2
                .DataPropertyName = "serie_comprobante"
                .Name = "serie_comprobante"
                .HeaderText = "Serie"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colserie_comprobante)

            Dim colnro_comprobante As New DataGridViewTextBoxColumn
            With colnro_comprobante '2
                .DisplayIndex = 3
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
                .DisplayIndex = 4
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
                .DisplayIndex = 5
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
                .DisplayIndex = 6
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
                .DisplayIndex = 7
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
                .DisplayIndex = 8
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
                .DisplayIndex = 9
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
                .DisplayIndex = 10
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
                .DisplayIndex = 11
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
                .DisplayIndex = 12
                .DataPropertyName = "idventa_pasajes"
                .Name = "idventa_pasajes"
                .HeaderText = "idVtaPasaje"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_pasaje.Columns.Add(colidventa_pasajes)

            Dim col_n_emife As New DataGridViewTextBoxColumn
            With col_n_emife '10
                .DisplayIndex = 13
                .DataPropertyName = "n_emife"
                .Name = "n_emife"
                .HeaderText = "n_emife"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_pasaje.Columns.Add(col_n_emife)

            Dim col_idtipo_Comprobante As New DataGridViewTextBoxColumn
            With col_idtipo_Comprobante  '0
                .DisplayIndex = 0
                .DataPropertyName = "idtipo_Comprobante"
                .Name = "idtipo_Comprobante"
                .HeaderText = "idtipo_comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_pasaje.Columns.Add(col_idtipo_Comprobante)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Function
    Sub resumen_total()
        Dim ld_monto_total As Double = 0.0
        Dim ll_fila As Long
        '--  
        For ll_fila = 0 To dtGridViewControl_pasaje.Rows.Count - 1
            ld_monto_total = ld_monto_total + CType(dtGridViewControl_pasaje.Rows(ll_fila).Cells("monto_total").Value, Double)
        Next
        '-- 
        Me.txt_total.Text = FormatNumber(ld_monto_total, 2)
    End Sub
    Public Sub fnControl_ventadelivery(ByVal rflag As Boolean)
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
                    If Objexcesoequipaje.lidtipo_comprobante1 <> 15 Then
                        Me.cmb_comprobante.SelectedValue = Objexcesoequipaje.ll_idtipo_comprobante_d
                    End If
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

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevo.EnabledChanged, btneditar.EnabledChanged, btnVerData.EnabledChanged, btnImprimir.EnabledChanged, btnCerrar.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub cmb_comprobante_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmb_comprobante.SelectedIndexChanged
        If IsReference(cmb_comprobante.SelectedValue) Then Return
        If cmb_comprobante.SelectedValue = 1 Then
            Txtdni.MaxLength = 11
            Label5.Text = "RUC"
        Else
            Txtdni.MaxLength = 8
            Label5.Text = "DNI"
        End If
    End Sub

    Public Function ValidaNumero(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[0-9\b]") '("^\d+$")  
        If re.IsMatch(txtStr.ToString()) Then
            ValidaNumero = True
        Else
            ValidaNumero = False
        End If
    End Function

    Private Sub txttotal_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txttotal.KeyPress
        If Not ValidarNumeroReal(e.KeyChar, Me.txttotal.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dtGridViewControl_pasaje_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewControl_pasaje.RowEnter
        'If IsNothing(Me.dtGridViewControl_pasaje.Rows(e.RowIndex).Cells("n_emife").Value) Then Return
        'Me.btneditar.Enabled = Me.dtGridViewControl_pasaje.Rows(e.RowIndex).Cells("n_emife").Value = 0
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click

    End Sub

    Private Sub txtpasajero_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtpasajero.KeyPress
        If Not ValidarLetraNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtpasajero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpasajero.TextChanged

    End Sub

    Private Sub Txtdni_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txtdni.TextChanged
        Me.txtpasajero.Text = ""
    End Sub

    Private Sub txttotal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttotal.LostFocus

    End Sub

    Private Sub txttotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttotal.TextChanged

    End Sub
End Class
