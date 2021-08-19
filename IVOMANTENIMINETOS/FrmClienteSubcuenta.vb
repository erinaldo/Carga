Imports INTEGRACION_EN
Imports INTEGRACION_LN
Public Class FrmClienteSubcuenta
    Public hnd As Long
    Dim buscarCliente As Cls_BuscarClienteLN
    Dim ContactoCentroCosto As Cls_ContactoCentroCosto
    Dim action As Integer
    Dim strSubcuenta As String
    Dim blnInicio As Boolean
    Dim tabpage As TabPage
    Dim ID_PERSONA_ECKERD As Integer = 1266
    Dim bIngreso As Boolean
#Region "FORMATOS DATAGRIDVIEW"
    Private Sub dgConfigDGVSubCuenta()
        Dim c As Integer = 0
        With dgvSubcuentas
            Dim Col_idPersona As New DataGridViewTextBoxColumn
            With Col_idPersona
                .Name = "idpersona" : .DataPropertyName = "idpersona"
                .DisplayIndex = c : .Visible = False
            End With
            c += +1
            Dim Col_idunidad_agencia As New DataGridViewTextBoxColumn
            With Col_idunidad_agencia
                .Name = "idunidad_agencia" : .DataPropertyName = "idunidad_agencia" : .DisplayIndex = c : .Visible = False
            End With
            c += +1
            Dim Col_idcentro_costo As New DataGridViewTextBoxColumn
            With Col_idcentro_costo
                .Name = "idcentro_costo" : .DataPropertyName = "idcentro_costo" : .DisplayIndex = c : .Visible = False
            End With
            c += +1
            Dim Col_RazonSocial As New DataGridViewTextBoxColumn
            With Col_RazonSocial
                .HeaderText = "Cliente"
                .DisplayIndex = c : .Width = 280
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
            End With
            c += +1
            Dim Col_SubCuenta As New DataGridViewTextBoxColumn
            With Col_SubCuenta
                .HeaderText = "Subcuenta"
                .DisplayIndex = c : .Width = 180
                .Name = "SubCuenta" : .DataPropertyName = "SubCuenta"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
            End With
            c += +1
            Dim Col_CiudadCobertura As New DataGridViewTextBoxColumn
            With Col_CiudadCobertura
                .HeaderText = "Ciudad"
                .DisplayIndex = c : .Width = 120
                .Name = "Ciudad" : .DataPropertyName = "CiudadCobertura"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
            End With
            c += +1
            Dim Col_CodigoSAP As New DataGridViewTextBoxColumn
            With Col_CodigoSAP
                .HeaderText = "Código SAP"
                .DisplayIndex = c : .Width = 100
                .Name = "codigoSap" : .DataPropertyName = "codigoSap"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
            End With
            .Columns.AddRange(Col_idPersona, Col_idunidad_agencia, Col_idcentro_costo, Col_RazonSocial, Col_SubCuenta, Col_CiudadCobertura, Col_CodigoSAP)
            .RowCount = 0
        End With
    End Sub

    Private Sub dgConfigDGVVenta()
        Dim c As Integer = 0
        With dgvVenta
            .ReadOnly = False
            .VirtualMode = False
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            c += +1
            Dim colSeleccion As New DataGridViewCheckBoxColumn
            With colSeleccion
                .HeaderText = "Sel"
                .Name = "sel"
                '.DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 50
                '.ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                '.Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DisplayIndex = c
            End With
            c += +1
            Dim Col_idguias_envio As New DataGridViewTextBoxColumn
            With Col_idguias_envio
                .Name = "id" : .DataPropertyName = "idguias_envio" : .DisplayIndex = c
                .DisplayIndex = c : .Visible = False
            End With
            c += +1
            Dim Col_fecha_guia As New DataGridViewTextBoxColumn
            With Col_fecha_guia
                .HeaderText = "Fecha"
                .Name = "fecha_guia" : .DataPropertyName = "fecha_guia" : .DisplayIndex = c
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            c += +1
            Dim Col_guia As New DataGridViewTextBoxColumn
            With Col_guia
                .HeaderText = "Nº Guía"
                .Name = "guia" : .DataPropertyName = "guia" : .DisplayIndex = c
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            c += +1
            Dim Col_origen As New DataGridViewTextBoxColumn
            With Col_origen
                .HeaderText = "Origen"
                .Name = "origen" : .DataPropertyName = "origen" : .DisplayIndex = c
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            c += +1
            Dim Col_destino As New DataGridViewTextBoxColumn
            With Col_destino
                .HeaderText = "Destino"
                .Name = "destino" : .DataPropertyName = "destino" : .DisplayIndex = c
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            c += +1
            Dim Col_origen2 As New DataGridViewTextBoxColumn
            With Col_origen2
                .HeaderText = "Subcuenta Origen"
                .Name = "origen2" : .DataPropertyName = "origen2" : .DisplayIndex = c
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Width = 167
            End With
            c += +1
            Dim Col_destino2 As New DataGridViewTextBoxColumn
            With Col_destino2
                .HeaderText = "Subcuenta Destino"
                .Name = "destino2" : .DataPropertyName = "destino2" : .DisplayIndex = c
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Width = 167
            End With
            c += +1
            Dim Col_subtotal As New DataGridViewTextBoxColumn
            With Col_subtotal
                .HeaderText = "Subtotal"
                .DisplayIndex = c ': .Width = 180
                .Name = "Subtotal" : .DataPropertyName = "Subtotal"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            c += +1
            Dim Col_impuesto As New DataGridViewTextBoxColumn
            With Col_impuesto
                .HeaderText = "Impuesto"
                .DisplayIndex = c ': .Width = 180
                .Name = "impuesto" : .DataPropertyName = "impuesto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            c += +1
            Dim Col_total As New DataGridViewTextBoxColumn
            With Col_total
                .HeaderText = "Total"
                .DisplayIndex = c ': .Width = 180
                .Name = "total" : .DataPropertyName = "total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            c += +1
            Dim Col_tipo As New DataGridViewTextBoxColumn
            With Col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo" : .DisplayIndex = c : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DisplayIndex = c : .Visible = False
            End With
            .Columns.AddRange(colSeleccion, Col_idguias_envio, Col_fecha_guia, Col_guia, Col_origen, Col_destino, Col_origen2, Col_destino2, Col_subtotal, Col_impuesto, Col_total, Col_tipo)
            .RowCount = 0
        End With
    End Sub
