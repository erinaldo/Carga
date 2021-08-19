Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
'Imports System.Data
'Imports AccesoDatos
Public Class FrmPrefacturacion
    Dim dtGuias, dtguiasclon As New DataTable
    Dim dvGuias, dvguiasclon As New DataView
    Dim vAccionRegistro As Integer
    Dim FiltroActual As String
    Dim bIngreso As Boolean = False
    Public hnd As Long

    'hlamas 16-09-2013 personalizado quimica suiza
    Dim ID_PERSONA_QUIMICA_SUIZA As Integer = 1290

    Private Sub FrmPrefacturacion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmPrefacturacion_MenuCancelar() Handles Me.MenuCancelar
        FrmPrefacturacion_ClickTabPage1()

        Me.MenuStrip1.Items(0).Enabled = True
        Me.MenuStrip1.Items(2).Visible = False
        Me.MenuStrip1.Items(2).Enabled = False
        Me.MenuStrip1.Items(3).Enabled = False
        Me.MenuTab.Items(0).Enabled = True
        SelectMenu(0)
    End Sub

    Private Sub FrmPrefacturacion_ClickTabPage1() Handles Me.ClickTabPage1
        'Me.dvGuias.RowFilter = ""
        'Me.chkSoloPendientes.Checked = False
        'Me.chkSoloPendientes.Checked = True

        'Me.QuitarTodoFiltroToolStripMenuItem.PerformClick()

        'hlamas 10-08-2015
        'Me.dvGuias.RowFilter = "PREFACTURADO = 0 "

        Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
    End Sub
    Private Sub FrmPrefacturacion_ClickTabPage2() Handles Me.ClickTabPage2
        Try
            '
            dgvGuiasFinal.Rows.Clear()
            If Me.dgvGuiasEnvio.RowCount > 0 Then
                txtNroPreFacturaFinal.Text = txtNroPreFactura.Text
                txtCodigoClienteFinal.Text = txtCodigoCliente.Text
                txtRazonSocialClienteFinal.Text = txtRazonSocialCliente.Text
                '
                Me.MenuStrip1.Items(0).Enabled = False
                Me.MenuStrip1.Items(2).Visible = True
                Me.MenuStrip1.Items(2).Enabled = True
                Me.MenuStrip1.Items(3).Enabled = True
                Me.MenuTab.Items(0).Enabled = False

                ' Linea ingresada por Tepsa 
                'dtGuias.EndInit()
                'Me.dgvGuiasEnvio.EndEdit()  'Grabando el final de las guias
                'Me.dgvGuiasEnvio.Refresh()

                'hlamas 10-08-2015
                'configurar_dtguias()
                'dvguiasclon = dvGuias
                'If (Me.TxtDt.Visible And Me.TxtDt.Text.Trim.Length = 7) Or Me.cmbCentroCosto.SelectedValue = 0 Then
                'dvguiasclon.RowFilter = "prefacturado=0 and seleccionar=1"
                'Else
                'dvguiasclon.RowFilter = "prefacturado=0 and seleccionar=1" & IIf(cmbCentroCosto.Text.Trim <> "", " and Centro_Costo = '" & cmbCentroCosto.Text.Trim & "'", "")  ' Tepsa   
                'End If

                'hlamas 10-08-2015
                'dgvGuiasFinal.DataSource = dvguiasclon
                CargarPendientesFacturar()

                'hlamas 10-08-2015
                'dgvGuiasFinal.Columns(0).Visible = False
                'dgvGuiasFinal.Columns(4).Visible = False
                'dgvGuiasFinal.Columns(8).Visible = False
                'dgvGuiasFinal.Columns(13).Visible = False
                'dgvGuiasFinal.Columns(14).Visible = False
                'dgvGuiasFinal.Columns(15).Visible = False
                'dgvGuiasFinal.Columns(16).Visible = False
                'dgvGuiasFinal.Columns(18).Visible = False

                '
                Labreggrabar.Text = "Nº Registro : " + CType(dgvGuiasFinal.RowCount, String)
                ' 
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Sub CargarPendientesFacturar()
        With dgvGuiasEnvio
            Dim dblSubtotal_1 As Double = 0, dblImpuesto_1 As Double = 0, dblTotal_1 As Double = 0
            Dim strRuc As String = "", strRazonSocial As String = "" : Dim blnOk As Boolean

            For Each row As DataGridViewRow In .Rows
                If (Me.TxtDt.Visible And Me.TxtDt.Text.Trim.Length = 7) Or Me.cmbCentroCosto.SelectedValue = 0 Then
                    blnOk = row.Cells("seleccionar").Value = 1 And row.Cells("prefacturado").Value = 0
                Else
                    If Me.cmbCentroCosto.SelectedValue = 0 Then
                        blnOk = row.Cells("seleccionar").Value = 1 And row.Cells("prefacturado").Value = 0
                    Else
                        blnOk = row.Cells("seleccionar").Value = 1 And row.Cells("prefacturado").Value = 0 And row.Cells("centro_costo").Value = Me.cmbCentroCosto.Text.Trim
                    End If
                End If
                If blnOk Then
                    With dgvGuiasFinal
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Cells("origen").Value = row.Cells("origen").Value
                        .Rows(.Rows.Count - 1).Cells("destino").Value = row.Cells("destino").Value
                        .Rows(.Rows.Count - 1).Cells("nro_guia").Value = row.Cells("nro_guia").Value
                        .Rows(.Rows.Count - 1).Cells("consignado").Value = row.Cells("consignado").Value
                        .Rows(.Rows.Count - 1).Cells("cantidad").Value = row.Cells("cantidad").Value
                        .Rows(.Rows.Count - 1).Cells("total_peso").Value = row.Cells("total_peso").Value
                        .Rows(.Rows.Count - 1).Cells("monto_base").Value = row.Cells("monto_base").Value
                        .Rows(.Rows.Count - 1).Cells("forma_pago").Value = row.Cells("forma_pago").Value
                        .Rows(.Rows.Count - 1).Cells("importe_bruto").Value = row.Cells("importe_bruto").Value
                        .Rows(.Rows.Count - 1).Cells("importe_igv").Value = row.Cells("importe_igv").Value
                        .Rows(.Rows.Count - 1).Cells("centro_costo").Value = row.Cells("centro_costo").Value
                        .Rows(.Rows.Count - 1).Cells("guia").Value = row.Cells("guia").Value

                        'If (Me.TxtDt.Visible And Me.TxtDt.Text.Trim.Length = 7) Or Me.cmbCentroCosto.SelectedValue = 0 Then
                        'dvguiasclon.RowFilter = "prefacturado=0 and seleccionar=1"
                        'Else
                        'dvguiasclon.RowFilter = "prefacturado=0 and seleccionar=1" & IIf(cmbCentroCosto.Text.Trim <> "", " and Centro_Costo = '" & cmbCentroCosto.Text.Trim & "'", "")  ' Tepsa   
                        'End If

                        'Dim dblSubtotal As Double = row.Cells("subtotal").Value
                        'Dim dblTotal As Double = dblSubtotal * (1 + (dtoUSUARIOS.iIGV / 100))
                        'Dim dblImpuesto As Double = dblTotal - dblSubtotal
                        'dblSubtotal_1 += dblSubtotal
                        'dblImpuesto_1 += dblImpuesto
                        'dblTotal_1 += dblTotal

                        '.Rows(.Rows.Count - 1).Cells("subtotal").Value = Format(dblSubtotal, "###,###,###0.00")
                        '.Rows(.Rows.Count - 1).Cells("impuesto").Value = Format(dblImpuesto, "###,###,###0.00")
                        '.Rows(.Rows.Count - 1).Cells("total").Value = Format(dblTotal, "###,###,###0.00")
                    End With
                End If
            Next
            'Totales
            'Me.lblSubtotal.Text = Format(dblSubtotal_1, "###,###,###0.00")
            'Me.lblImpuesto.Text = Format(dblImpuesto_1, "###,###,###0.00")
            'Me.lblTotal.Text = Format(dblTotal_1, "###,###,###0.00")
        End With
    End Sub

    Private Sub FrmPrefacturacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmPrefacturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            vAccionRegistro = 1
            Me.cmbCentroCosto.DropDownStyle = ComboBoxStyle.DropDownList
            'Tepsa
            MyUsuario = dtoUSUARIOS.IdLogin
            MyRol = dtoUSUARIOS.IdRol
            MyIP = dtoUSUARIOS.IP
            '
            Me.ShadowLabel1.Text = "Pre - Facturación"
            Me.SplitContainer2.Panel1Collapsed = True
            Me.MenuTab.Items(0).Text = "GUIAS DE ENVIO"
            Me.MenuTab.Items(1).Text = "PRE FACTURA"
            HabilitarMenu(MenuTab)

            Me.MenuStrip1.Items(1).Enabled = False
            Me.btnGenerar.Enabled = False
            '
            Fecha1._MyFecha = dtoUSUARIOS.dfecha_sistema
            Fecha2._MyFecha = dtoUSUARIOS.dfecha_sistema
            '
            ''Agregar Datos CboProducto - Pruebaa
            'Me.txtCodigoCliente.Focus()
            'cboProducto.Text = "SELECCIONE"
            'cboProducto.Items.Add("TEPSA COURIER")
            '' Fin

            'hlamas 03-10-2013
            Dim obj As New dtoVentaCargaContado
            With Me.cmbProducto
                .DataSource = obj.ListarProducto(2)
                .ValueMember = "idprocesos"
                .DisplayMember = "procesos"
                .SelectedValue = 0
            End With
            ConfigurarDGVGuiasFinal()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub FrmPrefacturacion_MenuGrabar() Handles Me.MenuGrabar
        Try
            Dim MyPrefactura As New dtoPREFACTURA
            With MyPrefactura
                .Accion = vAccionRegistro
                .IDPreFactura = 1 'Momentaneamente
                .NroPreFactura = Me.txtNroPreFactura.Text
                .IDPersona = Me.txtCodigoCliente.Text
                .MontoPrefactura = Me.txtMontoPreFacturaFinal.Text
                .Producto = Me.cmbProducto.SelectedValue
                .Usuario = dtoUSUARIOS.IdLogin
            End With

            Dim respPreFacturas As DataTable
            respPreFacturas = MyPrefactura.AgregaPreFactura()
            Dim a As DataTable = respPreFacturas
            'Dim a As New DataTable
            'Dim da As New OleDb.OleDbDataAdapter
            'da.Fill(a, respPreFacturas)

            'If respPreFacturas.Fields.Count = 1 Then 'Se realizo Correctamente.
            If a.Rows.Count > 0 Then
                If a.Rows(0)(0).ToString = "INSERTADO SATISFACTORIAMENTE" Then
                    Dim obj As New dtoPREFACTURA
                    For I As Integer = 0 To Me.dgvGuiasFinal.RowCount - 1
                        Dim RespAsocia As DataTable = obj.ASOCIA_GUIA_PREFACTURA(Me.txtNroPreFacturaFinal.Text, Me.dgvGuiasFinal.Rows(I).Cells("NRO_GUIA").Value, MyUsuario, MyRol, MyIP)
                        'datahelper
                        'Dim MyObjeAsociar As Object() = {"PKG_IVOPERSONA.SP_ASOCIA_GUIA_PREFACTURA", 12, _
                        '                                                Me.txtNroPreFacturaFinal.Text, 2, _
                        '                                                Me.dgvGuiasFinal.Rows(I).Cells("NRO_GUIA").Value, 2, _
                        '                                                MyUsuario, 1, _
                        '                                                MyRol, 1, _
                        '                                                MyIP, 2}
                        'Dim RespAsocia As ADODB.Recordset
                        'RespAsocia = VOCONTROLUSUARIO.fnSQLQuery(MyObjeAsociar)
                    Next
                    MessageBox.Show("Guardado Satisfactoriamente", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.MenuStrip1.Items(2).Enabled = False
                    Me.MenuStrip1.Items(3).Enabled = False

                    SelectMenu(0)

                    Me.dgvGuiasEnvio.Columns.Clear()

                    'hlamas 10-08-2015
                    'Me.dgvGuiasFinal.Columns.Clear()

                    Me.txtNroPreFactura.Text = ""
                    Me.txtNroPreFacturaFinal.Text = ""
                    Me.txtMontoFinalPreFacturar.Text = ""
                    Me.txtMontoPreFacturaFinal.Text = ""
                    Me.txtRazonSocialCliente.Text = ""
                    Me.txtRazonSocialClienteFinal.Text = ""
                    Me.txtTipofacturacion.Text = ""
                    Me.txtCodigoCliente.Text = ""
                    Me.txtCodigoClienteFinal.Text = ""
                    Me.cmbCentroCosto.DataSource = Nothing
                    Me.cmbDestinos.DataSource = Nothing

                    'hlamas 16-09-2013
                    Me.TxtDt.Text = ""
                    Me.LblDt.Visible = False
                    Me.TxtDt.Visible = False

                    Me.txtCodigoCliente.Focus()
                    Me.txtSumatoriaMonto.Text = "0.0"
                    labnroregselecciona.Text = "Nro Reg. Seleccionado : 0"
                ElseIf a.Rows(0)(0).ToString = "PREFACTURA YA EXISTE" Then
                    MessageBox.Show("La Prefactura ya Existe", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf respPreFacturas.Rows.Count = 2 And Len(Trim(respPreFacturas.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                MessageBox.Show("Descripción: " & respPreFacturas.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respPreFacturas.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch Qex As Exception
            MessageBox.Show(Qex.Message)
        End Try


        'datahelper
        'Try
        '    Dim MyPrefactura As New dtoPREFACTURA
        '    With MyPrefactura
        '        .Accion = vAccionRegistro
        '        .IDPreFactura = 1 'Momentaneamente
        '        .NroPreFactura = Me.txtNroPreFactura.Text
        '        .IDPersona = Me.txtCodigoCliente.Text
        '        .MontoPrefactura = Me.txtMontoPreFacturaFinal.Text
        '    End With

        '    Dim respPreFacturas As ADODB.Recordset
        '    respPreFacturas = MyPrefactura.AgregaPreFactura()
        '    Dim a As New DataTable
        '    Dim da As New OleDb.OleDbDataAdapter
        '    da.Fill(a, respPreFacturas)

        '    'If respPreFacturas.Fields.Count = 1 Then 'Se realizo Correctamente.
        '    If a.Rows.Count > 0 Then
        '        If a.Rows(0)(0).ToString = "INSERTADO SATISFACTORIAMENTE" Then
        '            'MessageBox.Show(respPreFacturas.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            For I As Integer = 0 To Me.dgvGuiasFinal.RowCount - 1
        '                '   Dim MyObjeAsociar As Object() = {"PKG_IVOPERSONA.SP_ASOCIA_GUIA_PREFACTURA", 14, Me.txtNroPreFacturaFinal.Text, 2, Me.dgvGuiasFinal.Rows(I).Cells("NRO_GUIA").Value, 2, MyUsuario, 1, MyRol, 1, MyIP, 2} 'Comentado por TEPSA
        '                Dim MyObjeAsociar As Object() = {"PKG_IVOPERSONA.SP_ASOCIA_GUIA_PREFACTURA", 12, _
        '                                                                Me.txtNroPreFacturaFinal.Text, 2, _
        '                                                                Me.dgvGuiasFinal.Rows(I).Cells("NRO_GUIA").Value, 2, _
        '                                                                MyUsuario, 1, _
        '                                                                MyRol, 1, _
        '                                                                MyIP, 2}
        '                Dim RespAsocia As ADODB.Recordset
        '                RespAsocia = VOCONTROLUSUARIO.fnSQLQuery(MyObjeAsociar)
        '                'MessageBox.Show(I)
        '            Next
        '            MessageBox.Show("Guardado Satisfactoriamente", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Me.MenuStrip1.Items(2).Enabled = False
        '            Me.MenuStrip1.Items(3).Enabled = False

        '            SelectMenu(0)

        '            Me.dgvGuiasEnvio.Columns.Clear()
        '            Me.dgvGuiasFinal.Columns.Clear()
        '            Me.txtNroPreFactura.Text = ""
        '            Me.txtNroPreFacturaFinal.Text = ""
        '            Me.txtMontoFinalPreFacturar.Text = ""
        '            Me.txtMontoPreFacturaFinal.Text = ""
        '            Me.txtRazonSocialCliente.Text = ""
        '            Me.txtRazonSocialClienteFinal.Text = ""
        '            Me.txtTipofacturacion.Text = ""
        '            Me.txtCodigoCliente.Text = ""
        '            Me.txtCodigoClienteFinal.Text = ""
        '            Me.cmbCentroCosto.DataSource = Nothing
        '            Me.cmbDestinos.DataSource = Nothing
        '            Me.txtCodigoCliente.Focus()
        '            Me.txtSumatoriaMonto.Text = "0.0"
        '            labnroregselecciona.Text = "Nro Reg. Seleccionado : 0"
        '        ElseIf a.Rows(0)(0).ToString = "PREFACTURA YA EXISTE" Then
        '            MessageBox.Show("La Prefactura ya Existe", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        End If
        '    ElseIf respPreFacturas.Fields.Count = 2 And Len(Trim(respPreFacturas.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
        '        MessageBox.Show("Descripción: " & respPreFacturas.Fields(1).Value, "ORACLE -> Error: " & respPreFacturas.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End If

        'Catch Qex As Exception
        '    MessageBox.Show(Qex.Message)
        'End Try
    End Sub

    Private Sub FrmPrefacturacion_MenuNuevo() Handles Me.MenuNuevo
        Me.dgvGuiasEnvio.Columns.Clear()

        'hlamas 10-08-2015
        'Me.dgvGuiasFinal.Columns.Clear()

        Me.txtNroPreFactura.Text = ""
        Me.txtNroPreFacturaFinal.Text = ""
        Me.txtMontoFinalPreFacturar.Text = ""
        Me.txtMontoPreFacturaFinal.Text = ""
        Me.txtRazonSocialCliente.Text = ""
        Me.txtRazonSocialClienteFinal.Text = ""
        Me.txtTipofacturacion.Text = ""
        Me.txtCodigoCliente.Text = ""
        Me.cmbCentroCosto.DataSource = Nothing
        Me.cmbDestinos.DataSource = Nothing
        'hlamas 16-09-2013
        Me.TxtDt.Text = ""
        Me.LblDt.Visible = False
        Me.TxtDt.Visible = False
        Me.txtCodigoCliente.Focus()
    End Sub

    Private Sub FrmPreFactura_MenuSalir() Handles Me.MenuSalir
        Me.Close()
    End Sub
    Private Sub txtCodigoCliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoCliente.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtCodigoCliente.Text.Length <> 0 Then
                    Dim sfec_inicio As String
                    Dim sfec_final As String
                    Dim snro_prefactura As String
                    sfec_inicio = Fecha1.GetMyFecha()
                    sfec_final = Fecha2.GetMyFecha
                    If txtNroPreFactura.Text = "" Then
                        snro_prefactura = "null"
                    Else
                        snro_prefactura = CType(txtNroPreFactura.Text, String)
                    End If

                    'hlamas 16-09-2013
                    Dim sDT As String = IIf(TxtDt.Visible And TxtDt.Text.Trim.Length = 7, TxtDt.Text, "")
                    Dim intProducto As Integer = Me.cmbProducto.SelectedValue
                    Dim ds As DataSet = Funciones.ClientePrefactura_new(1, txtCodigoCliente.Text, sfec_inicio, sfec_final, snro_prefactura, sDT, intProducto)
                    Dim dtCliente As DataTable = ds.Tables(0)
                    ''
                    'dtGuias = Nothing
                    'dtGuias = New DataTable
                    ''
                    'dtGuias = ds.Tables(1) '03/12/2009 - 
                    '
                    'Dim dtNroPrefactura As DataTable = ds.Tables(2)
                    Dim dtSubCuentas As DataTable = ds.Tables(3)
                    Dim dtDestinos As DataTable = ds.Tables(4)

                    If dtCliente.Columns(0).ColumnName = "EXISTE" Then
                        MessageBox.Show(dtCliente.Rows(0)(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtCodigoCliente.Text = ""
                        Me.txtRazonSocialCliente.Text = ""
                        Me.txtTipofacturacion.Text = ""
                    Else
                        Me.txtCodigoCliente.Text = dtCliente.Rows(0)(0).ToString
                        Me.txtRazonSocialCliente.Text = dtCliente.Rows(0)(1).ToString
                        Me.txtTipofacturacion.Text = dtCliente.Rows(0)(2).ToString

                        'Me.txtNroPreFactura.Text = dtNroPrefactura.Rows(0)(0).ToString
                        Me.txtNroPreFactura.Text = ""

                        cmbCentroCosto.DataSource = dtSubCuentas.DefaultView
                        cmbCentroCosto.DisplayMember = "CENTRO_COSTO"
                        cmbCentroCosto.ValueMember = "IDCENTRO_COSTO"

                        Me.cmbDestinos.DataSource = dtDestinos.DefaultView
                        Me.cmbDestinos.DisplayMember = "NOMBRE_UNIDAD"
                        Me.cmbDestinos.ValueMember = "IDUNIDAD_AGENCIA_DESTINO"
                        Me.cmbDestinos.SelectedValue = 99999

                        'hlamas 16-09-2013
                        If dtCliente.Rows(0)(3) = ID_PERSONA_QUIMICA_SUIZA Then
                            Me.LblDt.Visible = True
                            Me.TxtDt.Visible = True
                        Else
                            Me.TxtDt.Text = ""
                            Me.LblDt.Visible = False
                            Me.TxtDt.Visible = False
                        End If

                        Me.btnGenerar.Enabled = True

                    End If
                Else
                    MessageBox.Show("Ingrese el Código de un Cliente de Tipo III", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            ElseIf e.KeyCode = Keys.F1 Then
                Dim FrmBusFuncionario As FrmBusquedaClientes = New FrmBusquedaClientes
                FrmBusFuncionario.txtNombreFuncionario.Text = Me.txtCodigoCliente.Text
                FrmBusFuncionario.CodigoFuncionario = Me.txtCodigoCliente.Text
                FrmBusFuncionario.BuscaPor = 1
                Dim resultado As DialogResult
                'resultado = FrmBusFuncionario.ShowDialog()

                Acceso.Asignar(FrmBusFuncionario, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    resultado = FrmBusFuncionario.ShowDialog()
                Else
                    MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim FuncionarioNegocio As String = FrmBusFuncionario.NombreFuncionario
                If FrmBusFuncionario.CodigoFuncionario.Trim = "Ingrese un Valor..." Or FrmBusFuncionario.CodigoFuncionario.Trim = "" Then
                    Me.txtCodigoCliente.Text = ""
                    Me.txtRazonSocialCliente.Text = ""
                Else
                    Me.txtCodigoCliente.Text = FrmBusFuncionario.CodigoFuncionario
                    Me.txtRazonSocialCliente.Text = FrmBusFuncionario.NombreFuncionario
                End If

            End If

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargaComboDestinos()

        For i As Integer = 0 To Me.dgvGuiasEnvio.RowCount - 1
            cmbDestinos.Items.Add(Me.dgvGuiasEnvio.Rows(i).Cells("DESTINO").Value.ToString)
        Next

        Me.cmbDestinos.SelectedIndex = 0
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try
            '--
            If txtRazonSocialCliente.Text = "" Then
                MessageBox.Show("Seleccione el Cliente", "Prefacturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtRazonSocialCliente.Focus()
            End If
            '--
            If Fecha1.GetMyFecha = "  /  /" Then
                MessageBox.Show("Ingrese la fecha inicial", "Prefacturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtRazonSocialCliente.Focus()
                Exit Sub
            End If
            '-- 
            If Fecha2.GetMyFecha = "  /  /" Then
                MessageBox.Show("Ingrese la fecha final", "Prefacturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtRazonSocialCliente.Focus()
                Exit Sub
            End If

            If Me.cmbProducto.SelectedValue = 0 Then 'And Me.TxtDt.Text.Trim.Length = 0 Then
                MessageBox.Show("Seleccione el Producto", "Prefacturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbProducto.Focus()
                Exit Sub
            End If

            ' ------------------------------------------------------------------
            Dim sfec_inicio As String
            Dim sfec_final As String
            Dim snro_prefactura As String
            sfec_inicio = Fecha1.GetMyFecha()
            sfec_final = Fecha2.GetMyFecha
            If txtNroPreFactura.Text = "" Then
                snro_prefactura = "null"
            Else
                snro_prefactura = CType(txtNroPreFactura.Text, String)
            End If

            'hlamas 16-09-2013
            Dim sDT As String = IIf(TxtDt.Visible And TxtDt.Text.Trim.Length > 0, TxtDt.Text, "")
            Dim intProducto As Integer = Me.cmbProducto.SelectedValue
            Dim ds As DataSet = Funciones.ClientePrefactura_new(1, txtCodigoCliente.Text, sfec_inicio, sfec_final, snro_prefactura, sDT, intProducto)
            Dim dtCliente As DataTable = ds.Tables(0)
            dtGuias = ds.Tables(1)
            Dim dtNroPrefactura As DataTable = ds.Tables(2)
            Dim dtSubCuentas As DataTable = ds.Tables(3)
            Dim dtDestinos As DataTable = ds.Tables(4)
            If dtCliente.Columns(0).ColumnName = "EXISTE" Then
                MessageBox.Show(dtCliente.Rows(0)(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtCodigoCliente.Text = ""
                Me.txtRazonSocialCliente.Text = ""
                Me.txtTipofacturacion.Text = ""
                Me.txtNroPreFactura.Text = ""
            Else
                Me.txtCodigoCliente.Text = dtCliente.Rows(0)(0).ToString
                Me.txtRazonSocialCliente.Text = dtCliente.Rows(0)(1).ToString
                Me.txtTipofacturacion.Text = dtCliente.Rows(0)(2).ToString
                Me.txtNroPreFactura.Text = dtNroPrefactura.Rows(0)(0).ToString
                '
                cmbCentroCosto.DataSource = dtSubCuentas.DefaultView
                cmbCentroCosto.DisplayMember = "CENTRO_COSTO"
                cmbCentroCosto.ValueMember = "IDCENTRO_COSTO"
                '
                Me.cmbDestinos.DataSource = dtDestinos.DefaultView
                Me.cmbDestinos.DisplayMember = "NOMBRE_UNIDAD"
                Me.cmbDestinos.ValueMember = "IDUNIDAD_AGENCIA_DESTINO"
                Me.cmbDestinos.SelectedValue = 99999
                '
                Me.btnGenerar.Enabled = True
                '
                Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
            End If

            '--------------------------------------------------
            dgvGuiasEnvio.Columns.Clear()
            'hlamas 03-08-2015
            dvGuias = dtGuias.DefaultView

            With dgvGuiasEnvio
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                'hlamas 03-08-2015
                '.DataSource = dvGuias  'dtGuias.DefaultView    tepsa omendoza 
                .DataSource = dtGuias.DefaultView

                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect

                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .ReadOnly = False
                .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            End With

            Dim col0 As New DataGridViewTextBoxColumn
            With col0
                .HeaderText = "ORDEN"
                .Name = "ORDEN"
                .DataPropertyName = "ORDEN"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .HeaderText = "ORIGEN"
                .Name = "ORIGEN"
                .DataPropertyName = "ORIGEN"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .HeaderText = "DESTINO"
                .Name = "DESTINO"
                .DataPropertyName = "DESTINO"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            Dim col3 As New DataGridViewTextBoxColumn
            With col3
                .HeaderText = "NRO GUIA"
                .Name = "NRO_GUIA"
                .DataPropertyName = "NRO_GUIA"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .HeaderText = "FECHA GUIA"
                .Name = "FECHA_GUIA"
                .DataPropertyName = "FECHA_GUIA"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            Dim Col5 As New DataGridViewTextBoxColumn
            With Col5
                .HeaderText = "CONSIGNADO"
                .Name = "CONSIGNADO"
                .DataPropertyName = "CONSIGNADO"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            Dim col6 As New DataGridViewTextBoxColumn
            With col6
                .HeaderText = "CANTIDAD"
                .Name = "CANTIDAD"
                .DataPropertyName = "CANTIDAD"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            Dim col7 As New DataGridViewTextBoxColumn
            With col7
                .HeaderText = "TOTAL PESO"
                .Name = "TOTAL_PESO"
                .DataPropertyName = "TOTAL_PESO"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            Dim col8 As New DataGridViewTextBoxColumn
            With col8
                .HeaderText = "TOTAL VOLUMEN"
                .Name = "TOTAL_VOLUMEN"
                .DataPropertyName = "TOTAL_VOLUMEN"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            Dim col9 As New DataGridViewTextBoxColumn
            With col9
                .HeaderText = "MONTO BASE"
                .Name = "MONTO_BASE"
                .DataPropertyName = "MONTO_BASE"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            Dim col10 As New DataGridViewTextBoxColumn
            With col10
                .HeaderText = "FORMA PAGO"
                .Name = "FORMA_PAGO"
                .DataPropertyName = "FORMA_PAGO"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            Dim col11 As New DataGridViewTextBoxColumn
            With col11
                .HeaderText = "IMPORTE BRUTO"
                .Name = "IMPORTE_BRUTO"
                .DataPropertyName = "IMPORTE_BRUTO"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
            End With

            Dim col12 As New DataGridViewTextBoxColumn
            With col12
                .HeaderText = "IMPORTE IGV"
                .Name = "IMPORTE_IGV"
                .DataPropertyName = "IMPORTE_IGV"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
            End With

            Dim Col13 As New DataGridViewTextBoxColumn
            With Col13
                .HeaderText = "TOTAL COSTO"
                .Name = "TOTAL_COSTO"
                .DataPropertyName = "TOTAL_COSTO"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
            End With

            Dim Col14 As New DataGridViewTextBoxColumn
            With Col14
                .HeaderText = "ESTADO REGISTRO"
                .Name = "ESTADO_REGISTRO"
                .DataPropertyName = "ESTADO_REGISTRO"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim Col15 As New DataGridViewCheckBoxColumn
            With Col15
                .HeaderText = "PREFACTURADO"
                ' .Name = "¿PREFACTURADO?" Tepsa 
                .Name = "PREFACTURADO"
                '.DataPropertyName = "¿PREFACTURADO?"  Tepsa 
                .DataPropertyName = "PREFACTURADO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .ReadOnly = True
                .Visible = True
                '.FlatStyle = FlatStyle.Standard
                '.CellTemplate = New DataGridViewCheckBoxCell()
                '.CellTemplate.Style.BackColor = Color.Beige
            End With

            Dim Col16 As New DataGridViewCheckBoxColumn
            With Col16
                .HeaderText = "SELECCIONAR"
                .Name = "SELECCIONAR"
                .DataPropertyName = "SELECCIONAR"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                '.FlatStyle = FlatStyle.Standard
                '.CellTemplate = New DataGridViewCheckBoxCell()
                '.CellTemplate.Style.BackColor = Color.Beige
            End With

            Dim Col17 As New DataGridViewTextBoxColumn
            With Col17
                .HeaderText = "CENTRO COSTO"
                .Name = "Centro_Costo"
                .DataPropertyName = "Centro_Costo"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim Col18 As New DataGridViewTextBoxColumn
            With Col18
                .HeaderText = "DT"
                .Name = "dt"
                .DataPropertyName = "dt"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim Col19 As New DataGridViewTextBoxColumn
            With Col19
                .HeaderText = "ID Guia"
                .Name = "guia"
                .DataPropertyName = "guia"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .Visible = True
            End With

            'Centro_Costo
            Me.dgvGuiasEnvio.Columns.AddRange(col0, Col18, col1, col2, col3, col4, Col5, col6, col7, col8, col9, col10, col11, col12, Col13, Col14, Col15, Col16, Col17, Col19)

            'hlamas 21-09-2013
            If Me.TxtDt.Visible Then
                dgvGuiasEnvio.Columns(1).Visible = True
            Else
                dgvGuiasEnvio.Columns(1).Visible = False
            End If
            dgvGuiasEnvio.Columns(6).Visible = False
            'dgvGuiasEnvio.Columns(7).Visible = False
            dgvGuiasEnvio.Columns(8).Visible = False
            dgvGuiasEnvio.Columns(9).Visible = False
            dgvGuiasEnvio.Columns(10).Visible = False
            dgvGuiasEnvio.Columns(11).Visible = False
            dgvGuiasEnvio.Columns(13).Visible = False
            dgvGuiasEnvio.Columns(19).Visible = False
            'dgvGuiasEnvio.Columns(13).Visible = False


            'hlamas 03-08-2015 desactivar
            'For i As Integer = 0 To Me.dgvGuiasEnvio.RowCount - 1
            '    If Me.dgvGuiasEnvio.Rows(i).Cells("ESTADO_REGISTRO").Value = "CARGOS" Then
            '        Dim drw As DataRowView = CType(Me.dgvGuiasEnvio.DataSource, DataView).Item(i)
            '        drw("SELECCIONAR") = 1
            '    End If
            'Next
            '----------------------------------------------------------------

            Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
            chkSoloPendientes.Checked = True

            Me.dvGuias.RowFilter = "PREFACTURADO = 0 "

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Function SumaPreciosGuias() As Double
        Dim suma As Double
        Dim sum_importe_bruto As Double = 0

        Dim inroregseleccionado As Integer = 0
        For i As Integer = 0 To Me.dvGuias.Count - 1
            Dim b As DataRowView = Me.dvGuias.Item(i) '(Me.dgvGuiasEnvio.CurrentRow.Index)
            If b("prefacturado") <> 1 Then 'b(15)
                If b("seleccionar") = 1 Then  'b(16)
                    suma = b("total_costo") + suma 'b(13) + suma
                    sum_importe_bruto = sum_importe_bruto + b("Importe_bruto")
                    inroregseleccionado = inroregseleccionado + 1
                End If
            End If
        Next
        labnroregselecciona.Text = "Nro Reg. Seleccionado : " + CType(inroregseleccionado, String)
        suma = sum_importe_bruto + FormatNumber(sum_importe_bruto * dtoUSUARIOS.vImpuesto, 2)
        Return suma
    End Function
    Private Sub dgvGuiasEnvio_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvGuiasEnvio.CellMouseUp
        ' Se comenta todo por parte de Tepsa 
        'Try
        '    If e.Button = Windows.Forms.MouseButtons.Left Then
        '        Dim a As DataRowView = Me.dvGuias.Item(Me.dgvGuiasEnvio.CurrentRow.Index)

        '        'If a(14) = 0 Then 'Ya esta Seleccionado
        '        '    If a(14) = 0 Then
        '        '        a(14) = 1
        '        '        Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
        '        '        Exit Sub
        '        '    End If
        '        'End If

        '        'If a(14) = 1 Then 'Ya esta Seleccionado
        '        '    If a(14) = 1 Then
        '        '        a(14) = 0
        '        '        Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
        '        '        Exit Sub
        '        '    End If
        '        'End If
        '        If a(16) = 0 Then 'Ya esta Seleccionado
        '            If a(16) = 0 Then
        '                a(16) = 1
        '                Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
        '                Exit Sub
        '            End If
        '        End If

        '        If a(16) = 1 Then 'Ya esta Seleccionado
        '            If a(16) = 1 Then
        '                a(16) = 0
        '                Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
        '                Exit Sub
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception

        'End Try        
    End Sub
    Private Sub txtSumatoriaMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSumatoriaMonto.TextChanged
        txtMontoFinalPreFacturar.Text = Me.txtSumatoriaMonto.Text
        txtMontoPreFacturaFinal.Text = Me.txtSumatoriaMonto.Text
    End Sub
    Private Sub SeleccionarTodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarTodosToolStripMenuItem.Click
        Try
            If Me.dgvGuiasEnvio.RowCount > 0 Then
                For i As Integer = 0 To Me.dgvGuiasEnvio.RowCount - 1
                    'Me.dgvGuiasEnvio.Rows(i).Cells(14).Value = 1
                    Me.dgvGuiasEnvio.Rows(i).Cells("seleccionar").Value = 1
                Next
                Me.dgvGuiasEnvio.EndEdit()
                If Me.dgvGuiasEnvio.CurrentRow.Index = 0 Then 'Si el Foco esta en la Primera Fila.
                    'Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(Me.dgvGuiasEnvio.RowCount - 1).Cells(14)
                    Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(Me.dgvGuiasEnvio.RowCount - 1).Cells("seleccionar")
                ElseIf Me.dgvGuiasEnvio.CurrentRow.Index = Me.dgvGuiasEnvio.RowCount - 1 Then 'Si el Foco esta en la Ultima Fila.
                    'Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(0).Cells(14)
                    Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(0).Cells("seleccionar")
                ElseIf Me.dgvGuiasEnvio.CurrentRow.Index > 0 And Me.dgvGuiasEnvio.CurrentRow.Index < Me.dgvGuiasEnvio.RowCount - 1 Then 'Si el Foco esta en las Filas Intermedias.
                    'Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(0).Cells(14)
                    Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(0).Cells("seleccionar")
                End If
                Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
            Else
                MessageBox.Show("No hay Registros que seleccionar", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub SeleccionarHastaEstaPosicionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarHastaEstaPosicionToolStripMenuItem.Click
        Try
            If Me.dgvGuiasEnvio.RowCount > 0 Then
                For i As Integer = 0 To Me.dgvGuiasEnvio.RowCount - 1
                    'Me.dgvGuiasEnvio.Rows(i).Cells(14).Value = 0
                    Me.dgvGuiasEnvio.Rows(i).Cells("seleccionar").Value = 0
                Next

                For i As Integer = 0 To Me.dgvGuiasEnvio.CurrentRow.Index
                    'Me.dgvGuiasEnvio.Rows(i).Cells(14).Value = 1
                    Me.dgvGuiasEnvio.Rows(i).Cells("seleccionar").Value = 1
                Next

                Me.dgvGuiasEnvio.EndEdit()
                If Me.dgvGuiasEnvio.CurrentRow.Index = 0 Then 'Si el Foco esta en la Primera Fila.
                    'Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(Me.dgvGuiasEnvio.RowCount - 1).Cells(14)
                    Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(Me.dgvGuiasEnvio.RowCount - 1).Cells("seleccionar")
                ElseIf Me.dgvGuiasEnvio.CurrentRow.Index = Me.dgvGuiasEnvio.RowCount - 1 Then 'Si el Foco esta en la Ultima Fila.
                    'Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(0).Cells(14)
                    Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(0).Cells("seleccionar")
                ElseIf Me.dgvGuiasEnvio.CurrentRow.Index > 0 And Me.dgvGuiasEnvio.CurrentRow.Index < Me.dgvGuiasEnvio.RowCount - 1 Then 'Si el Foco esta en las Filas Intermedias.
                    'Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(0).Cells(14)
                    Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(0).Cells("seleccionar")
                End If
                Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
            Else
                MessageBox.Show("No hay Registros que seleccionar", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RestablecerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestablecerToolStripMenuItem.Click
        Try
            If Me.dgvGuiasEnvio.RowCount > 0 Then
                For i As Integer = 0 To Me.dgvGuiasEnvio.RowCount - 1
                    'Me.dgvGuiasEnvio.Rows(i).Cells(14).Value = 0
                    Me.dgvGuiasEnvio.Rows(i).Cells("seleccionar").Value = 0
                Next
                Me.dgvGuiasEnvio.EndEdit()
                If Me.dgvGuiasEnvio.CurrentRow.Index = 0 Then 'Si el Foco esta en la Primera Fila.
                    'Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(Me.dgvGuiasEnvio.RowCount - 1).Cells(14)
                    Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(Me.dgvGuiasEnvio.RowCount - 1).Cells("seleccionar")
                ElseIf Me.dgvGuiasEnvio.CurrentRow.Index = Me.dgvGuiasEnvio.RowCount - 1 Then 'Si el Foco esta en la Ultima Fila.
                    'Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(0).Cells(14)
                    Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(0).Cells("seleccionar")
                ElseIf Me.dgvGuiasEnvio.CurrentRow.Index > 0 And Me.dgvGuiasEnvio.CurrentRow.Index < Me.dgvGuiasEnvio.RowCount - 1 Then 'Si el Foco esta en las Filas Intermedias.
                    'Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(0).Cells(14)
                    Me.dgvGuiasEnvio.CurrentCell = Me.dgvGuiasEnvio.Rows(0).Cells("seleccionar")
                End If
                Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
            Else
                MessageBox.Show("No hay Registros que seleccionar", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
        End Try

    End Sub

#Region " API "
    Private Const WM_SYSCOMMAND As Integer = &H112&
    Private Const MOUSE_MOVE As Integer = &HF012&
    Private Const MK_SHIFT As Integer = &H4
    Private Const MK_CONTROL As Integer = &H8
    Private Const MK_MBUTTON As Integer = &H10


    'Declaramos el API de Windows.
    <System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint:="ReleaseCapture")> Private Shared Sub ReleaseCapture()
    End Sub
    <System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint:="SendMessage")> Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    'Funcion Privada para Mover el Formulario.
    Private Sub MoverForm()
        ReleaseCapture()
        SendMessage(Me.hnd, WM_SYSCOMMAND, MOUSE_MOVE, 0)
    End Sub
#End Region

    Public Structure PressedKeyData
        Private vkeydata As Keys

        Public Property KeyData() As Keys
            Get
                Return vkeydata
            End Get
            Set(ByVal value As Keys)
                vkeydata = value
            End Set
        End Property

    End Structure

    Public myPress As New PressedKeyData()

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        myPress.KeyData = keyData
        Return MyBase.ProcessCmdKey(msg, keyData)
        'WM_KEYDOWN
        'TBoxKey.Text = dataGrid1.myPress.KeyData.ToString()
        'Me.TextBox1.Text = IVOFACTURACION.FrmPrefacturacion.myPress.KeyData.ToString
    End Function

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Control Or Keys.A Then
            MessageBox.Show("Combinacion")
        End If

        If e.KeyCode = 16 Then
            MessageBox.Show("Presionaste la tecla Shift")
        End If
        If e.KeyCode = 17 Then
            MessageBox.Show("Presionaste la tecla Control")
        End If
        If e.KeyCode = 27 Then
            MessageBox.Show("Presionaste la tecla Scape")
        End If
        If e.KeyCode = 27 Then
            MessageBox.Show("Presionaste la tecla Scape")
        End If
    End Sub


    Private Sub cmbDestinos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDestinos.SelectedIndexChanged
        Try
            If Me.cmbDestinos.SelectedValue <> 99999 Then
                If Me.chkSoloPendientes.Checked = True Then
                    'Me.dvGuias.RowFilter = "DESTINO = '" & Me.cmbDestinos.Text & "' AND [¿PREFACTURADO?] = 0"   ' Tepsa 
                    Me.dvGuias.RowFilter = "DESTINO = '" & Me.cmbDestinos.Text & "' AND PREFACTURADO = 0"
                ElseIf Me.chkSoloPendientes.Checked = False Then
                    Me.dvGuias.RowFilter = "DESTINO = '" & Me.cmbDestinos.Text & "'"
                End If
            Else
                Me.chkSoloPendientes.Checked = False
                Me.chkSoloPendientes.Checked = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub QuitarTodoFiltroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitarTodoFiltroToolStripMenuItem.Click
        Me.dvGuias.RowFilter = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.chkSoloPendientes.Checked = True Then 'Solo permite ver los No facturados
                If Me.cmbDestinos.SelectedValue <> 99999 Then 'Considera los Filtros de destinos
                    ' Me.dvGuias.RowFilter = " FECHA_GUIA >= '" & Me.Fecha1.GetMyFecha & "' AND FECHA_GUIA <= '" & Me.Fecha2.GetMyFecha & "' AND [¿PREFACTURADO?] = 0 AND DESTINO = '" & Me.cmbDestinos.Text & "'" '><
                    ' Comentado por tepsa 
                    ' Me.dvGuias.RowFilter = "FECHA_GUIA >= '" & Me.Fecha1.GetMyFecha & "' AND FECHA_GUIA <= '" & Me.Fecha2.GetMyFecha & "' AND PREFACTURADO = 0 AND DESTINO = '" & Me.cmbDestinos.Text & "'" '><
                    Me.dvGuias.RowFilter = "PREFACTURADO = 0 AND DESTINO = '" & Me.cmbDestinos.Text & "'" & IIf(cmbCentroCosto.Text <> "", " AND Centro_Costo = '" & cmbCentroCosto.Text & "'", "")
                ElseIf Me.cmbDestinos.SelectedValue = 99999 Then 'No considera Filtros
                    ' Me.dvGuias.RowFilter = "FECHA_GUIA >= '" & Me.Fecha1.GetMyFecha & "' AND FECHA_GUIA <= '" & Me.Fecha2.GetMyFecha & "' AND [¿PREFACTURADO?] = 0 " '><
                    '
                    'Comentado por Tepsa 
                    'Me.dvGuias.RowFilter = "FECHA_GUIA >= '" & Me.Fecha1.GetMyFecha & "' AND FECHA_GUIA <= '" & Me.Fecha2.GetMyFecha & "' AND PREFACTURADO = 0 " '><    ' Tepsa 
                    Me.dvGuias.RowFilter = "PREFACTURADO = 0 " & IIf(cmbCentroCosto.Text <> "", " AND Centro_Costo = '" & cmbCentroCosto.Text & "'", "")
                End If
            ElseIf Me.chkSoloPendientes.Checked = False Then 'Muestra todos
                If Me.cmbDestinos.SelectedValue <> 99999 Then 'Considera los Filtros de destinos
                    'Me.dvGuias.RowFilter = "FECHA_GUIA >= '" & Me.Fecha1.GetMyFecha & "' AND FECHA_GUIA <= '" & Me.Fecha2.GetMyFecha & "' AND PREFACTURADO = 0 " '><   Comentado por Tepsa 
                    Me.dvGuias.RowFilter = "PREFACTURADO = 0 " & IIf(cmbCentroCosto.Text <> "", " AND Centro_Costo = '" & cmbCentroCosto.Text & "'", "")
                    ' Me.dvGuias.RowFilter = "FECHA_GUIA >= '" & Me.Fecha1.GetMyFecha & "' AND FECHA_GUIA <= '" & Me.Fecha2.GetMyFecha & "' AND [¿PREFACTURADO?] = 0 " '>< 'Tepsa 
                ElseIf Me.cmbDestinos.SelectedValue = 99999 Then 'No considera Filtros
                    'Comentado por Tepsa 
                    'Me.dvGuias.RowFilter = "FECHA_GUIA >= '" & Me.Fecha1.GetMyFecha & "' AND FECHA_GUIA <= '" & Me.Fecha2.GetMyFecha & "' AND DESTINO = '" & Me.cmbDestinos.Text & "'" '><
                    Me.dvGuias.RowFilter = "DESTINO = '" & Me.cmbDestinos.Text & "'" & IIf(cmbCentroCosto.Text <> "", " AND Centro_Costo = '" & cmbCentroCosto.Text & "'", "")
                End If
            End If
            Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkSoloPendientes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSoloPendientes.CheckedChanged
        Try
            'Me.dvGuias.RowFilter = "DESTINO = '" & Me.cmbDestinos.Text & "' AND [¿PREFACTURADO?] = 0"
            If Me.cmbDestinos.SelectedValue = 99999 Then
                If sender.Checked = True Then
                    ' Me.dvGuias.RowFilter = "[¿PREFACTURADO?] = 0"   ' Tepsa 
                    Me.dvGuias.RowFilter = "PREFACTURADO = 0"
                Else
                    Me.dvGuias.RowFilter = "" '"[¿PREFACTURADO?] = 1"
                End If
            ElseIf Me.cmbDestinos.SelectedValue <> 99999 Then
                If sender.Checked = True Then
                    ' Me.dvGuias.RowFilter = "DESTINO = '" & Me.cmbDestinos.Text & "' AND [¿PREFACTURADO?] = 0"    Tepsa 
                    Me.dvGuias.RowFilter = "DESTINO = '" & Me.cmbDestinos.Text & "' AND PREFACTURADO  = 0 "
                Else
                    Me.dvGuias.RowFilter = "DESTINO = '" & Me.cmbDestinos.Text & "'"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtCodigoCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Try
            'If Me.txtCodigoCliente.Text.Trim.Length <> 0 Then
            Me.dgvGuiasEnvio.Columns.Clear()

            'hlamas 10-08-2015
            'Me.dgvGuiasFinal.Columns.Clear()

            'Me.txtNroPreFactura.Text = ""
            Me.txtNroPreFacturaFinal.Text = ""
            Me.txtMontoFinalPreFacturar.Text = ""
            Me.txtMontoPreFacturaFinal.Text = ""
            Me.txtRazonSocialCliente.Text = ""
            Me.txtRazonSocialClienteFinal.Text = ""
            Me.txtTipofacturacion.Text = ""
            txtCodigoClienteFinal.Text = ""
            Me.cmbCentroCosto.DataSource = Nothing
            Me.cmbDestinos.DataSource = Nothing
            'End If
            If Me.txtCodigoCliente.Text.Trim.Length <> 0 Then
                Me.MenuStrip1.Items(0).Enabled = True
            Else
                Me.MenuStrip1.Items(0).Enabled = False
            End If

            'hlamas 16-09-2013
            Me.TxtDt.Text = ""
            Me.LblDt.Visible = False
            Me.TxtDt.Visible = False

        Catch ex As Exception
        End Try
    End Sub


    'Private Sub txtCodigoCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
    '    Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
    '    If KeyAscii = 13 Then

    '        If Me.txtCodigoCliente.Text.Trim.Length = 11 Then
    '            If Me.txtCodigoCliente.Text.Length <> 0 Then
    '                Dim rstCliente As ADODB.Recordset
    '                Dim rstGuias As ADODB.Recordset
    '                Dim rstNroPrefactura As ADODB.Recordset
    '                Dim rstSubCuentas As ADODB.Recordset
    '                Dim rstDestinos As ADODB.Recordset

    '                rstCliente = Funciones.ClientePrefactura(1, txtCodigoCliente.Text)
    '                rstGuias = rstCliente.NextRecordset
    '                rstNroPrefactura = rstCliente.NextRecordset
    '                rstSubCuentas = rstCliente.NextRecordset
    '                rstDestinos = rstCliente.NextRecordset

    '                Dim dtCliente As New DataTable
    '                'Dim dtGuias As New DataTable
    '                Dim dtNroPrefactura As New DataTable
    '                Dim dtSubCuentas As New DataTable
    '                Dim dtDestinos As New DataTable
    '                Dim da As New OleDb.OleDbDataAdapter

    '                Me.dgvGuiasEnvio.Columns.Clear()
    '                dtCliente.Clear()
    '                dtGuias.Clear()
    '                dtNroPrefactura.Clear()
    '                dtSubCuentas.Clear()

    '                da.Fill(dtCliente, rstCliente)
    '                da.Fill(dtNroPrefactura, rstNroPrefactura)
    '                da.Fill(dtGuias, rstGuias)
    '                da.Fill(dtSubCuentas, rstSubCuentas)
    '                da.Fill(dtDestinos, rstDestinos)

    '                'dtGuiasFinal = dtGuias.Copy
    '                If dtCliente.Columns(0).ColumnName = "EXISTE" Then
    '                    MessageBox.Show(dtCliente.Rows(0)(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    Me.txtCodigoCliente.Text = ""
    '                    Me.txtRazonSocialCliente.Text = ""
    '                    Me.txtTipofacturacion.Text = ""

    '                    Me.txtNroPreFactura.Text = ""
    '                Else
    '                    Me.txtCodigoCliente.Text = dtCliente.Rows(0)(0).ToString
    '                    Me.txtRazonSocialCliente.Text = dtCliente.Rows(0)(1).ToString
    '                    Me.txtTipofacturacion.Text = dtCliente.Rows(0)(2).ToString

    '                    Me.txtNroPreFactura.Text = dtNroPrefactura.Rows(0)(0).ToString

    '                    cmbCentroCosto.DataSource = dtSubCuentas.DefaultView
    '                    cmbCentroCosto.DisplayMember = "CENTRO_COSTO"
    '                    cmbCentroCosto.ValueMember = "IDCENTRO_COSTO"

    '                    Me.cmbDestinos.DataSource = dtDestinos.DefaultView
    '                    Me.cmbDestinos.DisplayMember = "NOMBRE_UNIDAD"
    '                    Me.cmbDestinos.ValueMember = "IDUNIDAD_AGENCIA_DESTINO"
    '                    Me.cmbDestinos.SelectedValue = 99999

    '                    Me.btnGenerar.Enabled = True

    '                End If
    '                'Me.txtCodigoCliente.Text = dtCliente.Rows(0)(0).ToString
    '                'Me.txtRazonSocialCliente.Text = dtCliente.Rows(0)(1).ToString
    '                'Me.txtTipofacturacion.Text = dtCliente.Rows(0)(2).ToString

    '                'Me.txtNroPreFactura.Text = dtNroPrefactura.Rows(0)(0).ToString


    '            Else
    '                MessageBox.Show("Ingrese el Código de un Cliente de Tipo III", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        ElseIf Me.txtCodigoCliente.Text.Trim.Length < 11 And Me.txtCodigoCliente.Text.Trim.Length <> 0 Then
    '            Dim FrmBusFuncionario As FrmBusquedaClientes = New FrmBusquedaClientes
    '            FrmBusFuncionario.txtNombreFuncionario.Text = Me.txtCodigoCliente.Text
    '            FrmBusFuncionario.CodigoFuncionario = Me.txtCodigoCliente.Text
    '            FrmBusFuncionario.BuscaPor = 1
    '            Dim resultado As DialogResult
    '            resultado = FrmBusFuncionario.ShowDialog()
    '            Dim FuncionarioNegocio As String = FrmBusFuncionario.NombreFuncionario
    '            Me.txtCodigoCliente.Text = FrmBusFuncionario.CodigoFuncionario
    '            Me.txtRazonSocialCliente.Text = FrmBusFuncionario.NombreFuncionario
    '        ElseIf Me.txtCodigoCliente.Text.Trim.Length = 0 Then
    '            MessageBox.Show("Ingrese los 3 Primeros digitos del Codigo.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If

    '    End If

    'End Sub

    Private Sub txtRazonSocialCliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRazonSocialCliente.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtCodigoCliente.Text.Length <> 0 Then
                    'datahelper
                    'Dim rstCliente As ADODB.Recordset
                    'Dim rstGuias As ADODB.Recordset
                    'Dim rstNroPrefactura As ADODB.Recordset
                    'Dim rstSubCuentas As ADODB.Recordset
                    'Dim rstDestinos As ADODB.Recordset

                    'Dim sfec_inicio As String
                    'Dim sfec_final As String
                    'Dim snro_prefactura As String
                    'sfec_inicio = Fecha1.GetMyFecha()
                    'sfec_final = Fecha2.GetMyFecha
                    'If txtNroPreFactura.Text = "" Then
                    '    snro_prefactura = "null"
                    'Else
                    '    snro_prefactura = CType(txtNroPreFactura.Text, String)
                    'End If
                    'rstCliente = Funciones.ClientePrefactura_new(1, txtCodigoCliente.Text, sfec_inicio, sfec_final, snro_prefactura)
                    ''
                    'rstGuias = rstCliente.NextRecordset
                    'rstNroPrefactura = rstCliente.NextRecordset
                    'rstSubCuentas = rstCliente.NextRecordset
                    'rstDestinos = rstCliente.NextRecordset
                    ''
                    'Dim dtCliente As New DataTable
                    'Dim dtNroPrefactura As New DataTable
                    'Dim dtSubCuentas As New DataTable
                    'Dim dtDestinos As New DataTable
                    'Dim da As New OleDb.OleDbDataAdapter
                    ''
                    'Me.dgvGuiasEnvio.Columns.Clear()
                    'dtCliente.Clear()
                    'dtGuias.Clear()
                    'dtNroPrefactura.Clear()
                    'dtSubCuentas.Clear()
                    ''
                    'da.Fill(dtCliente, rstCliente)
                    'da.Fill(dtNroPrefactura, rstNroPrefactura)
                    'da.Fill(dtGuias, rstGuias)
                    'da.Fill(dtSubCuentas, rstSubCuentas)
                    'da.Fill(dtDestinos, rstDestinos)
                    '
                    Dim sfec_inicio As String
                    Dim sfec_final As String
                    Dim snro_prefactura As String
                    sfec_inicio = Fecha1.GetMyFecha()
                    sfec_final = Fecha2.GetMyFecha
                    If txtNroPreFactura.Text = "" Then
                        snro_prefactura = "null"
                    Else
                        snro_prefactura = CType(txtNroPreFactura.Text, String)
                    End If

                    'hlamas 16-09-2013
                    Dim sDT As String = IIf(TxtDt.Visible And TxtDt.Text.Trim.Length = 7, TxtDt.Text, "")
                    Dim intProducto As Integer = Me.cmbProducto.SelectedValue
                    Dim ds As DataSet = Funciones.ClientePrefactura_new(1, txtCodigoCliente.Text, sfec_inicio, sfec_final, snro_prefactura, sDT, intProducto)
                    Dim dtCliente As DataTable = ds.Tables(0)
                    '
                    dtGuias = Nothing
                    dtGuias = New DataTable
                    '
                    dtGuias = ds.Tables(1) '03/12/2009 - 
                    Dim dtNroPrefactura As DataTable = ds.Tables(2)
                    Dim dtSubCuentas As DataTable = ds.Tables(3)
                    Dim dtDestinos As DataTable = ds.Tables(4)

                    If dtCliente.Columns(0).ColumnName = "EXISTE" Then
                        MessageBox.Show(dtCliente.Rows(0)(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtCodigoCliente.Text = ""
                        Me.txtRazonSocialCliente.Text = ""
                        Me.txtTipofacturacion.Text = ""
                    Else
                        Me.txtCodigoCliente.Text = dtCliente.Rows(0)(0).ToString
                        Me.txtRazonSocialCliente.Text = dtCliente.Rows(0)(1).ToString
                        Me.txtTipofacturacion.Text = dtCliente.Rows(0)(2).ToString

                        Me.txtNroPreFactura.Text = dtNroPrefactura.Rows(0)(0).ToString

                        cmbCentroCosto.DataSource = dtSubCuentas.DefaultView
                        cmbCentroCosto.DisplayMember = "CENTRO_COSTO"
                        cmbCentroCosto.ValueMember = "IDCENTRO_COSTO"

                        Me.cmbDestinos.DataSource = dtDestinos.DefaultView
                        Me.cmbDestinos.DisplayMember = "NOMBRE_UNIDAD"
                        Me.cmbDestinos.ValueMember = "IDUNIDAD_AGENCIA_DESTINO"
                        Me.cmbDestinos.SelectedValue = 99999

                        Me.btnGenerar.Enabled = True

                    End If
                Else
                    MessageBox.Show("Ingrese el Código de un Cliente de Tipo III", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf e.KeyCode = Keys.F1 Then
                Dim FrmBusFuncionario As FrmBusquedaClientes = New FrmBusquedaClientes
                FrmBusFuncionario.txtNombreFuncionario.Text = Me.txtCodigoCliente.Text
                FrmBusFuncionario.CodigoFuncionario = Me.txtRazonSocialCliente.Text
                FrmBusFuncionario.BuscaPor = 2
                Dim resultado As DialogResult
                resultado = FrmBusFuncionario.ShowDialog()
                Dim FuncionarioNegocio As String = FrmBusFuncionario.NombreFuncionario
                If FrmBusFuncionario.CodigoFuncionario.Trim = "Ingrese un Valor..." Or FrmBusFuncionario.CodigoFuncionario.Trim = "" Then
                    Me.txtCodigoCliente.Text = ""
                    Me.txtRazonSocialCliente.Text = ""
                Else
                    Me.txtCodigoCliente.Text = FrmBusFuncionario.CodigoFuncionario
                    Me.txtRazonSocialCliente.Text = FrmBusFuncionario.NombreFuncionario
                End If
            End If

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub configurar_dtguias()
        Dim ifila, iseleccionar As Integer
        Dim snroguias As String
        Dim ifila_dtguiasdataclon As Integer
        '
        Try
            '
            dvguiasclon = Nothing
            dtguiasclon = Nothing
            ' 
            dtguiasclon = New DataTable
            dvguiasclon = New DataView
            '
            dtguiasclon = dtGuias
            '
            For ifila = 0 To dgvGuiasEnvio.RowCount - 1
                snroguias = CType(dgvGuiasEnvio.Rows(ifila).Cells(3).Value, String)
                iseleccionar = CType(dgvGuiasEnvio.Rows(ifila).Cells("seleccionar").Value, Integer)
                '    iprefacturado = CType(dgvGuiasEnvio.Rows(ifila).Cells(15).Value, Integer)
                For ifila_dtguiasdataclon = 0 To dtguiasclon.Rows.Count - 1
                    If CType(dtguiasclon.Rows(ifila_dtguiasdataclon)(3), String) = snroguias Then
                        'If iseleccionar = 1 Then
                        dtguiasclon.Rows(ifila_dtguiasdataclon)(16) = iseleccionar
                        'Else
                        '    dtguiasclon.Rows(ifila_dtguiasdataclon)(16) = iseleccionar
                        'End If
                        Exit For
                    Else
                        dtguiasclon.Rows(ifila_dtguiasdataclon)(16) = iseleccionar
                    End If
                Next
            Next
            '
            dvguiasclon = dtguiasclon.DefaultView


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub dgvGuiasEnvio_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvGuiasEnvio.CellMouseClick
        'Return
        'Try
        '    Select Case e.ColumnIndex
        '        Case 17
        '            'If e.Button = Windows.Forms.MouseButtons.Left Then
        '            Dim a As DataRowView = Me.dvGuias.Item(Me.dgvGuiasEnvio.CurrentRow.Index)

        '            If dgvGuiasEnvio.Rows(e.RowIndex).Cells("seleccionar").Value = 0 Then 'Ya esta Seleccionado
        '                dgvGuiasEnvio.Rows(e.RowIndex).Cells("seleccionar").Value = 1
        '                dgvGuiasEnvio.EndEdit()
        '                Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
        '                Me.dgvGuiasEnvio.Refresh()
        '                Exit Sub
        '            End If

        '            If dgvGuiasEnvio.Rows(e.RowIndex).Cells("seleccionar").Value = 1 Then 'Ya esta Seleccionado
        '                dgvGuiasEnvio.Rows(e.RowIndex).Cells("seleccionar").Value = 0
        '                dgvGuiasEnvio.EndEdit()
        '                Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
        '                Me.dgvGuiasEnvio.Refresh()
        '                Exit Sub
        '            End If
        '            'dgvGuiasEnvio_CurrentCellDirtyStateChanged(Nothing, Nothing)
        '    End Select
        'Catch ex As Exception
        '    'MsgBox("aa")
        'End Try
        ''Try
        ''    Select Case e.ColumnIndex
        ''        Case 16
        ''            'If e.Button = Windows.Forms.MouseButtons.Left Then
        ''            Dim a As DataRowView = Me.dvGuias.Item(Me.dgvGuiasEnvio.CurrentRow.Index)

        ''            If dgvGuiasEnvio.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0 Then 'Ya esta Seleccionado
        ''                dgvGuiasEnvio.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 1
        ''                dgvGuiasEnvio.EndEdit()
        ''                Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
        ''                Me.dgvGuiasEnvio.Refresh()
        ''                Exit Sub
        ''            End If

        ''            If dgvGuiasEnvio.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 1 Then 'Ya esta Seleccionado
        ''                dgvGuiasEnvio.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
        ''                dgvGuiasEnvio.EndEdit()
        ''                Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
        ''                Me.dgvGuiasEnvio.Refresh()
        ''                Exit Sub
        ''            End If
        ''    End Select
        ''Catch ex As Exception

        ''End Try
    End Sub
    Private Sub cmbCentroCosto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCentroCosto.SelectedIndexChanged

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub
    Private Sub Fecha1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fecha1.Enter
        Try
            Me.dgvGuiasEnvio.Columns.Clear()

            'hlamas 10-08-2015
            'Me.dgvGuiasFinal.Columns.Clear()

            'Me.txtNroPreFactura.Text = ""
            Me.txtNroPreFacturaFinal.Text = ""
            Me.txtMontoFinalPreFacturar.Text = ""
            Me.txtMontoPreFacturaFinal.Text = ""
            Me.cmbCentroCosto.DataSource = Nothing
            Me.cmbDestinos.DataSource = Nothing
            Me.MenuStrip1.Items(0).Enabled = True
            'hlamas 16-09-2013
            'Me.TxtDt.Text = ""
            'Me.LblDt.Visible = False
            'Me.TxtDt.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fecha2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fecha2.Enter
        Try
            'hlamas 10-08-2015
            'Me.dgvGuiasFinal.Columns.Clear()

            'Me.txtNroPreFactura.Text = ""
            Me.txtNroPreFacturaFinal.Text = ""
            Me.txtMontoFinalPreFacturar.Text = ""
            Me.txtMontoPreFacturaFinal.Text = ""
            Me.cmbCentroCosto.DataSource = Nothing
            Me.cmbDestinos.DataSource = Nothing
            Me.MenuStrip1.Items(0).Enabled = True
            'hlamas 16-09-2013
            'Me.TxtDt.Text = ""
            'Me.LblDt.Visible = False
            'Me.TxtDt.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fecha1_GiveFeedback(sender As Object, e As System.Windows.Forms.GiveFeedbackEventArgs) Handles Fecha1.GiveFeedback

    End Sub
    Private Sub Fecha1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fecha1.Leave
        Try
            If txtRazonSocialCliente.Text = "" Then
                Exit Sub
            End If
            '
            If Fecha1.GetMyFecha = "  /  /" Then
                Exit Sub
            End If
            If Fecha2.GetMyFecha = "  /  /" Then
                Exit Sub
            End If

            '-------------------------------------------------
            'Dim sfec_inicio As String
            'Dim sfec_final As String
            'Dim snro_prefactura As String
            'sfec_inicio = Fecha1.GetMyFecha()
            'sfec_final = Fecha2.GetMyFecha
            'If txtNroPreFactura.Text = "" Then
            '    snro_prefactura = "null"
            'Else
            '    snro_prefactura = CType(txtNroPreFactura.Text, String)
            'End If

            'Dim ds As DataSet = Funciones.ClientePrefactura_new(1, txtCodigoCliente.Text, sfec_inicio, sfec_final, snro_prefactura)
            'Dim dtCliente As DataTable = ds.Tables(0)
            ''Dim dtGuias As DataTable = ds.Tables(1)
            'dtGuias = ds.Tables(1)
            'Dim dtNroPrefactura As DataTable = ds.Tables(2)
            'Dim dtSubCuentas As DataTable = ds.Tables(3)
            'Dim dtDestinos As DataTable = ds.Tables(4)
            'If dtCliente.Columns(0).ColumnName = "EXISTE" Then
            '    MessageBox.Show(dtCliente.Rows(0)(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.txtCodigoCliente.Text = ""
            '    Me.txtRazonSocialCliente.Text = ""
            '    Me.txtTipofacturacion.Text = ""
            '    Me.txtNroPreFactura.Text = ""
            'Else
            '    Me.txtCodigoCliente.Text = dtCliente.Rows(0)(0).ToString
            '    Me.txtRazonSocialCliente.Text = dtCliente.Rows(0)(1).ToString
            '    Me.txtTipofacturacion.Text = dtCliente.Rows(0)(2).ToString
            '    Me.txtNroPreFactura.Text = dtNroPrefactura.Rows(0)(0).ToString
            '    '
            '    cmbCentroCosto.DataSource = dtSubCuentas.DefaultView
            '    cmbCentroCosto.DisplayMember = "CENTRO_COSTO"
            '    cmbCentroCosto.ValueMember = "IDCENTRO_COSTO"
            '    '
            '    Me.cmbDestinos.DataSource = dtDestinos.DefaultView
            '    Me.cmbDestinos.DisplayMember = "NOMBRE_UNIDAD"
            '    Me.cmbDestinos.ValueMember = "IDUNIDAD_AGENCIA_DESTINO"
            '    Me.cmbDestinos.SelectedValue = 99999
            '    '
            '    Me.btnGenerar.Enabled = True
            '    '
            '    Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub Fecha2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fecha2.Leave
        Try
            If Fecha1.GetMyFecha = "  /  /" Then
                Exit Sub
            End If
            If Fecha2.GetMyFecha = "  /  /" Then
                Exit Sub
            End If
            If txtRazonSocialCliente.Text = "" Then
                Exit Sub
            End If

            '----------------------------------------------------------------
            'Dim sfec_inicio As String
            'Dim sfec_final As String
            'Dim snro_prefactura As String
            'sfec_inicio = Fecha1.GetMyFecha()
            'sfec_final = Fecha2.GetMyFecha
            'If txtNroPreFactura.Text = "" Then
            '    snro_prefactura = "null"
            'Else
            '    snro_prefactura = CType(txtNroPreFactura.Text, String)
            'End If

            'Dim ds As DataSet = Funciones.ClientePrefactura_new(1, txtCodigoCliente.Text, sfec_inicio, sfec_final, snro_prefactura)
            'Dim dtCliente As DataTable = ds.Tables(0)
            'Dim dtGuias As DataTable = ds.Tables(1)
            'Dim dtNroPrefactura As DataTable = ds.Tables(2)
            'Dim dtSubCuentas As DataTable = ds.Tables(3)
            'Dim dtDestinos As DataTable = ds.Tables(4)

            'If dtCliente.Columns(0).ColumnName = "EXISTE" Then
            '    MessageBox.Show(dtCliente.Rows(0)(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.txtCodigoCliente.Text = ""
            '    Me.txtRazonSocialCliente.Text = ""
            '    Me.txtTipofacturacion.Text = ""

            '    Me.txtNroPreFactura.Text = ""
            'Else
            '    Me.txtCodigoCliente.Text = dtCliente.Rows(0)(0).ToString
            '    Me.txtRazonSocialCliente.Text = dtCliente.Rows(0)(1).ToString
            '    Me.txtTipofacturacion.Text = dtCliente.Rows(0)(2).ToString
            '    Me.txtNroPreFactura.Text = dtNroPrefactura.Rows(0)(0).ToString
            '    '
            '    cmbCentroCosto.DataSource = dtSubCuentas.DefaultView
            '    cmbCentroCosto.DisplayMember = "CENTRO_COSTO"
            '    cmbCentroCosto.ValueMember = "IDCENTRO_COSTO"
            '    '
            '    Me.cmbDestinos.DataSource = dtDestinos.DefaultView
            '    Me.cmbDestinos.DisplayMember = "NOMBRE_UNIDAD"
            '    Me.cmbDestinos.ValueMember = "IDUNIDAD_AGENCIA_DESTINO"
            '    Me.cmbDestinos.SelectedValue = 99999
            '    '
            '    Me.btnGenerar.Enabled = True
            '    '
            '    Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub TxtDt_GotFocus(sender As Object, e As System.EventArgs) Handles TxtDt.GotFocus
        Me.TxtDt.SelectAll()
    End Sub

    Private Sub TxtDt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDt.KeyPress
        If Not ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbProducto.SelectedIndexChanged
        Me.dgvGuiasEnvio.DataSource = Nothing
    End Sub

    Private Sub TxtDt_LostFocus(sender As Object, e As System.EventArgs) Handles TxtDt.LostFocus
        If Me.TxtDt.Text.Trim.Length = 7 Then
            Me.cmbProducto.SelectedValue = 5
        End If
    End Sub

    Private Sub TxtDt_Validated(sender As Object, e As System.EventArgs) Handles TxtDt.Validated

    End Sub

    Private Sub dgvGuiasEnvio_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGuiasEnvio.CellContentClick
        If e.ColumnIndex <> 17 Then Return
        'If dgvGuiasEnvio.Rows(e.RowIndex).Cells("prefacturado").Value = 1 Then Return
        Me.txtSumatoriaMonto.Text = SumaPreciosGuias()
    End Sub

    Private Sub dgvGuiasEnvio_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvGuiasEnvio.CurrentCellDirtyStateChanged
        dgvGuiasEnvio.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub NoPrefacturarGuíaDeEnvíoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NoPrefacturarGuíaDeEnvíoToolStripMenuItem.Click
        If Me.dgvGuiasEnvio.Rows.Count > 0 Then
            If Me.dgvGuiasEnvio.CurrentRow.Cells("prefacturado").Value = 0 Then
                If MessageBox.Show("¿Está seguro de retirar la Guía de Envío Nº " & Me.dgvGuiasEnvio.CurrentRow.Cells("NRO_GUIA").Value & "?", "Prefacturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Dim intGuia As Integer
                    intGuia = Me.dgvGuiasEnvio.CurrentRow.Cells("guia").Value
                    NoPrefacturarGuiaEnvio(intGuia, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                    btnGenerar_Click(Nothing, Nothing)
                End If
            Else
                MessageBox.Show("La Guía de Envío Nº " & Me.dgvGuiasEnvio.CurrentRow.Cells("NRO_GUIA").Value & " ya está prefacturada", "Prefacturacion", MessageBoxButtons.OK)
            End If
        End If
    End Sub

    Sub NoPrefacturarGuiaEnvio(guia As Integer, usuario As Integer, ip As String)
        Try
            Dim obj As New dtoPREFACTURA
            obj.NoPrefacturarGuiaEnvio(guia, usuario, ip)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Prefacturacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigurarDGVGuiasFinal()
        With dgvGuiasFinal
            Cls_Utilitarios.FormatDataGridView(dgvGuiasFinal)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .AutoGenerateColumns = False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = False
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "ORIGEN" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "DESTINO"
            End With
            x += +1
            Dim col_nro_guia As New DataGridViewTextBoxColumn
            With col_nro_guia
                .Name = "nro_guia" : .DataPropertyName = "nro_guia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº GUIA" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_consignado As New DataGridViewTextBoxColumn
            With col_consignado
                .Name = "consignado" : .DataPropertyName = "consignado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "CONSIGNADO" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "CANTIDAD" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_total_peso As New DataGridViewTextBoxColumn
            With col_total_peso
                .Name = "total_peso" : .DataPropertyName = "total_peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "TOTAL PESO" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_monto_base As New DataGridViewTextBoxColumn
            With col_monto_base
                .Name = "monto_base" : .DataPropertyName = "monto_base"
                .DisplayIndex = x : .Visible = True : .HeaderText = "MONTO BASE" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_forma_pago As New DataGridViewTextBoxColumn
            With col_forma_pago
                .Name = "forma_pago" : .DataPropertyName = "forma_pago"
                .DisplayIndex = x : .Visible = True : .HeaderText = "FORMA PAGO" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_importe_bruto As New DataGridViewTextBoxColumn
            With col_importe_bruto
                .Name = "importe_bruto" : .DataPropertyName = "importe_bruto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "IMPORTE BRUTO" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_importe_igv As New DataGridViewTextBoxColumn
            With col_importe_igv
                .Name = "importe_igv" : .DataPropertyName = "importe_igv"
                .DisplayIndex = x : .Visible = True : .HeaderText = "IMPORTE IGV" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "0.00"
            End With
            x += +1
            Dim col_centro_costo As New DataGridViewTextBoxColumn
            With col_centro_costo
                .Name = "centro_costo" : .DataPropertyName = "centro_costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "CENTRO COSTO" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_guia As New DataGridViewTextBoxColumn
            With col_guia
                .Name = "guia" : .DataPropertyName = "guia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "GUIA" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            .Columns.AddRange(col_origen, col_destino, col_nro_guia, col_consignado, col_cantidad, col_total_peso, col_monto_base, col_forma_pago, _
                              col_importe_bruto, col_importe_igv, col_centro_costo, col_guia)
        End With
    End Sub
End Class
