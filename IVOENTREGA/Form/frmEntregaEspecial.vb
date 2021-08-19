Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class frmEntregaEspecial
    Sub FormatearDGVLista()
        With dgvLista
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.7!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = False
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = False
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_sel As New DataGridViewCheckBoxColumn
            With col_sel
                .HeaderText = "Sel"
                .Name = "sel"
                '.DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 50
                '.ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                '.Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DisplayIndex = x
                '.ReadOnly = False
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 35
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .HeaderText = "Nº Doc." : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero_documento As New DataGridViewTextBoxColumn
            With col_numero_documento
                .Name = "numero_documento" : .DataPropertyName = "numero_documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ruc/Dni"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Razón Social"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Width = 235 '280 '325
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,##                #0.00"
            End With
            x += +1
            Dim col_idtipo_comprobante As New DataGridViewTextBoxColumn
            With col_idtipo_comprobante
                .Name = "idtipo_comprobante" : .DataPropertyName = "idtipo_comprobante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_comprobante"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            .Columns.AddRange(col_sel, col_tipo, col_comprobante, col_fecha, col_numero_documento, col_cliente, _
                              col_estado, col_cantidad, col_peso, _
                              col_origen, col_destino, col_idtipo_comprobante, col_id, col_total)
        End With
    End Sub
    Sub Inicio()
        Dim obj As New Cls_EntregaCarga_LN
        Dim dt As DataTable = obj.Inicio.Tables(0)

        Me.cboTipoComprobante.SelectedIndex = 0
        With Me.cboOrigen
            .DisplayMember = "ciudad"
            .ValueMember = "id"
            .DataSource = dt
            .SelectedIndex = 0
        End With

        With Me.cboDestino
            .DisplayMember = "ciudad"
            .ValueMember = "id"
            .DataSource = dt.Copy
            .SelectedIndex = 0
        End With

        FormatearDGVLista()
        'Cls_Utilitarios.FormatDataGridView(dgvLista)

        Me.btnEntregar.Enabled = False
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Try
            Cursor = Cursors.WaitCursor
            ListarCarga()
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Entrega de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarCarga()
        Dim obj_AD As New Cls_EntregaCarga_LN
        Dim obj_EN As New Cls_EntregaCarga_EN


        If Me.txtNumeroDocumento.Text.Trim.Length > 0 Then
            obj_EN.SerieComprobante = "0"
            obj_EN.NumeroComprobante = "0"
            obj_EN.Nombres = ""
            obj_EN.NumeroDocumento = Me.txtNumeroDocumento.Text.Trim
        ElseIf Me.txtCliente.Text.Trim.Length > 0 Then
            obj_EN.SerieComprobante = "0"
            obj_EN.NumeroComprobante = "0"
            obj_EN.NumeroDocumento = ""
            obj_EN.Nombres = Me.txtCliente.Text.Trim
        ElseIf Me.txtNumeroComprobante.Text.Trim.Length > 0 Then
            obj_EN.NumeroDocumento = ""
            obj_EN.Nombres = ""

            Dim strNumeroComprobante As String() = Split(txtNumeroComprobante.Text, "-")
            If strNumeroComprobante.Length > 1 Then
                If strNumeroComprobante(0).Length > 1 And Val(strNumeroComprobante(1)) > 0 Then
                    obj_EN.SerieComprobante = strNumeroComprobante(0)
                    obj_EN.NumeroComprobante = strNumeroComprobante(1)
                Else
                    obj_EN.SerieComprobante = "0"
                    obj_EN.NumeroComprobante = "0"
                End If
            Else
                If strNumeroComprobante.Length = 1 Then
                    obj_EN.SerieComprobante = "0"
                    obj_EN.NumeroComprobante = strNumeroComprobante(0)
                Else
                    obj_EN.SerieComprobante = "0"
                    obj_EN.NumeroComprobante = "0"
                End If
            End If
        Else
            obj_EN.SerieComprobante = "0"
            obj_EN.NumeroComprobante = "0"
            obj_EN.NumeroDocumento = ""
            obj_EN.Nombres = ""
        End If

        obj_EN.FechaInicio = Me.dtpInicio.Value.ToShortDateString
        obj_EN.FechaFin = Me.dtpFin.Value.ToShortDateString

        obj_EN.Origen = Me.cboOrigen.SelectedValue
        obj_EN.Destino = Me.cboDestino.SelectedValue

        Me.dgvLista.DataSource = obj_AD.ListarCarga(obj_EN.FechaInicio, obj_EN.FechaFin, obj_EN.Origen, obj_EN.Destino, _
                                 obj_EN.NumeroDocumento, obj_EN.SerieComprobante, obj_EN.NumeroComprobante, obj_EN.Nombres, Me.cboTipoComprobante.SelectedIndex)
        Me.lblRegistros.Text = Me.dgvLista.Rows.Count

        'Me.btnEntregar.Enabled = dgvLista.Rows.Count > 0
        Activar()
    End Sub

    Private Sub frmEntregaEspecial_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Inicio()
    End Sub

    Private Sub btnEntregar_Click(sender As System.Object, e As System.EventArgs) Handles btnEntregar.Click
        Dim lista As List(Of DataGridViewRow) = ObtenerListaCheck(dgvLista, "sel")
        Dim frm As New frmEntregaEspecialConfirmacion
        frm.Cargar(lista)
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            btnBuscar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgvLista_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellContentClick
        If e.ColumnIndex <> 0 Then Return
        Activar()
    End Sub

    Private Sub dgvLista_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvLista.CurrentCellDirtyStateChanged
        dgvLista.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Function NumeroCheck(ByVal dgv As DataGridView) As Integer
        Dim intNumero As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsNothing(row.Cells(0).Value) Then
                If row.Cells(0).Value = 1 Or row.Cells(0).Value Then
                    intNumero += 1
                End If
            End If
        Next
        Return intNumero
    End Function

    Sub Activar()
        Dim intNumero As Integer = NumeroCheck(dgvLista)
        If intNumero > 0 Then
            Me.btnEntregar.Enabled = True
        Else
            Me.btnEntregar.Enabled = False
        End If
    End Sub

    Private Sub txtNumeroComprobante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroComprobante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtNumeroComprobante.Text.Trim.Length > 0 Then
                Me.btnBuscar_Click(Nothing, Nothing)
            End If
        Else
            If ValidaNumero2(e.KeyChar) Then
                e.Handled = False
            ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNumeroComprobante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroComprobante.TextChanged

    End Sub

    Private Sub txtNumeroDocumento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroDocumento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtNumeroDocumento.Text.Trim.Length >= 0 Then
                Me.btnBuscar_Click(Nothing, Nothing)
            End If
        Else
            If (Not ValidarNumero(e.KeyChar)) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNumeroDocumento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroDocumento.TextChanged

    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtCliente.Text.Trim.Length > 0 Then
                Me.btnBuscar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub txtCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCliente.TextChanged

    End Sub
End Class