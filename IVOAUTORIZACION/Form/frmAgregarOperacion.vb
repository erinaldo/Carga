Imports INTEGRACION_LN
Public Class frmAgregarOperacion
    Dim tabs6 As TabPage, tabs7 As TabPage, tabs8 As TabPage, tabs10 As TabPage, tabs11 As TabPage, tabs12 As TabPage, tabs13 As TabPage, tabs14 As TabPage, tabs15 As TabPage, tabs16 As TabPage
    Dim dt1 As DataTable

    Dim aLista As New ArrayList
    Dim intOperacion As Integer ', intTipoOperacion As Integer

    Dim dtTarifa As DataTable
    Dim dtOperacion As DataTable

    Public intOpcion As Integer = 0
    Public intUsuario As Integer

    Dim blnSalir As Boolean

#Region "Grid"
    Dim lblMotivo As Object

    Sub FormatearDGVNuevoComprobante()
        With dgvNuevoComprobante
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
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = False
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
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .HeaderText = "Fecha" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .HeaderText = "Tipo Comprobante" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .HeaderText = "Número" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_documento As New DataGridViewTextBoxColumn
            With col_documento
                .Name = "documento" : .DataPropertyName = "documento"
                .DisplayIndex = x : .HeaderText = "Nº Documento" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .HeaderText = "Cliente" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .HeaderText = "Origen" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .HeaderText = "Destino" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .HeaderText = "Total" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_idpersona As New DataGridViewTextBoxColumn
            With col_idpersona
                .Name = "idpersona" : .DataPropertyName = "idpersona" : .DisplayIndex = x : .Visible = False : .HeaderText = "idpersona"
            End With
            x += +1
            Dim col_idtipo_comprobante As New DataGridViewTextBoxColumn
            With col_idtipo_comprobante
                .Name = "idtipo_comprobante" : .DataPropertyName = "idtipo_comprobante" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_comprobante"
            End With
            x += +1
            Dim col_cantidad_peso As New DataGridViewTextBoxColumn
            With col_cantidad_peso
                .Name = "cantidad_peso" : .DataPropertyName = "cantidad_peso"
                .DisplayIndex = x : .HeaderText = "Cantidad Peso" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad_volumen As New DataGridViewTextBoxColumn
            With col_cantidad_volumen
                .Name = "cantidad_volumen" : .DataPropertyName = "cantidad_volumen"
                .DisplayIndex = x : .HeaderText = "Cantidad Volumen" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad_sobre As New DataGridViewTextBoxColumn
            With col_cantidad_sobre
                .Name = "cantidad_sobre" : .DataPropertyName = "cantidad_sobre"
                .DisplayIndex = x : .HeaderText = "Cantidad Sobre" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad_articulo As New DataGridViewTextBoxColumn
            With col_cantidad_articulo
                .Name = "cantidad_sobre" : .DataPropertyName = "cantidad_articulo"
                .DisplayIndex = x : .HeaderText = "Cantidad Articulo" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_total_peso As New DataGridViewTextBoxColumn
            With col_total_peso
                .Name = "total_peso" : .DataPropertyName = "total_peso"
                .DisplayIndex = x : .HeaderText = "Peso" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total_volumen As New DataGridViewTextBoxColumn
            With col_total_volumen
                .Name = "total_volumen" : .DataPropertyName = "total_volumen"
                .DisplayIndex = x : .HeaderText = "Volumen" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total_peso_articulo As New DataGridViewTextBoxColumn
            With col_total_peso_articulo
                .Name = "total_peso_articulo" : .DataPropertyName = "total_peso_articulo"
                .DisplayIndex = x : .HeaderText = "Peso Articulo" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            .Columns.AddRange(col_id, col_fecha, col_tipo, col_numero, col_documento, col_cliente, col_origen, col_destino, col_total, _
                              col_idpersona, col_idtipo_comprobante, col_cantidad_peso, col_cantidad_volumen, col_cantidad_sobre, col_cantidad_articulo, _
                              col_total_peso, col_total_volumen, col_total_peso_articulo)
        End With
    End Sub
    Sub FormatearDGVPeso7(dgv As DataGridView)
        Try
            Dim camp1 As String = "Tipo", camp2 As String = "Bulto", camp3 As String = "Peso"
            Dim camp4 As String = "Costo", camp5 As String = "Subtotal"
            With dgv
                .Columns.Clear()
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AutoGenerateColumns = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Both
                .RowHeadersWidth = 20

                Dim col1 As New DataGridViewTextBoxColumn
                With col1
                    .HeaderText = camp1
                    .Name = camp1
                    .DataPropertyName = camp1
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    .Visible = True
                End With
                .Columns.Add(col1)

                Dim col2 As New DataGridViewTextBoxColumn
                With col2
                    .HeaderText = camp2
                    .Name = camp2
                    .DataPropertyName = camp2
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .MaxInputLength = 5
                End With
                .Columns.Add(col2)

                Dim col3 As New DataGridViewTextBoxColumn
                With col3
                    .HeaderText = camp3
                    .Name = camp3
                    .DataPropertyName = camp3
                    .ReadOnly = False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .DefaultCellStyle.Format = "0.00"
                End With
                .Columns.Add(col3)

                Dim col4 As New DataGridViewTextBoxColumn
                With col4
                    .HeaderText = camp4
                    .Name = camp4
                    .DataPropertyName = camp4
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "0.00"
                End With
                .Columns.Add(col4)

                Dim col5 As New DataGridViewTextBoxColumn
                With col5
                    .HeaderText = camp5
                    .Name = camp5
                    .DataPropertyName = camp5
                    .DefaultCellStyle.Format = "0.00"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .MaxInputLength = 9
                End With
                .Columns.Add(col5)

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub FormatearDGVPeso8(dgv As DataGridView)
        Try
            Dim camp1 As String = "Tipo", camp2 As String = "Bulto", camp3 As String = "Peso"
            Dim camp4 As String = "Costo", camp5 As String = "Subtotal"
            With dgv
                .Columns.Clear()
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AutoGenerateColumns = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Both
                .RowHeadersWidth = 20

                Dim col1 As New DataGridViewTextBoxColumn
                With col1
                    .HeaderText = camp1
                    .Name = camp1
                    .DataPropertyName = camp1
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    .Visible = True
                End With
                .Columns.Add(col1)

                Dim col2 As New DataGridViewTextBoxColumn
                With col2
                    .HeaderText = camp2
                    .Name = camp2
                    .DataPropertyName = camp2
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = False
                    .MaxInputLength = 5
                    .DefaultCellStyle.Format = "0"
                End With
                .Columns.Add(col2)

                Dim col3 As New DataGridViewTextBoxColumn
                With col3
                    .HeaderText = camp3
                    .Name = camp3
                    .DataPropertyName = camp3
                    .ReadOnly = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .DefaultCellStyle.Format = "0.00"
                End With
                .Columns.Add(col3)

                Dim col4 As New DataGridViewTextBoxColumn
                With col4
                    .HeaderText = camp4
                    .Name = camp4
                    .DataPropertyName = camp4
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "0.00"
                End With
                .Columns.Add(col4)

                Dim col5 As New DataGridViewTextBoxColumn
                With col5
                    .HeaderText = camp5
                    .Name = camp5
                    .DataPropertyName = camp5
                    .DefaultCellStyle.Format = "0.00"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .MaxInputLength = 9
                End With
                .Columns.Add(col5)

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub FormatearDGVPeso10(dgv As DataGridView)
        Try
            Dim camp1 As String = "Tipo", camp2 As String = "Bulto", camp3 As String = "Peso"
            Dim camp4 As String = "Costo", camp5 As String = "Subtotal"
            With dgv
                .Columns.Clear()
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AutoGenerateColumns = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Both
                .RowHeadersWidth = 20

                Dim col1 As New DataGridViewTextBoxColumn
                With col1
                    .HeaderText = camp1
                    .Name = camp1
                    .DataPropertyName = camp1
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    .Visible = True
                End With
                .Columns.Add(col1)

                Dim col2 As New DataGridViewTextBoxColumn
                With col2
                    .HeaderText = camp2
                    .Name = camp2
                    .DataPropertyName = camp2
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .MaxInputLength = 5
                End With
                .Columns.Add(col2)

                Dim col3 As New DataGridViewTextBoxColumn
                With col3
                    .HeaderText = camp3
                    .Name = camp3
                    .DataPropertyName = camp3
                    .ReadOnly = True
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .DefaultCellStyle.Format = "0.00"
                End With
                .Columns.Add(col3)

                Dim col4 As New DataGridViewTextBoxColumn
                With col4
                    .HeaderText = camp4
                    .Name = camp4
                    .DataPropertyName = camp4
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "0.00"
                End With
                .Columns.Add(col4)

                Dim col5 As New DataGridViewTextBoxColumn
                With col5
                    .HeaderText = camp5
                    .Name = camp5
                    .DataPropertyName = camp5
                    .DefaultCellStyle.Format = "0.00"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .MaxInputLength = 9
                End With
                .Columns.Add(col5)

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub FormatearDGVPeso13(dgv As DataGridView)
        Try
            Dim camp1 As String = "Tipo", camp2 As String = "Bulto", camp3 As String = "Peso"
            Dim camp4 As String = "Costo", camp5 As String = "Subtotal"
            With dgv
                .Columns.Clear()
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AutoGenerateColumns = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Both
                .RowHeadersWidth = 20

                Dim col1 As New DataGridViewTextBoxColumn
                With col1
                    .HeaderText = camp1
                    .Name = camp1
                    .DataPropertyName = camp1
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    .Visible = True
                End With
                .Columns.Add(col1)

                Dim col2 As New DataGridViewTextBoxColumn
                With col2
                    .HeaderText = camp2
                    .Name = camp2
                    .DataPropertyName = camp2
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .MaxInputLength = 5
                End With
                .Columns.Add(col2)

                Dim col3 As New DataGridViewTextBoxColumn
                With col3
                    .HeaderText = camp3
                    .Name = camp3
                    .DataPropertyName = camp3
                    .ReadOnly = False
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .DefaultCellStyle.Format = "0.00"
                End With
                .Columns.Add(col3)

                Dim col4 As New DataGridViewTextBoxColumn
                With col4
                    .HeaderText = camp4
                    .Name = camp4
                    .DataPropertyName = camp4
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .DefaultCellStyle.Format = "0.00"
                End With
                .Columns.Add(col4)

                Dim col5 As New DataGridViewTextBoxColumn
                With col5
                    .HeaderText = camp5
                    .Name = camp5
                    .DataPropertyName = camp5
                    .DefaultCellStyle.Format = "0.00"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = True
                    .MaxInputLength = 9
                End With
                .Columns.Add(col5)

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub FormatearDGVCantidad(dgv As DataGridView)
        With dgv
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.7!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            '.VirtualMode = False
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With
            x += +1
            Dim col_articulo As New DataGridViewTextBoxColumn
            With col_articulo
                .Name = "articulo" : .DataPropertyName = "articulo"
                .DisplayIndex = x : .HeaderText = "Artículo" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .HeaderText = "Cantidad" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .MaxInputLength = 5
            End With
            x += +1
            Dim col_precio As New DataGridViewTextBoxColumn
            With col_precio
                .Name = "precio" : .DataPropertyName = "precio"
                .DisplayIndex = x : .HeaderText = "Precio" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00" : .ReadOnly = True
            End With
            x += +1
            Dim col_subtotal As New DataGridViewTextBoxColumn
            With col_subtotal
                .Name = "subtotal" : .DataPropertyName = "subtotal"
                .DisplayIndex = x : .HeaderText = "Subtotal" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "0.00" : .ReadOnly = True
            End With
            .Columns.AddRange(col_id, col_articulo, col_cantidad, col_precio, col_subtotal)
        End With
    End Sub

    Sub FormatearDGVCargo()
        With dgvCargo
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
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = False
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
            Dim col_serie As New DataGridViewTextBoxColumn
            With col_serie
                .Name = "serie" : .DataPropertyName = "serie"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Serie"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .HeaderText = "Nº Documento" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            .Columns.AddRange(col_serie, col_numero, col_id)
        End With
    End Sub

