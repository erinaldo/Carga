Imports INTEGRACION_LN
Public Class frmConsultaEntrega

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
            Dim col_huella As New DataGridViewTextBoxColumn
            With col_huella
                .Name = "huella" : .DataPropertyName = "huella"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Huella" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            x += +1
            Dim col_problema As New DataGridViewTextBoxColumn
            With col_problema
                .Name = "problema" : .DataPropertyName = "problema"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Problema" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            x += +1
            Dim col_motivo As New DataGridViewTextBoxColumn
            With col_motivo
                .Name = "motivo" : .DataPropertyName = "motivo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Motivo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            .Columns.AddRange(col_fecha_entrega, col_tipo, col_comprobante, col_destino, col_total, col_peso, col_cantidad, col_usuario, _
                              col_huella, col_problema, col_motivo)
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
            Dim col_sinhuella As New DataGridViewTextBoxColumn
            With col_sinhuella
                .Name = "sinhuella" : .DataPropertyName = "sinhuella"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Entregas sin Huella"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_porcsinhuella As New DataGridViewTextBoxColumn
            With col_porcsinhuella
                .Name = "porcsinhuella" : .DataPropertyName = "porcsinhuella"
                .DisplayIndex = x : .Visible = True : .HeaderText = "% Entregas sin Huella"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_problema As New DataGridViewTextBoxColumn
            With col_problema
                .Name = "problema" : .DataPropertyName = "problema"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Entregas con Problema"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_porcproblema As New DataGridViewTextBoxColumn
            With col_porcproblema
                .Name = "porcproblema" : .DataPropertyName = "porcproblema"
                .DisplayIndex = x : .Visible = True : .HeaderText = "% Entregas con Problema"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            .Columns.AddRange(col_destino, col_entrega, col_sinhuella, col_porcsinhuella, col_problema, col_porcproblema)
        End With
    End Sub

    Private Sub frmConsultaEntrega_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim obj As New Cls_EntregaCarga_LN

        With Me.cboOficina
            .DisplayMember = "agencia"
            .ValueMember = "id"
            .DataSource = obj.ListarAgencia
            .SelectedValue = 0
        End With

        Me.cboProblema.SelectedIndex = 0
        Me.cboHuella.SelectedIndex = 0
    End Sub

    Private Sub btnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        Filtrar()
    End Sub

    Sub ObtieneResumen(dgv As DataGridView, ByRef problema As Integer, ByRef sinhuella As Integer)
        Dim i As Integer = 0, j As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells("problema").Value.ToString.ToUpper = "SI" Then
                i += 1
            End If
            If row.Cells("huella").Value.ToString.ToUpper = "NO" Then
                j += 1
            End If
        Next
        problema = i
        sinhuella = j
    End Sub

    Sub Filtrar()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_EntregaCarga_LN
            With Me.dgv
                Dim intTipo As Integer = IIf(Me.rbtDetalle.Checked, 1, 2)
                Dim dt As DataTable = obj.ListarEntrega(Me.cboOficina.SelectedValue, Me.dtpInicio.Value.Date.ToShortDateString, _
                                                        Me.dtpFin.Value.Date.ToShortDateString, Me.cboProblema.SelectedIndex, Me.cboHuella.SelectedIndex, intTipo)
                .DataSource = dt

                Dim intTotal As Integer, intProblema As Integer, intSinHuella As Integer, dblPorcentaje As Double, dblPorcentaje2 As Double
                If Me.rbtDetalle.Checked Then
                    intTotal = Me.dgv.Rows.Count
                    ObtieneResumen(dgv, intProblema, intSinHuella)
                    dblPorcentaje = intProblema / intTotal * 100
                    dblPorcentaje2 = intSinHuella / intTotal * 100
                Else
                    intTotal = IIf(IsDBNull(dt.Compute("sum(entrega)", "")), 0, dt.Compute("sum(entrega)", ""))
                    intSinHuella = IIf(IsDBNull(dt.Compute("sum(sinhuella)", "")), 0, dt.Compute("sum(sinhuella)", ""))
                    dblPorcentaje2 = intSinHuella / intTotal * 100
                    intProblema = IIf(IsDBNull(dt.Compute("sum(problema)", "")), 0, dt.Compute("sum(problema)", ""))
                    dblPorcentaje = intProblema / intTotal * 100
                End If

                Me.lbl1.Text = intTotal
                Me.lbl2.Text = intProblema
                Me.lbl3.Text = Math.Round(dblPorcentaje, 2)
                Me.lbl4.Text = intSinHuella
                Me.lbl5.Text = Math.Round(dblPorcentaje2, 2)

                Cursor = Cursors.Default
            End With
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtDetalle_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtDetalle.CheckedChanged
        Limpiar()
        ConfigurarDGV()
    End Sub

    Private Sub rbtResumen_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtResumen.CheckedChanged
        Limpiar()
        ConfigurarDGV2()
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

    Private Sub cboHuella_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboHuella.SelectedIndexChanged
        Limpiar()
    End Sub

    Private Sub cboProblema_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProblema.SelectedIndexChanged
        Limpiar()
    End Sub

    Sub Limpiar()
        Me.dgv.DataSource = Nothing
        Me.lbl1.Text = "0"
        Me.lbl4.Text = "0"
        Me.lbl5.Text = "0.00"
        Me.lbl2.Text = "0"
        Me.lbl3.Text = "0.00"
    End Sub
End Class