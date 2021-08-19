Public Class frmResumenVentas

    Sub FormateardgvLista()
        With dgv
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
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            x += +1
            Dim col_venta As New DataGridViewTextBoxColumn
            With col_venta
                .Name = "venta" : .DataPropertyName = "venta"
                .DisplayIndex = x : .HeaderText = "Venta" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .HeaderText = "Tipo" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_subtotal As New DataGridViewTextBoxColumn
            With col_subtotal
                .Name = "subtotal" : .DataPropertyName = "subtotal"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subtotal" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_impuesto As New DataGridViewTextBoxColumn
            With col_impuesto
                .Name = "impuesto" : .DataPropertyName = "impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Impuesto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            .Columns.AddRange(col_venta, col_tipo, col_subtotal, col_impuesto, col_total)
        End With
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New dtoVentaCargaContado
            Dim dt As DataTable = obj.ResumenVentas(Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString, _
                                                    Me.cboCiudad.SelectedValue, Me.cboAgencia.SelectedValue)
            Me.dgv.DataSource = dt


            Dim subtotal As Double = IIf(IsDBNull(dt.Compute("sum(subtotal)", "")), 0, dt.Compute("sum(subtotal)", ""))
            Dim impuesto As Double = IIf(IsDBNull(dt.Compute("sum(impuesto)", "")), 0, dt.Compute("sum(impuesto)", ""))
            Dim total As Double = IIf(IsDBNull(dt.Compute("sum(total)", "")), 0, dt.Compute("sum(total)", ""))

            Me.lblSubtotal.Text = Format(subtotal, "###,###,###0.00")
            Me.lblImpuesto.Text = Format(impuesto, "###,###,###0.00")
            Me.lblTotal.Text = Format(total, "###,###,###0.00")
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmResumenVentas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormateardgvLista()
        With Me.cboCiudad
            Dim obj As dtoVentaCargaContado = New dtoVentaCargaContado
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarCiudad
            .SelectedValue = 0
        End With
    End Sub

    Private Sub cboCiudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCiudad.SelectedIndexChanged
        With Me.cboAgencia
            Dim obj As dtoVentaCargaContado = New dtoVentaCargaContado
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarAgencia(Me.cboCiudad.SelectedValue)
        End With
    End Sub
End Class