#End Region
#Region "Propiedades"
    Private intComprobante As Integer
    Public Property Comprobante() As Integer
        Get
            Return intComprobante
        End Get
        Set(ByVal value As Integer)
            intComprobante = value
        End Set
    End Property

    Private intTipoOperacion As Integer
    Public Property TipoOperacion As Integer
        Get
            Return intTipoOperacion
        End Get
        Set(ByVal value As Integer)
            intTipoOperacion = value
        End Set
    End Property

    Private intTipoComprobante As Integer
    Public Property TipoComprobante() As Integer
        Get
            Return intTipoComprobante
        End Get
        Set(ByVal value As Integer)
            intTipoComprobante = value
        End Set
    End Property

    Private intCliente As Integer
    Public Property Cliente() As Integer
        Get
            Return intCliente
        End Get
        Set(ByVal value As Integer)
            intCliente = value
        End Set
    End Property
    Private intProducto As Integer
    Public Property Producto() As Integer
        Get
            Return intProducto
        End Get
        Set(ByVal value As Integer)
            intProducto = value
        End Set
    End Property

    Private dblNC As Double
    Public Property NC() As Double
        Get
            Return dblNC
        End Get
        Set(ByVal value As Double)
            dblNC = value
        End Set
    End Property

    Private blnNuevo As Boolean
    Public Property Nuevo() As Boolean
        Get
            Return blnNuevo
        End Get
        Set(ByVal value As Boolean)
            blnNuevo = value
        End Set
    End Property


