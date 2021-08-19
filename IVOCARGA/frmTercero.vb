Public Class frmTercero

    Sub Formato()
        With Me.dgv
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .AllowUserToResizeColumns = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            '.RowHeadersVisible = True
            .RowHeadersWidth = 20
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            '.ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black
            .ReadOnly = True 'readonly cuando este false se puede editar
            '.Focus()

            Dim transportista As New DataGridViewTextBoxColumn
            With transportista
                .HeaderText = "Transportista"
                .Name = "transportista"
                .DataPropertyName = "transportista"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = True
                '.ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim tipo_cliente As New DataGridViewTextBoxColumn
            With tipo_cliente
                .HeaderText = "Tipo Cliente"
                .Name = "tipo_cliente"
                .DataPropertyName = "tipo_cliente"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = True
                '.ReadOnly = True
            End With

            Dim cliente As New DataGridViewTextBoxColumn
            With cliente
                .HeaderText = "Cliente"
                .Name = "cliente"
                .DataPropertyName = "cliente"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = True
                '.ReadOnly = True
            End With

            Dim consignado As New DataGridViewTextBoxColumn
            With consignado
                .HeaderText = "Consignado"
                .Name = "consignado"
                .DataPropertyName = "consignado"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim tipo As New DataGridViewTextBoxColumn
            With tipo
                .HeaderText = "Tipo"
                .Name = "tipo"
                .DataPropertyName = "tipo"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim comprobante As New DataGridViewTextBoxColumn
            With comprobante
                .HeaderText = "Comprobante"
                .Name = "comprobante"
                .DataPropertyName = "comprobante"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim estado As New DataGridViewTextBoxColumn
            With estado
                .HeaderText = "Estado"
                .Name = "estado"
                .DataPropertyName = "estado"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = True
                '.ReadOnly = True
            End With

            Dim cargo As New DataGridViewTextBoxColumn
            With cargo
                .HeaderText = "Cargo"
                .Name = "cargo"
                .DataPropertyName = "cargo"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim origen As New DataGridViewTextBoxColumn
            With origen
                .HeaderText = "Orígen"
                .Name = "origen"
                .DataPropertyName = "origen"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim destino As New DataGridViewTextBoxColumn
            With destino
                .HeaderText = "Destino"
                .Name = "destino"
                .DataPropertyName = "destino"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim cantidad As New DataGridViewTextBoxColumn
            With cantidad
                .HeaderText = "Cantidad"
                .Name = "cantidad"
                .DataPropertyName = "cantidad"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                '.Width = 120
                .Visible = True
            End With

            Dim peso As New DataGridViewTextBoxColumn
            With peso
                .HeaderText = "Peso"
                .Name = "peso"
                .DataPropertyName = "peso"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.Width = 120
                .DefaultCellStyle.Format = "0.00"
                .Visible = True
            End With

            Dim subtotal As New DataGridViewTextBoxColumn
            With subtotal
                .HeaderText = "Subtotal"
                .Name = "subtotal"
                .DataPropertyName = "subtotal"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.Width = 120
                .DefaultCellStyle.Format = "0.00"
                .Visible = True
            End With

            Dim impuesto As New DataGridViewTextBoxColumn
            With impuesto
                .HeaderText = "Impuesto"
                .Name = "impuesto"
                .DataPropertyName = "impuesto"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.Width = 120
                .DefaultCellStyle.Format = "0.00"
                .Visible = True
            End With

            Dim total As New DataGridViewTextBoxColumn
            With total
                .HeaderText = "Total"
                .Name = "total"
                .DataPropertyName = "total"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.Width = 120
                .DefaultCellStyle.Format = "0.00"
                .Visible = True
            End With

            Dim fecha_registro As New DataGridViewTextBoxColumn
            With fecha_registro
                .HeaderText = "Fecha Registro"
                .Name = "fecha_registro"
                .DataPropertyName = "fecha_registro"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim fecha_despacho As New DataGridViewTextBoxColumn
            With fecha_despacho
                .HeaderText = "Fecha Despacho"
                .Name = "fecha_despacho"
                .DataPropertyName = "fecha_despacho"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .DefaultCellStyle.Format = "dd/MM/yyyy"
                '.Width = 120
                .Visible = True
            End With

            Dim fecha_recepcion As New DataGridViewTextBoxColumn
            With fecha_recepcion
                .HeaderText = "Fecha Recepción"
                .Name = "fecha_recepcion"
                .DataPropertyName = "fecha_recepcion"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim fecha_reparto As New DataGridViewTextBoxColumn
            With fecha_reparto
                .HeaderText = "Fecha Reparto"
                .Name = "fecha_reparto"
                .DataPropertyName = "fecha_reparto"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim fecha_entrega As New DataGridViewTextBoxColumn
            With fecha_entrega
                .HeaderText = "Fecha Entrega"
                .Name = "fecha_entrega"
                .DataPropertyName = "fecha_entrega"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim fecha_devolucion As New DataGridViewTextBoxColumn
            With fecha_devolucion
                .HeaderText = "Fecha Devolución"
                .Name = "fecha_devolucion"
                .DataPropertyName = "fecha_devolucion"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim incidencia As New DataGridViewTextBoxColumn
            With incidencia
                .HeaderText = "Incidencia"
                .Name = "incidencia"
                .DataPropertyName = "incidencia"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim funcionario As New DataGridViewTextBoxColumn
            With funcionario
                .HeaderText = "Funcionario"
                .Name = "funcionario"
                .DataPropertyName = "funcionario"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            .Columns.AddRange(transportista, tipo_cliente, cliente, consignado, tipo, comprobante, estado, cargo, origen, destino, cantidad, peso, _
                              subtotal, impuesto, total, fecha_registro, fecha_despacho, fecha_recepcion, fecha_reparto, fecha_entrega, _
                              fecha_devolucion, incidencia, funcionario)
        End With
    End Sub

    Private Sub frmTercero_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Formato()
    End Sub

    Private Sub btnConsultarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarLista.Click
        Try
            Cursor = Cursors.AppStarting
            Dim dt As DataTable
            Dim obj As New dtoCarga

            dt = obj.ListarOperacionTercero(Me.dtpFechaInicio.Value.ToShortDateString, Me.dtpFechaFin.Value.ToShortDateString, dtoUSUARIOS.iIDAGENCIAS)
            Me.dgv.DataSource = dt

            Dim dblSubtotal As Double, dblImpuesto As Double, dblTotal As Double

            dblSubtotal = IIf(IsDBNull(dt.Compute("sum(subtotal)", "")), 0, dt.Compute("sum(subtotal)", ""))
            dblImpuesto = IIf(IsDBNull(dt.Compute("sum(impuesto)", "")), 0, dt.Compute("sum(impuesto)", ""))
            dblTotal = IIf(IsDBNull(dt.Compute("sum(total)", "")), 0, dt.Compute("sum(total)", ""))

            Me.lblSubtotal.Text = Format(dblSubtotal, "###,###,###0.00")
            Me.lblImpuesto.Text = Format(dblImpuesto, "###,###,###0.00")
            Me.lblTotal.Text = Format(dblTotal, "###,###,###0.00")

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
End Class