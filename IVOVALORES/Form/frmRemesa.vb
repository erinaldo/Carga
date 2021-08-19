Imports INTEGRACION_LN
Public Class frmRemesa
    Dim dtProveedor As DataTable
    Dim intOperacion As Operacion
    Dim blnInicio As Boolean
    Dim toolTip As New ToolTip()

    Sub FormateardgvLista()
        With dgvLista
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = True : .HeaderText = "Número"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha/Hora"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_agencia As New DataGridViewTextBoxColumn
            With col_id_agencia
                .Name = "id_agencia" : .DataPropertyName = "id_agencia" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_agencia"
            End With

            x += +1
            Dim col_soles As New DataGridViewTextBoxColumn
            With col_soles
                .Name = "soles" : .DataPropertyName = "soles"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Soles" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_dolar As New DataGridViewTextBoxColumn
            With col_dolar
                .Name = "dolar" : .DataPropertyName = "dolar"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dólares" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_banco As New DataGridViewTextBoxColumn
            With col_banco
                .Name = "banco" : .DataPropertyName = "banco" : .DisplayIndex = x : .Visible = False : .HeaderText = "banco"
            End With

            x += +1
            Dim col_cuenta_corriente As New DataGridViewTextBoxColumn
            With col_cuenta_corriente
                .Name = "cuenta_corriente" : .DataPropertyName = "cuenta_corriente" : .DisplayIndex = x : .Visible = False : .HeaderText = "cuenta_corriente"
            End With

            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante" : .DisplayIndex = x : .Visible = False : .HeaderText = "comprobante"
            End With

            x += +1
            Dim col_idportavalor As New DataGridViewTextBoxColumn
            With col_idportavalor
                .Name = "idportavalor" : .DataPropertyName = "idportavalor" : .DisplayIndex = x : .Visible = False : .HeaderText = "idportavalor"
            End With

            x += +1
            Dim col_portavalor As New DataGridViewTextBoxColumn
            With col_portavalor
                .Name = "portavalor" : .DataPropertyName = "portavalor"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Portavalor"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Observación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_estado_registro As New DataGridViewTextBoxColumn
            With col_id_estado_registro
                .Name = "id_estado_registro" : .DataPropertyName = "id_estado_registro" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado_registro"
            End With

            .Columns.AddRange(col_id, col_fecha, col_id_agencia, col_soles, col_dolar, col_banco, col_cuenta_corriente, col_comprobante, _
                              col_idportavalor, col_portavalor, col_id_estado, col_estado, col_observacion, col_id_estado_registro)
        End With
    End Sub
    Sub FormateardgvBolsa()
        With dgvBolsa
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id_preliq" : .DataPropertyName = "id_preliq" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_preliq"
            End With

            x += +1
            Dim col_id_cab As New DataGridViewTextBoxColumn
            With col_id_cab
                .Name = "id_preliq_det" : .DataPropertyName = "id_preliq_det" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_preliq_det"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha/Hora"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_moneda As New DataGridViewTextBoxColumn
            With col_moneda
                .Name = "moneda" : .DataPropertyName = "moneda"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Moneda"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_id_cab, col_fecha, col_codigo, col_moneda, col_monto, col_usuario)
        End With
    End Sub

    Sub ListarBanco()
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboBanco
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarBanco()
            .SelectedValue = 0
        End With
    End Sub

    Sub ListarProveedor()
        Dim obj As New Cls_LiquidacionValor_LN
        dtProveedor = obj.ListarProveedor()
        With Me.cboPortavalor
            .ValueMember = "id"
            .DisplayMember = "proveedor"
            .DataSource = dtProveedor
            .SelectedValue = 0
        End With
    End Sub

    Sub ListarCuentaCorriente(ByVal banco As Integer)
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboCuentaCorriente
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarCuentaCorriente(banco)
            .SelectedValue = 0
        End With
    End Sub

    Sub ListarRemesa()
        Dim strInicio As String = Me.dtpInicio.Value.ToShortDateString
        Dim strFin As String = Me.dtpFin.Value.ToShortDateString
        Dim intAgencia As Integer = Me.cboAgencia.SelectedValue

        Dim obj As New Cls_LiquidacionValor_LN
        Dim dt As DataTable = obj.ListarRemesa(strInicio, strFin, intAgencia)
        Me.dgvLista.DataSource = dt

        If dt.Rows.Count = 0 Then
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
        End If
    End Sub

    Sub ListarAgencia()
        Dim obj As New Cls_LiquidacionValor_LN
        With Me.cboAgencia
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = obj.ListarAgencia()
            .SelectedValue = dtoUSUARIOS.iIDAGENCIAS
        End With
    End Sub

    Private Sub txtCodigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.GotFocus
        Me.txtCodigo.SelectAll()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtCodigo.SelectionStart = 0
            Me.txtCodigo.SelectionLength = Me.txtCodigo.Text.Length
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Try
            If e.KeyChar = Chr(Keys.Enter) Then
                If Val(Me.txtCodigo.Text) = 0 Then Return

                Cursor = Cursors.WaitCursor
                PrepararBolsa(Me.txtCodigo.Text.Trim)
                Cursor = Cursors.Default
            Else
                If Not ValidarNumero(e.KeyChar) Then
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Remesa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub PrepararBolsa(ByVal codigo As String)
        Dim obj As New Cls_LiquidacionValor_LN
        Dim ds As DataSet = obj.RetirarBolsa(codigo, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)

        Dim dtLista As DataTable = ds.Tables(0)
        Dim dtEstado As DataTable = ds.Tables(1)

        Dim intEstado As Integer = dtEstado.Rows(0).Item("idestado")
        If intEstado <> 2 And intEstado <> 3 Then
            If dtEstado.Rows(0).Item("idestado") = -1 Then
                MessageBox.Show("La Bolsa con Código " & codigo & " no existe", "Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("La Bolsa con Código " & codigo & " no está en el Cofre", "Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return
        End If
        If dtLista.Rows.Count > 0 Then
            If Not (ExisteValorGrid(Me.dgvBolsa, 3, dtLista.Rows(0).Item("codigo"))) Then
                AgregarBolsa(dtLista)
            Else
                MessageBox.Show("La Bolsa con Código " & codigo & " ya se encuentra en la lista", "Remesa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.txtCodigo.Focus()
        End If
    End Sub

    Sub AgregarBolsa(ByVal dt As DataTable)
        Dim intFila As Integer
        For Each row As DataRow In dt.Rows
            With Me.dgvBolsa
                .Rows.Add()
                intFila = .Rows.Count - 1
                .Rows(intFila).Cells("id_preliq_det").Value = row.Item("id_preliq_det")
                .Rows(intFila).Cells("id_preliq").Value = row.Item("id_preliq")
                .Rows(intFila).Cells("fecha").Value = row.Item("fecha")
                .Rows(intFila).Cells("codigo").Value = row.Item("codigo")
                .Rows(intFila).Cells("moneda").Value = row.Item("moneda")
                .Rows(intFila).Cells("monto").Value = row.Item("monto")
                .Rows(intFila).Cells("usuario").Value = row.Item("usuario")
            End With
        Next
        Total()
    End Sub

    Sub Total()
        If Me.dgvBolsa.Rows.Count > 0 Then
            Dim intBolsa As Integer = 0, dblSoles As Double = 0, dblDolar As Double = 0
            For Each row As DataGridViewRow In Me.dgvBolsa.Rows
                intBolsa += 1
                If row.Cells("moneda").Value = "SOLES" Then
                    dblSoles = dblSoles + row.Cells("monto").Value
                End If
                If row.Cells("moneda").Value = "DOLAR" Then
                    dblDolar = dblDolar + row.Cells("monto").Value
                End If
            Next
            Me.lblBolsas.Text = intBolsa
            Me.lblSoles.Text = Format(dblSoles, "###,###,###0.00")
            Me.lblDolar.Text = Format(dblDolar, "###,###,###0.00")
        Else
            Me.lblBolsas.Text = "0"
            Me.lblSoles.Text = "0.00"
            Me.lblDolar.Text = "0.00"
        End If
    End Sub

    Sub Inicio()
        blnInicio = True
        toolTip.SetToolTip(Me.btnRetirar, "Retirar Bolsa")
    End Sub

    Private Sub frmRemesa_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        blnInicio = False
    End Sub

    Private Sub frmRemesa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Inicio()
            FormateardgvLista()
            FormateardgvBolsa()
            ListarAgencia()
            ListarBanco()
            ListarProveedor()
            If dgvLista.Rows.Count > 0 Then
                tsbEditar.Enabled = True
                tsbAnular.Enabled = True
            Else
                tsbEditar.Enabled = False
                tsbAnular.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Remesa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboPortavalor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPortavalor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPortavalor.SelectedIndexChanged
        If Me.cboPortavalor.SelectedValue > 0 Then
            Me.lblCodigo.Text = dtProveedor.Rows(Me.cboPortavalor.SelectedIndex).Item("codigo")
            Me.lblDni.Text = dtProveedor.Rows(Me.cboPortavalor.SelectedIndex).Item("numero_documento")
        Else
            Me.lblCodigo.Text = ""
            Me.lblDni.Text = ""
        End If
    End Sub

    Private Sub cboBanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboBanco.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBanco.SelectedIndexChanged
        Dim intBanco As Integer
        intBanco = Me.cboBanco.SelectedValue
        ListarCuentaCorriente(intBanco)
    End Sub

    Private Sub txtComprobante_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComprobante.Enter
        Me.txtComprobante.SelectAll()
    End Sub

    Private Sub txtObservacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservacion.Enter
        Me.txtObservacion.SelectAll()
    End Sub

    Private Sub txtComprobante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComprobante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If Me.cboBanco.SelectedValue = 0 Then
            MessageBox.Show("Seleccione el banco", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboBanco.Focus()
            Return
        End If

        If Me.cboCuentaCorriente.SelectedValue = 0 Then
            MessageBox.Show("Seleccione la cuenta corriente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboCuentaCorriente.Focus()
            Return
        End If

        If Me.cboPortavalor.SelectedValue = 0 Then
            MessageBox.Show("Seleccione el portavalor", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboPortavalor.Focus()
            Return
        End If

        If Me.dgvBolsa.RowCount = 0 Then
            MessageBox.Show("Ingrese las Bolsas", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCodigo.Focus()
            Return
        End If

        Grabar()
    End Sub

    Sub Grabar()
        Try
            Dim strFecha As String, dblSoles As Double, dblDolar As Double, strComprobante As String
            Dim intPortavalor As Integer, strObservacion As String, intBanco As Integer, intCuentaCorriente As Integer
            Dim intID As Integer, intIDAnterior As Integer

            If intOperacion = Operacion.Nuevo Then
                intID = 0
                intIDAnterior = 0
            Else
                intID = Me.dgvLista.CurrentRow.Cells("id").Value
                intIDAnterior = Me.dgvLista.CurrentRow.Cells("id").Value
            End If

            strFecha = CDate(FechaServidor()).ToShortDateString
            dblSoles = CType(Me.lblSoles.Text, Double)
            dblDolar = CType(Me.lblDolar.Text, Double)
            intBanco = Me.cboBanco.SelectedValue
            intCuentaCorriente = Me.cboCuentaCorriente.SelectedValue
            strComprobante = Me.txtComprobante.Text.Trim
            intPortavalor = Me.cboPortavalor.SelectedValue
            strObservacion = Me.txtObservacion.Text.Trim

            Dim obj As New Cls_LiquidacionValor_LN
            intID = obj.GrabarRemesa(intID, strFecha, dtoUSUARIOS.iIDAGENCIAS, dblSoles, dblDolar, strComprobante, intPortavalor, strObservacion, _
                             intBanco, intCuentaCorriente, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
            Dim intIdPreliquidacion As Integer
            With Me.dgvBolsa
                For Each row As DataGridViewRow In Me.dgvBolsa.Rows
                    intIdPreliquidacion = row.Cells("id_preliq_det").Value
                    obj.GrabarRemesa(intID, intIdPreliquidacion, intIDAnterior, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
                Next
            End With
            Me.Limpiar()
            intOperacion = Operacion.Nuevo
            ListarRemesa()
            Me.tabRemesas.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            Cursor = Cursors.AppStarting
            ListarRemesa()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Listar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Limpiar()
        Me.cboBanco.SelectedValue = 0
        Me.cboCuentaCorriente.SelectedValue = 0
        Me.cboPortavalor.SelectedValue = 0
        Me.lblDni.Text = ""
        Me.lblCodigo.Text = ""
        Me.txtComprobante.Text = ""
        Me.txtObservacion.Text = ""
        Me.dgvBolsa.Rows.Clear()
        Me.lblSoles.Text = "0.00"
        Me.lblDolar.Text = "0.00"
        Me.lblBolsas.Text = "0"
        Me.btnRetirar.Enabled = False
        Me.txtCodigo.Text = ""
    End Sub

    Sub ListarBolsa(ByVal id As Integer)
        Dim obj As New Cls_LiquidacionValor_LN
        Dim dt As DataTable = obj.ListarBolsa(id)
        AgregarBolsa(dt)
    End Sub

    Private Sub tsbNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        intOperacion = Operacion.Nuevo
        blnInicio = True
        Me.Limpiar()
        tsbGrabar.Enabled = True
        Me.tsbEditar.Enabled = False
        tabRemesas.SelectedIndex = 1
        Me.txtCodigo.Focus()
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Try
            Cursor = Cursors.AppStarting
            With dgvLista
                intOperacion = Operacion.Modificar
                blnInicio = False
                Me.Limpiar()
                Me.cboBanco.SelectedValue = .CurrentRow.Cells("banco").Value
                Me.cboCuentaCorriente.SelectedValue = .CurrentRow.Cells("cuenta_corriente").Value
                Me.cboPortavalor.SelectedValue = .CurrentRow.Cells("idportavalor").Value

                Me.txtComprobante.Text = IIf(IsDBNull(.CurrentRow.Cells("comprobante").Value), "", .CurrentRow.Cells("comprobante").Value)
                Me.txtObservacion.Text = IIf(IsDBNull(.CurrentRow.Cells("observacion").Value), "", .CurrentRow.Cells("observacion").Value)

                Dim intID As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
                ListarBolsa(intID)
                Cursor = Cursors.Default

                tabRemesas.SelectedIndex = 1

                Me.tsbEditar.Enabled = False
                Me.txtCodigo.Focus()
            End With
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Editar Remesa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRetirar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetirar.Click
        Try
            If intOperacion = Operacion.Modificar Then
                If Me.dgvBolsa.Rows.Count = 1 Then
                    MessageBox.Show("La Remesa no puede quedarse sin bolsas. Anule la Remesa", "Retirar Bolsa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnRetirar.Focus()
                    Return
                End If
            End If

            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de retirar la bolsa?", "Retirar Bolsa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                If intOperacion = Operacion.Modificar Then
                    Dim IntID As Integer = Me.dgvBolsa.CurrentRow.Cells("id").Value
                    Dim obj As New Cls_LiquidacionValor_LN
                    obj.RetornarBolsa(IntID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
                End If
                Me.dgvBolsa.Rows.Remove(Me.dgvBolsa.CurrentRow)
                Total()
                Me.txtCodigo.Text = ""
                Me.txtCodigo.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Retirar Bolsa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvBolsa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvBolsa.KeyDown
        If Me.btnRetirar.Enabled Then
            If e.KeyCode = Keys.Delete Then
                Me.btnRetirar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub dgvBolsa_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvBolsa.RowsAdded
        Me.btnRetirar.Enabled = True
    End Sub

    Private Sub dgvBolsa_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvBolsa.RowsRemoved
        Me.btnRetirar.Enabled = Me.dgvBolsa.Rows.Count > 0
    End Sub

    Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click
        Try
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de anular la Remesa?", "Anular Remesa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                AnularRemesa()
                ListarRemesa()
                Me.btnConsultar.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Anular Remesa", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AnularRemesa()
        Dim intID As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
        Dim obj As New Cls_LiquidacionValor_LN
        obj.AnularRemesa(intID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
    End Sub

    Private Sub tabRemesas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabRemesas.SelectedIndexChanged
        If tabRemesas.SelectedIndex = 0 Then
            Me.tsbNuevo.Enabled = True
            Me.tsbGrabar.Enabled = False
            If Me.dgvLista.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                Me.tsbAnular.Enabled = True
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
        Else
            Me.tsbNuevo.Enabled = False
            Me.tsbAnular.Enabled = False
            If Me.dgvLista.Rows.Count > 0 And blnInicio = False Then
                Me.tsbGrabar.Enabled = True
                Me.tsbEditar_Click(Nothing, Nothing)
            Else
                Me.tsbNuevo_Click(Nothing, Nothing)
            End If
        End If
        blnInicio = False
    End Sub

    Private Sub dgvLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLista.DoubleClick
        If Me.dgvLista.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cboCuentaCorriente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCuentaCorriente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub dgvLista_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        If dgvLista.Rows(e.RowIndex).Cells("id_estado").Value = 1 Then
            Me.tsbEditar.Enabled = True
            Me.tsbAnular.Enabled = True
        Else
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
        End If
    End Sub
End Class
