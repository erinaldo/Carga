Public Class frmfacturaotro
#Region "Variables"
    Dim dv_persona_factura_otro As New DataView
    Dim dv_direccion As New DataView
    Dim objFACTURA As New ClsLbTepsa.dtoFACTURA
    Dim bIngreso As Boolean = False

    Dim glosa02 As String
    ' Invoca a la Base de Datos 
    'Dim odba As New OleDb.OleDbDataAdapter
    ' Datatable y Dataview   
    Dim dtotra_factura, dtusuario, dttipo_factura, dtforma_pago, dtmoneda, dtrubro, dtdireccion As New DataTable
    Dim dvotra_factura, dvusuario, dvtipo_factura, dvforma_pago, dvmoneda, dvrubro, dvdireccion As New DataView
    ' Declarando Objetos 
    Public coll_Lista_Personas As New Collection
    Public iWinPersona As New AutoCompleteStringCollection
    Public iWinPersonaRUC As New AutoCompleteStringCollection
    Public iWinPersonaRubro As New AutoCompleteStringCollection
    Public iWinrepresentante_legal As New AutoCompleteStringCollection
    ' Variables para el cálculo 
    Dim digv_calculo As Double = dtoUSUARIOS.iIGV
    ' Variable booleanas 
    Dim b_lee_cmb As Boolean = False
    Dim b_lee_cliente As Boolean = False
    Dim b_ingresa_cliente As Boolean = False
    ' Variables en funcion de la serie y el número 
    Dim iserie_Digitos_Ventas As Integer = 3
    Dim inro_Digitos_Ventas As Integer = 7
    ' Variable de Control 
    Dim icontrol As Integer = 0
    Dim lbusqueda As Long = 0
    ' Reporte
    Private ObjReport As ClsLbTepsa.dtoFrmReport
    Public hnd As Long