#End Region
#Region "METODOS Y/ FUNCIONES"
    ''' <summary>
    ''' CARGA REGISTROS EN UN OBJETO DATAGRIDVIEW
    ''' </summary>
    ''' <param name="dt">DataTable con los registros a cargar</param>
    ''' <param name="dgv">Nombre del dataGridView en donde se cargaran los registros</param>
    Sub cargarDataGrid(ByVal dt As DataTable, ByVal dgv As DataGridView)
        dgv.Columns.Clear()
        dgv.DataSource = Nothing
        ServiceLocator.getutilitarios.FormatDataGridView(dgv)
        dgv.ReadOnly = True

        Select Case dgv.Name
            Case dgvSubcuentas.Name
                dgConfigDGVSubCuenta()
            Case dgvVenta.Name
                dgConfigDGVVenta()
        End Select
        '-->Habilita controles en función a los registros recuperados.
        EditarToolStripMenuItem.Enabled = dt.Rows.Count > 0
        AnularToolStripMenuItem.Enabled = dt.Rows.Count > 0

        dgv.DataSource = dt
    End Sub
    ''' <summary>
    ''' LIMPIA CONTROLES DEL MANTENIMIENTO DE SUB-CUENTAS
    ''' </summary>
    Sub clearControlsMantenimiento()
        txtCodigo.Clear()
        txtSubCuenta.Clear()
        txtCodigoSap.Clear()
        cmbCliente.SelectedIndex = 0
        cmbCiudadCobertura.SelectedIndex = 0
    End Sub
    ''' <summary>
    ''' LIMPIA CONTROLES DE LA LISTA DE SUB-CUENTAS
    ''' </summary>
    Sub cleanControlsListSubCuentas()
        cmbCliente_Busq.SelectedIndex = 0
        cmbCiudadCobertura_Busq.SelectedIndex = 0
    End Sub
    ''' <summary>
    ''' HABILITA O DESHABILITA LOS CONTROLES DEL MANTENIMIENTO DE LA SUBCUENTA
    ''' </summary>
    ''' <param name="enabled">estado del control (true, false)</param>
    Sub enabledControlsMantenimiento(ByVal enabled As Boolean)
        txtSubCuenta.Enabled = enabled
        txtCodigoSap.Enabled = enabled
        cmbCliente.Enabled = enabled
        cmbCiudadCobertura.Enabled = enabled
    End Sub

    Private Sub txtSubCuenta_Enter(sender As Object, e As System.EventArgs) Handles txtSubCuenta.Enter
        Me.txtSubCuenta.SelectAll()
    End Sub

    Private Sub txtCodigoSap_Enter(sender As Object, e As System.EventArgs) Handles txtCodigoSap.Enter
        Me.txtCodigoSap.SelectAll()
    End Sub
    ''' <summary>
    ''' PARA CAMBIAR EL FUCO EN FUNCIÓN A LA PULSACION LA TECLA ENTER POR EL USUARIO EN EL MANTENIMIENTO
    ''' </summary>
    Sub KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubCuenta.KeyPress, cmbCiudadCobertura.KeyPress, _
        txtCodigoSap.KeyPress, cmbCliente.KeyPress, cmbCliente_Busq.KeyPress, cmbCiudadCobertura_Busq.KeyPress

        If (e.KeyChar = Chr(13)) Then
            '-->Pestaña Mantenimineto
            If Me.cmbCliente.Focused Then
                Me.txtSubCuenta.Focus()
            ElseIf (txtSubCuenta.Focused) Then
                Me.cmbCiudadCobertura.Focus()
                If action = ServiceLocator.getContantes.ACTION_NEW Then
                    Me.cmbCiudadCobertura.DroppedDown = True
                End If
                ElseIf (cmbCiudadCobertura.Focused) Then
                    If Me.txtCodigoSap.Visible Then
                        txtCodigoSap.Focus()
                        txtCodigoSap.SelectAll()
                    Else
                        btnGuardar.Focus()
                    End If
                ElseIf (txtCodigoSap.Focused) Then
                    btnGuardar.Focus()

                    '--->Pestaña busqueda
                ElseIf (cmbCiudadCobertura_Busq.Focused) Then
                    btnBuscar_Click(Nothing, Nothing)
                End If
            Else
                e.KeyChar = UCase(e.KeyChar)
            End If
    End Sub
    Sub KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCliente_Busq.KeyDown, cmbCliente.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            '-->Pestaña Manetenimiento
            If (cmbCliente.Focused) Then
                Me.txtSubCuenta.Focus()

                '-->Pestaña Busqueda
            ElseIf (cmbCliente_Busq.Focused) Then
                btnBuscar_Click(Nothing, Nothing)
                cmbCiudadCobertura_Busq.Focus()
            End If

        End If
    End Sub
