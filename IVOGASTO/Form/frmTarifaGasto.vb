Imports INTEGRACION_LN
Imports INTEGRACION_EN
Public Class frmTarifaGasto
    Dim intOperacion As Operacion

    Private Sub ConfigurarDGVTarifa()
        With dgvTarifa
            Cls_Utilitarios.FormatDataGridView(dgvTarifa)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular)
            '.Font = New Font("tahoma", 10.0!, FontStyle.Regular)
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Id" : .Visible = False
            End With
            x += +1
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ciudad"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_tipo_tarifa As New DataGridViewTextBoxColumn
            With col_tipo_tarifa
                .Name = "tipo_tarifa" : .DataPropertyName = "tipo_tarifa"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Tarifa"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_tipo_gasto As New DataGridViewTextBoxColumn
            With col_tipo_gasto
                .Name = "tipo_gasto" : .DataPropertyName = "tipo_gasto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Pago"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Fecha Activación"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idciudad As New DataGridViewTextBoxColumn
            With col_idciudad
                .Name = "idciudad" : .DataPropertyName = "idciudad" : .DisplayIndex = x : .Visible = False : .HeaderText = "idciudad"
            End With
            x += +1
            Dim col_idtipo_tarifa As New DataGridViewTextBoxColumn
            With col_idtipo_tarifa
                .Name = "idtipo_tarifa" : .DataPropertyName = "idtipo_tarifa" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_tarifa"
            End With
            x += +1
            Dim col_idtipo_gasto As New DataGridViewTextBoxColumn
            With col_idtipo_gasto
                .Name = "idtipo_gasto" : .DataPropertyName = "idtipo_gasto" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_gasto"
            End With
            x += +1
            Dim col_bono As New DataGridViewTextBoxColumn
            With col_bono
                .Name = "bono" : .DataPropertyName = "bono" : .DisplayIndex = x : .Visible = False : .HeaderText = "bono"
            End With

            .Columns.AddRange(col_id, col_ciudad, col_tipo_tarifa, col_tipo_gasto, col_monto, col_fecha_inicio, col_idciudad, col_idtipo_tarifa, col_idtipo_gasto, col_bono)
        End With
    End Sub

    Sub Inicio()
        ConfigurarDGVTarifa()

        Dim obj As New Cls_Gasto_LN
        With Me.cboCiudad1
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarCiudad(1)
        End With

        With Me.cboTipoPago1
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarTipoPago(1)
        End With

        With Me.cboCiudad2
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarCiudad(2)
        End With

        With Me.cboTipoPago2
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarTipoPago(2)
        End With

        Me.cboTipoTarifa1.SelectedIndex = 0
        Me.cboTipoTarifa2.SelectedIndex = 0
    End Sub

    Private Sub frmTarifaGasto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Inicio()
    End Sub

    Sub Limpiar()
        Me.cboCiudad2.SelectedValue = 0
        Me.cboTipoTarifa2.SelectedIndex = 0
        Me.cboTipoPago2.SelectedValue = 0
        Me.txtMonto.Text = ""
        Me.dtpFechaActivacion.Value = FechaServidor()

        Me.cboCiudad2.Enabled = True
        Me.cboTipoTarifa2.Enabled = True
        Me.cboTipoPago2.Enabled = True
        Me.chkBono.Checked = False
        Me.chkBono.Visible = False
    End Sub

    Private Sub tsbGrabar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabar.Click
        Try
            If Me.cboTipoTarifa2.SelectedIndex = 0 Then
                MessageBox.Show("Seleccione Tipo de Tarifa", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoTarifa2.Focus()
                Me.cboTipoTarifa2.DroppedDown = True
                Return
            End If

            If Me.cboTipoTarifa2.SelectedIndex = 2 Then
                If Me.cboCiudad2.SelectedValue = 0 Then
                    MessageBox.Show("Seleccione Ciudad", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboCiudad2.Focus()
                    Me.cboCiudad2.DroppedDown = True
                    Return
                End If
            End If

            If Me.cboTipoPago2.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Tipo de Pago", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoPago2.Focus()
                Me.cboTipoPago2.DroppedDown = True
                Return
            End If

            If Val(Me.txtMonto.Text) = 0 Then
                MessageBox.Show("Ingrese Monto", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtMonto.Focus()
                Return
            End If

            Cursor = Cursors.WaitCursor
            Grabar()

            Me.cboCiudad1.SelectedValue = Me.cboCiudad2.SelectedValue
            Me.cboTipoTarifa1.SelectedIndex = Me.cboTipoTarifa2.SelectedIndex
            Me.cboTipoPago1.SelectedValue = Me.cboTipoPago2.SelectedValue

            Me.ListarTarifa()
            Me.tabTarifaPago.SelectedIndex = 0

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub Grabar()
        Try
            Dim obj As New Cls_Gasto_LN
            Dim objEN As New Cls_Gasto_EN

            If intOperacion = Operacion.Nuevo Then
                objEN.ID = 0
            Else
                objEN.ID = Me.dgvTarifa.CurrentRow.Cells("id").Value
            End If
            objEN.Ciudad = Me.cboCiudad2.SelectedValue
            objEN.TipoTarifa = Me.cboTipoTarifa2.SelectedIndex
            objEN.TipoGasto = Me.cboTipoPago2.SelectedValue
            objEN.Monto = Me.txtMonto.Text
            objEN.FechaInicio = Me.dtpFechaActivacion.Value.ToShortDateString
            If Me.chkBono.Visible Then
                objEN.Bono = IIf(Me.chkBono.Checked, 1, 0)
            Else
                objEN.Bono = 1
            End If
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            obj.GrabarTarifa(objEN)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub btnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        ListarTarifa()
    End Sub

    Sub ListarTarifa()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Gasto_LN
            Dim objEN As New Cls_Gasto_EN

            objEN.Ciudad = Me.cboCiudad1.SelectedValue
            objEN.TipoTarifa = Me.cboTipoTarifa1.SelectedIndex
            objEN.TipoGasto = Me.cboTipoPago1.SelectedValue

            Me.dgvTarifa.DataSource = obj.ListarTarifa(objEN)
            ActivarDesactivar(0)

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsbEditar.Click
        Editar()
        Me.cboCiudad2.Enabled = False
        Me.cboTipoTarifa2.Enabled = False
        Me.cboTipoPago2.Enabled = False
        Me.tabTarifaPago.SelectedIndex = 1
        Me.dtpFechaActivacion.Focus()
        intOperacion = Operacion.Modificar
    End Sub

    Sub Editar()
        Limpiar()
        With Me.dgvTarifa.CurrentRow
            Me.cboCiudad2.SelectedValue = .Cells("idciudad").Value
            Me.cboTipoTarifa2.SelectedIndex = .Cells("idtipo_tarifa").Value
            Me.cboTipoPago2.SelectedValue = .Cells("idtipo_gasto").Value
            Me.dtpFechaActivacion.Value = .Cells("fecha_inicio").Value
            Me.txtMonto.Text = Format(.Cells("monto").Value, "0.00")

            If .Cells("idtipo_tarifa").Value = 2 And .Cells("idtipo_gasto").Value = 1 Then
                Me.chkBono.Checked = IIf(.Cells("bono").Value = 1, True, False)
                Me.chkBono.Visible = True
            Else
                Me.chkBono.Checked = False
                Me.chkBono.Visible = False
            End If
        End With
    End Sub

    Sub ActivarDesactivar(tab As Integer)
        If tab = 0 Then
            Me.tsbGrabar.Enabled = False
            If Me.dgvTarifa.Rows.Count = 0 Then
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            Else
                Me.tsbEditar.Enabled = True
                Me.tsbAnular.Enabled = True
            End If
        Else
            Me.tsbGrabar.Enabled = True
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
        End If
    End Sub

    Sub Nuevo()
        Limpiar()
        RemoveHandler tabTarifaPago.SelectedIndexChanged, AddressOf tabTarifaPago_SelectedIndexChanged
        Me.tabTarifaPago.SelectedIndex = 1
        AddHandler tabTarifaPago.SelectedIndexChanged, AddressOf tabTarifaPago_SelectedIndexChanged
        ActivarDesactivar(1)
        Me.cboCiudad2.Focus()
    End Sub

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
        intOperacion = Operacion.Nuevo
        Nuevo()
    End Sub

    Private Sub tabTarifaPago_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabTarifaPago.SelectedIndexChanged
        If tabTarifaPago.SelectedIndex = 1 Then
            If Me.dgvTarifa.Rows.Count = 0 Then
                tsbNuevo_Click(Nothing, Nothing)
            Else
                tsbEditar_Click(Nothing, Nothing)
            End If
        End If
        ActivarDesactivar(Me.tabTarifaPago.SelectedIndex)
    End Sub

    Private Sub dgvTarifa_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvTarifa.DoubleClick
        If Me.dgvTarifa.Rows.Count > 0 Then
            tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtMonto_Enter(sender As Object, e As System.EventArgs) Handles txtMonto.Enter
        Me.txtMonto.SelectAll()
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.chkBono.Visible = False Then
                tsbGrabar_Click(Nothing, Nothing)
            Else
                SendKeys.Send(vbTab)
            End If
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtMonto.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMonto_LostFocus(sender As Object, e As System.EventArgs) Handles txtMonto.LostFocus
        Dim dblMonto As Double = IIf(Me.txtMonto.Text.Trim = "", 0, Me.txtMonto.Text)
        Me.txtMonto.Text = Format(dblMonto, "0.00")
    End Sub

    Private Sub cboCiudad2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCiudad2.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboTipoTarifa2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoTarifa2.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboTipoPago2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoPago2.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dtpFechaActivacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaActivacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub tsbAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsbAnular.Click
        Anular()
    End Sub

    Sub Anular()
        Try
            Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está seguro de anular la Tarifa?", "Tarifa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Dim obj As New Cls_Gasto_LN
                Dim objEN As New Cls_Gasto_EN
                objEN.ID = Me.dgvTarifa.CurrentRow.Cells("id").Value
                obj.AnularTarifa(objEN)
                Me.ListarTarifa()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtMonto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMonto.TextChanged

    End Sub

    Private Sub cboTipoTarifa1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoTarifa1.SelectedIndexChanged
        If Me.cboTipoTarifa1.SelectedIndex = 1 Then
            Me.cboCiudad1.SelectedIndex = 0
            Me.cboCiudad1.Enabled = False
        Else
            Me.cboCiudad1.Enabled = True
        End If
    End Sub

    Private Sub cboTipoTarifa2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoTarifa2.SelectedIndexChanged
        If Me.cboTipoTarifa2.SelectedIndex = 1 Then
            Me.cboCiudad2.SelectedIndex = 0
            Me.cboCiudad2.Visible = False
            Me.lblCiudad.Visible = False
        Else
            Me.cboCiudad2.Visible = True
            Me.lblCiudad.Visible = True
        End If

        If Me.cboTipoTarifa2.SelectedIndex = 2 And Me.cboTipoPago2.SelectedIndex = 1 Then
            Me.chkBono.Visible = True
            Me.chkBono.Checked = False
        Else
            Me.chkBono.Visible = False
            Me.chkBono.Checked = False
        End If
    End Sub

    Private Sub chkBono_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles chkBono.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            tsbGrabar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cboTipoPago2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoPago2.SelectedIndexChanged
        If Me.cboTipoTarifa2.SelectedIndex = 2 And Me.cboTipoPago2.SelectedIndex = 1 Then
            Me.chkBono.Visible = True
            Me.chkBono.Checked = False
        Else
            Me.chkBono.Visible = False
            Me.chkBono.Checked = False
        End If
    End Sub
End Class