#End Region

    Private Sub frmDatosFactura_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            e.Cancel = True
            blnSalir = True
        End If
    End Sub

    Function ListarOperacion(tipo_registro As Integer, tipo As Integer, tipo_servicio As Integer, tipo_comprobante As Integer, tipo_emision As Integer, _
                             modo As Integer, rol As Integer) As DataTable
        Try
            Dim obj As New Cls_NotaCredito_LN
            Return obj.ListarOperacion(tipo_registro, tipo, tipo_servicio, tipo_comprobante, tipo_emision, modo, rol)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Sub inicio()
        blnSalir = True

        tabs6 = Me.tabOperacion.TabPages("tab6")
        tabs7 = Me.tabOperacion.TabPages("tab7")
        tabs8 = Me.tabOperacion.TabPages("tab8")
        tabs10 = Me.tabOperacion.TabPages("tab10")
        tabs11 = Me.tabOperacion.TabPages("tab11")
        tabs12 = Me.tabOperacion.TabPages("tab12")
        tabs13 = Me.tabOperacion.TabPages("tab13")
        tabs14 = Me.tabOperacion.TabPages("tab14")
        tabs15 = Me.tabOperacion.TabPages("tab15")
        tabs16 = Me.tabOperacion.TabPages("tab16")

        Limpiar()
    End Sub

    Sub ListarOperacion()
        With Me.cboOperacion
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            RemoveHandler cboOperacion.SelectedIndexChanged, AddressOf cboOperacion_SelectedIndexChanged
            Dim dt As DataTable = ListarOperacion(1, 0, 1, 3, TipoOperacion, 1, G_Rol)
            .DataSource = dt
            dtOperacion = dt
            AddHandler cboOperacion.SelectedIndexChanged, AddressOf cboOperacion_SelectedIndexChanged
            .SelectedValue = 0
        End With

        cboOperacion_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Sub Limpiar()
        With tabOperacion
            For i As Integer = 0 To tabOperacion.TabPages.Count - 1
                tabOperacion.TabPages.RemoveAt(0)
            Next
        End With
    End Sub

    Sub ListarArticulo(id As Integer, cliente As Integer, origen As Integer, destino As Integer, dgv As DataGridView)
        Dim obj As New Cls_Autorizacion_LN
        dgv.DataSource = obj.ListarArticulo(id, cliente, origen, destino)
        dgv.Refresh()
    End Sub

    Sub ListarCiudad()
        Dim obj As New UtilData_LN
        With Me.cboDestino10
            .DisplayMember = "nombre_unidad"
            .ValueMember = "idunidad_agencia"
            Dim dt As DataTable = obj.ListarCiudad()
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Sub ActivaDesactivaOperacion(estado As Boolean, Optional opcion As Integer = 0)
        If opcion = 0 Then
            Me.txtComprobante.Enabled = estado
        End If
        Me.btnAceptar.Enabled = estado
        Me.dgvNuevoComprobante.Enabled = estado
    End Sub

    Function ObtieneTitulo(operacion As Integer) As String
        Select Case operacion
            Case 7
                Return "Cambio Peso"
            Case 8
                Return "Cambio Cantidad"
            Case 10
                Return "Cambio Destino"
            Case 13
                Return "Retiro Parcial de Carga"
        End Select
    End Function

    Private Sub cboOperacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOperacion.SelectedIndexChanged
        Dim obj As New Cls_Autorizacion_LN
        Dim intOpcion As Integer = Me.cboOperacion.SelectedValue
        Limpiar()
        Me.btnAceptar.Enabled = True
        Select Case intOpcion
            Case 0
                Me.btnAceptar.Enabled = False
            Case 6
                dt1 = obj.ListarComprobante(Comprobante)
                Me.lblRazonSocialActual.Text = dt1.Rows(0).Item("razon_social")
                Me.lblRazonSocialActual.Tag = dt1.Rows(0).Item("idpersona")
                Me.lblTotal6.Text = Format(dt1.Rows(0).Item("total"), "###,###,###0.00")
                tabOperacion.TabPages.Add(tabs6)
                Me.txtRazonSocial6.Focus()
            Case 130
                dt1 = obj.ListarComprobante(Comprobante)
                Me.lblTotalActual13.Text = Format(dt1.Rows(0).Item("total"), "###,###,###0.00")
                Me.lblDescuento13.Text = Format(CType(dt1.Rows(0).Item("descuento"), Double), "0.00")
                Me.lblProducto13.Text = dt1.Rows(0).Item("nombre_producto")
                Me.lblProducto13.Tag = dt1.Rows(0).Item("producto")
                If dt1.Rows(0).Item("articulo") = 0 Then
                    FormatearDGVPeso13(Me.dgvRetiro13)
                    ListarVenta(Comprobante, Me.dgvRetiro13)
                    ListarTarifa(dt1.Rows(0).Item("producto"), dt1.Rows(0).Item("origen"), dt1.Rows(0).Item("destino"), dt1.Rows(0).Item("idpersona"), _
                                 dt1.Rows(0).Item("tipo_tarifa"), 3)
                Else
                    Me.FormatearDGVCantidad(Me.dgvRetiro13)
                    ListarArticulo(Comprobante, dt1.Rows(0).Item("idpersona"), dt1.Rows(0).Item("origen"), dt1.Rows(0).Item("destino"), Me.dgvRetiro13)
                End If
                If Me.lblProducto13.Tag = 10 Then
                    Me.btnAceptar.Enabled = False
                    Me.dgvRetiro13.Enabled = False
                End If
                tabOperacion.TabPages.Add(tabs13)
            Case 100
                ListarCiudad()
                dt1 = obj.ListarComprobante(Comprobante)
                Me.lblTotalActual10.Text = Format(dt1.Rows(0).Item("total"), "###,###,###0.00")
                Me.lblDescuento10.Text = Format(CType(dt1.Rows(0).Item("descuento"), Double), "0.00")
                Me.lblProducto10.Text = dt1.Rows(0).Item("nombre_producto")
                Me.lblProducto10.Tag = dt1.Rows(0).Item("producto")
                Me.lblOrigen10.Text = dt1.Rows(0).Item("nombre_origen") & "-" & dt1.Rows(0).Item("nombre_destino")
                Me.lblOrigen10.Tag = dt1.Rows(0).Item("origen")
                Me.cboDestino10.Tag = dt1.Rows(0).Item("nombre_destino")
                If dt1.Rows(0).Item("articulo") = 0 Then
                    FormatearDGVPeso10(Me.dgvPeso10)
                    ListarVenta(Comprobante, Me.dgvPeso10)
                Else
                    Me.FormatearDGVCantidad(Me.dgvPeso10)
                    ListarArticulo(Comprobante, dt1.Rows(0).Item("idpersona"), dt1.Rows(0).Item("origen"), dt1.Rows(0).Item("destino"), Me.dgvPeso10)
                End If
                tabOperacion.TabPages.Add(tabs10)
            Case 7, 8, 9, 10, 13
                Dim blnExito As Boolean = True
                Me.txtComprobante.Text = "" : Me.txtComprobante.Tag = Nothing
                ActivaDesactivaOperacion(True)

                LimpiarNuevoComprobante()
                dt1 = obj.ListarComprobante(Comprobante)
                If dt1.Rows.Count > 0 Then
                    Me.lblTotalActual.Text = Format(dt1.Rows(0).Item("total"), "###,###,###0.00")
                    If intOpcion = 7 Or intOpcion = 10 Or intOpcion = 13 Or intOpcion = 8 Then
                        Me.lblTotalNC.Text = Format(NC, "###,###,###0.00")
                    Else
                        Me.lblTotalNC.Text = Format(dt1.Rows(0).Item("total"), "###,###,###0.00")
                    End If
                    Me.btnAceptar.Enabled = False
                End If
                tabs7.Text = ObtieneTitulo(intOpcion)
                tabOperacion.TabPages.Add(tabs7)

                'valida si producto esta asociado a operacion
                Dim intTipoOperacion As Integer = Me.cboOperacion.SelectedValue
                If intTipoOperacion = 8 Then
                    If Not (dt1.Rows(0).Item("producto") = 10 Or dt1.Rows(0).Item("producto") = 81) Then
                        ActivaDesactivaOperacion(False)
                    End If
                ElseIf intTipoOperacion = 7 Then
                    If dt1.Rows(0).Item("producto") = 10 Or dt1.Rows(0).Item("producto") = 81 Then
                        ActivaDesactivaOperacion(False)
                    End If
                End If
                Me.txtComprobante.Focus()

            Case 88
                dt1 = obj.ListarComprobante(Comprobante)
                Me.lblCantidadTotalActual.Text = Format(dt1.Rows(0).Item("total"), "###,###,###0.00")
                Me.lblProducto8.Text = dt1.Rows(0).Item("nombre_producto")
                Me.lblProducto8.Tag = dt1.Rows(0).Item("producto")

                If CType(dt1.Rows(0).Item("articulo"), Integer) = 0 And Me.lblProducto8.Tag <> 81 Then
                    Me.btnAceptar.Enabled = False
                Else
                    With dt1.Rows(0)
                        Me.lblBase8.Text = "0.00" 'Format(CType(.Item("base"), Double), "0.00")
                        Me.lblEntrega8.Text = Format(CType(.Item("entrega"), Double), "0.00")
                        Me.lblSeguro8.Text = Format(CType(.Item("seguro"), Double), "0.00")
                        Me.lblDevolucionCargo8.Text = Format(CType(.Item("cargo"), Double), "0.00")
                        Me.lblDescuento8.Text = "0.00" 'Format(CType(.Item("descuento"), Double), "0.00")
                        Me.lblSobre8.Text = "0.00" 'Format(CType(.Item("sobre"), Double), "0.00")
                        If Me.lblProducto8.Tag = 81 Then
                            Me.dgvCantidad.Visible = False
                            Me.dgvPeso8.Visible = True
                            FormatearDGVPeso8(Me.dgvPeso8)
                            ListarVenta(Comprobante, Me.dgvPeso8)

                            Calcula(0, Me.lblProducto8.Tag, Me.dgvPeso8)
                            Calcula(1, Me.lblProducto8.Tag, Me.dgvPeso8)

                            Dim dblTotal As Double = ObtieneTotalPeso(Me.dgvPeso8, 4)
                            Me.lblCantidadTotal.Text = Format(dblTotal, "###,###,###0.00")
                        Else
                            Me.dgvCantidad.Visible = True
                            Me.dgvPeso8.Visible = False
                            Me.FormatearDGVCantidad(Me.dgvCantidad)
                            ListarArticulo(Comprobante, dt1.Rows(0).Item("idpersona"), dt1.Rows(0).Item("idorigen"), dt1.Rows(0).Item("iddestino"), Me.dgvCantidad)
                            Me.lblCantidadTotal.Text = Format(ObtieneTotalCantidad(dgvCantidad, 4), "###,###,###0.00")
                        End If
                    End With
                End If
                tabOperacion.TabPages.Add(tabs8)

            Case 11
                dt1 = obj.ListarComprobante(Comprobante)
                Me.lblDireccionActual.Text = dt1.Rows(0).Item("direccion_origen")
                Me.lblTotal11.Text = Format(dt1.Rows(0).Item("total"), "###,###,###0.00")
                tabOperacion.TabPages.Add(tabs11)
            Case 12
                dt1 = obj.ListarComprobante(Comprobante)
                Me.lblTotal12.Text = Format(dt1.Rows(0).Item("total"), "###,###,###0.00")
                Me.txtMonto.Text = Me.lblTotal12.Text

                Dim obj2 As New dtoVentaCargaContado
                Dim dt2 As DataTable
                dt2 = obj2.ListarPagoResumen(Comprobante)
                If dt2.Rows.Count > 0 Then
                    If dt2.Rows(0).Item("cortesia") = 1 Then 'Or dt2.Rows(0).Item("tarjeta") = 1 Then
                        Me.cboDevolucionDinero.Enabled = False
                        Me.txtMonto.Enabled = False
                    Else
                        Me.cboDevolucionDinero.Enabled = True
                        Me.txtMonto.Enabled = True
                    End If
                End If
                tabOperacion.TabPages.Add(tabs12)
                Me.btnAceptar.Focus()
            Case 133
                dt1 = obj.ListarComprobante(Comprobante)
            Case 14
                dt1 = obj.ListarComprobante(Comprobante)
                Me.lblTotal14.Text = Format(dt1.Rows(0).Item("total"), "###,###,###0.00")
                tabOperacion.TabPages.Add(tabs14)
                Dim intTipoComprobante As Integer = dtOperacion.Rows(Me.cboOperacion.SelectedIndex).Item("tipo_comprobante")
                If intTipoComprobante = 3 Or intTipoComprobante = TipoComprobante Then
                    Me.txtDescuento14.Enabled = True
                    Me.btnAceptar.Enabled = True
                    Me.txtDescuento14.Focus()
                Else
                    Me.txtDescuento14.Text = ""
                    Me.txtDescuento14.Enabled = False
                    Me.btnAceptar.Enabled = False
                End If
            Case 15
                tabOperacion.TabPages.Add(tabs15)
                FormatearDGVCargo()
                dt1 = obj.ListarComprobante(Comprobante)
                If dt1.Rows.Count > 0 Then
                    Dim dblMonto As Double = dtoVentaCargaContado.MontoDevolucionCargo(dt1.Rows(0).Item("producto").ToString, dt1.Rows(0).Item("idpersona").ToString)
                    Me.lblMontoDevolucionCargo.Text = Format(dblMonto, "###,####,###0.00")
                End If
            Case 16
                tabOperacion.TabPages.Add(tabs16)
                dt1 = obj.ListarComprobante(Comprobante)
                If dt1.Rows.Count > 0 Then
                    Dim dtTarifaServicio As DataTable = ObtieneTarifaServicio(dt1.Rows(0).Item("origen").ToString, dt1.Rows(0).Item("destino").ToString, dt1.Rows(0).Item("producto").ToString, 3, 3, 1, dt1.Rows(0).Item("idpersona").ToString)
                    Dim intProducto As Integer = dt1.Rows(0).Item("producto")
                    intProducto = IIf(intProducto = 10, 3, 100)
                    Dim dblPeso As Double = CType(dt1.Rows(0).Item("peso").ToString, Double)
                    'intProducto = 3
                    Dim dblMonto As Double = ObtieneMontoTarifaServicio(intProducto, dblPeso, dtTarifaServicio)
                    Me.lblMontoEntregaDomicilio.Text = Format(dblMonto, "###,####,###0.00")
                End If
        End Select
    End Sub

    Function ExisteCargo(serie As Integer, numero As Integer, Optional fila As Integer = -1) As Integer
        For Each row As DataGridViewRow In Me.dgvCargo.Rows
            If fila = -1 Then
                If serie = Convert.ToInt32(row.Cells("serie").Value) And numero = Convert.ToInt32(row.Cells("numero").Value) Then
                    Return 1
                End If
            Else
                If serie = Convert.ToInt32(row.Cells("serie").Value) And numero = Convert.ToInt32(row.Cells("numero").Value) Then
                    If fila = row.Index Then
                        Return 2
                    Else
                        Return 1
                    End If
                End If
            End If
        Next
        Return 0
    End Function

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Dim frm As New frmDevolucionCargoDetalle
        frm.ID = 0
        frm.Tipo = dt1.Rows(0).Item("tipo").ToString
        frm.Comprobante = dt1.Rows(0).Item("comprobante").ToString
        frm.IdTipo = dt1.Rows(0).Item("idtipo_comprobante").ToString
        frm.IdComprobante = dt1.Rows(0).Item("id").ToString
        frm.Serie = ""
        frm.Numero = ""
        frm.Cliente = dt1.Rows(0).Item("idpersona").ToString
        frm.Opcion = 1
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            If ExisteCargo(frm.txtSerie.Text.Trim, frm.txtNumero.Text.Trim) Then
                MessageBox.Show("El Cargo ya existe", "Devolución de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnNuevo.Focus()
                Return
            End If
            MostrarCargo(frm, 1)
        End If
    End Sub

    Sub MostrarCargo(frm As frmDevolucionCargoDetalle, opcion As Integer)
        With Me.dgvCargo
            Dim intFila As Integer
            If opcion = 1 Then
                .Rows.Add()
                intFila = .Rows.Count - 1
            Else
                intFila = .CurrentCell.RowIndex
            End If
            .Rows(intFila).Cells(0).Value = frm.txtSerie.Text.Trim
            .Rows(intFila).Cells(1).Value = frm.txtNumero.Text.Trim
            .Rows(intFila).Cells(2).Value = 0
            Me.btnModificar.Enabled = True
            Me.btnEliminar.Enabled = True
        End With
    End Sub

    Sub ListarCargo(fila As Integer)
        Dim intTipo As Integer, intComprobante As Integer

        intTipo = dt1.Rows(0).Item("idtipo_comprobante").ToString
        intComprobante = dt1.Rows(0).Item("id").ToString

        Dim obj As New Cls_DevolucionCargo_LN
        Me.dgvCargo.DataSource = obj.ListarCargo(intTipo, intComprobante)

        Me.btnModificar.Enabled = Me.dgvCargo.Rows.Count > 0
        Me.btnEliminar.Enabled = Me.dgvCargo.Rows.Count > 0
    End Sub

    Private Sub tabOperacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabOperacion.SelectedIndexChanged
        If tabOperacion.SelectedTab Is tabOperacion.TabPages("tabDevolucion") Then
            Me.cboDevolucionDinero.SelectedIndex = 1
        End If
        Return
        If tabOperacion.SelectedTab Is tabOperacion.TabPages("tabDevolucion") Then
            FormatearDGVCargo()
            Dim obj As New Cls_Autorizacion_LN
            dt1 = obj.ListarComprobante(Comprobante)
            If dt1.Rows.Count > 0 Then
                Dim dblMonto As Double = dtoVentaCargaContado.MontoDevolucionCargo(dt1.Rows(0).Item("producto").ToString, dt1.Rows(0).Item("idpersona").ToString)
                Me.lblMontoDevolucionCargo.Text = Format(dblMonto, "###,####,###0.00")
            End If
        ElseIf tabOperacion.SelectedTab Is tabOperacion.TabPages("tabEntrega") Then
            Dim obj As New Cls_Autorizacion_LN
            dt1 = obj.ListarComprobante(Comprobante)
            If dt1.Rows.Count > 0 Then
                Dim dtTarifaServicio As DataTable = ObtieneTarifaServicio(dt1.Rows(0).Item("origen").ToString, dt1.Rows(0).Item("destino").ToString, dt1.Rows(0).Item("producto").ToString, 3, 3, 1, dt1.Rows(0).Item("idpersona").ToString)
                Dim intProducto As Integer = dt1.Rows(0).Item("producto")
                intProducto = IIf(intProducto = 10, 3, 100)
                Dim dblPeso As Double = CType(dt1.Rows(0).Item("destino").ToString, Double)
                Dim dblMonto As Double = ObtieneMontoTarifaServicio(intProducto, dblPeso, dtTarifaServicio)
            End If
        End If
    End Sub

    Function ObtieneTarifaServicio(origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer, servicio As Integer, cliente As Integer) As DataTable
        Dim objTarifaLN As New Cls_TarifaServicio_LN
        Dim dt As DataTable = objTarifaLN.ObtenerTarifaServicio(origen, destino, producto, tipo_tarifa, tipo_visibilidad, servicio, cliente, 0)
        Return dt
    End Function

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        Dim frm As New frmDevolucionCargoDetalle
        frm.ID = 0
        frm.Tipo = dt1.Rows(0).Item("tipo").ToString
        frm.Comprobante = dt1.Rows(0).Item("comprobante").ToString
        frm.IdTipo = dt1.Rows(0).Item("idtipo_comprobante").ToString
        frm.IdComprobante = dt1.Rows(0).Item("id").ToString
        frm.Serie = Me.dgvCargo.CurrentRow.Cells("serie").Value
        frm.Numero = Me.dgvCargo.CurrentRow.Cells("numero").Value
        frm.Cliente = dt1.Rows(0).Item("idpersona").ToString

        frm.Opcion = 1
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim intCargo As Integer = ExisteCargo(frm.txtSerie.Text.Trim, frm.txtNumero.Text.Trim, Me.dgvCargo.CurrentCell.RowIndex)
            If intCargo = 1 Then
                MessageBox.Show("El Cargo ya existe", "Devolución de Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnModificar.Focus()
                Return
            End If
            MostrarCargo(frm, 2)
        End If
    End Sub

    Private Sub btnAnular_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está seguro de eliminar el Cargo?", "Devolución de Cargos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            With Me.dgvCargo
                If .Rows.Count > 0 Then
                    .Rows.Remove(Me.dgvCargo.CurrentRow)
                    If .Rows.Count = 0 Then
                        Me.btnEliminar.Enabled = False
                        Me.btnModificar.Enabled = False
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub dgvCargo_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvCargo.DoubleClick
        If Me.dgvCargo.Rows.Count > 0 Then
            Me.btnModificar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        'If Me.cboUsuario.Visible Then
        '    If Me.cboUsuario.SelectedValue = 0 Then
        '        MessageBox.Show("Seleccione Usuario", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        blnSalir = False
        '        Me.cboUsuario.Focus()
        '        Me.cboUsuario.DroppedDown = True
        '        Return
        '    End If
        'End If
        If tabOperacion.SelectedTab Is tabOperacion.TabPages("tab6") Then
            If Me.txtRazonSocial6.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese nueva Razón Social", "Razón Social Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtRazonSocial6.Text = Me.txtRazonSocial6.Text.Trim
                blnSalir = False
                Me.txtRazonSocial6.Focus()
                Return
            End If
            If Me.txtRazonSocial6.Text.Trim = Me.lblRazonSocialActual.Text.Trim Then
                MessageBox.Show("Ingrese nueva Razón Social", "Razón Social Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtRazonSocial6.Text = Me.txtRazonSocial6.Text.Trim
                blnSalir = False
                Me.txtRazonSocial6.Focus()
                Return
            End If
        ElseIf tabOperacion.SelectedTab Is tabOperacion.TabPages("tab7") Then
            If Nuevo Then
                'hlamas 21-02-2018
                Dim frm As New frmDevolucionDinero
                frm.Total = CType(Me.lblTotalActual.Text, Double)
                frm.Monto = CType(Me.lblTotalActual.Text, Double) - CType(Me.lblTotalNuevoComprobante.Text, Double)
                frm.MontoNuevo = CType(Me.lblTotalNuevoComprobante.Text, Double)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    blnSalir = False
                    Me.btnAceptar.Focus()
                    Return
                End If
                Me.lblTotalNC.Text = Format(CType(frm.lblMonto.Text, Double), "###,###,###0.00")
            End If

        ElseIf tabOperacion.SelectedTab Is tabOperacion.TabPages("tab8") Then
            If Me.lblProducto8.Tag <> 81 Then
                If ObtieneSumaGrid(Me.dgvCantidad, 4) <= 0 Or CType(Me.lblCantidadTotal.Text, Integer) <= 0 Then
                    MessageBox.Show("Ingrese Cantidad", "Cambio Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    blnSalir = False
                    Me.dgvCantidad.Focus()
                    Return
                End If
            End If
            If CType(Me.lblCantidadTotal.Text, Double) >= CType(Me.lblCantidadTotalActual.Text, Double) Then
                MessageBox.Show("El nuevo Total " & Me.lblCantidadTotal.Text & " debe ser menor al Total " & Me.lblCantidadTotalActual.Text, "Cambio Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Information)
                blnSalir = False
                Me.dgvCantidad.Focus()
                Return
            End If
        ElseIf tabOperacion.SelectedTab Is tabOperacion.TabPages("tab10") Then
            If Me.cboDestino10.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Ciudad Destino", "Cambio Destino", MessageBoxButtons.OK, MessageBoxIcon.Information)
                blnSalir = False
                Me.cboDestino10.Focus()
                Me.cboDestino10.DroppedDown = True
                Return
            End If
            If Me.cboDestino10.Text = Me.cboDestino10.Tag Then
                MessageBox.Show("La Ciudad destino " & Me.cboDestino10.Text & " debe ser diferente a " & Me.cboDestino10.Tag, "Cambio Destino", MessageBoxButtons.OK, MessageBoxIcon.Information)
                blnSalir = False
                Me.cboDestino10.Focus()
                Me.cboDestino10.DroppedDown = True
                Return
            End If
            If CType(Me.lblTotal10.Text, Double) >= CType(Me.lblTotalActual10.Text, Double) Then
                MessageBox.Show("El nuevo Total " & Me.lblTotal10.Text & " debe ser menor al Total " & Me.lblTotalActual10.Text, "Cambio Destino", MessageBoxButtons.OK, MessageBoxIcon.Information)
                blnSalir = False
                Me.cboDestino10.Focus()
                Return
            End If

            If Nuevo Then
                'hlamas 21-02-2018
                Dim frm As New frmDevolucionDinero
                frm.Total = CType(Me.lblTotalActual10.Text, Double)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    blnSalir = False
                    Me.btnAceptar.Focus()
                    Return
                End If
                Me.lblDescuento10.Text = Format(CType(frm.txtMonto.Text, Double), "###,###,###0.00")
            End If

        ElseIf tabOperacion.SelectedTab Is tabOperacion.TabPages("tab11") Then
            If Me.txtDir11.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Dirección", "Dirección Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                blnSalir = False
                Me.btnDireccion11.Focus()
                Return
            End If
            ElseIf tabOperacion.SelectedTab Is tabOperacion.TabPages("tab12") Then
                If Me.cboDevolucionDinero.SelectedIndex = 0 Then
                    MessageBox.Show("Seleccione si se devuelve o no dinero al cliente", "Retiro Total de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboDevolucionDinero.Focus()
                    Me.cboDevolucionDinero.DroppedDown = True
                    blnSalir = False
                    Return
                End If

                Dim dlgRespuesta As DialogResult
                Dim strMensaje As String
                Dim dblCtaCte As Double = CType(Me.lblTotal12.Text, Double) - CType(Me.txtMonto.Text, Double)
                strMensaje = "Se realizará lo siguiente:" & Chr(13) & Chr(13) & "Devolución de dinero : " & Me.txtMonto.Text & Chr(13) & _
                    "Cuenta corriente : " & dblCtaCte.ToString("0.00") & Chr(13) & Chr(13) & _
                    "¿Está seguro de continuar?"
                dlgRespuesta = MessageBox.Show(strMensaje, "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If dlgRespuesta = Windows.Forms.DialogResult.No Then
                    blnSalir = False
                End If

                If Me.cboDevolucionDinero.SelectedIndex = 1 Then 'devolucion de dinero
                    If Not (CType(Me.txtMonto.Text, Double) >= 1 And CType(Me.txtMonto.Text, Double) <= CType(Me.lblTotal12.Text, Double)) Then
                        MessageBox.Show("El monto a devolver debe estar entre 1.00 y " & Me.lblTotal12.Text, "Retiro Total de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtMonto.Focus()
                        blnSalir = False
                        Return
                    End If
                End If
            ElseIf tabOperacion.SelectedTab Is tabOperacion.TabPages("tab14") Then
                If Not (Val(Me.txtDescuento14.Text) > 0 And Val(Me.txtDescuento14.Text) <= 99) Then
                    MessageBox.Show("El % de Descuento debe estar entre 1 y 99", "Descuento Global", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    blnSalir = False
                    Me.txtDescuento14.Focus()
                    Return
                End If
            ElseIf tabOperacion.SelectedTab Is tabOperacion.TabPages("tab15") Then
                If Me.chkCargo.Checked Then
                    If Me.dgvCargo.Rows.Count = 0 Then
                        MessageBox.Show("Ingrese Cargos del Cliente", "Devolución de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        blnSalir = False
                        Me.btnNuevo.Focus()
                        Return
                    End If
                Else
                    If Me.txtMotivo.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingrese Motivo", "Devolución de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        blnSalir = False
                        Me.txtMotivo.Text = ""
                        Me.txtMotivo.Focus()
                        Return
                    End If
                End If
                If CType(Me.lblMontoDevolucionCargo.Text, Double) <= 0 Then
                    MessageBox.Show("El Monto debe ser mayor a 0", "Devolución de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    blnSalir = False
                    Me.btnAceptar.Focus()
                    Return
                End If
            ElseIf tabOperacion.SelectedTab Is tabOperacion.TabPages("tab16") Then
                If Me.txtdir16.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Dirección", "Entrega a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    blnSalir = False
                    Me.btnDireccion16.Focus()
                    Return
                End If
                If Me.txtNombres.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Consignado", "Entrega a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    blnSalir = False
                    Me.btnConsignado.Focus()
                    Return
                End If
            'If CType(Me.lblMontoEntregaDomicilio.Text, Double) <= 0 Then
            '    MessageBox.Show("El Monto debe ser mayor a 0", "Entrega a Domicilio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    blnSalir = False
            '    Me.btnAceptar.Focus()
            '    Return
            'End If
            End If
    End Sub

    Private Sub chkCargo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCargo.CheckedChanged
        If Me.chkCargo.Checked Then
            Me.btnNuevo.Enabled = True

            Me.txtMotivo.Text = ""
            Me.txtMotivo.Enabled = False
        Else
            Me.dgvCargo.Rows.Clear()
            FormatearDGVCargo()
            Me.btnNuevo.Enabled = False
            Me.btnModificar.Enabled = False
            Me.btnEliminar.Enabled = False

            Me.txtMotivo.Enabled = True
            Me.txtMotivo.Focus()
        End If
    End Sub

    Private Sub txtMotivo_Enter(sender As Object, e As System.EventArgs) Handles txtMotivo.Enter
        Me.txtMotivo.SelectAll()
    End Sub

    Private Sub BtnDireccion_Click(sender As System.Object, e As System.EventArgs) Handles btnDireccion16.Click
        Me.Cursor = Cursors.AppStarting
        Me.CargarDireccion(16)
        Me.Cursor = Cursors.Default
    End Sub

    Sub CargarDireccion(operacion As Integer)
        Dim obj As New dtrecojo
        Dim frm As New FrmDireccion
        Dim nro As String

        frm.bNuevo = True
        Dim direccion, ref As String
        If operacion = 16 Then
            direccion = Me.txtdir16.Text
            ref = Me.txtref16.Text

            frm.nrodocumento = nro
            'frm.TxtDireccion.Text = direccion
            frm.TxtReferencia.Text = ref

            frm.departamento = Me.txtdepar16.Tag
            frm.provincia = Me.txtpro16.Tag
            frm.distrito = Me.txtdist16.Tag

            If txtdepar16.Tag = 0 Or txtpro16.Tag = 0 Or txtdist16.Tag = 0 Then
                frm.pais = 4
                frm.nomdepa = 15
                frm.nomprov = 17
                frm.nomdist = 2
            Else
                frm.pais = 4
                frm.nomdepa = txtdepar16.Tag
                frm.nomprov = txtpro16.Tag
                frm.nomdist = txtdist16.Tag 'Pasando TipoComunicacion
            End If
        ElseIf operacion = 11 Then
            direccion = Me.txtDir11.Text
            ref = Me.txtRef11.Text

            frm.nrodocumento = nro
            'frm.TxtDireccion.Text = direccion
            frm.TxtReferencia.Text = ref

            frm.departamento = Me.txtDepar11.Tag
            frm.provincia = Me.txtPro11.Tag
            frm.distrito = Me.txtDist11.Tag

            If txtDepar11.Tag = 0 Or txtPro11.Tag = 0 Or txtDist11.Tag = 0 Then
                frm.pais = 4
                frm.nomdepa = 15
                frm.nomprov = 17
                frm.nomdist = 2
            Else
                frm.pais = 4
                frm.nomdepa = txtDepar11.Tag
                frm.nomprov = txtPro11.Tag
                frm.nomdist = txtDist11.Tag 'Pasando TipoComunicacion
            End If
        End If
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            If operacion = 11 Then
                Me.txtDir11.Text = frm.strDireccion
                Me.txtRef11.Text = frm.TxtReferencia.Text
                Me.txtDepar11.Text = frm.CboDepartamento.Text
                Me.txtPro11.Text = frm.CboProvincia.Text
                Me.txtDist11.Text = frm.CboDistrito.Text
                Me.txtDepar11.Tag = frm.CboDepartamento.SelectedValue
                Me.txtPro11.Tag = frm.CboProvincia.SelectedValue
                Me.txtDist11.Tag = frm.CboDistrito.SelectedValue
            ElseIf operacion = 16 Then
                Me.txtdir16.Text = frm.strDireccion
                Me.txtref16.Text = frm.TxtReferencia.Text
                Me.txtdepar16.Text = frm.CboDepartamento.Text
                Me.txtpro16.Text = frm.CboProvincia.Text
                Me.txtdist16.Text = frm.CboDistrito.Text
                Me.txtdepar16.Tag = frm.CboDepartamento.SelectedValue
                Me.txtpro16.Tag = frm.CboProvincia.SelectedValue
                Me.txtdist16.Tag = frm.CboDistrito.SelectedValue
            End If
            'departamento = frm.CboDepartamento.SelectedValue
            'provincia = frm.CboProvincia.SelectedValue
            'distrito = frm.CboDistrito.SelectedValue
        End If
    End Sub

    Sub MostrarConsignado(frm As FrmConsignadoNuevo)
        With frm
            Me.txtTipoDocumento.Text = frm.CboTipoDocumento.Text
            Me.txtTipoDocumento.Tag = frm.CboTipoDocumento.SelectedValue
            Me.txtNumeroDocumento.Text = frm.TxtNumero.Text
            Me.txtNombres.Text = frm.TxtConsignado.Text.Trim

            If frm.CboTipoDocumento.SelectedValue = 1 Then
                Me.txtApellidoPaterno.Text = ""
                Me.txtApellidoMaterno.Text = ""
                Me.txtApellidoPaterno.Visible = False
                Me.txtApellidoMaterno.Visible = False
                Me.lblAP.Visible = False
                Me.lblAm.Visible = False
                Me.lblNombres.Text = "Ruc"
            Else
                Me.txtApellidoPaterno.Text = frm.txtapePConsig.Text.Trim
                Me.txtApellidoMaterno.Text = frm.txtapeMConsig.Text.Trim
                Me.txtApellidoPaterno.Visible = True
                Me.txtApellidoMaterno.Visible = True
                Me.lblAP.Visible = True
                Me.lblAm.Visible = True
                Me.lblNombres.Text = "Nombres"
            End If
        End With
    End Sub

    Private Sub btnConsignado_Click(sender As System.Object, e As System.EventArgs) Handles btnConsignado.Click
        Dim frm As New FrmConsignadoNuevo
        'frm.IDComprobante = dt1.Rows(0).Item("id").ToString
        'frm.IDTipoComprobante = dt1.Rows(0).Item("idtipo_comprobante").ToString
        frm.TxtNumero.Text = Me.txtNumeroDocumento.Text.Trim
        frm.TxtConsignado.Text = Me.txtNombres.Text.Trim
        frm.txtapePConsig.Text = Me.txtApellidoPaterno.Text.Trim
        frm.txtapeMConsig.Text = Me.txtApellidoMaterno.Text.Trim
        frm.IDTipoDocumento = Me.txtTipoDocumento.Tag
        frm.Opcion = 1
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            MostrarConsignado(frm)
        End If
    End Sub

    Sub Cargar(lista As ArrayList, operacion As Integer, tipo As Integer)
        aLista = lista
        intOperacion = operacion
        intTipoOperacion = tipo
    End Sub

    Sub ObtieneCargos(cadena As String, dgv As DataGridView)
        Dim s As String = "", c As Char, intContador As Integer = 0, intFila As Integer, intPosicion As Integer
        Dim strSerie As String, strNumero As String
        For i As Integer = 0 To cadena.Length - 1
            c = cadena.Substring(i, 1)
            s = s & c
            If c = "," Then
                intContador = intContador + 1
                intPosicion = s.IndexOf("-")
                strSerie = s.Substring(0, intPosicion)
                strNumero = s.Substring(intPosicion + 1)
                If strNumero.IndexOf(",") Then strNumero = strNumero.Substring(0, strNumero.Length - 1)
                s = ""
                With dgv
                    If intContador = 1 Then
                        dgv.Rows.Clear()
                    End If
                    dgv.Rows.Add()
                    intFila = dgv.Rows.Count - 1
                    dgv.Rows(intFila).Cells(0).Value = strSerie
                    dgv.Rows(intFila).Cells(1).Value = strNumero
                    dgv.Rows(intFila).Cells(2).Value = 1
                End With
            End If
        Next
    End Sub

    Sub ActualizaCantidad(lista As ArrayList, dgv As DataGridView)
        Dim item As Object
        Dim s As String = "", c As Char, intContador As Integer = -1, intFila As Integer = 0, intPosicion As Integer, intRegistro As Integer = 0
        Dim cadena As String, intReg As Integer = 0

        dgv.DataSource = Nothing
        FormatearDGVCantidad(Me.dgvCantidad)
        For Each item In lista
            cadena = item.texto
            intRegistro = InStr(cadena, ",")
            intReg = 0
            If intRegistro > 0 Then
                intContador += 1
                For i As Integer = 0 To cadena.Length - 1
                    c = cadena.Substring(i, 1)
                    s = s & c
                    If c = "," Then
                        If intFila = 0 Then
                            dgv.Rows.Add()
                        End If
                        'intFila = dgv.Rows.Count - 1
                        s = s.Substring(0, s.Trim.Length - 1)
                        dgv.Rows(intReg).Cells(intContador).Value = s
                        If intContador >= 3 Then
                            dgv.Rows(intReg).Cells(intContador).Value = Format(CType(dgv.Rows(intReg).Cells(intContador).Value, Double), "0.00")
                        End If
                        intReg += 1
                        s = ""
                    End If
                Next
                intFila = 1
            End If
        Next
    End Sub

    Sub ActualizaPeso(lista As ArrayList, dgv As DataGridView, producto As Integer)
        Dim item As Object
        Dim s As String = "", c As Char, intContador As Integer = -1, intRegistro As Integer = 0
        Dim cadena As String, intReg As Integer = 0

        For Each item In lista
            cadena = item.texto
            intRegistro = InStr(cadena, ",")
            intReg = 0
            If intRegistro > 0 Then
                intContador += 1
                For i As Integer = 0 To cadena.Length - 1
                    c = cadena.Substring(i, 1)
                    s = s & c
                    If c = "," Then
                        s = s.Substring(0, s.Trim.Length - 1)
                        If intContador = 0 Then
                            If producto <> 81 Then
                                dgv.Rows(intReg).Cells("peso").Value = Format(CType(s, Double), "0.00")
                            Else
                                dgv.Rows(intReg).Cells("bulto").Value = Format(CType(s, Integer), "0")
                            End If
                        Else
                            dgv.Rows(intReg).Cells("subtotal").Value = Format(CType(s, Double), "0.00")
                        End If
                        intReg += 1
                        s = ""
                    End If
                Next
                If producto <> 81 Then
                    'Calcula(0, Me.lblProducto7.Tag, Me.dgvPeso7)
                    'Calcula(1, Me.lblProducto7.Tag, Me.dgvPeso7)
                    Dim dblTotal As Double = ObtieneTotalPeso(Me.dgvNuevoComprobante, 4)
                    Me.lblTotalNuevoComprobante.Text = Format(dblTotal, "###,###,###0.00")
                Else
                    Calcula(0, Me.lblProducto8.Tag, Me.dgvPeso8)
                    Calcula(1, Me.lblProducto8.Tag, Me.dgvPeso8)
                    Dim dblTotal As Double = ObtieneTotalPeso(Me.dgvPeso8, 4)
                    Me.lblCantidadTotal.Text = Format(dblTotal, "###,###,###0.00")
                End If
            End If
        Next
    End Sub

    Sub ListarUsuario()
        'Dim obj As New Cls_Autorizacion_LN
        'With Me.cboUsuario
        '    .DisplayMember = "descripcion"
        '    .ValueMember = "id"
        '    .DataSource = obj.ListarUsuario(dtoUSUARIOS.m_idciudad, dtoUSUARIOS.iIDAGENCIAS)
        '    .SelectedValue = intUsuario
        'End With
    End Sub

    Private Sub frmDatosFactura_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        inicio()
        ListarOperacion()
        'If TipoOperacion = 2 Then
        '    ListarUsuario()
        '    Me.lblUsuario.Visible = True
        '    Me.cboUsuario.Visible = True
        'Else
        '    intUsuario = 0
        '    Me.lblUsuario.Visible = False
        '    Me.cboUsuario.Visible = False
        'End If
        If aLista.Count > 0 Then
            Me.cboOperacion.SelectedValue = intOperacion
            MostrarDatos()
            Me.btnModificar.Enabled = Me.chkCargo.Checked
            Me.btnEliminar.Enabled = Me.chkCargo.Checked
        End If

        If Not Me.tabOperacion.Enabled Then
            Me.btnAceptar.Enabled = False
        End If

        If intOpcion = 1 Then
            Me.tabOperacion.Enabled = True
            Me.txtComprobante.Enabled = False
            Me.btnAceptar.Enabled = False
        End If
    End Sub

    Sub MostrarDatos()
        If intOperacion = 77 Then
            'ActualizaPeso(aLista, Me.dgvPeso7, Me.lblProducto7.Tag)
        ElseIf intOperacion = 88 Then
            If Me.lblProducto8.Tag <> 81 Then
                ActualizaCantidad(aLista, Me.dgvCantidad)
            Else
                ActualizaPeso(aLista, Me.dgvPeso8, Me.lblProducto8.Tag)
            End If
        Else
            Me.FormatearDGVCargo()
            Dim item As Object
            Dim i As Integer = 0
            For Each item In aLista
                If item.operacion = intOperacion Then
                    i += 1
                    If intOperacion = 12 Then
                        Select Case i
                            Case 1 : Me.lblTotal12.Text = item.texto 'Format(CType(item.texto, Double), "###,###,###0.00")
                            Case 2 : Me.cboDevolucionDinero.SelectedIndex = item.texto
                            Case 3 : Me.txtMonto.Text = item.texto
                        End Select
                    ElseIf intOperacion = 14 Then
                        Select Case i
                            Case 1 : Me.lblMonto14.Text = item.texto
                            Case 2 : Me.txtDescuento14.Text = item.texto
                        End Select
                    ElseIf intOperacion = 15 Then
                        Select Case i
                            Case 1 : Me.lblMontoDevolucionCargo.Text = item.texto
                            Case 2 : Me.chkCargo.Checked = IIf(item.texto = 1, True, False)
                            Case 3
                                If Me.chkCargo.Checked Then
                                    ObtieneCargos(item.texto, Me.dgvCargo)
                                Else
                                    Me.txtMotivo.Text = item.texto
                                End If
                        End Select
                    ElseIf intOperacion = 16 Then
                        Select Case i
                            Case 1 : Me.lblMontoEntregaDomicilio.Text = item.texto
                            Case 2 : Me.txtdir16.Text = item.texto
                            Case 3 : Me.txtref16.Text = item.texto
                            Case 4
                                Me.txtdepar16.Text = item.texto
                                Me.txtdepar16.Tag = item.id
                            Case 5
                                Me.txtpro16.Text = item.texto
                                Me.txtpro16.Tag = item.id
                            Case 6
                                Me.txtdist16.Text = item.texto
                                Me.txtdist16.Tag = item.id
                            Case 7
                                Me.txtTipoDocumento.Text = item.texto
                                Me.txtTipoDocumento.Tag = item.id
                            Case 8 : Me.txtNumeroDocumento.Text = item.texto
                            Case 9 : Me.txtNombres.Text = item.texto
                            Case 10 : Me.txtApellidoPaterno.Text = item.texto
                            Case 11 : Me.txtApellidoMaterno.Text = item.texto
                        End Select
                        If Me.txtTipoDocumento.Tag = 1 Then
                            Me.txtApellidoPaterno.Visible = False
                            Me.txtApellidoMaterno.Visible = False
                            Me.lblAP.Visible = False
                            Me.lblAm.Visible = False
                            Me.lblNombres.Text = "Ruc"
                        Else
                            Me.txtApellidoPaterno.Visible = True
                            Me.txtApellidoMaterno.Visible = True
                            Me.lblAP.Visible = True
                            Me.lblAm.Visible = True
                            Me.lblNombres.Text = "Nombres"
                        End If
                    ElseIf intOperacion = 11 Then
                        Select Case i
                            Case 1 : Me.lblDireccionActual.Text = item.texto
                            Case 2 : Me.txtDir11.Text = item.texto
                            Case 3 : Me.txtRef11.Text = item.texto
                            Case 4
                                Me.txtDepar11.Text = item.texto
                                Me.txtDepar11.Tag = item.id
                            Case 5
                                Me.txtPro11.Text = item.texto
                                Me.txtPro11.Tag = item.id
                            Case 6
                                Me.txtDist11.Text = item.texto
                                Me.txtDist11.Tag = item.id
                        End Select
                    ElseIf intOperacion = 6 Then
                        Select Case i
                            Case 1
                                Me.lblRazonSocialActual.Text = item.texto
                                Me.lblRazonSocialActual.Tag = item.id
                            Case 2 : Me.txtRazonSocial6.Text = item.texto
                        End Select
                    ElseIf intOperacion = 7 Or intOperacion = 8 Or intOperacion = 10 Or intOperacion = 13 Then
                        Select Case i
                            Case 4
                                Me.txtComprobante.Text = item.texto
                                Me.txtComprobante.Tag = item.id
                                Dim e As New KeyPressEventArgs(Chr(13))
                                Me.txtComprobante_KeyPress(Nothing, e)
                        End Select
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub btnDireccion11_Click(sender As System.Object, e As System.EventArgs) Handles btnDireccion11.Click
        Me.Cursor = Cursors.AppStarting
        Me.CargarDireccion(11)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtRazonSocial6_Enter(sender As Object, e As System.EventArgs) Handles txtRazonSocial6.Enter
        Me.txtRazonSocial6.SelectAll()
    End Sub

    Private Sub txtRazonSocial6_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazonSocial6.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAceptar.Focus()
        End If
    End Sub

    Private Sub dgvArticulo_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvCantidad.CellBeginEdit
        'strValor = dgvArticulo.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
    End Sub

    Private Sub dgvArticulo_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCantidad.CellEndEdit
        With Me.dgvCantidad
            Dim intCantidad As Integer, dblPrecio As Double, dblSubtotal As Double, dblTotal As Double
            Dim dblBase As Double, dblSobre As Double, dblSeguro As Double, dblDevolucion As Double, dblEntrega As Double, dblDescuento As Double

            intCantidad = .CurrentCell.Value
            dblPrecio = dgvCantidad.CurrentRow.Cells("precio").Value
            dblSubtotal = intCantidad * dblPrecio
            dgvCantidad.CurrentRow.Cells("subtotal").Value = Format(dblSubtotal, "0.00")

            'dblSeguro = CType(Me.lblSeguro8.Text, Double)
            'dblDevolucion = CType(Me.lblDevolucionCargo8.Text, Double)
            'dblEntrega = CType(Me.lblEntrega8.Text, Double)

            dblTotal = ObtieneTotalCantidad(Me.dgvCantidad, 4) 'dblSubtotal + dblSeguro + dblDevolucion + dblEntrega
            Me.lblCantidadTotal.Text = Format(dblTotal, "0.00")
        End With
    End Sub

    Private Sub dgvCantidad_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvCantidad.CurrentCellDirtyStateChanged
        dgvCantidad.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgvArticulo_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvCantidad.EditingControlShowing
        'celda = TryCast(e.Control, DataGridViewTextBoxEditingControl)
    End Sub

    Private Sub dgvArticulo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dgvCantidad.KeyPress
        'e.Handled = Numero(e, celda)
    End Sub

    Function ObtieneTotalCantidad(dgv As DataGridView, columna As Integer) As Integer
        Dim dblSeguro As Double, dblDevolucion As Double, dblEntrega As Double
        Dim suma As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            suma += row.Cells(columna).Value
        Next

        dblSeguro = CType(Me.lblSeguro8.Text, Double)
        dblDevolucion = CType(Me.lblDevolucionCargo8.Text, Double)
        dblEntrega = CType(Me.lblEntrega8.Text, Double)

        Return suma + dblSeguro + dblDevolucion + dblEntrega
    End Function

    Private Sub dgvCantidad_CellValidated(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCantidad.CellValidated
        Me.lblCantidadTotal.Text = Format(ObtieneTotalCantidad(dgvCantidad, 4), "###,###,###0.00")
    End Sub

    Private Sub txtDescuento14_Enter(sender As Object, e As System.EventArgs) Handles txtDescuento14.Enter
        Me.txtDescuento14.SelectAll()
    End Sub

    Private Sub txtDescuento14_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuento14.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAceptar.Focus()
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtDescuento14.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescuento14_LostFocus(sender As Object, e As System.EventArgs) Handles txtDescuento14.LostFocus
        If Val(Me.txtDescuento14.Text) > 0 Then
            Me.txtDescuento14.Text = Format(CType(Me.txtDescuento14.Text, Double), "0.00")
        Else
            Me.txtDescuento14.Text = ""
        End If
    End Sub

    Private Sub txtDescuento14_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescuento14.TextChanged
        Dim dblTotal As Double, dblNuevoTotal As Double, dblDescuento As Double

        dblTotal = CType(Me.lblTotal14.Text, Double)
        If Val(Me.txtDescuento14.Text) > 0 Then
            dblDescuento = CType(Me.txtDescuento14.Text, Double)
        Else
            dblDescuento = 0
        End If
        dblNuevoTotal = dblTotal * (dblDescuento / 100)
        Me.lblMonto14.Text = Format(dblNuevoTotal, "###,###,###0.00")
    End Sub

    Function ObtieneSumaGrid(dgv As DataGridView, columna As Integer) As Double
        Dim dblSeguro As Double, dblDevolucion As Double, dblEntrega As Double
        Dim suma As Double = 0
        For Each row As DataGridViewRow In dgv.Rows
            suma += row.Cells(columna).Value
        Next
        Return suma
    End Function

    Sub ListarTarifa(producto As Integer, origen As Integer, destino As Integer, cliente As Integer, tipo_tarifa As Integer, _
                     tipo_visibilidad As Integer, Optional tipo_entrega As Integer = 0)
        Dim obj As New Cls_Autorizacion_LN
        dtTarifa = obj.ListarTarifa(producto, origen, destino, cliente, tipo_tarifa, tipo_visibilidad, tipo_entrega)
    End Sub

    Sub ListarVenta(id As Integer, dgv As DataGridView)
        Try
            With dgv
                Dim obj As New Cls_Autorizacion_LN
                Dim dt As DataTable = obj.ListarVenta(id)

                Dim row0 As String() = {"PESO", "0", "0.00", "0.00", "0.00"}
                .Rows().Add(row0)
                Dim row1 As String() = {"VOLUMEN", "0", "0.00", "0.00", "0.00"}
                .Rows().Add(row1)
                Dim row2 As String() = {"SOBRE", "0", "0.00", "0.00", "0.00"}
                .Rows().Add(row2)
                Dim row3 As String() = {"BASE", "0", "0.00", "0.00", "0.00"}
                .Rows().Add(row3)

                Dim dblMonto As Double
                If dt.Rows(0).Item("precio_peso") > 0 Then
                    .Rows(0).Cells(1).Value = dt.Rows(0).Item("cantidad_peso")
                    .Rows(0).Cells(2).Value = dt.Rows(0).Item("total_peso")
                    .Rows(0).Cells(3).Value = dt.Rows(0).Item("precio_peso")
                    dblMonto = CType(dt.Rows(0).Item("total_peso"), Double) * CType(dt.Rows(0).Item("precio_peso"), Double)
                    .Rows(0).Cells(4).Value = dblMonto
                End If
                If dt.Rows(0).Item("precio_volumen") > 0 Then
                    .Rows(1).Cells(1).Value = dt.Rows(0).Item("cantidad_volumen")
                    .Rows(1).Cells(2).Value = dt.Rows(0).Item("total_volumen")
                    .Rows(1).Cells(3).Value = dt.Rows(0).Item("precio_volumen")
                    dblMonto = CType(dt.Rows(0).Item("total_volumen"), Double) * CType(dt.Rows(0).Item("precio_volumen"), Double)
                    .Rows(1).Cells(4).Value = dblMonto
                End If
                If dt.Rows(0).Item("cantidad_sobre") > 0 Then
                    .Rows(2).Cells(1).Value = dt.Rows(0).Item("cantidad_sobre")
                    .Rows(2).Cells(3).Value = dt.Rows(0).Item("precio_sobre")
                    dblMonto = CType(dt.Rows(0).Item("cantidad_sobre"), Double) * CType(dt.Rows(0).Item("precio_sobre"), Double)
                    .Rows(2).Cells(4).Value = dblMonto
                End If
                If dt.Rows(0).Item("monto_base") > 0 Then
                    .Rows(3).Cells(4).Value = dt.Rows(0).Item("monto_base")
                End If

                dblMonto = CType(dt.Rows(0).Item("entrega"), Double)
                If dblMonto > 0 Then
                    Dim row4 As String() = {"ENTREGA", "0", "0.00", "0.00", Format(dblMonto, "0.00")}
                    .Rows().Add(row4)
                End If
                dblMonto = CType(dt.Rows(0).Item("devolucion"), Double)
                If dblMonto > 0 Then
                    Dim row4 As String() = {"DEV CARGO", "0", "0.00", "0.00", Format(dblMonto, "0.00")}
                    .Rows().Add(row4)
                End If
                dblMonto = CType(dt.Rows(0).Item("seguro"), Double)
                If dblMonto > 0 Then
                    Dim row4 As String() = {"SEGURO", "0", "0.00", "0.00", Format(dblMonto, "0.00")}
                    .Rows().Add(row4)
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ObtieneTotalPeso(dgv As DataGridView, columna As Integer)
        Dim dblSuma As Double = ObtieneSumaGrid(dgv, columna)
        Dim dblDescuento As Double = 0 'CType(Me.lblDescuento7.Text, Double) * -1

        If dblDescuento <> 0 Then
            dblSuma = dblSuma * (1 + (dblDescuento / 100))
        End If

        Return dblSuma
    End Function

    Private Sub fnCalcularCondicionTarifa(ByVal row As Integer, ByVal Peso_Volumen As Double, ByVal Costo As Double, PesoMaximo As Double, FleteMaximo As Double, dgv As DataGridView, Optional opcion As Integer = 0)
        If row = 0 Or row = 1 Then
            If Peso_Volumen >= 0.01 And Peso_Volumen <= PesoMaximo And Costo > 0 Then
                dgv("Subtotal", row).Value = FleteMaximo
            ElseIf Peso_Volumen > PesoMaximo And Costo > 0 Then
                Dim Calculo As Double = (Peso_Volumen - PesoMaximo) * (Costo)
                Dim SubNeto As Double = (Calculo + FleteMaximo)
                dgv("Subtotal", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
            ElseIf Peso_Volumen < 0.01 Then
                dgv("Subtotal", row).Value = "0.00"
            End If
        End If
    End Sub

    Sub Calcula(fila As Integer, producto As Integer, dgv As DataGridView)
        If producto = -1 Then 'articulo
            Dim intCantidad As Integer, dblPeso As Double, dblPrecio As Double, dblValor As Double
            With dgv
                intCantidad = Val(.Rows(fila).Cells("cantidad").Value)
                dblPrecio = CType(.Rows(fila).Cells("precio").Value, Double)
                dblValor = intCantidad * dblPrecio
                .Rows(fila).Cells(4).Value = Format(dblValor, "0.00")
            End With
        ElseIf producto <> 8 Then
            Dim intCantidad As Integer, dblPeso As Double, dblPrecio As Double, dblValor As Double
            With dgv
                If fila < 2 Then
                    intCantidad = Val(.Rows(fila).Cells("bulto").Value)
                    dblPeso = CType(.Rows(fila).Cells("peso").Value, Double)
                    dblPrecio = CType(.Rows(fila).Cells("costo").Value, Double)
                    If producto <> 81 Then
                        dblValor = dblPeso * dblPrecio
                    Else
                        dblValor = intCantidad * dblPrecio
                    End If
                ElseIf producto = 10 Then
                    intCantidad = Val(.Rows(fila).Cells("bulto").Value)
                    dblPrecio = CType(.Rows(fila).Cells("costo").Value, Double)
                    dblValor = intCantidad * dblPrecio
                End If
                .Rows(fila).Cells(4).Value = Format(dblValor, "0.00")
            End With
        Else
            Dim dblPeso As Double, dblVolumen As Double, dblPrecioPeso As Double, dblPrecioVolumen As Double, dblSubNetoPeso As Double
            Dim dblPesoMinimo As Double, dblVolumenMinimo As Double, dblFleteMinimoPeso As Double, dblFleteMinimoVolumen As Double
            If dtTarifa.Rows.Count > 0 Then
                dblPesoMinimo = CType(dtTarifa.Rows(0).Item("peso_minimo"), Double)
                dblVolumenMinimo = CType(dtTarifa.Rows(0).Item("volumen_minimo"), Double)
                dblFleteMinimoPeso = CType(dtTarifa.Rows(0).Item("flete_minimo_peso"), Double)
                dblFleteMinimoVolumen = CType(dtTarifa.Rows(0).Item("flete_minimo_volumen"), Double)
            Else
                dblPesoMinimo = 0 : dblVolumenMinimo = 0 : dblFleteMinimoPeso = 0 : dblFleteMinimoVolumen = 0
            End If

            With dgv
                dblPeso = CType(.Rows(0).Cells("peso").Value, Double)
                dblVolumen = CType(.Rows(1).Cells("peso").Value, Double)
                dblPrecioVolumen = CType(.Rows(1).Cells("peso").Value, Double)

                If fila = 0 Then
                    If (dblPeso <= dblPesoMinimo) Then
                        Me.fnCalcularCondicionTarifa(fila, dblPeso, dgv("Costo", 0).Value, dblPesoMinimo, dblFleteMinimoPeso, dgv)

                        If (dblPeso = 0) Then '-->Aplica la refla del flete minomo al volumen
                            Me.fnCalcularCondicionTarifa(1, dblVolumen, dgv("Costo", 1).Value, dblPesoMinimo, dblFleteMinimoPeso, dgv)
                        ElseIf (dblVolumen < dblPesoMinimo) Then '-->No aplica la regla fete mimimo al volumne
                            dblSubNetoPeso = dblVolumen * dblPrecioVolumen
                            dgv("Subtotal", 1).Value = dblSubNetoPeso
                        End If

                    ElseIf (dblPeso > dblPesoMinimo) Then
                        Me.fnCalcularCondicionTarifa(fila, dblPeso, dgv("Costo", 0).Value, dblPesoMinimo, dblFleteMinimoPeso, dgv)
                        If (dblVolumen < dblPesoMinimo) Then
                            dblSubNetoPeso = dblVolumen * dblPrecioVolumen
                            dgv("Subtotal", 1).Value = dblSubNetoPeso
                        End If
                    ElseIf (dblVolumen <= dblPesoMinimo) Then
                        Me.fnCalcularCondicionTarifa(fila, dblPeso, dgv("Costo", 1).Value, dblPesoMinimo, dblFleteMinimoPeso, dgv)
                    ElseIf (dblVolumen > dblPesoMinimo) Then
                        dblSubNetoPeso = dblVolumen * dblPrecioVolumen
                        dgv("Subtotal", 1).Value = dblSubNetoPeso
                    End If
                ElseIf fila = 1 Then
                    If (dblPeso = 0) Then
                        Me.fnCalcularCondicionTarifa(fila, dblVolumen, dgv("Costo", 1).Value, dblPesoMinimo, dblFleteMinimoPeso, dgv)

                    ElseIf (dblPeso <= dblPesoMinimo) Then
                        Me.fnCalcularCondicionTarifa(fila, dblVolumen, dgv("Costo", 1).Value, dblPesoMinimo, dblFleteMinimoPeso, dgv)

                        dblSubNetoPeso = dblVolumen * dblPrecioVolumen
                        dgv("Subtotal", 1).Value = dblSubNetoPeso
                    ElseIf (dblPeso > dblPesoMinimo) Then
                        dblSubNetoPeso = dblVolumen * dblPrecioVolumen
                        dgv("Subtotal", 1).Value = dblSubNetoPeso
                    ElseIf (dblVolumen <= dblPesoMinimo) Then
                        Me.fnCalcularCondicionTarifa(fila, dblVolumen, dgv("Costo", 1).Value, dblPesoMinimo, dblFleteMinimoPeso, dgv)
                    ElseIf (dblVolumen > dblPesoMinimo) Then
                        dblSubNetoPeso = dblVolumen * dblPrecioVolumen
                        dgv("Subtotal", 1).Value = dblSubNetoPeso
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub dgvPeso8_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPeso8.CellBeginEdit
        Dim intColumna As Integer, intFila As Integer, intValor As Integer
        intColumna = e.ColumnIndex
        intFila = e.RowIndex
        If Conversion.Val(Me.dgvPeso8(intColumna, intFila).Value) = 0 Then
            Return
        Else
            intValor = Me.dgvPeso8(intColumna, intFila).Value
        End If
        Me.dgvPeso8(intColumna, intFila).Value = intValor
    End Sub

    Private Sub dgvPeso8_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeso8.CellEndEdit
        Dim intColumna As Integer, intFila As Integer, dblTotal As Double, intValor As Double
        intColumna = e.ColumnIndex
        intFila = e.RowIndex

        If intFila > 1 Then
            Me.dgvPeso8(intColumna, intFila).Value = 0
            Return
        End If
        If Conversion.Val(Me.dgvPeso8(e.ColumnIndex, intFila).Value) = 0 Then
            Me.dgvPeso8(intColumna, intFila).Value = 0
        End If

        Calcula(intFila, Me.lblProducto8.Tag, Me.dgvPeso8)
        dblTotal = ObtieneTotalPeso(Me.dgvPeso8, 4)

        Me.lblCantidadTotal.Text = Format(dblTotal, "###,###,###0.00")
    End Sub

    Function ObtieneFilaGrid(dgv As DataGridView, columna As Integer, valor As Integer) As Integer
        With dgv
            For Each row As DataGridViewRow In dgv.Rows
                If row.Cells(columna).Value = valor Then
                    Return row.Index
                End If
            Next
            Return -1
        End With
    End Function

    Private Sub cboDestino10_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDestino10.SelectedIndexChanged
        If dt1.Rows(0).Item("articulo") > 0 Then 'articulos
            ListarTarifa(-1, dt1.Rows(0).Item("origen"), Me.cboDestino10.SelectedValue, dt1.Rows(0).Item("idpersona"), _
                         dt1.Rows(0).Item("tipo_tarifa"), 3)
            If dtTarifa.Rows.Count > 0 Then
                Dim intFila As Integer
                For Each row As DataRow In dtTarifa.Rows
                    intFila = ObtieneFilaGrid(Me.dgvPeso10, 0, row.Item("id"))
                    If intFila >= 0 Then
                        Me.dgvPeso10.Rows(intFila).Cells("precio").Value = row.Item("monto")
                        Calcula(intFila, -1, Me.dgvPeso10)
                    End If
                Next
            End If
        ElseIf Me.lblProducto10.Tag = 10 Then 'sobres
            Dim obj As New Cls_TarifaServicio_LN
            Dim dt As DataTable = obj.ObtenerTarifaServicio(dt1.Rows(0).Item("origen"), Me.cboDestino10.SelectedValue, Me.lblProducto10.Tag, 3, 3, IIf(dt1.Rows(0).Item("tipo_entrega") = 1, 4, 1), dt1.Rows(0).Item("idpersona"), 0)
            If dt.Rows.Count > 0 Then
                Me.dgvPeso10.Rows(2).Cells("costo").Value = Format(CType(dt.Rows(0).Item("monto"), Double), "0.00")
                Calcula(2, Me.lblProducto10.Tag, Me.dgvPeso10)
            End If
        ElseIf Me.lblProducto10.Tag = 81 Then 'tepsa box
            ListarTarifa(dt1.Rows(0).Item("producto"), dt1.Rows(0).Item("origen"), Me.cboDestino10.SelectedValue, dt1.Rows(0).Item("idpersona"), _
                         dt1.Rows(0).Item("tipo_tarifa"), 3, dt1.Rows(0).Item("tipo_entrega"))
            If dtTarifa.Rows.Count > 0 Then
                Me.dgvPeso10.Rows(0).Cells("costo").Value = dtTarifa.Rows(0).Item("monto")
                Me.dgvPeso10.Rows(1).Cells("costo").Value = dtTarifa.Rows(1).Item("monto")
            Else
                Me.dgvPeso10.Rows(0).Cells("costo").Value = "0.00"
                Me.dgvPeso10.Rows(1).Cells("costo").Value = "0.00"
            End If
            Calcula(0, Me.lblProducto10.Tag, Me.dgvPeso10)
            Calcula(1, Me.lblProducto10.Tag, Me.dgvPeso10)
        Else
            ListarTarifa(dt1.Rows(0).Item("producto"), dt1.Rows(0).Item("origen"), Me.cboDestino10.SelectedValue, dt1.Rows(0).Item("idpersona"), _
                         dt1.Rows(0).Item("tipo_tarifa"), 3)
            If dtTarifa.Rows.Count > 0 Then
                Me.dgvPeso10.Rows(0).Cells("costo").Value = dtTarifa.Rows(0).Item("peso")
                Me.dgvPeso10.Rows(1).Cells("costo").Value = dtTarifa.Rows(0).Item("volumen")
            Else
                Me.dgvPeso10.Rows(0).Cells("costo").Value = "0.00"
                Me.dgvPeso10.Rows(1).Cells("costo").Value = "0.00"
            End If
            Calcula(0, Me.lblProducto10.Tag, Me.dgvPeso10)
            Calcula(1, Me.lblProducto10.Tag, Me.dgvPeso10)
        End If

        Dim dblTotal As Double = ObtieneTotalPeso(Me.dgvPeso10, 4)
        Me.lblTotal10.Text = Format(dblTotal, "###,###,###0.00")
    End Sub

    Private Sub dgvRetiro13_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvRetiro13.CellBeginEdit
        Dim intColumna As Integer, intFila As Integer, dblValor As Double
        intColumna = e.ColumnIndex
        intFila = e.RowIndex
        If Conversion.Val(Me.dgvRetiro13(intColumna, intFila).Value) = 0 Then
            Return
        Else
            dblValor = Me.dgvRetiro13(intColumna, intFila).Value
        End If
        Me.dgvRetiro13(intColumna, intFila).Value = dblValor
    End Sub

    Private Sub dgvRetiro13_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetiro13.CellEndEdit
        Dim intColumna As Integer, intFila As Integer, dblTotal As Double, dblValor As Double
        intColumna = e.ColumnIndex
        intFila = e.RowIndex

        If intFila > 1 And dt1.Rows(0).Item("articulo") = 0 Then
            Me.dgvRetiro13(intColumna, intFila).Value = 0
            Return
        End If
        If Conversion.Val(Me.dgvRetiro13(e.ColumnIndex, intFila).Value) = 0 Then
            Me.dgvRetiro13(intColumna, intFila).Value = 0
        End If

        dblValor = RedondearMas(Me.dgvRetiro13(intColumna, intFila).Value)
        Me.dgvRetiro13(intColumna, intFila).Value = Format(dblValor, "0.00")

        If dt1.Rows(0).Item("articulo") = 0 Then
            Calcula(intFila, Me.lblProducto13.Tag, Me.dgvRetiro13)
        Else
            Calcula(intFila, -1, Me.dgvRetiro13)
        End If
        dblTotal = ObtieneTotalPeso(Me.dgvRetiro13, 4)

        Me.lblTotal13.Text = Format(dblTotal, "###,###,###0.00")
    End Sub

    Private Sub frmAgregarOperacion_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If aLista.Count = 0 Then
            'Me.cboTipoOperacion.SelectedIndex = 0
            'Me.cboTipoOperacion.DroppedDown = True
        End If
    End Sub

    Private Sub txtComprobante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtComprobante.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                If Me.txtComprobante.Text.Trim.Length > 0 Then
                    Cursor = Cursors.WaitCursor
                    Me.txtComprobante.Tag = ""

                    Dim obj As New Cls_Autorizacion_LN
                    Dim dt As DataTable = obj.ListarComprobante(Me.txtComprobante.Text.Trim, intOpcion)
                    Me.dgvNuevoComprobante.DataSource = dt
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0).Item("n_emife") = 0 Then 'si no esta dentro de los 10 dias habiles no se emite nc ni anulacion
                            Cursor = Cursors.Default
                            MessageBox.Show("El Comprobante debe ser enviado a SUNAT", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.txtComprobante.Focus()
                            Return
                        End If

                        ActivaDesactivaOperacion(True)
                        Me.txtComprobante.Tag = CType(dt.Rows(0).Item("id"), Integer)

                        Dim intTipoOperacion As Integer = Me.cboOperacion.SelectedValue
                        If intTipoOperacion = 8 Then
                            If Not (dt1.Rows(0).Item("producto") = 10 Or dt1.Rows(0).Item("producto") = 81) Then
                                ActivaDesactivaOperacion(False)
                            End If
                        ElseIf intTipoOperacion = 7 Then
                            If dt1.Rows(0).Item("producto") = 10 Or dt1.Rows(0).Item("producto") = 81 Then
                                ActivaDesactivaOperacion(False)
                            End If
                        End If

                        Dim dblTotal As Double = ObtieneTotalPeso(Me.dgvNuevoComprobante, 8)
                        Me.lblTotalNuevoComprobante.Text = Format(dblTotal, "###,###,###0.00")

                        'valida si nuevo comprobante es correcto segun la operacion
                        If Comprobante = Me.txtComprobante.Tag Then
                            Cursor = Cursors.Default
                            MessageBox.Show("Los Comprobantes deben ser diferentes", "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ActivaDesactivaOperacion(False, 1)
                            Me.txtComprobante.Focus()
                            Return
                        End If
                        If dt.Rows(0).Item("idtipo_comprobante") <> TipoComprobante Then
                            Cursor = Cursors.Default
                            MessageBox.Show("El Tipo de Comprobante debe ser similar", "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ActivaDesactivaOperacion(False, 1)
                            Me.txtComprobante.Focus()
                            Return
                        End If
                        If dt.Rows(0).Item("idcliente") <> Cliente Then
                            Cursor = Cursors.Default
                            MessageBox.Show("El Cliente debe ser similar", "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ActivaDesactivaOperacion(False, 1)
                            Me.txtComprobante.Focus()
                            Return
                        End If
                    Else
                        Cursor = Cursors.Default
                        Me.btnAceptar.Enabled = False
                        MessageBox.Show("El Comprobante no existe o no está Disponible", "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtComprobante.Focus()
                        Me.txtComprobante.SelectAll()
                        Return
                    End If
                    Me.btnAceptar.Enabled = True
                End If
                Cursor = Cursors.Default
            Else
                If ValidaNumero2(e.KeyChar) Then
                    e.Handled = False
                ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtComprobante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtComprobante.TextChanged
        LimpiarNuevoComprobante()
    End Sub

    Sub LimpiarNuevoComprobante()
        Me.dgvNuevoComprobante.DataSource = Nothing
        FormatearDGVNuevoComprobante()
        Me.lblTotalNuevoComprobante.Text = "0.00"
        Me.btnAceptar.Enabled = False

    End Sub

    Private Sub cboDevolucionDinero_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDevolucionDinero.SelectedIndexChanged
        Me.txtMonto.Enabled = Me.cboDevolucionDinero.SelectedIndex = 1
        If txtMonto.Enabled Then
            Me.txtMonto.Text = Me.lblTotal12.Text
            Me.btnAceptar.Focus()
        Else
            Me.txtMonto.Text = "0.00"
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAceptar.Focus()
        Else
            e.Handled = Not ValidarNumeroReal(e.KeyChar, Me.txtMonto.Text)
        End If
    End Sub

    Private Sub txtMonto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.LostFocus
        If Val(Me.txtMonto.Text) = 0 Then
            Me.txtMonto.Text = "0.00"
        Else
            Me.txtMonto.Text = Format(CType(Me.txtMonto.Text, Double), "0.00")
        End If
    End Sub

    Private Sub txtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.TextChanged

    End Sub
End Class