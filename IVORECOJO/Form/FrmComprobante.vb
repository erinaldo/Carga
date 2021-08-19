Public Class FrmComprobante
    Dim dt As DataTable
#Region "Formato Grid"
    Sub FormatoDgv()
        With Dgv
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            'Dim col_seleccion As New DataGridViewCheckBoxColumn
            'With col_seleccion
            '    .HeaderText = "Sel."
            '    .Name = "sel"
            '    '.DataPropertyName = "id_persona"
            '    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '    '.SortMode = DataGridViewColumnSortMode.NotSortable
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    .Width = 35
            '    .SortMode = DataGridViewColumnSortMode.Automatic
            '    .FalseValue = 0
            '    .TrueValue = 1
            'End With

            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .HeaderText = "Fecha"
                .Name = "fecha"
                .DataPropertyName = "fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .HeaderText = "Id"
                .Name = "id"
                .DataPropertyName = "id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            Dim col_id_tipo As New DataGridViewTextBoxColumn
            With col_id_tipo
                .HeaderText = "Id Tipo Doc"
                .Name = "id_tipo"
                .DataPropertyName = "id_tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .HeaderText = "Tipo Doc"
                .Name = "tipo"
                .DataPropertyName = "tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_documento As New DataGridViewTextBoxColumn
            With col_documento
                .HeaderText = "Nº Doc"
                .Name = "documento"
                .DataPropertyName = "documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .HeaderText = "Orígen"
                .Name = "origen"
                .DataPropertyName = "origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .HeaderText = "Destino"
                .Name = "destino"
                .DataPropertyName = "destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_origen2 As New DataGridViewTextBoxColumn
            With col_origen2
                .HeaderText = "Ag Orígen"
                .Name = "origen2"
                .DataPropertyName = "origen2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_destino2 As New DataGridViewTextBoxColumn
            With col_destino2
                .HeaderText = "Ag Destino"
                .Name = "destino2"
                .DataPropertyName = "destino2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .HeaderText = "Cliente"
                .Name = "cliente"
                .DataPropertyName = "cliente"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 200
            End With

            Dim col_s As New DataGridViewTextBoxColumn
            With col_s
                .HeaderText = "Subtotal"
                .Name = "subtotal"
                .DataPropertyName = "monto_sub_total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "#,###,###0.00"
            End With

            Dim col_i As New DataGridViewTextBoxColumn
            With col_i
                .HeaderText = "Impuesto"
                .Name = "impuesto"
                .DataPropertyName = "monto_impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "#,###,###0.00"
            End With

            Dim col_t As New DataGridViewTextBoxColumn
            With col_t
                .HeaderText = "Total"
                .Name = "total"
                .DataPropertyName = "total_costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "#,###,###0.00"
            End With

            .Columns.AddRange(col_fecha, col_id, col_id_tipo, col_tipo, col_documento, col_origen, col_origen2, col_destino, _
            col_destino2, col_cliente, col_s, col_i, col_t)
        End With
    End Sub
#End Region
    Private Sub FrmConfirmacionRecojo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.FormatoDgv()
            With CboAgencia
                Dim obj As New DtoAsociacion
                dt = obj.ListarAgencia(5100)
                .DataSource = dt
                .DisplayMember = "nombre"
                .ValueMember = "id"
                .SelectedValue = 51
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Buscar()
            If Me.Dgv.Rows.Count > 0 Then
                Me.BtnAceptar.Enabled = True
                Me.BtnAceptar.Focus()
            Else
                Me.BtnAceptar.Enabled = False
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Buscar()
        Try
            Dim obj As New DtoAsociacion
            Dim dt As DataTable = obj.Buscar(Me.DtpFechaInicio.Text, Me.DtpFechaFin.Text, 5100, Me.CboAgencia.SelectedValue)
            Me.Dgv.DataSource = dt
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub TxtDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDocumento.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                Me.Cursor = Cursors.AppStarting
                Dim obj As New DtoAsociacion
                Dim sDocumento As String = Me.TxtDocumento.Text
                Dim dt As DataTable = obj.Buscar(sDocumento)
                Me.Dgv.DataSource = dt
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Me.Cursor = Cursors.AppStarting
        Dim Rows As DataGridViewSelectedRowCollection = Me.Dgv.SelectedRows
        cRows = Rows
    End Sub

    Private Sub Dgv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv.DoubleClick
        If Dgv.Rows.Count > 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            BtnAceptar_Click(sender, e)
        End If
    End Sub
End Class