Imports INTEGRACION_LN
Public Class frmConsultaEntregaDomicilio

    Private Sub ConfigurarDGV()
        With dgv
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvRecojo)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
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
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_entrega As New DataGridViewTextBoxColumn
            With col_entrega
                .Name = "entrega" : .DataPropertyName = "entrega"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Entregas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_movil As New DataGridViewTextBoxColumn
            With col_movil
                .Name = "movil" : .DataPropertyName = "movil"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Entregas con Tablet"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_porcmovil As New DataGridViewTextBoxColumn
            With col_porcmovil
                .Name = "porcmovil" : .DataPropertyName = "porcmovil"
                .DisplayIndex = x : .Visible = True : .HeaderText = "% Entregas con Tablet"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            .Columns.AddRange(col_destino, col_entrega, col_movil, col_porcmovil)
        End With
    End Sub

    Private Sub ConfigurarDGV2()
        With dgv
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvRecojo)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
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
            Dim col_fecha_entrega As New DataGridViewTextBoxColumn
            With col_fecha_entrega
                .Name = "fecha_entrega" : .DataPropertyName = "fecha_entrega" : .DisplayIndex = x : .HeaderText = "Fecha Entrega" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_entrega As New DataGridViewTextBoxColumn
            With col_entrega
                .Name = "entrega" : .DataPropertyName = "entrega"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Entrega" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            x += +1
            Dim col_movil As New DataGridViewTextBoxColumn
            With col_movil
                .Name = "movil" : .DataPropertyName = "movil"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Entrega con Tablet" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            .Columns.AddRange(col_fecha_entrega, col_tipo, col_comprobante, col_destino, col_total, col_peso, col_cantidad, col_usuario, _
                              col_entrega, col_movil)
        End With
    End Sub

    Private Sub frmConsultaEntregaDomicilio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim obj As New Cls_EntregaCarga_LN

        With Me.cboOficina
            .DisplayMember = "agencia"
            .ValueMember = "id"
            .DataSource = obj.ListarAgencia
            .SelectedValue = 0
        End With
        'Me.cboMovil.SelectedIndex = 0
        ConfigurarDGV()
    End Sub

    Private Sub btnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        Filtrar()
    End Sub

    Sub Filtrar()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_EntregaCarga_LN
            With Me.dgv
                Dim intTipo As Integer = IIf(Me.rbtResumen.Checked, 1, 2)
                Dim dt As DataTable = obj.ListarEntregaDomicilio(Me.cboOficina.SelectedValue, Me.dtpInicio.Value.Date.ToShortDateString, _
                                                        Me.dtpFin.Value.Date.ToShortDateString, 0, intTipo)
                .DataSource = dt

                Dim intTotal As Integer, intMovil As Integer, dblPorcentaje As Double
                If Me.rbtResumen.Checked Then
                    intTotal = IIf(IsDBNull(dt.Compute("sum(entrega)", "")), 0, dt.Compute("sum(entrega)", ""))
                    intMovil = IIf(IsDBNull(dt.Compute("sum(movil)", "")), 0, dt.Compute("sum(movil)", ""))
                    dblPorcentaje = intMovil / intTotal * 100
                Else
                    intTotal = Me.dgv.Rows.Count
                    intMovil = IIf(IsDBNull(dt.Compute("count(movil)", "")), 0, dt.Compute("count(movil)", "movil='Si'"))
                    dblPorcentaje = intMovil / intTotal * 100
                End If

                Me.lbl1.Text = intTotal
                Me.lbl2.Text = intMovil
                Me.lbl3.Text = Math.Round(dblPorcentaje, 2)

                Cursor = Cursors.Default
            End With
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtResumen_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtResumen.CheckedChanged
        Limpiar()
        ConfigurarDGV()
    End Sub

    Private Sub rbtDetalle_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtDetalle.CheckedChanged
        Limpiar()
        ConfigurarDGV2()
    End Sub

    Sub Limpiar()
        Me.dgv.DataSource = Nothing
        Me.lbl1.Text = "0"
        Me.lbl2.Text = "0"
        Me.lbl3.Text = "0.00"
    End Sub

    Private Sub cboOficina_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOficina.SelectedIndexChanged
        Limpiar()
    End Sub

    Private Sub dtpInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpInicio.ValueChanged
        Limpiar()
    End Sub

    Private Sub dtpFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFin.ValueChanged
        Limpiar()
    End Sub
End Class