#End Region
#Region "Eventos"
    'Frm facturado
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try
            If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
                If Not (Me.TXTGLOSA.Focused Or Me.TXTGLOSA_sub_total.Focused) Then
                    SendKeys.Send("{Tab}")
                    Return True
                End If

            End If
            ' Salir del sistema 
            If msg.WParam.ToInt32() = CInt(Keys.Escape) Then
                limpiar_campos()
                SelectMenu(0)
                ToolStripMenuItem1.Enabled = True
                ToolStripMenuItem2.Enabled = False
                icontrol = 0
            End If
            If msg.WParam.ToInt32() = CInt(Keys.F5) Then
                ' Grabar 
                'cambio tecla funcion
                If btngrabar.Enabled Then
                    fn_grabar()
                End If
            End If
            If msg.WParam.ToInt32() = CInt(Keys.F6) Then
                'cambio tecla funcion
                If Me.btnClientes.Enabled Then
                    Me.MantenimientoCliente()
                End If
                'If Not Me.TabMante.SelectedIndex = 1 Then
                '    Exit Function
                'End If
                ''Verificando valores 
                'If Me.txtiddireccion_contacto.Text = "" Then
                '    Mod_otro_facturacion.siddireccion_consignado = "null"
                'Else
                '    Mod_otro_facturacion.siddireccion_consignado = Me.txtiddireccion_contacto.Text
                'End If
                ''
                'Dim a As New FrmMantCltefacturacion
                ''
                'a.dtfrmmantclte_rubro = dtrubro.Copy
                'a.coll_Lista_Personas = coll_Lista_Personas
                'a.iWinPersona = iWinPersona
                'a.iWinPersonaRUC = iWinPersonaRUC
                'a.iWinPersonaRubro = iWinPersonaRubro
                'a.iWinrepresentante_legal = iWinrepresentante_legal
                'If Me.txtidpersona.Text = "" Then
                '    a.txtidpersona.Text = ""
                'Else
                '    a.txtidpersona.Text = Me.txtidpersona.Text
                'End If

                'a.txtiddireccionconsignado.Text = Me.txtiddireccion_contacto.Text

                'If Me.txtcliente.Text = "" Then
                '    a.txtcliente.Text = ""
                'Else
                '    a.txtcliente.Text = Me.txtcliente.Text
                'End If
                'If Me.txtruc.Text = "" Then
                '    a.txtruc.Text = ""
                'Else
                '    a.txtruc.Text = Me.txtruc.Text
                'End If
                'If Me.txtrepresentante_legal.Text = "" Or Me.txtrepresentante_legal.Text = "null" Then
                '    a.txtrepresentante_legal.Text = ""
                'Else
                '    a.txtrepresentante_legal.Text = Me.txtrepresentante_legal.Text
                'End If

                '' Rubro 
                'a.dvfrmmantclte_rubro = CargarCombo(a.cmbrubro_frmmantclte, a.dtfrmmantclte_rubro, "rubro", "idrubro", -666)
                'a.cmbrubro_frmmantclte.SelectedValue = Me.cmbrubro.SelectedValue
                'Dim resultado As DialogResult

                ''resultado = a.ShowDialog()
                'Acceso.Asignar(a, Me.hnd)
                'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                '    resultado = a.ShowDialog()
                'Else
                '    MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Exit Function
                'End If

                ' ''Recuperando los valores para actualizar en lo que es la dirección y consignado 
                'If Not ModSolRecojoCarga.bcancelar Then
                '    Recupera_datos_clientes()
                'End If
                ''
                'Dim indexof As Integer = 0
                'b_lee_cliente = True
                'b_ingresa_cliente = False
                'If Me.txtruc.Text <> "" Then
                '    If iWinPersona.Count > 0 Then
                '        indexof = iWinPersonaRUC.IndexOf(txtruc.Text)
                '        If indexof >= 0 Then
                '            objOtras_facturas.sidpersona = coll_Lista_Personas(indexof.ToString)
                '            Me.txtidpersona.Text = objOtras_facturas.sidpersona
                '            If indexof <= iWinPersona.Count Then
                '                Me.txtcliente.Text = iWinPersona.Item(indexof)
                '                Me.cmbrubro.SelectedValue = iWinPersonaRubro.Item(indexof)
                '                Me.txtrepresentante_legal.Text = iWinrepresentante_legal.Item(indexof)
                '                '
                '                'Recupera Dirección Legal del Cliente 
                '                recupera_direccion(Me.txtidpersona.Text)
                '                b_lee_cliente = False
                '            End If
                '        Else
                '            b_ingresa_cliente = True
                '            'MsgBox("Cliente no encontrado...", MsgBoxStyle.Information, "Seguridad Sistema")
                '        End If
                '    End If
                'End If
            End If
            'If msg.WParam.ToInt32() = CInt(Keys.F10) Then
            '    b_no_lee_campo = False
            '    Me.txtiWinDestino.Focus()   ' Destino 
            'End If
            'If msg.WParam.ToInt32() = CInt(Keys.F11) Then
            '    b_no_lee_campo = False
            '    Me.cmbcondicion.Focus()   ' Condición de Pago 
            'End If
            'If msg.WParam.ToInt32() = CInt(Keys.F2) Then
            '    b_no_lee_campo = False
            '    Me.txtruc.Focus()   ' Ruc 
            'End If
            'If msg.WParam.ToInt32() = CInt(Keys.F4) Then
            '    b_no_lee_campo = False
            '    Me.txtiWinorigen.Focus()   ' 
            'End If
            'If msg.WParam.ToInt32() = CInt(Keys.Shift + Keys.Tab) Then
            '    b_no_lee_campo = False
            'End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Function
    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtruc.KeyPress, txtserie.KeyPress, txtnro_factura.KeyPress
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

    Private Sub frmfacturaotro_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmfacturaotro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    'frmotrosingresos (events) 
    Private Sub frmotrosingresos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.cboTipoComprobante.SelectedIndex = 0
            dtoUSUARIOS.m_iNombreUnidadAgencia = fnGetCiudad(dtoUSUARIOS.m_idciudad.ToString)
            dtoUSUARIOS.m_iNombreAgencia = fnGetAGENCIA(dtoUSUARIOS.m_iIdAgencia.ToString)
            Me.Text = "FACTURAS ADICIONALES..." & dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & " [ " & dtoUSUARIOS.m_iNombreAgencia & " ][ " & dtoUSUARIOS.m_iNombreUnidadAgencia & "] "
            ToolStripMenuItem1.Text = "&BUSCAR"
            ToolStripMenuItem2.Text = "&FACTURA"
            ToolStripMenuItem3.Visible = False
            ToolStripMenuItem4.Visible = False
            ToolStripMenuItem5.Visible = False
            ToolStripMenuItem3.Enabled = False
            ToolStripMenuItem4.Enabled = False
            ToolStripMenuItem5.Enabled = False
            ToolStripMenuItem2.Enabled = False ' Se debe activar cuando es nuevo

            SelectMenu(0)
            'Recupera los de otra factura 
            If objOtras_facturas.fnLISTA_INICIAL_otro_factura() = True Then
                'datahelper
                'odba.Fill(dtusuario, objOtras_facturas.rst_usuarios)
                'odba.Fill(dttipo_factura, objOtras_facturas.rst_tipo_factura)
                'odba.Fill(dtforma_pago, objOtras_facturas.rst_forma_pago)
                'odba.Fill(dtmoneda, objOtras_facturas.rst_moneda)
                'odba.Fill(dtrubro, objOtras_facturas.rst_rubro)

                dtusuario = objOtras_facturas.rst_usuarios
                dttipo_factura = objOtras_facturas.rst_tipo_factura
                dtforma_pago = objOtras_facturas.rst_forma_pago
                dtmoneda = objOtras_facturas.rst_moneda
                dtrubro = objOtras_facturas.rst_rubro
                b_lee_cmb = False
                dvusuario = CargarCombo(Me.CMBUSUARIOS, dtusuario, "usuario", "Idusuario_Personal", 0)
                dvtipo_factura = CargarCombo(Me.cmbtipofactura, dttipo_factura, "tipo_comprobante", "idtipo_comprobante", 32) 'Por defecto (32 FACTURA OTRO INGRESO)
                dvforma_pago = CargarCombo(Me.cmbformapago, dtforma_pago, "forma_pago", "idforma_pago", 2) 'Por defecto  (1 Contado) 
                dvmoneda = CargarCombo(Me.Cmbmoneda, dtmoneda, "descripcion", "idtipo_moneda", 1) 'Por Defecto (1 Nuevo Soles) 
                dvrubro = CargarCombo(Me.cmbrubro, dtrubro, "rubro", "idrubro", -666)
                'dvdireccion = CargarCombo(Me.cmbDireccion, dtdireccion, "direccion", "id", -666)
                b_lee_cmb = True
            End If
            ' Recupera el listado de clientes 
            If objOtras_facturas.fnLISTA_PERSONAS() = True Then
                fnCargar_iWin_for4(Me.txtcliente, objOtras_facturas.rst_Lista_Personas, coll_Lista_Personas, iWinPersona, 0, iWinPersonaRUC, iWinPersonaRubro, iWinrepresentante_legal)
            End If
            '

            With Me.cboTipoAfectacion
                .DisplayMember = "descripcion"
                .ValueMember = "codigo"
                .DataSource = ListarTipoControl(16, 2)
                .SelectedValue = 1
            End With

            Me.dtpfecha_emision.Text = dtoUSUARIOS.m_sFecha
            grillaformato()
            Me.lbNroRegistro.Text = "0"

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    'btnNuevo
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ToolStripMenuItem2.Enabled = True
        ToolStripMenuItem1.Enabled = False
        limpiar_campos()
        icontrol = 1
        SelectMenu(1)
    End Sub
    'btngrabar
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        fn_grabar()
    End Sub
    'Cmbmoneda
    Private Sub Cmbmoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbmoneda.SelectedIndexChanged
        If b_lee_cmb = True Then
            If Me.Cmbmoneda.SelectedValue <> 1 Then
                Me.Labtipo_cambio.Visible = True
                Me.txttipo_cambio.Visible = True
                Me.txttipo_cambio.Text = "0.00"
            Else
                Me.Labtipo_cambio.Visible = False
                Me.txttipo_cambio.Visible = False
                Me.txttipo_cambio.Text = "1.00"
            End If
        End If
    End Sub
    'txtsubtotal
    Private Sub txtsubtotal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsubtotal.Leave
        If txtsubtotal.Text <> "" Then
            calculo_impuesto(CType(txtsubtotal.Text, Double))
        End If
    End Sub
    'txtserie
    Private Sub txtserie_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtserie.Leave
        Me.txtserie.Text = RellenoRight(iserie_Digitos_Ventas, Me.txtserie.Text)
    End Sub
    'txtnro_factura
    Private Sub txtnro_factura_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnro_factura.Leave
        Me.txtnro_factura.Text = RellenoRight(inro_Digitos_Ventas, Me.txtnro_factura.Text)
        ' Validar que no se repita la factura 
        fnvalida_factura()
    End Sub

    'txtruc
    Private Sub txtruc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtruc.Leave
        Try
            Dim indexof As Integer = 0

            b_lee_cliente = True
            b_ingresa_cliente = False
            If Me.txtruc.Text <> "" Then
                If iWinPersona.Count > 0 Then
                    indexof = iWinPersonaRUC.IndexOf(txtruc.Text)
                    If indexof >= 0 Then
                        objOtras_facturas.sidpersona = coll_Lista_Personas(indexof.ToString)
                        Me.txtidpersona.Text = objOtras_facturas.sidpersona
                        If indexof <= iWinPersona.Count Then
                            Me.txtcliente.Text = iWinPersona.Item(indexof)
                            Me.cmbrubro.SelectedValue = iWinPersonaRubro.Item(indexof)
                            Me.txtrepresentante_legal.Text = iWinrepresentante_legal.Item(indexof)
                            '
                            'Recupera Dirección Legal del Cliente 
                            recupera_direccion(Me.txtidpersona.Text)

                            'Carga Direcciones Legales de Cliente
                            'datahelper
                            'dv_direccion = objFACTURA.sp_cargar_direccion_cliente(cnn, Me.txtidpersona.Text)
                            dv_direccion = objFACTURA.sp_cargar_direccion_cliente(Me.txtidpersona.Text)
                            If dv_direccion.Table.Rows.Count > 0 Then
                                dv_direccion = CargarCombo(Me.cmbDireccion, dv_direccion, "direccion", "iddireccion_consignado", -1)
                            End If
                            b_lee_cliente = False
                        End If
                    Else
                        'datahelper
                        'dv_persona_factura_otro = objFACTURA.sp_busca_liente_fac_otro(cnn, Me.txtruc.Text)
                        dv_persona_factura_otro = objFACTURA.sp_busca_liente_fac_otro(Me.txtruc.Text)
                        If dv_persona_factura_otro.Table.Rows.Count > 0 Then

                            Me.txtruc.Text = dv_persona_factura_otro.Table.Rows(0)("nu_docu_suna")
                            txtcliente.Text = dv_persona_factura_otro.Table.Rows(0)("razon_social")

                            If dv_persona_factura_otro.Table.Rows(0).IsNull("idrubro") Then
                                Me.cmbrubro.SelectedValue = 475
                            Else
                                Me.cmbrubro.SelectedValue = dv_persona_factura_otro.Table.Rows(0)("idrubro")
                            End If

                            If dv_persona_factura_otro.Table.Rows(0).IsNull("direccion") Then
                                txtdireccion.Text = ""
                            Else
                                txtdireccion.Text = dv_persona_factura_otro.Table.Rows(0)("direccion")
                            End If

                            txtidpersona.Text = dv_persona_factura_otro.Table.Rows(0)("idpersona")

                            If dv_persona_factura_otro.Table.Rows(0).IsNull("iddireccion_consignado") Then
                                txtiddireccion_contacto.Text = ""
                            Else
                                txtiddireccion_contacto.Text = dv_persona_factura_otro.Table.Rows(0)("iddireccion_consignado")
                            End If

                            If dv_persona_factura_otro.Table.Rows(0).IsNull("representante_legal") Then
                                txtrepresentante_legal.Text = ""
                            Else
                                txtrepresentante_legal.Text = dv_persona_factura_otro.Table.Rows(0)("representante_legal")
                            End If

                            'Carga Direcciones Legales de Cliente
                            'datahelper
                            'dv_direccion = objFACTURA.sp_cargar_direccion_cliente(cnn, Me.txtidpersona.Text)
                            dv_direccion = objFACTURA.sp_cargar_direccion_cliente(Me.txtidpersona.Text)
                            If dv_direccion.Table.Rows.Count > 0 Then
                                dv_direccion = CargarCombo(Me.cmbDireccion, dv_direccion, "direccion", "iddireccion_consignado", -1)
                            End If

                            b_lee_cliente = False
                        Else

                            Me.txtruc.Text = ""
                            txtcliente.Text = ""
                            Me.cmbrubro.SelectedValue = 475
                            txtdireccion.Text = ""
                            txtidpersona.Text = ""
                            txtiddireccion_contacto.Text = ""
                            txtrepresentante_legal.Text = ""
                            b_ingresa_cliente = True
                        End If


                        'MsgBox("Cliente no encontrado...", MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    'txtcliente
    Private Sub txtcliente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcliente.Leave
        Try
            Dim indexof As Integer = 0
            If b_lee_cliente = True And Len(Me.txtcliente.Text) > 0 Then
                If iWinPersona.Count > 0 Then
                    'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
                    indexof = IIf(iWinPersona.IndexOf(Me.txtcliente.Text) >= 0, iWinPersona.IndexOf(Me.txtcliente.Text), -1)

                    If indexof >= 0 Then
                        objOtras_facturas.sidpersona = coll_Lista_Personas(indexof.ToString)
                        Me.txtidpersona.Text = objOtras_facturas.sidpersona
                        If indexof <= iWinPersonaRUC.Count Then
                            Me.txtruc.Text = iWinPersonaRUC.Item(indexof)
                            Me.cmbrubro.SelectedValue = iWinPersonaRubro.Item(indexof)
                            Me.txtrepresentante_legal.Text = iWinrepresentante_legal.Item(indexof)
                            'Recupera Dirección Legal del Cliente 
                            recupera_direccion(Me.txtidpersona.Text)
                            b_ingresa_cliente = False
                        End If
                    Else
                        'Si no existe debe dejarlo pasar para que se grabe el cliente                  
                        b_ingresa_cliente = True
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    'btnBuscar
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        lbusqueda = 1
        recupera_grilla()
    End Sub

    Public Function ValidaNumero2(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[-0-9\b]") '("^\d+$")  
        If re.IsMatch(txtStr.ToString()) Then
            ValidaNumero2 = True
        Else
            ValidaNumero2 = False
        End If
    End Function

    Private Sub txtNroSerieDoc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroSerieDoc.KeyPress
        If ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNroSerieDoc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroSerieDoc.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.btnBuscar.Focus()
        End If
    End Sub
    'txtNroSerieDoc
    Private Sub txtNroSerieDoc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroSerieDoc.Leave
        lbusqueda = 2
        recupera_grilla()
    End Sub
    'btnCerrar
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        'ObjReport.Dispose()
        Me.Close()
    End Sub
    'btnsalir 
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        limpiar_campos()
        SelectMenu(0)
        ToolStripMenuItem1.Enabled = True
        ToolStripMenuItem2.Enabled = False
        icontrol = 0
    End Sub
    'btn_modificar
    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Try
            If dGVControl_otrafactura.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dGVControl_otrafactura.SelectedRows.Item(0).Index
            If dGVControl_otrafactura.Rows().Count - 1 = row Then
                Return
            End If
            ' Recuperando los datos de la idfactura_otro 
            objOtras_facturas.sidfactura_otro = CType(dGVControl_otrafactura.Rows(row).Cells("idfactura_otro").Value, String)
            ''
            If CType(objOtras_facturas.sidfactura_otro, Long) <= 0 Then
                MsgBox("No puede realizar está operación ...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            ' ''            
            fnControl_otrofactura(True)
        Catch ex As Exception

        End Try
    End Sub
    'btnImprimir
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            Dim lsidusuario As String
            Dim lsfecha_inicio As String
            Dim lsfecha_final As String
            'Recuperando los datos             
            lsidusuario = Me.CMBUSUARIOS.SelectedValue
            If lsidusuario = "0" Or lsidusuario = "9999" Or lsidusuario = "-666" Then
                lsidusuario = "0"
            End If
            '--
            lsfecha_inicio = dtFechaInicio.Text
            lsfecha_final = dtFechaFin.Text
            Try
                ObjReport.Dispose()
            Catch

            End Try
            Dim ls_mensaje As String
            ls_mensaje = "Del " + lsfecha_inicio + " hasta " + lsfecha_final
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            ObjReport.printrpt(False, "", "FAC102.RPT", _
            "P_SUBTITULO;" & ls_mensaje, _
            "V_IDUSUARIO;" & lsidusuario, _
            "V_FEC_INICIAL;" & lsfecha_inicio, _
            "V_FEC_FINAL;" & lsfecha_final)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de seguridad")
        End Try
    End Sub
#End Region
#Region "Procedimientos y/o funciones"
    Sub grillaformato()
        Try
            dGVControl_otrafactura.Columns.Clear()   'Limpiando la grilla 

            With dGVControl_otrafactura
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            ''
            Dim dgv_fecha_factura As New DataGridViewTextBoxColumn
            With dgv_fecha_factura  '0
                .DisplayIndex = 0
                .DataPropertyName = "fecha_factura"
                .Name = "fecha_factura"
                .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_fecha_factura)
            ''                        
            Dim dgv_tipo_comprobante As New DataGridViewTextBoxColumn
            With dgv_tipo_comprobante '1
                .DisplayIndex = 1
                .Name = "tipo_comprobante"
                .DataPropertyName = "tipo_comprobante"
                .HeaderText = "Tipo Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_tipo_comprobante)
            '
            Dim dvg_dcto As New DataGridViewTextBoxColumn
            With dvg_dcto '2
                .DisplayIndex = 2
                .DataPropertyName = "dcto"
                .Name = "dcto"
                .HeaderText = "NRO. FAC/BOL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dvg_dcto)
            '
            Dim dgv_ruc_cliente As New DataGridViewTextBoxColumn
            With dgv_ruc_cliente ' 3
                .DisplayIndex = 3
                .DataPropertyName = "ruc"
                .Name = "ruc"
                .HeaderText = "RUC"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_ruc_cliente)
            '
            Dim dgv_razon_social As New DataGridViewTextBoxColumn
            With dgv_razon_social ' 4
                .DisplayIndex = 4
                .DataPropertyName = "cliente"
                .Name = "cliente"
                .HeaderText = "Razón Social/Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_razon_social)
            '
            Dim dgv_moneda As New DataGridViewTextBoxColumn
            With dgv_moneda ' 5
                .DisplayIndex = 5
                .DataPropertyName = "moneda"
                .Name = "moneda"
                .HeaderText = "Moneda"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_moneda)
            '
            Dim dgv_monto_tipo_cambio As New DataGridViewTextBoxColumn
            With dgv_monto_tipo_cambio ' 6
                .DisplayIndex = 6
                .DataPropertyName = "monto_tipo_cambio"
                .Name = "monto_tipo_cambio"
                .HeaderText = "Tipo Cambio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_monto_tipo_cambio)
            '
            Dim dgv_monto_subtotal As New DataGridViewTextBoxColumn
            With dgv_monto_subtotal '7
                .DisplayIndex = 7
                .DataPropertyName = "monto_subtotal"
                .Name = "monto_subtotal"
                .HeaderText = "Sub Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_monto_subtotal)
            '
            Dim dgv_monto_impuesto As New DataGridViewTextBoxColumn
            With dgv_monto_impuesto '8
                .DisplayIndex = 8
                .DataPropertyName = "monto_impuesto"
                .Name = "monto_impuesto"
                .HeaderText = "Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_monto_impuesto)
            '
            Dim dgv_total_costo As New DataGridViewTextBoxColumn
            With dgv_total_costo '9
                .DisplayIndex = 9
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_total_costo)
            '
            Dim dgv_fecha_registro As New DataGridViewTextBoxColumn
            With dgv_fecha_registro '10
                .DisplayIndex = 10
                .DataPropertyName = "fecha_registro"
                .Name = "fecha_registro"
                .HeaderText = "Fecha Registro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_fecha_registro)
            '
            Dim dgv_usuario_registro As New DataGridViewTextBoxColumn
            With dgv_usuario_registro '11
                .DisplayIndex = 11
                .Name = "usuario_registro"
                .DataPropertyName = "usuario_registro"
                .HeaderText = "Usuario Registro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_usuario_registro)
            '
            Dim dgv_estado_registro As New DataGridViewTextBoxColumn
            With dgv_estado_registro '12
                .DisplayIndex = 12
                .Name = "estado_registro"
                .DataPropertyName = "estado_registro"
                .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_estado_registro)
            '
            Dim dgv_fecha_anulacion As New DataGridViewTextBoxColumn
            With dgv_fecha_anulacion '13
                .DisplayIndex = 13
                .Name = "fecha_anulacion"
                .DataPropertyName = "fecha_anulacion"
                .HeaderText = "Fecha anulación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_fecha_anulacion)
            '
            Dim dgv_usuario_anula As New DataGridViewTextBoxColumn
            With dgv_usuario_anula '14
                .DisplayIndex = 14
                .Name = "usuario_anula"
                .DataPropertyName = "usuario_anula"
                .HeaderText = "Usuario Anula"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(dgv_usuario_anula)

            Dim dgv_idfactura_otro As New DataGridViewTextBoxColumn
            With dgv_idfactura_otro '15
                .DisplayIndex = 15
                .Name = "idfactura_otro"
                .DataPropertyName = "idfactura_otro"
                .HeaderText = "Id Factura Otro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With
            dGVControl_otrafactura.Columns.Add(dgv_idfactura_otro)

            Dim dgv_aplicado As New DataGridViewTextBoxColumn
            With dgv_aplicado '14
                .DisplayIndex = 16
                .Name = "aplicado"
                .DataPropertyName = "aplicado"
                .HeaderText = "aplicado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With
            dGVControl_otrafactura.Columns.Add(dgv_aplicado)

            Dim dgv_idestado As New DataGridViewTextBoxColumn
            With dgv_idestado '14
                .DisplayIndex = 17
                .Name = "idestado"
                .DataPropertyName = "idestado"
                .HeaderText = "idestado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With
            dGVControl_otrafactura.Columns.Add(dgv_idestado)

            Dim dgv_d_Fecemife As New DataGridViewTextBoxColumn
            With dgv_d_Fecemife '14
                .DisplayIndex = 18
                .Name = "d_Fecemife"
                .DataPropertyName = "d_Fecemife"
                .HeaderText = "d_Fecemife"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With
            dGVControl_otrafactura.Columns.Add(dgv_d_Fecemife)

            Dim dgv_n_emife As New DataGridViewTextBoxColumn
            With dgv_n_emife '14
                .DisplayIndex = 19
                .Name = "n_emife"
                .DataPropertyName = "n_emife"
                .HeaderText = "n_emife"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With
            dGVControl_otrafactura.Columns.Add(dgv_n_emife)

            Dim dgv_idrubro As New DataGridViewTextBoxColumn
            With dgv_idrubro '14
                .DisplayIndex = 20
                .Name = "idrubro"
                .DataPropertyName = "idrubro"
                .HeaderText = "idrubro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With
            dGVControl_otrafactura.Columns.Add(dgv_idrubro)
            '-- 

            Dim col_idtipo_afectacion As New DataGridViewTextBoxColumn
            With col_idtipo_afectacion
                .DisplayIndex = 21
                .Name = "idtipo_afectacion"
                .DataPropertyName = "idtipo_afectacion"
                .HeaderText = "idtipo_afectacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With
            dGVControl_otrafactura.Columns.Add(col_idtipo_afectacion)

            Dim col_tipo_afectacion As New DataGridViewTextBoxColumn
            With col_tipo_afectacion
                .DisplayIndex = 22
                .Name = "tipo_afectacion"
                .DataPropertyName = "tipo_afectacion"
                .HeaderText = "Tipo Afectación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dGVControl_otrafactura.Columns.Add(col_tipo_afectacion)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Sub limpiar_campos()
        Try
            Me.txtruc.Text = ""
            Me.txtcliente.Text = ""
            Me.txtserie.Text = ""
            Me.txtrepresentante_legal.Text = ""
            Me.txtnro_factura.Text = ""
            Me.cmbtipofactura.SelectedValue = 32 ' Por defecto otros Ingresos 
            Me.dtpfecha_emision.Text = dtoUSUARIOS.m_sFecha
            Me.cmbformapago.SelectedValue = 2 'Por defecto debe ser Contado 
            Me.txtreferencia.Text = ""
            Me.Cmbmoneda.SelectedValue = 1 ' Por defecto moneda nacional 
            Me.TXTGLOSA.Text = ""
            Me.TXTGLOSA_sub_total.Text = ""
            Me.txtsubtotal.Text = ""
            Me.txtimpuesto.Text = ""
            Me.txttotal.Text = ""
            Me.txtigv.Text = digv_calculo ' Variable global del igv 
            ' Tipo de cambio por defecto debe ser moneda nacional 
            Me.Labtipo_cambio.Visible = False
            Me.txttipo_cambio.Visible = False
            Me.txttipo_cambio.Text = "1.0"
            Me.txtpreciounitario.Text = "0.0"
            Me.txtcantidad.Text = "0"
            Me.cmbrubro.SelectedValue = -666
            '
            b_lee_cliente = True
            b_ingresa_cliente = False
            '
            icontrol = 0
            lbusqueda = 0
            'Control de variables 
            Me.txtidpersona.Text = ""
            Me.txtidfactura_otra.Text = ""
            Me.txtdireccion.Text = ""

            Me.cboTipoAfectacion.SelectedValue = 1

            cmbDireccion.DataSource = Nothing
            cmbDireccion.Items.Clear()
            ' 
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Function fnvalida_factura() As Boolean
        Dim s_comprobante, s_usuario, s_fecha_emision As String
        Dim lid_factura As Long
        '
        Try
            objOtras_facturas.sserie_factura = Me.txtserie.Text
            objOtras_facturas.snro_factura = Me.txtnro_factura.Text
            If objOtras_facturas.fn_verifica_factura() = True Then
                If objOtras_facturas.rst_verifica_factura.Rows.Count > 0 Then
                    If IsDBNull(objOtras_facturas.rst_verifica_factura.Rows(0).Item("idfactura")) = True Then
                        Return True
                    Else
                        lid_factura = CType(objOtras_facturas.rst_verifica_factura.Rows(0).Item("idfactura").ToString, Long)
                        s_comprobante = CType(objOtras_facturas.rst_verifica_factura.Rows(0).Item("comprobante").ToString, String)
                        s_fecha_emision = CType(objOtras_facturas.rst_verifica_factura.Rows(0).Item("fecha_factura").ToString, String)
                        s_usuario = CType(objOtras_facturas.rst_verifica_factura.Rows(0).Item("login").ToString, String)
                        '
                        MessageBox.Show("La factura " + Me.txtserie.Text + " - " + Me.txtnro_factura.Text + " existe en el " + s_comprobante + " del día " + s_fecha_emision + " con el usuario " + s_usuario, "Facturación Otro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtnro_factura.Text = ""
                        Me.txtnro_factura.Focus()
                        Return False
                    End If
                End If

                'datahelper
                'If objOtras_facturas.rst_verifica_factura.EOF = False And objOtras_facturas.rst_verifica_factura.BOF = False Then
                '    If IsDBNull(objOtras_facturas.rst_verifica_factura.Fields.Item("idfactura").Value) = True Then
                '        Return True
                '    Else
                '        lid_factura = CType(objOtras_facturas.rst_verifica_factura.Fields.Item("idfactura").Value, Long)
                '        s_comprobante = CType(objOtras_facturas.rst_verifica_factura.Fields.Item("comprobante").Value, String)
                '        s_fecha_emision = CType(objOtras_facturas.rst_verifica_factura.Fields.Item("fecha_factura").Value, String)
                '        s_usuario = CType(objOtras_facturas.rst_verifica_factura.Fields.Item("login").Value, String)
                '        '
                '        MessageBox.Show("La factura " + Me.txtserie.Text + " - " + Me.txtnro_factura.Text + " existe en el " + s_comprobante + " del día " + s_fecha_emision + " con el usuario " + s_usuario, "Facturación Otro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '        Me.txtnro_factura.Text = ""
                '        Me.txtnro_factura.Focus()
                '        Return False
                '    End If
                'End If
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Function
    Sub fn_grabar()
        Try
            'hlamas 15-04-2016
            If Me.txtnro_factura.Enabled Then
                Dim MyObligatorios As Object() = {Me.txtserie, Me.txtnro_factura, Me.TXTGLOSA, Me.txtsubtotal, Me.txtcliente, Me.txtruc}
                If Funciones.Validaciones(MyObligatorios) <> 0 Then
                    Exit Sub
                End If
            Else
                Dim MyObligatorios As Object() = {Me.TXTGLOSA, Me.txtsubtotal, Me.txtcliente, Me.txtruc}
                If Funciones.Validaciones(MyObligatorios) <> 0 Then
                    Exit Sub
                End If
            End If

            'hlamas 15-04-2016
            If IsNothing(Me.cmbtipofactura.SelectedValue) Then
                MessageBox.Show("Seleccione el Tipo de Comprobante", "Facturación Especial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbtipofactura.Focus()
                Exit Sub
            End If

            If Me.cmbtipofactura.SelectedValue <> 41 Then
                If IsNothing(Me.cmbDireccion.SelectedValue) Then
                    MessageBox.Show("Seleccione la Dirección Fiscal", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cmbDireccion.Focus()
                    Exit Sub
                End If
            End If

            If Me.cboTipoAfectacion.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Tipo de Afectación del Igv", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoAfectacion.Focus()
                Exit Sub
            End If

            If Me.TXTGLOSA.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese la Glosa", "Facturación Especial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TXTGLOSA.Text = Me.TXTGLOSA.Text.Trim
                Me.TXTGLOSA.Focus()
                Exit Sub
            End If

            Dim chCar As Char = Me.TXTGLOSA.Text.Substring(0)
            Dim intCar As Integer = Asc(chCar)
            If Not ((intCar >= 97 And intCar <= 122) Or (intCar >= 65 And intCar <= 90)) Then
                MessageBox.Show("El 1er Caracter debe ser un caracter válido (A..Z a..z)", "Facturación Especial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TXTGLOSA.Focus()
                Return
            End If

            ' Validar la serie y el número que no existan, siempre que sea nuevo  
            If icontrol = 1 Then
                fnvalida_factura()
            End If
            'Validar montos 
            If Me.txttipo_cambio.Text <= 0 Then
                If Me.Cmbmoneda.SelectedValue = 2 Then
                    MessageBox.Show("Debe ingresar un tipo de cambio válido", "Facturación Especial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            If Me.txtsubtotal.Text <= 0 Then
                MessageBox.Show("Debe ingresar el Sub Total de la Factura", "Facturación Especial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtsubtotal.Focus()
                Exit Sub
            End If
            'calculo_impuesto(CType(Me.txtsubtotal.Text, Double))
            '
            objOtras_facturas.icontrol = icontrol
            If icontrol = 1 Then
                objOtras_facturas.sidfactura_otro = "null"
            Else
                objOtras_facturas.sidfactura_otro = Me.txtidfactura_otra.Text
            End If
            ' Verificar que el id Persona tenga valor 
            If Me.txtidpersona.Text = "" Then
                objOtras_facturas.sidpersona = "null"
            Else
                objOtras_facturas.sidpersona = Me.txtidpersona.Text
            End If
            objOtras_facturas.iidtipo_comprobante = Me.cmbtipofactura.SelectedValue
            objOtras_facturas.sserie_factura = Me.txtserie.Text
            objOtras_facturas.snro_factura = Me.txtnro_factura.Text
            objOtras_facturas.sfecha_factura = Me.dtpfecha_emision.Text
            objOtras_facturas.iidforma_pago = Me.cmbformapago.SelectedValue
            objOtras_facturas.dmonto_subtotal = CType(Me.txtsubtotal.Text, Double)
            objOtras_facturas.dmonto_impuesto = CType(Me.txtimpuesto.Text, Double)
            objOtras_facturas.dtotal_costo = CType(Me.txttotal.Text, Double)
            objOtras_facturas.iidtipo_moneda = Me.Cmbmoneda.SelectedValue
            objOtras_facturas.iidestado_factura_otro = 1 'Siempre va hacer 1 (Activo) 
            objOtras_facturas.dmonto_tipo_cambio = CType(Me.txttipo_cambio.Text, Double)
            objOtras_facturas.iidagencias = CType(dtoUSUARIOS.m_iIdAgencia.ToString, Integer)
            objOtras_facturas.lidusuario_personal = CType(dtoUSUARIOS.IdLogin, Long)
            objOtras_facturas.sip = dtoUSUARIOS.IP
            objOtras_facturas.lidrol = dtoUSUARIOS.IdRol
            objOtras_facturas.lidproceso = 63 ' Proceso de Facturación 
            objOtras_facturas.sglosa = Me.TXTGLOSA.Text
            objOtras_facturas.digv = CType(Me.txtigv.Text, Double)
            objOtras_facturas.memo = txtreferencia.Text
            If Me.TXTGLOSA_sub_total.Text.Trim = "" Then
                objOtras_facturas.glosa02 = "NULL"
            Else
                objOtras_facturas.glosa02 = Me.TXTGLOSA_sub_total.Text
            End If

            If Me.txtcantidad.Text = "" Then
                objOtras_facturas.lcantidad = -666
            Else
                objOtras_facturas.lcantidad = CType(Me.txtcantidad.Text, Long)
            End If
            If Me.txtpreciounitario.Text = "" Then
                objOtras_facturas.dprecio_unitario = -666
            Else
                objOtras_facturas.dprecio_unitario = CType(Me.txtpreciounitario.Text, Double)
            End If
            If Me.cmbDireccion.SelectedIndex = -1 Then
                objOtras_facturas.direccion_facturacion = -1
            Else
                objOtras_facturas.direccion_facturacion = cmbDireccion.SelectedValue
            End If
            objOtras_facturas.tipo_afectacion = Me.cboTipoAfectacion.SelectedIndex

            ' Grabar 
            If objOtras_facturas.fn_grabar Then

                If objOtras_facturas.lcod_mensaje <> 0 Then
                    MsgBox(objOtras_facturas.smensaje, MsgBoxStyle.Exclamation, "Facturación Especial")
                    Exit Sub
                Else
                    MsgBox(objOtras_facturas.smensaje, MsgBoxStyle.Information, "Facturación Especial")
                    limpiar_campos()
                    SelectMenu(0)
                    ToolStripMenuItem1.Enabled = True
                    ToolStripMenuItem2.Enabled = False
                    icontrol = 0
                    ' Recuperar datos 
                    lbusqueda = 1
                    recupera_grilla()

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Sub recupera_grilla()
        Try
            objOtras_facturas.icontrol = lbusqueda
            objOtras_facturas.lidusuario_personal = Me.CMBUSUARIOS.SelectedValue
            If objOtras_facturas.lidusuario_personal = 9999 Then
                objOtras_facturas.lidusuario_personal = -666
            End If
            ' 
            objOtras_facturas.sfecha_inicio = Me.dtFechaInicio.Text
            objOtras_facturas.sfecha_final = Me.dtFechaFin.Text
            objOtras_facturas.TipoComprobante = Me.cboTipoComprobante.SelectedIndex + 1
            '--
            Dim strNroDoc As String() = Split(txtNroSerieDoc.Text, "-")
            If strNroDoc.Length > 1 Then
                If Val(strNroDoc(0).Length) > 0 And Val(strNroDoc(1).Length) > 0 Then
                    objOtras_facturas.sserie_factura = strNroDoc(0).Trim 'RellenoRight(3, strNroDoc(0))
                    objOtras_facturas.snro_factura = RellenoRight(7, strNroDoc(1))
                Else
                    objOtras_facturas.sserie_factura = "0"
                    objOtras_facturas.snro_factura = "0"
                End If
            Else
                objOtras_facturas.sserie_factura = "0"
                objOtras_facturas.snro_factura = "0"
            End If
            '    
            dtotra_factura = Nothing
            dtotra_factura = New DataTable
            dvotra_factura = Nothing
            dvotra_factura = New DataView
            '
            If objOtras_facturas.fnbusqueda_otrafactura = True Then
                'datahelper
                'odba.Fill(dtotra_factura, objOtras_facturas.rst_busqueda_otrafactura)
                'grillaformato()
                dtotra_factura = objOtras_facturas.rst_busqueda_otrafactura
                dvotra_factura = dtotra_factura.DefaultView
                '
                dGVControl_otrafactura.DataSource = dvotra_factura

                lbNroRegistro.Text = dvotra_factura.Count
                '
                If dvotra_factura.Count = 0 Then
                    MsgBox("No se ha encontrado ningún resultado para esta busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            Else
                MsgBox("No se ha encontrado ningún resultado para esta busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        lbusqueda = 0
    End Sub
    Sub recupera_direccion(ByVal vidpersona As String)
        Try
            objOtras_facturas.sidpersona = vidpersona
            If objOtras_facturas.fnbusqueda_direccion_cliente = True Then
                Me.txtiddireccion_contacto.Text = objOtras_facturas.liddireccion_consignado
                Me.txtdireccion.Text = objOtras_facturas.sdireccion_cliente
                ' Podria recuperar el Pais, departamento, Provincia y Distrito  
            Else
                Me.txtiddireccion_contacto.Text = ""
                Me.txtdireccion.Text = ""
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Sub Recupera_datos_clientes()
        Me.txtidpersona.Text = Mod_otro_facturacion.sidpersona
        Me.txtruc.Text = Mod_otro_facturacion.sruc
        Me.txtcliente.Text = Mod_otro_facturacion.scliente
        Me.cmbrubro.SelectedValue = Mod_otro_facturacion.iidrubro
        Me.txtdireccion.Text = Mod_otro_facturacion.siddireccion_consignado
    End Sub
    ' Editar de Otra Facturación  
    Public Sub fnControl_otrofactura(ByVal rflag As Boolean)
        Dim flat As Boolean = False
        Try
            If dGVControl_otrafactura.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dGVControl_otrafactura.SelectedRows.Item(0).Index
            If dGVControl_otrafactura.Rows().Count - 1 = row Then
                Return
            End If
            If row >= 0 Then
                limpiar_campos() ' Limpiando variables
                SelectMenu(1)
                objOtras_facturas.sidfactura_otro = CType(dGVControl_otrafactura.Rows(row).Cells("idfactura_otro").Value, String)
                If objOtras_facturas.fn_edita_otra_factura() = True Then
                    icontrol = 0 ' Para actualizar los datos
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("idfactura_otro")) = False Then
                        Me.txtidfactura_otra.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("idfactura_otro"), Long)
                    Else
                        Me.txtidfactura_otra.Text = ""
                    End If
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("idpersona")) = False Then
                        Me.txtidpersona.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("idpersona"), String)
                    Else
                        Me.txtidpersona.Text = ""
                    End If
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("nu_docu_suna")) = False Then
                        Me.txtruc.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("nu_docu_suna"), String)
                        Dim e As EventArgs
                        txtruc_Leave(txtruc, e)
                    Else
                        Me.txtruc.Text = ""
                    End If
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("razon_social")) = False Then
                        Me.txtcliente.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("razon_social"), String)
                    Else
                        Me.txtcliente.Text = ""
                    End If
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("serie_factura")) = False Then
                        Me.txtserie.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("serie_factura"), String)
                    Else
                        Me.txtserie.Text = ""
                    End If
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("nro_factura")) = False Then
                        Me.txtnro_factura.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("nro_factura"), String)
                    Else
                        Me.txtnro_factura.Text = ""
                    End If
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("representante_legal")) = False Then
                        Me.txtrepresentante_legal.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("representante_legal"), String)
                    Else
                        Me.txtrepresentante_legal.Text = ""
                    End If
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("idtipo_comprobante")) = False Then
                        Me.cmbtipofactura.SelectedValue = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("idtipo_comprobante"), Long)
                    Else
                        Me.cmbtipofactura.SelectedValue = -666
                    End If
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("Fecha_Factura")) = False Then
                        Me.dtpfecha_emision.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("Fecha_Factura"), String)
                    Else
                        Me.dtpfecha_emision.Text = "00/00/0000"
                    End If
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("Idforma_Pago")) = False Then
                        Me.cmbformapago.SelectedValue = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("Idforma_Pago"), Long)
                    Else
                        Me.cmbformapago.SelectedValue = -666
                    End If
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("memo")) = False Then
                        Me.txtreferencia.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("memo"), String)
                    Else
                        Me.txtreferencia.Text = ""
                    End If
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("idtipo_moneda")) = False Then
                        Me.Cmbmoneda.SelectedValue = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("idtipo_moneda"), Long)
                    Else
                        Me.Cmbmoneda.SelectedValue = -666
                    End If


                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("glosa")) = False Then
                        Me.TXTGLOSA.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("glosa"), String)
                    Else
                        Me.TXTGLOSA.Text = ""
                    End If


                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("glosa02")) = False Then
                        Me.TXTGLOSA_sub_total.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("glosa02"), String)
                    Else
                        Me.TXTGLOSA_sub_total.Text = ""
                    End If

                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("igv")) = False Then
                        Me.txtigv.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("igv"), Double)
                        digv_calculo = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("igv"), Double)
                    Else
                        Me.txtigv.Text = "0.00"
                        digv_calculo = 0
                    End If

                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("monto_subtotal")) = False Then
                        Me.txtsubtotal.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("monto_subtotal"), Double)
                    Else
                        Me.txtsubtotal.Text = "0.00"
                    End If
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("monto_impuesto")) = False Then
                        Me.txtimpuesto.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("monto_impuesto"), Double)
                    Else
                        Me.txtimpuesto.Text = "0.00"
                    End If
                    '-
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("total_costo")) = False Then
                        Me.txttotal.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("total_costo"), Double)
                    Else
                        Me.txttotal.Text = "0.00"
                    End If

                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("monto_tipo_cambio")) = False Then
                        Me.txttipo_cambio.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("monto_tipo_cambio"), Double)

                    Else
                        Me.txttipo_cambio.Text = "1"

                    End If

                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("precio_unitario")) = False Then
                        Me.txtpreciounitario.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("precio_unitario"), Double)
                    Else
                        Me.txtpreciounitario.Text = "0.0"
                    End If

                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("cantidad")) = False Then
                        Me.txtcantidad.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("cantidad"), Double)
                    Else
                        Me.txtcantidad.Text = "0.00"
                    End If
                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("direccion_legal")) = False Then
                        Me.txtdireccion.Text = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("direccion_legal"), String)
                    Else
                        Me.txtdireccion.Text = ""
                    End If

                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("idrubro")) = False Then
                        Me.cmbrubro.SelectedValue = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("idrubro"), String)
                    Else
                        Me.cmbrubro.SelectedValue = -666
                    End If

                    If IsDBNull(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("iddireccion")) = False Then
                        Me.cmbDireccion.SelectedValue = CType(objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("iddireccion"), Integer)
                    Else
                        Me.cmbDireccion.SelectedValue = -1
                    End If

                    Me.cboTipoAfectacion.SelectedIndex = objOtras_facturas.rst_edita_otra_factura.Rows(0).Item("idtipo_afectacion")
                End If
            Else
                MsgBox("No Puede Realizar esta Operacion, Solo puede Editar las Recepcionadas", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            flat = False
        End Try
        '--
    End Sub
    Private Sub AnularToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularToolStripMenuItem.Click
        'Recuperando los datos 
        Dim dgrv0 As DataGridViewRow
        Dim s_comprobante As String
        Dim s_idfactua_otro As String
        Dim lnromensaje As Long
        Dim smensaje As String
        Try
            '
            If Me.dGVControl_otrafactura.Rows.Count < 1 Then
                Exit Sub
            End If
            dgrv0 = Me.dGVControl_otrafactura.CurrentRow()
            s_comprobante = CType(dgrv0.Cells("dcto").Value, String)
            Dim resp As DialogResult = MessageBox.Show("¿Está Seguro de Anular la Factura Nº " & s_comprobante & "?", "Seguridad del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = Windows.Forms.DialogResult.Yes Then
                s_idfactua_otro = CType(dgrv0.Cells("idfactura_otro").Value, String)
                objOtras_facturas.sidfactura_otro = s_idfactua_otro

                Dim intOrigen As Integer = 0
                Dim strFecha As String = dGVControl_otrafactura.CurrentRow.Cells("fecha_factura").Value
                Dim strFechaServidor As String = FechaServidor(1)
                Dim dias As Long = DateDiff(DateInterval.Day, CType(strFecha, Date), CType(strFechaServidor, Date))
                If dias <= 3 Then 'validar si mes de comprobante es diferente a mes del sistema
                    If DatePart(DateInterval.Month, CDate(strFecha)) <> DatePart(DateInterval.Month, CDate(strFechaServidor)) Then
                        intOrigen = 1
                    End If
                End If
                If intOrigen = 1 Then
                    Cursor = Cursors.Default
                    MessageBox.Show("El Comprobante no puede ser anulado. El mes de la factura es menor al mes actual" & Chr(13) & "Para Anular el Comprobante, emita una Nota de Crédito", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim frm As New frmMotivoAnulacion
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    Dim strMotivo As String = frm.txtMotivo.Text.Trim
                    If dGVControl_otrafactura.CurrentRow.Cells("IDESTADO").Value = 2 Then
                        MsgBox("La Factura ya está anulada", MsgBoxStyle.Information, "Titan")
                        Exit Sub
                    End If
                    If dGVControl_otrafactura.CurrentRow.Cells("APLICADO").Value = 1 Then
                        MsgBox("La Factura ya está Aplicada", MsgBoxStyle.Information, "Titan")
                        Exit Sub
                    End If

                    Dim strTipo As String = dGVControl_otrafactura.CurrentRow.Cells("tipo_comprobante").Value.ToString.Substring(0, 1)
                    If dGVControl_otrafactura.CurrentRow.Cells("n_emife").Value = 0 Then 'si comprobante no tiene CDR
                        'If strTipo = "F" Then
                        Cursor = Cursors.Default
                        MessageBox.Show("La Factura no puede ser Anulada", "Antes de Anularlo, envielo a SUNAT", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                        'Else
                        '    Dim strFecha As String = DateAdd(DateInterval.Day, 1, dGVControl_otrafactura.CurrentRow.Cells("fecha_factura").Value)
                        '    Dim strFechaServidor As String = FechaServidor(1)
                        '    Dim dias As Long = DateDiff(DateInterval.Day, CType(strFecha, Date), CType(strFechaServidor, Date))
                        '    If dias > 3 Then 'comprobante sin CDR excede plazo de anulacion por baja
                        '        MessageBox.Show("La Factura excede Plazo de Anulación (3 dias)", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '        Return
                        '    End If
                        'End If
                    Else
                        If strTipo = "R" Then
                            strTipo = "01"
                        Else
                            strTipo = IIf(strTipo = "F", "01", "03")
                        End If

                        Dim strComprobante As String = dGVControl_otrafactura.CurrentRow.Cells("dcto").Value
                        Dim intPosicion As Integer = InStr(strComprobante.Trim, " ")
                        'Dim strSerie As String = IIf(strTipo = "01", "F", "B") & strComprobante.Substring(0, intPosicion - 1)
                        Dim strSerie As String = strComprobante.Substring(0, intPosicion - 1)
                        Dim strNumero As String = strComprobante.Substring(intPosicion)
                        strNumero = strNumero.PadLeft(8, "0")
                        Dim blnAnulable As Boolean = FEManager.isAvoidable(strTipo, strFecha, strSerie, strNumero, strMotivo)
                        If Not blnAnulable Then
                            Cursor = Cursors.Default
                            MessageBox.Show("La Factura no puede ser Anulada", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return
                        End If
                    End If

                    objOtras_facturas.motivo = strMotivo
                    If objOtras_facturas.fn_anula_otra_factura Then
                        'datahelper
                        'lnromensaje = CType(objOtras_facturas.rst_anula_otra_factura.Fields.Item("codsql").Value, Long)
                        'smensaje = CType(objOtras_facturas.rst_anula_otra_factura.Fields.Item("msjsql").Value, String)
                        lnromensaje = CType(objOtras_facturas.rst_anula_otra_factura.Rows(0).Item("codsql"), Long)
                        smensaje = CType(objOtras_facturas.rst_anula_otra_factura.Rows(0).Item("msjsql"), String)
                        If lnromensaje <> 0 Then
                            MsgBox(smensaje, MsgBoxStyle.Exclamation, "Venta de Pasajes")
                        Else
                            'Refresca la pantalla 
                            lbusqueda = 1
                            recupera_grilla()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirComprobante.Click

        'datahelper
        'Dim idfactura_otro As Long = dGVControl_otrafactura.CurrentRow.Cells("idfactura_otro").Value
        'Dim cmd As New System.Data.OracleClient.OracleCommand
        'cmd.Connection = cnn
        'cmd.CommandType = CommandType.StoredProcedure
        'cmd.CommandText = "PKG_IVOFACTUACION_OTROS.sp_impri_factu_otro"
        ''cmd.CommandText = "sp_impri_factu_otro"
        'cmd.Parameters.Add(New OracleClient.OracleParameter("p_idfactura_otro", OracleClient.OracleType.Number)).Value = idfactura_otro
        'cmd.Parameters.Add(New OracleClient.OracleParameter("cur_impri_factu_otro", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output

        'Try

        '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

        '    Dim ds As New DataSet
        '    daora.Fill(ds)

        '    imprimir(ds.Tables(0).DefaultView)

        'Catch ex As System.Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

        'Catch OEx As System.Data.OracleClient.OracleException
        '    MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
        'End Try

        Dim dlgrespuesta As DialogResult = MessageBox.Show("¿Está seguro de imprimir el comprobante?", "Imprimir Comprobante", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If dlgrespuesta = Windows.Forms.DialogResult.Yes Then
            Try
                Dim idfactura_otro As Long = dGVControl_otrafactura.CurrentRow.Cells("idfactura_otro").Value
                Dim obj As New ClsLbTepsa.dtoFACTURA
                imprimir2(obj.impri_factu_otro2(idfactura_otro))

            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
            End Try
        End If
    End Sub

    Private Sub imprimir(ByVal dv As DataView)
        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport

        If dGVControl_otrafactura.Rows.Count = 0 Then
            MsgBox("Seleccione una factura", MsgBoxStyle.Information, "Seguridad del Sistema")
            Exit Sub
        End If
        If IsNothing(dGVControl_otrafactura.CurrentCell) Then
            MsgBox("Seleccione una factura", MsgBoxStyle.Information, "Seguridad del Sistema")
            Exit Sub
        End If
        Try

            Dim TOTAL_COSTO As Double
            Dim MONTO_IMPUESTO As Double
            Dim INTERES As Double

            TOTAL_COSTO = dv.Table.Rows(0)("total_costo_dbl")
            MONTO_IMPUESTO = dv.Table.Rows(0)("monto_impuesto_dbl")
            INTERES = 100 * (MONTO_IMPUESTO) / (TOTAL_COSTO - MONTO_IMPUESTO)
            INTERES = Int(FormatNumber(INTERES, 2))

            If TOTAL_COSTO > 400 Then
                If MsgBox("Posiblmente esta factura este consideranda en la impresion la GLOSA DE DETRACCION" & Chr(13) & Chr(13) & " ¿DESEA IMPRIMIR LA GLOSA?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    glosa02 = "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON " & Chr(13) & _
                    "EL GOBIERNO CENTRAL ,  SEGÚN D.L. Nº  940 - R.S. Nº 158 -2006-SUNAT  / D.S. " & Chr(13) & _
                    "Nº 033-2006-MTC." & Chr(13) & _
                    "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829."
                Else
                    glosa02 = ""
                End If
            Else
                glosa02 = ""
            End If

            Dim nro_letras As String = ""
            If dv.Table.Rows(0)("IDTIPO_MONEDA") = 1 Then
                nro_letras = ConvercionNroEnLetras(TOTAL_COSTO)
            ElseIf dv.Table.Rows(0)("IDTIPO_MONEDA") = 2 Then
                nro_letras = ConvercionNroEnLetrasDolares(TOTAL_COSTO)
            Else
                nro_letras = ""
            End If


            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            ObjReport.printrpt(False, "", "FAC030.RPT", "P_IDFACTURA_OTRO;" & dv.Table.Rows(0)("IDFACTURA_OTRO"), _
            "P_USUARIO;" & "", _
            "P_AGENCIA;" & "", _
            "P_FECHA_APERTURA;" & "", _
            "P_FECHA_CIERRE;" & "", _
            "P_MONTO_LETRAS;" & nro_letras, _
            "P_MENSAJE;" & "", _
            "P_IGV;" & INTERES, _
            "P_GLOSA02;" & glosa02, _
            "P_IMPRESO;" & "")
            Dim OBJFACTURA As New ClsLbTepsa.dtoFACTURA



        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del sistema")
        End Try

    End Sub

    Private Sub txtsubtotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsubtotal.TextChanged

    End Sub

    Private Sub txtigv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtigv.TextChanged

    End Sub

    Private Sub cmbDireccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDireccion.SelectedIndexChanged
        txtdireccion.Text = CType(sender, ComboBox).Text
    End Sub

    Private Sub btnClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClientes.Click
        Me.MantenimientoCliente()
    End Sub

    Sub MantenimientoCliente()
        Try
            If Not Me.TabMante.SelectedIndex = 1 Then
                Exit Sub
            End If
            'Verificando valores 
            If Me.txtiddireccion_contacto.Text = "" Then
                Mod_otro_facturacion.siddireccion_consignado = "null"
            Else
                Mod_otro_facturacion.siddireccion_consignado = Me.txtiddireccion_contacto.Text
            End If
            '
            Dim a As New FrmMantCltefacturacion
            '
            a.dtfrmmantclte_rubro = dtrubro.Copy
            a.coll_Lista_Personas = coll_Lista_Personas
            a.iWinPersona = iWinPersona
            a.iWinPersonaRUC = iWinPersonaRUC
            a.iWinPersonaRubro = iWinPersonaRubro
            a.iWinrepresentante_legal = iWinrepresentante_legal
            If Me.txtidpersona.Text = "" Then
                a.txtidpersona.Text = ""
            Else
                a.txtidpersona.Text = Me.txtidpersona.Text
            End If

            a.txtiddireccionconsignado.Text = Me.txtiddireccion_contacto.Text

            If Me.txtcliente.Text = "" Then
                a.txtcliente.Text = ""
            Else
                a.txtcliente.Text = Me.txtcliente.Text
            End If
            If Me.txtruc.Text = "" Then
                a.txtruc.Text = ""
            Else
                a.txtruc.Text = Me.txtruc.Text
            End If
            If Me.txtrepresentante_legal.Text = "" Or Me.txtrepresentante_legal.Text = "null" Then
                a.txtrepresentante_legal.Text = ""
            Else
                a.txtrepresentante_legal.Text = Me.txtrepresentante_legal.Text
            End If

            ' Rubro 
            a.dvfrmmantclte_rubro = CargarCombo(a.cmbrubro_frmmantclte, a.dtfrmmantclte_rubro, "rubro", "idrubro", -666)
            a.cmbrubro_frmmantclte.SelectedValue = Me.cmbrubro.SelectedValue
            Dim resultado As DialogResult

            'resultado = a.ShowDialog()
            Acceso.Asignar(a, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                resultado = a.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ''Recuperando los valores para actualizar en lo que es la dirección y consignado 
            If Not ModSolRecojoCarga.bcancelar Then
                Recupera_datos_clientes()
            End If
            '
            Dim indexof As Integer = 0
            b_lee_cliente = True
            b_ingresa_cliente = False
            If Me.txtruc.Text <> "" Then
                If iWinPersona.Count > 0 Then
                    indexof = iWinPersonaRUC.IndexOf(txtruc.Text)
                    If indexof >= 0 Then
                        objOtras_facturas.sidpersona = coll_Lista_Personas(indexof.ToString)
                        Me.txtidpersona.Text = objOtras_facturas.sidpersona
                        If indexof <= iWinPersona.Count Then
                            Me.txtcliente.Text = iWinPersona.Item(indexof)
                            Me.cmbrubro.SelectedValue = iWinPersonaRubro.Item(indexof)
                            Me.txtrepresentante_legal.Text = iWinrepresentante_legal.Item(indexof)
                            '
                            'Recupera Dirección Legal del Cliente 
                            recupera_direccion(Me.txtidpersona.Text)
                            b_lee_cliente = False
                        End If
                    Else
                        b_ingresa_cliente = True
                        'MsgBox("Cliente no encontrado...", MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmbtipofactura_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbtipofactura.SelectedIndexChanged
        'hlamas 15-04-2016
        If IsNothing(Me.cmbtipofactura.SelectedValue) Then Return
        Me.txtserie.Text = ""
        Me.txtnro_factura.Text = ""
        If dttipo_factura.Rows(cmbtipofactura.SelectedIndex).Item("electronico") >= 0 Then
            Me.txtserie.Enabled = False
            Me.txtnro_factura.Enabled = False
        Else
            Me.txtserie.Enabled = True
            Me.txtnro_factura.Enabled = True
        End If
        'If cmbtipofactura.SelectedValue = 41 Then
        '    txttotal.ReadOnly = False
        '    Me.txtsubtotal.ReadOnly = True
        'Else
        '    txttotal.ReadOnly = True
        '    Me.txtsubtotal.ReadOnly = False
        'End If
    End Sub

    Private Sub btnEmisionfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmisionfe.Click
        '-->####BEGIN 17/05/2016 - JABANTO
        Return
        Try
            If dGVControl_otrafactura.Rows.Count = 0 Then
                MsgBox("Seleccione una factura", MsgBoxStyle.Information, "Seguridad del Sistema")
                Exit Sub
            End If
            If IsNothing(dGVControl_otrafactura.CurrentCell) Then
                MsgBox("Seleccione una factura", MsgBoxStyle.Information, "Seguridad del Sistema")
                Exit Sub
            End If

            If (MessageBox.Show("¿Está seguro de emitir el Comprobante Electrónico?", "Emisión F.E.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                Me.Cursor = Cursors.WaitCursor

                Dim idfactura_otro As Long = dGVControl_otrafactura.CurrentRow.Cells("idfactura_otro").Value
                Dim objFac As New ClsLbTepsa.dtoFACTURA
                Dim dt As DataTable = objFac.impri_factu_otro2(idfactura_otro)
                If (dt.Rows.Count = 0) Then
                    MessageBox.Show("No se pudo encontrar el Documento para la Emisión.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                Dim row As DataRow = dt.Rows(0)


                Dim cliente As New FECliente
                cliente.tipoDocumentoID = row("IDTIPO_DOC_IDENTIDAD")
                cliente.numeroDocumento = row("NU_DOCU_SUNA")
                cliente.nombres = row("RAZON_SOCIAL")
                cliente.direccion = IIf(IsDBNull(row("DIRECCION_PERSONA")), Nothing, row("DIRECCION_PERSONA"))

                Dim venta As New FEVenta
                venta.cliente = cliente
                venta.TipoAfectacion = row("idtipo_afectacion")
                venta.numeroSerie = row("SERIE_FACTURA")
                venta.numeroCorrelativo = row("NRO_FACTURA")
                venta.fechaEmision = row("FECHA_FACTURA")
                venta.isSOUE = True
                venta.opGravada = row("MONTO_SUBTOTAL_DBL")
                venta.igv = row("MONTO_IMPUESTO_DBL")
                venta.total = row("TOTAL_COSTO_DBL")
                '-->Valida si es boleta o factura
                'If (row("IDTIPO_COMPROBANTE") = 41) Then
                '    venta.tipoComprobanteID = 2 'Boleta
                'Else
                '    venta.tipoComprobanteID = 1 'factura
                'End If
                If row("nu_docu_suna").ToString.Length = 11 Then
                    venta.tipoComprobanteID = 1 'factura
                Else
                    venta.tipoComprobanteID = 2 'Boleta
                End If
                If row("IDTIPO_MONEDA") = 1 Then
                    venta.totalLetras = ConvercionNroEnLetras(venta.total)
                    venta.isMonedaSoles = True
                ElseIf row("IDTIPO_MONEDA") = 2 Then
                    venta.totalLetras = ConvercionNroEnLetrasDolares(venta.total)
                    venta.isMonedaSoles = False
                End If
                venta.tipoVenta = FEManager.TIPO_VENTA_ESPECIAL
                venta.id = idfactura_otro
                venta.tabla = "T_FACTURA_OTRO"

                Dim detalleVenta As New FEDetalleVenta
                detalleVenta.descripcion = row("GLOSA")
                detalleVenta.cantidad = 1
                detalleVenta.tarifa = venta.total
                detalleVenta.unidadMedida = FEManager.SUNAT_UNIMED_UNIDAD

                Dim listaDetalle As New List(Of FEDetalleVenta)
                listaDetalle.Add(detalleVenta)
                venta.detalleVenta = listaDetalle

                '*******************************************************************
                '-->Retencion
                If dGVControl_otrafactura.CurrentRow.Cells("monto_impuesto").Value > 0 Then
                    If venta.total > FEManager.DETRACCION_MONTO_MAYOR_400 Then
                        If MsgBox("Posiblemente esta factura este consideranda en la impresion la GLOSA DE DETRACCION" & Chr(13) & Chr(13) & " ¿DESEA IMPRIMIR LA GLOSA?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            venta.glosaRetencion = FEManager.DETRACCION_GLOSA_MAYOR_400ESPECIAL
                        End If
                    End If
                Else
                    venta.glosaRetencion = ""
                End If

                'Dim result = FEManager.result
                Dim result = FEManager.sendVentaSunat(venta, Nothing)
                If (result.IsCorrect) Then
                    objFac.actualizarEmisonFE(idfactura_otro, "T_FACTURA_OTRO")
                    btnBuscar_Click(Nothing, Nothing)
                End If
                MessageBox.Show(result.Message, "Respuesta WSSunat", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub dGVControl_otrafactura_CurrentCellChanged(sender As Object, e As System.EventArgs) Handles dGVControl_otrafactura.CurrentCellChanged
        '-->####BEGIN 17/05/2016 - JABANTO
        Try
            btn_modificar.Enabled = True
            btnEmisionfe.Enabled = True
            Me.btnImprimirComprobante.Enabled = False

            Dim row As DataGridViewRow = dGVControl_otrafactura.CurrentRow
            If Not (row Is Nothing) Then
                If (Convert.ToInt32(row.Cells("n_emife").Value) = 1) Then
                    btn_modificar.Enabled = False
                    btnEmisionfe.Enabled = False
                    Me.btnImprimirComprobante.Enabled = True
                End If
            End If
        Catch ex As Exception
            btnEmisionfe.Enabled = False
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txttotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttotal.TextChanged
        If txttotal.Text <> "" Then
            Dim dblSubTotal As Double = CType(Me.txttotal.Text, Double) / (1 + (digv_calculo / 100))
            Me.txtsubtotal.Text = FormatNumber(dblSubTotal, 2)
            Me.txtimpuesto.Text = FormatNumber(dblSubTotal * (digv_calculo / 100), 2)
        End If
    End Sub

    Private Sub cboTipoAfectacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoAfectacion.SelectedIndexChanged
        If Me.cboTipoAfectacion.SelectedIndex > 1 Then
            Me.txtigv.Text = ""
        Else
            Me.txtigv.Text = dtoUSUARIOS.iIGV
        End If
        txtigv_Validated(Nothing, Nothing)
    End Sub

    Private Sub txtigv_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtigv.Validated
        If Not IsNumeric(txtsubtotal.Text) Then
            txtsubtotal.Text = "0.00"
        End If
        If Not IsNumeric(txtigv.Text) Then
            txtigv.Text = "0.00"
        Else
            txtigv.Text = FormatNumber(txtigv.Text, 2)
        End If
        digv_calculo = txtigv.Text
        calculo_impuesto(CType(txtsubtotal.Text, Double))
    End Sub

    Sub calculo_impuesto(ByVal dmonto_sub_total As Double)
        Me.txtimpuesto.Text = FormatNumber(dmonto_sub_total * (digv_calculo / 100), 2)
        Me.txttotal.Text = dmonto_sub_total + CType(Me.txtimpuesto.Text, Double)
    End Sub

    Private Sub imprimir2(ByVal dt As DataTable)
        For Each row As DataRow In dt.Rows
            Dim fecliente As New FECliente
            fecliente.tipoDocumentoID = row.Item("idtipo_doc_identidad").ToString()
            fecliente.numeroDocumento = row.Item("nu_docu_suna").ToString()
            fecliente.nombres = row.Item("razon_social").ToString()
            fecliente.direccion = IIf(IsDBNull(row.Item("direccion_persona")), "", row.Item("direccion_persona").ToString())
            Dim venta As New FEVenta
            Dim serie As String = row.Item("serie_factura")
            Dim correlativo As String = row.Item("nro_factura")
            venta.cliente = fecliente
            venta.numeroSerie = serie
            venta.numeroCorrelativo = correlativo
            venta.fechaEmision = Convert.ToDateTime(row.Item("fecha_factura").ToString()).ToString("dd/MM/yyyy")
            venta.tipoComprobanteID = IIf(serie.Trim.Substring(0, 1) = "F", 1, 2)
            venta.opGravada = row.Item("monto_subtotal_dbl")
            venta.igv = row.Item("monto_impuesto_dbl")
            venta.total = row.Item("total_costo_dbl")
            venta.totalLetras = ConvercionNroEnLetras(venta.total)
            venta.formaPago = row.Item("forma_pago").ToString()
            'venta.producto = row.Item("producto").ToString()
            venta.origen = row.Item("nombre_agencia").ToString()
            'venta.destino = row.Item("destino").ToString()
            'Dim strCiudad As String = dtoVentaCargaContado.CiudadComprobante(row.Item("tipo"), row.Item("id"), 2)
            'If strCiudad.Trim.ToUpper = row.Item("destino").ToString.Trim.ToUpper Then
            'venta.destino = row.Item("destino").ToString()
            'Else
            'venta.destino = strCiudad
            'End If

            venta.remitenete = fecliente.nombres
            'venta.consignado = row.Item("consignado").ToString()
            'venta.tipoEntrega = row.Item("tipo_entrega").ToString()
            'venta.direccionEntrega = IIf(row("tipo_entrega") = "AGENCIA", row("agencia_destino"), row.Item("direccion_destino").ToString())
            venta.agenciaEmision = row.Item("nombre_agencia").ToString()
            venta.usuarioEmision = row.Item("login").ToString()

            Dim result = FEManager.reimprimirComprobante(venta)
            If Not (result.isCorrect) Then
                MessageBox.Show("No se puedo imprimir el Comprobante N° " & row.Item("Comprobante").ToString(), "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next


        Return

        If dGVControl_otrafactura.Rows.Count = 0 Then
            MsgBox("Seleccione una factura", MsgBoxStyle.Information, "Seguridad del Sistema")
            Exit Sub
        End If
        If IsNothing(dGVControl_otrafactura.CurrentCell) Then
            MsgBox("Seleccione una factura", MsgBoxStyle.Information, "Seguridad del Sistema")
            Exit Sub
        End If

        Dim obj As New Imprimir
        Try
            Dim TOTAL_COSTO As Double
            Dim MONTO_IMPUESTO As Double
            Dim INTERES As Double

            TOTAL_COSTO = dt.Rows(0)("total_costo_dbl")
            MONTO_IMPUESTO = dt.Rows(0)("monto_impuesto_dbl")
            INTERES = 100 * (MONTO_IMPUESTO) / (TOTAL_COSTO - MONTO_IMPUESTO)
            INTERES = Int(FormatNumber(INTERES, 2))

            If TOTAL_COSTO > 400 Then
                If MsgBox("Posiblemente esta factura este consideranda en la impresion la GLOSA DE DETRACCION" & Chr(13) & Chr(13) & " ¿DESEA IMPRIMIR LA GLOSA?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    glosa02 = "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON " & Chr(13) & _
                    "EL GOBIERNO CENTRAL, SEGÚN D.L.Nº 940-R.S. Nº158-2006-SUNAT/D.S." & Chr(13) & _
                    "Nº 033-2006-MTC." & Chr(13) & _
                    "Sirvase Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829."
                Else
                    glosa02 = ""
                End If
            Else
                glosa02 = ""
            End If

            Dim nro_letras As String = ""
            If dt.Rows(0)("IDTIPO_MONEDA") = 1 Then
                nro_letras = ConvercionNroEnLetras(TOTAL_COSTO)
            ElseIf dt.Rows(0)("IDTIPO_MONEDA") = 2 Then
                nro_letras = ConvercionNroEnLetrasDolares(TOTAL_COSTO)
            Else
                nro_letras = ""
            End If

            '19-07-2010 hlamas
            obj.Inicializar()
            'Dim sImpresora As String = obj.ObtieneImpresora(1, dtoUSUARIOS.IP)
            Dim sImpresora As String
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0

            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt2 As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 1)
            If dt2.Rows.Count = 0 Then
                sImpresora = ""
            Else
                If IsDBNull(dt2.Rows(0).Item("impresora")) Then
                    sImpresora = ""
                Else
                    sImpresora = dt2.Rows(0).Item("impresora")
                    iTamaño = dt2.Rows(0).Item("tamano")
                    iSuperior = dt2.Rows(0).Item("superior")
                    Iizquierda = dt2.Rows(0).Item("izquierda")
                End If
            End If
            obj.Impresora = sImpresora
            obj.Superior = iSuperior
            obj.Izquierda = Iizquierda

            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            'Dim iLong As Integer = 36
            Dim iLong As Integer = IIf(iTamaño = 0, 36, iTamaño)

            y = iLong * pagina + 4
            For Each row As DataRow In dt.Rows
                y += 1
                i += 1
                Dim direccion As String = "Av. Manuel Echeandia Nro.303 - San Luis - Lima - Lima"
                Dim sDoc As String = row("SERIE_FACTURA") & "-" & row("NRO_FACTURA")
                obj.EscribirLinea(y + 2, 10, direccion)
                obj.EscribirLinea(y + 1, 80, "Fact: " & sDoc)
                'obj.EscribirLinea(y, 48, "Fact: " & sDoc)

                'obj.EscribirLinea(y + 4, 8, CType(row("FECHA_FACTURA"), Date).Day)
                'obj.EscribirLinea(y + 4, 23, MonthName(Month(row("FECHA_FACTURA"))))
                'obj.EscribirLinea(y + 4, 42, Year(row("FECHA_FACTURA")))
                obj.EscribirLinea(y + 4, 10, CType(row("FECHA_FACTURA"), Date).Day)
                obj.EscribirLinea(y + 4, 25, MonthName(Month(row("FECHA_FACTURA"))))
                obj.EscribirLinea(y + 4, 44, Year(row("FECHA_FACTURA")))

                obj.EscribirLinea(y + 5, 13, IIf(IsDBNull(row("RAZON_SOCIAL")), "", row("RAZON_SOCIAL")))
                obj.EscribirLinea(y + 5, 66, IIf(IsDBNull(row("NU_DOCU_SUNA")), "", row("NU_DOCU_SUNA")))
                obj.EscribirLinea(y + 5, 105, IIf(IsDBNull(row("FERE")), "", row("FERE")))

                obj.EscribirLinea(y + 6, 13, IIf(IsDBNull(row("DIRECCION_PERSONA")), "", row("DIRECCION_PERSONA")))
                obj.EscribirLinea(y + 6, 105, IIf(IsDBNull(row("MEMO")), "", row("MEMO")))

                obj.EscribirLinea(y + 7, 105, IIf(IsDBNull(row("CONDI_PAGO")), "", row("CONDI_PAGO")))


                If Not IsDBNull(row("GLOSA")) Then
                    Dim glosa As String
                    glosa = row("GLOSA").ToString.Replace(Chr(10), "")
                    'glosa = row("GLOSA").ToString.Replace(Chr(13), "")
                    glosa = glosa.Trim & Space(300 - glosa.Length)
                    'MsgBox(Len(glosa))

                    'obj.EscribirLinea(y + 13, 16, glosa.Substring(0, 100))
                    'obj.EscribirLinea(y + 14, 16, glosa.Substring(100, 100))
                    'obj.EscribirLinea(y + 15, 16, glosa.Substring(201, 98))
                    obj.EscribirLinea(y + 13, 21, glosa.Substring(0, 72))
                    obj.EscribirLinea(y + 14, 21, glosa.Substring(72, 72))
                    obj.EscribirLinea(y + 15, 21, glosa.Substring(144, 72))
                    obj.EscribirLinea(y + 16, 21, glosa.Substring(216, 69))

                End If

                If glosa02.Trim.Length > 0 Then
                    glosa02 = glosa02.Replace(Chr(13), "")
                    'glosa02 = glosa02.Replace(Chr(10), "")
                    glosa02 = glosa02.Trim & Space(300 - glosa02.Length)

                    'obj.EscribirLinea(y + 16, 16, glosa02.Substring(0, 100))
                    'obj.EscribirLinea(y + 17, 16, glosa02.Substring(100, 100))
                    'obj.EscribirLinea(y + 18, 16, glosa02.Substring(200, 100))
                    obj.EscribirLinea(y + 17, 21, glosa02.Substring(0, 72))
                    obj.EscribirLinea(y + 18, 21, glosa02.Substring(72, 72))
                    obj.EscribirLinea(y + 19, 21, glosa02.Substring(144, 72))
                End If


                obj.EscribirLinea(y + 20, 21, "Son: " & nro_letras)
                obj.EscribirLinea(y + 21, 21, "S.E.U.O.")
                obj.EscribirLinea(y + 22, 83, INTERES.ToString("0.00"))

                obj.EscribirLinea(y + 21, 105, row("MONTO_SUBTOTAL").PadLeft(10, " "))
                obj.EscribirLinea(y + 22, 105, row("MONTO_IMPUESTO").PadLeft(10, " "))
                obj.EscribirLinea(y + 23, 105, row("TOTAL_COSTO").PadLeft(10, " "))
            Next
            obj.Comprimido = True
            obj.Preliminar = True
            obj.Tamaño = iLong
            obj.Imprimir()
            obj.Finalizar()

            Dim frm As New FrmPreview
            frm.Tamaño = iLong
            frm.Documento = 1
            frm.Text = "Facturación Otros"
            frm.ShowDialog()

            Return
            'ObjReport.rutaRpt = PathFrmReport
            'ObjReport.conectar(rptservice, rptuser, rptpass)
            'ObjReport.printrpt(False, "", "FAC030.RPT", "P_IDFACTURA_OTRO;" & dv.Table.Rows(0)("IDFACTURA_OTRO"), _
            '"P_USUARIO;" & "", _
            '"P_AGENCIA;" & "", _
            '"P_FECHA_APERTURA;" & "", _
            '"P_FECHA_CIERRE;" & "", _
            '"P_MONTO_LETRAS;" & nro_letras, _
            '"P_MENSAJE;" & "", _
            '"P_IGV;" & INTERES, _
            '"P_GLOSA02;" & glosa02, _
            '"P_IMPRESO;" & "")
            'Dim OBJFACTURA As New ClsLbTepsa.dtoFACTURA

        Catch ex As Exception
            obj.Finalizar()
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del sistema")
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub reimpresionTicket(ByVal dataTable As DataTable)
        For Each row As DataRow In dataTable.Rows
            Dim fecliente As New FECliente
            fecliente.tipoDocumentoID = row.Item("tipo_documento").ToString()
            fecliente.numeroDocumento = row.Item("numero_documento").ToString()
            fecliente.nombres = row.Item("cliente").ToString()
            fecliente.direccion = IIf(IsDBNull(row.Item("direccion_origen")), "", row.Item("direccion_origen").ToString())
            Dim venta As New FEVenta
            Dim serie As String = row.Item("Comprobante").ToString().Split("-")(0)
            Dim correlativo As String = row.Item("Comprobante").ToString().Split("-")(1)
            venta.cliente = fecliente
            venta.numeroSerie = serie
            venta.numeroCorrelativo = correlativo
            venta.fechaEmision = Convert.ToDateTime(row.Item("fecha_emision").ToString()).ToString("dd/MM/yyyy")
            venta.tipoComprobanteID = row.Item("Tipo")
            venta.opGravada = row.Item("monto_sub_total")
            venta.igv = row.Item("monto_impuesto")
            venta.total = row.Item("total_costo")
            venta.totalLetras = ConvercionNroEnLetras(venta.total)
            venta.formaPago = row.Item("tipo_pago").ToString()
            venta.producto = row.Item("producto").ToString()
            venta.origen = row.Item("origen").ToString()
            'venta.destino = row.Item("destino").ToString()
            Dim strCiudad As String = dtoVentaCargaContado.CiudadComprobante(row.Item("tipo"), row.Item("id"), 2)
            If strCiudad.Trim.ToUpper = row.Item("destino").ToString.Trim.ToUpper Then
                venta.destino = row.Item("destino").ToString()
            Else
                venta.destino = strCiudad
            End If

            venta.remitenete = fecliente.nombres
            venta.consignado = row.Item("consignado").ToString()
            venta.tipoEntrega = row.Item("tipo_entrega").ToString()
            venta.direccionEntrega = IIf(row("tipo_entrega") = "AGENCIA", row("agencia_destino"), row.Item("direccion_destino").ToString())
            venta.agenciaEmision = row.Item("agencia_emision").ToString()
            venta.usuarioEmision = row.Item("usuario").ToString()

            Dim result = FEManager.reimprimirComprobante(venta)
            If Not (result.isCorrect) Then
                MessageBox.Show("No se puedo imprimir el Comprobante N° " & row.Item("Comprobante").ToString(), "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next
    End Sub
End Class