#End Region
    Private Sub FrmClienteSubcuenta_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        cmbCliente_Busq.Focus()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            clearControlsMantenimiento()
            enabledControlsMantenimiento(False)
            btnGuardar.Enabled = False

            tabSubcuenta.SelectedTab = tpSubCuentasAsociadas
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmClienteSubcuenta_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmClienteSubcuenta_ImeModeChanged(sender As Object, e As System.EventArgs) Handles Me.ImeModeChanged

    End Sub
    Private Sub FrmClienteSubcuenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            blnInicio = True
            strSubcuenta = ""
            dgConfigDGVSubCuenta()
            '-->Carga combos
            '---->Filtro
            ServiceLocator.getUtilData.cargarCombos("t_persona_nocorporativo", cmbCliente_Busq, True)
            ServiceLocator.getUtilData.cargarCombos("t_unidadAgencia", cmbCiudadCobertura_Busq, True)
            '---->Mantenimiento
            ServiceLocator.getUtilData.cargarCombos(, cmbCliente, False, cmbCliente_Busq.DataSource)
            ServiceLocator.getUtilData.cargarCombos(, cmbCiudadCobertura, False, cmbCiudadCobertura_Busq.DataSource)
            '----->Actualizar
            ServiceLocator.getUtilData.cargarCombos("t_unidadAgencia", cmbCiudad, True, cmbCiudad.DataSource)
            Me.cmbCiudad_SelectedIndexChanged(Nothing, Nothing)

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        Try
            blnInicio = True
            action = ServiceLocator.getContantes.ACTION_NEW
            enabledControlsMantenimiento(True)
            btnGuardar.Enabled = True

            RemoveHandler tabSubcuenta.SelectedIndexChanged, AddressOf tabSubcuenta_SelectedIndexChanged
            tabSubcuenta.SelectedTab = tpMantenimiento
            AddHandler tabSubcuenta.SelectedIndexChanged, AddressOf tabSubcuenta_SelectedIndexChanged
            Me.cmbCliente.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If (cmbCliente.SelectedValue <= 0) Then
                MessageBox.Show("Seleccione el Cliente", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbCliente.Focus()
                Exit Sub
            ElseIf (txtSubCuenta.Text.Trim.Length = 0) Then
                MessageBox.Show("Ingrese el Nombre de la Subcuenta", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtSubCuenta.Text = ""
                txtSubCuenta.Focus()
                Exit Sub
                'ElseIf (cmbCiudadCobertura.SelectedValue <= 0) Then
                '   MessageBox.Show("Seleccione la Ciudad", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'cmbCiudadCobertura.Focus()
                'Exit Sub
            ElseIf (cmbCliente.SelectedValue = ServiceLocator.getContantes.ID_PERSONA_ECKERD) Then
                If (txtCodigoSap.Text.Trim.Length = 0) Then
                    MessageBox.Show("Ingrese el Código SAP", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtCodigoSap.Text = ""
                    txtCodigoSap.Focus()
                    Exit Sub
                ElseIf (txtCodigoSap.Text.Trim.Length < 10) Then
                    MessageBox.Show("El Código SAP debe tener 10 dígitos", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCodigoSap.Focus()
                    Exit Sub
                End If
            End If

            '-->Solicita confirmacion de usuario
            Dim Mensaje As String = ""
            If (action = Cls_Constantes_LN.ACTION_NEW) Then
                Mensaje = "Se Creará la Subcuenta " & txtSubCuenta.Text.Trim & Chr(13) & "¿Desea continuar?"
            Else
                Mensaje = "Se Actualizará la Subcuenta " & txtSubCuenta.Text.Trim & Chr(13) & "¿Desea continuar?"
            End If

            If (MessageBox.Show(Mensaje, "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                Cursor = Cursors.WaitCursor

                ContactoCentroCosto = New Cls_ContactoCentroCosto
                Dim centroCosto As New Cls_CentroCosto
                Dim persona As New Cls_Persona
                Dim unidadAgenica As New Cls_UnidadAgencia

                If (action = Cls_Constantes_LN.ACTION_MODIFY) Then
                    centroCosto.idCentroCosto = txtCodigo.Text.Trim
                End If

                persona.idPersona = cmbCliente.SelectedValue
                centroCosto.centroCosto = txtSubCuenta.Text.Trim
                unidadAgenica.idUnidadAgencia = cmbCiudadCobertura.SelectedValue

                ContactoCentroCosto.centroCosto = centroCosto
                ContactoCentroCosto.persona = persona
                ContactoCentroCosto.unidadAgenica = unidadAgenica
                ContactoCentroCosto.codigoSap = txtCodigoSap.Text.Trim
                ContactoCentroCosto.idUsuarioRegistro = dtoUSUARIOS.IdLogin
                ContactoCentroCosto.ipRegistro = dtoUSUARIOS.IP
                ContactoCentroCosto.idRolRegistro = dtoUSUARIOS.IdRol

                Dim dt As New DataTable
                dt = ServiceLocator.getSubCuenta.guardar(ContactoCentroCosto)

                '-->Es mayor a cero cuando el centro de costo que se esta ingresando para el cliente seleccionado ya existe en la base de datos
                'If (action = Cls_Constantes_LN.ACTION_NEW) Then
                If (dt.Rows(0)(0) = 1) Then 'And (action = Cls_Constantes_LN.ACTION_NEW Or (action = Cls_Constantes_LN.ACTION_MODIFY And strSubcuenta.ToString.Trim > Me.txtSubCuenta.Text.Trim)) Then
                    MessageBox.Show("El Nombre de la Subcuenta ya Existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtSubCuenta.Focus()
                    Cursor = Cursors.Default
                    Exit Sub
                End If
                'Else
                '    If (dt.Rows.Count > 0 And dt.Rows(0)("idcentro_costo") <> centroCosto.idCentroCosto) Then
                '        MessageBox.Show("El Nombre de la subCuenta que ha ingresado ya esta registrada", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '        txtSubCuenta.Focus()
                '        Cursor = Cursors.Default
                '        Exit Sub
                '    End If
                'End If

                '-->
                cmbCliente_Busq.SelectedValue = cmbCliente.SelectedValue
                cmbCiudadCobertura_Busq.SelectedValue = cmbCiudadCobertura.SelectedValue
                btnBuscar_Click(Nothing, Nothing)
                MessageBox.Show("Se Grabó Correctamente", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCancelar_Click(Nothing, Nothing)
                '-->
                Cursor = Cursors.Default

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            Cursor = Cursors.WaitCursor

            cargarDataGrid(ServiceLocator.getSubCuenta.buscarSubCuenta(cmbCliente_Busq.SelectedValue, cmbCiudadCobertura_Busq.SelectedValue), dgvSubcuentas)

            If cmbCliente_Busq.SelectedValue = ServiceLocator.getContantes.ID_PERSONA_ECKERD Then
                Me.dgvSubcuentas.Columns("codigoSap").Visible = True
            Else
                Me.dgvSubcuentas.Columns("codigoSap").Visible = False

            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub EditarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor

            action = Cls_Constantes_LN.ACTION_MODIFY

            Dim rowSubCuenta As DataRow
            rowSubCuenta = DirectCast(dgvSubcuentas.DataSource, DataTable).Rows(dgvSubcuentas.CurrentRow.Index)

            txtCodigo.Text = rowSubCuenta("idcentro_costo")
            txtSubCuenta.Text = rowSubCuenta("SubCuenta")
            cmbCliente.SelectedValue = rowSubCuenta("idPersona")
            cmbCiudadCobertura.SelectedValue = rowSubCuenta("idunidad_agencia")
            If cmbCiudadCobertura.SelectedIndex = -1 Then cmbCiudadCobertura.SelectedIndex = 0
            txtCodigoSap.Text = IIf(IsDBNull(rowSubCuenta("codigoSap")), "", rowSubCuenta("codigoSap"))
            Me.strSubcuenta = Me.txtSubCuenta.Text.Trim

            enabledControlsMantenimiento(True)

            Me.cmbCliente.Enabled = False
            txtCodigoSap.Enabled = True

            tabSubcuenta.SelectedTab = tpMantenimiento
            Me.btnGuardar.Enabled = True

            Me.txtSubCuenta.Focus()
            Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub AnularToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor

            Dim rowSubCuenta As DataRow
            rowSubCuenta = DirectCast(dgvSubcuentas.DataSource, DataTable).Rows(dgvSubcuentas.CurrentRow.Index)

            If (MessageBox.Show("Se Anulará la Subcuenta " & rowSubCuenta("SubCuenta") & " " & Chr(13) & "¿Desea continuar?", "Anulación de la Subcuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                ServiceLocator.getSubCuenta.anular(rowSubCuenta("idcentro_costo"), dtoUSUARIOS.IdLogin, dtoUSUARIOS.IdRol, dtoUSUARIOS.IP)

                btnBuscar_Click(Nothing, Nothing)
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dgvSubcuentas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSubcuentas.DoubleClick
        If dgvSubcuentas.RowCount > 0 Then
            EditarToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub txtCodigoSap_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoSap.TextChanged
        'Try
        '    '-->Valida si se ha realizado algun cambio en el codigo sap para habilitar el boton guardar
        '    If (action = Cls_Constantes_LN.ACTION_MODIFY And Not String.IsNullOrEmpty(txtCodigo.Text.Trim)) Then
        '        Dim rowSubCuenta() As DataRow
        '        rowSubCuenta = DirectCast(dgvSubcuentas.DataSource, DataTable).Select("idcentro_costo=" & txtCodigo.Text)

        '        btnGuardar.Enabled = IIf(IsDBNull(rowSubCuenta(0).Item("codigoSap")), "", rowSubCuenta(0).Item("codigoSap")) <> txtCodigoSap.Text.Trim Or
        '                                rowSubCuenta(0).Item("idunidad_agencia") <> cmbCiudadCobertura.SelectedValue Or
        '                                rowSubCuenta(0).Item("idPersona") <> cmbCliente.SelectedValue Or
        '                                rowSubCuenta(0).Item("subCuenta") <> txtSubCuenta.Text.Trim
        '    End If

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub dgvSubcuentas_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSubcuentas.CellContentClick

    End Sub

    Private Sub FrmClienteSubcuenta_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If (cmbCliente.SelectedValue = ServiceLocator.getContantes.ID_PERSONA_ECKERD) Then
            Me.lblCodigoSap.Visible = True
            Me.txtCodigoSap.Visible = True
            Me.txtCodigoSap.Text = ""
        Else
            Me.lblCodigoSap.Visible = False
            Me.txtCodigoSap.Visible = False
        End If
        tabpage = Me.tabSubcuenta.TabPages(2)
        Me.tabSubcuenta.TabPages.RemoveAt(2)
        cmbCliente_Busq.Focus()
    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCliente.SelectedIndexChanged
        If cmbCliente.SelectedValue = ServiceLocator.getContantes.ID_PERSONA_ECKERD Then
            Me.lblCodigoSap.Visible = True
            Me.txtCodigoSap.Text = ""
            Me.txtCodigoSap.Visible = True
            If Me.tabSubcuenta.TabPages.Count = 2 Then
                Me.tabSubcuenta.TabPages.Add(tabpage)
            End If
        Else
            Me.lblCodigoSap.Visible = False
            Me.txtCodigoSap.Visible = False
            If Me.tabSubcuenta.TabPages.Count = 3 Then
                Me.tabSubcuenta.TabPages.RemoveAt(2)
            End If
        End If
    End Sub

    Private Sub cmbCliente_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cmbCliente.SelectedValueChanged
        'If cmbCliente.SelectedValue = ID_PERSONA_ECKERD Then
        '    Me.lblCodigoSap.Visible = True
        '    Me.txtCodigoSap.Text = ""
        '    Me.txtCodigoSap.Visible = True
        'Else
        '    Me.lblCodigoSap.Visible = False
        '    Me.txtCodigoSap.Visible = False
        'End If
    End Sub

    Private Sub tabSubcuenta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabSubcuenta.SelectedIndexChanged
        'If blnInicio Then
        ' blnInicio = False
        'Exit Sub
        'End If
        If (tabSubcuenta.SelectedIndex = 0) Then
            btnCancelar_Click(Nothing, Nothing)
        ElseIf tabSubcuenta.SelectedIndex = 1 Then
            If Me.dgvSubcuentas.RowCount > 0 Then
                EditarToolStripMenuItem_Click(Nothing, Nothing)
            Else
                NuevoToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub cmbCiudad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCiudad.SelectedIndexChanged
        'Dim dtSubcuenta As DataTable
        'dtSubcuenta = ServiceLocator.getSubCuenta.buscarSubCuenta(ID_PERSONA_ECKERD, Me.cmbCiudad.SelectedValue)
        'Me.cmbSubcuenta.ValueMember = "idcentro_costo"
        'Me.cmbSubcuenta.DisplayMember = "subcuenta"
        'Me.cmbSubcuenta.DataSource = dtSubcuenta

        ServiceLocator.getUtilData.cargarCombos("t_subcuenta", cmbSubcuenta, True, , Me.cmbCiudad.SelectedValue)
    End Sub

    Private Sub btnBuscar2_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar2.Click
        Try
            Cursor = Cursors.WaitCursor
            cargarDataGrid(ServiceLocator.getSubCuenta.buscarVenta(ID_PERSONA_ECKERD, Me.cmbSubcuenta.SelectedValue, Me.cmbCiudad.SelectedValue), dgvVenta)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Sub Actualizar(lngSubcuenta As Long, intOpcion As Integer)
        Try
            Dim intTipo As Integer, lngComprobante As Long
            Cursor = Cursors.WaitCursor
            For Each row As DataGridViewRow In dgvVenta.Rows
                intTipo = row.Cells("tipo").Value
                lngComprobante = row.Cells("id").Value
                If Not IsNothing(row.Cells(0).Value) Then
                    If row.Cells(0).Value = 1 Then
                        ServiceLocator.getSubCuenta.ActualizarSubcuenta(intTipo, lngComprobante, lngSubcuenta, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IdRol, dtoUSUARIOS.IP, intOpcion)
                    End If
                End If
            Next
            MessageBox.Show("La Actualización se Realizó Correctamente", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgvVenta_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVenta.CellContentClick
        If e.ColumnIndex <> 0 Then Return
        Try
            Dim iEstado As Integer
            If IsDBNull(dgvVenta.Rows(e.RowIndex).Cells(0).Value) Then
                iEstado = 2
            Else
                iEstado = dgvVenta.Rows(e.RowIndex).Cells(0).Value
            End If

            SeleccionarCheckDgv(CType(sender, DataGridView).CurrentRow, 0, iEstado)

            If ExisteCheck(dgvVenta) Then
                Me.btnActualizar.Enabled = True
            Else
                Me.btnActualizar.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgvVenta_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvVenta.CurrentCellDirtyStateChanged
        dgvVenta.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Function ExisteCheck(ByVal dgv As DataGridView) As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsNothing(row.Cells(0).Value) Then
                If row.Cells(0).Value = 1 Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub dgvVenta_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvVenta.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If dgvVenta.Rows.Count > 0 Then
                Me.Cursor = Cursors.AppStarting
                ContextMenuStrip1.Show(sender, e.X, e.Y)
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub MnuContextSelTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuContextSelTodo.Click
        Try
            Dim obj As New DtoRecojo
            SeleccionarCheckDgv(Me.dgvVenta, 0, 1)
            If Not ExisteCheck(Me.dgvVenta) Then
                Me.btnActualizar.Enabled = False
            Else
                Me.btnActualizar.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MnuContextSelEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuContextSelEliminar.Click
        Try
            SeleccionarCheckDgv(Me.dgvVenta, 0, 0)
            If Not ExisteCheck(Me.dgvVenta) Then
                Me.btnActualizar.Enabled = False
            Else
                Me.btnActualizar.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        Try
            Dim frm As New FrmActualizaSubcuenta
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Actualizar(frm.cmbSubcuenta.SelectedValue, IIf(frm.rbOrigen.Checked, 1, 2))
                Me.btnActualizar.Enabled = False
                Me.btnBuscar2_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCliente_Busq_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCliente_Busq.SelectedIndexChanged
        If IsReference(Me.cmbCliente_Busq) Then
            Me.dgvSubcuentas.Columns("codigoSap").Visible = False
            Return
        End If

        If cmbCliente_Busq.SelectedValue = ServiceLocator.getContantes.ID_PERSONA_ECKERD Then
            Me.dgvSubcuentas.Columns("codigoSap").Visible = True
        Else
            Me.dgvSubcuentas.Columns("codigoSap").Visible = False
        End If
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, AnularToolStripMenuItem.EnabledChanged, EditarToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub txtSubCuenta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubCuenta.TextChanged

    End Sub
End Class